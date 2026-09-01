using GestionRemitosTransporte.Modelos;

Cliente cliente = new Cliente(
    1,
    "Chiappa Cristian",
    "Miramar, Buenos Aires",
    "20-93245108-5",
    "Cuenta Corriente",
    true
);

Remito remito = new Remito(
    1,
    "0001-00020301",
    new DateTime(2026, 5, 23),
    cliente,
    "Cuenta Corriente",
    "Remito de prueba basado en comprobante manual."
);

DetalleRemito detalle1 = new DetalleRemito(
    1,
    2,
    "Bultos varios",
    "Vignolo",
    "0003-24773",
    868500m,
    21712m
);

DetalleRemito detalle2 = new DetalleRemito(
    2,
    15,
    "Bultos varios",
    "Hintercom",
    "0003-0024993",
    1114400m,
    17860m
);

DetalleRemito detalle3 = new DetalleRemito(
    3,
    6,
    "Bultos varios",
    "Exult",
    "0001-0016079",
    712318.93m,
    17808m
);

DetalleRemito detalle4 = new DetalleRemito(
    4,
    15,
    "Bultos varios",
    "Distelec",
    "0001-00012393",
    1800000m,
    15000m
);

remito.AgregarDetalle(detalle1);
remito.AgregarDetalle(detalle2);
remito.AgregarDetalle(detalle3);
remito.AgregarDetalle(detalle4);

remito.MarcarComoEntregado();

Console.WriteLine("SISTEMA DE GESTIÓN DE REMITOS");
Console.WriteLine("-----------------------------");
Console.WriteLine("Cliente: " + cliente.NombreRazonSocial);
Console.WriteLine("Remito Nº: " + remito.NumeroRemito);
Console.WriteLine("Fecha: " + remito.Fecha.ToShortDateString());
Console.WriteLine("Estado del remito: " + remito.Estado);
Console.WriteLine("Total flete del remito: $" + remito.TotalFlete);

Console.WriteLine();
Console.WriteLine("GENERACIÓN DE LIQUIDACIÓN MENSUAL");
Console.WriteLine("---------------------------------");

LiquidacionMensual liquidacion = new LiquidacionMensual(
    1,
    "LIQ-2026-05-0001",
    DateTime.Today,
    5,
    2026,
    cliente
);

liquidacion.AgregarRemito(remito);

Console.WriteLine("Liquidación Nº: " + liquidacion.NumeroLiquidacion);
Console.WriteLine("Cliente: " + liquidacion.Cliente.NombreRazonSocial);
Console.WriteLine("Mes facturado: " + liquidacion.MesFacturado + "/" + liquidacion.AnioFacturado);
Console.WriteLine("Estado liquidación: " + liquidacion.Estado);
Console.WriteLine("Subtotal: $" + liquidacion.Subtotal);
Console.WriteLine("IVA 21%: $" + liquidacion.Iva);
Console.WriteLine("Total: $" + liquidacion.Total);

Console.WriteLine();
Console.WriteLine("EMITIENDO LIQUIDACIÓN...");
liquidacion.EmitirLiquidacion();

Console.WriteLine("Estado liquidación: " + liquidacion.Estado);
Console.WriteLine("Estado remito: " + remito.Estado);

Console.WriteLine();
Console.WriteLine("Presione una tecla para finalizar...");
Console.ReadKey();
