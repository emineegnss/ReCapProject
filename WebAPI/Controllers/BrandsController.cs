using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandServices _brandService;

        public BrandsController(IBrandServices brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll() {
             var entity =_brandService.GetAll();
            if (entity.Success)
            {
                return Ok(entity);
            }
            return BadRequest();

        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var entity = _brandService.GetCarsByBrandId(id);
            if (entity.Success)
            {
               return Ok(entity);
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(Brand brand) {
            var entity = _brandService.Delete(brand);
            if (entity.Success)
            {
                Ok(entity);
            }
            return BadRequest();

        }
       
    }
}
