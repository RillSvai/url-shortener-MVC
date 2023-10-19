using Microsoft.AspNetCore.Mvc;
using UrlShortener.DataAccess.Repository.IRepository;
using UrlShortener.Models;
using UrlShortener.Utility;
using UrlShortener.Utility.Identity;

namespace UrlShortenerWeb.Controllers
{
 

    public class UrlController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public UrlController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(_unitOfWork.UrlRepo.GetAll(null,null));
        }
        public IActionResult Details(int? id) 
        {
            if (id == null) 
            {
                return NotFound();
            }
            return View(_unitOfWork.UrlRepo.Get(url => url.Id == id,"User"));
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            return View();
        }
    }
}
