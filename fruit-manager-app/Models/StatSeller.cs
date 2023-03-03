using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DemoAspNet.Models
{
	public class StatSeller
	{
		public int? Id { get; set; }
		public float? SommesR { get; set; }
		public float? Benefice { get; set; } 
		public int? NbrArticleV { get; set; }
		public int? SellerId { get; set; }
		public Seller? Seller { get; set; }


	}
}
