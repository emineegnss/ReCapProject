using Business.Abstract;
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
