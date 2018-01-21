using _00_DataBase.Query;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System;
using System.Collections.Generic;

namespace _01.Business.Libro
{
    public partial class BusinessLibro
    {
        private QLibro qLibro = new QLibro();

        public List<DtoLibro> GetAll()
        {
            return qLibro.GetAll();
        }

        public DtoLibro GetByPrimaryKey(string primaryKey)
        {
            return qLibro.GetByPrimaryKey(primaryKey);
        }

        public void Insert(DtoLibro dto)
        {
            MensajeGlobal.Init();
            try
            {
                dto.codigoLibro = Guid.NewGuid().ToString();

                qLibro.Insert(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("El libro fue modificada correctamente.");
            }
            catch (Exception e)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo registrar el libro.");
            }
        }

        public void Edit(DtoLibro dto)
        {
            MensajeGlobal.Init();
            try
            {
                qLibro.Edit(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("El libro fue modificada correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo modificada el libro.");
            }
        }

        public void Delete(string primaryKey)
        {
            MensajeGlobal.Init();
            try
            {
                qLibro.Delete(primaryKey);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("El libro fue eliminado correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo eliminar el libro.");
            }
        }
    }
}