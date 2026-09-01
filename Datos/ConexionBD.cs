using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.Sqlite;

namespace GestionRemitosTransporte.Datos
{
    public static class ConexionBD
    {
        private static readonly string rutaBaseDatos =
            Path.Combine(AppContext.BaseDirectory, "BaseDatos", "BaseDatos_Remitos_Transporte.sqlite");

        public static SqliteConnection ObtenerConexion()
        {
            SqliteConnection conexion = new SqliteConnection($"Data Source={rutaBaseDatos}");
            conexion.Open();

            return conexion;
        }

        public static string ObtenerRutaBaseDatos()
        {
            return rutaBaseDatos;
        }
    }
}