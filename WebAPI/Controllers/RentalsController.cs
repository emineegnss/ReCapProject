using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalServices _rentalServices;

        public RentalsController(IRentalServices rentalServices)
        {
            _rentalServices = rentalServices;
        }
        [HttpGet("getall")]
        public ActionResult GetAllRental() {
            var result = _rentalServices.GetAll();
            if (result.Success) {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyid")]
        public ActionResult GetByIdRental(int id)
        {
            var result = _rentalServices.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);

            }
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalServices.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(result); }
        }
    }
}
