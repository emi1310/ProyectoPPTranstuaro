using Microsoft.Data.Sqlite;
using Trastuaro_V2.Datos;
using Trastuaro_V2.Modelos.Reportes;

namespace Trastuaro_V2.Repositories
{
    public class ReporteRepository
    {
        public List<RankingClienteReporte> ObtenerRankingClientes(
            int mes,
            int anio)
        {
            List<RankingClienteReporte> ranking = new();

            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
            SELECT
                c.nombre_razon_social,
                COUNT(DISTINCT r.id_remito) AS cantidad_remitos,
                SUM(dl.importe) AS total_facturado
            FROM detalle_liquidacion AS dl

            INNER JOIN remito AS r
                ON r.id_remito = dl.id_remito

            INNER JOIN cliente AS c
                ON c.id_cliente = r.id_cliente

            WHERE CAST(strftime('%m', r.fecha) AS INTEGER) = $mes
              AND CAST(strftime('%Y', r.fecha) AS INTEGER) = $anio

            GROUP BY
                c.id_cliente,
                c.nombre_razon_social

            ORDER BY
                total_facturado DESC;
            """;

            comando.Parameters.AddWithValue(
                "$mes",
                mes);

            comando.Parameters.AddWithValue(
                "$anio",
                anio);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            int puesto = 1;

            while (lector.Read())
            {
                RankingClienteReporte item = new()
                {
                    Puesto = puesto,
                    Cliente = lector.GetString(0),
                    Periodo = $"{mes:D2}/{anio}",
                    CantidadRemitos = lector.GetInt32(1),
                    TotalFacturado =
                        Convert.ToDecimal(
                            lector.GetValue(2))
                };

                ranking.Add(item);

                puesto++;
            }

            return ranking;
        }

        public ResumenMensualReporte ObtenerResumenMensual(
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
    SELECT
        COALESCE(SUM(dl.importe), 0) AS total_facturado,

        COALESCE(SUM(
            CASE
                WHEN r.tipo_facturacion = 'CuentaCorriente'
                THEN dl.importe
                ELSE 0
            END
        ), 0) AS total_cuenta_corriente,

        COALESCE(SUM(
            CASE
                WHEN r.tipo_facturacion = 'Contado'
                THEN dl.importe
                ELSE 0
            END
        ), 0) AS total_contado,

        COUNT(DISTINCT r.id_cliente) AS clientes_con_actividad,

        COUNT(DISTINCT r.id_remito) AS cantidad_remitos,

        COUNT(DISTINCT dl.id_liquidacion) AS cantidad_liquidaciones

    FROM detalle_liquidacion AS dl

    INNER JOIN remito AS r
        ON r.id_remito = dl.id_remito

    WHERE CAST(strftime('%m', r.fecha) AS INTEGER) = $mes
      AND CAST(strftime('%Y', r.fecha) AS INTEGER) = $anio;
    """;

            comando.Parameters.AddWithValue(
                "$mes",
                mes);

            comando.Parameters.AddWithValue(
                "$anio",
                anio);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            if (!lector.Read())
            {
                return new ResumenMensualReporte
                {
                    Periodo = $"{mes:D2}/{anio}"
                };
            }

            return new ResumenMensualReporte
            {
                Periodo = $"{mes:D2}/{anio}",

                TotalFacturado =
                    Convert.ToDecimal(
                        lector.GetValue(0)),

                TotalCuentaCorriente =
                    Convert.ToDecimal(
                        lector.GetValue(1)),

                TotalContado =
                    Convert.ToDecimal(
                        lector.GetValue(2)),

                ClientesConActividad =
                    lector.GetInt32(3),

                CantidadRemitos =
                    lector.GetInt32(4),

                CantidadLiquidaciones =
                    lector.GetInt32(5)
            };
        }
    }
}