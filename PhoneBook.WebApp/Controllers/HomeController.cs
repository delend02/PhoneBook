using Microsoft.AspNetCore.Mvc;

namespace PhoneBook.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
