using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Ventas
{
    public partial class frm_Si_No : Form
    {
        public frm_Si_No()
        {
            InitializeComponent();
        }
        //----------------------------------------- METODO BTN_SI -------------------------------------------//
        private void btn_si_Click(object sender, EventArgs e)
        {
            this.Tag = "Si";
            this.Close();
        }

        //----------------------------------------- METODO BTN_NO -------------------------------------------//
        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Tag = "No";
            this.Close();
        }

        //--------------------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA ---------------------//
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }
    }
}
