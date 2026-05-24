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

namespace CapaPresentacion.Compras
{
    public partial class frm_PrecompraVenta : Form
    {
        public frm_PrecompraVenta()
        {
            InitializeComponent();
        }
        public string idProdcto = "";
        private void frm_PrecompraVenta_Load(object sender, EventArgs e)
        {
            Buscar_Producto(idProdcto.Trim());
            txt_preciocompra.Focus();
        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
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
                    lbl_idProd.Text = Convert.ToString(data.Rows[0]["Id_Pro"]);
                    //Lbl_stockActual.Text = Convert.ToString(data.Rows[0]["Stock_Actual"]);
                    txt_preciocompra.Text = Convert.ToString(data.Rows[0]["Pre_CompraS"]);
                    txt_preventa.Text = Convert.ToString(data.Rows[0]["Pre_venta"]);
                    lbl_idProd.Text = Convert.ToString(data.Rows[0]["Descripcion_Larga"]);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al Guardar: " + ex.Message, "Form Add Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void bt_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_preciocompra.Text == "") { txt_preciocompra.Focus(); return; }
            if (Convert.ToDouble(txt_preciocompra.Text) == 0) { txt_preciocompra.Focus(); return; }


            if (txt_preventa.Text == "") { txt_preventa.Focus(); return; }
            if (Convert.ToDouble(txt_preventa.Text) == 0) { txt_preventa.Focus(); return; }

            this.Tag = "A";
            this.Close();
        }

        private void txt_preciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_ModalCategoria ui = new Cls_ModalCategoria();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_ModalCategoria ui = new Cls_ModalCategoria();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        private void txt_preciocompra_TextChanged(object sender, EventArgs e)
        {
            txt_preciocompra.Text = txt_preciocompra.Text.Replace(",", ".");
            txt_preciocompra.SelectionStart = txt_preciocompra.Text.Length;
        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {
            txt_preventa.Text = txt_preventa.Text.Replace(",", ".");
            txt_preventa.SelectionStart = txt_preventa.Text.Length;
        }

        private void txt_preciocompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_preventa.Focus();
            }
        }

        private void txt_cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_aceptar_Click(sender, e);
            }
        }

        private void frm_PrecompraVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
