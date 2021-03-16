﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtDL;
using Microsoft.AspNetCore.Http;
using ArtModel;
using cryptoart.Models;
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

            List<decoratedArt> arts = new List<decoratedArt>();
            foreach (Art a in _repo.GetArt(seller).ToList())
            {
                decoratedArt Da = new decoratedArt(a);
                Da.InBid = _repo.InBid(a.Id);
                Da.ClosingDate = _repo.GetClose(a.Id);
                arts.Add(Da);
            }
            return View(arts);

        }

        [BidWorkerFilter]
        public ActionResult Auctions()
        {
            var ses = this.HttpContext.Session;
            int seller = (int)ses.GetInt32("id");

            List<decoratedArt> arts = new List<decoratedArt>();
            foreach (Art a in _repo.GetArtInAuction(seller).ToList())
            {
                decoratedArt Da = new decoratedArt(a);
                Da.InBid = _repo.InBid(a.Id);
                Da.ClosingDate = _repo.GetClose(a.Id);
                arts.Add(Da);
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
                if (auction.ClosingDate > DateTime.Now.AddMinutes(5))
                {
                    var ses = this.HttpContext.Session;
                    int seller = (int)ses.GetInt32("id");
                    auction.SellerId = seller;
                    auction.Notify = 0;
                    //  _repo.Save(auction);
                    return RedirectToAction("Gallery", "Seller");
                }
            }
            TempData["ArtId"] =TempData["ArtId"];
            TempData["Name"] = TempData["Name"];
            return RedirectToAction("FailedAuction","Seller");
        }


    }
}
