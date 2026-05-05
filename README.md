# TransporteArequipaAPI - Gestión de Flotas y Mantenimiento

API RESTful profesional diseñada para la gestión integral de activos en el sector transportes. El sistema permite el control en tiempo real de vehículos y conductores siguiendo estándares de **Arquitectura Limpia**.

## 🚀 Stack Tecnológico

*   **Lenguaje:** C#
*   **Framework:** .NET 8 / ASP.NET Core Web API
*   **ORM:** Entity Framework Core
*   **Base de Datos:** SQL Server
*   **Documentación:** Swagger / OpenAPI

## 🏗️ Características Técnicas

*   **Arquitectura:** Implementación de patrones de diseño para separar la lógica de negocio del acceso a datos.
*   **Gestión Asíncrona:** Uso intensivo de `async/await` para optimizar el rendimiento del servidor en peticiones concurrentes.
*   **Integridad de Datos:** Relaciones complejas manejadas mediante EF Core para asegurar la trazabilidad del mantenimiento preventivo.

## 🛠️ Endpoints Principales (Documentados en Swagger)

*   `GET /api/vehiculos`: Listado completo de la flota.
*   `POST /api/mantenimiento`: Registro de nuevas órdenes de servicio.
*   `PUT /api/conductores/{id}`: Actualización de estados y disponibilidad.

---
💻 *Desarrollado por Michael Lazaro Lujan - Ingeniero de Sistemas*

