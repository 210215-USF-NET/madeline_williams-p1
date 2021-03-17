using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using auctionBL;
using ArtModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cryptoart.Models;


namespace cryptoart.Controllers
{
    public class ArtController : Controller
    {
        private IArtBl _bl;
        private ArtModel.IArtmapper _mapper;

       public ArtController(IArtBl bl, ArtModel.IArtmapper mapper)
        {
            _bl = bl;
            _mapper = mapper;
        }



        // GET: ArtistController
        public ActionResult Index()
        {
            return View(_bl.GetArt().ToList());
            //return View(_mapper.cast2IndexVM(_bl.GetArt().FirstOrDefault()));
            
            }



        // GET: ArtistController
        public ActionResult Artists()
        {

            return View(_bl.GetArt().ToList());

        }


        public ActionResult Value(int id)
        {
            
            TempData["orderBy"] = "value";
            return RedirectToAction("Gallery", new { id = id });
        }

        public ActionResult name(int id)
        {
            
            TempData["orderBy"] = "name";
            return RedirectToAction("Gallery",new { id = id });
        }

        public ActionResult owner(int id)
        {
            
            TempData["orderBy"] = "owner";
            return RedirectToAction("Gallery",new { id = id});
        }

        [userFilter]
        public ActionResult Gallery(int id)
        {
            var ses = this.HttpContext.Session;
            int? dir= ses.GetInt32("dir");
            ses.SetInt32("dir",-1*(int)dir);
            ViewData["ArtistId"] = id;
            ViewData["ArtistName"] = _bl.GetArtistName(id);
            ViewData["ArtistEmail"] = _bl.GetArtistEmail(id);
            List<Art> art = _bl.GetArtByArtist(id).ToList();
            List<decoratedArt> DA = new List<decoratedArt>();
            foreach ( Art a in art)
            {
                decoratedArt da=new decoratedArt(a);
                da.InBid = _bl.GetInBid(a.Id);
                da.Owner = _bl.GetOwner(a.Id);
                DA.Add(da);
            }
            if (TempData["orderBy"] != null)
            {
                switch (TempData["orderBy"])
                {
                    case "value":
                        if (dir > 0)
                        {
                            DA = DA.OrderByDescending(x => x.CurrentValue).ToList();
                        }
                        else
                        {
                            DA = DA.OrderBy(x => x.CurrentValue).ToList();
                        }
                        break;
                    case "name":
                        if (dir > 0)
                        {
                            DA = DA.OrderByDescending(x => x.Name).ToList();
                        }
                        else
                        {
                            DA = DA.OrderBy(x => x.Name).ToList();
                        }
                        break;
                    case "owner":
                        if (dir > 0)
                        {
                            DA = DA.OrderByDescending(x => x.Owner).ToList();
                        }
                        else
                        {
                            DA = DA.OrderBy(x => x.Owner).ToList();
                        }
                        break;
                }

            }

                return View(DA);

        }

        // GET: ArtistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArtistController/Create
        public ActionResult Create()
        {
            return View();
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
