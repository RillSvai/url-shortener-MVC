using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.DataAccess.Repository.IRepository;
using UrlShortener.Models;
using UrlShortener.Utility;
using UrlShortener.Utility.Identity;

namespace UrlShortenerWeb.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserManager<User> _userManager;
        public IdentityController(IUnitOfWork unitOfWork, IUserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager; 
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
            _unitOfWork.Save();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Logout() 
        {
            SD.User = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
