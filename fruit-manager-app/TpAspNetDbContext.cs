using Microsoft.EntityFrameworkCore;

namespace fruit_manager_app
{
    public class TpAspNetDbContext: DbContext
    {
        public DbSet<DemoAspNet.Models.Product> Products { get; set; }
        public DbSet<DemoAspNet.Models.Client> Clients { get; set; }
        public DbSet<DemoAspNet.Models.Seller> sellers { get; set; }
        public DbSet<DemoAspNet.Models.Stat> Stats { get; set; }
        public DbSet<DemoAspNet.Models.Panier> Paniers { get; set; }
        public DbSet<DemoAspNet.Models.Facture> Factures { get; set; }







        protected override void OnConfiguring(DbContextOptionsBuilder DbContextOptionsBuilder)
        {
            string connection_string = "Data Source=DESKTOP-4MISVQS\\SQLEXPRESS02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string database_TP = "database";
            DbContextOptionsBuilder.UseSqlServer($"{connection_string};Database={database_TP}; ");
        }

    }
}
