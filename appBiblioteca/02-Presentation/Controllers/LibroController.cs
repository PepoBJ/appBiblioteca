using _01.Business.Libro;
using _02_Presentation.Midelware;
using _02_Presentation.ViewModel;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    [SessionExpireFilter]
    [AccessFilter(Rol = "Administrador,Bibliotecario")]
    public class LibroController : Controller
    {
        BusinessLibro _BusinessLibro = null;
        VMLibro _VMLibro = null;

        public LibroController()
        {
            _BusinessLibro = new BusinessLibro();
            _VMLibro = new VMLibro();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(DtoLibro dto)
        {
            _BusinessLibro.Insert(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Insert", "Libro"));
        }

        public ActionResult List()
        {
            _VMLibro.listaLibros = _BusinessLibro.GetAll();

            return View(_VMLibro);
        }

        public ActionResult Delete(string parameter = null)
        {
            if (parameter != null)
            {
                _BusinessLibro.Delete(parameter);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }

            return Redirect(Url.Action("List", "Libro"));
        }

        public ActionResult Edit(string parameter = null)
        {
            if (parameter == null)
            {
                return Redirect(Url.Action("List", "Libro"));
            }

            _VMLibro.dtoLibro = _BusinessLibro.GetByPrimaryKey(parameter);

            return View(_VMLibro);
        }

        [HttpPost]
        public ActionResult Edit(DtoLibro dto)
        {
            _BusinessLibro.Edit(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Edit", "Libro", new { parameter = dto.codigoLibro }));
        }
    }
}