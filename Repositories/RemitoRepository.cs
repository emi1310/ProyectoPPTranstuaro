using Microsoft.Data.Sqlite;
using Trastuaro_V2.Datos;
using Trastuaro_V2.Modelos;

namespace Trastuaro_V2.Repositories
{
    public class RemitoRepository
    {
        public int Agregar(Remito remito)
        {
            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
            INSERT INTO remito
            (
                numero_remito,
                fecha,
                id_cliente,
                condicion_pago,
                estado,
                total_flete
            )
            VALUES
            (
                $numeroRemito,
                $fecha,
                $idCliente,
                $condicionPago,
                $estado,
                $totalFlete
            );

            SELECT last_insert_rowid();
            """;

            comando.Parameters.AddWithValue(
                "$numeroRemito",
                remito.NumeroRemito);

            comando.Parameters.AddWithValue(
                "$fecha",
                remito.Fecha.ToString("yyyy-MM-dd"));

            comando.Parameters.AddWithValue(
                "$idCliente",
                remito.IdCliente);

            comando.Parameters.AddWithValue(
                "$condicionPago",
                remito.CondicionPago);

            comando.Parameters.AddWithValue(
                "$estado",
                remito.Estado);

            comando.Parameters.AddWithValue(
                "$totalFlete",
                remito.TotalFlete);

            object? resultado = comando.ExecuteScalar();

            return Convert.ToInt32(resultado);
        }

        public List<Remito> ObtenerPorClienteYEstado(
    int idCliente,
    string estado)
        {
            List<Remito> remitos = new List<Remito>();

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
    FROM remito AS r
    WHERE r.id_cliente = $idCliente
      AND (
            $estado = 'Todos'
            OR r.estado = $estado
          )
    ORDER BY r.fecha, r.numero_remito;
    """;

            comando.Parameters.AddWithValue(
                "$idCliente",
                idCliente);

            comando.Parameters.AddWithValue(
                "$estado",
                estado);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            while (lector.Read())
            {
                Remito remito = new Remito
                {
                    IdRemito = lector.GetInt32(0),
                    NumeroRemito = lector.GetString(1),
                    Fecha = DateTime.Parse(lector.GetString(2)),
                    IdCliente = lector.GetInt32(3),
                    CondicionPago = lector.GetString(4),
                    Estado = lector.GetString(5),
                    TotalFlete = Convert.ToDecimal(
                        lector.GetValue(6))
                };

                remitos.Add(remito);
            }

            return remitos;
        }

        public List<Remito> ObtenerPendientesPorClienteYPeriodo(
    int idCliente,
    int mes,
    int anio)
        {
            List<Remito> remitos = new List<Remito>();

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
            FROM remito AS r
            WHERE r.id_cliente = $idCliente
              AND CAST(strftime('%m', r.fecha) AS INTEGER) = $mes
              AND CAST(strftime('%Y', r.fecha) AS INTEGER) = $anio
              AND NOT EXISTS
              (
                  SELECT 1
                  FROM detalle_liquidacion AS dl
                  WHERE dl.id_remito = r.id_remito
              )
            ORDER BY r.fecha, r.numero_remito;
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

            while (lector.Read())
            {
                Remito remito = new Remito
                {
                    IdRemito = lector.GetInt32(0),
                    NumeroRemito = lector.GetString(1),
                    Fecha = DateTime.Parse(lector.GetString(2)),
                    IdCliente = lector.GetInt32(3),
                    CondicionPago = lector.GetString(4),
                    Estado = lector.GetString(5),
                    TotalFlete = Convert.ToDecimal(
                        lector.GetValue(6))
                };

                remitos.Add(remito);
            }

            return remitos;
        }

        public List<Remito> ObtenerPorClientePeriodoYEstado(
    int idCliente,
    int mes,
    int anio,
    string estado)
        {
            List<Remito> remitos = new List<Remito>();

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
    FROM remito AS r
    WHERE r.id_cliente = $idCliente
      AND CAST(strftime('%m', r.fecha) AS INTEGER) = $mes
      AND CAST(strftime('%Y', r.fecha) AS INTEGER) = $anio
      AND ($estado = 'Todos' OR r.estado = $estado)
    ORDER BY r.fecha, r.numero_remito;
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

            comando.Parameters.AddWithValue(
                "$estado",
                estado);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            while (lector.Read())
            {
                Remito remito = new Remito
                {
                    IdRemito = lector.GetInt32(0),
                    NumeroRemito = lector.GetString(1),
                    Fecha = DateTime.Parse(lector.GetString(2)),
                    IdCliente = lector.GetInt32(3),
                    CondicionPago = lector.GetString(4),
                    Estado = lector.GetString(5),
                    TotalFlete = Convert.ToDecimal(
                        lector.GetValue(6))
                };

                remitos.Add(remito);
            }

            return remitos;
        }
        // Búsqueda de remitos para clientes sin CC
        public List<Remito> ObtenerPendientesPorCliente(
    int idCliente)
        {
            List<Remito> remitos = new List<Remito>();

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
    FROM remito AS r
    WHERE r.id_cliente = $idCliente
      AND r.estado = 'Pendiente'
    ORDER BY r.fecha, r.numero_remito;
    """;

            comando.Parameters.AddWithValue(
                "$idCliente",
                idCliente);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            while (lector.Read())
            {
                Remito remito = new Remito
                {
                    IdRemito = lector.GetInt32(0),
                    NumeroRemito = lector.GetString(1),
                    Fecha = DateTime.Parse(lector.GetString(2)),
                    IdCliente = lector.GetInt32(3),
                    CondicionPago = lector.GetString(4),
                    Estado = lector.GetString(5),
                    TotalFlete = Convert.ToDecimal(
                        lector.GetValue(6))
                };

                remitos.Add(remito);
            }

            return remitos;
        }
        public void ActualizarEstado(int idRemito, string nuevoEstado)
        {
            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
    UPDATE remito
    SET estado = $nuevoEstado
    WHERE id_remito = $idRemito;
    """;

            comando.Parameters.AddWithValue(
                "$nuevoEstado",
                nuevoEstado);

            comando.Parameters.AddWithValue(
                "$idRemito",
                idRemito);

            comando.ExecuteNonQuery();
        }

        public void FacturarRemitosEnProcesoPorPeriodo(
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
    UPDATE remito
    SET estado = 'Facturado'
    WHERE id_cliente = $idCliente
      AND CAST(strftime('%m', fecha) AS INTEGER) = $mes
      AND CAST(strftime('%Y', fecha) AS INTEGER) = $anio
      AND estado = 'En proceso';
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

            comando.ExecuteNonQuery();
        }

        public void ActualizarEstado(
    int idRemito,
    string nuevoEstado,
    SqliteConnection conexion,
    SqliteTransaction transaccion)
        {
            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.Transaction = transaccion;

            comando.CommandText =
            """
    UPDATE remito
    SET estado = $nuevoEstado
    WHERE id_remito = $idRemito;
    """;

            comando.Parameters.AddWithValue(
                "$nuevoEstado",
                nuevoEstado);

            comando.Parameters.AddWithValue(
                "$idRemito",
                idRemito);

            comando.ExecuteNonQuery();
        }
        public string ObtenerProximoNumero()
        {
            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =  """  SELECT COALESCE( MAX(CAST(numero_remito AS INTEGER)), 0 ) + 1  FROM remito; """;

            object? resultado = comando.ExecuteScalar();

            int proximoNumero =
                Convert.ToInt32(resultado);

            return proximoNumero.ToString("D4");
        }



    }
}