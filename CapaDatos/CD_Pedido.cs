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
    public class CD_Pedido : Conexion
    {


        //----------------------------- METODO REGISTRAR PEDIDO ------------------------------//
        public static bool temp_saved = false;
        public static bool det_saved = false;
        public void CD_RegistrarPedido(Pedido objPed)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", objPed.Id_Ped);
                cmd.Parameters.AddWithValue("@Id_Cliente", objPed.Id_Cliente);
                cmd.Parameters.AddWithValue("@SubTotal", objPed.SubTotal);
                cmd.Parameters.AddWithValue("@IgvPed", objPed.IgvPed);
                cmd.Parameters.AddWithValue("@TotalPed", objPed.TotalPed);
                cmd.Parameters.AddWithValue("@id_Usu", objPed.Id_Usu);
                cmd.Parameters.AddWithValue("@TotalGancia", objPed.TotalGancia);
                cmd.Parameters.AddWithValue("@totaldscuento", objPed.Total_Dscuento);
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



        //------------------------- METODO REGISTRAR DETALLE_PEDIDO --------------------------//
        public void CD_DetallePedido(Detalle_Pedido objPed)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("sp_Registrar_detalle_Pedido", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", objPed.Id_Ped);
                cmd.Parameters.AddWithValue("@Id_Pro", objPed.Id_Pro);
                cmd.Parameters.AddWithValue("@Precio", objPed.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", objPed.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", objPed.Importe);
                cmd.Parameters.AddWithValue("@Utilidad_Unit", objPed.Utilidad_Unit);
                cmd.Parameters.AddWithValue("@TotalUtilidad", objPed.TotalUtilidad);
                cmd.Parameters.AddWithValue("@descuentoDet", objPed.DescuentoDet);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Producto se ha Registrado correctamente", "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                det_saved = true;
            }
            catch (Exception ex)
            {
                det_saved = true;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        //-------------------------- METODO ELIMINAR DETALLE_PEDIDO -----------------------------//
        public static bool elminado_temp = false;
        public void CD_Eliminar_DetallePedido(string idped)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_eliminar_detalle_Pedido", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Ped", idped);
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




        //------------------------ METODO BUSCAR PEDIDO POR ID PARA EDITAR ------------------------//
        public DataTable CD_Buscar_PedidoId(string idped)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Pedido_Para_Editar", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Ped", idped);
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




        //--------------------------- METODO ELIMINAR PEDIDO COMPLETO ------------------------------//
        public void CD_Eliminar_Pedido(string idped)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("Sp_Eliminar_Pedido_Completo", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idped);
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




        //----------------------------- METODO CAMBIAR ESTADO PEDIDO --------------------------------// 
        public void CD_Cambiar_EstadoPedido(string idped)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("Sp_Pedido_Atendido", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Ped", idped);
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


        //verificar:
        //1 referencia
        public bool CD_Verificar_siProducto_TieneVenta(string idprod, DateTime fecha)
        {
            bool respuesta = false;
            Int32 cant_registros = 0;
            SqlConnection cn = new SqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cn.ConnectionString = conectar();
                cmd.CommandText = "Sp_Verificar_siProducto_TieneVenta";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //parametros:
                cmd.Parameters.AddWithValue("@idprod", idprod);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                cn.Open();
                cant_registros = Convert.ToInt32(cmd.ExecuteScalar());

                if (cant_registros > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }

                cmd.Parameters.Clear();
                cmd.Dispose();
                cmd = null;
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                // Opcional: registrar el error ex.Message para depuración
            }
            return respuesta;
        }


    }
}
