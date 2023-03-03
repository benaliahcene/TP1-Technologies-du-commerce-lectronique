using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DemoAspNet.Models
{
    public class Client
    {
        
        public int? Id { get; set; } 
        [Required(ErrorMessage = "Champs requis !")]
        public string? Nom { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public string? Prenom { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public float? Solde { get; set; }
		[Required(ErrorMessage = "Champs requis !")]
		public string? Mdp { get; set; }
		public ICollection<ClientProduct>? ClientProducts { get; set; }

        public ICollection<Panier>? Paniers { get; set; }
        public ICollection<Facture>? Factures { get; set; }
		public ICollection<Stat>? Stats { get; set; }



	}
}
