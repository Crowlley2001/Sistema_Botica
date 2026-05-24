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
    public partial class frm_Solo_Canti : Form
    {
        public frm_Solo_Canti()
        {
            InitializeComponent();
        }

        private void frm_Solo_Canti_Load(object sender, EventArgs e)
        {
            txt_cant.Focus();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            e.KeyChar = Convert.ToChar(objMover.Solo_Numeros(e.KeyChar));
        }

        private void txt_cant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_cant.Text.Trim() == "") return;
                if (Convert.ToDouble(txt_cant.Text) == 0) { MessageBox.Show("La Cantidad debe ser Mayor a Cero", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); txt_cant.Focus(); return; }

                this.Tag = "A";
                this.Close();
            }
        }

        private void txt_cant_TextChanged(object sender, EventArgs e)
        {
            txt_cant.Text = txt_cant.Text.Replace(",", ".");
            txt_cant.SelectionStart = txt_cant.Text.Length;
        }

        private void frm_Solo_Canti_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }
    }
}
