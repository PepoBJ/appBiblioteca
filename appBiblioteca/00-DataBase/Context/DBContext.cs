using _00_DataBase.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace _00_DataBase.Context
{
    public class DBContext : DbContext
    {
        #region Dbsets

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Devolucion> Devoluciones { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<LibroAutor> LibroAutores { get; set; }
        public DbSet<LibroCategoria> LibroCategorias { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        #endregion

        #region configurations 

        public DBContext() : base("biblioteca")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<DBContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        #endregion        
    }
}