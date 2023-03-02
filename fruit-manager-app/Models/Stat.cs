using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DemoAspNet.Models
{
    public class Stat
    {
        public int? Id { get; set; }
        public float? Sommes { get; set; }
        public int? NbrArticle { get; set; }
		public int? ClientId { get; set; }
		public Client? Client { get; set; }


	}
}
