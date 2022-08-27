using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;
using System.Collections.Generic;

namespace PhoneBook.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<TelephoneBook> _bookRepository;

        public HomeController(IRepository<TelephoneBook> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        List<TelephoneBook> books = new List<TelephoneBook>();

        public IActionResult Table()
        {
            //var result = _bookRepository.GetAll();

           

            books.Add(new TelephoneBook(1, "Tokarev", "Maksim", "Evgenevich", "972325", "sdhbxc"));
            books.Add(new TelephoneBook(2, "Tokarev", "Maksim", "Evgenevich", "43423", "EFFDc"));
            books.Add(new TelephoneBook(3, "Tokarev", "Maksim", "Evgenevich", "1231", "gdge"));
            books.Add(new TelephoneBook(4, "Tokarev", "Maksim", "Evgenevich", "5346", "cBCXCv"));
            books.Add(new TelephoneBook(5, "Tokarev", "Maksim", "Evgenevich", "7567", "CVcbcbz"));
            books.Add(new TelephoneBook(6, "Tokarev", "Maksim", "Evgenevich", "23542", "VvD"));
            books.Add(new TelephoneBook(7, "Tokarev", "Maksim", "Evgenevich", "23146", "XCCXC"));
            books.Add(new TelephoneBook(8, "Tokarev", "Maksim", "Evgenevich", "869434", "CBcB"));
            books.Add(new TelephoneBook(9, "Tokarev", "Maksim", "Evgenevich", "4", "ZBBBXCBXC"));

            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }



        public IActionResult About()
        {
            return View();
        }
    }
}
