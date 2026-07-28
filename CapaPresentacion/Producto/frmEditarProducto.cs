using CapaEntidad;
using CapaNegocio;
using CapaDatos;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CapaPresentacion.Producto
{
    public partial class frmEditarProducto : Form
    {
        string idOriginal = "";
        public frmEditarProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cbo_receta.SelectedIndex = 0;
            LLenarCombo_Categoria();
            BuscarProducto(this.Tag.ToString());

            if (!chk_fechvence.Checked)
                dtp_fechaVence.Value = DateTime.Now;
        }
        //----------------------------- METODO LLENAR COMBOBOX CATEGORIA-------------------------------//
        private void LLenarCombo_Categoria()
        {
            CN_Categoria obj = new CN_Categoria();
            DataTable data = new DataTable();
            data = obj.ListarCategorias();
            if (data.Rows.Count > 0)
            {
                var cbo = cbo_catg;
                cbo.DataSource = data;
                cbo.DisplayMember = "Categoria";
                cbo.ValueMember = "Id_Cat";
                cbo.SelectedIndex = -1;
            }
        }

        //-------------------------- METODO EDITAR PRODUCTO ATRAVES DEL ID-----------------------------//
        private void BuscarProducto(string idprod)
        {
            CN_Producto obj = new CN_Producto();
            DataTable data = new DataTable();
            string fecha;
            try
            {
                data = obj.BuscarProductoID(idprod);
                if (data.Rows.Count == 0)
                {
                    MessageBox.Show(
                    "El ID ingresado no existe o se dio de Baja",
                    "Búsqueda",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                    return;
                }

                var dt = data.Rows[0];

                idOriginal = dt["Id_Pro"].ToString();
                txt_idProd.Text = idOriginal;

                txt_idProd.Text = dt["Id_Pro"].ToString();
                txt_nomprod.Text = dt["Descripcion_Larga"].ToString();
                cbo_catg.SelectedValue = Convert.ToInt32(dt["Id_Cat"]);
                cbo_presentacion.Text = dt["Frmto_Compra"].ToString().Trim();
                txt_PA.Text = dt["Prin_Acti"].ToString();
                txt_lab.Text = dt["Laboratorio"].ToString();
                fecha = dt["FechaVncmnto"].ToString();
                if (fecha == "_")
                {
                    chk_fechvence.Checked = false;
                    dtp_fechaVence.Enabled = false;
                }
                else
                {
                    chk_fechvence.Checked = true;
                    dtp_fechaVence.Enabled = true;
                }
                cbo_receta.Text = dt["VentaConReceta"].ToString();
                nud_min.Value = Convert.ToInt32(dt["Und_Min"]);
                nud_max.Value = Convert.ToInt32(dt["Und_Max"]);
                txt_precompra.Text = dt["Pre_CompraS"].ToString();
                txt_preventa.Text = dt["Pre_venta"].ToString();

                fotoruta = dt["Foto"].ToString();

                if (System.IO.File.Exists(fotoruta))
                {
                    using (Image imagen = Image.FromFile(fotoruta))
                    {
                        pic_prod.Image = new Bitmap(imagen);
                    }
                }
                else
                {
                    pic_prod.Image = Properties.Resources.Imagen7;
                }

                pic_prod.SizeMode = PictureBoxSizeMode.Zoom;
                pic_prod.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Busqueda de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //--------------- METODO MOVER FORMULARIO DESDE EL Cls_ModalCategoria--------------------------//
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }

        //--------------------------------- METODO CERRAR PRODUCTO-------------------------------------//
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //--------------------------------- METODO GUARDAR PRODUCTO------------------------------------//
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_idProd.Text))
            {
                MessageBox.Show(
                    "Debe ingresar y buscar un ID de producto antes de guardar",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txt_idProd.Focus();
                return;
            }
            if (txt_idProd.Text != idOriginal)
            {
                MessageBox.Show(
                    "No está permitido modificar el ID del producto",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txt_idProd.Text = idOriginal;
                return;
            }
            Registrar_Producto();
        }

        //--------------------------------- METODO REGISTRAR PRODUCTO----------------------------------//
        string fotoruta = "";
        string nuevaFotoSeleccionada = "";
        private void Registrar_Producto()
        {
            CN_Producto obj = new CN_Producto();
            CapaEntidad.Producto pro = new CapaEntidad.Producto();
            try
            {
                pro.Idprod = txt_idProd.Text;
                pro.Descripcion = txt_nomprod.Text;
                pro.PrecioCompra = Convert.ToDouble(txt_precompra.Text);
                pro.IdCat = Convert.ToInt32(cbo_catg.SelectedValue);
                pro.Foto = GuardarFotoEditada();
                pro.Preventa = Convert.ToDouble(txt_preventa.Text);
                pro.FormatoCompra = cbo_presentacion.Text;
                pro.PrincipioActivo = txt_PA.Text;
                pro.Laboratorio = txt_lab.Text;
                pro.Und_min = Convert.ToInt32(nud_min.Value);
                pro.Und_max = Convert.ToInt32(nud_max.Value);
                if (chk_fechvence.Checked == true)
                {
                    pro.FechaVence = dtp_fechaVence.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    pro.FechaVence = "_";
                }
                pro.Venta_conReceta = cbo_receta.Text;
                obj.EditarProducto(pro);
                if (CD_Producto.prod_saved == true)
                {
                    MessageBox.Show("El producto se ha editado correctamente", "Registro de Kardex", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (CD_Producto.prod_saved == true)
                    Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //--------------------------------- METODO GUARDAR IMAGEN--------------------------------------//
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter =
                    "Imágenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos los archivos|*.*";
                if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    nuevaFotoSeleccionada = openFileDialog1.FileName;
                    using (Image imagen = Image.FromFile(nuevaFotoSeleccionada))
                    {
                        pic_prod.Image = new Bitmap(imagen);
                    }
                    pic_prod.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                pic_prod.Image = Image.FromFile(
                    Application.StartupPath + @"\Resources\Imagen7.png"
                );
                pic_prod.SizeMode = PictureBoxSizeMode.Zoom;

                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Cargar Imagen",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        }

        private string GuardarFotoEditada()
        {
            if (string.IsNullOrWhiteSpace(nuevaFotoSeleccionada) ||
                !File.Exists(nuevaFotoSeleccionada))
            {
                return fotoruta;
            }

            string carpeta = Path.Combine(
                Application.StartupPath, "ImagenesProductos");
            Directory.CreateDirectory(carpeta);
            string extension = Path.GetExtension(nuevaFotoSeleccionada);
            if (string.IsNullOrWhiteSpace(extension))
                extension = ".png";
            string destino = Path.Combine(
                carpeta,
                idOriginal.Trim().Replace(":", "_").Replace("/", "_") + extension);
            File.Copy(nuevaFotoSeleccionada, destino, true);
            fotoruta = destino;
            nuevaFotoSeleccionada = "";
            return destino;
        }

        //--------------------------- METODO SELECCIONAR CHECK PARA LA FECHA---------------------------//
        private void chk_fechvence_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_fechvence.Checked == true)
            {
                dtp_fechaVence.Enabled = true;
            }
            else
            {
                dtp_fechaVence.Enabled = false;
            }
        }

        //------------------------------------- METODO LIMPIAR ----------------------------------------//
        private void Limpiar()
        {
            // TextBox
            txt_idProd.Clear();
            txt_nomprod.Clear();
            txt_precompra.Clear();
            txt_preventa.Clear();
            txt_PA.Clear();
            txt_lab.Clear();

            // NumericUpDown
            nud_min.Value = nud_min.Minimum;
            nud_max.Value = nud_max.Minimum;

            // ComboBox
            cbo_catg.SelectedValue = -1;
            cbo_receta.SelectedIndex = 0;
            cbo_presentacion.SelectedIndex = -1;

            // Fecha
            dtp_fechaVence.Value = DateTime.Now;
            dtp_fechaVence.Enabled = false;

            // Imagen
            pic_prod.Image = Properties.Resources.Imagen7;
            pic_prod.SizeMode = PictureBoxSizeMode.Zoom;
            fotoruta = "";

            // Foco inicial
            txt_nomprod.Focus();
        }

        //---------------------------------- METODO LIMPIAR BOTON--------------------------------------//

        private void btn_Limpiar_Productos_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //-------- METODO ESCRIBIR SOLO NUMEROS PARA EL TXTPRECIOVENTA Y EL TXTPRECIOCOMPRA------------//
        private void SoloNumerosConDecimal(KeyPressEventArgs e, object sender)
        {
            char separador = ','; // español

            var txt = sender as Control;
            if (txt == null) return;

            // Permitir números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Permitir backspace
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            // Convertir punto en coma
            if (e.KeyChar == '.')
            {
                e.KeyChar = separador;
            }

            // Permitir SOLO una coma
            if (e.KeyChar == separador)
            {
                if (txt.Text.Contains(separador))
                {
                    e.Handled = true;
                    return;
                }

                // No permitir empezar con coma
                if (txt.Text.Length == 0)
                {
                    e.Handled = true;
                    return;
                }

                e.Handled = false;
                return;
            }

            // Bloquear todo lo demás
            e.Handled = true;
        }

        //--------------------------- METODO NUMERO DECIMAL TXT_PRECOMPRA------------------------------//
        private void txt_precompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerosConDecimal(e, txt_precompra);
        }

        //---------------------------- METODO NUMERO DECIMAL TXT_PREVENTA------------------------------//
        private void txt_preventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerosConDecimal(e, txt_preventa);
        }


        //------------------------------ METODO BUSCAR PRODUCTO POR ID---------------------------------//
        //private void btn_id_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txt_idProd.Text))
        //    {
        //        MessageBox.Show(
        //            "Ingrese un ID de producto para buscar",
        //            "Validación",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning
        //        );
        //        txt_idProd.Focus();
        //        return;
        //    }
        //    BuscarProducto(txt_idProd.Text);
        //}
        private void btn_eliminar_Click(object sender, EventArgs e)
        {

        }
        //------------------------------ METODO DAR DE BAJA PRODUCTO-----------------------------------//
        private void bt_DarBajaProductoTool_Click(object sender, EventArgs e)
        {
            CN_Producto obj = new CN_Producto();
            if (txt_idProd.Text.Trim().Length == 0) return;
            obj.DarBajaProducto(txt_idProd.Text.Trim());
            if (CD_Producto.elminado_prod == true)
            {
                MessageBox.Show("El producto se ha dado de baja");
                Limpiar();
            }
        }


        //----------------------------- METODO ELIMINAR PERMANENTEMENTE--------------------------------//
        private void bt_eliminarProductoTool_Click(object sender, EventArgs e)
        {
            CN_Producto obj = new CN_Producto();
            CN_Kardex objkar = new CN_Kardex();
            DataTable data = new DataTable();
            string idkardex = "-";
            if (txt_idProd.Text.Trim().Length == 0) return;

            data = objkar.BuscarKardexPorValor(txt_idProd.Text.Trim());
            if (data.Rows.Count > 0)
            {
                idkardex = data.Rows[0]["Id_krdx"].ToString();
                obj.EliminarProducto(txt_idProd.Text.Trim(), idkardex);
                if (CD_Producto.elminado_prod == true)
                {
                    MessageBox.Show("El producto se ha eliminado permanentemente");
                    Limpiar();
                }
            }
            else
            {
                obj.EliminarProducto(txt_idProd.Text.Trim(), idkardex);
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
    }
}
