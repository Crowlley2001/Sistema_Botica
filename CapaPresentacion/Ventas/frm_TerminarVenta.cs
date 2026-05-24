using CapaPresentacion.Modales;
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
    public partial class frm_TerminarVenta : Form
    {
        
        public frm_TerminarVenta()
        {
            InitializeComponent();
        }

        //--------------------------------- METODO LOAD DEL FORMULARIO --------------------------------------//

        public double TotalVenta = 0;
        public string TipoPago = "";
        private void frm_TerminarVenta_Load(object sender, EventArgs e)
        {
            if (TipoPago == "Efectivo")
            {
                pnl_tarjeta.Visible = false;
            }
            else
            {
                pnl_tarjeta.Visible = true;
            }
            this.ActiveControl = txt_Acuenta;
            txt_Acuenta.SelectionStart = txt_Acuenta.Text.Length;
        }



        //------------------------------ METODO PARA LIMPIAR EL FORMULARIO ----------------------------------//
        public void LimpiarForm()
        {
            txt_Acuenta.Text = "0";
            txt_Total_acobrar.Text = "0";
        }

        //---------------------------- METODO PARA CALCULAR VUELTO EN EL TEXTBOX ----------------------------//
        private void txt_Acuenta_TextChanged(object sender, EventArgs e)
        {
           
            txt_Acuenta.Text = txt_Acuenta.Text.Replace(",", ".");
            txt_Acuenta.SelectionStart = txt_Acuenta.Text.Length;

            try
            {
                if (string.IsNullOrWhiteSpace(txt_Acuenta.Text))
                {
                    txt_Acuenta.Focus();
                    return;
                }

                double pagaCon = Convert.ToDouble(txt_Acuenta.Text);
                double total = Convert.ToDouble(txt_Total_acobrar.Text);
                double vuelto = pagaCon - total;

             
                txt_vuelto.Text = vuelto.ToString("###0.00");
            }
            catch (Exception ex)
            {
                txt_vuelto.Text = "0.00";
                string sms = ex.Message; 
            }
        }

        //---------------------------- METODO PARA VALIDAR SOLO NUMEROS -------------------------------------//

        private void txt_Acuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cls_ModalCategoria ui = new Cls_ModalCategoria();
            e.KeyChar = Convert.ToChar(ui.Solo_Numeros(e.KeyChar));
        }

        //--------------------------- METODO PARA CAPTURAR TECLA ESCAPE Y ENTER -----------------------------//
        private void frm_TerminarVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                btrn_imprimir_Click(sender, e);
            }
        }

        //----------------------------- BOTON PARA IMPRIMIR TICKET DE VENTA ---------------------------------//
        private void btrn_imprimir_Click(object sender, EventArgs e)
        {
            this.Tag = "A";
            this.Close();
        }

        //------------------------------ BOTON PARA SALIR DEL FORMULARIO ------------------------------------//
        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        //--------------------------- METODO PARA PRESIONAR ENTER EN EL TEXTBOX -----------------------------//
        private void txt_Acuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btrn_imprimir_Click(sender, e);
            }
        }

        //----------------------------------- METODO PARA CERRAR EL FORMULARIO ------------------------------//
        private void label2_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        //--------------------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA ---------------------//
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
