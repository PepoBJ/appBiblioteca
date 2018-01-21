using System;
using System.Collections.Generic;

namespace _04_DataTransferObjects.Objects
{
    public class DtoLibro
    {
        #region properties
        
        public string codigoLibro { get; set; }
        public string titulo { get; set; }
        public DateTime fechaLanzamiento { get; set; }
        public string idioma { get; set; }
        public int paginas { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }

        #endregion

        #region childs
        
        public virtual List<DtoLibroCategoria> childLibroCategoria { get; set; }
        
        public virtual List<DtoLibroAutor> childLibroAutor { get; set; }
        
        public virtual List<DtoPrestamo> childPrestamo { get; set; }
        
        public virtual List<DtoDevolucion> childDevolucion { get; set; }

        #endregion
    }
}