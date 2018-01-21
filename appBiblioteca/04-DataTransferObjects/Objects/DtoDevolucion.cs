using System;

namespace _04_DataTransferObjects.Objects
{
    public class DtoDevolucion
    {
        #region properties
        
        public string codigoDevolucion { get; set; }
        public DateTime fechaConsignada { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public string codigoUsuario { get; set; }
        public string codigoLibro { get; set; }

        public string codigoPrestamo { get; set; }
        #endregion

        #region parents

        public virtual DtoUsuario parentUsuario { get; set; }
        
        public virtual DtoLibro parentLibro { get; set; }

        #endregion
    }
}