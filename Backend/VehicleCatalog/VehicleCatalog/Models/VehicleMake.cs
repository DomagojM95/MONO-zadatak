namespace VehicleCatalog.Models
{
    public  class VehicleMake:Entity
    {
        public string? CarName{ get; set; }

        public string? Abrv { get; set; }

        public ICollection<VehicleModel> Vehicles { get; set; }


    }
}
