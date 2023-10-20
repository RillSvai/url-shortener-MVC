using Microsoft.AspNetCore.Mvc;
using UrlShortener.DataAccess.Repository.IRepository;
using UrlShortener.Models;
using UrlShortener.Utility;

namespace UrlShortenerWeb.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public IdentityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            _unitOfWork.UserRepo.Insert(registerModel.User);
            SD.User = registerModel.User;
            _unitOfWork.Save();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Logout() 
        {
            return View();
        }
    }
}
