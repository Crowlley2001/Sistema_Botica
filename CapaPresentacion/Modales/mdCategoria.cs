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

namespace CapaPresentacion.Modales
{
    public partial class mdCategoria : Form
    {
        public mdCategoria()
        {
            InitializeComponent();
        }
        //---------------------- METODO PARA MOVERFORMULARIO DESDE EL CLS_MODALCATEGORIA LLAMADO -------------------//
        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }


        //----------------------------- METODO LLAMAR CONFIGURAR Y CARGAR CATEGORIAS -------------------------------//
        private void mdCategoria_Load(object sender, EventArgs e)
        {
            Configura_ListView();
            Cargar_Categorias();
        }


        //------------------------------------ METODO CONFIGURAR CATEGORIAS ----------------------------------------//
        private void Configura_ListView()
        {
            var lis = lsv_Cat;
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HideSelection = false;
            //Aqui se agregan las columnas de nuestro ListView
            lis.Columns.Add("ID", 70, HorizontalAlignment.Left);
            lis.Columns.Add("Categoria", 353, HorizontalAlignment.Left);
        }


        //----------------------------------- METODO LLENAR LISTA CATEGORIAS ---------------------------------------//
        private void llenar_ListView( DataTable data)
        {
            lsv_Cat.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dataRow = data.Rows[i];
                ListViewItem list = new ListViewItem(dataRow["Id_Cat"].ToString());
                list.SubItems.Add(dataRow["Categoria"].ToString());
                lsv_Cat.Items.Add(list);
            }
        }


        //--------------------------------------- METODO LSITAR CATEGORIAS------------------------------------------//
        private void Cargar_Categorias()

        {
            CN_Categoria objCateg = new CN_Categoria();
            DataTable data = new DataTable();
            data = objCateg.ListarCategorias();
            if (data.Rows.Count > 0)
            {
                llenar_ListView(data);
            }
            else
            {
                lsv_Cat.Items.Clear();
            }

        }


        //---------------------------- METODO ACTIVAR NUEVA CATEGORIA DESDE EL LABEL -------------------------------//
        private void lbl_new_Click(object sender, EventArgs e)
        {
            pnl_reg.Enabled = true;
            txt_catg.Focus();
        }


        //------------------------------------- METODO REGISTRAR CATEGORIAS ----------------------------------------//

        private bool tipo = false; //false = nuevo, true = editar
        private void btn_save_Click(object sender, EventArgs e)
        {
            CN_Categoria objCateg = new CN_Categoria();
            if (tipo == false)
            {
                if (txt_catg.Text.Trim().Length == 0)
                {
                    txt_catg.Focus(); return;
                }
                objCateg.RegistrarCategoria(txt_catg.Text);
                Cargar_Categorias();
                txt_catg.Text = "";
                pnl_reg.Enabled = false;
            }
            //-------------------------------- METODO EDITAR CATEGORIAS --------------------------------//
            else
            {
                if (txt_catg.Text.Trim().Length == 0)
                {
                    txt_catg.Focus(); return;
                }

                objCateg.EditarCategoria(Convert.ToInt32(txt_id.Text), txt_catg.Text);
                Cargar_Categorias();
                txt_catg.Text = "";
                txt_id.Text = "";
                pnl_reg.Enabled = false;

            }
        }


        //------------------------------------- METODO DOBLECLIK CATEGORIAS ---------------------------------------//
        private void lsv_Cat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsv_Cat.SelectedIndices.Count == 0) return;
            var lis = lsv_Cat.SelectedItems[0];
            txt_id.Text = lis.SubItems[0].Text;
            txt_catg.Text = lis.SubItems[1].Text;
            pnl_reg.Enabled = true;
            tipo = true; //editar
            txt_catg.Focus();
        }


        //-------------------------------------- METODO GUARDAR CON ENTER -----------------------------------------//
        private void txt_catg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.PerformClick();
            }
        }


        //-------------------------------------- METODO CERRAR CATEGORIAS -----------------------------------------//
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
