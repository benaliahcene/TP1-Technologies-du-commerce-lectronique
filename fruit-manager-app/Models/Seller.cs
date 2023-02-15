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
        public string? Id { get; set; }
    }
}
