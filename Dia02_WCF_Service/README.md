WCF (CoreWCF) - Día 2

Solución con 3 proyectos para exponer un servicio CoreWCF y un cliente .NET 8 que lo consume.

- `ServiceLibrary` (CoreWCF): interfaz `IHelloService` y clase `HelloService`.
- `WcfHost` (ASP.NET Core): hostea CoreWCF con endpoint `basicHttpBinding` en `/HelloService.svc`.
- `WcfClientConsole` (.NET 8): cliente de consola que consume el servicio y muestra la respuesta.

Requisitos:
- .NET SDK 8 instalado
- Acceso a NuGet para restaurar paquetes (CoreWCF y System.ServiceModel)

Cómo ejecutar:
1) Restaurar dependencias (una sola vez por solución):
   - `dotnet restore`

2) Iniciar el host (terminal 1):
   - `dotnet run --project WcfHost`
   - El servicio quedará disponible en `http://localhost:5000/HelloService.svc`
   - WSDL: `http://localhost:5000/HelloService.svc?wsdl`

3) Ejecutar el cliente (terminal 2):
   - `dotnet run --project WcfClientConsole`
   - Deberías ver en consola: `Hola Paul, desde CoreWCF en .NET 8`

Notas:
- La solución es `Dia02_WCF_Service.sln` e incluye los tres proyectos.
- `WcfHost` referencia `ServiceLibrary` y publica el endpoint con `BasicHttpBinding`.
- El cliente define su propia interfaz con atributos `System.ServiceModel` compatibles con SOAP para consumir el servicio.
