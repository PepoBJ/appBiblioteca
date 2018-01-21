using _00_DataBase.Query;
using _03_Helpers.BusinessHelper;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System;
using System.Collections.Generic;
using System.Web;
using _E = _00_DataBase.Entities;

namespace _01.Business._Usuario
{
    public partial class BusinessUsuario
    {
        private QUsuario qUsuario = new QUsuario();
        
        public bool Login(DtoUsuario dto)
        {
            MensajeGlobal.Init();
            try
            {
                DtoUsuario dtoUsuarioAuth = qUsuario.GetByDni(dto.dni);

                dto.contrasena = Encriptar.Sha512(dto.contrasena);

                var x = dtoUsuarioAuth.parentCarrera;

                if (dtoUsuarioAuth != null && dto.contrasena.Equals(dtoUsuarioAuth.contrasena))
                {
                    HttpContext.Current.Session["codigoUsuario"] = dtoUsuarioAuth.codigoUsuario;
                    HttpContext.Current.Session["nombre"] = dtoUsuarioAuth.nombre + " " + dtoUsuarioAuth.apellidos;
                    HttpContext.Current.Session["dni"] = dtoUsuarioAuth.dni;
                    HttpContext.Current.Session["rolUsuario"] = dtoUsuarioAuth.rol;

                    return true;
                }
                else
                {
                    MensajeGlobal.TipoError();
                    MensajeGlobal.listaMensaje.Add("El correo electronico o la contraseña son incorrectos.");

                    return false;
                }
            }
            catch (Exception e)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo ingresar al sistema.");

                return false;
            }
        }

        public void Insert(DtoUsuario dto)
        {
            MensajeGlobal.Init();
            try
            {
                dto.codigoUsuario = Guid.NewGuid().ToString();
                dto.contrasena = Encriptar.Sha512(dto.contrasena);

                qUsuario.Insert(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("El usuario fue registrado correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo registrar el usuario, DNI o codigoInterno duplicado.");
            }
        }

        public void Edit(DtoUsuario dto)
        {
            MensajeGlobal.Init();
            try
            {
                qUsuario.Edit(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("El usuario fue modificado correctamente.");
            }
            catch (Exception e)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo modificadar el usuario, DNI o codigoInterno duplicado.");
            }
        }

        public List<DtoUsuario> GetAll()
        {
            return qUsuario.GetAll();
        }

        public void Delete(string primaryKey)
        {
            MensajeGlobal.Init();

            try
            {
                qUsuario.Delete(primaryKey);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("Se elimino al usuario.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo elminar al usuario.");
            }
        }

        public DtoUsuario GetByPrimaryKey(string primaryKey)
        {
            return qUsuario.GetByPrimaryKey(primaryKey);
        }
    }
}