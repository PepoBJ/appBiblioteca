using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _02_Presentation.Midelware
{
    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["codigoUsuario"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {
                        { "Controller", "Usuario" },
                        { "Action", "Login" }
                    }
                );
            }

            base.OnActionExecuting(filterContext);
        }
    }
}