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
    public class CD_Temporal : Conexion
    {


        //--------------------------- METODO REGISTRAR TEMPORAL----------------------------//
        public static bool temp_saved = false;
        public void CD_RegistrarTemporal(Temporal objTem)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insertar_Temporal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codTem", objTem.CodTem);
                cmd.Parameters.AddWithValue("@FechaEmi", objTem.FechaEmi);
                cmd.Parameters.AddWithValue("@cliente", objTem.Cliente);
                cmd.Parameters.AddWithValue("@Ruc", objTem.Ruc);
                cmd.Parameters.AddWithValue("@Direccion", objTem.Direccion);
                cmd.Parameters.AddWithValue("@SubTtal", objTem.SubTtal);
                cmd.Parameters.AddWithValue("@IgvT", objTem.IgvT);
                cmd.Parameters.AddWithValue("@TotalT", objTem.TotalT);
                cmd.Parameters.AddWithValue("@TotalDscto","0"); 
                cmd.Parameters.AddWithValue("@SonT", objTem.SonT);
                cmd.Parameters.AddWithValue("@vendedor", objTem.Vendedor);
                cmd.Parameters.AddWithValue("@CodigoQr", objTem.CodigoQr);
                cmd.Parameters.AddWithValue("@Tipocomprobante", objTem.Tipocomprobante);
                cmd.Parameters.AddWithValue("@HashCpe", objTem.HashCpe);
                cmd.Parameters.AddWithValue("@MotivoEmi", objTem.MotivoEmi);
                cmd.Parameters.AddWithValue("@TipoPago", objTem.TipoPago);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Producto se ha Registrado correctamente", "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                temp_saved = true;
            }
            catch (Exception ex)
            {
                temp_saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        //----------------------- METODO REGISTRAR DETALLE_TEMPORAL -------------------------//
        public void CD_DetalleTemporal(Detalle_Temporal objDet)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Det_Temporal", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codtem", objDet.CodTem);
                cmd.Parameters.AddWithValue("@CodProd", objDet.CodPro);
                cmd.Parameters.AddWithValue("@Cantidad", objDet.Cantidad);
                cmd.Parameters.AddWithValue("@Producto", objDet.Producto);
                cmd.Parameters.AddWithValue("@PreUnt", objDet.Pre_Unt);
                cmd.Parameters.AddWithValue("@Importe", objDet.ImporteT);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Producto se ha Registrado correctamente", "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                temp_saved = true;
            }
            catch (Exception ex)
            {
                temp_saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        //----------------------------- METODO ELIMINAR TEMPORAL--------------------------------//
        public static bool elminado_temp = false;
        public void CD_Eliminar_Temporal(string idtemp)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_Eliminar_Temporales", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idtempo", idtemp);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                elminado_temp = true;
            }
            catch (Exception ex)
            {
                elminado_temp = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Eliminación de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }





        //--------------------------- METODO BUSCAR TEMPORAL POR ID-----------------------------//
        public DataTable CD_Buscar_TemporalId(string idtemp)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Temporales", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id", idtemp);
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
