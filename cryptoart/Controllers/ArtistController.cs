using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using auctionBL;
using ArtModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using cryptoart.Models;
using ArtDL;

namespace cryptoart.Controllers
{
    public class ArtistController : Controller
    {
        private IArtistBl _bl;
        private ArtModel.IArtistmapper _mapper;

       public ArtistController(IArtistBl bl, ArtModel.IArtistmapper mapper)
        {
            _bl = bl;
            _mapper = mapper;
        }



        // GET: ArtistController
        public ActionResult Index()
        {

            return View(_mapper.cast2IndexVM(_bl.GetArtists().FirstOrDefault()));
            
            }


        // GET: ArtistController
        public ActionResult Artists()
        {

            return View(_bl.GetArtists().ToList());

        }





        [BidWorkerFilter]
        public ActionResult Gallery()
        {
            var ses = this.HttpContext.Session;
            int artist=(int)ses.GetInt32("id");

            List<SelectListItem> optionList = new List<SelectListItem>()
            {
    
            };
            foreach (Seller s in _bl.GetSellers())
            {
                optionList.Add(new SelectListItem { Text = s.Name, Value = s.Id.ToString()});
            }
            ViewBag.ListItem = optionList;
            List<decoratedArt> arts = new List<decoratedArt>();
            foreach (Art a in _bl.GetArt(artist).ToList())
            {
                decoratedArt Da = new decoratedArt(a);
                if (_bl.Owned(a.Id))
                {
                    Da.Owner = _bl.Owner(a.Id);
                    Da.Owned = true;
                }
                Da.InBid = _bl.InBid(a.Id);
                arts.Add(Da);
            }
            return View(arts);

        }


        [BidWorkerFilter]
        public ActionResult Attach()
        {
            var ses = this.HttpContext.Session;
            int artist = (int)ses.GetInt32("id");

            List<SelectListItem> optionList = new List<SelectListItem>()
            {

            };
            foreach (Seller s in _bl.GetSellers())
            {
                optionList.Add(new SelectListItem { Text = s.Name, Value = s.Id.ToString() });
            }
            ViewBag.ListItem = optionList;
            List<decoratedArt> arts = new List<decoratedArt>();
            foreach (Art a in _bl.GetArt(artist).ToList())
            {
                decoratedArt Da = new decoratedArt(a);
                if (_bl.Owned(a.Id))
                {
                    Da.Owner = _bl.Owner(a.Id);
                    Da.Owned = true;
                }
                Da.InBid = _bl.InBid(a.Id);
                if (Da.Owner == "")
                {
                    arts.Add(Da);
                }
            }
            return View(arts);

        }



        [HttpPost]
        public ActionResult Attach(IFormCollection collection)
        {
            int sellid = int.Parse(Request.Form["ListItem"].ToString());
            int artid = int.Parse(Request.Form["ArtId"].ToString());
            _bl.Attach(artid, sellid);
            TempData["attached"] = artid;
            return RedirectToAction("Gallery");
        }

        // GET: ArtistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArtistController/Create
        public ActionResult Submit()
        {
            return View();
        }


        public ActionResult FailedSubmit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SaveArt(Art art, [FromServices] IArtistRepo repo)
        {
            if (ModelState.IsValid)
            { 

                repo.Save(art);
            }
            else
            {
                return RedirectToAction("failedSubmit");
            }
          

            return RedirectToAction("Gallery", "Artist");
        }



        // POST: ArtistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArtistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
