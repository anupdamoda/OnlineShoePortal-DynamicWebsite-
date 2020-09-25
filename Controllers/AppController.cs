using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoePortal_DynamicWebsite_.Data;
using OnlineShoePortal_DynamicWebsite_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoePortal_DynamicWebsite_.Controllers
{
    public class AppController : Controller
    {
        private readonly ToyContext _context;
        private readonly IToyRepository _repository;

        public AppController(IToyRepository repository){
            _repository = repository;
        }
        public IActionResult Index()
        {
       //     var results = _context.Products.ToList();
            return View();
        }

        public IActionResult Aboutus()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }
       
        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            ViewBag.Title = "Contact Us";
            return View();
        }
        public IActionResult LoginorRegister()
        {
            ViewBag.Title = "Login or Register";
            return View();
        }
        [Authorize]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }
    }
}
 