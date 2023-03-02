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
    public class PanierController : Controller
    {
         public IActionResult Panier()
        {
            ViewBag.Title = "Panier";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("ahcene");

            List<Models.Panier> paniers = tpAspNetDbContext.Paniers.Where(c => c.ClientId == Convert.ToInt32(id)).ToList();
            ViewBag.Products = paniers;
            return View();

        }
        [HttpGet]
        [Route("Home/RemoveProduct/{Id:int}")]
        public IActionResult RemoveProduct(int Id)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Product product = tpAspNetDbContext.Products.Find(Id); Console.WriteLine(Id);
            tpAspNetDbContext.Products.Remove(product);
            tpAspNetDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Home/panierproduct/{Id:int}")]

        public IActionResult PanierProduct(int Id)
        {
            HttpContext.Session.LoadAsync();
            string id = HttpContext.Session.GetString("ahcene");
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Product product = tpAspNetDbContext.Products.Find(Id); Console.WriteLine(Id);
            Models.Panier panier = new Panier();
            /*  panier.Id = product.Id;  */
            Console.WriteLine("test");
            Console.WriteLine(id);
            Console.WriteLine("test");

            /*            panier.ClientId = int.Parse((id),CultureInfo.InvariantCulture.NumberFormat);
            */
            panier.ClientId = (int?)Convert.ToInt32((id), CultureInfo.InvariantCulture.NumberFormat);
            
            panier.Vendeur = product.Vendeur;
            panier.PrixU = (float)product.Prix;
            panier.PrixTotal = (float)panier.PrixU;
            panier.Title = product.Title;
            panier.Quantite = 1;
            tpAspNetDbContext.Paniers.Add(panier);
            tpAspNetDbContext.SaveChanges();

            return RedirectToAction("Panier");
        }
        [HttpGet]
        [Route("Home/RemoveProductPanier/{Id:int}")]
        public IActionResult RemoveProductPanier(int Id)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Panier panier = tpAspNetDbContext.Paniers.Find(Id); Console.WriteLine(Id);
            tpAspNetDbContext.Paniers.Remove(panier);
            tpAspNetDbContext.SaveChanges();

            return RedirectToAction("Panier");
        }

        [HttpPost]
        public IActionResult Paiement(string Title,int Quantite, int Id, float PrixU)
        {
            Console.WriteLine(Title); 
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Panier panier = tpAspNetDbContext.Paniers.Find(Id);
			HttpContext.Session.SetString("ceFacture", Id.ToString());
			panier.PrixTotal = Quantite * PrixU; 
            panier.Quantite = Quantite;
            tpAspNetDbContext.SaveChanges();
            panier.Title= Title;

            //Effacer le produit du panier
            Models.Facture facture = new Models.Facture();
            facture.Id = Id;
            facture.Quantite = Quantite;
            facture.PrixU = PrixU;
            facture.PrixT= Quantite * PrixU;
            facture.Title= Title;
            facture.ClientId = panier.ClientId;
            tpAspNetDbContext.Factures.Add(facture);
            tpAspNetDbContext.Paniers.Remove(panier);
            Models.Stat stat= new Models.Stat();
            stat.Id = Id;
            stat.Sommes = Quantite * PrixU;
            stat.NbrArticle = Quantite;
            stat.ClientId = panier.ClientId;
            tpAspNetDbContext.Stats.Add(stat);

			tpAspNetDbContext.SaveChanges();
            // Enregistrer les informations du panier dans la base de donnees
            return RedirectToAction("Facture");
        }

        public IActionResult Facture()
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("ahcene");

            List<Models.Facture> factures = tpAspNetDbContext.Factures.Where(c => c.ClientId == Convert.ToInt32(id)).ToList();
            
            ViewBag.Paniers = factures;
      
            return View();
        }



    }

}

