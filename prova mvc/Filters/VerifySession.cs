using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prova_mvc.Models;
using prova_mvc.Controllers;

namespace prova_mvc.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var Ouser = (user)HttpContext.Current.Session["User"];
            if (Ouser == null)
            {
                if (filterContext.Controller is HomeController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/index");
                }
            }
            else {
                if (filterContext.Controller is HomeController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Dashboard/index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}