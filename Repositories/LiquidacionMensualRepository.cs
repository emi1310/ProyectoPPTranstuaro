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
                estado,
                tipo_liquidacion
            )
            VALUES
            (
                $idCliente,
                $mes,
                $anio,
                $fechaEmision,
                $total,
                $estado,
                tipo_liquidacion
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

            comando.Parameters.AddWithValue(
                "$tipoLiquidacion",
                liquidacion.TipoLiquidacion);

            object? resultado = comando.ExecuteScalar();

            return Convert.ToInt32(resultado);
        }

        public int Agregar(
    LiquidacionMensual liquidacion,
    SqliteConnection conexion,
    SqliteTransaction transaccion)
        {
            using SqliteCommand comando = conexion.CreateCommand();

            comando.Transaction = transaccion;

            comando.CommandText =
            """
    INSERT INTO liquidacion_mensual
    (
        id_cliente,
        mes,
        anio,
        fecha_emision,
        total,
        estado,
        tipo_liquidacion
    )
    VALUES
    (
        $idCliente,
        $mes,
        $anio,
        $fechaEmision,
        $total,
        $estado,
        $tipoLiquidacion
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

            comando.Parameters.AddWithValue(
                "$tipoLiquidacion",
                liquidacion.TipoLiquidacion);

            object? resultado = comando.ExecuteScalar();

            return Convert.ToInt32(resultado);
        }
        public void ActualizarEstado(
            int idLiquidacion,
             string nuevoEstado)
        {
            using SqliteConnection conexion = ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
    UPDATE liquidacion_mensual
    SET estado = $nuevoEstado
    WHERE id_liquidacion = $idLiquidacion;
    """;

            comando.Parameters.AddWithValue(
                "$nuevoEstado",
                nuevoEstado);

            comando.Parameters.AddWithValue(
                "$idLiquidacion",
                idLiquidacion);

            comando.ExecuteNonQuery();
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
        public void ActualizarTotal(
    int idLiquidacion,
    decimal nuevoTotal,
    SqliteConnection conexion,
    SqliteTransaction transaccion)
        {
            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.Transaction = transaccion;

            comando.CommandText =
            """
    UPDATE liquidacion_mensual
    SET total = $nuevoTotal
    WHERE id_liquidacion = $idLiquidacion;
    """;

            comando.Parameters.AddWithValue(
                "$nuevoTotal",
                nuevoTotal);

            comando.Parameters.AddWithValue(
                "$idLiquidacion",
                idLiquidacion);

            comando.ExecuteNonQuery();
        }

        public LiquidacionMensual? ObtenerPorId(int idLiquidacion)
        {
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
        mes,
        anio,
        fecha_emision,
        total,
        estado
    FROM liquidacion_mensual
    WHERE id_liquidacion = $idLiquidacion;
    """;

            comando.Parameters.AddWithValue(
                "$idLiquidacion",
                idLiquidacion);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            if (!lector.Read())
            {
                return null;
            }

            return new LiquidacionMensual
            {
                IdLiquidacion = lector.GetInt32(0),
                IdCliente = lector.GetInt32(1),
                Mes = lector.GetInt32(2),
                Anio = lector.GetInt32(3),
                FechaEmision = DateTime.Parse(
                    lector.GetString(4)),
                Total = Convert.ToDecimal(
                    lector.GetValue(5)),
                Estado = lector.GetString(6)
            };
        }

        public List<LiquidacionMensual> ObtenerPorCliente(
    int idCliente)
        {
            List<LiquidacionMensual> liquidaciones =
                new List<LiquidacionMensual>();

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
        mes,
        anio,
        fecha_emision,
        total,
        estado,
        tipo_liquidacion
    FROM liquidacion_mensual
    WHERE id_cliente = $idCliente
    ORDER BY fecha_emision DESC, id_liquidacion DESC;
    """;

            comando.Parameters.AddWithValue(
                "$idCliente",
                idCliente);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            while (lector.Read())
            {
                LiquidacionMensual liquidacion =
                    new LiquidacionMensual
                    {
                        IdLiquidacion = lector.GetInt32(0),
                        IdCliente = lector.GetInt32(1),
                        Mes = lector.GetInt32(2),
                        Anio = lector.GetInt32(3),
                        FechaEmision =
                            DateTime.Parse(lector.GetString(4)),
                        Total =
                            Convert.ToDecimal(lector.GetValue(5)),
                        Estado = lector.GetString(6),
                        TipoLiquidacion = lector.GetString(7)
                    };

                liquidaciones.Add(liquidacion);
            }

            return liquidaciones;
        }

        public LiquidacionMensual? ObtenerPorClienteYPeriodo(
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
    SELECT
        id_liquidacion,
        id_cliente,
        mes,
        anio,
        fecha_emision,
        total,
        estado
    FROM liquidacion_mensual
    WHERE id_cliente = $idCliente
      AND mes = $mes
      AND anio = $anio
      AND tipo_liquidacion = 'Mensual'
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

            using SqliteDataReader lector =
                comando.ExecuteReader();

            if (!lector.Read())
            {
                return null;
            }

            return new LiquidacionMensual
            {
                IdLiquidacion = lector.GetInt32(0),
                IdCliente = lector.GetInt32(1),
                Mes = lector.GetInt32(2),
                Anio = lector.GetInt32(3),
                FechaEmision = DateTime.Parse(
                    lector.GetString(4)),
                Total = Convert.ToDecimal(
                    lector.GetValue(5)),
                Estado = lector.GetString(6)
            };
        }
    }
}