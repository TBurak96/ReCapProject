using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class RentalsControllers : Controller
    {
        IRentalService _rentaLService;
        public RentalsControllers(IRentalService rentalService)
        {
            _rentaLService = rentalService;

        }


        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _rentaLService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
                
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentaLService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentaLService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentaLService.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("update")]

        public IActionResult Update(Rental rental)
        {
            var result = _rentaLService.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
