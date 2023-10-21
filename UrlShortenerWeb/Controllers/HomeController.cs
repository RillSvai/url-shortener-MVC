using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.DataAccess.Repository.IRepository;
using UrlShortener.Models;

namespace UrlShortenerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(_unitOfWork.UrlRepo.GetAll(null, "User"));
        }
        [HttpGet,Route("/redirector/{token}")]
        public IActionResult Redirector([FromRoute] string token) 
        {
            string? originalUrl = _unitOfWork.UrlRepo.Get(url => url.TokenShortUrl == token,null)?.OriginalUrl;
            if (originalUrl is null) 
            {
                return NotFound();
            }
            return Redirect(originalUrl);   
        }
        public IActionResult About() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}