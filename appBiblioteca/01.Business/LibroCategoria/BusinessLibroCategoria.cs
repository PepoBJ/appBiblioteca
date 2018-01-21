using _00_DataBase.Query;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System;
using System.Collections.Generic;

namespace _01.Business.LibroCategoria
{
    public partial class BusinessLibroCategoria
    {
        private QLibroCategoria qLibroCategoria = new QLibroCategoria();

        public List<DtoLibroCategoria> GetAll()
        {
            return qLibroCategoria.GetAll();
        }

        public DtoLibroCategoria GetByPrimaryKey(string primaryKey)
        {
            return qLibroCategoria.GetByPrimaryKey(primaryKey);
        }

        public void Insert(DtoLibroCategoria dto)
        {
            MensajeGlobal.Init();
            try
            {
                dto.codigoLibroCategoria = Guid.NewGuid().ToString();

                qLibroCategoria.Insert(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el libro - categoria se guardo correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar el libro - categoria.");
            }
        }

        public void Edit(DtoLibroCategoria dto)
        {
            MensajeGlobal.Init();
            try
            {
                qLibroCategoria.Edit(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el libro - categoria se guardo correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar el libro - categoria.");
            }
        }

        public void Delete(string primaryKey)
        {
            MensajeGlobal.Init();
            try
            {
                qLibroCategoria.Delete(primaryKey);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el libro - categoria se elimino correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo eliminar el libro - categoria.");
            }
        }
    }
}