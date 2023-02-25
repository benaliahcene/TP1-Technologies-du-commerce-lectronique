using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DemoAspNet.Models
{
    public class Stat
    {
        public int? Id { get; set; }
        public double? Sommes { get; set; }
        public string? NbrArticle { get; set; }


    }
}
