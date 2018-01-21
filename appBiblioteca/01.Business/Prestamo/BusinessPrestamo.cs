using _00_DataBase.Query;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System;
using System.Collections.Generic;

namespace _01.Business.Prestamo
{
    public partial class BusinessPrestamo
    {
        private QPrestamo qPrestamo = new QPrestamo();
        private QLibro qLibro = new QLibro();

        public List<DtoPrestamo> GetAll()
        {
            return qPrestamo.GetAll();
        }

        public DtoPrestamo GetByPrimaryKey(string primaryKey)
        {
            return qPrestamo.GetByPrimaryKey(primaryKey);
        }

        public void Insert(DtoPrestamo dto)
        {
            MensajeGlobal.Init();
            try
            {
                dto.codigoPrestamo = Guid.NewGuid().ToString();
                dto.estado = "no devuleto";
                dto.fechaPrestamo = DateTime.Now;

                DtoLibro libro = qLibro.GetByPrimaryKey(dto.codigoLibro);

                if(libro.stock <= 0)
                {
                    MensajeGlobal.TipoError();
                    MensajeGlobal.listaMensaje.Add("No se pudo guardar el Prestamo, el libro esta fuera de stock.");

                    return;
                }

                libro.stock--;

                qLibro.EditStock(libro);
                qPrestamo.Insert(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el Prestamo se guardo correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar el Prestamo.");
            }
        }

        public void Edit(DtoPrestamo dto)
        {
            MensajeGlobal.Init();
            try
            {
                qPrestamo.Edit(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el Prestamo se guardo correctamente.");
            }
            catch (Exception e)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar el Prestamo.");
            }
        }

        public void Delete(string primaryKey)
        {
            MensajeGlobal.Init();
            try
            {
                DtoLibro libro = qLibro.GetByPrimaryKey(qPrestamo.GetByPrimaryKey(primaryKey).codigoLibro);

                libro.stock++;

                qLibro.EditStock(libro);

                qPrestamo.Delete(primaryKey);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("el Prestamo se elimino correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo eliminar el Prestamo.");
            }
        }
    }
}