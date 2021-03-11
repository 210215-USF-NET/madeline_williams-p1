
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptoart
{
    public class userFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
           
            var ses = context.HttpContext.Session;
            if (ses.GetString("user") == ""){
                ses.SetString("user","browser");
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           // throw new NotImplementedException();
        }
    }
}
