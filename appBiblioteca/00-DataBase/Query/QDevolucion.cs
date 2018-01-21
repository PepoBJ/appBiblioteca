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
    public class QDevolucion : RepoGeneric<DtoDevolucion>
    {
        public bool Delete(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                Devolucion devolucion = dbc.Devoluciones.Find(primaryKey);

                dbc.Devoluciones.Remove(devolucion);
                dbc.SaveChanges();

                return true;
            }
        }

        public bool Edit(DtoDevolucion dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Devolucion devolucion = dbc.Devoluciones.Find(dto.codigoDevolucion);

                devolucion.fechaDevolucion = dto.fechaDevolucion;

                dbc.SaveChanges();

                return true;
            }
        }

        public List<DtoDevolucion> GetAll()
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<List<DtoDevolucion>>(dbc.Devoluciones.ToList());
            }
        }

        public DtoDevolucion GetByPrimaryKey(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoDevolucion>(dbc.Devoluciones.Find(primaryKey));
            }
        }

        public bool Insert(DtoDevolucion dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Devolucion devolucion = Mapper.Map<Devolucion>(dto);

                dbc.Devoluciones.Add(devolucion);
                dbc.SaveChanges();

                return true;
            }
        }
    }
}