using _00_DataBase.Query;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System;
using System.Collections.Generic;

namespace _01.Business.Autor
{
    public partial class BusinessAutor
    {
        private QAutor qAutor = new QAutor();

        public List<DtoAutor> GetAll()
        {
            return qAutor.GetAll();
        }

        public DtoAutor GetByPrimaryKey(string primaryKey)
        {
            return qAutor.GetByPrimaryKey(primaryKey);
        }

        public void Insert(DtoAutor dto)
        {
            MensajeGlobal.Init();
            try
            {
                dto.codigoAutor = Guid.NewGuid().ToString();

                qAutor.Insert(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el autor se guardo correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar el autor.");
            }
        }

        public void Edit(DtoAutor dto)
        {
            MensajeGlobal.Init();
            try
            {
                qAutor.Edit(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el autor se guardo correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar el autor.");
            }
        }

        public void Delete(string primaryKey)
        {
            MensajeGlobal.Init();
            try
            {
                qAutor.Delete(primaryKey);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el autor se elimino correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo eliminar el autor.");
            }
        }
    }
}