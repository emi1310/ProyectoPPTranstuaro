using GestionRemitosTransporte.Datos;
using Microsoft.Data.Sqlite;

Console.WriteLine("PRUEBA DE CONEXIÓN A SQLITE");
Console.WriteLine("---------------------------");

Console.WriteLine("Ruta de la base de datos:");
Console.WriteLine(ConexionBD.ObtenerRutaBaseDatos());

Console.WriteLine();

using SqliteConnection conexion = ConexionBD.ObtenerConexion();

string consulta = @"
SELECT 
    idCliente,
    nombreRazonSocial,
    domicilio,
    cuitDni,
    condicionIVA,
    tieneCuentaCorriente,
    activo
FROM Clientes;
";

using SqliteCommand comando = new SqliteCommand(consulta, conexion);
using SqliteDataReader lector = comando.ExecuteReader();

Console.WriteLine("CLIENTES ENCONTRADOS");
Console.WriteLine("--------------------");

while (lector.Read())
{
    int idCliente = lector.GetInt32(0);
    string nombreRazonSocial = lector.GetString(1);
    string domicilio = lector.IsDBNull(2) ? "" : lector.GetString(2);
    string cuitDni = lector.IsDBNull(3) ? "" : lector.GetString(3);
    string condicionIVA = lector.IsDBNull(4) ? "" : lector.GetString(4);
    bool tieneCuentaCorriente = lector.GetInt32(5) == 1;
    bool activo = lector.GetInt32(6) == 1;

    Console.WriteLine($"ID: {idCliente}");
    Console.WriteLine($"Cliente: {nombreRazonSocial}");
    Console.WriteLine($"Domicilio: {domicilio}");
    Console.WriteLine($"CUIT/DNI: {cuitDni}");
    Console.WriteLine($"Condición IVA: {condicionIVA}");
    Console.WriteLine($"Cuenta corriente: {(tieneCuentaCorriente ? "Sí" : "No")}");
    Console.WriteLine($"Activo: {(activo ? "Sí" : "No")}");
    Console.WriteLine();
}

Console.WriteLine("Prueba finalizada.");
Console.WriteLine("Presione una tecla para cerrar...");
Console.ReadKey();
