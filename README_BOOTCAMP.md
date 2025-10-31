# Bootcamp .NET 8 + Enterprise – Ventus/CHUBB

Este paquete contiene prácticas de 7 días con foco en .NET 8, WCF (CoreWCF), Web API, EF Core, Docker, Azure DevOps, JWT, Serilog y Testing.

## Requisitos
- .NET SDK 8.0+
- SQL Server (local o remoto)
- Docker Desktop
- Git

## Pasos rápidos
1. Dia01_CSharpAvanzado: `dotnet run`
2. Dia02_WCF_Service: levantar `WcfHost` y luego ejecutar `WcfClientConsole`
3. Dia03_WebApi_EFCore: `dotnet run` y probar `/swagger`
4. Dia04_Docker_Azure: `docker build` y `docker run -p 8080:8080 webapidemo`
5. Dia05_Seguridad_JWT: probar `/api/auth/login` y luego `/api/auth/secure` con Bearer
6. Dia06_Logging_Testing: `dotnet test`
7. Dia07_Final_Documentacion: completa y ajusta README + checklist

## Notas
- Para WCF en .NET 8 se usa CoreWCF para hospedar servicios.
- Ajusta ConnectionStrings y secretos de JWT antes de producción.
