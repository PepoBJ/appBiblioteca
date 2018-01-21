using _04_DataTransferObjects.Objects;
using System.Collections.Generic;

namespace _02_Presentation.ViewModel
{
    public class VMLibroCategoria
    {
        public List<DtoLibro> listaLibros { get; set; }
        public List<DtoLibroCategoria> listaLibroCategoria { get; set; }
        public List<DtoCategoria> listaCategorias { get; set; }
        public DtoLibroCategoria dtoLibroCategoria { get; set; }
    }
}