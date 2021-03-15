using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using ArtDL;
namespace cryptoart.Controllers
{
    internal class BidWorkerFilterAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var ses = context.HttpContext.Session;
            IArtRepo repo = context.HttpContext.RequestServices.GetService<IArtRepo>();
       
                repo.Maintain();
       
        }
    }
}