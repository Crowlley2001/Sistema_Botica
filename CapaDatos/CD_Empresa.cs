using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Empresa : Conexion
    {
        public void EditarDatosEmpresa(string nombre, string ruc, string direccion, string correo,
                               string usuariosol, string clavesol, string clavecertificado, string obs)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conectar()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_EditarDatosEmpresa", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nombreRancho", nombre);
                        cmd.Parameters.AddWithValue("@nroRuc", ruc);
                        cmd.Parameters.AddWithValue("@Direccionran", direccion);
                        cmd.Parameters.AddWithValue("@correo", correo);
                        cmd.Parameters.AddWithValue("@usuariosol", usuariosol);
                        cmd.Parameters.Add("@clavesol", SqlDbType.VarChar, 1000).Value =
                            ProtectorSecretos.Proteger(clavesol);
                        cmd.Parameters.Add(
                            "@clavecertificado", SqlDbType.VarChar, 1000).Value =
                            ProtectorSecretos.Proteger(clavecertificado);
                        cmd.Parameters.AddWithValue("@obs", obs); // Guarda la ruta local o del servidor

                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar datos: " + ex.Message);
            }
        }


        public DataTable MostrarDatosEmpresa()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(conectar()))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter("select * from Miempresa", cn))
                    {
                        da.Fill(dt);
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0]["clavesol"] = ProtectorSecretos.Desproteger(
                        Convert.ToString(dt.Rows[0]["clavesol"]));
                    dt.Rows[0]["clavecertificado"] =
                        ProtectorSecretos.Desproteger(
                            Convert.ToString(dt.Rows[0]["clavecertificado"]));
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar datos de la empresa: " + ex.Message);
            }
        }
    }
}


