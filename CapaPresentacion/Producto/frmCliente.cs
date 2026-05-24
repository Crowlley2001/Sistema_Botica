using CapaEntidad;
using CapaNegocio;
using CapaDatos;
using Guna.UI2.WinForms;
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
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        private void frmCliente_Load_1(object sender, EventArgs e)
        {
            //         FECHA - ACTUAL         //
            dtp_fechanaci.Value = DateTime.Now;
        }

        //----------------------- METODO GENERAR ID CLIENTE---------------------------//
        private string GenerarIdCliente(string estadox)
        {
            CN_Cliente obj_Cliente = new CN_Cliente();
            DataTable dt = new DataTable();

            dt = obj_Cliente.Vertodos_los_Clientes(estadox);
            string idcliente = "";
            string nroextraido = txt_dni.Text.Substring(1, 6);

            if (dt.Rows.Count > 0)
            {
                idcliente = "C-" + nroextraido + (dt.Rows.Count + 1);
            }
            else
            {
                idcliente = "C-" + nroextraido + "1";
            } 
            return idcliente;

        }

        //------------ METODO MOVER FORMULARIO DESDE EL Cls_ModalCategoria------------//
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }

        //------------------------ METODO CERRAR CLIENTE------------------------------//
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        //------------------------ METODO GUARDAR CLIENTE-----------------------------//
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;
            Registrar_cliente();
        }

        //----------------------- METODO REGISTRAR CLIENTE----------------------------//
        private void Registrar_cliente()
        {
            CN_Cliente obj = new CN_Cliente();
            Cliente cli = new Cliente();

            try
            {
                cli.Idcliente = txt_idcliente.Text;
                cli.Nombre = txt_nombre.Text;
                cli.Dniruc = txt_dni.Text;
                cli.Direccion = txt_direccion.Text;
                cli.Email = txt_mail.Text;
                cli.FechaAniver = dtp_fechanaci.Value;
                cli.Telefono = txt_tel.Text;

                obj.Registrar_Cliente(cli);

                if (CD_Cliente.cli_saved == true)
                {
                    MessageBox.Show("El Cliente se ha registrado correctamente",
                        "Registro cliente form",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Tag = "A";   
                    this.Close();     
                }

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Registro de Cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        //------------------------- METODO VALIDAR CAMPOS-----------------------------//
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txt_nombre.Text))
            {
                MessageBox.Show("Ingrese el nombre del cliente");
                txt_nombre.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txt_mail.Text) &&
                !txt_mail.Text.Contains("@"))
            {
                MessageBox.Show("Ingrese un correo válido");
                txt_mail.Focus();
                return false;
            }

            if (!long.TryParse(txt_tel.Text, out _) && txt_tel.Text.Length > 0)
            {
                MessageBox.Show("El teléfono solo debe contener números");
                txt_tel.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_idcliente.Text))
            {
                MessageBox.Show("El ID del cliente no se ha generado");
                txt_idcliente.Focus();
                return false;
            }

            return true;
        }

        //----------------------------- METODO LIMPIAR--------------------------------//
        private void Limpiar()
        {
            // TextBox
            txt_idcliente.Clear();
            txt_nombre.Clear();
            txt_dni.Clear();
            txt_direccion.Clear();
            txt_mail.Clear();
            txt_tel.Clear();

            // Fecha
            dtp_fechanaci.Value = DateTime.Now;
            dtp_fechanaci.Enabled = false;

            // Foco inicial
            txt_nombre.Focus();
        }
        //----------------------------- METODO CANCELAR-------------------------------//
    

        //---------------- METODO GENERAR ID DE TODOS LOS CLIENTES--------------------//
        private void txt_dni_TextChanged(object sender, EventArgs e)
        {
            if (txt_dni.Text.Trim().Length > 7)
            {
                txt_idcliente.Text = GenerarIdCliente("Todos");
            }
            else if (txt_dni.Text.Trim().Length == 0)
            {
                txt_idcliente.Text = "";
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_limpiar_cliente_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
