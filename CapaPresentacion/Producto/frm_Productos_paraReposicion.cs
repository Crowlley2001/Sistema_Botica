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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CapaPresentacion.Producto
{
    public partial class frm_Productos_paraReposicion : Form
    {
        public frm_Productos_paraReposicion()
        {
            InitializeComponent();
        }

        private void frm_Productos_paraReposicion_Load(object sender, EventArgs e)
        {
            ConfigurarListView();
            CargarProductosReposicion();
        }

        private void ConfigurarListView()
        {
            lsv_reposicion.View = View.Details;
            lsv_reposicion.Columns.Clear();

            lsv_reposicion.Columns.Add("Código", 200);
            lsv_reposicion.Columns.Add("Producto", 200);
            lsv_reposicion.Columns.Add("Stock", 150);
            lsv_reposicion.Columns.Add("Stock Mínimo", 150);
            lsv_reposicion.Columns.Add("Comprar", 150);
        }
        private void CargarProductosReposicion()
        {
            CN_Producto obj = new CN_Producto();
            DataTable dt = obj.CN_ProductosReposicion();

            lsv_reposicion.Items.Clear();
            int contador = 0;

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["Id_Pro"].ToString());
                item.SubItems.Add(row["Descripcion_Larga"].ToString());
                item.SubItems.Add(row["Stock_Actual"].ToString());
                item.SubItems.Add(row["Und_Min"].ToString());
                item.SubItems.Add(row["CantidadComprar"].ToString());

                // 🔥 Color si necesita urgente
                int stock = Convert.ToInt32(row["Stock_Actual"]);
                if (stock == 0)
                {
                    item.BackColor = Color.Red;
                    item.ForeColor = Color.White;
                }

                lsv_reposicion.Items.Add(item);
                contador++;
            }
            lblTotalReposicion.Text = contador.ToString();
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    
}
