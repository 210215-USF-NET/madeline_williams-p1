using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtDL;
using Microsoft.AspNetCore.Http;
using ArtModel;
using cryptoart.Models;
using Serilog;
namespace cryptoart.Controllers
{
    public class SellerController : Controller
    {

        private ISellerRepo _repo;
       

        public SellerController(ISellerRepo repo)
        {

            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [BidWorkerFilter]
        public ActionResult Gallery()
        {
            var ses = this.HttpContext.Session;
            int seller = (int)ses.GetInt32("id");
            ViewData["SellerName"] = _repo.GetSellerName(seller);
            List<decoratedArt> arts = new List<decoratedArt>();
            foreach (Art a in _repo.GetArt(seller).ToList())
            {
                decoratedArt Da = new decoratedArt(a);
                Da.ClosingDate = _repo.GetClose(a.Id);

                Da.InBid = _repo.InBid(a.Id);
                arts.Add(Da);
               
              
            }
            return View(arts);

        }

        [BidWorkerFilter]
        public ActionResult Auctions()
        {


            var ses = this.HttpContext.Session;
            int seller = (int)ses.GetInt32("id");
            ViewData["SellerName"] = _repo.GetSellerName(seller);
            List <decoratedArt> arts = new List<decoratedArt>();
            foreach (Art a in _repo.GetArtInAuction(seller).ToList())
            {
                decoratedArt Da = new decoratedArt(a);
                Da.InBid = _repo.InBid(a.Id);
                Da.ClosingDate = _repo.GetClose(a.Id);
                arts.Add(Da);

            }
            return View(arts);

        }



        [BidWorkerFilter]
        public ActionResult CurrentAuctions()
        {


            var ses = this.HttpContext.Session;
            int seller = (int)ses.GetInt32("id");
            ViewData["SellerName"] = _repo.GetSellerName(seller);
            List<decoratedArt> arts = new List<decoratedArt>();
            foreach (Art a in _repo.GetArtInCurrentAuction(seller).ToList())
            {
                decoratedArt Da = new decoratedArt(a);
                Da.ClosingDate = _repo.GetClose(a.Id);
                DateTime d = DateTime.Now;
               
                if (d.CompareTo(Da.ClosingDate) < 0)
                {
                   
                    Da.InBid = true;
                   
                    arts.Add(Da);
                }
                    }
            return View(arts);

        }





        [HttpPost]
        public ActionResult CreateAuction(IFormCollection collection)
        {
            TempData["Name"]=Request.Form["Name"].ToString();
            TempData["ArtId"] = Request.Form["ArtId"].ToString();

            return View();
        }
        [HttpGet]
        public ActionResult FailedAuction()
        {

            return View();
        }



        [HttpPost]
        public IActionResult SaveAuction(Auction auction)
        {
            if (ModelState.IsValid)
            {
                if (auction.ClosingDate > DateTime.Now.AddMinutes(2))
                {
                    var ses = this.HttpContext.Session;
                    int seller = (int)ses.GetInt32("id");
                    auction.SellerId = seller;
                    auction.Notify = 0;
                    _repo.Save(auction);
                    return RedirectToAction("Gallery", "Seller");
                }
                else
                {
                    Log.Warning("Issue Creating Auction, Model not valid");
                }
            }
            TempData["ArtId"] =TempData["ArtId"];
            TempData["Name"] = TempData["Name"];
            return RedirectToAction("FailedAuction","Seller");
        }


    }
}
