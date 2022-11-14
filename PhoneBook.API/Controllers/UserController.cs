using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Services.UserServices;
using PhoneBook.Domain.Entity;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            var result = _userServices.Create(user);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Update([FromBody] User user)
        {
            var result = _userServices.Update(user);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromRoute] ulong id)
        {
            var result = _userServices.Delete(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetByID([FromRoute] ulong id)
        {
            var result = _userServices.Get(id);
            return Ok(result);
        }
    }
}
