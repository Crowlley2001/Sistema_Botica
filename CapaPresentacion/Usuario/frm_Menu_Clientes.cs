using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Producto;
using CapaPresentacion.Ventas;
using MSistemaBotica_C.Utilitarios;
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
    public partial class frm_Menu_Clientes : Form
    {
        public frm_Menu_Clientes()
        {
            InitializeComponent();
        }

        private void frm_Menu_Clientes_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_clientes();
            lsv_cli.ContextMenuStrip = contextMenuClienteStrip1;
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Configurar_listView()
        {
            var lis = lsv_cli;

            lsv_cli.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            lis.HeaderStyle = ColumnHeaderStyle.None;
            //configurar las columnas:
            lis.Columns.Add("ID", 145, HorizontalAlignment.Center); //0          
            lis.Columns.Add("Nombre del Cliente", 210, HorizontalAlignment.Left);  //2
            lis.Columns.Add("dni", 125, HorizontalAlignment.Center);  //3
            lis.Columns.Add("Direccion", 250, HorizontalAlignment.Left);  //4
            lis.Columns.Add("telefono", 142, HorizontalAlignment.Left);  //1           
            lis.Columns.Add("Correo Electronico", 160, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Estado", 100, HorizontalAlignment.Right);  //1          

        }

        private void Llenar_Listview(DataTable data)
        {
            lsv_cli.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_Cliente"].ToString());
                list.SubItems.Add(dr["Razon_Social_Nombres"].ToString());
                list.SubItems.Add(dr["DNI"].ToString());
                list.SubItems.Add(dr["Direccion"].ToString());
                list.SubItems.Add(dr["Telefono"].ToString());
                list.SubItems.Add(dr["E_Mail"].ToString());
                list.SubItems.Add(dr["Estado_Cli"].ToString());
                lsv_cli.Items.Add(list); //si no podemos esto., el listview nunca se llenara
            }
            PintasFilas_Cliente();
            pnl_msm.Visible = false;
            lbl_totallItem.Text = lsv_cli.Items.Count.ToString();
        }


        private void PintasFilas_Cliente()
        {
            int cont = 1;

            for (int i = 0; i < lsv_cli.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    lsv_cli.Items[i].BackColor = Color.WhiteSmoke;
                }

                cont += 1;
            }
        }

        private void Cargar_Todos_clientes()
        {
            CN_Cliente obj = new CN_Cliente();
            DataTable dato = new DataTable();

            dato = obj.Vertodos_los_Clientes("Activo");
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_cli.Items.Clear();
                pnl_msm.Visible = true;
            }

        }

        private void buscar_cliente(string valor)
        {
            CN_Cliente obj = new CN_Cliente();
            DataTable dato = new DataTable();

            dato = obj.Buscar_Clientes_PorValor(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_cli.Items.Clear();
                pnl_msm.Visible = true;
            }
        }

        private void txt_buscarcliente_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscarcliente.Text.Trim().Length > 2)
            {
                buscar_cliente(txt_buscarcliente.Text);
            }
        }

        private void txt_buscarcliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscarcliente.Text.Trim().Length > 2)
                {
                    buscar_cliente(txt_buscarcliente.Text);
                }
                else
                {
                    Cargar_Todos_clientes();
                }

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frmCliente ad = new frmCliente();

            fil.Show();
            ad.ShowDialog(this);
            fil.Hide();

            if (ad.Tag != null && ad.Tag.ToString() == "A")
            {
                Cargar_Todos_clientes();
            }
        }

      
        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frmCliente ad = new frmCliente();


            fil.Show();
            ad.ShowDialog(this);
            fil.Hide();

            if (ad.Tag.ToString() == "A")
            {
                Cargar_Todos_clientes();
            }
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_editar_Click(sender, e);
        }
        private void btn_editar_Click(object sender, EventArgs e)
        {

          btn_Copiar_Click(sender, e);

        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_clientes();
        }


        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_softmsm ver = new frm_softmsm();

            if (lsv_cli.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm.Text = "Selecciona el Item que deseas copiar";
                ver.tipo = "Warning";
                ver.ShowDialog(this);
                fil.Hide();
            }
            else
            {
                var lis = lsv_cli.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());

                ver.Lbl_msm.Text = "ID copiado correctamente";
                ver.tipo = "Good";
                ver.ShowDialog(this);
            }
        }

        private void lsv_cli_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lsv_cli.GetItemAt(e.X, e.Y);

                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }

        private void lsv_cli_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (lsv_cli.SelectedItems.Count > 0)
                {
                    Clipboard.SetText(lsv_cli.SelectedItems[0].SubItems[0].Text);
                }
            }
        }

        private void lbl_buscarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_buscarcliente.Text))
            {
                MessageBox.Show("Ingrese un dato para buscar");

                txt_buscarcliente.Focus();
                Cargar_Todos_clientes();
                return;
            }

            CN_Cliente obj = new CN_Cliente();
            DataTable dato = obj.Buscar_Clientes_PorValor(txt_buscarcliente.Text);

            // Validar si no encontró resultados
            if (dato.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados, mostrando todos los clientes");

                Cargar_Todos_clientes();
                return;
            }

            Llenar_Listview(dato);
        }

        private void btn_Copiar_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();

            if (lsv_cli.SelectedItems.Count == 0)
            {
                fil.Show();
                ver.lbl_msm.Text = "Selecciona el Item que deseas Editar";
                ver.ShowDialog(this);
                fil.Hide();
            }
            else
            {
                var lis = lsv_cli.SelectedItems[0];
                string idclie = lis.SubItems[0].Text;

                frm_Editar_Cliente edi = new frm_Editar_Cliente();
                edi.idcliente = idclie;

                fil.Show();
                edi.ShowDialog(this);
                fil.Hide();

                if (edi.Tag != null && edi.Tag.ToString() == "A")
                {
                    Cargar_Todos_clientes();
                }
            }
        }
    }
}
