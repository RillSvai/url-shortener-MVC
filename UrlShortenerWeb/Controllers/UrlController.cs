using Microsoft.AspNetCore.Mvc;
using UrlShortener.DataAccess.Repository.IRepository;
using UrlShortener.Models;
using UrlShortener.Utility;

namespace UrlShortenerWeb.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUrlShortener _urlShortener;
        public UrlController(IUnitOfWork unitOfWork, IUrlShortener urlShortener)
        {
            _unitOfWork = unitOfWork;
            _urlShortener = urlShortener;
        }
        public IActionResult Index()
        {
            SD.User = _unitOfWork.UserRepo.Get(user => user.Id == 5, null);
            return View(_unitOfWork.UrlRepo.GetAll(null, null));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(_unitOfWork.UrlRepo.Get(url => url.Id == id, "User"));
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UrlViewModel urlVM) 
        {
            if (!ModelState.IsValid) 
            {
                return View();  
            }
            urlVM.Url.TokenShortUrl = _urlShortener.GetToken(urlVM.TokenLen);
            urlVM.Url.ShortUrl = _urlShortener.GetShortUrl(HttpContext.Request.Scheme,HttpContext.Request.Host.Value,urlVM.Url.TokenShortUrl);
            urlVM.Url.CreatorId = SD.User.Id;
            _unitOfWork.UrlRepo.Insert(urlVM.Url);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Url");
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            return View();
        }
    }
}
