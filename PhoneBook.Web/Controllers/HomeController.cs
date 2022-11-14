using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Services.TelephoneServices;
using PhoneBook.Web.Mappers;
using PhoneBook.Web.Models;
using System.Collections.Generic;

namespace PhoneBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITelephoneService _telephoneServices;

        public HomeController(ITelephoneService telephoneServices)
        {
            _telephoneServices = telephoneServices;
        }

        [HttpGet]
        public IActionResult Table()
        {
            var books = _telephoneServices.GetAll().ConstructToListModels();

            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TelephoneBookModel telephoneBook)
        {
            var resultBook = TelephoneBookMappers.ConstructToEntities(telephoneBook);

            _telephoneServices.Create(resultBook);

            return View("Table", _telephoneServices.GetAll().ConstructToListModels());

        }

        [HttpGet]
        public IActionResult About([FromRoute] string ID)
        {
            if (!ulong.TryParse(ID, out var result))
                return View();

            var book = _telephoneServices.Get(result).ConstructToModels();

            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(List<ulong> ID)
        {
            _telephoneServices.RangeDelete(ID);
            return View("Table", _telephoneServices.GetAll().ConstructToListModels());
        }

        [HttpGet]
        public IActionResult Redact([FromRoute] string ID)
        {
            if (!ulong.TryParse(ID, out var result))
                return View();

            var book = _telephoneServices.Get(result).ConstructToModels();

            return View(book);
        }

        [HttpPost]
        public IActionResult Change(TelephoneBookModel model)
        {
            return View("Table", _telephoneServices.GetAll().ConstructToListModels());
        }
    }
}
