namespace VehicleCatalog.Models
{
    public abstract class VehicleMake:Entity
    {
        public string? CarName{ get; set; }

        public string? Abrv { get; set; }

        public List<VehicleModel> Models { get; set; } = new List<VehicleModel>();


    }
}
