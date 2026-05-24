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
    public class CD_Usuario : Conexion
    {
        public static bool saved = false;
        public void CD_Registrar_Usuario(Usuarios objProd)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("sp_registrar_Usuario", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusu", objProd.Idusu);
                cmd.Parameters.AddWithValue("@nombres", objProd.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", objProd.Apellidos);
                cmd.Parameters.AddWithValue("@usu", objProd.Usu);
                cmd.Parameters.AddWithValue("@clave", objProd.Clave);
                cmd.Parameters.AddWithValue("@foto", objProd.Foto);
                cmd.Parameters.AddWithValue("@fechaNaci", objProd.FechaNaci);
                cmd.Parameters.AddWithValue("@idrol", objProd.Idrol);
                cmd.Parameters.AddWithValue("@correo", objProd.Correo);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Producto se ha Registrado correctamente", "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                saved = true;
            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public void CD_Modificar_Usaurio(Usuarios objProd)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("sp_editar_Usuario", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusu", objProd.Idusu);
                cmd.Parameters.AddWithValue("@nombres", objProd.Nombres);
                cmd.Parameters.AddWithValue("@apellidos", objProd.Apellidos);
                cmd.Parameters.AddWithValue("@usu", objProd.Usu);
                cmd.Parameters.AddWithValue("@clave", objProd.Clave);
                cmd.Parameters.AddWithValue("@foto", objProd.Foto);
                cmd.Parameters.AddWithValue("@fechaNaci", objProd.FechaNaci);
                cmd.Parameters.AddWithValue("@idrol", objProd.Idrol);
                cmd.Parameters.AddWithValue("@correo", objProd.Correo);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Producto se ha Registrado correctamente", "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                saved = true;
            }
            catch (Exception ex)
            {
                saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        //------------------------ Verificar Acceso ---------------------------//
        public bool CD_Verificar_Acceso(string xusu, string xpass)
        {
            bool rspta = false;
            Int32 nro = 0;
            SqlConnection cn = new SqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cn.ConnectionString = conectar();
                cmd.CommandText = "Sp_Login";
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", xusu);
                cmd.Parameters.AddWithValue("@Contraseña", xpass);
                cn.Open();
                nro = Convert.ToInt32(cmd.ExecuteScalar());
                if (nro > 0)
                {
                    rspta = true;
                }
                else
                {
                    rspta = false;
                }
                cn.Close();
                cmd.Dispose();
            }
            catch (Exception ex) 
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al guardar:" + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
            return rspta;
        }


        //------------------------ Buscar Usuarios ---------------------------//
        public DataTable CD_Buscar_Usuarios(string xusu)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_LeerUsuario_Login", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Usuario", xusu);
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
                MessageBox.Show("Error al mostrar datos: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }




        public DataTable CD_Cargar_todos_Usuarios()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_listar_Todos_users", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al mostrar datos: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }



        public void CD_Eliminar_Usuario(int idusu)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = conectar();
                cn.Open(); 

                SqlCommand cmd = new SqlCommand("sp_eliminar_Usu", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusu", idusu);

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

                MessageBox.Show("Error: " + ex.Message, "Eliminar usuario",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }





        public DataTable CD_Buscar_Usuario_porId(int xusu)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Usuario", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@idusu", xusu);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al mostrar datos: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }




        public DataTable CD_Cargar_todos_Roels(string xusu)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Cargar_todos_Roles", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                da = null;
                return dt;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al mostrar datos: " + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }
    }
}
