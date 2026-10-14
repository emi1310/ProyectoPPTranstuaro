using Microsoft.Data.Sqlite;
using Trastuaro_V2.Datos;
using Trastuaro_V2.Modelos;

namespace Trastuaro_V2.Repositories
{
    public class DetalleLiquidacionRepository
    {
        public int Agregar(DetalleLiquidacion detalle)
        {
            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
            INSERT INTO detalle_liquidacion
            (
                id_liquidacion,
                id_remito,
                importe
            )
            VALUES
            (
                $idLiquidacion,
                $idRemito,
                $importe
            );

            SELECT last_insert_rowid();
            """;

            comando.Parameters.AddWithValue(
                "$idLiquidacion",
                detalle.IdLiquidacion);

            comando.Parameters.AddWithValue(
                "$idRemito",
                detalle.IdRemito);

            comando.Parameters.AddWithValue(
                "$importe",
                detalle.Importe);

            object? resultado = comando.ExecuteScalar();

            return Convert.ToInt32(resultado);
        }
    }
}