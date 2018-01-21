using _01.Business._Usuario;
using _01.Business.Libro;
using _01.Business.Prestamo;
using _02_Presentation.Midelware;
using _02_Presentation.ViewModel;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    [SessionExpireFilter]
    public class PrestamoController : Controller
    {
        BusinessPrestamo _BusinessPrestamo = null;
        BusinessLibro _businessLibro = null;
        BusinessUsuario _businessUsuario = null;
        VMPrestamo _VMPrestamo = null;

        public PrestamoController()
        {
            _BusinessPrestamo = new BusinessPrestamo();
            _businessUsuario = new BusinessUsuario();
            _businessLibro = new BusinessLibro();
            _VMPrestamo = new VMPrestamo();
        }

        public ActionResult Insert()
        {
            _VMPrestamo.listaLibros = _businessLibro.GetAll();
            _VMPrestamo.listaUsuarios = _businessUsuario.GetAll();

            return View(_VMPrestamo);
        }

        [HttpPost]
        [AccessFilter(Rol = "Administrador,Bibliotecario")]
        public ActionResult Insert(DtoPrestamo dto)
        {
            _BusinessPrestamo.Insert(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Insert", "Prestamo"));
        }

        public ActionResult List()
        {
            _VMPrestamo.listaPrestamos = _BusinessPrestamo.GetAll();

            return View(_VMPrestamo);
        }

        [AccessFilter(Rol = "Administrador,Bibliotecario")]
        public ActionResult Delete(string parameter = null)
        {
            if (parameter != null)
            {
                _BusinessPrestamo.Delete(parameter);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }

            return Redirect(Url.Action("List", "Prestamo"));
        }

        [AccessFilter(Rol = "Administrador,Bibliotecario")]
        public ActionResult Edit(string parameter = null)
        {
            if (parameter == null)
            {
                return Redirect(Url.Action("List", "Prestamo"));
            }

            _VMPrestamo.dtoPrestamo = _BusinessPrestamo.GetByPrimaryKey(parameter);

            return View(_VMPrestamo);
        }

        [HttpPost]
        [AccessFilter(Rol = "Administrador,Bibliotecario")]
        public ActionResult Edit(DtoPrestamo dto)
        {
            _BusinessPrestamo.Edit(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Edit", "Prestamo", new { parameter = dto.codigoPrestamo }));
        }
    }
}