using _01.Business.Categoria;
using _01.Business.Libro;
using _01.Business.LibroCategoria;
using _02_Presentation.Midelware;
using _02_Presentation.ViewModel;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    [SessionExpireFilter]
    [AccessFilter(Rol = "Administrador,Bibliotecario")]
    public class LibroCategoriaController : Controller
    {
        BusinessLibroCategoria _BusinessLibroCategoria = null;
        BusinessCategoria _BusinessCategoria = null;
        BusinessLibro _businessLibro = null;
        VMLibroCategoria _VMLibroCategoria = null;

        public LibroCategoriaController()
        {
            _BusinessLibroCategoria = new BusinessLibroCategoria();
            _BusinessCategoria = new BusinessCategoria();
            _businessLibro = new BusinessLibro();
            _VMLibroCategoria = new VMLibroCategoria();
        }

        public ActionResult Insert()
        {
            _VMLibroCategoria.listaCategorias = _BusinessCategoria.GetAll();
            _VMLibroCategoria.listaLibros = _businessLibro.GetAll();

            return View(_VMLibroCategoria);
        }

        [HttpPost]
        public ActionResult Insert(DtoLibroCategoria dto)
        {
            _BusinessLibroCategoria.Insert(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Insert", "LibroCategoria"));
        }

        public ActionResult List()
        {
            _VMLibroCategoria.listaLibros = _businessLibro.GetAll();

            return View(_VMLibroCategoria);
        }

        public ActionResult Delete(string parameter = null)
        {
            if (parameter != null)
            {
                _BusinessLibroCategoria.Delete(parameter);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }

            return Redirect(Url.Action("List", "LibroCategoria"));
        }

        public ActionResult Edit(string parameter = null)
        {
            if (parameter == null)
            {
                return Redirect(Url.Action("List", "LibroCategoria"));
            }

            _VMLibroCategoria.dtoLibroCategoria = _BusinessLibroCategoria.GetByPrimaryKey(parameter);
            _VMLibroCategoria.listaCategorias = _BusinessCategoria.GetAll();
            _VMLibroCategoria.listaLibros = _businessLibro.GetAll();

            return View(_VMLibroCategoria);
        }

        [HttpPost]
        public ActionResult Edit(DtoLibroCategoria dto)
        {
            _BusinessLibroCategoria.Edit(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Edit", "LibroCategoria", new { parameter = dto.codigoLibroCategoria }));
        }
    }
}