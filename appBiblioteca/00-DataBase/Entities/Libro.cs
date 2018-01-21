using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_DataBase.Entities
{
    public class Libro
    {
        #region properties
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string codigoLibro { get; set; }
        public string titulo { get; set; }
        public DateTime fechaLanzamiento { get; set; }
        public string idioma { get; set; }
        public int paginas { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }

        #endregion

        #region childs

        [ForeignKey("codigoLibro")]
        public virtual List<LibroCategoria> childLibroCategoria { get; set; }

        [ForeignKey("codigoLibro")]
        public virtual List<LibroAutor> childLibroAutor { get; set; }

        [ForeignKey("codigoLibro")]
        public virtual List<Prestamo> childPrestamo { get; set; }

        [ForeignKey("codigoLibro")]
        public virtual List<Devolucion> childDevolucion { get; set; }

        #endregion
    }
}