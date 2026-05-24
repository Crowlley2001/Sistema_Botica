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
    public class CD_Kardex : Conexion
    {
        public static bool kar_saved = false;
        public static bool det_saved = false;
        //----------------------------- METODO REGISTRAR KARDEX--------------------------------//
        public void RegistrarKardex(string idkardx, string idproducto)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("sp_crear_kardex", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idkardex", idkardx);
                cmd.Parameters.AddWithValue("@idprod", idproducto);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Kardex se ha guardado exitosamente: ", "CD - Registro de Kardex", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kar_saved = true;
            }
            catch (Exception ex)
            {
                kar_saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Erro al guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        //----------------------------- METODO REGISTRAR DETALLEKARDEX--------------------------------//
        public void Registrar_DetalleKardex(Detalle_Kardex kr)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_detalle_kardex", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Krdx", kr.IdKardex);
                cmd.Parameters.AddWithValue("@Item", kr.Item);
                cmd.Parameters.AddWithValue("@Doc_Soport", kr.Doc_soporte);
                cmd.Parameters.AddWithValue("@Det_Operacion", kr.Det_Operacion);
                cmd.Parameters.AddWithValue("@Cantidad_In", kr.Cantidad_In);
                cmd.Parameters.AddWithValue("@Precio_Unt_In", kr.Precio_In);
                cmd.Parameters.AddWithValue("@Costo_Total_In", kr.Total_In);
                cmd.Parameters.AddWithValue("@Cantidad_Out", kr.Cantidad_Out);
                cmd.Parameters.AddWithValue("@Precio_Unt_Out", kr.Precio_Out);
                cmd.Parameters.AddWithValue("@Importe_Total_Out", kr.Total_Out);
                cmd.Parameters.AddWithValue("@Cantidad_Saldo", kr.Cantidad_saldo);
                cmd.Parameters.AddWithValue("@Promedio", kr.Promedio);
                cmd.Parameters.AddWithValue("@Costo_Total_Saldo", kr.Total_saldo);
                cmd.Parameters.AddWithValue("@id_usu", kr.Idusu);
                cmd.Parameters.AddWithValue("@Tipo_operacion", kr.Tipo_operacion);
                cmd.Parameters.AddWithValue("@Cant_Difncial", kr.Cant_diferencial);
                cmd.Parameters.AddWithValue("@ImportDiferen", kr.ImporteDiferente);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Kardex se ha guardado exitosamente: ", "Registro de Kardex", MessageBoxButtons.OK, MessageBoxIcon.Information);
                det_saved = true;
            }
            catch (Exception ex)
            {
                det_saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //-----------------------------VALIDAR SI PRODUCTO YA TIENE KARDEX--------------------------------//
        public bool Verificar_Producto_Kardex(string idproducto)
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cn.ConnectionString = conectar();
                cmd = new SqlCommand("Sp_Ver_sihay_Kardex");
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Prod", idproducto);
                cn.Open();
                getvalue = Convert.ToInt32(cmd.ExecuteScalar());
                if (getvalue > 0)
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
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al validar: " + ex.Message, "Capa Datos Kardex", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }
            return respuesta;
        }

        //----------------------------- METODO BUSCAR KARDEX POR VALOR--------------------------------//
        public DataTable CD_Buscar_KARDEXVALOR(string idkar)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_DeKardex_Principal_yDetalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", idkar);
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



        public DataTable CD_Buscar_DetallesKardex_PorDia(DateTime dia)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Ver_Kardex_delDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha", dia);
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




        public DataTable CD_Listar_Productos_SinStock_porVenta(DateTime dia)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Productos_sinSTock_DespuesdeVenta", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fechadia", dia);
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




        public DataTable CD_Listar_Productos_QueTuvieron_ajusteInver(DateTime dia , DateTime hasta , string tipo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Productoskardex_porTipoOpera_fecha", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@desde", dia);
                da.SelectCommand.Parameters.AddWithValue("@hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@tipoOpera", tipo);
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
