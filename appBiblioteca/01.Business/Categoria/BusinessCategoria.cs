using _00_DataBase.Query;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System;
using System.Collections.Generic;

namespace _01.Business.Categoria
{
    public partial class BusinessCategoria
    {
        private QCategoria qCategoria = new QCategoria();

        public List<DtoCategoria> GetAll()
        {
            return qCategoria.GetAll();
        }

        public DtoCategoria GetByPrimaryKey(string primaryKey)
        {
            return qCategoria.GetByPrimaryKey(primaryKey);
        }

        public void Insert(DtoCategoria dto)
        {
            MensajeGlobal.Init();
            try
            {
                dto.codigoCategoria = Guid.NewGuid().ToString();

                qCategoria.Insert(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("La categoria fue registrada correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo registrar la categoria.");
            }
        }

        public void Edit(DtoCategoria dto)
        {
            MensajeGlobal.Init();
            try
            {
                qCategoria.Edit(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("La categoria fue modificada correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo modificada la categoria.");
            }
        }

        public void Delete(string primaryKey)
        {
            MensajeGlobal.Init();
            try
            {
                qCategoria.Delete(primaryKey);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("La categoria fue eliminada correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo eliminar la categoria.");
            }
        }
    }
}