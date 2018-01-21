using System;
using System.Linq;
using System.Web;

namespace _03_Helpers.PresentationHelper
{
    public class Access
    {
        public static bool IsValidRol(string role)
        {
            string[] roles = role.Split(',');

            string[] dtoUsuarioRoles = HttpContext.Current.Session["rolUsuario"].ToString().Split(',');

            return roles.Any(item => dtoUsuarioRoles.Any(rol => item.Equals(rol, StringComparison.OrdinalIgnoreCase)));
        }
    }
}
