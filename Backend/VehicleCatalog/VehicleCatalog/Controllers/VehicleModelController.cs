using Microsoft.AspNetCore.Mvc;
using Ninject.Planning;
using VehicleCatalog.Data;
using VehicleCatalog.Models;
using VehicleCatalog.Models.DTO;

namespace VehicleCatalog.Controllers
{

    [ApiController]
    [Route("Api/v1/[controller]")]
    public class VehicleModelController : ControllerBase
    {

        private readonly VehicleCatalogDataContext _context;


        public VehicleModelController(VehicleCatalogDataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var models = _context.Models.ToList();
                if (models == null || models.Count == 0)
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            if (vehicleModelDTO.MakeId <= 0)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var make = _context.Makes.Find(vehicleModelDTO.MakeId);

                if (make == null)
                {
                    return BadRequest(ModelState);
                }


                VehicleModel model = new()
                {

                    CarName = vehicleModelDTO.CarName,
                    Abrv = vehicleModelDTO.Abrv,
                    MakeID = make


                };

                _context.Models.Add(model);
                _context.SaveChanges();



                return Ok(vehicleModelDTO);



            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                                   ex.Message);

            }
        }




        [HttpPut]
        [Route("{ID:int}")]


        public IActionResult Put(int id, VehicleModelDTO vehicleModelDTO)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }

            if (id <= 0 || vehicleModelDTO == null)
            { return BadRequest(); }

            try
            {

                var make = _context.Makes.Find(vehicleModelDTO.MakeId);

                if (make == null)
                {
                    return BadRequest();
                }
                var model = _context.Models.Find(id);

                if (model == null)
                {
                    return BadRequest();
                }


                model.CarName = vehicleModelDTO.CarName;
                model.Abrv = vehicleModelDTO.Abrv;
                model.MakeID = make;


                _context.Models.Update(model);
                _context.SaveChanges();

                vehicleModelDTO.ID = id;
                vehicleModelDTO.MakeId = make.ID;


                return Ok(vehicleModelDTO);

            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status503ServiceUnavailable,
                    ex.Message);

            }


        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]

        public IActionResult Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }


            var modelsBase = _context.Models.Find(id);
            if(modelsBase == null)
            {
                return BadRequest();
            }

            try
            {


                _context.Models.Remove(modelsBase);
                _context.SaveChanges();


                return new JsonResult("{\"Message\":\"Deleted\"}");







            }
            catch (Exception ex)
            {

                return new JsonResult("{\"Message\":\"Can't delete this\"}", ex);
            }


        }

    }
}
