using CapaDatos;
using CapaEntidad;
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

namespace CapaPresentacion.Usuario
{
    public partial class frm_Editar_Cliente : Form
    {
        public string idcliente = "";
        public frm_Editar_Cliente()
        {
            InitializeComponent();
        }
        private void frm_Editar_Cliente_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(idcliente))
            {
                Cargar_Datos_Cliente();
            }
            //         FECHA - ACTUAL         //
            dtp_fechanaci.Value = DateTime.Now;
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
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Actualizar_Cliente();
        }

        private void Actualizar_Cliente()
        {
            CN_Cliente obj = new CN_Cliente();
            Cliente cli = new Cliente();

            cli.Idcliente = txt_idcliente.Text;
            cli.Nombre = txt_nombre.Text;
            cli.Dniruc = txt_dni.Text;
            cli.Direccion = txt_direccion.Text;
            cli.Email = txt_mail.Text;
            cli.Telefono = txt_tel.Text;
            cli.FechaAniver = dtp_fechanaci.Value;

            obj.Editar_Cliente(cli);

            if (CD_Cliente.cli_saved == true)
            {
                MessageBox.Show("Cliente actualizado correctamente");

                this.Tag = "A";
                this.Close();
            }
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
