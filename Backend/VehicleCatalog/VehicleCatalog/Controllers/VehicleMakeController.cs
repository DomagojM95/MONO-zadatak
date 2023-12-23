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
        private readonly VehicleCatalogDataContext _context;

        public VehicleMakeController(VehicleCatalogDataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetMake()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var make = _context.Makes.ToList();
                if (make == null || make.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(_context.Makes.ToList());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet]
        [Route("{sifra:int}")]

        public IActionResult GetbyId(int id)
        {


            if (id == 0)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var make = _context.Makes.Find(id);

                if (make == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, make);
                }

                return new JsonResult(make);



            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }


        }


        [HttpPost]
        public IActionResult PostMake(VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {


                _context.Makes.Add(vehicleMake);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, vehicleMake);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }


        }



        [HttpPut]
        [Route("{id:int}")]


        public IActionResult Put(int id, VehicleMake vehicleMake)
        {
            if (id == 0 || vehicleMake == null)
            { return BadRequest(); }


            try
            {
                var makeBaze= _context.Makes.Find(id);
                if (makeBaze == null)
                {
                    return BadRequest();
                }

                makeBaze.CarName = vehicleMake.CarName;
                makeBaze.Abrv=vehicleMake.Abrv;

                _context.Makes.Update(makeBaze);
                _context.SaveChanges();


                return StatusCode(StatusCodes.Status200OK, makeBaze);

                



            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);
            }

        }



        [HttpDelete]
        [Route("{id:int}")]


        public IActionResult Delete(int id) 
        
        {
            if (id == 0) { return BadRequest(); }
            try
            {


                var makeBase= _context.Makes.Find(id);
                if (makeBase == null) { return BadRequest(); }

                _context.Makes.Remove(makeBase);
                _context.SaveChanges();


                return new JsonResult("{\"Message\":\"Deleted\"}");

            }
            catch (Exception ex)
            {

                return new JsonResult("{\"Message\":\"Can't delete this\"}",ex);

            }

        }






    }
}


