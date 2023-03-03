using System.ComponentModel.DataAnnotations;

namespace DemoAspNet.Models
{
    public class Seller
    {
        [Required(ErrorMessage = "Champs requis !")]
        public string? Nom { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public string? Prenom { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public int? Id { get; set; }
		[Required(ErrorMessage = "Champs requis !")]
		public string? Mdp { get; set; }

		//relations
		public ICollection<Product>? Products { get; set; }
		public ICollection<StatSeller>? StatSellers { get; set; }
		public ICollection<FactureSeller>? FactureSellers { get; set; }


	}
}
