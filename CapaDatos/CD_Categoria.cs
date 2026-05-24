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
    public class CD_Categoria : Conexion
    {
        //----------------------------- METODO REGISTRAR CATEGORIA--------------------------------//
        public void CD_RegistrarCategoria(string nombreCateg)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_Registrar_Categoria", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombreCateg", nombreCateg);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La Categoria se ha Registrado correctamente", "Registrar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Registrar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        //----------------------------- METODO EDITAR CATEGORIA--------------------------------//
        public void CD_EditarCategoria(int idCateg, string nombreCateg)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("SP_Editar_Categoria", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCat", idCateg);
                cmd.Parameters.AddWithValue("@nombrecateg", nombreCateg);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("La Categoria se ha Editado correctamente", "Editar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Editar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
        }

        //----------------------------- METODO LISTAR CATEGORIA--------------------------------//
        public DataTable CD_ListarCategoria()
        {
            SqlConnection cn = new SqlConnection(); ;
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todas_Categ", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dato = new DataTable();
                da.Fill(dato);
                da = null;
                return dato;
            }
            catch (Exception ex)
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Listar Categoria", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }
        }

    }
}
