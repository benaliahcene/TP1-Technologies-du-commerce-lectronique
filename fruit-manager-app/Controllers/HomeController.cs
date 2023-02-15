using CsvHelper;
using DemoAspNet.Models;
using fruit_manager_app;
using Intercom.Core;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DemoAspNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Page des produits";
           

            List<Models.Product> products = new List<Models.Product>();

            using (var reader = new StreamReader("Data/data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    products.Add(
                       new Models.Product { Title = csv.GetField("ProductTitle"),
                           Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat),
                           Categorie = csv.GetField("Category"),
                           Description = csv.GetField("Usage"),
                           Pour = csv.GetField("Gender"),
                           Vendeur =csv.GetField("Seller"),
                           URLimg = csv.GetField("ImageURL") }
                   );
                };
            }
           
            ViewBag.Products = products;
            return View();
            /*     return View();*/


        }
        public IActionResult ProductsPage()
        {
            ViewBag.Title = "Page des produits";

            List<Models.Product> products = new List<Models.Product>();

            using (var reader = new StreamReader("Data/data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    products.Add(
                       new Models.Product
                       {
                           Title = csv.GetField("ProductTitle"),
                           Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat),
                           Categorie = csv.GetField("Category"),
                           Description = csv.GetField("Usage"),
                           Pour = csv.GetField("Gender"),
                           Vendeur = csv.GetField("Seller"),
                           URLimg = csv.GetField("ImageURL")
                       }
                   );
                };
            }

            return View(products);
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

            List<Models.Product> products = new List<Models.Product>();
            using (var reader = new StreamReader("Data/data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    products.Add(
                       new Models.Product
                       {
                           Title = csv.GetField("ProductTitle"),
                           Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat),
                           Categorie = csv.GetField("Category"),
                           Description = csv.GetField("Usage"),
                           Pour = csv.GetField("Gender"),
                           Vendeur = csv.GetField("Seller"),
                           URLimg = csv.GetField("ImageURL")
                       }
                   );
                };
            }
            return View(products);
        }
        // Ajouter un client au base de données 
        [HttpGet]
        public IActionResult ClientLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClient(Models.Client client)
        {
           
            TpAspNetDbContext tpAspNetDbContext=new TpAspNetDbContext();
            tpAspNetDbContext.Clients.Add(client);
            tpAspNetDbContext.SaveChanges();

            return RedirectToAction("ClientLogin");
            
        }
        public IActionResult AddClient()
        {

          return View();

        }
        // ajouter un vendeur au base de données
        [HttpGet]
        public IActionResult SellerLogin()
        {
            ViewBag.Title = "Nouveau Profil";

            return View();
        }
        [HttpPost]
        public IActionResult AddSeller(Models.Seller seller)
        {

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            tpAspNetDbContext.sellers.Add(seller);
            tpAspNetDbContext.SaveChanges();

            return RedirectToAction("SellerLogin");

        }
        public IActionResult AddSeller()
        {

            return View();

        }
        // modification de compte client
        public IActionResult EditProfilClient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Models.Product product)
        {
            ViewBag.Title = "Ajouter un produit";

            if (ModelState.IsValid)
                return RedirectToAction("Results", product);

            return View();
        }


        /* public IActionResult Results()
         {
             return RedirectToAction("Index");
         }*/
        
        public IActionResult EditProfilVendeur(Models.Seller seller)
        {

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            tpAspNetDbContext.sellers.Update(seller);
            tpAspNetDbContext.SaveChanges();
            return View();
        }

        public ActionResult ClientPage()
        {
          
             List<Models.Product> products = new List<Models.Product>();

            using (var reader = new StreamReader("Data/data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    products.Add(
                       new Models.Product
                       {
                           Title = csv.GetField("ProductTitle"),
                           Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat),
                           Categorie = csv.GetField("Category"),
                           Description = csv.GetField("Usage"),
                           Pour = csv.GetField("Gender"),
                           Vendeur = csv.GetField("Seller"),
                           URLimg = csv.GetField("ImageURL")
                       }
                   );
                };
            }

            return View(products);
        }
        public IActionResult ClientListeFactures()
        {
            return View();
        }

        // hello test
        public IActionResult SellerListeFactures()
        {
            return View();
        }

       
        public IActionResult SellerPage(Models.Seller user_product)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            List<Models.Seller> Sell = tpAspNetDbContext.sellers.ToList();
            List<Models.Seller> match_sellers = new List<Models.Seller>();
            List<Models.Product> products = new List<Models.Product>();
            string nom_1 = "Albert";
            string nom_2 = "Amelie";
            string nom_3 = "Julie";
            string nom_4 = "Xavier";
           
            user_product.Nom = String.IsNullOrEmpty(user_product.Nom) ? String.Empty : user_product.Nom;
            foreach (Models.Seller seller in Sell)
            {
                if (seller.Nom.Equals(user_product.Nom))
                { if(nom_1.Equals(user_product.Nom))
                    {
                        ViewBag.Nom_Vendeur = "Albert";

                        Console.WriteLine(seller.Nom);
                    Console.WriteLine("test1");

                    Console.WriteLine(user_product.Nom);

                    using (var reader = new StreamReader("Data/Albert/Albert.csv"))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            Console.WriteLine("Data/Albert/Images/" + csv.GetField("Image"));
                            products.Add(

                               new Models.Product { Title = csv.GetField("ProductTitle"), Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat), Categorie = csv.GetField("Category"), Description = csv.GetField("Usage"), Pour = csv.GetField("Gender"), Vendeur = "Albert", URLimg = csv.GetField("ImageURL") }
                           );


                        };
                    }
                    return View(products);
                  }
                    if (nom_2.Equals(user_product.Nom))
                    {
                        ViewBag.Nom_Vendeur = "Amelie";

                        Console.WriteLine(seller.Nom);
                        Console.WriteLine("test1");

                        Console.WriteLine(user_product.Nom);

                        using (var reader = new StreamReader("Data/Amélie/Amélie.csv"))
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                Console.WriteLine("Data/Amelie/Images/" + csv.GetField("Image"));
                                products.Add(

                                   new Models.Product { Title = csv.GetField("ProductTitle"), Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat), Categorie = csv.GetField("Category"), Description = csv.GetField("Usage"), Pour = csv.GetField("Gender"), Vendeur = "Albert", URLimg = csv.GetField("ImageURL") }
                               );


                            };
                        }
                        return View(products);
                    }
                    if (nom_3.Equals(user_product.Nom))
                    {
                        ViewBag.Nom_Vendeur = "Julie";

                        Console.WriteLine(seller.Nom);
                        Console.WriteLine("test1");

                        Console.WriteLine(user_product.Nom);

                        using (var reader = new StreamReader("Data/Julie/Julie.csv"))
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                Console.WriteLine("Data/Julie/Images/" + csv.GetField("Image"));
                                products.Add(

                                   new Models.Product { Title = csv.GetField("ProductTitle"), Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat), Categorie = csv.GetField("Category"), Description = csv.GetField("Usage"), Pour = csv.GetField("Gender"), Vendeur = "Albert", URLimg = csv.GetField("ImageURL") }
                               );


                            };
                        }
                        return View(products);
                    }
                    if (nom_4.Equals(user_product.Nom))
                    {
                        ViewBag.Nom_Vendeur = "Xavier" ;
                        Console.WriteLine(seller.Nom);
                        Console.WriteLine("test1");

                        Console.WriteLine(user_product.Nom);

                        using (var reader = new StreamReader("Data/Xavier/Xavier.csv"))
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            csv.Read();
                            csv.ReadHeader();
                            while (csv.Read())
                            {
                                Console.WriteLine("Data/Xavier/Images/" + csv.GetField("Image"));
                                products.Add(

                                   new Models.Product { Title = csv.GetField("ProductTitle"), Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat), Categorie = csv.GetField("Category"), Description = csv.GetField("Usage"), Pour = csv.GetField("Gender"), Vendeur = "Albert", URLimg = csv.GetField("ImageURL") }
                               );


                            };
                        }
                        return View(products);
                    }

                }
              
               
            }
            return RedirectToAction("SellerLogin");
            /*ViewBag.Seller = Sell;*/


            /*ViewBag.Title = "Page de contact";
            List<Models.Product> products = new List<Models.Product>();

            using (var reader = new StreamReader("Data/Albert/Albert.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    Console.WriteLine("Data/Albert/Images/" + csv.GetField("Image"));
                    products.Add(

                       new Models.Product { Title = csv.GetField("ProductTitle"), Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat), Categorie = csv.GetField("Category"), Description = csv.GetField("Usage"), Pour = csv.GetField("Gender"), Vendeur = "Albert", URLimg = csv.GetField("ImageURL") }
                   );


                };
            }
            return View(products);*/
            return View();
            
        }



        [HttpPost]
        public IActionResult Results(Models.Product user_product)
        {
            List<Models.Product> products = new List<Models.Product>();

            using (var reader = new StreamReader("Data/Albert/Albert.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    Console.WriteLine("Data/Albert/Images/" + csv.GetField("Image"));
                    products.Add(

                       new Models.Product { Title = csv.GetField("ProductTitle"), Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat), Categorie = csv.GetField("Category"), Description = csv.GetField("Usage"), Pour = csv.GetField("Gender"), Vendeur = "Albert", URLimg = csv.GetField("ImageURL") }
                   );


                };
            }
            using (var reader = new StreamReader("Data/Amélie/Amélie.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    products.Add(

                       new Models.Product { Title = csv.GetField("ProductTitle"), Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat), Categorie = csv.GetField("Category"), Description = csv.GetField("Usage"), Pour = csv.GetField("Gender"), Vendeur = "Amélie", URLimg = csv.GetField("ImageURL") }
                   );


                };
            }
            using (var reader = new StreamReader("Data/Julie/Julie.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    products.Add(

                       new Models.Product { Title = csv.GetField("ProductTitle"), Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat), Categorie = csv.GetField("Category"), Description = csv.GetField("Usage"), Pour = csv.GetField("Gender"), Vendeur = "Julie", URLimg = csv.GetField("ImageURL") }
                   );


                };
            }
            using (var reader = new StreamReader("Data/Xavier/Xavier.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    products.Add(

                       new Models.Product { Title = csv.GetField("ProductTitle"), Prix = float.Parse(csv.GetField("Price"), CultureInfo.InvariantCulture.NumberFormat), Categorie = csv.GetField("Category"), Description = csv.GetField("Usage"), Pour = csv.GetField("Gender"), Vendeur = "Xavier", URLimg = csv.GetField("ImageURL") }
                   );


                };
            }


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
    }

}

