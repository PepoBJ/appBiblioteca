using _04_DataTransferObjects.Objects;
using System.Collections.Generic;

namespace _02_Presentation.ViewModel
{
    public class VMCategoria
    {
        public List<DtoCategoria> listaCategorias { get; set; }
        public DtoCategoria dtoCategoria { get; set; }
    }
}