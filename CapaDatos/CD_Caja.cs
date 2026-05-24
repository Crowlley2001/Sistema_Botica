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
    public class CD_Caja : Conexion
    {
        public static bool cajaSaved = false;

        //----------------------------------METODO REGISTRAR MOVIMIENTO EN CAJA------------------------------//
        public void CD_Registrar_Mov_Caja(Caja cja)
        {
            // Usamos 'using' para gestionar automáticamente el cierre y la liberación de recursos
            using (SqlConnection cn = new SqlConnection(conectar()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_registrar_Caja", cn);
                    cmd.CommandTimeout = 20;
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregando los parámetros desde el objeto 'cja'
                    cmd.Parameters.AddWithValue("@Fecha_Caja", cja.Fecha_Caja);
                    cmd.Parameters.AddWithValue("@Tipo_Caja", cja.Tipo_Caja);
                    cmd.Parameters.AddWithValue("@Concepto", cja.Concepto);
                    cmd.Parameters.AddWithValue("@De_Para", cja.De_Para);
                    cmd.Parameters.AddWithValue("@Nro_Doc", cja.Nro_Doc);
                    cmd.Parameters.AddWithValue("@ImporteCaja", cja.ImporteCaja);
                    cmd.Parameters.AddWithValue("@Id_Usu", cja.Id_Usu);
                    cmd.Parameters.AddWithValue("@TotalUti", cja.TotalUti);
                    cmd.Parameters.AddWithValue("@TipoPago", cja.TipoPago);
                    cmd.Parameters.AddWithValue("@GeneradoPor", cja.GeneradoPor);
                    cmd.Parameters.AddWithValue("@totaldescuento", cja.Total_Dscuentos);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    cajaSaved = true;
                }
                catch (Exception ex)
                {
                    cajaSaved = false;
                    if(cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    MessageBox.Show("Error al registrar el movimiento en caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        //----------------------------------METODO ACTUALIZAR TOTAL EN CAJA----------------------------------//
        public void CD_Actualizar_Total_Caja(string nroDoc, double total, double totalUtili, string tipoPago)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_Actualizar_Total_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregando parámetros para la actualización
                cmd.Parameters.AddWithValue("@Nro_doc", nroDoc);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@TotalUtilidad", totalUtili);
                cmd.Parameters.AddWithValue("@TipoPago", tipoPago);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                cajaSaved = true;
            }
            catch (Exception ex)
            {
                cajaSaved = false;

                // Verifica si la conexión quedó abierta para cerrarla
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //----------------------------------METODO LISTAR TODAS LAS CAJAS------------------------------------//
        public DataTable CD_Listar_Todas_Cajas()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Todas_Cajas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }


        //----------------------------------METODO LISTAR CAJAS DEL DIA--------------------------------------//
        public DataTable CD_listar_Cajas_DelDia(DateTime xdia)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_delDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@dia", xdia);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        //----------------------------------METODO LISTAR CAJAS DEL MES--------------------------------------//
        public DataTable CD_listar_Cajas_Delmes(DateTime xmes)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_del_Mes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechas", xmes);

                DataTable dato = new DataTable();
                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        //----------------------------METODO LISTAR CAJAS POR RANGO DE FECHAS--------------------------------//
        public DataTable CD_listar_Cajas_porRangoFecha(DateTime xdesde, DateTime hasta)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_porFechas", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@desde", xdesde);
                da.SelectCommand.Parameters.AddWithValue("@hasta", hasta);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }


        //----------------------METODO LISTAR CAJAS DEL MES POR TIPO DOCUMENTO-------------------------------//
        public DataTable CD_listar_Cajas_pormes_tipoDoc(DateTime xmes, string tipodoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Cajas_porMes_tipoDoc", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fechas", xmes);
                da.SelectCommand.Parameters.AddWithValue("@tipodoc", tipodoc);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }
            return null;
        }


        //----------------------------------METODO BUSCADOR GENERAL DE CAJAS---------------------------------//
        public DataTable CD_buscador_General_Cajas(String valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_MoviCaja_xValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xvalor", valor);
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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

        //---------------------------------METODO ANULAR MOVIMIENTO EN CAJA----------------------------------//
        public void CD_anular_Movimiento_Caja(string nroDoc, string estado)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("sp_Anular_movCaja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetro para identificar el documento a anular
                cmd.Parameters.AddWithValue("@NroDoc", nroDoc);
                cmd.Parameters.AddWithValue("@estadoCaja", estado);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                cajaSaved = true;
            }
            catch (Exception ex)
            {
                cajaSaved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //------------------------------METODO CAMBIAR MODO DE CIERRE DE CAJA--------------------------------//
        public void CD_CambiarModo_Caja(int idcaja)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                // Llama al procedimiento almacenado para cambiar el modo de cierre
                SqlCommand cmd = new SqlCommand("sp_cambiarModo_cierreCaja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                // Parámetro para identificar la caja específica
                cmd.Parameters.AddWithValue("@idcaja", idcaja);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                cajaSaved = true;
            }
            catch (Exception ex)
            {
                cajaSaved = false;

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //---------------------------METODO LISTAR GASTOS DEL DIA PARA REPORTE-------------------------------//
        public DataTable CD_listar_GastosdelDia_paraReporte(DateTime xdia)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                // Llama al procedimiento almacenado diseñado específicamente para el reporte de gastos
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_gastos_deldia_paraReporte", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@dia", xdia);

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
                MessageBox.Show("Error al Guardar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


    }
}
