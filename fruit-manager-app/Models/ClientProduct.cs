namespace DemoAspNet.Models
{
    public class ClientProduct
    {
        public int? Id { get; set; }
        public int? ClientId { get; set; }
        public Client? Client { get; set; }
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
