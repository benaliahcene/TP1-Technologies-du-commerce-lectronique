using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DemoAspNet.Models
{ 
    public class Panier
    {
        public int Id { get; set; }
        public string? Title { get; set; }       
        public string? Vendeur { get; set; }
        public float? PrixU { get; set; }
        public int? Quantite { get; set; }

        // relations
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public ICollection<PanierProduct>? PanierProducts { get; set; }


    }
}
