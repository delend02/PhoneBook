using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Services;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly ITelephoneServices _telephoneServices;

        public PhoneController(ITelephoneServices telephoneServices)
        {
            _telephoneServices = telephoneServices;
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

        [HttpPost]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet("ID")]
        public IActionResult GetByID()
        {
            return Ok();
        }

        public IActionResult GetAll()
        {
            return Ok();
        }

    }
}
