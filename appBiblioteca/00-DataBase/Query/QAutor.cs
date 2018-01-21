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
    public class QAutor : RepoGeneric<DtoAutor>
    {
        public bool Delete(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                Autor autor = dbc.Autores.Find(primaryKey);

                dbc.Autores.Remove(autor);
                dbc.SaveChanges();

                return true;
            }
        }

        public bool Edit(DtoAutor dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Autor autor = dbc.Autores.Find(dto.codigoAutor);

                autor.nombre = dto.nombre;
                autor.apellidos = dto.apellidos;

                dbc.SaveChanges();

                return true;
            }
        }

        public List<DtoAutor> GetAll()
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<List<DtoAutor>>(dbc.Autores.ToList());
            }
        }

        public DtoAutor GetByPrimaryKey(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoAutor>(dbc.Autores.Find(primaryKey));
            }
        }

        public bool Insert(DtoAutor dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Autor autor = Mapper.Map<Autor>(dto);

                dbc.Autores.Add(autor);
                dbc.SaveChanges();

                return true;
            }
        }
    }
}