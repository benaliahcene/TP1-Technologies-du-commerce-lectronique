namespace DemoAspNet.Models
{
	public class FactureSeller
	{
		public int? Id { get; set; }
		public DateTime? Date { get; set; }
		public string? Client { get; set; }
		public int? FactureClientId { get; set; }
		public int? SellerId { get; set; }
		public Seller? Seller { get; set; }
	}
}


