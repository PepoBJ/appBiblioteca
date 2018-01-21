using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_DataBase.Entities
{
    public class Prestamo
    {
        #region properties
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigoPrestamo { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public DateTime fechaDevolucion { get; set; }
        public string codigoUsuario { get; set; }
        public string codigoLibro { get; set; }
        public string estado { get; set; }

        #endregion

        #region parents
        
        [ForeignKey("codigoUsuario")]
        public virtual Usuario parentUsuario { get; set; }

        [ForeignKey("codigoLibro")]
        public virtual Libro parentLibro { get; set; }
        
        #endregion
    }
}