using System.Collections.Generic;

namespace _04_DataTransferObjects.Objects
{
    public class DtoUsuario
    {
        #region properties
        
        public string codigoUsuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string dni { get; set; }
        public string codigoInterno { get; set; }
        public bool sexo { get; set; }
        public string codigoCarrera { get; set; }
        public string rol { get; set; }
        public string contrasena { get; set; }

        #endregion

        #region parents
        
        public virtual DtoCarrera parentCarrera { get; set; }

        #endregion

        #region childs
        
        public virtual List<DtoDevolucion> childDevolucion { get; set; }
        
        public virtual List<DtoPrestamo> childPrestamo { get; set; }

        #endregion
    }
}