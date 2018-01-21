using _01.Business.Categoria;
using _02_Presentation.Midelware;
using _02_Presentation.ViewModel;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System.Web.Mvc;

namespace _02_Presentation.Controllers
{
    [SessionExpireFilter]
    [AccessFilter(Rol = "Administrador,Bibliotecario")]
    public class CategoriaController : Controller
    {
        BusinessCategoria _businessCategoria = null;
        VMCategoria _vmCategoria = null;

        public CategoriaController()
        {
            _businessCategoria = new BusinessCategoria();
            _vmCategoria = new VMCategoria();
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(DtoCategoria dto)
        {
            _businessCategoria.Insert(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Insert", "Categoria"));
        }

        public ActionResult List()
        {
            _vmCategoria.listaCategorias = _businessCategoria.GetAll();

            return View(_vmCategoria);
        }

        public ActionResult Delete(string parameter = null)
        {
            if(parameter != null)
            {
                _businessCategoria.Delete(parameter);

                TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
                TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");
            }
            
            return Redirect(Url.Action("List", "Categoria"));
        }

        public ActionResult Edit(string parameter = null)
        {
            if(parameter == null)
            {
                return Redirect(Url.Action("List", "Categoria"));
            }

            _vmCategoria.dtoCategoria = _businessCategoria.GetByPrimaryKey(parameter);

            return View(_vmCategoria);
        }

        [HttpPost]
        public ActionResult Edit(DtoCategoria dto)
        {
            _businessCategoria.Edit(dto);

            TempData["mensajeGlobal"] = MensajeGlobal.listaMensaje;
            TempData["correcto"] = MensajeGlobal.tipo.Equals("Correcto");

            return Redirect(Url.Action("Edit", "Categoria", new { parameter = dto.codigoCategoria }));
        }
    }
}