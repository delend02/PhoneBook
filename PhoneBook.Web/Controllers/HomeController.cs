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

       

        public IActionResult Table()
        {
            //var result = _bookRepository.GetAll();

            List<TelephoneBook> books = new List<TelephoneBook>();

            books.Add(new TelephoneBook(1, "Tokarev", "Maksim", "Evgenevich", "972325", "sdhbxc", null));
            books.Add(new TelephoneBook(2, "Tokarev", "Maksim", "Evgenevich", "43423", "EFFDc", null));
            books.Add(new TelephoneBook(3, "Tokarev", "Maksim", "Evgenevich", "1231", "gdge", null));
            books.Add(new TelephoneBook(4, "Tokarev", "Maksim", "Evgenevich", "5346", "cBCXCv", null));
            books.Add(new TelephoneBook(5, "Tokarev", "Maksim", "Evgenevich", "7567", "CVcbcbz", null));
            books.Add(new TelephoneBook(6, "Tokarev", "Maksim", "Evgenevich", "23542", "VvD", null));
            books.Add(new TelephoneBook(7, "Tokarev", "Maksim", "Evgenevich", "23146", "XCCXC", null));
            books.Add(new TelephoneBook(8, "Tokarev", "Maksim", "Evgenevich", "869434", "CBcB", null));
            books.Add(new TelephoneBook(9, "Tokarev", "Maksim", "Evgenevich", "4", "ZBBBXCBXC", null));




            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
