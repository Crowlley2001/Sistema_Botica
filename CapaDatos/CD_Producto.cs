using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CD_Producto : Conexion
    {
        public static bool prod_saved = false;
        //----------------------------- METODO REGISTRAR PRODUCTO--------------------------------//
        public void CD_RegistrarProducto(Producto objProd)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_registrar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", objProd.Idprod);
                cmd.Parameters.AddWithValue("@descripcion", objProd.Descripcion);
                cmd.Parameters.AddWithValue("@Pre_compra", objProd.PrecioCompra);
                cmd.Parameters.AddWithValue("@StockActual", objProd.StockActual);
                cmd.Parameters.AddWithValue("@idCat", objProd.IdCat);
                cmd.Parameters.AddWithValue("@Foto", objProd.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta", objProd.Preventa);
                cmd.Parameters.AddWithValue("@Frmto_Compra", objProd.FormatoCompra);
                cmd.Parameters.AddWithValue("@Utilidad", objProd.UtilidadUnit);
                cmd.Parameters.AddWithValue("@ValorporProd", objProd.ValorxCant);
                cmd.Parameters.AddWithValue("@Prin_Activo", objProd.PrincipioActivo);
                cmd.Parameters.AddWithValue("@Laboratorio", objProd.Laboratorio);
                cmd.Parameters.AddWithValue("@Und_Min", objProd.Und_min);
                cmd.Parameters.AddWithValue("@Und_Max", objProd.Und_max);
                cmd.Parameters.AddWithValue("@fechaVncmnto", objProd.FechaVence);
                cmd.Parameters.AddWithValue("@Ventaconreceta", objProd.Venta_conReceta);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Producto se ha Registrado correctamente", "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                prod_saved = true;
            }
            catch (Exception ex)
            {
                prod_saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        //----------------------------- METODO EDITAR PRODUCTO--------------------------------//
        public void CD_EditarProducto(Producto objProd)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("Sp_Editar_Producto", cn);
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", objProd.Idprod);
                cmd.Parameters.AddWithValue("@descripcion", objProd.Descripcion);
                cmd.Parameters.AddWithValue("@Pre_compra", objProd.PrecioCompra);
                cmd.Parameters.AddWithValue("@idCat", objProd.IdCat);
                cmd.Parameters.AddWithValue("@Foto", objProd.Foto);
                cmd.Parameters.AddWithValue("@Pre_Venta", objProd.Preventa);
                cmd.Parameters.AddWithValue("@Frmto_Compra", objProd.FormatoCompra);
                cmd.Parameters.AddWithValue("@Prin_Activo", objProd.PrincipioActivo);
                cmd.Parameters.AddWithValue("@Laboratorio", objProd.Laboratorio);
                cmd.Parameters.AddWithValue("@Und_Min", objProd.Und_min);
                cmd.Parameters.AddWithValue("@Und_Max", objProd.Und_max);
                cmd.Parameters.AddWithValue("@fechaVncmnto", objProd.FechaVence);
                cmd.Parameters.AddWithValue("@Ventaconreceta", objProd.Venta_conReceta);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                //MessageBox.Show("El Producto se ha Registrado correctamente", "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                prod_saved = true;
            }
            catch (Exception ex)
            {
                prod_saved = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        //----------------------------- METODO BUSCAR PRODUCTO ID--------------------------------//
        public DataTable CD_Buscar_ProductoID(string idpro)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("Sp_Buscador_Produtos_porValor", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@valor", idpro);
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
        //----------------------------- METODO DARBAJA PRODUCTO --------------------------------//
        public static bool elminado_prod = false;
        public void CD_DarBaja_Producto(string idpro)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("Sp_Darbaja_Producto", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                elminado_prod = true;
            }
            catch (Exception ex)
            {
                elminado_prod = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Baja del producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //----------------------------- METODO ELIMINAR PRODUCTO --------------------------------//

        public void CD_Eliminar_Producto(string idpro, string idkardex)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_Eliminar_Producto", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
                cmd.Parameters.AddWithValue("@idKarde", idkardex);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                elminado_prod = true;
            }
            catch (Exception ex)
            {
                elminado_prod = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Eliminación de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        //----------------------------- METODO MOSTRAR TODOS LOS PRODUCTOS --------------------------------//
        public DataTable CD_Mostrar_Producto()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();
                SqlDataAdapter da = new SqlDataAdapter("sp_Listar_Todos_Productos", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        //----------------------------- METODO RESTAR STOCK PRODUCTOS --------------------------------//
        public void CD_RestarStock_Producto(string idpro, double stock)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_Restar_Stock", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
                cmd.Parameters.AddWithValue("@stock", stock);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                elminado_prod = true;
            }
            catch (Exception ex)
            {
                elminado_prod = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Eliminación de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //----------------------------- METODO SUMAR STOCK PRODUCTOS --------------------------------//
        public void CD_SumarStock_Producto(string idpro, double stock)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_SumarStock", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
                cmd.Parameters.AddWithValue("@stock", stock);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                elminado_prod = true;
            }
            catch (Exception ex)
            {
                elminado_prod = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Eliminación de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void CD_Actualizar_PrecioCompra_Producto(string idpro, double precomprasol, double preventa_menor, double utilidad, double valoralmacen)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("Sp_Actulizar_Precios_CompraVenta_Producto", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Pro", idpro);
                cmd.Parameters.AddWithValue("@Pre_CompraS", precomprasol);
                cmd.Parameters.AddWithValue("@Pre_vntaxMenor", preventa_menor);
                cmd.Parameters.AddWithValue("@Utilidad", utilidad);
                cmd.Parameters.AddWithValue("@ValorAlmacen", valoralmacen);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                elminado_prod = true;
            }
            catch (Exception ex)
            {
                elminado_prod = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Eliminación de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public void CD_Igualar_Stock_Producto(string idpro, double stock)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_Igualar_Stock_aCero", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
                cmd.Parameters.AddWithValue("@stock", stock);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                elminado_prod = true;
            }
            catch (Exception ex)
            {
                elminado_prod = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Eliminación de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

     

        public void CD_Cambiar_campo_estadoReporte(string idprod, string palabra)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("Sp_Cambiar_CampoReporteProducto", cn);

            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idprod);
                cmd.Parameters.AddWithValue("@Palabra", palabra);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                elminado_prod = true;
            }
            catch (Exception ex)
            {
                elminado_prod = false;

                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error: " + ex.Message,
                                "Baja de Producto",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }



        //para la consulta:
        public DataTable CD_Listar_todos_Los_productos_sinRotacion(string palabra)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();

                SqlDataAdapter da = new SqlDataAdapter("Sp_Listar_productos_sinRotacion", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Parametros:
                da.SelectCommand.Parameters.AddWithValue("@Palabra", palabra);

                DataTable data = new DataTable();

                da.Fill(data);
                da = null;

                return data;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }

                MessageBox.Show("Error de Registro: " + ex.Message,
                                "Registro de Cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return null;
            }
        }


        public void BD_Actualizar_PrecioCompra_Producto(string idprod, double precompraSol, double preVenta_mnor, double utilidad, double valoralmacen)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("Sp_Actulizar_Precios_CompraVenta_Producto", cn);

            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_Pro", idprod);
                cmd.Parameters.AddWithValue("@Pre_CompraS", precompraSol);
                cmd.Parameters.AddWithValue("@Pre_vntaxMenor", preVenta_mnor);
                cmd.Parameters.AddWithValue("@Utilidad", utilidad);
                cmd.Parameters.AddWithValue("@ValorAlmacen", valoralmacen);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                elminado_prod = true; 
            }
            catch (Exception ex)
            {
                elminado_prod = false;
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Actualización de precios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void CD_Calcular_Valor_Almacen(string idpro)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_calcular_Valor_almacen", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                elminado_prod = true;
            }
            catch (Exception ex)
            {
                elminado_prod = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Baja del producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public void CD_Calcular_Utilidad_deAlamacen(string idpro)
        {
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("sp_calcular_utilidad", cn);
            try
            {
                cn.ConnectionString = conectar();
                cmd.CommandTimeout = 20;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idpro", idpro);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                elminado_prod = true;
            }
            catch (Exception ex)
            {
                elminado_prod = false;
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message, "Baja del producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public DataTable CD_Listar_Productos_MasVendidos(DateTime fecha)
        {
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = conectar();

                SqlDataAdapter da = new SqlDataAdapter("Sp_Productos_MasVendidos_DelDia", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Fecha", fecha);

                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar productos vendidos: " + ex.Message);
                return null;
            }
        }


        public DataTable CD_ProductosReposicion()
        {
            SqlConnection cn = new SqlConnection();
            DataTable dt = new DataTable();

            try
            {
                cn.ConnectionString = conectar();
                SqlCommand cmd = new SqlCommand("sp_productos_reposicion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error: " + ex.Message);
            }

            return dt;
        }


        public bool CD_ExisteProducto(string nombre)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = conectar();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Productos WHERE Descripcion_Larga = @nombre", cn);

                cmd.Parameters.AddWithValue("@nombre", nombre);

                cn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();

                return count > 0;
            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();

                MessageBox.Show("Error verificando producto: " + ex.Message);
                return false;
            }
        }

    }
}
