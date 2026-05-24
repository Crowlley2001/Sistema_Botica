using CapaEntidad;
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
    public class CD_Reporte_Kardex : Conexion
    {
        public static bool prod_saved = false;
        //----------------------------- METODO REGISTRAR PRODUCTO--------------------------------//
        public void CD_Registrar_Reporte(string idprod, string nombreprod, double stock, double compra_xstock, double precompra,double preventa, double venta_Xstock, double utilidad, double utilidad_xstock, string obs)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Temporal_ReportKardex", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idprod", idprod);
                cmd.Parameters.AddWithValue("@NombreProducto", nombreprod);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@preCompra", compra_xstock);
                cmd.Parameters.AddWithValue("@Comp_x_Stock", precompra);
                cmd.Parameters.AddWithValue("@PreVenta", preventa);
                cmd.Parameters.AddWithValue("@Venta_x_Stock", venta_Xstock);
                cmd.Parameters.AddWithValue("@Utilidad", utilidad);
                cmd.Parameters.AddWithValue("@Utili_x_Stock", utilidad_xstock);
                cmd.Parameters.AddWithValue("@obs", obs);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Producto se ha Registrado correctamente", "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                prod_saved = true;
            }
            catch (Exception ex)
            {
                prod_saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        public void CD_Eliminar_ReporteKardex()
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_Eliminar_Temporal_Kardex", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@idpro", idpro);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                
            }
            catch (Exception ex)
            {
              
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Baja del producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public DataTable CD_Listar_Todos_Temporal_Kardex()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Temporal_Kardex", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al mostrar datos: " + ex.Message, "Registro de Producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
    }
}
