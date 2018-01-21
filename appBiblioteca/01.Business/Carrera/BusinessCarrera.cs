using _00_DataBase.Query;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System;
using System.Collections.Generic;

namespace _01.Business.Carrera
{
    public partial class BusinessCarrera
    {
        private QCarrera qCarrera = new QCarrera();

        public List<DtoCarrera> GetAll()
        {
            return qCarrera.GetAll();
        }

        public DtoCarrera GetByPrimaryKey(string primaryKey)
        {
            return qCarrera.GetByPrimaryKey(primaryKey);
        }

        public void Insert(DtoCarrera dto)
        {
            MensajeGlobal.Init();
            try
            {
                dto.codigoCarrera = Guid.NewGuid().ToString();
                qCarrera.Insert(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("La carrera se guardo correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar la carrera.");
            }
        }

        public void Edit(DtoCarrera dto)
        {
            MensajeGlobal.Init();
            try
            {
                qCarrera.Edit(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("La carrera se guardo correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar la carrera.");
            }
        }

        public void Delete(string primaryKey)
        {
            MensajeGlobal.Init();
            try
            {
                qCarrera.Delete(primaryKey);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("La carrera se elimino correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo eliminar la carrera.");
            }
        }
    }
}