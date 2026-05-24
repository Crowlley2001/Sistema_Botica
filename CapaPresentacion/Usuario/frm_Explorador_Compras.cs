using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Compras;
using CapaPresentacion.Factura;
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
    public partial class frm_Explorador_Compras : Form
    {
        public frm_Explorador_Compras()
        {
            InitializeComponent();
        }
        private void frm_Explorador_Compras_Load(object sender, EventArgs e)
        {
            Configurar_listView();
            Cargar_Todos_compras();
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
            var lis = lsv_com;

            lsv_com.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            lis.HeaderStyle = ColumnHeaderStyle.None;
            //configurar las columnas:
            lis.Columns.Add("ID Interno", 160, HorizontalAlignment.Left); //0  
            lis.Columns.Add("Nro Fisico", 180, HorizontalAlignment.Left);  //3                     
            lis.Columns.Add("Fecha", 180, HorizontalAlignment.Left);  //4
            lis.Columns.Add("Total S/", 100, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Forma Pago", 0, HorizontalAlignment.Left);  //1
            //lis.Columns.Add("Tipo Ingreso", 100, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Tipo Doc.", 150, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Tipo Registro", 155, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Tipo Operacion", 160, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Estado", 70, HorizontalAlignment.Left);  //1
            lis.Columns.Add("Procedencia", 0, HorizontalAlignment.Left);  //1
            //lis.Columns.Add("procedencia", 219, HorizontalAlignment.Left);  //1

        }

        private void Llenar_Listview(DataTable data)
        {
            lsv_com.Items.Clear();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["Id_DocComp"].ToString());
                list.SubItems.Add(dr["NroFac_Fisico"].ToString());
                list.SubItems.Add(dr["Fecha_Ingre"].ToString());
                list.SubItems.Add(dr["Total_Ingre"].ToString());
                list.SubItems.Add(dr["ModalidadPago"].ToString());
                list.SubItems.Add(dr["TipoDoc_Compra"].ToString());
                list.SubItems.Add(dr["Tiporegistro"].ToString());
                list.SubItems.Add(dr["TipoProceso"].ToString());
                list.SubItems.Add(dr["Estado_Ingre"].ToString());
                list.SubItems.Add(dr["Datos_Adicional"].ToString());
                lsv_com.Items.Add(list); //si no podemos esto., el listview nunca se llenara
            }
            PintasFilas_Compra();
            pnl_compras.Visible = false;
            lbl_totallItem.Text = lsv_com.Items.Count.ToString();
        }

        private void PintasFilas_Compra()
        {
            int cont = 1;

            for (int i = 0; i < lsv_com.Items.Count; i++)
            {
                if (cont % 2 != 0)
                {
                    lsv_com.Items[i].BackColor = Color.WhiteSmoke;
                }

                cont += 1;
            }
        }

        private void Cargar_Todos_compras()
        {
            CN_Compra obj = new CN_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_cargar_Todas_Compras();
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_compras.Visible = true;
            }

        }



        private void buscar_compras(string valor)
        {
            CN_Compra obj = new CN_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_Compras_Explorador(valor);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_compras.Visible = true;
            }

        }


        //por fechas:
        private void buscar_compras_pordia(DateTime fechax)
        {
            CN_Compra obj = new CN_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_Compras_Explorador_Pormes_Dia("dia", fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_compras.Visible = true;
            }

        }

        //por mes:
        private void buscar_compras_porMes(DateTime fechax)
        {
            CN_Compra obj = new CN_Compra();
            DataTable dato = new DataTable();

            dato = obj.RN_buscar_Compras_Explorador_Pormes_Dia("mes", fechax);
            if (dato.Rows.Count > 0)
            {
                Llenar_Listview(dato);
            }
            else
            {
                lsv_com.Items.Clear();
                pnl_compras.Visible = true;
            }

        }

        private void txt_buscarcliente_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscarcliente.Text.Trim().Length > 2)
            {
                buscar_compras(txt_buscarcliente.Text);
            }
        }

        private void txt_buscarcliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_buscarcliente.Text.Trim().Length > 2)
                {
                    buscar_compras(txt_buscarcliente.Text);
                }
                else
                {
                    Cargar_Todos_compras();
                }
            }
        }

        private void bt_copiarIDProveedorTool_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_softmsm ver = new frm_softmsm();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.Lbl_msm.Text = "Selecciona el Item que deseas copiar";
                ver.tipo = "Warning";
                ver.ShowDialog(this);
                fil.Hide();
            }
            else
            {
                var lis = lsv_com.SelectedItems[0];
                string idprovee = lis.SubItems[0].Text;

                Clipboard.Clear();
                Clipboard.SetText(idprovee.Trim());

                ver.Lbl_msm.Text = "ID copiado correctamente";
                ver.tipo = "Good";
                ver.ShowDialog(this);
            }
        }

        private void nuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_EntradasProd com = new frm_EntradasProd();

            fil.Show();
            com.ShowDialog(this);
            fil.Hide();
        }

        private void mostrarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cargar_Todos_compras();
        }

        private void lsv_com_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_Ver_Detalle_Compras edi = new frm_Ver_Detalle_Compras();

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm.Text = "Selecciona el Item";
                ver.ShowDialog(this);
                fil.Hide();
            }
            else
            {
                var lis = lsv_com.SelectedItems[0];
                string idcompra = lis.SubItems[0].Text;

                fil.Show();
                edi.Tag = idcompra;
                edi.ShowDialog(this);
                fil.Hide();
            }
        }

        private void editarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CN_Compra obj = new CN_Compra();
            CN_Producto objpro = new CN_Producto();
            DataTable dato = new DataTable();
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            frm_Si_No sino = new frm_Si_No();
            frm_Eliminar_Guias com = new frm_Eliminar_Guias();

            string idProd = "";
            double stocProd = 0;

            if (lsv_com.SelectedIndices.Count == 0)
            {
                fil.Show();
                ver.lbl_msm.Text = "Selecciona la Compra que Quieres eliminar";
                ver.ShowDialog(this);
                fil.Hide();
            }
            else
            {
                var lis = lsv_com.SelectedItems[0];
                string idcompra = lis.SubItems[0].Text;

                //Abrimos el formulario de eliminación
                fil.Show();
                com.Tag = idcompra;
                com.ShowDialog(this);
                fil.Hide();

                //Aquí estaba el error
                if (com.Tag != null && com.Tag.ToString() == "Si")
                {
                    //Devolver Stock o No
                    fil.Show();
                    sino.lbl_msm.Text = "LEE BIEN POR FAVOR!!! Para Eliminar y Quitar el Stock, Presiona SI, NO para Eliminar sin Quitar Stock";
                    sino.ShowDialog(this);
                    fil.Hide();

                    if (sino.Tag != null && sino.Tag.ToString() == "Si")
                    {
                        //cargar los datos de la compra
                        dato = obj.CN_Buscar_CompraconDetalle(idcompra.Trim());

                        if (dato.Rows.Count > 0)
                        {
                            for (int i = 0; i < dato.Rows.Count; i++)
                            {
                                DataRow dr = dato.Rows[i];
                                idProd = dr["Id_Pro"].ToString();
                                stocProd = Convert.ToDouble(dr["Cantidad"]);

                                objpro.RestarStock_Producto(idProd.Trim(), stocProd);
                            }

                            obj.CN_Eliminar_RegistrarCompra(idcompra.Trim());

                            if (CD_Producto.prod_saved == true)
                            {
                                fil.Show();
                                ok.Lbl_msm1.Text = "La Compra se ha Eliminado, Actualiza tu Ventana";
                                ok.ShowDialog(this);
                                fil.Hide();
                                Cargar_Todos_compras();
                            }
                        }
                    }
                    else
                    {
                        //Eliminar sin devolver stock
                        obj.CN_Eliminar_RegistrarCompra(idcompra.Trim());

                        if (CD_Producto.prod_saved == true)
                        {
                            fil.Show();
                            ok.Lbl_msm1.Text = "La Compra se ha Eliminado, Actualiza tu Ventana";
                            ok.ShowDialog(this);
                            fil.Hide();
                        }
                    }
                }
            }
        }

        private void frm_Explorador_Compras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void buscaComprobanteDelMesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frmSoloMes solo = new frmSoloMes();

            fil.Show();
            solo.ShowDialog(this);
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_mes.Value;

                buscar_compras_porMes(xfecha);
            }
        }

        private void buscarComprobanteDelDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            frm_SoloFecha solo = new frm_SoloFecha();

            fil.Show();
            solo.ShowDialog(this);
            fil.Hide();

            if (solo.Tag.ToString() == "A")
            {
                DateTime xfecha = solo.dtp_fn.Value;

                buscar_compras_pordia(xfecha);
            }
        }
    }
}
