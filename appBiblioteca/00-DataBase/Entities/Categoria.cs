using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_DataBase.Entities
{
    public class Categoria
    {
        #region properties
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigoCategoria { get; set; }
        public string nombre { get; set; }

        #endregion

        #region childs
        
        [ForeignKey("codigoCategoria")]
        public virtual List<LibroCategoria> childLibroCategoria { get; set; }

        #endregion
    }
}