using _04_DataTransferObjects.Objects;
using System.Collections.Generic;

namespace _02_Presentation.ViewModel
{
    public class VMCarrera
    {
        public List<DtoCarrera> listaCarreras { get; set; }
        public DtoCarrera dtoCarrera { get; set; }
    }
}