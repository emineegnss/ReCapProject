using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageServices _carImageServices;

        public CarImagesController(ICarImageServices carImageServices)
        {
            _carImageServices = carImageServices;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageServices.GetAllImages();
            if (result.Success) { 
            return Ok(result);
            }
            else { return BadRequest(result); }
        }
        [HttpPost("add")]
        public IActionResult Add(CarImage carImage)
        {
            var result = _carImageServices.Add(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
