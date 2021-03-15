using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
namespace cryptoart.Controllers
{
    internal class clearUserFilterAttribute : ActionFilterAttribute
    {
   

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var ses = context.HttpContext.Session;
            
                 ses.SetString("user", "browser");
                ses.SetInt32("id",-1);
                ses.SetString("Name", "Generica");
        }
    }
}