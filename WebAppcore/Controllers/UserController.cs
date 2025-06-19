using Microsoft.AspNetCore.Mvc;
using WebAppcore.Models;
using WebAppcore.Data;
using System.ComponentModel.DataAnnotations;
namespace WebAppcore.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                // Vérifier si l'email existe déjà
                var exist = _db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (exist != null)
                {
                    ModelState.AddModelError("Email", "Email déjà utilisé.");
                    return View(model);
                }

                model.Role = 0;

                _db.Users.Add(model);
                _db.SaveChanges();

                TempData["Success"] = "Inscription réussie.";
            }

            return RedirectToAction("Login", "User");
        }
        public IActionResult Login() 
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                if (user.Role == 1)
                {
                    // Admin
                    TempData["Success"] = "Bonjourr Admin : " + user.Name;
                    return RedirectToAction("Index", "Product");
                }
                else if (user.Role == 0)
                {
                    // Utilisateur normal
                    TempData["Success"] = "Bonjourr Client : " + user.Name;
                    return RedirectToAction("Index", "Buy");
                }
            }

            TempData["error"] = "Données invalides";
            return RedirectToAction("Login" , "User");
        }
		public async Task<IActionResult> Logout()
		{
			return RedirectToAction("Login", "User");
		}



	}

}

