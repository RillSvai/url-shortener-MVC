using Microsoft.AspNetCore.Mvc;

namespace UrlShortenerWeb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
