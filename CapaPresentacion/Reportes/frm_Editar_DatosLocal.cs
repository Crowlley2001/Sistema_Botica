using CapaNegocio;
using CapaPresentacion.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Reportes
{
    public partial class frm_Editar_DatosLocal : Form
    {
        string rutaLogo = "";
        public frm_Editar_DatosLocal()
        {
            InitializeComponent();
            txt_claveSOL.UseSystemPasswordChar = true;
            txt_certificado.UseSystemPasswordChar = true;
        }

        private void frm_Editar_DatosLocal_Load(object sender, EventArgs e)
        {
            CN_Empresa obj = new CN_Empresa();
            DataTable dt = obj.MostrarDatosEmpresa();

            if (dt.Rows.Count > 0)
            {
                txt_nombre.Text = dt.Rows[0]["nombreRancho"].ToString();
                txt_ruc.Text = dt.Rows[0]["nroRuc"].ToString();
                txt_direccion.Text = dt.Rows[0]["Direccionran"].ToString();
                txt_correo.Text = dt.Rows[0]["correo"].ToString();
                txt_usuarioSOL.Text = dt.Rows[0]["usuariosol"].ToString();
                txt_claveSOL.Text = dt.Rows[0]["clavesol"].ToString();
                txt_certificado.Text = dt.Rows[0]["clavecertificado"].ToString();

                rutaLogo = dt.Rows[0]["obs"].ToString();

                if (!string.IsNullOrEmpty(rutaLogo))
                {
                    Circule_Logo.Image = CargarImagenSinBloqueo(rutaLogo);
                }
            }
        }

        private void btn_Listo_Click(object sender, EventArgs e)
        {
            CN_Empresa obj = new CN_Empresa();

            obj.EditarDatosEmpresa(
                txt_nombre.Text,
                txt_ruc.Text,
                txt_direccion.Text,
                txt_correo.Text,
                txt_usuarioSOL.Text,
                txt_claveSOL.Text,
                txt_certificado.Text,
                rutaLogo
            );

            Filtro fill = new Filtro();
            frm_Msm_bueno ok = new frm_Msm_bueno();

            fill.Show();
            ok.Lbl_msm1.Text = "Datos del negocio guardados correctamente";
            ok.ShowDialog(this);
            fill.Hide();
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
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_buscarLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Imagenes|*.jpg;*.png;*.jpeg";

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                
                string carpetaDestino = Path.Combine(Application.StartupPath, "Resources");
                if (!Directory.Exists(carpetaDestino)) Directory.CreateDirectory(carpetaDestino);

                string nombreArchivo = "logo_empresa" + Path.GetExtension(abrir.FileName);
                string rutaFinal = Path.Combine(carpetaDestino, nombreArchivo);
                File.Copy(abrir.FileName, rutaFinal, true);
                rutaLogo = rutaFinal; 
                Circule_Logo.Image = CargarImagenSinBloqueo(rutaLogo);
            }
        }

        private Image CargarImagenSinBloqueo(string ruta)
        {
            if (!File.Exists(ruta)) return null;

            using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(ruta)))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
