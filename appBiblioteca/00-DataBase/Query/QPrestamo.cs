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
    public class QPrestamo : RepoGeneric<DtoPrestamo>
    {
        public bool Delete(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                Prestamo prestamo = dbc.Prestamos.Find(primaryKey);

                dbc.Prestamos.Remove(prestamo);
                dbc.SaveChanges();

                return true;
            }
        }

        public bool Edit(DtoPrestamo dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Prestamo prestamo = dbc.Prestamos.Find(dto.codigoPrestamo);

                prestamo.fechaDevolucion = dto.fechaDevolucion;
                prestamo.fechaPrestamo = dto.fechaPrestamo;

                dbc.SaveChanges();

                return true;
            }
        }

        public bool ChangeEstate(DtoPrestamo dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Prestamo prestamo = dbc.Prestamos.Find(dto.codigoPrestamo);

                prestamo.estado = dto.estado;

                dbc.SaveChanges();

                return true;
            }
        }

        public DtoPrestamo GetByPrimaryKey(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoPrestamo>(dbc.Prestamos.Find(primaryKey));
            }
        }

        public bool Insert(DtoPrestamo dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Prestamo prestamo = Mapper.Map<Prestamo>(dto);

                dbc.Prestamos.Add(prestamo);
                dbc.SaveChanges();

                return true;
            }
        }

        public List<DtoPrestamo> GetAll()
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<List<DtoPrestamo>>(dbc.Prestamos.ToList());
            }
        }
    }
}