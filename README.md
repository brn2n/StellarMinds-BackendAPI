# OBLIGATORIO-N3D-317501-331209

# [cite_start]StellarMinds - Sistema de Gestión Astronómica [cite: 26]

[cite_start]Sistema integral para la gestión de socios, préstamos de equipos astronómicos y planificación de sesiones de observación con asistencia de **IA (Google Gemini)**[cite: 26, 72]. [cite_start]Este proyecto fue desarrollado para la materia *Diseño Web Asistido por IA* de la Universidad ORT Uruguay[cite: 4].

## 🌌 Descripción del Problema
[cite_start]StellarMinds permite al observatorio astronómico gestionar de manera eficiente su inventario de equipos (telescopios, monturas, cámaras y oculares) y los préstamos realizados a sus socios[cite: 26, 29, 43, 45]. [cite_start]El sistema destaca por su capacidad de validar técnicamente si una configuración de equipo es apta para observar un objeto celeste específico mediante el análisis de parámetros ópticos a través de inteligencia artificial[cite: 61, 72].

## 🏗️ Arquitectura y Diseño
[cite_start]La solución se ha diseñado bajo los principios de **Arquitectura Limpia (Clean Architecture)** y **Domain-Driven Design (DDD)**, asegurando un bajo acoplamiento y alta cohesión[cite: 218].

### Estructura de la Solución
* **StellarMinds.LogicaNegocio:** El núcleo del sistema. [cite_start]Contiene las entidades de dominio, los **Value Objects** y las reglas de negocio fundamentales[cite: 189]. Es la capa más interna y no conoce a las demás.
* [cite_start]**StellarMinds.Infraestructura:** Encargada del acceso a datos mediante **Entity Framework 10** y de la persistencia en SQL Server[cite: 216]. Conoce a la Lógica de Negocio.
* **StellarMinds.LogicaAplicacion:** Actúa como mediadora, coordinando los servicios de aplicación. Conoce tanto a la Lógica de Negocio como a Infraestructura.
* [cite_start]**StellarMinds.WebApp:** Capa de presentación desarrollada en **ASP.NET Core MVC** que consume la Web API mediante `HttpClient`[cite: 209, 216].

## 🛠️ Tecnologías Utilizadas
* [cite_start]**.NET 10** y **C#** como lenguaje principal[cite: 216].
* [cite_start]**Entity Framework 10** con **LINQ** (sintaxis de método) para el acceso a datos[cite: 216, 217].
* [cite_start]**Web API REST-ful** documentada con **Swagger**[cite: 207, 208].
* [cite_start]**Google Gemini API** para la evaluación técnica de observaciones (RF07)[cite: 72, 159].
* [cite_start]**SQL Server** para el almacenamiento persistente[cite: 216].

## 🚀 Requerimientos Funcionales Destacados
* [cite_start]**Gestión de Préstamos:** Validación automática de carga útil de monturas y disponibilidad de stock[cite: 51, 53].
* [cite_start]**Evaluación con IA:** Integración con Gemini para calificar observaciones como IDEAL, ADECUADO o NO RECOMENDABLE[cite: 73].
* [cite_start]**Auditoría:** Registro automático de acciones de préstamos y devoluciones (RF06)[cite: 157, 158].
* [cite_start]**Ranking de Objetos:** Listado de los objetos celestes más observados por los socios (RF10)[cite: 179, 180].

## 📋 Instrucciones de Ejecución
1.  [cite_start]Clonar el repositorio dentro de la organización `Prog-DW-2026-1`[cite: 267, 268].
2.  Configurar la cadena de conexión en el archivo de configuración de la Web API.
3.  [cite_start]Ejecutar el script de SQL proporcionado para la **precarga de datos** (mínimo 10 registros por tabla)[cite: 261, 262].
4.  [cite_start]Configurar una API Key de Gemini válida para la funcionalidad de evaluación[cite: 132].
5.  [cite_start]Iniciar la solución ejecutando la Web API y la WebApp de forma independiente[cite: 210].

---
[cite_start]*Este proyecto cumple con las pautas de uso de IA Generativa establecidas por la cátedra[cite: 4].*
