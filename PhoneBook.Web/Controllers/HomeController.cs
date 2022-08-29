using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using PhoneBook.Web.Models;
using System.Collections.Generic;

namespace PhoneBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<TelephoneBook> _bookRepository;

        List<TelephoneBook> books;
        public HomeController(IRepository<TelephoneBook> bookRepository)
        {
            books = new List<TelephoneBook> {
                        new TelephoneBook {Address = "231", ID = 1, SurName="Евгеньевич", FirstName = "Максим", LastName = "Токарев", NumberPhone = "89114966798" },
                        new TelephoneBook {Address = "157", ID = 1, SurName="Сергеевич", FirstName = "Максим", LastName = "Токарев", NumberPhone = "89114966798" },
                        new TelephoneBook {Address = "63", ID = 1, SurName="Александрович", FirstName = "Максим", LastName = "Токарев", NumberPhone = "89114966798" },
                        new TelephoneBook {Address = "234", ID = 1, SurName="Витальевич", FirstName = "Максим", LastName = "Токарев", NumberPhone = "89114966798" }};
               
            _bookRepository = bookRepository;
        }


        public IActionResult Table()
        {
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
            var a = telephoneBook;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
