﻿using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleCatalog.Models
{
    public class VehicleModel:Entity
    {
       
        public virtual VehicleMake? MakeID { get; set; }
        public string? CarName { get; set; }
        public string? Abrv { get; set; }




    }
}
 