namespace DemoAspNet.Models
{
    public class Facture
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public float? PrixU { get; set; }
        public int? Quantite { get; set; }
        public float? PrixT { get; set; }
         public int? ClientId { get; set; }
        public Client? Client { get; set; }
    }
}


