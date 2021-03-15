using Microsoft.AspNetCore.Mvc;
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
        public ActionResult ViewAuctions()
        {
            var ses = this.HttpContext.Session;
            int collector = (int)ses.GetInt32("id");

            List<decoratedArtCollector> arts = new List<decoratedArtCollector>();
            foreach (Art a in _repo.GetAuctions(collector).ToList())
            {
                decoratedArtCollector Da = new decoratedArtCollector(a);
                Da.ClosingDate = _repo.GetClosingForArt(a.Id);
                arts.Add(Da);
            }

            List<Bid> bids = _repo.GetBids(collector);
            foreach (Bid b in bids) {
                if (arts.Where(x => x.Id == b.ArtId).FirstOrDefault().CollectorsBid < b.Amount)
                {
                    arts.Where(x => x.Id == b.ArtId).FirstOrDefault().CollectorsBid = b.Amount;
                }
            }
            
            return View(arts);
        }


    }
}
