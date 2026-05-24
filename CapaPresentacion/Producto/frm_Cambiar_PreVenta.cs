using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Producto
{
    public partial class frm_Cambiar_PreVenta : Form
    {
        public frm_Cambiar_PreVenta()
        {
            InitializeComponent();
        }

        public string idProduto = "";
        private void frm_Cambiar_PreVenta_Load(object sender, EventArgs e)
        {
            Buscar_Producto(idProduto.Trim());
            txt_precio_venta.Focus();

        }

        private void Buscar_Producto(string xvalor)
        {
            CN_Producto obj = new CN_Producto();
            DataTable data = new DataTable();

            try
            {
                data = obj.BuscarProductoID(xvalor.Trim());
                if (data.Rows.Count > 0)
                {
                    lbl_producto_precio.Text = Convert.ToString(data.Rows[0]["Id_Pro"]);
                    //Lbl_stockActual.Text = Convert.ToString(data.Rows[0]["Stock_Actual"]);
                    txt_precio_compra.Text = Convert.ToString(data.Rows[0]["Pre_CompraS"]);
                    txt_precio_venta.Text = Convert.ToString(data.Rows[0]["Pre_venta"]);
                    lbl_producto_precio.Text = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_cancelar_precio_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_aceptar_precio_Click(object sender, EventArgs e)
        {
            if (txt_precio_compra.Text == "") { txt_precio_compra.Focus(); return; }
            if (Convert.ToDouble(txt_precio_compra.Text) == 0) { txt_precio_compra.Focus(); return; }


            if (txt_precio_venta.Text == "") { txt_precio_venta.Focus(); return; }
            if (Convert.ToDouble(txt_precio_venta.Text) == 0) { txt_precio_venta.Focus(); return; }

            this.Tag = "A";
            this.Close();
        }

        private void txt_precio_compra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_ModalCategoria ui = new Cls_ModalCategoria();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_precio_venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_ModalCategoria ui = new Cls_ModalCategoria();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_precio_compra_TextChanged(object sender, EventArgs e)
        {
            txt_precio_compra.Text = txt_precio_compra.Text.Replace(",", ".");
            txt_precio_compra.SelectionStart = txt_precio_compra.Text.Length;
        }

        private void txt_precio_venta_TextChanged(object sender, EventArgs e)
        {
            txt_precio_venta.Text = txt_precio_venta.Text.Replace(",", ".");
            txt_precio_venta.SelectionStart = txt_precio_venta.Text.Length;
        }

        private void txt_precio_compra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_precio_venta.Focus();
            }
        }


        private void txt_precio_venta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_aceptar_precio_Click(sender, e);
            }
        }


        private void frm_Cambiar_PreVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }
    }
}
