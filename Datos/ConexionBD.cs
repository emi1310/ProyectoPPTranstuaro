using Microsoft.Data.Sqlite;

namespace Trastuaro_V2.Datos
{
    public static class ConexionBD
    {
        private static readonly string RutaBaseDatos =
            Path.Combine(AppContext.BaseDirectory, "TrastuaroV2.db");

        private static readonly string CadenaConexion =
            $"Data Source={RutaBaseDatos};Foreign Keys=True";

        public static SqliteConnection CrearConexion()
        {
            return new SqliteConnection(CadenaConexion);
        }

        public static string ObtenerRutaBaseDatos()
        {
            return RutaBaseDatos;
        }

        public static void Inicializar()
        {
            using SqliteConnection conexion = CrearConexion();
            conexion.Open();

            using SqliteCommand comando = conexion.CreateCommand();

            comando.CommandText =
            """
            CREATE TABLE IF NOT EXISTS cliente
            (
                id_cliente INTEGER PRIMARY KEY AUTOINCREMENT,
                nombre_razon_social TEXT NOT NULL,
                domicilio TEXT,
                cuit_dni TEXT NOT NULL,
                condicion_iva TEXT NOT NULL,
                tiene_cuenta_corriente INTEGER NOT NULL DEFAULT 0
                    CHECK (tiene_cuenta_corriente IN (0, 1)),
                activo INTEGER NOT NULL DEFAULT 1
                    CHECK (activo IN (0, 1))
            );

            CREATE TABLE IF NOT EXISTS remito
            (
                id_remito INTEGER PRIMARY KEY AUTOINCREMENT,
                numero_remito TEXT NOT NULL UNIQUE,
                fecha TEXT NOT NULL,
                id_cliente INTEGER NOT NULL,
                condicion_pago TEXT NOT NULL,
                estado TEXT NOT NULL DEFAULT 'Pendiente',
                total_flete NUMERIC NOT NULL DEFAULT 0
                    CHECK (total_flete >= 0),

                FOREIGN KEY (id_cliente)
                    REFERENCES cliente (id_cliente)
                    ON UPDATE CASCADE
                    ON DELETE RESTRICT
            );

            CREATE TABLE IF NOT EXISTS detalle_remito       
            (
                id_detalle_remito INTEGER PRIMARY KEY AUTOINCREMENT,
                id_remito INTEGER NOT NULL,
                cantidad_bultos INTEGER NOT NULL
                    CHECK (cantidad_bultos > 0),
                descripcion TEXT,
                proveedor_origen TEXT,
                numero_remito_origen TEXT,
                valor_declarado NUMERIC NOT NULL DEFAULT 0
                    CHECK (valor_declarado >= 0),
                importe_flete NUMERIC NOT NULL DEFAULT 0
                    CHECK (importe_flete >= 0),

                FOREIGN KEY (id_remito)
                    REFERENCES remito (id_remito)
                    ON UPDATE CASCADE
                    ON DELETE CASCADE
            );
            

                        CREATE TABLE IF NOT EXISTS liquidacion_mensual
            (
                id_liquidacion INTEGER PRIMARY KEY AUTOINCREMENT,
                id_cliente INTEGER NOT NULL,

                mes INTEGER
                    CHECK (mes IS NULL OR mes BETWEEN 1 AND 12),

                anio INTEGER
                    CHECK (anio IS NULL OR anio >= 2000),

                fecha_emision TEXT NOT NULL,

                total NUMERIC NOT NULL DEFAULT 0
                    CHECK (total >= 0),

                estado TEXT NOT NULL DEFAULT 'Abierta',

                tipo_liquidacion TEXT NOT NULL DEFAULT 'Mensual'
                    CHECK (tipo_liquidacion IN ('Mensual', 'Directa')),

                FOREIGN KEY (id_cliente)
                    REFERENCES cliente (id_cliente)
                    ON UPDATE CASCADE
                    ON DELETE RESTRICT
            );



            CREATE TABLE IF NOT EXISTS detalle_liquidacion
            (
                id_detalle_liquidacion INTEGER PRIMARY KEY AUTOINCREMENT,
                id_liquidacion INTEGER NOT NULL,
                id_remito INTEGER NOT NULL UNIQUE,
                importe NUMERIC NOT NULL
                    CHECK (importe >= 0),

                FOREIGN KEY (id_liquidacion)
                    REFERENCES liquidacion_mensual (id_liquidacion)
                    ON UPDATE CASCADE
                    ON DELETE CASCADE,

                FOREIGN KEY (id_remito)
                    REFERENCES remito (id_remito)
                    ON UPDATE CASCADE
                    ON DELETE RESTRICT
            );

            CREATE INDEX IF NOT EXISTS idx_remito_cliente
                ON remito (id_cliente);

            CREATE INDEX IF NOT EXISTS idx_detalle_remito
                ON detalle_remito (id_remito);

            CREATE INDEX IF NOT EXISTS idx_cliente_cuit_dni
                ON cliente (cuit_dni);

            CREATE INDEX IF NOT EXISTS idx_liquidacion_cliente_periodo
                ON liquidacion_mensual (id_cliente, anio, mes);

            CREATE UNIQUE INDEX IF NOT EXISTS ux_liquidacion_mensual_cliente_periodo
            ON liquidacion_mensual (id_cliente, anio, mes)
            WHERE tipo_liquidacion = 'Mensual';

            CREATE INDEX IF NOT EXISTS idx_detalle_liquidacion
                ON detalle_liquidacion (id_liquidacion);
            """;

            comando.ExecuteNonQuery();
            comando.CommandText =
"""
SELECT COUNT(*)
FROM pragma_table_info('liquidacion_mensual')
WHERE name = 'tipo_liquidacion';
""";

            int existeTipoLiquidacion =
                Convert.ToInt32(comando.ExecuteScalar());

            if (existeTipoLiquidacion == 0)
            {
                comando.CommandText =
                """
    ALTER TABLE liquidacion_mensual
    ADD COLUMN tipo_liquidacion TEXT NOT NULL DEFAULT 'Mensual';
    """;

                comando.ExecuteNonQuery();
            }
        }
    }
}