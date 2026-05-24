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
    public class CD_Documento : Conexion
    {
        public static bool doc_saved = false;

        // ---------------------------------------------
        // REGISTRAR DOCUMENTO
        // ---------------------------------------------
        public void CD_RegistrarDocumento(Documento objDoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_Insert_Documento", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Doc", objDoc.Id_Doc);
                cmd.Parameters.AddWithValue("@id_Ped", objDoc.Id_Ped);
                cmd.Parameters.AddWithValue("@Id_Tipo", objDoc.Id_Tipo);
                cmd.Parameters.AddWithValue("@Fecha_Emi", objDoc.Fecha_Emi);
                cmd.Parameters.AddWithValue("@Importe", objDoc.ImporteDoc);
                cmd.Parameters.AddWithValue("@TipoPago", objDoc.TipoPago);
                cmd.Parameters.AddWithValue("@NroOpera", objDoc.Nro_Operation);
                cmd.Parameters.AddWithValue("@id_Usu", objDoc.Id_Usu);
                cmd.Parameters.AddWithValue("@TotalGanancia", objDoc.TotalGanancia);
                cmd.Parameters.AddWithValue("@TotalDscuento", objDoc.TotalDscuento);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                doc_saved = true;
            }
            catch (Exception ex)
            {
                doc_saved = false;
                if (cn.State == System.Data.ConnectionState.Open) cn.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        // ---------------------------------------------
        // BUSCAR DOCUMENTO POR ID
        // ---------------------------------------------
        public DataTable CD_Buscar_DocumentoId(string idtemp)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Documentos_xValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Xvalor", idtemp);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error al mostrar datos: " + ex.Message);
                return null;
            }
        }




        // ---------------------------------------------
        // LISTAR TODOS LOS DOCUMENTOS
        // ---------------------------------------------
        public DataTable CD_Listar_Documentos()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();

                SqlDataAdapter da = new SqlDataAdapter("sp_listar_todos_Docs", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error al mostrar datos: " + ex.Message);
                return null;
            }
        }




        // ---------------------------------------------
        // LISTAR DOCUMENTOS EMITIDOS HOY
        // ---------------------------------------------
        public DataTable CD_Listar_Documentos_Pordia(DateTime dia)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_Doc_emitoshoy", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@FechaActual", dia);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error al mostrar datos: " + ex.Message);
                return null;
            }
        }









        // ---------------------------------------------
        // ELIMINAR DOCUMENTO
        // ---------------------------------------------
        public bool CD_Eliminar_Documento(string idDoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand("Sp_Eliminar_Documento", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_Doc", idDoc);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }




        // ---------------------------------------------
        // VALIDAR DOCUMENTO EXISTENTE
        // ---------------------------------------------
        public bool CD_ValidarDocumento(string idDoc)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand("Sp_Validar_Id_Doc", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Doc", idDoc);

                cn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();

                return (count > 0);
            }
            catch
            {
                return false;
            }
        }



        // ---------------------------------------------
        // BUSCAR DOCUMENTO DETALLE ID
        // ---------------------------------------------
        public DataTable CD_Buscar_DocumentoDetalleId(string idtemp)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Documento_yDetalle", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Nro_Doc", idtemp);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error al mostrar datos: " + ex.Message);
                return null;
            }

        }




        // ---------------------------------------------
        // ANULAR DOCUMENTO 
        // ---------------------------------------------
        public void CD_AnulaDocumento(string idtemp, string estado)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand da = new SqlCommand("Sp_Anular_Documento", cn);
                da.CommandTimeout = 20;
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@Id_Doc", idtemp);
                da.Parameters.AddWithValue("@estado", estado);

                cn.Open();
                da.ExecuteNonQuery();
                cn.Close();
                doc_saved = true;
                
            }
            catch (Exception ex)
            {
                doc_saved = false;
                if (cn.State == System.Data.ConnectionState.Open) cn.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        }



        // ---------------------------------------------
        // LISTAR FACTURAS EMITIDAS EN UN MES
        // ---------------------------------------------
        public DataTable CD_Listar_Facturas_Emitidas_Mes(DateTime fechaMes)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();

                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Fcturas_Emtidas_EnunMes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes", fechaMes);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error al listar facturas del mes: " + ex.Message);
                return null;
            }
        }






        // ---------------------------------------------
        // LISTAR FACTURAS EMITIDAS EN RANGO DE FECHAS
        // ---------------------------------------------
        public DataTable CD_Listar_Facturas_Emitidas_Rango(DateTime fechaInicio, DateTime fechaFin)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();

                SqlDataAdapter da = new SqlDataAdapter("Sp_Leer_Fcturas_Emtidas_enRangoFecha", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes1", fechaInicio);
                da.SelectCommand.Parameters.AddWithValue("@Fecha_Mes2", fechaFin);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error al listar facturas por rango: " + ex.Message);
                return null;
            }
        }





        // ---------------------------------------------
        // LISTAR COMPROBANTES EMITIDOS EN UN MES POR TIPO
        // ---------------------------------------------
        public DataTable CD_Listar_Comprobantes_Emitidos_Mes(DateTime fechaMes, int tipoDoc)
        {
            SqlConnection cn = new SqlConnection(conectar());
            try
            {
                SqlCommand cmd = new SqlCommand("Sp_Leer_Comprobantes_Emtidas_EnunMes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asignación explícita de tipos para evitar errores de conversión
                cmd.Parameters.Add("@Fecha_Mes", SqlDbType.Date).Value = fechaMes;
                cmd.Parameters.Add("@Docu", SqlDbType.Int).Value = tipoDoc;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Capa de Datos: " + ex.Message);
                return null;
            }
        }


       


    }
}
