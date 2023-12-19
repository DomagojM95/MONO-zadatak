using Microsoft.AspNetCore.Mvc;
using Ninject.Planning;
using VehicleCatalog.Data;
using VehicleCatalog.Models;

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

        public IActionResult Post(VehicleModel vehicleModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            try
            {

                _context.Models.Add(vehicleModel);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, vehicleModel);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                   ex.Message);

            }
        }
    }
}
