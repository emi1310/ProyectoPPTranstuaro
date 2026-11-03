using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trastuaro_V2.Modelos;

using Trastuaro_V2.Datos;

namespace Trastuaro_V2.Repositories
{
    public class LiquidacionRepository
    {
        public int Agregar(
            Liquidacion liquidacion,
            SqliteConnection conexion,
            SqliteTransaction transaccion)
        {
            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.Transaction = transaccion;

            comando.CommandText =
            """
            INSERT INTO liquidacion
            (
                id_cliente,
                fecha_emision,
                tipo_facturacion,
                mes,
                anio,
                estado,
                total
            )
            VALUES
            (
                $idCliente,
                $fechaEmision,
                $tipoFacturacion,
                $mes,
                $anio,
                $estado,
                $total
            );

            SELECT last_insert_rowid();
            """;

            comando.Parameters.AddWithValue(
                "$idCliente",
                liquidacion.IdCliente);

            comando.Parameters.AddWithValue(
                "$fechaEmision",
                liquidacion.FechaEmision.ToString("yyyy-MM-dd"));

            comando.Parameters.AddWithValue(
                "$tipoFacturacion",
                liquidacion.TipoFacturacion.ToString());

            comando.Parameters.AddWithValue(
                "$mes",
                (object?)liquidacion.Mes ?? DBNull.Value);

            comando.Parameters.AddWithValue(
                "$anio",
                (object?)liquidacion.Anio ?? DBNull.Value);

            comando.Parameters.AddWithValue(
                "$estado",
                liquidacion.Estado.ToString());

            comando.Parameters.AddWithValue(
                "$total",
                liquidacion.Total);

            object? resultado =
                comando.ExecuteScalar();

            return Convert.ToInt32(resultado);
        }
        public List<Liquidacion> ObtenerPorCliente(int idCliente)
        {
            List<Liquidacion> liquidaciones = new();

            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
    SELECT
        id_liquidacion,
        id_cliente,
        fecha_emision,
        tipo_facturacion,
        mes,
        anio,
        estado,
        total
    FROM liquidacion
    WHERE id_cliente = $idCliente
    ORDER BY fecha_emision DESC,
             id_liquidacion DESC;
    """;

            comando.Parameters.AddWithValue(
                "$idCliente",
                idCliente);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            while (lector.Read())
            {
                Liquidacion liquidacion = new()
                {
                    IdLiquidacion =
                        lector.GetInt32(
                            lector.GetOrdinal("id_liquidacion")),

                    IdCliente =
                        lector.GetInt32(
                            lector.GetOrdinal("id_cliente")),

                    FechaEmision =
                        DateTime.Parse(
                            lector.GetString(
                                lector.GetOrdinal("fecha_emision"))),

                    TipoFacturacion =
                        Enum.Parse<TipoFacturacion>(
                            lector.GetString(
                                lector.GetOrdinal("tipo_facturacion"))),

                    Mes =
                        lector.IsDBNull(
                            lector.GetOrdinal("mes"))
                            ? null
                            : lector.GetInt32(
                                lector.GetOrdinal("mes")),

                    Anio =
                        lector.IsDBNull(
                            lector.GetOrdinal("anio"))
                            ? null
                            : lector.GetInt32(
                                lector.GetOrdinal("anio")),

                    Estado =
                        Enum.Parse<EstadoLiquidacion>(
                            lector.GetString(
                                lector.GetOrdinal("estado"))),

                    Total =
                        lector.GetDecimal(
                            lector.GetOrdinal("total"))
                };

                liquidaciones.Add(liquidacion);
            }

            return liquidaciones;
        }
        public bool ExisteCuentaCorrientePorPeriodo(
    int idCliente,
    int mes,
    int anio)
        {
            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
    SELECT COUNT(*)
    FROM liquidacion
    WHERE id_cliente = $idCliente
      AND tipo_facturacion = 'CuentaCorriente'
      AND mes = $mes
      AND anio = $anio;
    """;

            comando.Parameters.AddWithValue(
                "$idCliente",
                idCliente);

            comando.Parameters.AddWithValue(
                "$mes",
                mes);

            comando.Parameters.AddWithValue(
                "$anio",
                anio);

            long cantidad =
                Convert.ToInt64(
                    comando.ExecuteScalar());

            return cantidad > 0;
        }
    }
}