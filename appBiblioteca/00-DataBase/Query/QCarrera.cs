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
    public class QCarrera : RepoGeneric<DtoCarrera>
    {
        public bool Delete(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                Carrera carrera = dbc.Carreras.Find(primaryKey);

                dbc.Carreras.Remove(carrera);
                dbc.SaveChanges();

                return true;
            }
        }

        public bool Edit(DtoCarrera dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Carrera carrera = dbc.Carreras.Find(dto.codigoCarrera);

                carrera.nombre = dto.nombre;

                dbc.SaveChanges();

                return true;
            }
        }

        public List<DtoCarrera> GetAll()
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<List<DtoCarrera>>(dbc.Carreras.ToList());
            }
        }

        public DtoCarrera GetByPrimaryKey(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoCarrera>(dbc.Carreras.Find(primaryKey));
            }
        }

        public bool Insert(DtoCarrera dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Carrera carrera = Mapper.Map<Carrera>(dto);

                dbc.Carreras.Add(carrera);
                dbc.SaveChanges();

                return true;
            }
        }
    }
}