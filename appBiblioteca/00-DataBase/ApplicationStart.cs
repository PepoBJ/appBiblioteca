using _00_DataBase.Entities;
using _04_DataTransferObjects.Objects;
using AutoMapper;

namespace _00_DataBase
{
    public class ApplicationStart
    {
        public static void Start()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DtoUsuario, Usuario>().MaxDepth(7);
                cfg.CreateMap<DtoAutor, Autor>().MaxDepth(7);
                cfg.CreateMap<DtoLibro, Libro>().MaxDepth(7);
                cfg.CreateMap<DtoCarrera, Carrera>().MaxDepth(7);
                cfg.CreateMap<DtoCategoria, Categoria>().MaxDepth(7);
                cfg.CreateMap<DtoDevolucion, Devolucion>().MaxDepth(7);
                cfg.CreateMap<DtoPrestamo, Prestamo>().MaxDepth(7);
                cfg.CreateMap<DtoLibroAutor, LibroAutor>().MaxDepth(7);
                cfg.CreateMap<DtoLibroCategoria, LibroCategoria>().MaxDepth(7);

                cfg.CreateMap<Usuario, DtoUsuario>().MaxDepth(7);
                cfg.CreateMap<Autor, DtoAutor>().MaxDepth(7);
                cfg.CreateMap<Libro, DtoLibro>().MaxDepth(7);
                cfg.CreateMap<Carrera, DtoCarrera>().MaxDepth(7);
                cfg.CreateMap<Categoria, DtoCategoria>().MaxDepth(7);
                cfg.CreateMap<Devolucion, DtoDevolucion>().MaxDepth(7);
                cfg.CreateMap<Prestamo, DtoPrestamo>().MaxDepth(7);
                cfg.CreateMap<LibroAutor, DtoLibroAutor>().MaxDepth(7);
                cfg.CreateMap<LibroCategoria, DtoLibroCategoria>().MaxDepth(7);
            });
        }
    }
}