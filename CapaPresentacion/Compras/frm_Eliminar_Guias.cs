using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Compras
{
    public partial class frm_Eliminar_Guias : Form
    {
        public frm_Eliminar_Guias()
        {
            InitializeComponent();
        }

  
        private void frm_Eliminar_Guias_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Buscar_Compra_paraEliminar(this.Tag.ToString());
            //         FECHA - ACTUAL         //
            dtp_fechadoc.Value = DateTime.Now;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }

        private void Configurar_listView()
        {
            var lis = lsv_elimicompra;
            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = true;
            lis.FullRowSelect = true;
            lis.HideSelection = false;
            lis.HeaderStyle = ColumnHeaderStyle.None;
            //configurar las columnas:
            lis.Columns.Add("ID producto", 120, HorizontalAlignment.Left); //0
            lis.Columns.Add("Descripcion producto", 425, HorizontalAlignment.Left);  //1
            lis.Columns.Add("cantidad", 60, HorizontalAlignment.Center);  //1
            lis.Columns.Add("Compra", 90, HorizontalAlignment.Center);  //1
            lis.Columns.Add("Importe", 90, HorizontalAlignment.Center);  //1
            lis.Columns.Add("Venta", 96, HorizontalAlignment.Center);  //1
        }

        public void Buscar_Compra_paraEliminar(string Nro_Doc)
        {
            DataTable dataTable = new DataTable();
            CN_Compra obj = new CN_Compra();
            Filtro filtro = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_Msm_bueno ok = new frm_Msm_bueno();

            try
            {
                dataTable = obj.CN_Buscar_CompraconDetalle(Nro_Doc);
                if (dataTable.Rows.Count > 0)
                {
                    txt_nroDoc.Text = dataTable.Rows[0]["Id_DocComp"].ToString();
                    lsv_elimicompra.Items.Clear();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        ListViewItem list;
                        list = new ListViewItem(dr["Id_Pro"].ToString(), 0);
                        {
                            var withBlock = list;
                            withBlock.SubItems.Add(dr["Descripcion_Larga"].ToString());
                            withBlock.SubItems.Add(dr["Cantidad"].ToString());
                            withBlock.SubItems.Add(dr["PrecioUnit"].ToString());
                            withBlock.SubItems.Add(dr["Importe"].ToString());
                            withBlock.SubItems.Add(dr["preventa"].ToString());
                            lsv_elimicompra.Items.Add(list);
                        }
                    }
                    Calcular();
                    pnl_Compra.Visible = false;
                    btn_EliminarCompra.Enabled = true;
                }
                else
                {
                    filtro.Show();
                    ver.lbl_msm.Text = "No se encontró la compra con el número de documento proporcionado.";
                    ver.ShowDialog(this);
                    filtro.Hide();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Calcular()
        {
            double xtotal = 0;
            double xcant = 0;
            double xpreciocompra = 0;
            double ximportecompra = 0;
            double xsubtotal = 0;
            double xigv = 0;

            for (int i = 0; i < lsv_elimicompra.Items.Count; i++)
            {
                xcant = Convert.ToDouble(lsv_elimicompra.Items[i].SubItems[2].Text);
                xpreciocompra = Convert.ToDouble(lsv_elimicompra.Items[i].SubItems[3].Text);

                //calculo del IMporte de Compra:
                ximportecompra = xpreciocompra * xcant;
                lsv_elimicompra.Items[i].SubItems[4].Text = ximportecompra.ToString("###0.00");

                //caluclo del total:
                xtotal = xtotal + Convert.ToDouble(lsv_elimicompra.Items[i].SubItems[4].Text);

            }
            //calcular el IGV: IVA
            xsubtotal = xtotal / 1.18;
            xigv = xtotal - xsubtotal;

            txt_subtotalCompra.Text = xsubtotal.ToString("###0.00");
            txt_igvCompra.Text = xigv.ToString("###0.00");
            txt_totalpagarCompra.Text = xtotal.ToString("###0.00");

        }

        private void btn_EliminarCompra_Click(object sender, EventArgs e)
        {
            Filtro filtro = new Filtro();
            frm_Si_No sino = new frm_Si_No();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            frm_Advertencia ver = new frm_Advertencia();
            CN_Compra obj = new CN_Compra();

            filtro.Show();
            sino.lbl_msm.Text = "¿Está seguro de eliminar esta compra?";
            sino.ShowDialog(this);
            filtro.Hide();

            if (sino.Tag != null && sino.Tag.ToString() == "Si")
            {
                Registrar_MoviemtoKardex();
                obj.CN_Eliminar_RegistrarCompra(txt_nroDoc.Text);
                ok.Lbl_msm1.Text = "La compra se eliminó correctamente.";
                ok.ShowDialog(this);
                this.Close();
            }
             else
            {
                ver.lbl_msm.Text = "La compra no se eliminó.";
                ver.ShowDialog(this);
            }


        }

        private void Registrar_MoviemtoKardex()
        {
            CN_Kardex obj = new CN_Kardex();
            Detalle_Kardex kar = new Detalle_Kardex();
            CN_Producto objpro = new CN_Producto();
            DataTable dato = new DataTable();
            DataTable datoprod = new DataTable();

            string xidkardex = "";
            int xitem = 0;
            double stockProd = 0;
            double precioCompraProd = 0;

            string idprod = "";
            string nomprod = "-";
            double xcant = 0;
            double xpreCompra = 0;

            try
            {
                for (int i = 0; i <= lsv_elimicompra.Items.Count - 1; i++)
                {
                    idprod = lsv_elimicompra.Items[i].SubItems[0].Text;
                    xcant = Convert.ToDouble(lsv_elimicompra.Items[i].SubItems[2].Text);
                    xpreCompra = Convert.ToDouble(lsv_elimicompra.Items[i].SubItems[2].Text);
                    nomprod = lsv_elimicompra.Items[i].SubItems[1].Text;

                    if (obj.Verificar_Kardex_Producto(idprod) == true)
                    {
                        //si tiene kardex es valido:
                        dato = obj.BuscarKardexPorValor(idprod.Trim());
                        if (dato.Rows.Count > 0)
                        {
                            xidkardex = Convert.ToString(dato.Rows[0]["Id_krdx"]);
                            xitem = dato.Rows.Count;
                            //leemos los datos del producto:
                            datoprod = objpro.BuscarProductoID(idprod.Trim());
                            stockProd = Convert.ToDouble(datoprod.Rows[0]["Stock_Actual"]);
                            precioCompraProd = Convert.ToDouble(datoprod.Rows[0]["Pre_CompraS"]);

                            //registramos el Detalle del Kardex:
                            kar.IdKardex = xidkardex;
                            kar.Item = xitem + 1;
                            kar.Doc_soporte = txt_nroDoc.Text;
                            kar.Det_Operacion = "Eliminar Guia de Compra";
                            //Entrada:
                            kar.Cantidad_In = 0;
                            kar.Precio_In = 0;
                            kar.Total_In = 0;
                            //salida:
                            kar.Cantidad_Out = xcant;
                            kar.Precio_Out = xpreCompra;
                            kar.Total_Out = xcant * xpreCompra;
                            //saldos:
                            kar.Cantidad_saldo = stockProd - xcant;
                            kar.Promedio = xpreCompra;
                            kar.Total_saldo = xpreCompra * kar.Cantidad_saldo;
                            kar.Idusu = Convert.ToInt32(Cls_ModalCategoria.IdUsu);
                            kar.Tipo_operacion = "Eliminacion";
                            kar.Cant_diferencial = "-";
                            kar.ImporteDiferente = 0;

                            obj.Registrar_DetalleKardex(kar);

                            //ahora acrtalizamos nuestro stock de la tabla productos:
                            objpro.RestarStock_Producto(idprod.Trim(), xcant);
                        }
                        else
                        {
                            MessageBox.Show("El Producto: " + nomprod + " No Tiene Kardex", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Producto: " + nomprod + " No Tiene Kardex", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
