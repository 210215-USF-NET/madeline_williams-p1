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
            ViewData["Name"]=Request.Form["ListItem"].ToString();
            ViewData["ArtId"] = Request.Form["ArtId"].ToString();

            return View();
        }



        [HttpPost]
        public IActionResult SaveAuction(Auction auction)
        {

            var ses = this.HttpContext.Session;
            int seller = (int)ses.GetInt32("id");
            auction.SellerId = seller;
            auction.Notify = 0;
            _repo.Save(auction);
            
            return RedirectToAction("Gallery", "Seller");
        }


    }
}
