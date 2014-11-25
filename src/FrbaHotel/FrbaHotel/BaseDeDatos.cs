using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace FrbaHotel
{
    class BaseDeDatos
    {

        public static SqlConnection conectar()
        {
            string connectionString = Program.conexion;
            return new SqlConnection(connectionString);
        }

        public static string agregarApostrofos(string palabra)
        {
            return "'" + palabra + "'";
        }

        public static string agregarPorcentajes(string palabra)
        {
            return "%" + palabra + "%";
        }

        public static string cifrar256(string texto)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            SHA256Managed provider = new SHA256Managed();
            byte[] hash = provider.ComputeHash(bytes);
            string textoHash = string.Empty;
            foreach (byte x in hash)
            {
                textoHash += String.Format("{0:X2}", x);
            }
            return textoHash;
        }
        public static int converTrimToInt(int numero)
        {
            return numero * 3;
        }
    }

}
