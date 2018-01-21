using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_DataBase.Entities
{
    public class LibroCategoria
    {
        #region properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigoLibroCategoria { get; set; }
        public string codigoCategoria { get; set; }
        public string codigoLibro { get; set; }

        #endregion

        #region parents

        [ForeignKey("codigoCategoria")]
        public virtual Categoria parentCategoria { get; set; }

        [ForeignKey("codigoCategoria")]
        public virtual Libro parentLibro { get; set; }

        #endregion

    }
}