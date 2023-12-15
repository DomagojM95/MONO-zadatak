using Microsoft.EntityFrameworkCore;
using VehicleCatalog.Models;

namespace VehicleCatalog.Data
{
    public class VehicleCatalogContext:DbContext
    {
     public VehicleCatalogContext(DbContextOptions<VehicleCatalogContext> options) : base(options) { }

     public DbSet<VehicleMake> VehicleMake { get; set; }
     public DbSet<VehicleModel> VehicleModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>().HasOne(m => m.MakeID);

        }
    }
}
