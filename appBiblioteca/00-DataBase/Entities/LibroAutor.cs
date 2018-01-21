using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_DataBase.Entities
{
    public class LibroAutor
    {

        #region properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigoLibroAutor { get; set; }
        public string codigoAutor { get; set; }
        public string codigoLibro { get; set; }

        #endregion

        #region parents
        
        [ForeignKey("codigoAutor")]
        public virtual Autor parentAutor { get; set; }

        [ForeignKey("codigoLibro")]
        public virtual Libro parentLibro { get; set; }

        #endregion

    }
}