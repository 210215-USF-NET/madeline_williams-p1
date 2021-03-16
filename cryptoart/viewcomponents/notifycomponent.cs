using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ArtDL;
using ArtModel;
namespace cryptoart.viewcomponents
{

    public class NotifyViewComponent : ViewComponent
    {
        private readonly IArtRepo _repo;

        public NotifyViewComponent(IArtRepo repo)
        {
            _repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            var ses = this.HttpContext.Session;
            int user = (int)ses.GetInt32("id");
            string ut = ses.GetString("user");
            List<string> articles = new List<string>();
            if (user > -1)
            {
                articles = _repo.GetNotify(ut, user);
            }

            return View(articles);
        }
    }
    }

