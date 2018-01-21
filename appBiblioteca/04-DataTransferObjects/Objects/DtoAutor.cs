using System.Collections.Generic;

namespace _04_DataTransferObjects.Objects
{
    public class DtoAutor
    {
        #region properties
        
        public string codigoAutor { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }

        #endregion

        #region childs
        
        public virtual List<DtoLibroAutor> childLibroAutor { get; set; }

        #endregion
    }
}