using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace _03_Helpers.BusinessHelper
{
    public class Encriptar
    {
        public static string Sha512(string cadena)
        {
            SHA512 hashTool = new SHA512Managed();

            byte[] texto = Encoding.UTF8.GetBytes(string.Concat(cadena, (ConfigurationManager.AppSettings["password"])));
            byte[] resultado = hashTool.ComputeHash(texto);
            string textoCifrado = Convert.ToBase64String(resultado);

            return textoCifrado;
        }
    }
}