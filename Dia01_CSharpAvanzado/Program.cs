using System.Net.Http;
using System.Linq;

// Demostraciones de C# moderno
Console.WriteLine("=== Dia01: C# Moderno ===");

// Datos de ejemplo (positional records)
var pedidos = new[]
{
    new Pedido("A", 150m),
    new Pedido("B", 90m),
    new Pedido("A", 60m)
};

// LINQ: GroupBy + proyección
var resumen = pedidos
    .GroupBy(p => p.Cliente)
    .Select(g => new ResultadoCliente(g.Key, g.Sum(x => x.Total)))
    .OrderByDescending(x => x.Suma);

foreach (var r in resumen)
{
    // Pattern matching en switch expression (rangos)
    var categoria = r.Suma switch
    {
        >= 200m => "Alto",
        >= 100m => "Medio",
        _ => "Bajo"
    };
    Console.WriteLine($"Cliente {r.Cliente} => {categoria} ({r.Suma})");
}

// Datos detallados usando records con propiedades init
var pedidosDetallados = new List<PedidoDetallado>
{
    new()
    {
        Cliente = "A",
        Lineas = new()
        {
            new() { Producto = "X", Cantidad = 2, PrecioUnitario = 50m },
            new() { Producto = "Y", Cantidad = 1, PrecioUnitario = 100m }
        }
    },
    new()
    {
        Cliente = "B",
        Lineas = new()
        {
            new() { Producto = "X", Cantidad = 1, PrecioUnitario = 50m }
        }
    },
    new()
    {
        Cliente = "A",
        Lineas = new()
        {
            new() { Producto = "Y", Cantidad = 1, PrecioUnitario = 100m }
        }
    }
};

Console.WriteLine("-- SelectMany + GroupBy (ventas por producto) --");

// LINQ: SelectMany para aplanar líneas de pedido
var lineas = pedidosDetallados
    .SelectMany(p => p.Lineas.Select(l => new
    {
        p.Cliente,
        l.Producto,
        l.Cantidad,
        Importe = l.Importe
    }));

var ventasPorProducto = lineas
    .GroupBy(x => x.Producto)
    .Select(g => new
    {
        Producto = g.Key,
        Cantidad = g.Sum(x => x.Cantidad),
        Recaudado = g.Sum(x => x.Importe)
    })
    .OrderByDescending(x => x.Recaudado);

foreach (var v in ventasPorProducto)
{
    Console.WriteLine($"Producto {v.Producto}: Cantidad={v.Cantidad}, Recaudado={v.Recaudado}");
}

Console.WriteLine("-- Property pattern (clasificación de pedidos) --");

// Pattern matching con property patterns sobre PedidoDetallado
foreach (var p in pedidosDetallados)
{
    var clasificacion = p switch
    {
        { Cliente: "A", Lineas: { Count: >= 2 } } => "Preferente (A con 2+ líneas)",
        { Lineas: { Count: 0 } } => "Sin líneas",
        { Lineas: { Count: 1 } } => "Unitario",
        _ => "Normal"
    };
    Console.WriteLine($"Pedido de {p.Cliente}: {clasificacion}");
}

Console.WriteLine("-- Aggregate (totales por cliente con acumulador) --");

// LINQ: Aggregate para acumular en un diccionario
var totalesPorCliente = lineas.Aggregate(new Dictionary<string, decimal>(), (acc, x) =>
{
    acc[x.Cliente] = acc.TryGetValue(x.Cliente, out var curr) ? curr + x.Importe : x.Importe;
    return acc;
});

foreach (var kvp in totalesPorCliente.OrderByDescending(k => k.Value))
{
    Console.WriteLine($"Cliente {kvp.Key}: Total={kvp.Value}");
}

// Ejemplo async/await con HttpClient
using var http = new HttpClient();
var resp = await http.GetAsync("https://httpbin.org/get");
Console.WriteLine($"HTTP status: {resp.StatusCode}");

// Tipos al final del archivo
public record Pedido(string Cliente, decimal Total);
public record ResultadoCliente(string Cliente, decimal Suma);

public record LineaPedido
{
    public required string Producto { get; init; }
    public required int Cantidad { get; init; }
    public required decimal PrecioUnitario { get; init; }
    public decimal Importe => Cantidad * PrecioUnitario;
}

public record PedidoDetallado
{
    public required string Cliente { get; init; }
    public required List<LineaPedido> Lineas { get; init; }
}
