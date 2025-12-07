# finance-control-backend
API Backend del proyecto Finance Control Pro. Contiene la lógica de negocio, servicios, controladores, autenticación, seguridad, reglas financieras, gestión de deudas, pagos, reportes y comunicación con la base de datos PostgreSQL.


# FinanceControlPro – Backend

Backend del proyecto FinanceControlPro, construido con .NET 8 y PostgreSQL.

---

##  Tecnologías utilizadas

- **.NET 8**
- **C#**
- **Entity Framework Core 8**
- **PostgreSQL**
- **AutoMapper**
- **Swagger / OpenAPI**
- Arquitectura por capas (API, Application, Domain, Infrastructure, Shared)

---

##  Requisitos para trabajar con el proyecto

Antes de correr o actualizar el backend, debes tener:

- **.NET SDK 8 instalado**
- **PostgreSQL instalado** 
- **Acceso a la cadena de conexión** (modificar `appsettings.json` si es necesario)

---

## Cómo correr el backend
Desde la carpeta raíz del proyecto, o desde la API:

dotnet run --project FinanceControlPro.API

## Cómo verificar que está corriendo bien
Una vez iniciado, abre en el navegador:

[text](http://localhost:5097/swagger)

## Notas
http://localhost:5097/swagger