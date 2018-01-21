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
    public class QLibroCategoria : RepoGeneric<DtoLibroCategoria>
    {
        public bool Delete(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                LibroCategoria libroCategoria = dbc.LibroCategorias.Find(primaryKey);

                dbc.LibroCategorias.Remove(libroCategoria);
                dbc.SaveChanges();

                return true;
            }
        }

        public bool Edit(DtoLibroCategoria dto)
        {
            using (DBContext dbc = new DBContext())
            {
                LibroCategoria libroCategoria = dbc.LibroCategorias.Find(dto.codigoLibroCategoria);

                libroCategoria.codigoLibro = dto.codigoLibro;
                libroCategoria.codigoCategoria = dto.codigoCategoria;

                dbc.SaveChanges();

                return true;
            }
        }

        public List<DtoLibroCategoria> GetAll()
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<List<DtoLibroCategoria>>(dbc.LibroCategorias.ToList());
            }
        }

        public DtoLibroCategoria GetByPrimaryKey(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoLibroCategoria>(dbc.LibroCategorias.Find(primaryKey));
            }
        }

        public bool Insert(DtoLibroCategoria dto)
        {
            using (DBContext dbc = new DBContext())
            {
                LibroCategoria libroCategoria = Mapper.Map<LibroCategoria>(dto);

                dbc.LibroCategorias.Add(libroCategoria);
                dbc.SaveChanges();

                return true;
            }
        }
    }
}