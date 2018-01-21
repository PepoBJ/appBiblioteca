using System.Collections.Generic;

namespace _04_DataTransferObjects.Objects
{
    public class DtoCategoria
    {
        #region properties
        
        public string codigoCategoria { get; set; }
        public string nombre { get; set; }

        #endregion

        #region childs
        
        public virtual List<DtoLibroCategoria> childLibroCategoria { get; set; }

        #endregion
    }
}