using Microsoft.EntityFrameworkCore;
using VehicleCatalog.Models;

namespace VehicleCatalog.Data
{
    public class VehicleCatalogDataContext :DbContext
    {
        public VehicleCatalogDataContext(DbContextOptions<VehicleCatalogDataContext> options) : base(options) 
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DOMAGOJ;Database=Vehicel;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<VehicleMake> Makes { get; set; }
        public DbSet<VehicleModel> Models { get; set; }


    }
}
