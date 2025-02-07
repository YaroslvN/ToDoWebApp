using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(string Username, string Email, string Password, string ConfirmPassword)
        {
            User user = new User()
            {
                Name = Username,
                Email = Email,
                PasswordHash = Password
            };
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
