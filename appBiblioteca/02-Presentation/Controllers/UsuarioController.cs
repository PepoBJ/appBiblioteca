using _01.Business._Usuario;
using _01.Business.Carrera;
using _02_Presentation.Midelware;
using _02_Presentation.ViewModel;
using _03_Helpers.PresentationHelper;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    public class UsuarioController : Controller
    {
        BusinessUsuario _businessUsuario = null;
        BusinessCarrera _businessCarrera = null;
        VMUsuario _vmUsuario = null;

        public UsuarioController()
        {
            _businessUsuario = new BusinessUsuario();
            _businessCarrera = new BusinessCarrera();
            _vmUsuario = new VMUsuario();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(DtoUsuario dto)
        {
            if (_businessUsuario.Login(dto))
            {
                return Redirect(Url.Action("Index", "Index"));
            }
            else
            {
                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

                return Redirect(Url.Action("Login", "Usuario"));
            }
        }

        [SessionExpireFilter]
        [AccessFilter(Rol = "Administrador")]
        public ActionResult Insert()
        {
            _vmUsuario.listaCarreras = _businessCarrera.GetAll();

            return View(_vmUsuario);
        }

        [HttpPost]
        [AccessFilter(Rol = "Administrador")]
        public ActionResult Insert(DtoUsuario dto)
        {
            _businessUsuario.Insert(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Insert", "Usuario"));
        }

        [SessionExpireFilter]
        [AccessFilter(Rol = "Administrador")]
        public ActionResult List()
        {
            _vmUsuario.listaUsuarios = _businessUsuario.GetAll();

            return View(_vmUsuario);
        }

        [AccessFilter(Rol = "Administrador")]
        public ActionResult Delete(string parameter = null)
        {
            if(parameter != null)
            {
                _businessUsuario.Delete(parameter);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }

            return Redirect(Url.Action("List", "Usuario"));
        }

        [SessionExpireFilter]
        public ActionResult Edit(string parameter = null)
        {
            if(!Access.IsValidRol("Administrador"))
            {
                parameter = null;
            }

            if(parameter == null)
            {
                parameter = Session["codigoUsuario"].ToString();
            }

            _vmUsuario.listaCarreras = _businessCarrera.GetAll();
            _vmUsuario.dtoUsuario = _businessUsuario.GetByPrimaryKey(parameter);

            return View(_vmUsuario);
        }

        [HttpPost]
        public ActionResult Edit(DtoUsuario dto)
        {
            _businessUsuario.Edit(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Edit", "Usuario", new { parameter = dto.codigoUsuario }));
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Login", "Usuario");
        }
    }
}