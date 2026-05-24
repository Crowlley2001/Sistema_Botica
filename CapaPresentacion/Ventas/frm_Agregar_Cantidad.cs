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

namespace CapaPresentacion.Ventas
{
    public partial class frm_Agregar_Cantidad : Form
    {
        public frm_Agregar_Cantidad()
        {
            InitializeComponent();
        }

        private void frm_Agregar_Cantidad_Load(object sender, EventArgs e)
        {
            txt_cant.Focus();
            txt_cant.SelectAll();
        }

        //------------------------ EVENTO KEYPRESS SOLO NUMEROS ENTEROS -------------------------//
        private void txt_cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_ModalCategoria ui = new Cls_ModalCategoria();
            e.KeyChar = Convert.ToChar(ui.Solo_NumeroEnteros(e.KeyChar));
        }

        //---------------------------- EVENTO KEYDOWN LLAMAR TXT_CANT ---------------------------//
        private void frm_Agregar_Cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txt_cant_KeyDown(sender, e);
            }
        }


        //------------------------------ EVENTO KEYDOW BTN_LISTO --------------------------------//
        private void txt_cant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_listo.PerformClick();
                e.SuppressKeyPress = true; 
            }
        }


        //-------------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA ----------------//
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }


        //----------------------------------- METODO CANCELAR -----------------------------------//
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //---------------------------- METODO LISTO ENTER Y STOCK  ------------------------------//
        private void btn_listo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_cant.Text))
            {
                MessageBox.Show("Ingrese una cantidad",
                    "Mensaje del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txt_cant.Focus();
                return;
            }

            double cant = Convert.ToDouble(txt_cant.Text);
            double stock = Convert.ToDouble(lbl_Stock1.Text);

            if (cant <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero",
                    "Mensaje del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cant > stock)
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock",
                    "Mensaje del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                txt_cant.Text = "1";
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
