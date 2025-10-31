# Día 5 — Seguridad JWT

Agrega autenticación JWT a una API .NET 8 con:
- Endpoint `POST /api/auth/login` que devuelva token.
- Endpoint `GET /api/auth/secure` protegido con `[Authorize]`.
- Configuración de `Jwt:Secret` en appsettings o user-secrets.
Incluye Swagger con soporte para Authorization: Bearer.

