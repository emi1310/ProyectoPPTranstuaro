using Microsoft.Data.Sqlite;
using Trastuaro_V2.Datos;
using Trastuaro_V2.Modelos;

namespace Trastuaro_V2.Repositories
{
    public class DetalleRemitoRepository
    {
        public int Agregar(DetalleRemito detalle)
        {
            using SqliteConnection conexion =
                ConexionBD.CrearConexion();

            conexion.Open();

            using SqliteCommand comando =
                conexion.CreateCommand();

            comando.CommandText =
            """
            INSERT INTO detalle_remito
            (
                id_remito,
                cantidad_bultos,
                descripcion,
                proveedor_origen,
                numero_remito_origen,
                valor_declarado,
                importe_flete
            )
            VALUES
            (
                $idRemito,
                $cantidadBultos,
                $descripcion,
                $proveedorOrigen,
                $numeroRemitoOrigen,
                $valorDeclarado,
                $importeFlete
            );

            SELECT last_insert_rowid();
            """;

            comando.Parameters.AddWithValue(
                "$idRemito",
                detalle.IdRemito);

            comando.Parameters.AddWithValue(
                "$cantidadBultos",
                detalle.CantidadBultos);

            comando.Parameters.AddWithValue(
                "$descripcion",
                (object?)detalle.Descripcion ?? DBNull.Value);

            comando.Parameters.AddWithValue(
                "$proveedorOrigen",
                (object?)detalle.ProveedorOrigen ?? DBNull.Value);

            comando.Parameters.AddWithValue(
                "$numeroRemitoOrigen",
                (object?)detalle.NumeroRemitoOrigen ?? DBNull.Value);

            comando.Parameters.AddWithValue(
                "$valorDeclarado",
                detalle.ValorDeclarado);

            comando.Parameters.AddWithValue(
                "$importeFlete",
                detalle.ImporteFlete);

            object? resultado = comando.ExecuteScalar();

            return Convert.ToInt32(resultado);
        }
    }
}