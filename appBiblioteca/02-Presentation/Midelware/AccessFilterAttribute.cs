
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _02_Presentation.Midelware
{
    public class AccessFilterAttribute : ActionFilterAttribute
    {
        public string Rol { get; set; }
        private string[] Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Rol != null && Rol != string.Empty && HttpContext.Current.Session["rolUsuario"] != null)
            {
                Roles = Rol.Split(',');

                string CurrentRolUser = HttpContext.Current.Session["rolUsuario"].ToString();

                string[] usuarioRoles = CurrentRolUser.Split(',');

                bool access = Roles.Any(item => usuarioRoles.Any(rol => item.Equals(rol, StringComparison.OrdinalIgnoreCase)));

                if (!access)
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                            { "Controller", "Index" },
                            { "Action", "Index" }
                        }
                    );
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                            { "Controller", "Index" },
                            { "Action", "Index" }
                        }
                    );
            }

            base.OnActionExecuting(filterContext);
        }
    }
}