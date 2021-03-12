using cryptoart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace cryptoart.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }


        public IActionResult Artists()
        {
           
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.IdOrName = "";
            ViewBag.UserRole = "";
            var ses = this.HttpContext.Session;
            String user = ses.GetString("user");
            List<SelectListItem> optionList = new List<SelectListItem>()
            {
            new SelectListItem { Text = "artist", Value = "artist", Selected = (user == "artist")},
    new SelectListItem() { Text = "collector", Value = "collector", Selected = (user == "collector")},
    new SelectListItem() { Text = "seller", Value = "seller", Selected = (user == "seller")},
    new SelectListItem() { Text = "browser", Value = "browser", Selected = (user == "browser")}
            };
            ViewBag.ListItem = optionList;
            return View();
        }


        [HttpPost]
        public IActionResult perform(IFormCollection collection)
        {
            var ses = this.HttpContext.Session;
             ses.SetString("user", Request.Form["ListItem"].ToString());


            return RedirectToAction("Login", "Login");
            
        }


        public IActionResult Privacy()
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
