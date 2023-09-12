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
        [HttpGet("getfilebyid")]
        public IActionResult GetFileById(int id)
        {
            var result = _carImageServices.GetByImageId(id);
            if (result.Success)
            {
                var b = System.IO.File.ReadAllBytes(result.Data.ImagePath);
                return File(b, "image/jpeg");
            }
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
        public IActionResult Add([FromForm] CarImage carImage, [FromForm(Name ="Image")] IFormFile file)
        {
            var result = _carImageServices.Add(carImage, file);
            if (result.Success) return Ok(result);
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm(Name = "Image")] IFormFile file)
        {
            var result = _carImageServices.Update(carImage, file);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageServices.Delete(carImage);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
