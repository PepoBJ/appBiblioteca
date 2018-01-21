using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_DataBase.Entities
{
    public class Carrera
    {
        #region properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigoCarrera { get; set; }
        public string nombre { get; set; }

        #endregion

        #region childs
            
        [ForeignKey("codigoCarrera")]
        public virtual List<Usuario> childUsuario { get; set; }

        #endregion
    }
}