using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuchTreat.Data;
using DuchTreat.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DuchTreat.Controllers
{
    public class AppController : Controller
    {
        private readonly IDutchRepository _dutchRepository;

        public AppController(IDutchRepository dutchRepository )
        {
            _dutchRepository = dutchRepository;
        }

        public IActionResult Index()
        {          
            return View();
        }

        [HttpGet("Contact")]
        public IActionResult Contact()
        {
                       ViewBag.Title = "Contact US";
            return View();
        }

        [HttpPost("Contact")]
        public IActionResult Contact(ContactViewModel Model)
        {
          
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About US";
            return View();
        }

        public IActionResult Shop()
        {
            var result = _dutchRepository.GetAllProducts();
            return View(result);
        }
    }
}