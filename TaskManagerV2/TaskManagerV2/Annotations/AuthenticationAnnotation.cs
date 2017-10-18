using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerV2.Models;

namespace TaskManagerV2.Annotations
{
    public class AuthenticationAnnotation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.LoggedUser == null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
                return;
            }
        }
    }
}