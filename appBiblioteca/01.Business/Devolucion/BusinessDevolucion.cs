using _00_DataBase.Query;
using _04_DataTransferObjects.Message;
using _04_DataTransferObjects.Objects;
using System;
using System.Collections.Generic;

namespace _01.Business.Devolucion
{
    public partial class BusinessDevolucion
    {
        private QDevolucion qDevolucion = new QDevolucion();
        private QPrestamo qPrestamo = new QPrestamo();
        private QLibro qLibro = new QLibro();

        public List<DtoDevolucion> GetAll()
        {
            return qDevolucion.GetAll();
        }

        public DtoDevolucion GetByPrimaryKey(string primaryKey)
        {
            return qDevolucion.GetByPrimaryKey(primaryKey);
        }

        public void Insert(DtoDevolucion dto)
        {
            MensajeGlobal.Init();
            try
            {
                dto.codigoDevolucion = Guid.NewGuid().ToString();
                dto.fechaDevolucion = DateTime.Now;

                DtoPrestamo prestamo = qPrestamo.GetByPrimaryKey(dto.codigoPrestamo);

                dto.fechaConsignada = prestamo.fechaDevolucion;
                prestamo.estado = "devuelto";
                dto.codigoUsuario = prestamo.codigoUsuario;
                dto.codigoLibro = prestamo.codigoLibro;

                qPrestamo.ChangeEstate(prestamo);

                DtoLibro libro = qLibro.GetByPrimaryKey(dto.codigoLibro);
                
                libro.stock++;

                qLibro.EditStock(libro);
                qDevolucion.Insert(dto);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("Se proceso la devolucion del libro correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo guardar la devolucion.");
            }
        }
        
        public void Delete(string primaryKey)
        {
            MensajeGlobal.Init();
            try
            {
                DtoLibro libro = qLibro.GetByPrimaryKey(qDevolucion.GetByPrimaryKey(primaryKey).codigoLibro);

                DtoDevolucion dto = qDevolucion.GetByPrimaryKey(primaryKey);

                DtoPrestamo prestamo = qPrestamo.GetByPrimaryKey(dto.codigoPrestamo);
                
                prestamo.estado = "no devuelto";

                qPrestamo.ChangeEstate(prestamo);

                libro.stock--;

                qLibro.EditStock(libro);

                qDevolucion.Delete(primaryKey);

                MensajeGlobal.TipoCorrecto();
                MensajeGlobal.listaMensaje.Clear();
                MensajeGlobal.listaMensaje.Add("la devolucion se elimino correctamente.");
            }
            catch (Exception)
            {
                MensajeGlobal.TipoError();
                MensajeGlobal.listaMensaje.Add("No se pudo eliminar la devolucion.");
            }
        }
    }
}