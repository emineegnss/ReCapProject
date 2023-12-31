﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarServices _carServices;

        public CarsController(ICarServices carServices)
        {
            _carServices = carServices;
        }
        [HttpGet("getall")]
        public IActionResult GetAllCars()
        {
            Thread.Sleep(800);
            var result = _carServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
        [HttpGet("getalldetail")]
        public IActionResult GetCarDetail()
        {
            var result = _carServices.GetCarDetail();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
        [HttpGet("getdetailsid")]
        public IActionResult GetCarDetail(int id)
        {
            var result = _carServices.GetCarDetailId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet("getbyid")]
        public IActionResult GetByIdCars(int id)
        {
            var result = _carServices.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }

        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int brandId)
        {
            var result = _carServices.GetCarsByBrandId(brandId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else { 
                return BadRequest(result); 
            }
        }
        [HttpGet("getbycolor")]
        public IActionResult GetByColor(int colorId)
        {
            var result = _carServices.GetCarsByColorId(colorId);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carServices.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }

    }
}
