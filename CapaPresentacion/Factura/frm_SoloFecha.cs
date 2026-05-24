using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Factura
{
    public partial class frm_SoloFecha : Form
    {
        public frm_SoloFecha()
        {
            InitializeComponent();
        }
        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }
        private void btrn_aceptar_Click(object sender, EventArgs e)
        {
            this.Tag = "A";
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void frm_SoloFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }

        private void frm_SoloFecha_Load(object sender, EventArgs e)
        {
            //         FECHA - ACTUAL         //
            dtp_fn.Value = DateTime.Now;
        }
    }
}
