using _01.Business._Usuario;
using _01.Business.Devolucion;
using _01.Business.Libro;
using _02_Presentation.Midelware;
using _02_Presentation.ViewModel;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    [SessionExpireFilter]
    public class DevolucionController : Controller
    {
        BusinessDevolucion _BusinessDevolucion = null;
        BusinessLibro _businessLibro = null;
        BusinessUsuario _businessUsuario = null;
        VMDevolucion _VMDevolucion = null;

        public DevolucionController()
        {
            _BusinessDevolucion = new BusinessDevolucion();
            _businessUsuario = new BusinessUsuario();
            _businessLibro = new BusinessLibro();
            _VMDevolucion = new VMDevolucion();
        }

        [AccessFilter(Rol = "Administrador,Bibliotecario")]
        public ActionResult Insert(string parameter = null)
        {
            if (parameter != null)
            {
                DtoDevolucion dto = new DtoDevolucion();
                dto.codigoPrestamo = parameter;

                _BusinessDevolucion.Insert(dto);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }

            return Redirect(Url.Action("List", "Prestamo"));
        }
        
        public ActionResult List()
        {
            _VMDevolucion.listaDevoluciones = _BusinessDevolucion.GetAll();

            return View(_VMDevolucion);
        }

        [AccessFilter(Rol = "Administrador,Bibliotecario")]
        public ActionResult Delete(string parameter = null)
        {
            if (parameter != null)
            {
                _BusinessDevolucion.Delete(parameter);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }

            return Redirect(Url.Action("List", "Prestamo"));
        }        
    }
}