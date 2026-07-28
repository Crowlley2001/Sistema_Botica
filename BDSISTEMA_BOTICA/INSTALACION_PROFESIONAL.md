# Instalación segura de las mejoras

Estas instrucciones se aplican sobre una copia verificada de
`BDSISTEMA_BOTICA`. No pruebe primero sobre la base que usa la botica.

## Requisitos

- SQL Server 2019 o posterior.
- Usuario de Windows con permisos para realizar backup y modificar la base.
- `sqlcmd.exe` instalado.
- La aplicación debe permanecer cerrada durante la actualización.

## Procedimiento recomendado

1. Abra PowerShell como el mismo usuario autorizado en SQL Server.
2. Cree una copia aislada. El script se niega a sobrescribir bases:

```powershell
.\Crear_Copia_Prueba.ps1 -Servidor ".\SQLEXPRESS"
```

3. Aplique las mejoras únicamente a la copia:

```powershell
.\Instalar_Migraciones.ps1 -Servidor ".\SQLEXPRESS" `
    -BaseDatos "BDSISTEMA_BOTICA_PRUEBA" `
    -EjecutarPruebasRollback
```

El instalador realiza obligatoriamente un backup `COPY_ONLY` con checksum,
verifica que pueda leerse y recién entonces aplica las migraciones en orden.
Las pruebas incluidas trabajan dentro de transacciones y revierten sus datos.

## Migraciones

1. `001_Moneda_y_TipoCambio.sql`
2. `002_Venta_Atomica.sql`
3. `003_Compra_Atomica.sql`
4. `004_Anulacion_Venta_Atomica.sql`
5. `005_Seguridad_Usuarios.sql`
6. `006_Auditoria_Operaciones.sql`
7. `007_Precision_Monetaria.sql`
8. `008_Proteccion_Credenciales.sql`
9. `009_Canje_Documento_Atomico.sql`
10. `010_Reportes_Temporales_Portatiles.sql`

## Verificación funcional

Después de una instalación correcta:

- Inicie sesión con un usuario existente. Su contraseña antigua se migrará
  automáticamente al formato protegido.
- Abra caja y registre una venta pequeña en PEN.
- Registre una venta USD con tipo de cambio del día.
- Registre una compra de prueba y verifique stock y Kardex.
- Como administrador, anule la venta y confirme la devolución de stock.
- Revise `V_Auditoria_Operaciones`.
- Confirme que factura y boleta muestran la numeración y el QR esperados.

## Importante sobre SUNAT

El QR tiene la estructura requerida para la representación impresa, pero una
factura o boleta solo es electrónica oficialmente cuando existe XML UBL
firmado, envío a SUNAT/OSE y CDR aceptado. Esa integración requiere
certificado y credenciales reales del contribuyente.
