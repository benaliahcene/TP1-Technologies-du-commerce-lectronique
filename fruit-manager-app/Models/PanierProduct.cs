using DemoAspNet.Models;

namespace DemoAspNet.Models
{
    public class PanierProduct
    {
        public int Id { get; set; }
        public int? PanierId { get; set; }
        public Panier? Panier { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
