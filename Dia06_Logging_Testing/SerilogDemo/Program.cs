using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

Log.Information("Aplicación iniciada");
try
{
    Log.Debug("Ejecutando tarea...");
    Console.WriteLine("Hola desde SerilogDemo");
    Log.Information("Tarea completada");
}
catch (Exception ex)
{
    Log.Error(ex, "Error ejecutando la tarea");
}
finally
{
    Log.CloseAndFlush();
}
