using Microsoft.Data.Sqlite;
using Trastuaro_V2.Datos;
using Trastuaro_V2.Modelos;

namespace Trastuaro_V2.Repositories
{
    public class ClienteRepository
    {
        public int Agregar(Cliente cliente)
        {
            using SqliteConnection conexion = ConexionBD.CrearConexion();
            conexion.Open();

            using SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText =
            """
            INSERT INTO cliente
            (
                nombre_razon_social,
                domicilio,
                cuit_dni,
                condicion_iva,
                tiene_cuenta_corriente,
                activo
            )
            VALUES
            (
                $nombre,
                $domicilio,
                $cuitDni,
                $condicionIva,
                $cuentaCorriente,
                $activo
            );

            SELECT last_insert_rowid();
            """;

            comando.Parameters.AddWithValue(
                "$nombre",
                cliente.NombreRazonSocial);

            comando.Parameters.AddWithValue(
                "$domicilio",
                (object?)cliente.Domicilio ?? DBNull.Value);

            comando.Parameters.AddWithValue(
                "$cuitDni",
                cliente.CuitDni);

            comando.Parameters.AddWithValue(
                "$condicionIva",
                cliente.CondicionIva);

            comando.Parameters.AddWithValue(
                "$cuentaCorriente",
                cliente.TieneCuentaCorriente ? 1 : 0);

            comando.Parameters.AddWithValue(
                "$activo",
                cliente.Activo ? 1 : 0);

            object? resultado = comando.ExecuteScalar();

            return Convert.ToInt32(resultado);
        }

        public List<Cliente> ListarActivos()
        {
            List<Cliente> clientes = new();

            using SqliteConnection conexion = ConexionBD.CrearConexion();
            conexion.Open();

            using SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText =
            """
            SELECT
                id_cliente,
                nombre_razon_social,
                domicilio,
                cuit_dni,
                condicion_iva,
                tiene_cuenta_corriente,
                activo
            FROM cliente
            WHERE activo = 1
            ORDER BY nombre_razon_social;
            """;

            using SqliteDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cliente cliente = new()
                {
                    IdCliente = lector.GetInt32(0),
                    NombreRazonSocial = lector.GetString(1),
                    Domicilio = lector.IsDBNull(2)
                        ? null
                        : lector.GetString(2),
                    CuitDni = lector.GetString(3),
                    CondicionIva = lector.GetString(4),
                    TieneCuentaCorriente = lector.GetInt32(5) == 1,
                    Activo = lector.GetInt32(6) == 1
                };

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}