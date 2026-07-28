[CmdletBinding()]
param(
    [string]$Servidor = ".\SQLEXPRESS",
    [string]$BaseOrigen = "BDSISTEMA_BOTICA",
    [string]$BasePrueba = "BDSISTEMA_BOTICA_PRUEBA"
)

$ErrorActionPreference = "Stop"

if ($BaseOrigen -eq $BasePrueba) {
    throw "La base de prueba no puede tener el mismo nombre que la original."
}

if (-not $BasePrueba.EndsWith("_PRUEBA", [StringComparison]::OrdinalIgnoreCase)) {
    throw "Por seguridad, el nombre de la copia debe terminar en _PRUEBA."
}

$sqlcmd = Get-Command "sqlcmd.exe" -ErrorAction Stop
$origenLiteral = $BaseOrigen.Replace("'", "''")
$pruebaLiteral = $BasePrueba.Replace("'", "''")
$origenIdentificador = $BaseOrigen.Replace("]", "]]")
$pruebaIdentificador = $BasePrueba.Replace("]", "]]")

$consulta = @"
SET NOCOUNT ON;
SET XACT_ABORT ON;

IF DB_ID(N'$origenLiteral') IS NULL
    THROW 59001, 'La base de datos original no existe.', 1;

IF DB_ID(N'$pruebaLiteral') IS NOT NULL
    THROW 59002, 'La base de prueba ya existe. El script no sobrescribirá ninguna base.', 1;

DECLARE @CantidadDatos INT;
DECLARE @CantidadLogs INT;
DECLARE @LogicoDatos SYSNAME;
DECLARE @LogicoLog SYSNAME;
DECLARE @DirectorioBackup NVARCHAR(4000);
DECLARE @DirectorioDatos NVARCHAR(4000);
DECLARE @DirectorioLog NVARCHAR(4000);
DECLARE @ArchivoBackup NVARCHAR(4000);
DECLARE @ArchivoDatos NVARCHAR(4000);
DECLARE @ArchivoLog NVARCHAR(4000);
DECLARE @Sql NVARCHAR(MAX);

SELECT @CantidadDatos = COUNT(*)
FROM sys.master_files
WHERE database_id = DB_ID(N'$origenLiteral') AND type = 0;

SELECT @CantidadLogs = COUNT(*)
FROM sys.master_files
WHERE database_id = DB_ID(N'$origenLiteral') AND type = 1;

IF @CantidadDatos <> 1 OR @CantidadLogs <> 1
    THROW 59003, 'La base tiene una distribución de archivos no compatible con el creador automático.', 1;

SELECT @LogicoDatos = name
FROM sys.master_files
WHERE database_id = DB_ID(N'$origenLiteral') AND type = 0;

SELECT @LogicoLog = name
FROM sys.master_files
WHERE database_id = DB_ID(N'$origenLiteral') AND type = 1;

SET @DirectorioBackup =
    CONVERT(NVARCHAR(4000), SERVERPROPERTY('InstanceDefaultBackupPath'));
SET @DirectorioDatos =
    CONVERT(NVARCHAR(4000), SERVERPROPERTY('InstanceDefaultDataPath'));
SET @DirectorioLog =
    CONVERT(NVARCHAR(4000), SERVERPROPERTY('InstanceDefaultLogPath'));

IF NULLIF(@DirectorioBackup, '') IS NULL OR
   NULLIF(@DirectorioDatos, '') IS NULL OR
   NULLIF(@DirectorioLog, '') IS NULL
    THROW 59004, 'SQL Server no informó sus directorios predeterminados.', 1;

IF RIGHT(@DirectorioBackup, 1) NOT IN ('\', '/')
    SET @DirectorioBackup += '\';
IF RIGHT(@DirectorioDatos, 1) NOT IN ('\', '/')
    SET @DirectorioDatos += '\';
IF RIGHT(@DirectorioLog, 1) NOT IN ('\', '/')
    SET @DirectorioLog += '\';

SET @ArchivoBackup = @DirectorioBackup + N'$origenLiteral' +
    N'_copia_para_pruebas_' +
    REPLACE(REPLACE(CONVERT(VARCHAR(19), GETDATE(), 120), ':', ''), ' ', '_') +
    N'.bak';
SET @ArchivoDatos = @DirectorioDatos + N'$pruebaLiteral.mdf';
SET @ArchivoLog = @DirectorioLog + N'$pruebaLiteral' + N'_log.ldf';

BACKUP DATABASE [$origenIdentificador]
TO DISK = @ArchivoBackup
WITH COPY_ONLY, CHECKSUM, INIT, STATS = 10;

RESTORE VERIFYONLY FROM DISK = @ArchivoBackup WITH CHECKSUM;

SET @Sql =
    N'RESTORE DATABASE [$pruebaIdentificador] FROM DISK = ' +
    QUOTENAME(@ArchivoBackup, '''') +
    N' WITH MOVE ' + QUOTENAME(@LogicoDatos, '''') +
    N' TO ' + QUOTENAME(@ArchivoDatos, '''') +
    N', MOVE ' + QUOTENAME(@LogicoLog, '''') +
    N' TO ' + QUOTENAME(@ArchivoLog, '''') + N', ' +
    N'RECOVERY, CHECKSUM, STATS = 10;';

EXEC sys.sp_executesql @Sql;

ALTER DATABASE [$pruebaIdentificador] SET RECOVERY SIMPLE;
ALTER DATABASE [$pruebaIdentificador] SET TRUSTWORTHY OFF;

SELECT
    N'$pruebaLiteral' AS BasePruebaCreada,
    @ArchivoBackup AS BackupOrigenVerificado;
"@

Write-Host "Creando una copia aislada de $BaseOrigen..."
& $sqlcmd.Source `
    -S $Servidor `
    -E `
    -C `
    -b `
    -d master `
    -Q $consulta

if ($LASTEXITCODE -ne 0) {
    throw "No se pudo crear la copia de prueba. La base original no fue modificada."
}

Write-Host "Copia de prueba creada correctamente: $BasePrueba" `
    -ForegroundColor Green
