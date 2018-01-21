using _04_DataTransferObjects.Objects;
using System.Collections.Generic;

namespace _02_Presentation.ViewModel
{
    public class VMLibro
    {
        public List<DtoLibro> listaLibros { get; set; }
        public DtoLibro dtoLibro { get; set; }
    }
}