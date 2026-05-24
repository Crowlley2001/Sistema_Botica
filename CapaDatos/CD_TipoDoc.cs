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
    public class CD_TipoDoc : Conexion
    {

        //-------------------------- METODO GENERAR NRO CORRELATIVO -----------------------------//
        public static string CD_Generar_NroCorrelativo(int idtipo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Listado_Tipo", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);
                string NroDoc;

                cn.Open();
                NroDoc = Convert.ToString(cmd.ExecuteScalar());
                cn.Close();
                return NroDoc;
            }
            catch (Exception ex)
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error de Registro:" + ex.Message, "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return "-";
            }
        }


        //--------------------------- METODO ACTUALIZAR CORRELATIVO -------------------------------//
        public static void CD_Actualizar_Correlativo(int idtipo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Actualiza_Tipo_Doc", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Tipo", idtipo);
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
                MessageBox.Show("Error de Registro:" + ex.Message, "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        //----------------------------- METODO LISTAR TIPO DOCUMENTO --------------------------------//
        public DataTable CD_Listar_Tipo_Doc()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("SP_Listar_Tipo_Doc", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar: " + ex.Message);
                return null;
            }
        }


        //------------------ METODO LISTAR TIPO DOCUMENTO ESPECIAL PARA VENTAS ----------------------//
        public DataTable CD_Listar_Tipo_Doc_Especial_Ventas()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar2();
                // Usa el proc: Select * from Tipo_Doc Where Id_Tipo in ('3','2','1')
                SqlCommand cmd = new SqlCommand("Sp_Tipod_Doc_Spcial", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en lista especial: " + ex.Message);
                return null;
            }
        }


        //----------------------------- METODO EDITAR TIPO DOCUMENTO --------------------------------//
        public void CD_Editar_Tipo_Doc(int id, string doc, string serie, string num)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Tipo_Doc", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idtipo", id);
                cmd.Parameters.AddWithValue("@documento", doc);
                cmd.Parameters.AddWithValue("@serie", serie);
                cmd.Parameters.AddWithValue("@numero", num);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Documento editado correctamente");
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                MessageBox.Show("Error al editar: " + ex.Message);
            }
        }



        public static bool Saved = false; // Variable para indicar si se guardó correctamente
        public void CD_Editar_Correlativo(TipoDoc cja)
        {
            SqlConnection cn = new SqlConnection();
            {
                try
                {
                    cn.ConnectionString = conectar2();
                    SqlCommand cmd = new SqlCommand("Sp_Editar_Tipo_Doc", cn);
                    cmd.CommandTimeout = 20;
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregando los parámetros desde el objeto 'cja'
                    cmd.Parameters.AddWithValue("@idtipo", cja.Id_Tipo);
                    cmd.Parameters.AddWithValue("@documento", cja.Documento);
                    cmd.Parameters.AddWithValue("@serie", cja.Serie);
                    cmd.Parameters.AddWithValue("@numero", cja.Numero);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    Saved = true;
                }
                catch (Exception ex)
                {
                    Saved = false;
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }
                    MessageBox.Show("Error al registrar el movimiento en caja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }


        public DataTable CD_Cargar_Todos_Los_Correlativos()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar2();
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_Tipo_Doc", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
             

                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en lista especial: " + ex.Message);
                return null;
            }
        }



        public DataTable CD_Cargar_Correlativo_porId(int idtipo)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar2();
                SqlDataAdapter da = new SqlDataAdapter("SP_Listar_Tipo_Doc_porId", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idtipo", idtipo);

                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en lista especial: " + ex.Message);
                return null;
            }
        }
    }
}
