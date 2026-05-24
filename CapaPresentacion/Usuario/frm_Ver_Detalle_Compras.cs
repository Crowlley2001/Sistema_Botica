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
    public partial class frm_Ver_Detalle_Compras : Form
    {
        public frm_Ver_Detalle_Compras()
        {
            InitializeComponent();
        }

        private void frm_Ver_Detalle_Compras_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Buscar_Det_Compras(this.Tag.ToString());
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        private void btn_cerraDetalle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Configurar_listView()
        {
            var lis = lsv_det_Com;

            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            //configurar las columnas:
            lis.Columns.Add("ID", 120, HorizontalAlignment.Left); //0  
            lis.Columns.Add("Id Prod", 125, HorizontalAlignment.Left);  //3
            lis.Columns.Add("Descripcion del Producto", 360, HorizontalAlignment.Left);  //2           
            lis.Columns.Add("Precio", 0, HorizontalAlignment.Left);  //4
            lis.Columns.Add("Cant", 30, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Importe S/", 0, HorizontalAlignment.Left);  //1      
        }


        private void Buscar_Det_Compras(string idcompra)
        {
            CN_Compra obj = new CN_Compra();
            DataTable dato = new DataTable();

            dato = obj.CN_Buscar_CompraconDetalle(idcompra.Trim());

            if (dato.Rows.Count > 0)
            {
                lsv_det_Com.Items.Clear();
                for (int i = 0; i < dato.Rows.Count; i++)
                {
                    DataRow dr = dato.Rows[i];
                    ListViewItem list = new ListViewItem(dr["Id_DocComp"].ToString());
                    list.SubItems.Add(dr["Id_Pro"].ToString());
                    list.SubItems.Add(dr["Descripcion_Larga"].ToString());
                    list.SubItems.Add(dr["PrecioUnit"].ToString());
                    list.SubItems.Add(dr["Cantidad"].ToString());
                    list.SubItems.Add(dr["Importe"].ToString());

                    lsv_det_Com.Items.Add(list); //si no podemos esto., el listview nunca se llenara
                }

            }
        }

    }
}
