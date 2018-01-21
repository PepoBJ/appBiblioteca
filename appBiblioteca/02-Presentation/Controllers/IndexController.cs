using _02_Presentation.Midelware;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    [SessionExpireFilter]
    public class IndexController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}