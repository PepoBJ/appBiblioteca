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
    public class QCategoria : RepoGeneric<DtoCategoria>
    {
        public bool Delete(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                Categoria categoria = dbc.Categorias.Find(primaryKey);

                dbc.Categorias.Remove(categoria);
                dbc.SaveChanges();

                return true;
            }
        }

        public bool Edit(DtoCategoria dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Categoria categoria = dbc.Categorias.Find(dto.codigoCategoria);

                categoria.nombre = dto.nombre;

                dbc.SaveChanges();

                return true;
            }
        }

        public List<DtoCategoria> GetAll()
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<List<DtoCategoria>>(dbc.Categorias.ToList());
            }
        }

        public DtoCategoria GetByPrimaryKey(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoCategoria>(dbc.Categorias.Find(primaryKey));
            }
        }

        public bool Insert(DtoCategoria dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Categoria categoria = Mapper.Map<Categoria>(dto);

                dbc.Categorias.Add(categoria);
                dbc.SaveChanges();

                return true;
            }
        }
    }
}