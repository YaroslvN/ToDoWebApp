using Microsoft.AspNetCore.Mvc;

namespace ToDoWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
