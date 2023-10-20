using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;

namespace UrlShortenerWeb.Controllers
{
    public class IdentityController : Controller
    {
       
        public IdentityController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login() 
        {
            return View();
        }
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerModel)
        {
            
            if (!ModelState.IsValid) 
            {
                return View(registerModel);
            }
            return RedirectToAction("Index","Home");
        }
        public IActionResult Logout() 
        {
            return View();
        }
    }
}
