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
    public class CD_Cliente : Conexion
    {
        public static bool cli_saved = false;
        //----------------------------- METODO REGISTRAR CLIENTE--------------------------------//
        public void CD_RegistrarCliente(Cliente cli)
        {

            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_Registrar_Cliente", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial", cli.Nombre);
                cmd.Parameters.AddWithValue("@dni", cli.Dniruc);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@email", cli.Email);
                cmd.Parameters.AddWithValue("@fechaAniver", cli.FechaAniver);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                cli_saved = true;
            }
            catch (Exception ex)
            {
                cli_saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error de registro: " + ex.Message, "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //----------------------------- METODO EDITAR CLIENTE--------------------------------//
        public void CD_EditarCliente(Cliente cli)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand("Sp_Modificar_Cliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 20;

                cmd.Parameters.AddWithValue("@idcliente", cli.Idcliente);
                cmd.Parameters.AddWithValue("@razonsocial", cli.Nombre);
                cmd.Parameters.AddWithValue("@dni", cli.Dniruc);
                cmd.Parameters.AddWithValue("@direccion", cli.Direccion);
                cmd.Parameters.AddWithValue("@telefono", cli.Telefono);
                cmd.Parameters.AddWithValue("@email", cli.Email);
                cmd.Parameters.AddWithValue("@idDis", 1); 
                cmd.Parameters.AddWithValue("@fechaAniver", cli.FechaAniver);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                cli_saved = true;
            }
            catch (Exception ex)
            {
                cli_saved = false;

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error al editar cliente: " + ex.Message);
            }
        }



        //----------------------------- METODO VALIDAR DNI-RUC--------------------------------//
        public bool Verificar_Nro_DNIRUC(string nroDni)
        {
            bool respuesta = false;
            Int32 nroRegistros = 0;
            SqlConnection cn = new SqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cn.ConnectionString = conectar();
                cmd.CommandText = "sp_Validar_NroDNI";
                cmd.Connection = cn;
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", nroDni);
                cn.Open();
                nroRegistros = Convert.ToInt32(cmd.ExecuteScalar());
                if (nroRegistros > 0)
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al verificar: " + ex.Message, "Capa Datos Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                respuesta = false;
            }
            return respuesta;
        }

        //----------------------------- METODO LISTAR CLIENTE--------------------------------//
        public DataTable CD_Vertodos_Los_Clientes(string estadox)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Clientes", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@estado", estadox);
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
                MessageBox.Show("Error al mostrar datos: " + ex.Message, "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }


        //----------------------------- METODO BUSCAR CLIENTE POR VALOR--------------------------------//
        public DataTable CD_Buscar_Clientes_PorValor(string valor)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscar_Cliente_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Valor", valor);
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
                MessageBox.Show("Error al mostrar datos: " + ex.Message, "Registro de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

        }

    }


}
