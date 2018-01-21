using System;
using System.Collections.Generic;

namespace _04_DataTransferObjects.Objects
{
    public class DtoCarrera
    {
        #region properties
        
        public string codigoCarrera { get; set; }
        public string nombre { get; set; }

        #endregion

        #region childs
        
        public virtual List<DtoUsuario> childUsuario { get; set; }

        #endregion
    }
}