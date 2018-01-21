using _00_DataBase.Repository;
using _00_DataBase.Entities;
using _00_DataBase.Context;
using _04_DataTransferObjects.Objects;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _00_DataBase.Query
{
    public class QLibro : RepoGeneric<DtoLibro>
    {
        public bool Delete(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                Libro libro = dbc.Libros.Find(primaryKey);

                dbc.Libros.Remove(libro);
                dbc.SaveChanges();

                return true;
            }
        }

        public bool Edit(DtoLibro dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Libro libro = dbc.Libros.Find(dto.codigoLibro);

                libro.descripcion = dto.descripcion;
                libro.fechaLanzamiento = dto.fechaLanzamiento;
                libro.idioma = dto.idioma;
                libro.paginas = dto.paginas;
                libro.stock = dto.stock;
                libro.titulo = dto.titulo;

                dbc.SaveChanges();

                return true;
            }
        }

        public bool EditStock(DtoLibro dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Libro libro = dbc.Libros.Find(dto.codigoLibro);
                
                libro.stock = dto.stock;

                dbc.SaveChanges();

                return true;
            }
        }

        public List<DtoLibro> GetAll()
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<List<DtoLibro>>(dbc.Libros.ToList());
            }
        }

        public DtoLibro GetByPrimaryKey(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoLibro>(dbc.Libros.Find(primaryKey));
            }
        }

        public bool Insert(DtoLibro dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Libro libro = Mapper.Map<Libro>(dto);

                dbc.Libros.Add(libro);
                dbc.SaveChanges();

                return true;
            }
        }
    }
}