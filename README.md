# StellarMinds - Sistema de Gestión Astronómica

Sistema integral para la gestión de socios, préstamos de equipos astronómicos y planificación de sesiones de observación con asistencia de IA (Groq). Este proyecto fue desarrollado para la materia Diseño Web asistido por IA de la Universidad ORT Uruguay.

---

## 🌌 Descripción del Problema

El observatorio "StellarMinds" requiere un sistema para gestionar sus socios, el inventario de equipos (telescopios, monturas, cámaras y oculares) y los préstamos asociados. El sistema destaca por validar técnicamente si una configuración de equipo es apta para observar un objeto celeste específico mediante el análisis de parámetros ópticos a través de la API de Groq.

---

## 🏗️ Arquitectura y Diseño

La solución sigue las recomendaciones de Arquitectura Limpia (Clean Architecture) y DDD (Domain Driven Design), aplicando los principios SOLID.

### Estructura de la Solución

- **StellarMinds.LogicaNegocio:** Núcleo del sistema con entidades de dominio, Value Objects y reglas de negocio. Es la capa más interna y no posee dependencias de las demás.
- **StellarMinds.Infraestructura:** Encargada del acceso a datos mediante Entity Framework 10 y la persistencia en SQL Server. Conoce a la Lógica de Negocio.
- **StellarMinds.LogicaAplicacion:** Coordina los servicios de aplicación y casos de uso. Conoce tanto a la Lógica de Negocio como a Infraestructura.

---

## 🛠️ Tecnologías Utilizadas

- **.NET 10** y **C#** como lenguaje principal.
- **Entity Framework 10** con **LINQ** (sintaxis de método) para consultas.
- **Web API REST-ful** documentada con Postman.
- **Groq API** para la evaluación de adecuación de equipos (RF07).
- **SQL Server** para el almacenamiento de datos.

---

## 🚀 Requerimientos Funcionales Destacados

- **Gestión de Préstamos:** Validación de carga útil (peso) y compatibilidad de monturas (ecuatorial/híbrida para astrofotografía).
- **Evaluación con IA:** Clasificación de observaciones como **IDEAL**, **ADECUADO** o **NO RECOMENDABLE** según la óptica del equipo y el objeto celeste.
- **Auditoría:** Registro automático de altas y devoluciones de préstamos indicando fecha y usuario.
- **Ranking de Objetos:** Listado ordenado de los objetos celestes más observados por los socios.
