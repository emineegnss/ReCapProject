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
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageServices.GetByImageId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
       
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageServices.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageServices.GetByImageId(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageServices.Add(file, carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageServices.Update(file, carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var carDeleteImage = _carImageServices.GetByImageId(carImage.CarImageId).Data;
            var result = _carImageServices.Delete(carDeleteImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
