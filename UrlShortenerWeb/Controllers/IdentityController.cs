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
        [HttpPost]
        async public Task<IActionResult> Login(LoginViewModel userData)
        {
            User? user = await _unitOfWork.UserRepo.Get(user => user.Email == userData.Email && user.Password == userData.Password, null);
            if (user is null)
            {
                ModelState.AddModelError("", "Data incorrect!");
            }
            if (!ModelState.IsValid) 
            {
                return View();
            }
            SD.User = user; 
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        async public Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid) 
            {
                return View(registerModel);
            }
            await _unitOfWork.UserRepo.Insert(registerModel.User!);
            await _unitOfWork.Save();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Logout() 
        {
            SD.User = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
