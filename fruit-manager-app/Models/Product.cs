using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAspNet.Models
{
    public class Product
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public string? Title { get; set; }
             
        [Required(ErrorMessage = "Champs requis !")]
        public string? Categorie { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public string? Pour { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public string? Vendeur { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public double? Prix { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Champs requis !")]
        public string? URLimg { get; set; }
        /*        public int? Nbr { get; set; } = 0;
        */
        //relations

       public int  FK_ClientId { get; set; }
       public Client? Client { get; set; }           

    }
}
