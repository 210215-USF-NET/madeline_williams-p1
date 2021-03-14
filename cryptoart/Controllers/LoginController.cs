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
using bl=auctionBL;
using ArtModel;
using ArtDL;
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
            ViewData["Name"] = ses.GetString("Name");
            return View();
        }


        [HttpPost]
        public IActionResult perform(IFormCollection collection, [FromServices] bl.ILogin login)
        {
            var ses = this.HttpContext.Session;
             ses.SetString("user", Request.Form["ListItem"].ToString());
           
                if (login.GetUser(Request.Form["name"].ToString(), Request.Form["ListItem"].ToString()) != null)
                {
                    ses.SetInt32("id", login.GetUser(Request.Form["name"].ToString(), Request.Form["ListItem"].ToString()).Id);
                    ses.SetString("Name", login.GetUser(Request.Form["name"].ToString(), Request.Form["ListItem"].ToString()).Name);
                    return RedirectToAction("Index", "Home");
            }
                else
                {
                TempData["name"] = Request.Form["name"].ToString();
                   return  RedirectToAction( "Create" + ses.GetString("user"), "Login");
                }


           
            
        }


        public IActionResult SaveArtist(Artist artist, [FromServices]IArtistRepo Ar )
        {

    
           artist= Ar.Save(artist);
            var ses = this.HttpContext.Session;
            ses.SetInt32("id", artist.Id);
            ses.SetString("name",artist.Name);
            ses.SetString("user", "artist");

            return View();
        }

        [clearUserFilter]
        public IActionResult Createartist(string name)
        {
            ViewData["Name"] = TempData["name"];
            return View();
        }

        [clearUserFilter]
        public IActionResult Createseller()
        {
            return View();
        }

        [clearUserFilter]
        public IActionResult Createcollector()
        {
            return View();
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
