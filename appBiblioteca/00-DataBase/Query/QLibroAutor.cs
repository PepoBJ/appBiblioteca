using _00_DataBase.Entities;
using _00_DataBase.Repository;
using _00_DataBase.Context;
using _04_DataTransferObjects.Objects;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _00_DataBase.Query
{
    public class QLibroAutor : RepoGeneric<DtoLibroAutor>
    {
        public bool Delete(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                LibroAutor libroAutor = dbc.LibroAutores.Find(primaryKey);

                dbc.LibroAutores.Remove(libroAutor);
                dbc.SaveChanges();

                return true;
            }
        }

        public bool Edit(DtoLibroAutor dto)
        {
            using (DBContext dbc = new DBContext())
            {
                LibroAutor libroAutor = dbc.LibroAutores.Find(dto.codigoLibroAutor);

                libroAutor.codigoAutor = dto.codigoAutor;
                libroAutor.codigoLibro = dto.codigoLibro;

                dbc.SaveChanges();

                return true;
            }
        }

        public List<DtoLibroAutor> GetAll()
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<List<DtoLibroAutor>>(dbc.LibroAutores.ToList());
            }
        }

        public DtoLibroAutor GetByPrimaryKey(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoLibroAutor>(dbc.LibroAutores.Find(primaryKey));
            }
        }

        public bool Insert(DtoLibroAutor dto)
        {
            using (DBContext dbc = new DBContext())
            {
                LibroAutor libroAutor = Mapper.Map<LibroAutor>(dto);

                dbc.LibroAutores.Add(libroAutor);
                dbc.SaveChanges();

                return true;
            }
        }
    }
}