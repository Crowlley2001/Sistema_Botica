using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CD_TipoCambio : Conexion
    {
        //-------------------------- GUARDAR TIPO CAMBIO -----------------------------//
        public static void CD_Guardar_TipoCambio(DateTime fecha, double compra, double venta, int idUsu)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Guardar_TipoCambio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Fecha", fecha);
                cmd.Parameters.AddWithValue("@Compra", compra);
                cmd.Parameters.AddWithValue("@Venta", venta);
                cmd.Parameters.AddWithValue("@Id_Usu", idUsu);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar Tipo de Cambio: " + ex.Message);
            }
        }

        //-------------------------- BUSCAR POR FECHA -----------------------------//
        public static DataTable CD_Buscar_TipoCambio_Fecha(DateTime fecha)
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Buscar_TipoCambio_Fecha", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Fecha", fecha);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar Tipo de Cambio: " + ex.Message);
                return dt;
            }
        }


        public static DataTable CD_Listar_TipoCambio()
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Listar_TipoCambio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return dt;
            }
        }

        public static bool ExisteTipoCambio(DateTime fecha)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("SP_EXISTE_TIPO_CAMBIO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
                SqlParameter output = new SqlParameter("@Existe", SqlDbType.Bit);
                output.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(output);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return Convert.ToBoolean(output.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en ExisteTipoCambio: " + ex.Message);
                return false;
            }
        }

        public static DataTable ObtenerTipoCambioActual()
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("Sp_TipoCambio_Actual", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return dt;
            }
        }
    }
}
