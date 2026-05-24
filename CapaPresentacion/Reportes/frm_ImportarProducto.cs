using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace CapaPresentacion.Reportes
{
    public partial class frm_ImportarProducto : Form
    {
        public frm_ImportarProducto()
        {
            InitializeComponent();
        }

        private void frm_ImportarProducto_Load(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        private void btn_Listo_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog1.FileName;
                txt_ruta.Text = FileName;

                if (txt_ruta.Text.Length > 0)
                {
                    MessageBox.Show("Archivo cargado correctamente", "Importar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (txt_book.Text.Length == 0)
                {
                    MessageBox.Show("Debe ingresar el nombre de la hoja", "Importar Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Importar_Excel
                Importar_Excel(txt_ruta.Text.Trim(), txt_book.Text.Trim());
            }
        }

        private void Importar_Excel(string path, string Hoja)
        {
            try
            {
                DataSet dataset = new DataSet();

                using (OleDbConnection MyConnection = new OleDbConnection(
                "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'"))
                {
                    OleDbDataAdapter MyCommand = new OleDbDataAdapter(
                    "select * from [" + Hoja + "$]", MyConnection);

                    MyCommand.Fill(dataset);
                }

                dgt_datos.DataSource = dataset.Tables[0];

                int xnro = dgt_datos.RowCount;
                btn_nrofila.Text = xnro.ToString();

                btn_Quitar.Enabled = true;
                btn_save.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al importar el archivo: " + ex.Message,
                "Importar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgt_datos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            string NomColum = dgt_datos.Columns[columnIndex].Name;
            dgt_datos.Columns.Remove(NomColum);
        }

        private void btn_Quitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgt_datos.CurrentCell != null)
                {
                    int colIndex = dgt_datos.CurrentCell.ColumnIndex;

                    DataTable dt = (DataTable)dgt_datos.DataSource;
                    dt.Columns.RemoveAt(colIndex);

                    dgt_datos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al quitar la columna: " + ex.Message);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Obtener_Registro();
        }


        string NombrProd = "";
        double PrecioVenta = 0;
        double PrecompraSol = 0;
        double Stock = 0;

        private void Obtener_Registro()
        {
            int xitem = 0;

            if (dgt_datos.RowCount == 0) return;
            if (dgt_datos.Columns.Count < 4)
            {
                MessageBox.Show("El Excel debe tener al menos 4 columnas:\nNombre | Stock | PrecioCompra | PrecioVenta",
                "Importar Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                CN_Producto obj = new CN_Producto();

                foreach (DataGridViewRow fila in dgt_datos.Rows)
                {
                  
                    if (fila.IsNewRow) continue;
                    NombrProd = Convert.ToString(fila.Cells[0].Value)?.Trim();

                    double.TryParse(Convert.ToString(fila.Cells[1].Value),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out Stock);

                    double.TryParse(Convert.ToString(fila.Cells[2].Value),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out PrecompraSol);

                    double.TryParse(Convert.ToString(fila.Cells[3].Value),
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out PrecioVenta);

                    if (string.IsNullOrWhiteSpace(NombrProd))
                    {
                        continue;
                    }

                    if (Stock < 0 || PrecompraSol < 0 || PrecioVenta < 0)
                    {
                        continue; 
                    }
                    if (obj.ExisteProducto(NombrProd))
                    {
                        continue;
                    }
                    Registrar_Producto();
                    xitem++;
                    btn_RutaExcel.Text = xitem.ToString();
                }
                if (xitem > 0)
                {
                    Filtro fill = new Filtro();
                    frm_Msm_bueno ok = new frm_Msm_bueno();

                    fill.Show();

                    if (xitem == dgt_datos.Rows.Count - 1)
                    {
                        ok.Lbl_msm1.Text = "¡Productos importados correctamente!";
                    }
                    else
                    {
                        ok.Lbl_msm1.Text = "¡Productos importados, algunos fueron omitidos! Total guardados: " + xitem;
                    }

                    ok.ShowDialog(this);
                    fill.Hide();

                    btn_Listo.Enabled = false;
                    btn_Quitar.Enabled = false;
                    btn_nrofila.Text = "0";
                    btn_RutaExcel.Text = "0";
                }
                else
                {
                    MessageBox.Show("No se importó ningún producto válido al parece existe en la base de datos",
                    "Importar Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el registro: " + ex.Message,
                "Importar Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Registrar_Producto()
        {
            CN_Producto obj = new CN_Producto();
            CapaEntidad.Producto pro = new CapaEntidad.Producto();

            string IDProducto = CN_TipoDoc.CN_Generar_NroCorrelativo(7);
            try
            {
                pro.Idprod = IDProducto;
                pro.Descripcion = NombrProd;
                pro.PrecioCompra = PrecompraSol;
                pro.StockActual = Stock;
                pro.IdCat = 1;
                pro.Foto = "-";
                pro.Preventa = PrecioVenta;
                pro.FormatoCompra = "Und";
                pro.UtilidadUnit = 0;
                pro.ValorxCant = 0;
                pro.PrincipioActivo = "-";
                pro.Laboratorio = "-";
                pro.Und_min = 5;
                pro.Und_max = 50;
                pro.FechaVence = "-";
              
                pro.Venta_conReceta = "No";
                obj.RegistrarProducto(pro);
                if (CD_Producto.prod_saved == true)
                {
                    CN_TipoDoc.CN_Actualizar_Correlativo(7);
                    Registrar_Kardex(IDProducto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Registro de producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Registrar_Kardex(string idprod)
        {
            CN_Kardex objkardex = new CN_Kardex();
            Detalle_Kardex detkardex = new Detalle_Kardex();
            try
            {
                if (objkardex.Verificar_Kardex_Producto(idprod.Trim()) == true) return;
                string idkardex = CN_TipoDoc.CN_Generar_NroCorrelativo(8);

                // 2do paso: registrar el kardex
                objkardex.RegistrarKardex(idkardex, idprod);

                if (CD_Kardex.kar_saved == true)
                {
                    // 3er paso: registrar el detalle del kardex
                    detkardex.IdKardex = idkardex;
                    detkardex.Item = 1;
                    detkardex.Doc_soporte = "0000";
                    detkardex.Det_Operacion = "INICIO DE KARDEX";

                    //entradas
                    detkardex.Cantidad_In = Stock;
                    detkardex.Precio_In = PrecompraSol;
                    detkardex.Total_In = Stock * PrecompraSol;

                    //salidas
                    detkardex.Cantidad_Out = 0;
                    detkardex.Precio_Out = 0;
                    detkardex.Total_Out = 0;

                    //Saldo
                    detkardex.Cantidad_In = Stock;
                    detkardex.Precio_In = PrecompraSol;
                    detkardex.Total_In = Stock * PrecompraSol;

                    //extras
                    detkardex.Idusu = 1;
                    detkardex.Tipo_operacion = "Inicio KArdex";
                    detkardex.Cant_diferencial = "_";
                    detkardex.ImporteDiferente = 0;
                    objkardex.Registrar_DetalleKardex(detkardex);

                    CN_TipoDoc.CN_Actualizar_Correlativo(8);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Registro del kardex desde Form", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    }
}
