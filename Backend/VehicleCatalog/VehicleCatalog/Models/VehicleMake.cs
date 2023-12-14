namespace VehicleCatalog.Models
{
    public abstract class VehicleMake:Entity
    {
        public string CarName { get; set; }
        public string Abrv { get; set; }
        public virtual ICollection<VehicleModel> Models { get; set; }

        public List<VehicleModel> VehicleModels { get; set; } = new();
    }
}
