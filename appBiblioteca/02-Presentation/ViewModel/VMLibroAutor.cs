using _04_DataTransferObjects.Objects;
using System.Collections.Generic;

namespace _02_Presentation.ViewModel
{
    public class VMLibroAutor
    {
        public List<DtoLibro> listaLibros { get; set; }
        public List<DtoLibroAutor> listaLibroAutor { get; set; }
        public List<DtoAutor> listaAutores { get; set; }
        public DtoLibroAutor dtoLibroAutor { get; set; }
    }
}