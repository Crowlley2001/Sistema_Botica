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

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //----------------------------- METODO LOAD LOGIN --------------------------------//
        private void Login_Load(object sender, EventArgs e)
        {
            txt_usuario.Focus();
        }


        //----- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA LLAMADO-----------//
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }


        //----------------------------- METODO CERRAR LOGIN ------------------------------//
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //----------------------------- METODO HACER LOGIN -------------------------------//
        int intento = 0;
        private void HacerLogin()
        {
            CN_Usuario obj = new CN_Usuario();
            DataTable dato = new DataTable();
            string xusu, xpass;
            xusu = txt_usuario.Text.Trim();
            xpass = txt_password.Text.Trim();

           
            if (obj.CN_VerificarAcceso(xusu, xpass) == true)
            {
                dato = obj.CN_BuscarUsuario(xusu);
                if (dato.Rows.Count > 0)
                {
                    Cls_ModalCategoria.IdUsu = Convert.ToInt32(dato.Rows[0]["Id_Usu"]);
                    Cls_ModalCategoria.Nombre = dato.Rows[0]["Nombres"].ToString();
                    Cls_ModalCategoria.Apellido = dato.Rows[0]["Apellidos"].ToString();
                    Cls_ModalCategoria.Idrol = dato.Rows[0]["Id_Rol"].ToString();
                    Cls_ModalCategoria.Foto = dato.Rows[0]["FotoUsu"].ToString();

                
                    if (Cls_ModalCategoria.Idrol == "1")
                        Cls_ModalCategoria.Nomerol = "Administrador";
                    else if (Cls_ModalCategoria.Idrol == "2")
                        Cls_ModalCategoria.Nomerol = "Vendedor";
                }

                Inicio frm = new Inicio();
                this.Hide();
                frm.Show();
                frm.Cargar_DatosUsuarios();
            }
            else
            {
                intento+=1;
                txt_usuario.Text = "";
                txt_password.Text = "";
                MessageBox.Show("¡Acceso Denegado! Usuario o Contraseña Incorrecta." + intento.ToString() + "/3", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (intento == 3)
                {
                    MessageBox.Show("Ha excedido el número máximo de intentos. La aplicación se cerrará: 3/3", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
            }
        }


        //----------------------------- BOTON ENTRAR LOGIN -------------------------------//
        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if(txt_password.Text.Trim().Length == 0) txt_password.Focus();
            if(txt_usuario.Text.Trim().Length == 0) txt_usuario.Focus();

            HacerLogin();
        }


        //----------------- EVENTO ENTER PARA TEXTBOX USUARIO Y PASSWORD -----------------//
        private void txt_usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_password.Focus();
            }
        }



        //-------------- EVENTO ENTER PARA TEXTBOX USUARIO Y PASSWORD --------------------//
        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_cancelar_Click(sender,e);
              
            }
        }
    }
}
