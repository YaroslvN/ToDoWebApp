using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoWebApp.Data;
using ToDoWebApp.Models;

namespace ToDoWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string Username, string Email, string Password, string ConfirmPassword)
        {
            if (ModelState.IsValid && ConfirmPassword == Password)
            {
                string hashadPassword = BCrypt.Net.BCrypt.HashPassword(Password);

                 User user = new User()
                 {
                     Name = Username,
                     Email = Email,
                     PasswordHash = hashadPassword
                 };

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
           return View();
          
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            // Ищем пользователя в БД одним запросом (без ToList())
            var user = _context.Users.FirstOrDefault(u => u.Name == Username);

            // Проверяем, найден ли пользователь
            if (user != null && BCrypt.Net.BCrypt.Verify(Password, user.PasswordHash))
            {
                return RedirectToAction("Index", "Home");
            }

            // Если логин неудачный, можно добавить ошибку в ModelState
            ModelState.AddModelError("", "Неверный логин или пароль");
            return View();
        }
    }
}
