using _01.Business.Carrera;
using _02_Presentation.Midelware;
using _02_Presentation.ViewModel;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    [SessionExpireFilter]
    [AccessFilter(Rol = "Administrador,Bibliotecario")]
    public class CarreraController : Controller
    {
        BusinessCarrera _businessCarrera = null;
        VMCarrera _vmCarrera = null;

        public CarreraController()
        {
            _businessCarrera = new BusinessCarrera();
            _vmCarrera = new VMCarrera();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(DtoCarrera dto)
        {
            _businessCarrera.Insert(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Insert", "Carrera"));
        }

        public ActionResult List()
        {
            _vmCarrera.listaCarreras = _businessCarrera.GetAll();

            return View(_vmCarrera);
        }

        public ActionResult Delete(string parameter = null)
        {
            if (parameter != null)
            {
                _businessCarrera.Delete(parameter);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }

            return Redirect(Url.Action("List", "Carrera"));
        }

        public ActionResult Edit(string parameter = null)
        {
            if (parameter == null)
            {
                return Redirect(Url.Action("List", "Carrera"));
            }

            _vmCarrera.dtoCarrera = _businessCarrera.GetByPrimaryKey(parameter);

            return View(_vmCarrera);
        }

        [HttpPost]
        public ActionResult Edit(DtoCarrera dto)
        {
            _businessCarrera.Edit(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Edit", "Carrera", new { parameter = dto.codigoCarrera }));
        }
    }
}