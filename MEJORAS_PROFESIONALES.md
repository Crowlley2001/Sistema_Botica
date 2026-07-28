# Sistema Botica Profesional 2.0

## Mejoras implementadas

- Conexión SQL configurable y portátil mediante `App.config`.
- Verificación automática de conexión y versión de base antes del login.
- Venta atómica: pedido, detalle, comprobante, caja, stock, Kardex y
  correlativos en una sola transacción.
- Compra atómica: cabecera, detalle, precios, stock, Kardex y correlativo en
  una sola transacción.
- Anulación atómica con devolución opcional de stock y restricción exclusiva
  para administradores.
- Canje atómico de nota de venta a factura o boleta sin duplicar caja ni stock.
- Soporte PEN/USD en ventas y compras con tipo de cambio por fecha.
- Cálculo correcto del IGV incluido en el precio.
- Validación de RUC para factura y documento del cliente en boletas mayores a
  S/ 700.
- QR con estructura de representación impresa SUNAT para factura y boleta.
- Rutas portátiles para QR y reportes; ya no dependen de `F:\PORTAFOLIO`.
- Vista previa automática y aislamiento de datos temporales por comprobante,
  evitando cruces de productos o QR entre cajas.
- Contraseñas de usuarios protegidas mediante PBKDF2, salt individual y
  migración automática de usuarios antiguos.
- Credenciales SOL y certificado protegidas con DPAPI de Windows.
- Auditoría de ventas, compras, anulaciones y administración de usuarios.
- Columnas monetarias migradas de `REAL` a `DECIMAL`.
- Registro local de errores no controlados.
- Instalador de migraciones con backup y verificación obligatorios.
- Pruebas rollback para venta, compra, anulación y canje.

## Estado de comprobantes electrónicos

El sistema genera numeración, datos fiscales y contenido QR para la
representación impresa. No debe presentarse como emisor electrónico completo
hasta configurar e implementar con datos reales:

- certificado digital vigente;
- generación y firma XML UBL;
- envío a SUNAT u OSE;
- recepción y almacenamiento del CDR;
- tratamiento de rechazos, bajas y resúmenes diarios.

Esta activación depende de credenciales, certificado y ambiente SUNAT del
contribuyente. El sistema conserva la configuración protegida para esa etapa.

## Compilación verificada

- Configuración Debug: 0 errores, 0 advertencias.
- Configuración Release: 0 errores, 0 advertencias.
- Scripts de migración y pruebas: sintaxis Transact-SQL validada.
- Instalador PowerShell: sintaxis validada.
- PBKDF2: clave correcta aceptada y clave incorrecta rechazada.
- DPAPI: cifrado y descifrado de credenciales verificados.
- QR SUNAT: formato, serie, número, importes, fecha y documento verificados.

Las migraciones 001 a 009 y las pruebas rollback de venta, compra, anulación
y canje fueron ejecutadas correctamente sobre `BDSISTEMA_BOTICA_PRUEBA`.
La migración 010 debe validarse de la misma forma antes de actualizar la base
de producción.
