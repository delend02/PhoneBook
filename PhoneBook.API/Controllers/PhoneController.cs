using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Services.TelephoneServices;
using PhoneBook.Domain.Entity;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly ITelephoneService _telephoneServices;

        public PhoneController(ITelephoneService telephoneServices)
        {
            _telephoneServices = telephoneServices;
        }

        [HttpPost]
        public IActionResult Create([FromBody] TelephoneBook telephoneBook)
        {
            _telephoneServices.Create(telephoneBook);
            return Ok();
        }

        [HttpPost]
        public IActionResult Update([FromBody] TelephoneBook telephoneBook)
        {
            _telephoneServices.Update(telephoneBook);
            return Ok();
        }

        [HttpPost]
        public IActionResult Delete([FromQuery] ulong id)
        {
            _telephoneServices.Delete(id);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetByID([FromQuery] ulong id)
        {
            return Ok(_telephoneServices.Get(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {           
            return Ok(_telephoneServices.GetAll());
        }
    }
}
