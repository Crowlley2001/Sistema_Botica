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
    public class CD_Producto_SinValor : Conexion
    {
        public static bool guardado = false;
        public void CD_Registrar_Producto_sinValor(string idprod, int idusu, string motivo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Prod_ventaPerdia", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idprod", idprod);
                cmd.Parameters.AddWithValue("@idusu", idusu);
                cmd.Parameters.AddWithValue("@motiviIngre", motivo);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                guardado = true;
            }
            catch (Exception ex)
            {
                guardado = false;

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error al Guardar: " + ex.Message,
                                "Capa Datos Proveedor",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        public DataTable CD_Cargar_Producto_sinVenta_porStock_deldia(DateTime dia)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_VerProducto_NoVendidos_pornoTenerStock", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechadia", dia);

                DataTable dato = new DataTable();

                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error al Guardar: " + ex.Message,
                                "Capa Datos Proveedor",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

            return null;
        }




        // por rangos:
        public DataTable CD_Cargar_Producto_sinVenta_porStock_porRango(DateTime dia1, DateTime dia2)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_VerProducto_NoVendidos_pornoTenerStock_porfechas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha1", dia1);
                da.SelectCommand.Parameters.AddWithValue("@fecha2", dia2);

                DataTable dato = new DataTable();

                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error al Guardar: " + ex.Message,
                                "Capa Datos Proveedor",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }

            return null;
        }
    }
}
