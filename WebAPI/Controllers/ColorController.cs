using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        IColorServices _colorServices;

        public ColorController(IColorServices colorServices)
        {
            _colorServices = colorServices;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var entity = _colorServices.GetAll();
            if (entity.Success)
            {
                return Ok(entity);
            }
            return BadRequest();
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var enity = _colorServices.GetCarsByBrandId(id);
            if (enity.Success)
            {
                return Ok(enity);
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Add(Color color)
        {
            var entity = _colorServices.Add(color);
            if (entity.Success)
            {
                return Ok(entity);
            }
            return BadRequest();
        }
    }
}
