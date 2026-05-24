using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using CapaNegocio;

namespace CapaPresentacion.Informes
{
    public partial class frm_print_Informe : Form
    {
        public frm_print_Informe()
        {
            InitializeComponent();
        }

        public string NrDoc;
        public string TipoDoc = "";
        public DateTime fechadia;

        private void frm_print_Ticket_Load(object sender, EventArgs e)
        {
            if (TipoDoc.Trim() == "salidAlmacen")
            {
                Imprimir_Salida_Almacen(NrDoc);
            }
            if (TipoDoc.Trim() == "cierrecaja")
            {
                Imprimir_Cierre_Caja(NrDoc);
            }
            if (TipoDoc.Trim() == "sinventa")
            {
                Imprimir_Productos_No_Vendidos(fechadia);
            }
            if (TipoDoc.Trim() == "sinrota")
            {
                Imprimir_Productos_sinRotacion();
            }
            if (TipoDoc.Trim() == "exportBD")
            {
                Imprimir_ExportarBD();
            }
            if (TipoDoc.Trim() == "reporteKardex")
            {
                Imprimir_Kardex_Valorizado();
            }
            if (TipoDoc.Trim() == "venta_mes")
            {
                Imprimir_Record_General_Ventas();
            }
            if (TipoDoc.Trim() == "mes_doc")
            {
                Imprimir_Record_General_MesDoc();
            }
            if (TipoDoc.Trim() == "movcaja_dia")
            {
                Imprimir_Movimiento_Caja_Dia();
            }

            if (TipoDoc.Trim() == "prod_masvendidos")
            {
                Imprimir_Productos_MasVendidos();
            }

        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CrearQR_Fisico(string textoQR, string nroDoc)
        {
            string ruta = @"F:\PORTAFOLIO\SISTEMA_BOTICA\CPE_2\QR_TEMP\";

            // 1. Si la carpeta no existe, la crea
            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            // 2. Generador QR
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 1200,
                    Height = 1200,
                    Margin = 3
                }
            };

            // 3. Crear y guardar BMP
            using (Bitmap bmp = writer.Write(textoQR))
            {
                bmp.Save(ruta + nroDoc + ".BMP", ImageFormat.Bmp);
            }
        }
        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Temporal objNegocio = new CN_Temporal();
                DataTable dt = objNegocio.CN_Buscar_TemporalId(NrDoc);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Crys_Print_Ticket ticket = new Crys_Print_Ticket();
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "V_Temporales_Detalle";
                    // Pasamos los datos
                    ticket.SetDataSource(dt);

                    // Vinculamos al visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No hay datos para el documento: " + NrDoc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }

        private void Imprimir_Productos_MasVendidos()
        {
            try
            {
                CN_Producto objNegocio = new CN_Producto();
                DataTable dt = new DataTable();

                dt = objNegocio.CN_Listar_Productos_MasVendidos(fechadia);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Crys_Productos_MasVendidos rpt = new Crys_Productos_MasVendidos();

                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_Productos_MasVendidos.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        rpt.Load(rutaReporte);
                    }

                    rpt.DataSourceConnections.Clear();
                    dt.TableName = "V_Ventas_Detalle";
                    rpt.SetDataSource(dt);

                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = rpt;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No hay productos vendidos en esta fecha.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }

        private void Imprimir_Movimiento_Caja_Dia()
        {
            try
            {
                CN_Documento objNegocio = new CN_Documento();
                DataTable dt = new DataTable();

                dt = objNegocio.CN_Listar_Documentos_Pordia(fechadia);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Crys_Movimiento_Caja_Dia rpt = new Crys_Movimiento_Caja_Dia();

                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_Movimiento_Caja_Dia.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        rpt.Load(rutaReporte);
                    }

                    rpt.DataSourceConnections.Clear();
                    dt.TableName = "V_Listado_Documento";
                    rpt.SetDataSource(dt);

                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = rpt;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No hay movimientos en esta fecha.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message);
            }
        }







        private void Imprimir_Record_General_MesDoc()
        {
            try
            {
    
                int idTipo = 0;
                if (this.Tag != null && int.TryParse(this.Tag.ToString(), out idTipo))
                {
                    CN_Documento objNegocio = new CN_Documento();
                    DataTable dt = objNegocio.CN_Listar_Comprobantes_Emitidos_Mes(fechadia, idTipo);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Crys_Ventas_MesDoc ticket = new Crys_Ventas_MesDoc();
                        string rutaReporte = Application.StartupPath + @"\Informes\Crys_Ventas_MesDoc.rpt";

                        if (File.Exists(rutaReporte))
                        {
                            ticket.Load(rutaReporte);
                        }
                        ticket.DataSourceConnections.Clear();
                        dt.TableName = "V_Listado_Documento";
                        ticket.SetDataSource(dt);
                        Crys_visor.ReportSource = null;
                        Crys_visor.ReportSource = ticket;
                        Crys_visor.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros para este tipo de documento en la fecha seleccionada.",
                                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Error: El tipo de documento no ha sido seleccionado correctamente.",
                                    "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void Imprimir_Record_General_Ventas()
        {
            try
            {

                // 2. Obtener datos de la BD
                CN_Documento objNegocio = new CN_Documento();
                DataTable dt = new DataTable();
                dt = objNegocio.CN_Listar_Facturas_Emitidas_Mes(fechadia);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Crys_Ventas_deMes ticket = new Crys_Ventas_deMes();
                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_Ventas_deMes.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        ticket.Load(rutaReporte); // Carga el archivo físico
                    }
                    else
                    {
                        // Si no existe el archivo suelto, lo intenta usar como objeto incrustado
                        // (No necesitas poner nada aquí si ya lo instanciaste arriba)
                    }

                    // 3. Limpiar conexiones y pasar datos
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "V_Listado_Documento";
                    ticket.SetDataSource(dt);

                    // 4. Mostrar en el visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivo RPT: " + ex.Message);
            }
        }




        private void Imprimir_Kardex_Valorizado()
        {
            try
            {

                // 2. Obtener datos de la BD
                CN_Reporte_Kardex objNegocio = new CN_Reporte_Kardex();
                DataTable dt = new DataTable();
                dt = objNegocio.CN_Listar_Todos_Temporal_Kardex();

                if (dt != null && dt.Rows.Count > 0)
                {

                    Crys_Inventario_Valorizado ticket = new Crys_Inventario_Valorizado();
                    // Construimos la ruta dinámica a la carpeta Informes
                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_Inventario_Valorizado.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        ticket.Load(rutaReporte); // Carga el archivo físico
                    }
                    else
                    {
                        // Si no existe el archivo suelto, lo intenta usar como objeto incrustado
                        // (No necesitas poner nada aquí si ya lo instanciaste arriba)
                    }

                    // 3. Limpiar conexiones y pasar datos
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "v_Kardex_Vista";
                    ticket.SetDataSource(dt);

                    // 4. Mostrar en el visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivo RPT: " + ex.Message);
            }
        }





        private void Imprimir_ExportarBD()
        {
            try
            {

                // 2. Obtener datos de la BD
                CN_Producto objNegocio = new CN_Producto();
                DataTable dt = new DataTable();
                dt = objNegocio.CargarTodos_Productos();

                if (dt != null && dt.Rows.Count > 0)
                {

                    Crys_ExportBD ticket = new Crys_ExportBD();
                    // Construimos la ruta dinámica a la carpeta Informes
                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_ExportBD.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        ticket.Load(rutaReporte); // Carga el archivo físico
                    }
                    else
                    {
                        // Si no existe el archivo suelto, lo intenta usar como objeto incrustado
                        // (No necesitas poner nada aquí si ya lo instanciaste arriba)
                    }

                    // 3. Limpiar conexiones y pasar datos
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "v_Producto_Categoria";
                    ticket.SetDataSource(dt);

                    // 4. Mostrar en el visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivo RPT: " + ex.Message);
            }
        }


        private void Imprimir_Productos_sinRotacion()
        {
            try
            {

                // 2. Obtener datos de la BD
                CN_Producto objNegocio = new CN_Producto();
                DataTable dt = new DataTable();
                dt = objNegocio.CN_Listar_todos_Los_productos_sinRotacion("Sinrotacion");

                if (dt != null && dt.Rows.Count > 0)
                {

                    Crys_Productos_Sin_Rotacion ticket = new Crys_Productos_Sin_Rotacion();
                    // Construimos la ruta dinámica a la carpeta Informes
                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_Productos_Sin_Rotacion.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        ticket.Load(rutaReporte); // Carga el archivo físico
                    }
                    else
                    {
                        // Si no existe el archivo suelto, lo intenta usar como objeto incrustado
                        // (No necesitas poner nada aquí si ya lo instanciaste arriba)
                    }

                    // 3. Limpiar conexiones y pasar datos
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "v_Producto_Categoria";
                    ticket.SetDataSource(dt);

                    // 4. Mostrar en el visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivo RPT: " + ex.Message);
            }
        }



        private void Imprimir_Productos_No_Vendidos(DateTime dia)
        {
            try
            {
                // 2. Obtener datos de la BD
                CN_Producto_SinValor objNegocio = new CN_Producto_SinValor();
                DataTable dt = objNegocio.CN_Cargar_Producto_sinVenta_porStock_deldia(dia);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Crys_Producto_SinValor ticket = new Crys_Producto_SinValor();
                    // Construimos la ruta dinámica a la carpeta Informes
                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_Producto_SinValor.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        ticket.Load(rutaReporte); // Carga el archivo físico
                    }
                    else
                    {
                        // Si no existe el archivo suelto, lo intenta usar como objeto incrustado
                        // (No necesitas poner nada aquí si ya lo instanciaste arriba)
                    }

                    // 3. Limpiar conexiones y pasar datos
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "V_ProductosinValor_Prod";
                    ticket.SetDataSource(dt);

                    // 4. Mostrar en el visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivo RPT: " + ex.Message);
            }
        }

        private void Imprimir_Cierre_Caja(string NrDoc)
        {
            try
            {
                // 1. Generar el QR
                CrearQR_Fisico(NrDoc, NrDoc);

                // 2. Obtener datos de la BD
                CN_CierreCaja objNegocio = new CN_CierreCaja();
                DataTable dt = objNegocio.CN_Listar_Cierre_Caja_porID(NrDoc);

                if (dt != null && dt.Rows.Count > 0)
                {

                    Crys_CierreCaja ticket = new Crys_CierreCaja();
                    // Construimos la ruta dinámica a la carpeta Informes
                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_CierreCaja.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        ticket.Load(rutaReporte); // Carga el archivo físico
                    }
                    else
                    {
                        // Si no existe el archivo suelto, lo intenta usar como objeto incrustado
                        // (No necesitas poner nada aquí si ya lo instanciaste arriba)
                    }

                    // 3. Limpiar conexiones y pasar datos
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "v_cierreCaja_usu";
                    ticket.SetDataSource(dt);

                    // 4. Mostrar en el visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivo RPT: " + ex.Message);
            }
        }


        private void Imprimir_Salida_Almacen(string NrDoc)
        {
            try
            {
                // 1. Generar el QR
                CrearQR_Fisico(NrDoc, NrDoc);

                // 2. Obtener datos de la BD
                CN_Compra objNegocio = new CN_Compra();
                DataTable dt = objNegocio.CN_Buscar_CompraconDetalle(NrDoc);

                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    Crys_Salida_Almacen ticket = new Crys_Salida_Almacen();
                    // Construimos la ruta dinámica a la carpeta Informes
                    string rutaReporte = Application.StartupPath + @"\Informes\Crys_Salida_Almacen.rpt";

                    if (File.Exists(rutaReporte))
                    {
                        ticket.Load(rutaReporte); // Carga el archivo físico
                    }
                    else
                    {
                        // Si no existe el archivo suelto, lo intenta usar como objeto incrustado
                        // (No necesitas poner nada aquí si ya lo instanciaste arriba)
                    }

                    // 3. Limpiar conexiones y pasar datos
                    ticket.DataSourceConnections.Clear();
                    dt.TableName = "V_Documentos_Compra_Detalle";
                    ticket.SetDataSource(dt);

                    // 4. Mostrar en el visor
                    Crys_visor.ReportSource = null;
                    Crys_visor.ReportSource = ticket;
                    Crys_visor.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se encontraron datos para el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar archivo RPT: " + ex.Message);
            }
        }
     

        private void btn_reimprimir_Click(object sender, EventArgs e)
        {
            Crys_visor.ExportReport();
        }

        private void frm_print_Ticket_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);
            }
        }
    }
}
