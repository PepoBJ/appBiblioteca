using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_DataBase.Entities
{
    public class Usuario
    {
        #region properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigoUsuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string dni { get; set; }
        public string codigoInterno { get; set; }
        public bool sexo { get; set; }
        public string codigoCarrera { get; set; }
        public string rol { get; set; }
        public string contrasena { get; set; }

        #endregion

        #region parents
        
        [ForeignKey("codigoCarrera")]
        public virtual Carrera parentCarrera { get; set; }

        #endregion

        #region childs

        [ForeignKey("codigoUsuario")]
        public virtual List<Devolucion> childDevolucion { get; set; }

        [ForeignKey("codigoUsuario")]
        public virtual List<Prestamo> childPrestamo { get; set; }

        #endregion
    }
}