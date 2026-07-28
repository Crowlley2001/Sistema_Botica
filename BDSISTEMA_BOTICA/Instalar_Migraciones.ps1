[CmdletBinding()]
param(
    [string]$Servidor = ".\SQLEXPRESS",
    [string]$BaseDatos = "BDSISTEMA_BOTICA",
    [switch]$EjecutarPruebasRollback
)

$ErrorActionPreference = "Stop"

$sqlcmd = Get-Command "sqlcmd.exe" -ErrorAction Stop
$directorioMigraciones = Join-Path $PSScriptRoot "Migraciones"
$directorioPruebas = Join-Path $PSScriptRoot "Pruebas"

function Invoke-SqlArchivo {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Ruta
    )

    Write-Host ("Ejecutando: " + (Split-Path $Ruta -Leaf))
    & $sqlcmd.Source `
        -S $Servidor `
        -E `
        -C `
        -b `
        -d master `
        -v "BaseDatos=$BaseDatos" `
        -i $Ruta

    if ($LASTEXITCODE -ne 0) {
        throw "SQL Server rechazó el archivo: $Ruta"
    }
}

Write-Host "Verificando conexión con $Servidor..."
& $sqlcmd.Source `
    -S $Servidor `
    -E `
    -C `
    -b `
    -d master `
    -Q "SET NOCOUNT ON; SELECT @@SERVERNAME AS Servidor;"

if ($LASTEXITCODE -ne 0) {
    throw "No fue posible conectar con SQL Server."
}

$baseEscapada = $BaseDatos.Replace("]", "]]")
$consultaBackup = @"
IF DB_ID(N'$($BaseDatos.Replace("'", "''"))') IS NULL
    THROW 56001, 'La base de datos indicada no existe.', 1;

DECLARE @Directorio NVARCHAR(4000) =
    CONVERT(NVARCHAR(4000), SERVERPROPERTY('InstanceDefaultBackupPath'));
DECLARE @Archivo NVARCHAR(4000);

IF NULLIF(@Directorio, '') IS NULL
    THROW 56002, 'SQL Server no informó su directorio predeterminado de backup.', 1;

IF RIGHT(@Directorio, 1) NOT IN ('\', '/')
    SET @Directorio += '\';

SET @Archivo =
    @Directorio +
    N'$($BaseDatos.Replace("'", "''"))_antes_migracion_' +
    REPLACE(REPLACE(CONVERT(VARCHAR(19), GETDATE(), 120), ':', ''), ' ', '_') +
    N'.bak';

BACKUP DATABASE [$baseEscapada]
TO DISK = @Archivo
WITH COPY_ONLY, CHECKSUM, INIT, STATS = 10;

RESTORE VERIFYONLY FROM DISK = @Archivo WITH CHECKSUM;
SELECT @Archivo AS BackupVerificado;
"@

Write-Host "Creando y verificando backup obligatorio..."
& $sqlcmd.Source `
    -S $Servidor `
    -E `
    -C `
    -b `
    -d master `
    -Q $consultaBackup

if ($LASTEXITCODE -ne 0) {
    throw "El backup no pudo crearse o verificarse. No se aplicaron migraciones."
}

$migraciones = Get-ChildItem $directorioMigraciones -Filter "*.sql" |
    Sort-Object Name

if ($migraciones.Count -eq 0) {
    throw "No se encontraron migraciones."
}

foreach ($migracion in $migraciones) {
    Invoke-SqlArchivo -Ruta $migracion.FullName
}

if ($EjecutarPruebasRollback) {
    Write-Host "Ejecutando pruebas que revierten sus propios datos..."
    $pruebas = Get-ChildItem $directorioPruebas -Filter "*.sql" |
        Sort-Object Name
    foreach ($prueba in $pruebas) {
        Invoke-SqlArchivo -Ruta $prueba.FullName
    }
}

Write-Host "Migraciones aplicadas correctamente." -ForegroundColor Green
