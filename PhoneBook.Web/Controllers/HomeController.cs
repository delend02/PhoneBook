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

            return View("Table", _bookRepository.GetAll());
        }

        [HttpGet]
        public IActionResult About([FromRoute] string ID)
        {
            if (!ulong.TryParse(ID, out var result))
                return View();

            var book = _bookRepository.GetByID(result);
            return View(book);
        }

        [HttpPost("about")]
        public IActionResult AboutDelete(string ID)
        {
            if (!ulong.TryParse(ID, out var result))
                return View();

            _bookRepository.Delete(result);
            _bookRepository.Save();
            return View("Table", _bookRepository.GetAll());
        }

        [HttpPost("about")]
        public IActionResult Correct(string ID)
        {
            if (!ulong.TryParse(ID, out var result))
                return View();

            _bookRepository.Delete(result);
            _bookRepository.Save();
            return View("Table", _bookRepository.GetAll());
        }
    }
}
