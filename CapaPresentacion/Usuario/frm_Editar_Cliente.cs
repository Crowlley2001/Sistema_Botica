using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Usuario
{
    public partial class frm_Editar_Cliente : Form
    {
        public string idcliente = "";
        public frm_Editar_Cliente()
        {
            InitializeComponent();
            txt_dni.MaxLength = 11;
            txt_dni.ReadOnly = false;
            txt_dni.Enabled = true;
            txt_dni.PlaceholderText = "DNI (8) o RUC (11)";
            txt_dni.KeyPress += txt_dni_KeyPress;
            txt_dni.DoubleClick += delegate { txt_dni.SelectAll(); };
        }
        private void frm_Editar_Cliente_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idcliente))
            {
                Cargar_Datos_Cliente();
            }
        }
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cargar_Datos_Cliente()
        {
            CN_Cliente obj = new CN_Cliente();
            DataTable dt = new DataTable();

            dt = obj.Buscar_Clientes_PorValor(idcliente);

            if (dt.Rows.Count > 0)
            {
                txt_idcliente.Text = dt.Rows[0]["Id_Cliente"].ToString();
                txt_nombre.Text = dt.Rows[0]["Razon_Social_Nombres"].ToString();
                txt_dni.Text = dt.Rows[0]["DNI"].ToString();
                txt_direccion.Text = dt.Rows[0]["Direccion"].ToString();
                txt_tel.Text = dt.Rows[0]["Telefono"].ToString();
                txt_mail.Text = dt.Rows[0]["E_Mail"].ToString();
                DateTime fecha;
                if (DateTime.TryParse(
                    Convert.ToString(dt.Rows[0]["Fcha_Ncmnto_Anivsrio"]), out fecha))
                {
                    dtp_fechanaci.Value = fecha;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Actualizar_Cliente();
        }

        private void Actualizar_Cliente()
        {
            if (!ValidarCliente())
                return;

            CN_Cliente obj = new CN_Cliente();
            Cliente cli = new Cliente();

            cli.Idcliente = txt_idcliente.Text;
            cli.Nombre = txt_nombre.Text;
            cli.Dniruc = txt_dni.Text;
            cli.Direccion = txt_direccion.Text;
            cli.Email = txt_mail.Text;
            cli.Telefono = txt_tel.Text;
            cli.FechaAniver = dtp_fechanaci.Value;

            try
            {
                obj.Editar_Cliente(cli);

                if (CD_Cliente.cli_saved == true)
                {
                    Filtro filtro = new Filtro();
                    frm_Msm_bueno ok = new frm_Msm_bueno();
                    filtro.Show();
                    ok.Lbl_msm1.Text = "El cliente fue actualizado correctamente.";
                    ok.ShowDialog(this);
                    filtro.Hide();

                    this.Tag = "A";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MostrarAdvertencia("No se pudo actualizar el cliente: " + ex.Message);
            }
        }

        private bool ValidarCliente()
        {
            if (txt_nombre.Text.Trim().Length < 2)
            {
                MostrarAdvertencia("Ingrese el nombre o razón social del cliente.");
                txt_nombre.Focus();
                return false;
            }

            string documento = new string(txt_dni.Text.Where(char.IsDigit).ToArray());
            if (documento.Length != 8 && documento.Length != 11)
            {
                MostrarAdvertencia("Ingrese un DNI de 8 dígitos o un RUC de 11 dígitos.");
                txt_dni.Focus();
                return false;
            }

            if (documento.Length == 11 && !ValidadorDocumentoPeru.EsRucValido(documento))
            {
                MostrarAdvertencia("El RUC ingresado no es válido.");
                txt_dni.Focus();
                return false;
            }

            txt_dni.Text = documento;
            return true;
        }

        private void txt_dni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void MostrarAdvertencia(string mensaje)
        {
            Filtro filtro = new Filtro();
            frm_Advertencia advertencia = new frm_Advertencia();
            filtro.Show();
            advertencia.lbl_msm.Text = mensaje;
            advertencia.ShowDialog(this);
            filtro.Hide();
        }
        private void Limpiar_Cliente()
        {

            txt_nombre.Text = "";
            txt_dni.Text = "";
            txt_direccion.Text = "";
            txt_tel.Text = "";
            txt_mail.Text = "";

            dtp_fechanaci.Value = DateTime.Now;

            txt_nombre.Focus();
        }
        private void btn_limpiar_editarcliente_Click(object sender, EventArgs e)
        {
            Limpiar_Cliente();
        }
    }
}
