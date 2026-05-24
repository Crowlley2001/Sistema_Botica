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
    public partial class frm_Advertencia : Form
    {
        public frm_Advertencia()
        {
            InitializeComponent();
        }
        //---------------------------------- METODO ACEPTAR ADEVETENCIA --------------------------------------//
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //------------------------------------- METODO ACEPTAR Y SALIR----------------------------------------//
        private void frm_Advertencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_cancelar_Click(sender, e);
            }
        }
        //--------------------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA ----------------------//
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
