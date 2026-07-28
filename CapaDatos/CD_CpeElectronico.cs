using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public sealed class CD_CpeElectronico : Conexion
    {
        public void Guardar(string idDocumento, CpeResultado resultado)
        {
            using (SqlConnection cn = new SqlConnection(conectar()))
            using (SqlCommand cmd = new SqlCommand(@"
MERGE dbo.CpeEnvio AS destino
USING (SELECT @IdDocumento AS IdDocumento) AS origen
ON destino.IdDocumento = origen.IdDocumento
WHEN MATCHED THEN UPDATE SET
    Ambiente = @Ambiente,
    EstadoCpe = @Estado,
    CodigoRespuesta = @Codigo,
    MensajeRespuesta = @Mensaje,
    HashCpe = @Hash,
    XmlGenerado = @Xml,
    CdrContenido = @Cdr,
    FechaProceso = @Fecha,
    Intentos = destino.Intentos + 1
WHEN NOT MATCHED THEN
    INSERT
    (
        IdDocumento, Ambiente, EstadoCpe, CodigoRespuesta,
        MensajeRespuesta, HashCpe, XmlGenerado, CdrContenido,
        FechaProceso, Intentos
    )
    VALUES
    (
        @IdDocumento, @Ambiente, @Estado, @Codigo,
        @Mensaje, @Hash, @Xml, @Cdr, @Fecha, 1
    );", cn))
            {
                cmd.Parameters.Add("@IdDocumento", SqlDbType.Char, 11).Value =
                    idDocumento.Trim();
                cmd.Parameters.Add("@Ambiente", SqlDbType.VarChar, 20).Value =
                    resultado.Ambiente;
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value =
                    resultado.Estado;
                cmd.Parameters.Add("@Codigo", SqlDbType.VarChar, 20).Value =
                    resultado.CodigoRespuesta;
                cmd.Parameters.Add("@Mensaje", SqlDbType.NVarChar, 500).Value =
                    resultado.Mensaje;
                cmd.Parameters.Add("@Hash", SqlDbType.VarChar, 88).Value =
                    resultado.Hash;
                cmd.Parameters.Add("@Xml", SqlDbType.NVarChar, -1).Value =
                    resultado.XmlGenerado;
                cmd.Parameters.Add("@Cdr", SqlDbType.NVarChar, -1).Value =
                    resultado.CdrContenido;
                cmd.Parameters.Add("@Fecha", SqlDbType.DateTime2).Value =
                    resultado.FechaProceso;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarEstados()
        {
            using (SqlConnection cn = new SqlConnection(conectar()))
            using (SqlDataAdapter da = new SqlDataAdapter(@"
SELECT RTRIM(IdDocumento) AS IdDocumento, Ambiente, EstadoCpe,
       CodigoRespuesta, MensajeRespuesta, HashCpe, FechaProceso
FROM dbo.CpeEnvio;", cn))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }

        public DataTable ListarCentro(string filtro, string estado)
        {
            using (SqlConnection cn = new SqlConnection(conectar()))
            using (SqlCommand cmd = new SqlCommand(@"
SELECT
    RTRIM(c.IdDocumento) AS Comprobante,
    td.Documento AS Tipo,
    d.Fecha_Emi AS FechaEmision,
    cli.Razon_Social_Nombres AS Cliente,
    d.ImporteMoneda AS Importe,
    d.CodigoMoneda AS Moneda,
    c.Ambiente,
    c.EstadoCpe,
    c.CodigoRespuesta,
    c.MensajeRespuesta,
    c.HashCpe,
    c.FechaProceso,
    c.Intentos
FROM dbo.CpeEnvio c
INNER JOIN dbo.Documento d ON d.id_Doc = c.IdDocumento
INNER JOIN dbo.Pedido p ON p.id_Ped = d.id_Ped
INNER JOIN dbo.Cliente cli ON cli.Id_Cliente = p.Id_Cliente
INNER JOIN dbo.Tipo_Doc td ON td.Id_Tipo = d.Id_Tipo
WHERE
    (@Estado = '' OR c.EstadoCpe = @Estado)
    AND
    (
        @Filtro = ''
        OR c.IdDocumento LIKE '%' + @Filtro + '%'
        OR cli.Razon_Social_Nombres LIKE '%' + @Filtro + '%'
        OR c.HashCpe LIKE '%' + @Filtro + '%'
    )
ORDER BY c.FechaProceso DESC;", cn))
            {
                cmd.Parameters.Add("@Filtro", SqlDbType.VarChar, 120).Value =
                    (filtro ?? string.Empty).Trim();
                cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 30).Value =
                    (estado ?? string.Empty).Trim();
                DataTable tabla = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(tabla);
                return tabla;
            }
        }

        public DataRow Obtener(string idDocumento)
        {
            using (SqlConnection cn = new SqlConnection(conectar()))
            using (SqlCommand cmd = new SqlCommand(@"
SELECT TOP (1)
    RTRIM(IdDocumento) AS IdDocumento, Ambiente, EstadoCpe,
    CodigoRespuesta, MensajeRespuesta, HashCpe, XmlGenerado,
    CdrContenido, FechaProceso, Intentos
FROM dbo.CpeEnvio
WHERE LTRIM(RTRIM(IdDocumento)) = LTRIM(RTRIM(@IdDocumento));", cn))
            {
                cmd.Parameters.Add("@IdDocumento", SqlDbType.Char, 11).Value =
                    (idDocumento ?? string.Empty).Trim();
                DataTable tabla = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    da.Fill(tabla);
                return tabla.Rows.Count == 0 ? null : tabla.Rows[0];
            }
        }
    }
}
