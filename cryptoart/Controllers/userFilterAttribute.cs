using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
namespace cryptoart.Controllers
{
    internal class userFilterAttribute : Attribute
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

            var ses = context.HttpContext.Session;
            if (ses.GetString("user") == "")
            {
                ses.SetString("user", "collector");
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // throw new NotImplementedException();
        }
    }
}