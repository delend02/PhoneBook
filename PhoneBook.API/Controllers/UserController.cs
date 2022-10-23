using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Services;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {

        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetByID()
        {
            return Ok();
        }
    }
}
