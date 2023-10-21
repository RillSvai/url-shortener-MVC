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
            if (_unitOfWork.UrlRepo.Get(url => url.OriginalUrl == urlVM.Url.OriginalUrl,null) is not null) 
            {
                ModelState.AddModelError("Url", "This url already exists(");
            }
            if (!ModelState.IsValid) 
            {
                return View();  
            }
            string token = _urlShortener.GetToken(urlVM.TokenLen);
			uint i = 0;
            while (_unitOfWork.UrlRepo.Get(url => url.TokenShortUrl == token, null) is not null) 
            {
				if (++i == 10)
				{
					_unitOfWork.UrlRepo.Remove(_unitOfWork.UrlRepo.Get(url => url.TokenShortUrl == token, null));
					_unitOfWork.Save();
                    break;
				}
				token = _urlShortener.GetToken(8);
            }
		    urlVM.Url.TokenShortUrl = token;
			urlVM.Url.ShortUrl = _urlShortener.GetShortUrl(HttpContext.Request.Scheme,HttpContext.Request.Host.Value,urlVM.Url.TokenShortUrl);
            urlVM.Url.CreatorId = SD.User?.Id ?? _unitOfWork.UserRepo.Get(null,null).Id;
            _unitOfWork.UrlRepo.Insert(urlVM.Url);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Url");
        }
        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0) 
            {
                return BadRequest();
            }
            Url url = _unitOfWork.UrlRepo.Get(x => x.Id == id, null);
            if (url is null) 
            {
                return BadRequest();
            }
            _unitOfWork.UrlRepo.Remove(url);
            _unitOfWork.Save();
            return RedirectToAction("Index","Url");
        }
    }
}
