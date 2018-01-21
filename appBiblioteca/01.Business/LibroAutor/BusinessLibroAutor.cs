using _00_DataBase.Query;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System;
using System.Collections.Generic;

namespace _01.Business.LibroAutor
{
    public partial class BusinessLibroAutor
    {
        private QLibroAutor qLibroAutor = new QLibroAutor();

        public List<DtoLibroAutor> GetAll()
        {
            return qLibroAutor.GetAll();
        }

        public DtoLibroAutor GetByPrimaryKey(string primaryKey)
        {
            return qLibroAutor.GetByPrimaryKey(primaryKey);
        }

        public void Insert(DtoLibroAutor dto)
        {
            MensajeGlobal.Init();
            try
            {
                dto.codigoLibroAutor = Guid.NewGuid().ToString();

                qLibroAutor.Insert(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el libro - autor se guardo correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar el libro - autor.");
            }
        }

        public void Edit(DtoLibroAutor dto)
        {
            MensajeGlobal.Init();
            try
            {
                qLibroAutor.Edit(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el libro - autor se guardo correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar el libro - autor.");
            }
        }

        public void Delete(string primaryKey)
        {
            MensajeGlobal.Init();
            try
            {
                qLibroAutor.Delete(primaryKey);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el libro - autor se elimino correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo eliminar el libro - autor.");
            }
        }
    }
}