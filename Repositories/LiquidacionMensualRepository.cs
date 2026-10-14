using Microsoft.Data.Sqlite;
using Trastuaro_V2.Datos;
using Trastuaro_V2.Modelos;

namespace Trastuaro_V2.Repositories
{
    public class LiquidacionMensualRepository
    {
        public int Agregar(LiquidacionMensual liquidacion)
        {
            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
            INSERT INTO liquidacion_mensual
            (
                id_cliente,
                mes,
                anio,
                fecha_emision,
                total,
                estado
            )
            VALUES
            (
                $idCliente,
                $mes,
                $anio,
                $fechaEmision,
                $total,
                $estado
            );

            SELECT last_insert_rowid();
            """;

            comando.Parameters.AddWithValue(
                "$idCliente",
                liquidacion.IdCliente);

            comando.Parameters.AddWithValue(
                "$mes",
                liquidacion.Mes);

            comando.Parameters.AddWithValue(
                "$anio",
                liquidacion.Anio);

            comando.Parameters.AddWithValue(
                "$fechaEmision",
                liquidacion.FechaEmision.ToString("yyyy-MM-dd"));

            comando.Parameters.AddWithValue(
                "$total",
                liquidacion.Total);

            comando.Parameters.AddWithValue(
                "$estado",
                liquidacion.Estado);

            object? resultado = comando.ExecuteScalar();

            return Convert.ToInt32(resultado);
        }
        public bool ExisteParaClienteYPeriodo(
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
                FROM liquidacion_mensual
                WHERE id_cliente = $idCliente
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

            object? resultado = comando.ExecuteScalar();

            return Convert.ToInt32(resultado) > 0;
        }
    }
}