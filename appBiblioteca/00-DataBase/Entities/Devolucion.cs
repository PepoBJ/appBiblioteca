
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_DataBase.Entities
{
    public class Devolucion
    {
        #region properties
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigoDevolucion { get; set; }
        public DateTime fechaConsignada { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public string codigoUsuario { get; set; }
        public string codigoLibro { get; set; }
        public string codigoPrestamo { get; set; }

        #endregion

        #region parents

        [ForeignKey("codigoUsuario")]
        public virtual Usuario parentUsuario { get; set; }

        [ForeignKey("codigoLibro")]
        public virtual Libro parentLibro { get; set; }

        #endregion
    }
}