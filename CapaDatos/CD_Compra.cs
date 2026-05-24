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
    public class CD_Compra : Conexion
    {
        public static bool saved = false;
        public void CD_Registrar_Compras(Documento_Compras pro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Compra", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCom", pro.Id_DocComp);
                cmd.Parameters.AddWithValue("@Nro_Fac_Fisico", pro.NroFac_Fisico);
                cmd.Parameters.AddWithValue("@SubTotal_Com", pro.SubTotal_ingre);
                cmd.Parameters.AddWithValue("@FechaIngre", pro.Fecha_Ingre);
                cmd.Parameters.AddWithValue("@TotalCompra", pro.Total_Ingre);
                cmd.Parameters.AddWithValue("@IdUsu", pro.id_Usu);
                cmd.Parameters.AddWithValue("@ModalidadPago", pro.ModalidadPago);
                cmd.Parameters.AddWithValue("@TiempoEspera", pro.TiempoEspera);
                cmd.Parameters.AddWithValue("@FechaVence", pro.Fecha_Vencimiento);
                cmd.Parameters.AddWithValue("@EstadoIngre", pro.Estado_Ingre);
                cmd.Parameters.AddWithValue("@Datos_Adicional", pro.Datos_Adicional);
                cmd.Parameters.AddWithValue("@Tipo_Doc_Compra", pro.TipoDoc_Compra);
                cmd.Parameters.AddWithValue("@Tiporegistro", pro.Tiporegistro);
                cmd.Parameters.AddWithValue("@LugarSalida", pro.LugarSalida);
                cmd.Parameters.AddWithValue("@TipoProceso", pro.TipoProceso);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                saved = true;
            }
            catch (Exception ex)
            {
                saved = false;
                if(cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al registrar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CD_Registrar_Detalle_Compras(Detalle_DocumentoCompra pro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_Detalle_ingreso", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_ingreso", pro.Id_DocComp);
                cmd.Parameters.AddWithValue("@Id_Pro", pro.Id_Pro);
                cmd.Parameters.AddWithValue("@Precio", pro.PrecioUnit);
                cmd.Parameters.AddWithValue("@Cantidad", pro.Cantidad);
                cmd.Parameters.AddWithValue("@Importe", pro.Importe);
                cmd.Parameters.AddWithValue("@preventa", pro.Preventa);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                saved = true;
            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al registrar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable CD_Buscar_CompraconDetalle(string idpro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_FacturasCompras_Detalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", idpro);
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


        public void CD_Eliminar_RegistrarCompra(string NroId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_Borrar_Factura_Ingresada", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Fac", NroId);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                saved = true;
            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al registrar la compra: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable CD_cargar_Todas_Compras()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();

                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Todas_Facturas_Compras", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable CD_buscar_Compras(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();

                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Gnral_deCompras", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", valor);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable CD_buscar_Compras_PorFecha(string tipo, DateTime fecha)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = conectar();

                SqlDataAdapter da = new SqlDataAdapter("Sp_Facturas_Ingresadas_alDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@tipo", tipo);
                da.SelectCommand.Parameters.AddWithValue("@fecha", fecha);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable CD_Listar_Comprobantes_Emitidos_Mes(DateTime fecha, int idTipo)
        {
            SqlConnection cn = new SqlConnection(conectar());
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Comprobantes_Emtidas_EnunMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", fecha);
                da.SelectCommand.Parameters.AddWithValue("@Docu", idTipo);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
                return null;
            }
        }

    }
}
