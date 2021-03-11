using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using auctionBL;
using ArtModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

        public ActionResult Gallery(int id)
        {

            return View(_bl.GetArtists().ToList());

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
