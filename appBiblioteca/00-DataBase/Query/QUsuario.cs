using System;
using _00_DataBase.Entities;
using _00_DataBase.Repository;
using _00_DataBase.Context;
using System.Linq;
using _04_DataTransferObjects.Objects;
using AutoMapper;
using System.Collections.Generic;

namespace _00_DataBase.Query
{
    public class QUsuario : RepoGeneric<DtoUsuario>
    {
        public bool Delete(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                Usuario usuario = dbc.Usuarios.Find(primaryKey);

                dbc.Usuarios.Remove(usuario);
                dbc.SaveChanges();

                return true;
            }
        }

        public bool Edit(DtoUsuario dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Usuario usuario = dbc.Usuarios.Find(dto.codigoUsuario);

                usuario.nombre = dto.nombre;
                usuario.apellidos = dto.apellidos;
                usuario.codigoCarrera = dto.codigoCarrera;
                usuario.codigoInterno = dto.codigoInterno;
                usuario.direccion = dto.direccion;
                usuario.dni = dto.dni;
                usuario.sexo = dto.sexo;
                usuario.telefono = dto.telefono;
                usuario.rol = dto.rol;

                dbc.SaveChanges();

                return true;
            }
        }

        public DtoUsuario GetByPrimaryKey(string primaryKey)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoUsuario>(dbc.Usuarios.Find(primaryKey));
            }
        }

        public DtoUsuario GetByDni(string dni)
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<DtoUsuario>(dbc.Usuarios.Where(u => u.dni.Equals(dni)).FirstOrDefault());
            }
        }

        public bool Insert(DtoUsuario dto)
        {
            using (DBContext dbc = new DBContext())
            {
                Usuario usuario = Mapper.Map<Usuario>(dto);

                dbc.Usuarios.Add(usuario);
                dbc.SaveChanges();

                return true;
            }
        }

        public List<DtoUsuario> GetAll()
        {
            using (DBContext dbc = new DBContext())
            {
                return Mapper.Map<List<DtoUsuario>>(dbc.Usuarios.ToList());
            }
        }
    }
}