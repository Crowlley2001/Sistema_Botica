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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cbo_receta.SelectedIndex = 0;
            LLenarCombo_Categoria();
            if (cbo_catg.Items.Count > 0)
                cbo_catg.SelectedIndex = 0;
            if (cbo_presentacion.Items.Count > 0)
                cbo_presentacion.SelectedIndex = 0;
            // Estado inicial
            chk_bar.Checked = false;
            txt_idProd.Enabled = false;
            GenerarIdAutomatico();

            chk_fechvence.Checked = false;
            dtp_fechaVence.Enabled = false;

            //         FECHA - ACTUAL         //
            dtp_fechaVence.Value = DateTime.Now;
        }

        //---------------------------- METODO LLENAR COMBOBOX CATEGORIA--------------------------------//
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
                cbo.SelectedIndex = 0;

            }
        }
        //------------------ METODO MOVER FORMULARIO DESDE EL Cls_ModalCategoria-----------------------//
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }
        //------------------------------- METODO CERRAR PRODUCTO --------------------------------------//
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------------------- METODO GUARDAR PRODUCTO--------------------------------------//
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Registrar_Producto();
        }
        //----------------------------- METODO REGISTRAR PRODUCTO -------------------------------------//
        string fotoruta = "";
        private void Registrar_Producto()
        {
            CN_Producto obj = new CN_Producto();
            CapaEntidad.Producto pro = new CapaEntidad.Producto();
            string fotoCopiada = null;
            try
            {
                if (!chk_bar.Checked)
                {
                    GenerarIdAutomatico();
                }

                if (obj.ExisteIdProducto(txt_idProd.Text))
                {
                    if (!chk_bar.Checked)
                    {
                        GenerarIdAutomatico();
                    }
                    else
                    {
                        MessageBox.Show(
                            "El código ingresado ya pertenece a otro producto.",
                            "Código duplicado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        txt_idProd.Focus();
                        return;
                    }
                }

                pro.Idprod = txt_idProd.Text;
                pro.Descripcion = txt_nomprod.Text;
                pro.PrecioCompra = Convert.ToDouble(txt_precompra.Text);
                pro.StockActual = Convert.ToDouble(txt_stock.Text);
                pro.IdCat = Convert.ToInt32(cbo_catg.SelectedValue);
                fotoCopiada = GuardarFotoEnCarpetaProducto(pro.Idprod);
                pro.Foto = string.IsNullOrWhiteSpace(fotoCopiada) ? "-" : fotoCopiada;
                pro.Preventa = Convert.ToDouble(txt_preventa.Text);
                pro.FormatoCompra = cbo_presentacion.Text;
                pro.UtilidadUnit = Convert.ToDouble(txt_preventa.Text) - Convert.ToDouble(txt_precompra.Text);
                pro.ValorxCant = Convert.ToDouble(txt_stock.Text) * Convert.ToDouble(txt_precompra.Text);
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
                obj.RegistrarProducto(pro);
                if (CD_Producto.prod_saved == true)
                {
                    Crear_Kardex(txt_idProd.Text);
                    if (CD_Kardex.kar_saved == true)
                    {
                        MessageBox.Show("El producto se ha registrado correctamente", "Registro de Kardex", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Limpiar();
                }
                else if (!string.IsNullOrWhiteSpace(fotoCopiada) &&
                         File.Exists(fotoCopiada))
                {
                    File.Delete(fotoCopiada);
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrWhiteSpace(fotoCopiada) &&
                    File.Exists(fotoCopiada))
                {
                    File.Delete(fotoCopiada);
                }
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //---------------------------------- METODO VALIDAR CAMPOS ------------------------------------//
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_idProd.Text))
            {
                MessageBox.Show(
                    "Ingrese el ID del producto",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txt_idProd.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_nomprod.Text))
            {
                MessageBox.Show("Ingrese el nombre del producto");
                txt_nomprod.Focus();
                return false;
            }

            if (!int.TryParse(txt_stock.Text, out _))
            {
                MessageBox.Show("Ingrese un stock válido");
                txt_stock.Focus();
                return false;
            }

            if (cbo_catg.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una categoría");
                cbo_catg.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbo_presentacion.Text))
            {
                MessageBox.Show("Seleccione una presentación");
                cbo_presentacion.Focus();
                return false;
            }

            if (!decimal.TryParse(txt_precompra.Text, out _))
            {
                MessageBox.Show("Ingrese un precio de compra válido");
                txt_precompra.Focus();
                return false;
            }

            if (!decimal.TryParse(txt_preventa.Text, out _))
            {
                MessageBox.Show("Ingrese un precio de venta válido");
                txt_preventa.Focus();
                return false;
            }
            return true;
        }
        //----------------------------------- METODO CREAR KARDEX -------------------------------------//
        private void Crear_Kardex(string idprod)
        {
            CN_Kardex objkardex = new CN_Kardex();
            Detalle_Kardex detkardex = new Detalle_Kardex();
            try
            {
                if (objkardex.Verificar_Kardex_Producto(idprod.Trim()) == true) return;
                string idkardex = CN_TipoDoc.CN_Generar_NroCorrelativo(8);

                    // 2do paso: registrar el kardex
                objkardex.RegistrarKardex(idkardex,txt_idProd.Text);

                if (CD_Kardex.kar_saved == true)
                {
                    // 3er paso: registrar el detalle del kardex
                    detkardex.IdKardex = idkardex;
                    detkardex.Item = 1;
                    detkardex.Doc_soporte = "0000";
                    detkardex.Det_Operacion = "INICIO DE KARDEX";

                    //entradas
                    detkardex.Cantidad_In = Convert.ToDouble(txt_stock.Text);
                    detkardex.Precio_In = Convert.ToDouble(txt_precompra.Text);
                    detkardex.Total_In = Convert.ToDouble(txt_stock.Text) * Convert.ToDouble(txt_precompra.Text);

                    //salidas
                    detkardex.Cantidad_Out = 0;
                    detkardex.Precio_Out = 0;
                    detkardex.Total_Out = 0;

                    //Saldo
                    detkardex.Cantidad_In = Convert.ToDouble(txt_stock.Text);
                    detkardex.Precio_In = Convert.ToDouble(txt_precompra.Text);
                    detkardex.Total_In = Convert.ToDouble(txt_stock.Text) * Convert.ToDouble(txt_precompra.Text);

                    //extras
                    detkardex.Idusu = 1;
                    detkardex.Tipo_operacion = "Inicio";
                    detkardex.Cant_diferencial = "_";
                    detkardex.ImporteDiferente = 0;
                    objkardex.Registrar_DetalleKardex(detkardex);
                    if (CD_Kardex.det_saved)
                    {
                        CN_TipoDoc.CN_Actualizar_Correlativo(8);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Registro del kardex desde Form", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        //------------------------------- METODO GUARDAR IMAGEN ---------------------------------------//
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fotoruta = openFileDialog1.FileName;
                    pic_prod.Image = Image.FromFile(fotoruta);
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
        //----------------------- METODO SELECCIONAR CHECK PARA EL IDPRODUCTO--------------------------//
        private void chk_bar_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_bar.Checked==true)
            {
                txt_idProd.Enabled = true;
                txt_idProd.Clear();
                txt_idProd.Focus();
            }
            else
            {
                txt_idProd.Enabled = false;
                GenerarIdAutomatico();
            }
        }
        //-------------------------- METODO SELECCIONAR CHECK PARA LA FECHA ---------------------------//
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
        //-------------------------------------- METODO LIMPIAR----------------------------------------//
        private void Limpiar()
        {
            // TextBox
            txt_idProd.Clear();
            txt_nomprod.Clear();
            txt_precompra.Clear();
            txt_preventa.Clear();
            txt_stock.Clear();
            txt_PA.Clear();
            txt_lab.Clear();

            // NumericUpDown
            nud_min.Value = nud_min.Minimum;
            nud_max.Value = nud_max.Minimum;

            // ComboBox
            cbo_catg.SelectedIndex = cbo_catg.Items.Count > 0 ? 0 : -1;
            cbo_receta.SelectedIndex = 0;
            cbo_presentacion.SelectedIndex = cbo_presentacion.Items.Count > 0 ? 0 : -1;

            // CheckBox
            chk_bar.Checked = false;
            chk_fechvence.Checked = false;

            // Fecha
            dtp_fechaVence.Value = DateTime.Now;
            dtp_fechaVence.Enabled = false;

            // Imagen
            pic_prod.Image = Properties.Resources.Imagen7;
            pic_prod.SizeMode = PictureBoxSizeMode.Zoom;
            fotoruta = "";
            GenerarIdAutomatico();

            // Foco inicial
            txt_nomprod.Focus();
        }
        //------------------------------------ METODO LIMPIAR BOTON------------------------------------//
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        //------- METODO ESCRIBIR SOLO NUMEROS PARA EL TXTPRECIOVENTA Y EL TXTPRECIOCOMPRA-------------//
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
        //---------------------------- METODO NUMERO DECIMAL TXT_PRECOMPRA-----------------------------//
        private void txt_precompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerosConDecimal(e, txt_precompra);
        }
        //---------------------------- METODO NUMERO DECIMAL TXT_PREVENTA------------------------------//
        private void txt_preventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumerosConDecimal(e, txt_preventa);
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void GenerarIdAutomatico()
        {
            try
            {
                txt_idProd.Text = new CN_Producto().ObtenerSiguienteIdProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo generar el código automático: " + ex.Message,
                    "Código de producto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private string GuardarFotoEnCarpetaProducto(string idProducto)
        {
            if (string.IsNullOrWhiteSpace(fotoruta) || !File.Exists(fotoruta))
                return null;

            string carpeta = Path.Combine(
                Application.StartupPath, "ImagenesProductos");
            Directory.CreateDirectory(carpeta);

            string extension = Path.GetExtension(fotoruta);
            if (string.IsNullOrWhiteSpace(extension))
                extension = ".png";

            string destino = Path.Combine(
                carpeta,
                idProducto.Trim().Replace(":", "_").Replace("/", "_") + extension);
            File.Copy(fotoruta, destino, true);
            return destino;
        }
    }
}
