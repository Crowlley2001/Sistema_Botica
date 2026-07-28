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
            try
            {
                byte[] hash;
                byte[] salt;
                int iteraciones;
                PasswordHasher.Crear(
                    objProd.Clave, out hash, out salt, out iteraciones);

                using (SqlConnection cn = new SqlConnection(conectar()))
                using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO dbo.Usuarios
                    (
                        Id_Usu, Nombres, Apellidos, Usuario, Contraseña,
                        FotoUsu, Fecha_Ncmiento, Id_Rol, Correo, Estado_Usu,
                        PasswordHash, PasswordSalt, PasswordIterations
                    )
                    VALUES
                    (
                        @idusu, @nombres, @apellidos, @usu, 'PROTEGIDA',
                        @foto, @fechaNaci, @idrol, @correo, 'Activo',
                        @hash, @salt, @iteraciones
                    );", cn))
                {
                    AgregarParametrosUsuario(cmd, objProd);
                    cmd.Parameters.Add("@hash", SqlDbType.VarBinary, 32).Value = hash;
                    cmd.Parameters.Add("@salt", SqlDbType.VarBinary, 32).Value = salt;
                    cmd.Parameters.Add("@iteraciones", SqlDbType.Int).Value = iteraciones;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                saved = true;
            }
            catch (Exception ex)
            {
                saved = false;
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Registro de usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }


        public void CD_Modificar_Usaurio(Usuarios objProd)
        {
            try
            {
                bool cambiarClave = !String.IsNullOrWhiteSpace(objProd.Clave);
                byte[] hash = null;
                byte[] salt = null;
                int iteraciones = 0;
                if (cambiarClave)
                    PasswordHasher.Crear(
                        objProd.Clave, out hash, out salt, out iteraciones);

                string sql = @"
                    UPDATE dbo.Usuarios
                    SET Nombres = @nombres,
                        Apellidos = @apellidos,
                        Usuario = @usu,
                        FotoUsu = @foto,
                        Fecha_Ncmiento = @fechaNaci,
                        Id_Rol = @idrol,
                        Correo = @correo" +
                    (cambiarClave ? @",
                        Contraseña = 'PROTEGIDA',
                        PasswordHash = @hash,
                        PasswordSalt = @salt,
                        PasswordIterations = @iteraciones" : String.Empty) + @"
                    WHERE Id_Usu = @idusu;";

                using (SqlConnection cn = new SqlConnection(conectar()))
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    AgregarParametrosUsuario(cmd, objProd);
                    if (cambiarClave)
                    {
                        cmd.Parameters.Add("@hash", SqlDbType.VarBinary, 32).Value = hash;
                        cmd.Parameters.Add("@salt", SqlDbType.VarBinary, 32).Value = salt;
                        cmd.Parameters.Add("@iteraciones", SqlDbType.Int).Value = iteraciones;
                    }
                    cn.Open();
                    if (cmd.ExecuteNonQuery() != 1)
                        throw new InvalidOperationException(
                            "No se encontró el usuario que se desea modificar.");
                }
                saved = true;
            }
            catch (Exception ex)
            {
                saved = false;
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Modificar usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }



        //------------------------ Verificar Acceso ---------------------------//
        public bool CD_Verificar_Acceso(string xusu, string xpass)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conectar()))
                using (SqlCommand cmd = new SqlCommand(@"
                    SELECT TOP (1)
                        Id_Usu, Contraseña, PasswordHash,
                        PasswordSalt, PasswordIterations
                    FROM dbo.Usuarios
                    WHERE Usuario = @usuario
                      AND Estado_Usu = 'Activo';", cn))
                {
                    cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 8).Value = xusu;
                    cn.Open();
                    using (SqlDataReader lector = cmd.ExecuteReader())
                    {
                        if (!lector.Read())
                            return false;

                        int idUsuario = lector.GetInt32(0);
                        string claveAnterior =
                            lector.IsDBNull(1) ? String.Empty : lector.GetString(1);
                        byte[] hash = lector.IsDBNull(2)
                            ? null : (byte[])lector[2];
                        byte[] salt = lector.IsDBNull(3)
                            ? null : (byte[])lector[3];
                        int iteraciones = lector.IsDBNull(4)
                            ? 0 : lector.GetInt32(4);

                        if (hash != null)
                            return PasswordHasher.Verificar(
                                xpass, hash, salt, iteraciones);

                        if (!String.Equals(
                            claveAnterior, xpass, StringComparison.Ordinal))
                            return false;

                        lector.Close();
                        MigrarClaveAnterior(cn, idUsuario, xpass);
                        return true;
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(
                    "No se pudo validar el acceso: " + ex.Message,
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        private static void MigrarClaveAnterior(
            SqlConnection cn,
            int idUsuario,
            string password)
        {
            byte[] hash;
            byte[] salt;
            int iteraciones;
            PasswordHasher.Crear(
                password, out hash, out salt, out iteraciones);

            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE dbo.Usuarios
                SET Contraseña = 'PROTEGIDA',
                    PasswordHash = @hash,
                    PasswordSalt = @salt,
                    PasswordIterations = @iteraciones
                WHERE Id_Usu = @id;", cn))
            {
                cmd.Parameters.Add("@hash", SqlDbType.VarBinary, 32).Value = hash;
                cmd.Parameters.Add("@salt", SqlDbType.VarBinary, 32).Value = salt;
                cmd.Parameters.Add("@iteraciones", SqlDbType.Int).Value = iteraciones;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                cmd.ExecuteNonQuery();
            }
        }

        private static void AgregarParametrosUsuario(
            SqlCommand cmd,
            Usuarios usuario)
        {
            cmd.Parameters.Add("@idusu", SqlDbType.Int).Value = usuario.Idusu;
            cmd.Parameters.Add("@nombres", SqlDbType.VarChar, 50).Value =
                usuario.Nombres.Trim();
            cmd.Parameters.Add("@apellidos", SqlDbType.VarChar, 50).Value =
                usuario.Apellidos.Trim();
            cmd.Parameters.Add("@usu", SqlDbType.VarChar, 8).Value =
                usuario.Usu.Trim();
            cmd.Parameters.Add("@foto", SqlDbType.VarChar, 200).Value =
                (object)usuario.Foto ?? DBNull.Value;
            cmd.Parameters.Add("@fechaNaci", SqlDbType.Date).Value =
                Convert.ToDateTime(usuario.FechaNaci);
            cmd.Parameters.Add("@idrol", SqlDbType.Int).Value =
                Convert.ToInt32(usuario.Idrol);
            cmd.Parameters.Add("@correo", SqlDbType.VarChar, 150).Value =
                (object)usuario.Correo ?? DBNull.Value;
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
                if (!dt.Columns.Contains("Estado_Usu"))
                    return dt;

                DataView activos = new DataView(dt)
                {
                    RowFilter = "Estado_Usu = 'Activo'"
                };
                return activos.ToTable();
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

        public int CD_ObtenerSiguienteIdUsuario()
        {
            using (SqlConnection cn = new SqlConnection(conectar()))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT ISNULL(MAX(Id_Usu), 0) + 1 FROM dbo.Usuarios;", cn))
            {
                cn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
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
