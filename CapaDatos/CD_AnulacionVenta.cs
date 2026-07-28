using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_AnulacionVenta : Conexion
    {
        public void Anular(string idDocumento, bool devolverStock, int idUsuario)
        {
            using (SqlConnection cn = new SqlConnection(conectar()))
            using (SqlCommand cmd = new SqlCommand("Sp_Anular_Venta_Completa", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30;
                cmd.Parameters.Add("@IdDocumento", SqlDbType.Char, 11).Value =
                    idDocumento.Trim();
                cmd.Parameters.Add("@DevolverStock", SqlDbType.Bit).Value =
                    devolverStock;
                cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = idUsuario;

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
