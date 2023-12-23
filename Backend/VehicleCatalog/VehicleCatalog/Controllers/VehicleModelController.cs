using Microsoft.AspNetCore.Mvc;
using Ninject.Planning;
using VehicleCatalog.Data;
using VehicleCatalog.Models;
using VehicleCatalog.Models.DTO;

namespace VehicleCatalog.Controllers
{

    [ApiController]
    [Route("Api/v1/[controller]")]
    public class VehicleModelController :ControllerBase
    {

        private readonly VehicleCatalogDataContext _context;


        public VehicleModelController(VehicleCatalogDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            try
            {
                var models = _context.Models.ToList();
                if(models==null || models.Count==0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Models.ToList());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);

            }
        }


        [HttpPost]

        public IActionResult Post(VehicleModelDTO vehicleModelDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            if (vehicleModelDTO.IdMake <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var make = _context.Makes.Find(vehicleModelDTO.MakeId);

                if(make == null)
                {
                    return BadRequest(ModelState);
                }


                VehicleModel model = new()
                {

                    CarName = vehicleModelDTO.CarName,
                    Abrv = vehicleModelDTO.Abrv,
                    MakeID=make


                };

                _context.Models.Add(model);
                _context.SaveChanges();

                vehicleModelDTO.ID = model.ID;

                return Ok(vehicleModelDTO);

               

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                   ex.Message);

            }
        }
    }
}
