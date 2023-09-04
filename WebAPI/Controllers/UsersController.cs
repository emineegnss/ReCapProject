using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices _userServices;

        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(); }
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _userServices.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(); }
        }
        [HttpPost("add")]
        public IActionResult Add(User user)
        {

            var result = _userServices.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            else { return BadRequest(); }
        }

    }
}
