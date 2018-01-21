using System;

namespace _04_DataTransferObjects.Objects
{
    public class DtoPrestamo
    {
        #region properties
        
        public string codigoPrestamo { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public string codigoUsuario { get; set; }
        public string codigoLibro { get; set; }
        public string estado { get; set; }

        #endregion

        #region parents
        
        public virtual DtoUsuario parentUsuario { get; set; }
        
        public virtual DtoLibro parentLibro { get; set; }

        #endregion
    }
}