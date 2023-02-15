using System.ComponentModel.DataAnnotations;

namespace DemoAspNet.Models
{
    public class Client
    {
      
        public string? ClientId { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public string? Nom { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public string? Prenom { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public float? Solde { get; set; }
        public ICollection<Product>? Products { get; set;}

    }
}
