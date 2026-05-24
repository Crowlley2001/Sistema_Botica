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

namespace CapaPresentacion.Factura
{
    public partial class frm_Solo_Usuario : Form
    {
        public frm_Solo_Usuario()
        {
            InitializeComponent();
        }

        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btrn_aceptar_Click(object sender, EventArgs e)
        {
            if (cbo_users.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un usuario",
                    "Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cbo_users.Focus();
                return;
            }

            this.Tag = "A";
            this.Close();
        }

        private void frm_Solo_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Tag = "";
                this.Close();
            }
        }


        private void Cargar_Todos_Usuarios()
        {
            CN_Usuario obj = new CN_Usuario();
            DataTable data = new DataTable();
            data = obj.CN_Cargar_todos_Usuarios();
            if (data.Rows.Count > 0)
            {
                var cbo = cbo_users;
                cbo.DataSource = data;
                cbo.DisplayMember = "Nombres";
                cbo.ValueMember = "Id_Usu";
                cbo.SelectedIndex = -1;
            }
        }

        private void frm_Solo_Usuario_Load(object sender, EventArgs e)
        {
            Cargar_Todos_Usuarios();
            cbo_users.Focus();
            //         FECHA - ACTUAL         //
            dtp_fn_Usu.Value = DateTime.Now;
        }
    }
}
