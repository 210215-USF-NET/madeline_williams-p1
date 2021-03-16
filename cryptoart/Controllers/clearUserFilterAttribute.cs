using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
namespace cryptoart.Controllers
{
    internal class userFilterAttribute : ActionFilterAttribute
    {
   

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var ses = context.HttpContext.Session;
            if (ses.GetString("user") == null)
            {
                 ses.SetString("user", "browser");
                ses.SetInt32("id",-1);
                ses.SetString("Name", "Generica");
                Log.Warning("Clearing out user information");

            }

        }
    }
}