using _04_DataTransferObjects.Objects;
using System.Collections.Generic;

namespace _02_Presentation.ViewModel
{
    public class VMUsuario
    {
        public List<DtoCarrera> listaCarreras { get; set; }
        public List<DtoUsuario> listaUsuarios { get; set; }
        public DtoUsuario dtoUsuario { get; set; }
    }
}