using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleCatalog.Data;
using VehicleCatalog.Models;
using VehicleCatalog.Models.DTO;
using System.Collections.Generic;

namespace VehicleCatalog.Controllers
{
    [ApiController]
    [Route("Api/v1/[controller]")]
    public class VehicleMakeController : ControllerBase
    {
        private readonly VehicleCatalogContext _context;

        public VehicleMakeController(VehicleCatalogContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            if(!ModelState.IsValid)
            {
                return  BadRequest(ModelState);
            }
            try
            {
            var vehicleMake=_context.VehicleMake.
                    Include(make=>make.VehicleModels)
                    .ToList();

                if(vehicleMake == null) 
                {
                    return new EmptyResult();
                }
                

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VehicleMake, VehicleMakeDTO>();

                });
                var mapper = config.CreateMapper();
                
                List<VehicleMakeDTO> get= mapper.Map<List<VehicleMakeDTO>>(vehicleMake);
                return Ok(get);
            }
            catch (Exception ex)
            {

                return StatusCode(
                   StatusCodes.Status503ServiceUnavailable,ex);
            }
        }


        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetbyId(int id)
        {
            if (id==0) 
            {
                return BadRequest(ModelState);
            }

            var m = _context.VehicleMake.
                Include(make => make.VehicleModels);


        }



    }
}
