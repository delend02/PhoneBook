using Microsoft.AspNetCore.Mvc;
using PhoneBook.Domain.Entity;
using PhoneBook.Domain.Interfaces;

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
            var books = _bookRepository.GetAll();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TelephoneBook telephoneBook)
        {
            _bookRepository.Create(telephoneBook);
            _bookRepository.Save();
            return View("Table");
        }

        
        public IActionResult About([FromRoute] string ID)
        {
            var book = _bookRepository.Find(book => book.ID == ulong.Parse(ID));

            return View(book);
        }
    }
}
