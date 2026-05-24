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
    public class CD_CierreCaja : Conexion
    {
        public static bool saved = false;

        //------------------------------------- MÉTODO PARA REGISTRAR EL INICIO DE CAJA ------------------------------------------//
        public void CD_Registrar_Inicio_Caja(Cierre_Caja obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Reg_Cierre_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCierre", obj.Id_cierre);
                cmd.Parameters.AddWithValue("@Apertura_Caja", obj.Apertura_Caja);
                cmd.Parameters.AddWithValue("@Total_Ingreso", obj.Total_Ingreso);
                cmd.Parameters.AddWithValue("@TotalEgreso", obj.TotalEgreso);
                cmd.Parameters.AddWithValue("@Id_usu", obj.Id_Usu);
                cmd.Parameters.AddWithValue("@TodoDeposito", obj.TodoDeposito);
                cmd.Parameters.AddWithValue("@TotalGanancia", obj.Gananciadeldia);
                cmd.Parameters.AddWithValue("@TotalEntregado", obj.TotalEntregado);
                cmd.Parameters.AddWithValue("@SaldoSiguiente", obj.SaldoSiguiente);
                cmd.Parameters.AddWithValue("@TotalFactura", obj.TotalFactura);
                cmd.Parameters.AddWithValue("@TotalBoleta", obj.TotalBoleta);
                cmd.Parameters.AddWithValue("@Totalnota", obj.TotalNotaVenta);
                cmd.Parameters.AddWithValue("@TotalCreditoCobrado", obj.TotalCreditoCobrado);
                cmd.Parameters.AddWithValue("@TotalCreditoEmitido", obj.TotalCreditoEmitido);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();  
                saved = true;
            }
            catch (Exception ex) 
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al registrar el cierre de caja: " + ex.Message,"Capa Datos Proveedor",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //------------------------------------- MÉTODO PARA REGISTRAR EL CIERRE DE CAJA ------------------------------------------//
        public void CD_Registrar_Cierre_Caja(Cierre_Caja obj)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("sp_Actualizar_Cierre_Caja", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCIERRE", obj.Id_cierre);
                cmd.Parameters.AddWithValue("@Apertura_Caja", obj.Apertura_Caja);
                cmd.Parameters.AddWithValue("@Total_Ingreso", obj.Total_Ingreso);
                cmd.Parameters.AddWithValue("@TotalEgreso", obj.TotalEgreso);
                cmd.Parameters.AddWithValue("@Id_usu", obj.Id_Usu);
                cmd.Parameters.AddWithValue("@TodoDeposito", obj.TodoDeposito);
                cmd.Parameters.AddWithValue("@TotalGanancia", obj.Gananciadeldia);
                cmd.Parameters.AddWithValue("@TotalEntregado", obj.TotalEntregado);
                cmd.Parameters.AddWithValue("@SaldoSiguiente", obj.SaldoSiguiente);
                cmd.Parameters.AddWithValue("@TotalFactura", obj.TotalFactura);
                cmd.Parameters.AddWithValue("@TotalBoleta", obj.TotalBoleta);
                cmd.Parameters.AddWithValue("@Totalnota", obj.TotalNotaVenta);
                cmd.Parameters.AddWithValue("@TotalCreditoCobrado", obj.TotalCreditoCobrado);
                cmd.Parameters.AddWithValue("@TotalCreditoEmitido", obj.TotalCreditoEmitido);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                saved = true;
            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al registrar el cierre de caja: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //------------------------------------- MÉTODO PARA LISTAR CIERRES DE CAJA DEL DÍA ------------------------------------------//
        public DataTable CD_Listar_Cierre_Caja_DelDia(DateTime xdia, string estadocierre)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_delDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xdia", xdia);
                da.SelectCommand.Parameters.AddWithValue("@estadocierre", estadocierre);

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


        //------------------------------------- MÉTODO PARA LISTAR CIERRE DE CAJA POR ID ------------------------------------------//
        public DataTable CD_Listar_Cierre_Caja_porID(string idcierre)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar(); 
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_porId", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idcierre", idcierre);
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
                MessageBox.Show("Error al Cargar Cierre: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        //------------------------------------- MÉTODO PARA LISTAR TODOS LOS CIERRES DE CAJA ------------------------------------------//
        public DataTable CD_Listar_Todo_cierres()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_todos_cierresCaja", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dato = new DataTable();
                da.Fill(dato);
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error al Cargar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }



        //------------------------------------- MÉTODO PARA LISTAR CIERRE DE CAJA POR USUARIO ------------------------------------------//
        public DataTable CD_Listar_Cierre_Caja_porUsuario(int idusu)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_porUsuario", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Usu", idusu);
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
                MessageBox.Show("Error al Cargar: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }


        //------------------------------------- MÉTODO PARA LISTAR CIERRE DE CAJA POR USUARIO Y MES ------------------------------------------//
        public DataTable CD_Listar_Cierre_Caja_porUsu_Mes(int usuId, DateTime mes)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_porUsu_Mes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Id_Usu", usuId);
                da.SelectCommand.Parameters.AddWithValue("@fechames", mes);

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


        //------------------------------------- MÉTODO PARA LISTAR CIERRE DE CAJA DEL MES ------------------------------------------//
        public DataTable BD_Listar_Cierre_Caja_delMes(DateTime xmes)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_delMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@xmes", xmes);

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



        //------------------------------------- MÉTODO PARA LISTAR CIERRE DE CAJA POR RANGO DE FECHA ------------------------------------------//
        public DataTable CD_Cargar_CierreCaja_porRangoFecha(DateTime desde, DateTime hasta)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_CierreCaja_porRangoFecha", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@desde", desde);
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


        //------------------------------------- MÉTODO PARA VALIDAR INICIO DOBLE DE CAJA ------------------------------------------//
        public bool CD_validar_InicioDoble_caja()
        {
            bool respuesta = false;
            Int32 getvalue = 0;
            SqlConnection cn = new SqlConnection();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cn.ConnectionString = conectar();
                cmd.CommandText = "SP_VALIDAR_REGISTRO_CAJA";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

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
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al validar inicio de caja: " + ex.Message, "Capa Datos Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }
            return respuesta;
        }



        //------------------------------------- MÉTODO PARA CALCULAR VENTAS POR TIPO DE DOCUMENTO ------------------------------------------//
        public DataTable CD_Calcular_Ventas_PorTipo_Doc(string nomTipoDoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_PorTipoDoc", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipodoc", nomTipoDoc);

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



        //------------------------------------- MÉTODO PARA CALCULAR VENTAS A CRÉDITO ------------------------------------------//
        public DataTable CD_Calcular_ventas_Acredito()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_aCredito", cn);
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



        //------------------------------------- MÉTODO PARA CALCULAR VENTAS A DEPÓSITO ------------------------------------------//
        public DataTable CD_Calcular_ventas_ADeposito()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_aDeposito", cn);
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



        //------------------------------------- MÉTODO PARA CALCULAR GANANCIAS DEL DÍA ------------------------------------------//
        public DataTable CD_Calcular_Ganancias_deldia()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Ventas_GananciadelDia", cn);
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




        public DataTable CD_Calcular_Gastos_TipoPago(string nomTipoDoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Calcular_Gastos_porTipoPago", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@tipopago", nomTipoDoc);

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



        public void CD_Cerrar_Movimientos_Masivo()
        {
            SqlConnection cn = new SqlConnection(conectar());
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Cerrar_Movimientos_Masivo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                throw new Exception("Error al cerrar movimientos: " + ex.Message);
            }
        }

    }
}
