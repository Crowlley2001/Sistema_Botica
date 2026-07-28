using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaPresentacion
{
    internal static class VerificadorSistema
    {
        public static bool EsEntornoPruebas()
        {
            ConnectionStringSettings configuracion =
                ConfigurationManager.ConnectionStrings["BoticaDb"];
            if (configuracion == null)
                return false;

            SqlConnectionStringBuilder cadena =
                new SqlConnectionStringBuilder(configuracion.ConnectionString);
            return cadena.InitialCatalog.EndsWith(
                "_PRUEBA",
                StringComparison.OrdinalIgnoreCase);
        }

        public static string Verificar()
        {
            ConnectionStringSettings configuracion =
                ConfigurationManager.ConnectionStrings["BoticaDb"];
            if (configuracion == null ||
                String.IsNullOrWhiteSpace(configuracion.ConnectionString))
            {
                return "No está configurada la conexión BoticaDb.";
            }

            try
            {
                using (SqlConnection cn =
                    new SqlConnection(configuracion.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT Requisito
                    FROM
                    (
                        SELECT 'Migración 001: moneda' AS Requisito
                        WHERE COL_LENGTH('dbo.Documento', 'CodigoMoneda') IS NULL
                        UNION ALL
                        SELECT 'Migración 002: venta atómica'
                        WHERE OBJECT_ID(
                            'dbo.Sp_Registrar_Venta_Completa', 'P') IS NULL
                        UNION ALL
                        SELECT 'Migración 003: compra atómica'
                        WHERE OBJECT_ID(
                            'dbo.Sp_Registrar_Compra_Completa', 'P') IS NULL
                        UNION ALL
                        SELECT 'Migración 004: anulación atómica'
                        WHERE OBJECT_ID(
                            'dbo.Sp_Anular_Venta_Completa', 'P') IS NULL
                        UNION ALL
                        SELECT 'Migración 005: claves protegidas'
                        WHERE COL_LENGTH('dbo.Usuarios', 'PasswordHash') IS NULL
                        UNION ALL
                        SELECT 'Migración 006: auditoría'
                        WHERE OBJECT_ID(
                            'dbo.AuditoriaOperacion', 'U') IS NULL
                        UNION ALL
                        SELECT 'Migración 007: precisión monetaria'
                        WHERE EXISTS
                        (
                            SELECT 1
                            FROM sys.columns c
                            INNER JOIN sys.types t
                                ON t.user_type_id = c.user_type_id
                            WHERE c.object_id = OBJECT_ID('dbo.Productos')
                              AND c.name = 'Pre_venta'
                              AND t.name <> 'decimal'
                        )
                        UNION ALL
                        SELECT 'Migración 008: credenciales protegidas'
                        WHERE COL_LENGTH(
                            'dbo.Miempresa', 'AmbienteCpe') IS NULL
                        UNION ALL
                        SELECT 'Migración 009: canje atómico'
                        WHERE OBJECT_ID(
                            'dbo.Sp_Canjear_Nota_Venta', 'P') IS NULL
                    ) faltantes;", cn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 10;
                    cn.Open();

                    List<string> faltantes = new List<string>();
                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                            faltantes.Add(lector.GetString(0));
                    }

                    if (faltantes.Count > 0)
                    {
                        return "La base de datos necesita actualización:\n- " +
                            String.Join("\n- ", faltantes);
                    }
                }
            }
            catch (Exception ex)
            {
                return
                    "No se pudo conectar con BDSISTEMA_BOTICA.\n" +
                    "Revise SQL Server y la cadena BoticaDb.\n\n" +
                    ex.Message;
            }

            return null;
        }
    }
}
