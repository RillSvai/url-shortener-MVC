using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Registration() 
        {
            return View();
        }
        public IActionResult Logout() 
        {
            return View();
        }
    }
}
