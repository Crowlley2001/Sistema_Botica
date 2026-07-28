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
    public partial class frm_editCant : Form
    {
        public frm_editCant()
        {
            InitializeComponent();
        }
        private void frm_editCant_Load(object sender, EventArgs e)
        {
            txt_cantStock.Focus();
        }
        private void frm_editCant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              this.Tag = "";
              this.Close();
            }
        }
    
        private void txt_cantStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_generarstock_Click(sender, e);
            }
        }
        private void btn_generarstock_Click(object sender, EventArgs e)
        {
            if(txt_cantStock.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la cantidad a ajustar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                this.Tag = "A";
                this.Close();
            }
        }

        private void btn_cancelarstock_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_cantStock_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double resul = Convert.ToDouble(txt_cantStock.Text) - Convert.ToDouble(txt_stockActual.Text);
                txt_dife.Text = resul.ToString();

                double importe = 0;
                double result2 = Math.Abs(resul);
                importe = result2 * Convert.ToDouble(txt_precompra.Text);
                txt_importe.Text = importe.ToString("###0.00");

            }
            catch (Exception)
            {
                txt_dife.Text = "0";
                txt_importe.Text = "0";
                MessageBox.Show("Ingrese un valor numérico válido para la cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }
    }
}
