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
                tipo_facturacion,
                estado,
                total_flete
            )
            VALUES
            (
                $numeroRemito,
                $fecha,
                $idCliente,
                $tipoFacturacion,
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

            comando.Parameters.AddWithValue( "$tipoFacturacion", remito.TipoFacturacion.ToString());

            
            comando.Parameters.AddWithValue( "$estado", remito.Estado.ToString());

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
        r.tipo_facturacion,
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
                    TipoFacturacion = Enum.Parse<TipoFacturacion>( lector.GetString(4)),
                    Estado = Enum.Parse<EstadoRemito>(lector.GetString(5)),
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
                r.tipo_facturacion,
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
                    TipoFacturacion = Enum.Parse<TipoFacturacion>( lector.GetString(4)),
                    Estado = Enum.Parse<EstadoRemito>(lector.GetString(5)),
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
        r.tipo_facturacion,
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
                    TipoFacturacion = Enum.Parse<TipoFacturacion>( lector.GetString(4)),
                    Estado = Enum.Parse<EstadoRemito>(lector.GetString(5)),
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
        r.tipo_facturacion,
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
                    TipoFacturacion =  Enum.Parse<TipoFacturacion>( lector.GetString(4)), Estado = Enum.Parse<EstadoRemito>(lector.GetString(5)),
                    TotalFlete = Convert.ToDecimal(
                        lector.GetValue(6))
                };

                remitos.Add(remito);
            }

            return remitos;
        }

        public List<Remito> ObtenerPorFiltros(
    int idCliente,
    TipoFacturacion? tipoFacturacion,
    string estado,
    int? mes,
    int? anio)
        {
            List<Remito> remitos = new();

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
        r.tipo_facturacion,
        r.estado,
        r.total_flete,
        r.fecha_anulacion,
        r.motivo_anulacion
    FROM remito AS r
    WHERE r.id_cliente = $idCliente
      AND (
        $tipoFacturacion IS NULL
        OR r.tipo_facturacion = $tipoFacturacion
    )
      AND (
            $estado = 'Todos'
            OR r.estado = $estado
          )
      AND (
            $mes IS NULL
            OR CAST(strftime('%m', r.fecha) AS INTEGER) = $mes
          )
      AND (
            $anio IS NULL
            OR CAST(strftime('%Y', r.fecha) AS INTEGER) = $anio
          )
    ORDER BY r.fecha, r.numero_remito;
    """;

            comando.Parameters.AddWithValue(
                "$idCliente",
                idCliente);

            
            string? tipoFacturacionTexto =  tipoFacturacion?.ToString();
            comando.Parameters.AddWithValue( "$tipoFacturacion", (object?)tipoFacturacionTexto ?? DBNull.Value);

            comando.Parameters.AddWithValue(
                "$estado",
                estado);

            comando.Parameters.AddWithValue(
                "$mes",
                (object?)mes ?? DBNull.Value);

            comando.Parameters.AddWithValue(
                "$anio",
                (object?)anio ?? DBNull.Value);

            using SqliteDataReader lector =
                comando.ExecuteReader();

            while (lector.Read())
            {
                Remito remito = new()
                {
                    IdRemito = lector.GetInt32(0),
                    NumeroRemito = lector.GetString(1),
                    Fecha = DateTime.Parse(lector.GetString(2)),
                    IdCliente = lector.GetInt32(3),

                    TipoFacturacion =  Enum.Parse<TipoFacturacion>( lector.GetString(4)),

                   
                    Estado = Enum.Parse<EstadoRemito>(lector.GetString(5)),

                    TotalFlete =
                        Convert.ToDecimal(lector.GetValue(6)),
                    FechaAnulacion = lector.IsDBNull(7) ? null : DateTime.Parse( lector.GetString(7)),

                    MotivoAnulacion = lector.IsDBNull(8) ? null : lector.GetString(8) };

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
      AND estado = 'EnProceso';
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
        public void ActualizarEstado( int idRemito, EstadoRemito nuevoEstado, SqliteConnection conexion, SqliteTransaction transaccion)
        {
            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.Transaction = transaccion;

            comando.CommandText = """ UPDATE remito SET estado = $estado  WHERE id_remito = $idRemito; """;

            comando.Parameters.AddWithValue( "$estado", nuevoEstado.ToString());

            comando.Parameters.AddWithValue( "$idRemito", idRemito);

            comando.ExecuteNonQuery();
        }
        public void AnularRemito( int idRemito, DateTime fechaAnulacion, string motivoAnulacion)
        {
            using SqliteConnection conexion =  ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText =
            """
    UPDATE remito
    SET
        estado = $estado,
        fecha_anulacion = $fechaAnulacion,
        motivo_anulacion = $motivoAnulacion
    WHERE id_remito = $idRemito;
    """;

            comando.Parameters.AddWithValue(
                "$estado",
                EstadoRemito.Anulado.ToString());

            comando.Parameters.AddWithValue(
                "$fechaAnulacion",
                fechaAnulacion.ToString("yyyy-MM-dd"));

            comando.Parameters.AddWithValue(
                "$motivoAnulacion",
                motivoAnulacion);

            comando.Parameters.AddWithValue(
                "$idRemito",
                idRemito);

            comando.ExecuteNonQuery();
        }

    }
}