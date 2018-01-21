using _01.Business.Autor;
using _01.Business.Libro;
using _01.Business.LibroAutor;
using _02_Presentation.Midelware;
using _02_Presentation.ViewModel;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    [SessionExpireFilter]
    [AccessFilter(Rol = "Administrador,Bibliotecario")]
    public class LibroAutorController : Controller
    {
        BusinessLibroAutor _businessLibroAutor = null;
        BusinessAutor _businessAutor = null;
        BusinessLibro _businessLibro = null;
        VMLibroAutor _VMLibroAutor = null;

        public LibroAutorController()
        {
            _businessLibroAutor = new BusinessLibroAutor();
            _businessAutor = new BusinessAutor();
            _businessLibro = new BusinessLibro();
            _VMLibroAutor = new VMLibroAutor();
        }

        public ActionResult Insert()
        {
            _VMLibroAutor.listaAutores = _businessAutor.GetAll();
            _VMLibroAutor.listaLibros = _businessLibro.GetAll();

            return View(_VMLibroAutor);
        }

        [HttpPost]
        public ActionResult Insert(DtoLibroAutor dto)
        {
            _businessLibroAutor.Insert(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Insert", "LibroAutor"));
        }

        public ActionResult List()
        {
            _VMLibroAutor.listaAutores = _businessAutor.GetAll();

            return View(_VMLibroAutor);
        }

        public ActionResult Delete(string parameter = null)
        {
            if (parameter != null)
            {
                _businessLibroAutor.Delete(parameter);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }

            return Redirect(Url.Action("List", "LibroAutor"));
        }

        public ActionResult Edit(string parameter = null)
        {
            if (parameter == null)
            {
                return Redirect(Url.Action("List", "LibroAutor"));
            }

            _VMLibroAutor.dtoLibroAutor = _businessLibroAutor.GetByPrimaryKey(parameter);
            _VMLibroAutor.listaAutores = _businessAutor.GetAll();
            _VMLibroAutor.listaLibros = _businessLibro.GetAll();

            return View(_VMLibroAutor);
        }

        [HttpPost]
        public ActionResult Edit(DtoLibroAutor dto)
        {
            _businessLibroAutor.Edit(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Edit", "LibroAutor", new { parameter = dto.codigoLibroAutor }));
        }
    }
}