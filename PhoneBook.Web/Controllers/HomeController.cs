using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Services;
using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Web.Models;

namespace PhoneBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITelephoneServices _telephoneServices;

        public HomeController(ITelephoneServices telephoneServices)
        {
            _telephoneServices = telephoneServices;
        }

        [HttpGet]
        public IActionResult Table()
        {
            var books = _telephoneServices.GetAll();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TelephoneDescriptionModel telephoneBook)
        {
            _telephoneServices.Create(telephoneBook);
            return View("Table", _telephoneServices.GetAll());
        }

        [HttpGet]
        public IActionResult About([FromRoute] string ID)
        {
            if (!ulong.TryParse(ID, out var result))
                return View();

            var book = _telephoneServices.Get(result);
            return View(book);
        }

        [HttpPost]
        public IActionResult AboutDelete(string ID)
        {
            if (!ulong.TryParse(ID, out var result))
                return View();

            _telephoneServices.Delete(result);
            return View("Table", _telephoneServices.GetAll());
        }

        [HttpPost]
        public IActionResult Correct(string ID)
        {
            if (!ulong.TryParse(ID, out var result))
                return View();

            _telephoneServices.Delete(result);
            return View("Table", _telephoneServices.GetAll());
        }
    }
}
