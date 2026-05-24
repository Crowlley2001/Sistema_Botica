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
    public partial class frm_Mes_Doc : Form
    {
        public frm_Mes_Doc()
        {
            InitializeComponent();
            Cargar_TipoDoc();
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
            this.Tag = "A";
            this.Close();
        }

        private void Cargar_TipoDoc()
        {
            cbo_tipoDoC.DataSource = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Factura"),
                new KeyValuePair<int, string>(2, "Boleta"),
                new KeyValuePair<int, string>(3, "Nota Venta")
            };

            cbo_tipoDoC.DisplayMember = "Value";
            cbo_tipoDoC.ValueMember = "Key";
            cbo_tipoDoC.SelectedIndex = 0;
        }

        private void frm_Mes_Doc_Load(object sender, EventArgs e)
        {
            //         FECHA - ACTUAL         //
            dtp_mes.Value = DateTime.Now;
        }
    }
}
