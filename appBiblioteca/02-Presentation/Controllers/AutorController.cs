using _01.Business.Autor;
using _02_Presentation.Midelware;
using _02_Presentation.ViewModel;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    [SessionExpireFilter]
    [AccessFilter(Rol = "Administrador,Bibliotecario")]
    public class AutorController : Controller
    {
        BusinessAutor _BusinessAutor = null;
        VMAutor _VMAutor = null;

        public AutorController()
        {
            _BusinessAutor = new BusinessAutor();
            _VMAutor = new VMAutor();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(DtoAutor dto)
        {
            _BusinessAutor.Insert(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Insert", "Autor"));
        }

        public ActionResult List()
        {
            _VMAutor.listaAutores = _BusinessAutor.GetAll();

            return View(_VMAutor);
        }

        public ActionResult Delete(string parameter = null)
        {
            if (parameter != null)
            {
                _BusinessAutor.Delete(parameter);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }

            return Redirect(Url.Action("List", "Autor"));
        }

        public ActionResult Edit(string parameter = null)
        {
            if (parameter == null)
            {
                return Redirect(Url.Action("List", "Autor"));
            }

            _VMAutor.dtoAutor = _BusinessAutor.GetByPrimaryKey(parameter);

            return View(_VMAutor);
        }

        [HttpPost]
        public ActionResult Edit(DtoAutor dto)
        {
            _BusinessAutor.Edit(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Edit", "Autor", new { parameter = dto.codigoAutor }));
        }
    }
}