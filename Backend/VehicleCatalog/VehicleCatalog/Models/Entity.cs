using System.ComponentModel.DataAnnotations;

namespace VehicleCatalog.Models
{
    public abstract class Entity
    {
        [Key]
        public int ID { get; set; }
    }
}
