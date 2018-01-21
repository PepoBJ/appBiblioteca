using _04_DataTransferObjects.Objects;
using System.Collections.Generic;

namespace _02_Presentation.ViewModel
{
    public class VMPrestamo
    {
        public List<DtoPrestamo> listaPrestamos { get; set; }
        public DtoPrestamo dtoPrestamo { get; set; }
        public List<DtoLibro> listaLibros { get; set; }
        public List<DtoUsuario> listaUsuarios { get; set; }
    }
}