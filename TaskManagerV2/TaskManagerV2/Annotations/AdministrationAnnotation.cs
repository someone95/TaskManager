using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerV2.Models;

namespace TaskManagerV2.Annotations
{
    public class AdministrationAnnotation : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthenticationManager.LoggedUser.IsAdmin == false)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
                return;
            }
        }
    }
}