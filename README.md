# OBLIGATORIO-N3D-317501-331209

# 🚀 StellarMinds - Sistema de Gestión Astronómica

## 📌 Descripción del Proyecto

Este proyecto consiste en el desarrollo de un sistema para el observatorio astronómico **StellarMinds**, orientado a la gestión de socios, préstamos de equipos y planificación de observaciones astronómicas.

El sistema permitirá centralizar la operativa del club, facilitando tanto la administración interna como la experiencia de los socios, integrando además evaluaciones inteligentes mediante servicios de inteligencia artificial.

Este desarrollo se realiza en el marco del obligatorio de la materia **Diseño Web Asistido por IA** de ORT.

---

## 🧠 Objetivo

Diseñar una solución completa basada en **arquitectura en capas y principios de Clean Architecture**, que permita:

- Gestionar usuarios con distintos roles
- Administrar equipos astronómicos
- Controlar préstamos de equipos
- Planificar observaciones
- Evaluar la calidad de las observaciones mediante IA

---

## 🏗️ Arquitectura del Proyecto

El sistema se organiza en múltiples capas siguiendo buenas prácticas de diseño:

### 📦 Lógica de Negocio (`LogicaNegocio`)
- Contiene las entidades del dominio
- Define reglas de negocio
- Modela el comportamiento del sistema
- No depende de otras capas

---

### ⚙️ Lógica de Aplicación (`LogicaAplicacion`)
- Orquesta los casos de uso
- Coordina la interacción entre dominio e infraestructura
- Aplica validaciones y flujos del sistema

Depende de:
- `LogicaNegocio`
- `Infraestructura`

---

### 🏗️ Infraestructura (`Infraestructura`)
- Implementa la persistencia en base de datos
- Maneja acceso a datos y repositorios
- Integra servicios externos (ej: API de IA)
- Contiene implementaciones técnicas

Depende de:
- `LogicaNegocio`

---

### 🌐 Web (`Web`)
- Interfaz de usuario (MVC)
- Consumo de Web API
- Interacción con el usuario final

Depende de:
- `LogicaAplicacion`
- `LogicaNegocio`

---

## ⚙️ Tecnologías Utilizadas

- .NET (Web API + MVC)
- C#
- Entity Framework
- SQL Server
- LINQ
- Swagger (documentación de API)
- Consumo de APIs externas (IA - Gemini)

---

## 🔐 Roles del Sistema

El sistema contempla distintos tipos de usuarios:

- **Administrador**
- **Coordinador**
- **Socio**

Cada uno con permisos y funcionalidades específicas.

---

## 📋 Funcionalidades Previstas

### 🔑 Autenticación
- Login y Logout de usuarios
- Control de acceso por roles

---

### 👥 Gestión de Socios
- Alta de usuarios
- Asignación de roles

---

### 🔭 Gestión de Equipos
- CRUD de:
  - Telescopios
  - Monturas
  - Cámaras
  - Oculares

---

### 📦 Préstamos de Equipos
- Registro de préstamos
- Validación de disponibilidad
- Validación de compatibilidad entre equipos
- Devolución de equipos
- Auditoría de acciones

---

### 🌌 Observaciones Astronómicas
- Registro de observaciones
- Asociación con préstamos vigentes
- Selección de objetos celestes

---

### 🤖 Evaluación Inteligente (IA)
- Evaluación del equipo utilizado para una observación
- Clasificación:
  - IDEAL
  - ADECUADO
  - NO RECOMENDABLE
- Uso de servicio externo de IA (Gemini)

---

### 📊 Reportes y Consultas
- Préstamos por período
- Ranking de objetos observados
- Socios que utilizaron un telescopio específico
- Auditoría de préstamos

---

## 📡 API REST

El sistema expondrá endpoints REST para:

- Gestión de usuarios
- Gestión de equipos
- Préstamos
- Observaciones
- Consultas

Incluye documentación mediante **Swagger**.

---

## 🧪 Validaciones y Reglas de Negocio

El sistema contempla múltiples validaciones, entre ellas:

- Disponibilidad de equipos
- Compatibilidad entre telescopio y montura
- Reglas para astrofotografía
- Estados de préstamos
- Seguridad en credenciales

---

## 📂 Estructura del Proyecto

```
/Solution
 ├── LogicaNegocio
 ├── LogicaAplicacion
 ├── Infraestructura
 ├── Web
 └── WebAPI
```

---

## 📌 Estado del Proyecto

Este proyecto se encuentra en fase de **diseño y planificación**.

Actualmente:
- Se está definiendo la arquitectura
- Se están estableciendo las responsabilidades de cada capa
- No se han implementado funcionalidades aún

---

## 📖 Consideraciones

- El sistema seguirá principios SOLID
- Se aplicará Domain Driven Design (DDD)
- Se utilizarán ViewModels en la capa Web
- Se manejarán errores mediante excepciones
- Se priorizará código mantenible y escalable

---

## 👨‍💻 Autor

Fernando Arriondo
