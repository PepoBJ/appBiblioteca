using System.Collections.Generic;

namespace _04_DataTransferObjects.Message
{
    public class MensajeGlobal
    {
        public static string tipo { get; set; }
        public static List<string> listaMensaje { get; set; }

        public static void Init()
        {
            listaMensaje = new List<string>();
        }

        public static void TipoCorrecto()
        {
            tipo = "Correcto";
        }

        public static void TipoAlerta()
        {
            tipo = "Alerta";
        }

        public static void TipoError()
        {
            tipo = "Error";
        }
    }
}