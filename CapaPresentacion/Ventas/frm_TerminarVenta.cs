using CapaPresentacion.Modales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        public string NroOperacion = "";
        public string CodigoMoneda = "PEN";
        public decimal TipoCambio = 1m;
        private void frm_TerminarVenta_Load(object sender, EventArgs e)
        {
            label3.Text = CodigoMoneda == "USD"
                ? "Total venta US$"
                : "Total venta S/.";

            if (PasarelaPagoManual.EsEfectivo(TipoPago))
            {
                pnl_tarjeta.Visible = false;
            }
            else
            {
                pnl_tarjeta.Visible = true;
                label2.Text = TipoPago;
                lbl_msm.Text = "Operación: " + NroOperacion;
                decimal total;
                if (TryLeerImporte(txt_Total_acobrar.Text, out total))
                    txt_Acuenta.Text = total.ToString("0.00");
                txt_Acuenta.ReadOnly = true;
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
            decimal pagaCon;
            decimal total;
            if (TryLeerImporte(txt_Acuenta.Text, out pagaCon) &&
                TryLeerImporte(txt_Total_acobrar.Text, out total))
            {
                decimal vuelto = pagaCon - total;
                txt_vuelto.Text = vuelto.ToString("0.00");
            }
            else
            {
                txt_vuelto.Text = "0.00";
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
            decimal total;
            decimal pago;
            if (!TryLeerImporte(txt_Total_acobrar.Text, out total) ||
                !TryLeerImporte(txt_Acuenta.Text, out pago))
            {
                MessageBox.Show(
                    "Ingrese un importe de pago válido.",
                    "Validación de cobro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txt_Acuenta.Focus();
                return;
            }

            if (PasarelaPagoManual.EsEfectivo(TipoPago) &&
                pago < total)
            {
                MessageBox.Show(
                    "El importe recibido no puede ser menor que el total de la venta.",
                    "Validación de cobro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txt_Acuenta.Focus();
                return;
            }

            if (!PasarelaPagoManual.EsEfectivo(TipoPago))
            {
                DialogResult confirmacion = MessageBox.Show(
                    "Verifique los datos antes de registrar la venta:\n\n" +
                    "Método: " + TipoPago + "\n" +
                    "Operación: " + NroOperacion + "\n" +
                    "Importe: " + CodigoMoneda + " " + total.ToString("0.00") +
                    "\n\n¿El pago figura como aprobado en el POS o aplicación?",
                    "Confirmar pago electrónico",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (confirmacion != DialogResult.Yes)
                    return;
            }

            this.Tag = "A";
            this.Close();
        }

        private static bool TryLeerImporte(string texto, out decimal importe)
        {
            string valor = (texto ?? string.Empty).Trim();
            return decimal.TryParse(
                       valor,
                       NumberStyles.Number,
                       CultureInfo.CurrentCulture,
                       out importe) ||
                   decimal.TryParse(
                       valor.Replace(',', '.'),
                       NumberStyles.Number,
                       CultureInfo.InvariantCulture,
                       out importe);
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
