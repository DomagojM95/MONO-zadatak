using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleCatalog.Models
{
    public class VehicleModel:Entity
    {
        [ForeignKey("VehicleMake")]
        public VehicleMake VehicleMake { get; set; }
        public int MakeID { get; set; }
        public string CarName { get; set; }
        public string Abrv { get; set; }

        public virtual VehicleMake Make { get; set; }

    }
}
