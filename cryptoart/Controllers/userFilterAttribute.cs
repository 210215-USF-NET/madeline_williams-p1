using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
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
                //ses.SetString("user", "browser");
                //ses.SetString("user", "seller");
                //ses.SetString("user", "artist");

            }

        }
    }
}