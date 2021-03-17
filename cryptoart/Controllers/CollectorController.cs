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
    public class CollectorController : Controller
    {
        private ICollectorRepo _repo;


        public CollectorController(ICollectorRepo repo)
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
            int collector = (int)ses.GetInt32("id");

            List<decoratedArt> arts = new List<decoratedArt>();
            foreach (Art a in _repo.GetArt(collector).ToList())
            {
                decoratedArt Da = new decoratedArt(a);
                arts.Add(Da);
            }
            return View(arts);

        }

        [BidWorkerFilter]
        public ActionResult ViewAuctions()
        {
            var ses = this.HttpContext.Session;
            int collector = (int)ses.GetInt32("id");

            List<decoratedArtCollector> arts = new List<decoratedArtCollector>();
            foreach (Art a in _repo.GetAuctions().ToList())
            {
                decoratedArtCollector Da = new decoratedArtCollector(a);
                Da.ClosingDate = _repo.GetClosingForArt(a.Id);
                arts.Add(Da);
            }

            List<Bid> bids = _repo.GetBids(collector);
            foreach (Bid b in bids)
            {
                decoratedArtCollector tmpart = arts.Where(x => x.Id == b.ArtId).FirstOrDefault();
                if (tmpart!=null &&tmpart.CollectorsBid < b.Amount)
                {
                    Log.Warning("No bids for user");
                    arts.Where(x => x.Id == b.ArtId).FirstOrDefault().CollectorsBid = b.Amount;
                }
            }

            return View(arts);
        }


        [BidWorkerFilter]
        public ActionResult ViewBids()
        {
            var ses = this.HttpContext.Session;
            int collector = (int)ses.GetInt32("id");

            List<decoratedArtCollector> arts = new List<decoratedArtCollector>();
            foreach (Art a in _repo.GetAuctions(collector).ToList())
            {
                decoratedArtCollector Da = new decoratedArtCollector(a);
                Da.ClosingDate = _repo.GetClosingForArt(a.Id);
                Da.Owner = _repo.GetOwner(a.Id);
                arts.Add(Da);
            }

            List<Bid> bids = _repo.GetBids(collector);
            foreach (Bid b in bids)
            {
                decoratedArtCollector art = arts.Where(x => x.Id == b.ArtId).FirstOrDefault();
                if (art != null && art.CollectorsBid < b.Amount)
                {
                    Log.Warning("No bids for user");
                    art.CollectorsBid = b.Amount;
                }
            }
            ViewData["CollectorName"] = _repo.GetName(collector);
            return View(arts);
        }

        [HttpPost]
        public ActionResult MakeBid()
        {
            Bid bid = new Bid();
            bid.ArtId = int.Parse(Request.Form["ArtId"].ToString());
            bid.AuctionId = _repo.GetAuction(bid.ArtId);

            return View(bid);
        }

        [HttpPost]
        public ActionResult SaveBid(Bid bid)
        {
            if (ModelState.IsValid)
            {
                var ses = this.HttpContext.Session;
                int collector = (int)ses.GetInt32("id");
                bid.CollectorId = collector;
                bid.TimeOfBid = DateTime.Now;
                _repo.Save(bid);
                return RedirectToAction("ViewBids", "Collector");
            }
            else
            {
                Log.Warning("Error Saving Bid");
            }
            return View(bid);
        }

    }
}
