using DemoAspNet.Models;
using fruit_manager_app;
using Intercom.Core;
using Intercom.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;

namespace DemoAspNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Page des produits";
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
/*            List<Models.Product> products = tpAspNetDbContext.Products.Where(c => c.SellerId == user_product.Id).ToList();
*/
            List<Models.Product> products = tpAspNetDbContext.Products.ToList();
            ViewBag.Products = products;
            return View();


        }
        public IActionResult ProductsPage()
        {
            ViewBag.Title = "Page des produits";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            List<Models.Product> products = tpAspNetDbContext.Products.ToList();
            ViewBag.Products = products;
            return View();
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Title = "Ajouter un produit";
            return View();
        }

        public IActionResult Panier()
        {
            ViewBag.Title = "Panier";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            List<Models.Panier> panier = tpAspNetDbContext.Paniers.ToList();
            ViewBag.Products = panier;
            return View();

        }
        // Ajouter un client au base de données 
        [HttpGet]
        public IActionResult ClientLogin()
        {
            ViewBag.Title = "Client - connexion";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            List<Models.Client> clients = tpAspNetDbContext.Clients.ToList();

            ViewBag.Clients = clients;
            return View();
        }
        [HttpPost]
        public IActionResult AddClient(Models.Client client)
        {
            ViewBag.Title = "Ajouter un client";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            tpAspNetDbContext.Clients.Add(client);
            tpAspNetDbContext.SaveChanges();

            return RedirectToAction("ClientLogin");

        }
        public IActionResult AddClient()
        {
            return View();
        }
        public IActionResult AddProduct(Models.Product product)
        {
			string id = HttpContext.Session.GetString("vendeur");

			TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
			Models.Seller seller = tpAspNetDbContext.sellers.Find(Convert.ToInt32(id));
			product.SellerId = Convert.ToInt32(id);
            product.Vendeur = seller.Nom;
            tpAspNetDbContext.Products.Add(product);
            tpAspNetDbContext.SaveChanges();

            return View();

        }
        // ajouter un vendeur au base de données
        [HttpGet]
        public IActionResult SellerLogin()
        {
            ViewBag.Title = "Vendeur - connexion";
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            List<Models.Seller> Sell = tpAspNetDbContext.sellers.ToList();
			ViewBag.Sellers = Sell;

            return View();
        }
        [HttpPost]
        public IActionResult AddSeller(Models.Seller seller)
        {
            ViewBag.Title = "Ajouter - vendeur ";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            tpAspNetDbContext.sellers.Add(seller);
            tpAspNetDbContext.SaveChanges();

            return RedirectToAction("SellerLogin");

        }
        public IActionResult AddSeller()
        {
            ViewBag.Title = "Ajouter - vendeur ";

            return View();

        }
        // modification de compte client
        public IActionResult EditProfilClient()
        {
            ViewBag.Title = "Modification du profil ";
            string id = HttpContext.Session.GetString("ahcene");

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Client client = tpAspNetDbContext.Clients.Find(Convert.ToInt32(id)); Console.WriteLine(id);
            ViewBag.Nom_Client = client.Nom;
            ViewBag.Id_Client = client.Id;
            return View();
        }
        public IActionResult EditProfilClients(string nom, string prenom, float solde)
        {
            ViewBag.Title = "Modification du profil ";
            string id = HttpContext.Session.GetString("ahcene");

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Client client = tpAspNetDbContext.Clients.Find(Convert.ToInt32(id)); Console.WriteLine(id);
            Console.WriteLine(client.Nom); Console.WriteLine(client.Prenom);
            client.Nom = nom;
            client.Prenom = prenom;
            client.Solde = solde;
            tpAspNetDbContext.SaveChanges();
            return RedirectToAction("ClientPage");
        }


        [HttpPost]
        /* public IActionResult AddProduct(Models.Product product)
         {
             ViewBag.Title = "Ajouter un produit";

             if (ModelState.IsValid)
                 return RedirectToAction("Results", product);

             return View();
         }*/


        /* public IActionResult Results()
         {
             return RedirectToAction("Index");
         }*/

        public IActionResult EditProfilVendeur(string nom, string prenom)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();

            ViewBag.Title = "Modification du profil ";
            string id = HttpContext.Session.GetString("vendeur");


            Models.Seller seller = tpAspNetDbContext.sellers.Find(Convert.ToInt32(id)); Console.WriteLine(Convert.ToInt32(id));
            Console.WriteLine(seller.Nom); Console.WriteLine(seller.Prenom);
            seller.Nom = nom;
            seller.Prenom = prenom;
            tpAspNetDbContext.SaveChanges();
            return RedirectToAction("SellerPage");
        }
        public IActionResult EditProfilVendeur()
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();

            ViewBag.Title = "Modification du profil ";
            string id = HttpContext.Session.GetString("vendeur");


            Models.Seller seller = tpAspNetDbContext.sellers.Find(Convert.ToInt32(id)); Console.WriteLine(Convert.ToInt32(id));
            ViewBag.Nom_Vendeur = seller.Nom; Console.WriteLine("test", seller.Nom);

            return View();
        }
        //eferf
        public IActionResult ClientPage(Models.Client uclient)
        {
            ViewBag.Title = "Page Client ";
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("ahcene");
            Models.Client client = tpAspNetDbContext.Clients.Find(Convert.ToInt32(id));
            ViewBag.Nom_Client = client.Nom;
            ViewBag.Id_Client = client.Id;
            Console.WriteLine(client.Nom);
            List<Models.Product> products = tpAspNetDbContext.Products.ToList();
            ViewBag.Products = products;
            return View();

        }
        public IActionResult ClientPageT(Models.Client client)
        {
            ViewBag.Title = "Page client ";
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();

			HttpContext.Session.SetString("ahcene", client.Id.ToString());
            Console.Write(client.Id);
            Models.Client client1= tpAspNetDbContext.Clients.Find(client.Id);
            if(client1.Mdp.Equals(client.Mdp))
            {
                return RedirectToAction("ClientPage",client);
            }
            TempData["AlertMessage"] = "Mot de passe incorrect !!";
            return RedirectToAction("ClientLogin");
        }
        public IActionResult StatClient()
        {
            ViewBag.Title = "Statistiques ";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("ahcene");
            Models.Client client = tpAspNetDbContext.Clients.Find(Convert.ToInt32(id));

            ViewBag.Nom_Client = client.Nom;
            ViewBag.Id_Client = client.Id;
            List<Models.Stat> Stats = tpAspNetDbContext.Stats.Where(c => c.ClientId == Convert.ToInt32(id)).ToList();
			return View(Stats);
        }
        public IActionResult ClientListeFactures()
        {
            ViewBag.Title = "Factures ";
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("ahcene");
            Models.Client client = tpAspNetDbContext.Clients.Find(Convert.ToInt32(id));

            ViewBag.Nom_Client = client.Nom;
            ViewBag.Id_Client = client.Id;
            return View(client);
        }

        // hello test
        public IActionResult SellerListeFactures()
		{
			ViewBag.Title = "Factures ";
			TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("vendeur");
            Models.Seller seller = tpAspNetDbContext.sellers.Find(Convert.ToInt32(id));

            ViewBag.Nom_Vendeur = seller.Nom;
            Console.WriteLine(id); Console.WriteLine(id); Console.WriteLine(id); Console.WriteLine(id); Console.WriteLine(id);
			List<Models.FactureSeller> factures = tpAspNetDbContext.FactureSellers.Where(c => c.SellerId == Convert.ToInt32(id)).ToList();
			ViewBag.Factures= factures;
            return View();
        }
        public IActionResult SellerPageT(Models.Seller user_product)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();

            if (user_product.Id > 0)
            {
                HttpContext.Session.SetString("vendeur", user_product.Id.ToString());

                Models.Seller seller = tpAspNetDbContext.sellers.Find(user_product.Id);
                if (seller.Mdp.Equals(user_product.Mdp))
                {
                    HttpContext.Session.SetString("mdp", user_product.Mdp.ToString());


                    return RedirectToAction("SellerPage", user_product);
                }

                TempData["AlertMessage"] = "Mot de passe incorrect !!";
                return RedirectToAction("SellerLogin");
            }
            TempData["AlertMessage"] = "veuillez choisir le vendeur !!";
            return RedirectToAction("SellerLogin");


        }

        public IActionResult SellerPage(Models.Seller user_product)
        {
            ViewBag.Title = "Page Vendeur ";
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("vendeur");
            string mdp = HttpContext.Session.GetString("mdp");
            Models.Seller seller = tpAspNetDbContext.sellers.Find(Convert.ToInt32(id));

            ViewBag.Nom_Vendeur = seller.Nom;
            ViewBag.Id_Vendeur = seller.Id;
            Console.WriteLine(seller.Nom);
            List<Models.Product> products = tpAspNetDbContext.Products.Where(c => c.SellerId == seller.Id).ToList();
            ViewBag.Products = products;
            return View();
			
        }
		public IActionResult StatSeller()
		{
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("vendeur");
            Models.Seller seller = tpAspNetDbContext.sellers.Find(Convert.ToInt32(id));

            ViewBag.Nom_Vendeur = seller.Nom;
            ViewBag.Id_Vendeur = seller.Id;
			List<Models.StatSeller> statSellers = tpAspNetDbContext.StatSellers.Where(c => c.SellerId == Convert.ToInt32(id)).ToList();
			ViewBag.StatSeller = statSellers;
			return View();
		}

		[HttpPost]
        public IActionResult Results(Models.Product user_product)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("ahcene");
            Models.Client client = tpAspNetDbContext.Clients.Find(Convert.ToInt32(id));

            ViewBag.Nom_Client = client.Nom;
            ViewBag.Id_Client = client.Id;
            List<Models.Product> products = tpAspNetDbContext.Products.ToList();
            List<Models.Product> match_products = new List<Models.Product>();

            user_product.Title = String.IsNullOrEmpty(user_product.Title) ? String.Empty : user_product.Title;
            user_product.Vendeur = String.IsNullOrEmpty(user_product.Vendeur) ? String.Empty : user_product.Vendeur;
            user_product.Categorie = String.IsNullOrEmpty(user_product.Categorie) ? String.Empty : user_product.Categorie;

            foreach (Models.Product product in products)
            {
                if (product.Title.Contains(user_product.Title) && product.Vendeur.Contains(user_product.Vendeur) && product.Categorie.Contains(user_product.Categorie))
                {
                    match_products.Add(product);
                }
            }

            return View(match_products);
        }
        [HttpPost]
        public IActionResult ResultsIndex(Models.Product user_product)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            List<Models.Product> products = tpAspNetDbContext.Products.ToList();
            List<Models.Product> match_products = new List<Models.Product>();

            user_product.Title = String.IsNullOrEmpty(user_product.Title) ? String.Empty : user_product.Title;
            user_product.Vendeur = String.IsNullOrEmpty(user_product.Vendeur) ? String.Empty : user_product.Vendeur;
            user_product.Categorie = String.IsNullOrEmpty(user_product.Categorie) ? String.Empty : user_product.Categorie;

            foreach (Models.Product product in products)
            {
                if (product.Title.Contains(user_product.Title) && product.Vendeur.Contains(user_product.Vendeur) && product.Categorie.Contains(user_product.Categorie))
                {
                    match_products.Add(product);
                }
            }

            return View(match_products);
        }

      
        [HttpPost]
        public IActionResult MessageC(int Id, float solde)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Client client = tpAspNetDbContext.Clients.Find(Id);
            client.Solde=client.Solde+solde;
            tpAspNetDbContext.SaveChanges();
            return View();
        }
   

		[HttpGet]
		[Route("Home/voirfacture/{Id:int}")]
		public IActionResult RemoveProductPanier(int Id)
		{
			TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
			Models.Facture facture = tpAspNetDbContext.Factures.Find(Id); Console.WriteLine(Id);

            TempData["AlertMessage"] = $"titre : {facture.Title} , somme : {facture.PrixT}$  quantite: {facture.Quantite}.";
			return RedirectToAction("SellerListeFactures");
		}

	}

}

