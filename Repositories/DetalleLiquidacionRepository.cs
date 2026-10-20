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

        public int Agregar(
    DetalleLiquidacion detalle,
    SqliteConnection conexion,
    SqliteTransaction transaccion)
        {
            using SqliteCommand comando = conexion.CreateCommand();

            comando.Transaction = transaccion;

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
        public List<Remito> ObtenerRemitosPorLiquidacion(
    int idLiquidacion)
        {
            List<Remito> remitos =
                new List<Remito>();

            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
    SELECT
        r.id_remito,
        r.numero_remito,
        r.fecha,
        r.id_cliente,
        r.condicion_pago,
        r.estado,
        r.total_flete
    FROM detalle_liquidacion AS dl
    INNER JOIN remito AS r
        ON r.id_remito = dl.id_remito
    WHERE dl.id_liquidacion = $idLiquidacion
    ORDER BY r.fecha, r.numero_remito;
    """;

            comando.Parameters.AddWithValue(
                "$idLiquidacion",
                idLiquidacion);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            while (lector.Read())
            {
                Remito remito =
                    new Remito
                    {
                        IdRemito = lector.GetInt32(0),
                        NumeroRemito = lector.GetString(1),
                        Fecha = DateTime.Parse(
                            lector.GetString(2)),
                        IdCliente = lector.GetInt32(3),
                        CondicionPago = lector.GetString(4),
                        Estado = lector.GetString(5),
                        TotalFlete =
                            Convert.ToDecimal(
                                lector.GetValue(6))
                    };

                remitos.Add(remito);
            }

            return remitos;
        }
    }
}