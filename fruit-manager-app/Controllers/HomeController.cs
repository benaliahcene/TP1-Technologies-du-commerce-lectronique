﻿using DemoAspNet.Models;
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
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
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

            return View();
        }
        public IActionResult EditProfilClients(string nom, string prenom, int id, float solde)
        {
            ViewBag.Title = "Modification du profil ";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Client client = tpAspNetDbContext.Clients.Find(id); Console.WriteLine(id);
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

        public IActionResult EditProfilVendeur(string nom, string prenom, int id)
        {
            ViewBag.Title = "Modification du profil ";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Seller seller = tpAspNetDbContext.sellers.Find(id); Console.WriteLine(id);
            Console.WriteLine(seller.Nom); Console.WriteLine(seller.Prenom);
            seller.Nom = nom;
            seller.Prenom = prenom;
            tpAspNetDbContext.SaveChanges();
            return RedirectToAction("SellerPage");
        }
        public IActionResult EditProfilVendeur()
        {
            ViewBag.Title = "Modification du profil ";

            return View();
        }
        //eferf
        public IActionResult ClientPage(Models.Client client)
        {
            ViewBag.Title = "Page client ";
            ViewBag.Nom = client.Nom;
            Console.WriteLine(client.Nom);
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            List<Models.Product> products = tpAspNetDbContext.Products.ToList();
            HttpContext.Session.SetString("ahcene",client.Id.ToString());

            ViewBag.Products = products;

            return View();
        }
        public IActionResult StatClient()
        {
            ViewBag.Title = "Statistiques ";

            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            List<Models.Stat> Stats = tpAspNetDbContext.Stats.ToList();
            return View(Stats);
        }
        public IActionResult ClientListeFactures()
        {
            ViewBag.Title = "Factures ";
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            string id = HttpContext.Session.GetString("ahcene");
            Models.Client client = tpAspNetDbContext.Clients.Find(Convert.ToInt32(id));
            return View(client);
        }

        // hello test
        public IActionResult SellerListeFactures()
        {
            ViewBag.Title = "Factures ";
            return View();
        }


        public IActionResult SellerPage(Models.Seller user_product)
        {
            ViewBag.Title = "Page Vendeur ";
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();

            if (user_product.Id > 0)
            {
                ViewBag.Nom_Vendeur = user_product.Nom;
                ViewBag.Id_Vendeur = user_product.Id;
                Console.WriteLine(user_product.Nom);
                List<Models.Product> products = tpAspNetDbContext.Products.Where(c => c.SellerId == user_product.Id).ToList();
                ViewBag.Products = products;
                return View();
            }
            return RedirectToAction("SellerLogin");


        }

        [HttpPost]
        public IActionResult Results(Models.Product user_product)
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
     
    /*    [HttpPost]
        public IActionResult Paiement( float PrixU)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Stat stat =new Stat();
            stat.NbrArticle = "1";
            stat.Sommes = PrixU;
            Console.WriteLine("teho");
            tpAspNetDbContext.Stats.Add(stat);
            tpAspNetDbContext.SaveChanges();


            return RedirectToAction("StatClient");
        }*/
        public IActionResult Facture(int Id)
        {
        return View();  
        }
        [HttpPost]
        public IActionResult MessageC(int id, float solde)
        {
            TpAspNetDbContext tpAspNetDbContext = new TpAspNetDbContext();
            Models.Client client = tpAspNetDbContext.Clients.Find(id);
            client.Solde=client.Solde+solde;
            tpAspNetDbContext.SaveChanges();
            return View();
        }
        
        
    }

}

