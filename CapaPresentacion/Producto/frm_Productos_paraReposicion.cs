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

                // La alerta crítica debe permanecer visible mientras la ventana
                // esté abierta. También incluye existencias negativas.
                decimal stock;
                decimal.TryParse(Convert.ToString(row["Stock_Actual"]), out stock);
                if (stock <= 0)
                {
                    item.UseItemStyleForSubItems = true;
                    item.BackColor = Color.FromArgb(255, 226, 226);
                    item.ForeColor = Color.FromArgb(183, 28, 28);
                    item.Font = new Font(lsv_reposicion.Font, FontStyle.Bold);

                    // KryptonListView puede repintar cada subelemento; aplicar
                    // el estilo a todos evita que la alerta desaparezca.
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    {
                        subItem.BackColor = item.BackColor;
                        subItem.ForeColor = item.ForeColor;
                        subItem.Font = item.Font;
                    }
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
