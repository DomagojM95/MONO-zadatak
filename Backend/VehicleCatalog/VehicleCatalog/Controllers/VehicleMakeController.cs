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
        public IActionResult GetMake()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var make = _context.VehicleMake.ToList();
                if (make == null || make.Count == 0)
                {
                    return new EmptyResult();
                }

                return new JsonResult(_context.VehicleMake.ToList());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        //[HttpGet]
        //[Route("{sifra:int}")]

        //public IActionResult GetbyId(int id)
        //{


        //    if (id == 0)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {

        //        var make = _context.VehicleMake.Find(id);

        //        if (make == null)
        //        {
        //            return StatusCode(StatusCodes.Status204NoContent, make);
        //        }

        //        return new JsonResult(make);



        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
        //    }


        //}


        [HttpPost]
        public IActionResult PostMake(VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                _context.VehicleMake.Add(vehicleMake);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, vehicleMake);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }



        }
    }
}


