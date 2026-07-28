using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_CanjeDocumento : Conexion
    {
        public string Canjear(
            string idDocumentoOrigen,
            int idTipoDocumentoNuevo,
            DateTime fechaEmision,
            int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(conectar()))
            using (SqlCommand cmd = new SqlCommand(
                "Sp_Canjear_Nota_Venta", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@IdDocumentoOrigen", SqlDbType.Char, 11)
                    .Value = idDocumentoOrigen.Trim();
                cmd.Parameters.Add("@IdTipoDocumentoNuevo", SqlDbType.Int)
                    .Value = idTipoDocumentoNuevo;
                cmd.Parameters.Add("@FechaEmision", SqlDbType.DateTime)
                    .Value = fechaEmision;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int)
                    .Value = idUsuario;

                SqlParameter salida = cmd.Parameters.Add(
                    "@IdDocumentoNuevo", SqlDbType.VarChar, 11);
                salida.Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();
                return Convert.ToString(salida.Value).Trim();
            }
        }
    }
}
