using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaEntidad
{
    public class MenuUsuario : Conexion
    {

        public void CD_Registrar_Privilegios_Usuario(string nommenu, int idusu)
        {
            SqlConnection cn = new SqlConnection(conectar());
            SqlCommand cmd = new SqlCommand("sp_registrar_MenuxUsuario", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //agregar los parametros
                cmd.Parameters.AddWithValue("@nombremenu", nommenu);
                cmd.Parameters.AddWithValue("@idusu", idusu);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Algo malo pasó: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //eliminar:
        public void CD_Eliminar_privilegios_Usuario(int idUsu)
        {
            SqlConnection cn = new SqlConnection(conectar());
            SqlCommand cmd = new SqlCommand("sp_eliminarMenu_xId", cn);

            try
            {
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                //agregar los parametros
                cmd.Parameters.AddWithValue("@idUsu", idUsu);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Algo malo pasó: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool CD_Verificar_sitiene_menu(int idusu)
        {
            bool functionReturnValue = false;
            Int32 xfil = 0;

            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();
            Cn.ConnectionString = conectar();
            var _with1 = Cmd;
            _with1.CommandText = "sp_Verificar_siUsu_tieneMenu";
            _with1.Connection = Cn;
            _with1.CommandTimeout = 20;
            _with1.CommandType = CommandType.StoredProcedure;
            _with1.Parameters.AddWithValue("@idUsu", idusu);
            //_with1.Parameters.AddWithValue("@Clave", Co/*n*/traseña);

            try
            {
                Cn.Open();
                xfil = (Int32)Cmd.ExecuteScalar();
                if (xfil > 0)
                {
                    functionReturnValue = true;
                }
                else
                {
                    functionReturnValue = false;
                }

                Cmd.Parameters.Clear();
                Cmd.Dispose();
                Cmd = null;
                Cn.Close();
            }
            catch (Exception)
            {
          
                functionReturnValue = false;

               
                if (Cn.State == ConnectionState.Open)
                {
                    Cn.Close();
                }
            }

            return functionReturnValue;

        }


        public DataTable CD_Leer_Privilegio_Usuario(int idusu)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_menu_porIdUsu", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idusu", idusu);
                DataTable dato = new DataTable();

                da.Fill(dato);
                da = null;
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Close();
                cn = null;
                MessageBox.Show("Algo malo pasó: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw
            }
            return null;
        }




        public static string CD_Listar_Id_MenuSys(string nomMenu, int IdUsu)
        {
            SqlConnection Cn = new SqlConnection();
            try
            {
                Cn.ConnectionString = conectar2();
                SqlCommand cmd = new SqlCommand("sp_cargar_menu_xcod", Cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nommenu", nomMenu);
                cmd.Parameters.AddWithValue("@idusu", IdUsu);
                string NroDoc;

                Cn.Open();
                NroDoc = Convert.ToString(cmd.ExecuteScalar());
                Cn.Close();
                return NroDoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Cn.State == ConnectionState.Open) Cn.Close();
                Cn.Dispose();
                Cn = null;
                return null;
            }
        }



    }
}
