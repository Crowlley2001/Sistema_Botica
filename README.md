# Sistema de Gestión Integral - Botica Elicler & Salud

¡Bienvenido! Este es un sistema ERP de escritorio robusto y escalable diseñado específicamente para el control operativo, logístico y financiero de una farmacia/botica de mediana escala. 

El proyecto destaca por resolver problemas críticos del negocio farmacéutico mediante el uso de lógica analítica e interfaces personalizadas.

---

## 🛠️ Arquitectura y Tecnologías
El sistema está desarrollado bajo una **Arquitectura Desacoplada en N-Capas**, garantizando la separación de responsabilidades, mantenibilidad y escalabilidad del software:

* **CapaPresentacion:** Interfaz gráfica ágil construida en Windows Forms (.NET Framework), utilizando librerías estéticas de controles personalizados para el punto de venta.
* **CapaNegocio:** Centraliza las reglas del establecimiento, validaciones lógicas, políticas de stock y restricciones de seguridad.
* **CapaDatos:** Manejo y persistencia de datos mediante conexiones seguras y optimizadas hacia el motor de base de datos.
* **CapaEntidad:** Modelado de objetos del negocio que representan de forma fiel las tablas relacionales.

**Tecnologías Clave:**
* **Lenguaje:** C# (.NET)
* **Motor de Base de Datos:** SQL Server (Transact-SQL)
* **Control de Versiones:** Git & GitHub

---

## 🚀 Módulos Destacados del Sistema

### 📦 Gestión de Inventario y Almacén
* **Control por Kardex:** Registro minucioso y automatizado de entradas, salidas y traspasos entre almacenes secundarios.
* **Productos para Reposición:** Alertas automatizadas basadas en stock mínimo para optimizar la cadena de suministro.
* **Productos sin Rotación:** Analítica interna para mitigar mermas y pérdidas económicas por fechas de vencimiento próximas.

### 💰 Punto de Venta y Finanzas
* **Flujo de Caja Restrictivo:** Bloqueo de operaciones de venta si no existe una apertura de caja con saldo inicial previo.
* **Cierre y Arqueo de Caja:** Gestión de gastos diarios y otros ingresos para garantizar cuadres al centavo por turno.
* **Venta Perdida por Stock:** Registro estratégico de demandas insatisfechas para priorizar compras futuras.

### 🔐 Seguridad y Herramientas Administrativas
* **Privilegios por Rol:** Control de accesos modularizado para Administradores y Vendedores (restricción en la anulación de comprobantes).
* **Mantenimiento Nativo:** Herramientas integradas para realizar respaldos (Backup) e importación de la base de datos de manera directa.
