using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_DataBase.Entities
{
    public class Autor
    {
        #region properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigoAutor { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }

        #endregion

        #region childs
        
        [ForeignKey("codigoAutor")]
        public virtual List<LibroAutor> childLibroAutor { get; set; }

        #endregion
    }
}