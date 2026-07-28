using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Inicio
    {
        private Label dashVentas;
        private Label dashTotal;
        private Label dashUtilidad;
        private Label dashStock;
        private Label dashVencimientos;
        private DataGridView dashVentasRecientes;
        private DataGridView dashAlertas;

        private void ConstruirDashboardProfesional()
        {
            tabPage1.Controls.Clear();
            tabPage1.BackColor = Color.FromArgb(245, 247, 251);
            tabPage1.Padding = new Padding(22);

            TableLayoutPanel raiz = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = tabPage1.BackColor,
                ColumnCount = 1,
                RowCount = 4,
                Padding = new Padding(0)
            };
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 66));
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 130));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            // Deja un margen inferior real para que las acciones no se recorten.
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));

            Panel encabezado = new Panel { Dock = DockStyle.Fill };
            Label titulo = new Label
            {
                AutoSize = true,
                Text = "Resumen operativo",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(43, 47, 58),
                Location = new Point(0, 2)
            };
            Label fecha = new Label
            {
                AutoSize = true,
                Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy",
                    new CultureInfo("es-PE")),
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.DimGray,
                Location = new Point(4, 43)
            };
            Button actualizar = CrearBotonDashboard("Actualizar", Color.FromArgb(52, 120, 246));
            actualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            actualizar.Location = new Point(raiz.Width - 130, 10);
            actualizar.Click += (s, e) => CargarDashboardProfesional();
            encabezado.Resize += (s, e) =>
                actualizar.Left = Math.Max(0, encabezado.ClientSize.Width - actualizar.Width);
            encabezado.Controls.Add(titulo);
            encabezado.Controls.Add(fecha);
            encabezado.Controls.Add(actualizar);

            TableLayoutPanel tarjetas = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 5,
                RowCount = 1,
                Padding = new Padding(0, 8, 0, 12)
            };
            for (int i = 0; i < 5; i++)
                tarjetas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));

            dashVentas = AgregarTarjeta(tarjetas, 0, "Ventas de hoy", "0",
                Color.FromArgb(52, 120, 246));
            dashTotal = AgregarTarjeta(tarjetas, 1, "Ingresos de hoy", "S/ 0.00",
                Color.FromArgb(24, 160, 116));
            dashUtilidad = AgregarTarjeta(tarjetas, 2, "Utilidad estimada", "S/ 0.00",
                Color.FromArgb(126, 87, 194));
            dashStock = AgregarTarjeta(tarjetas, 3, "Stock por reponer", "0",
                Color.FromArgb(242, 153, 31));
            dashVencimientos = AgregarTarjeta(tarjetas, 4, "Vencen en 90 días", "0",
                Color.FromArgb(224, 76, 76));

            TableLayoutPanel contenido = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(0, 4, 0, 8)
            };
            contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
            contenido.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));

            dashVentasRecientes = CrearGrillaDashboard();
            dashAlertas = CrearGrillaDashboard();
            contenido.Controls.Add(CrearPanelGrilla("Últimas ventas del día",
                dashVentasRecientes), 0, 0);
            contenido.Controls.Add(CrearPanelGrilla("Alertas de inventario",
                dashAlertas), 1, 0);

            FlowLayoutPanel acciones = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                Padding = new Padding(0, 6, 0, 12)
            };
            Button vender = CrearBotonDashboard("Nueva venta", Color.FromArgb(156, 48, 211));
            vender.Click += Bt_VentasTool_Click;
            Button reposicion = CrearBotonDashboard("Ver reposición", Color.FromArgb(242, 153, 31));
            reposicion.Click += productosParaReposicionToolStripMenuItem_Click;
            acciones.Controls.Add(vender);
            acciones.Controls.Add(reposicion);

            raiz.Controls.Add(encabezado, 0, 0);
            raiz.Controls.Add(tarjetas, 0, 1);
            raiz.Controls.Add(contenido, 0, 2);
            raiz.Controls.Add(acciones, 0, 3);
            tabPage1.Controls.Add(raiz);

            CargarDashboardProfesional();
        }

        private void CargarDashboardProfesional()
        {
            try
            {
                DataTable documentos = new CN_Documento()
                    .CN_Listar_Documentos_Pordia(DateTime.Today) ?? new DataTable();

                DataRow[] activos = documentos.AsEnumerable()
                    .Where(fila => !documentos.Columns.Contains("Estado_Doc") ||
                        string.Equals(Convert.ToString(fila["Estado_Doc"]).Trim(),
                            "Activo", StringComparison.OrdinalIgnoreCase))
                    .ToArray();

                decimal total = activos.Sum(fila => DecimalSeguro(fila, "ImporteDoc"));
                decimal utilidad = activos.Sum(fila => DecimalSeguro(fila, "TotalGanancia"));

                CN_Producto productos = new CN_Producto();
                DataTable reposicion = productos.CN_ProductosReposicion() ?? new DataTable();
                DataTable todos = productos.CargarTodos_Productos() ?? new DataTable();
                DataTable vencen = FiltrarVencimientos(todos, 90);

                dashVentas.Text = activos.Length.ToString();
                dashTotal.Text = "S/ " + total.ToString("N2");
                dashUtilidad.Text = "S/ " + utilidad.ToString("N2");
                dashStock.Text = reposicion.Rows.Count.ToString();
                dashVencimientos.Text = vencen.Rows.Count.ToString();

                CargarVentasDashboard(documentos);
                CargarAlertasDashboard(reposicion, vencen);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    "No se pudo actualizar el dashboard: " + ex.Message);
            }
        }

        private void CargarVentasDashboard(DataTable origen)
        {
            DataTable vista = new DataTable();
            vista.Columns.Add("Comprobante");
            vista.Columns.Add("Cliente");
            vista.Columns.Add("Tipo");
            vista.Columns.Add("Pago");
            vista.Columns.Add("Total");

            foreach (DataRow fila in origen.AsEnumerable()
                .OrderByDescending(f => FechaSegura(f, "Fecha_Emi")).Take(8))
            {
                vista.Rows.Add(
                    TextoSeguro(fila, "id_Doc"),
                    TextoSeguro(fila, "Razon_Social_Nombres"),
                    TextoSeguro(fila, "Documento"),
                    TextoSeguro(fila, "TipoPago"),
                    "S/ " + DecimalSeguro(fila, "ImporteDoc").ToString("N2"));
            }

            dashVentasRecientes.DataSource = vista;
        }

        private void CargarAlertasDashboard(DataTable reposicion, DataTable vencen)
        {
            DataTable vista = new DataTable();
            vista.Columns.Add("Prioridad");
            vista.Columns.Add("Producto");
            vista.Columns.Add("Detalle");

            foreach (DataRow fila in vencen.AsEnumerable()
                .OrderBy(f => FechaProducto(f)).Take(6))
            {
                DateTime fecha = FechaProducto(fila);
                vista.Rows.Add(
                    fecha < DateTime.Today ? "VENCIDO" : "VENCIMIENTO",
                    NombreProductoAlerta(fila),
                    fecha.ToString("dd/MM/yyyy"));
            }

            foreach (DataRow fila in reposicion.AsEnumerable().Take(6))
            {
                vista.Rows.Add(
                    "STOCK",
                    NombreProductoAlerta(fila),
                    "Actual: " + TextoSeguro(fila, "Stock_Actual") +
                    " | Mínimo: " + TextoSeguro(fila, "Und_Min"));
            }

            dashAlertas.DataSource = vista;
            foreach (DataGridViewRow fila in dashAlertas.Rows)
            {
                string prioridad = Convert.ToString(fila.Cells["Prioridad"].Value);
                if (prioridad == "VENCIDO")
                    fila.DefaultCellStyle.ForeColor = Color.Firebrick;
                else if (prioridad == "VENCIMIENTO")
                    fila.DefaultCellStyle.ForeColor = Color.DarkOrange;
            }
        }

        private static DataTable FiltrarVencimientos(DataTable origen, int dias)
        {
            DataTable resultado = origen.Clone();
            if (!origen.Columns.Contains("FechaVncmnto"))
                return resultado;

            DateTime limite = DateTime.Today.AddDays(dias);
            foreach (DataRow fila in origen.Rows)
            {
                DateTime fecha = FechaProducto(fila);
                if (fecha != DateTime.MinValue && fecha <= limite)
                    resultado.ImportRow(fila);
            }
            return resultado;
        }

        private static DateTime FechaProducto(DataRow fila)
        {
            DateTime fecha;
            string valor = TextoSeguro(fila, "FechaVncmnto");
            return DateTime.TryParse(valor, out fecha) ? fecha.Date : DateTime.MinValue;
        }

        private static DateTime FechaSegura(DataRow fila, string columna)
        {
            DateTime fecha;
            return fila.Table.Columns.Contains(columna) &&
                DateTime.TryParse(Convert.ToString(fila[columna]), out fecha)
                ? fecha : DateTime.MinValue;
        }

        private static decimal DecimalSeguro(DataRow fila, string columna)
        {
            decimal valor;
            return fila.Table.Columns.Contains(columna) &&
                decimal.TryParse(Convert.ToString(fila[columna]), out valor)
                ? valor : 0m;
        }

        private static string TextoSeguro(DataRow fila, string columna)
        {
            return fila.Table.Columns.Contains(columna)
                ? Convert.ToString(fila[columna]).Trim() : string.Empty;
        }

        private static string NombreProductoAlerta(DataRow fila)
        {
            string nombre = TextoSeguro(fila, "Descripcion_Larga");
            if (!string.IsNullOrWhiteSpace(nombre))
                return nombre;

            string codigo = TextoSeguro(fila, "Id_Pro");
            return string.IsNullOrWhiteSpace(codigo)
                ? "Producto sin descripción"
                : "Código: " + codigo;
        }

        private static Label AgregarTarjeta(TableLayoutPanel contenedor, int columna,
            string titulo, string valor, Color color)
        {
            Panel tarjeta = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(columna == 0 ? 0 : 7, 0,
                    columna == 4 ? 0 : 7, 0),
                Padding = new Padding(16)
            };
            Panel acento = new Panel
            {
                BackColor = color,
                Dock = DockStyle.Left,
                Width = 5
            };
            Label etiqueta = new Label
            {
                Text = titulo,
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.DimGray,
                Location = new Point(20, 16)
            };
            Label numero = new Label
            {
                Text = valor,
                AutoSize = true,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(43, 47, 58),
                Location = new Point(18, 47)
            };
            tarjeta.Controls.Add(numero);
            tarjeta.Controls.Add(etiqueta);
            tarjeta.Controls.Add(acento);
            contenedor.Controls.Add(tarjeta, columna, 0);
            return numero;
        }

        private static DataGridView CrearGrillaDashboard()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                ForeColor = Color.FromArgb(43, 47, 58),
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 36,
                RowTemplate = { Height = 32 },
                GridColor = Color.FromArgb(232, 235, 241),
                ColumnHeadersDefaultCellStyle =
                {
                    BackColor = Color.FromArgb(52, 120, 246),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    SelectionBackColor = Color.FromArgb(52, 120, 246),
                    SelectionForeColor = Color.White,
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                },
                DefaultCellStyle =
                {
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(43, 47, 58),
                    Font = new Font("Segoe UI", 9F),
                    SelectionBackColor = Color.FromArgb(224, 235, 255),
                    SelectionForeColor = Color.FromArgb(30, 55, 95),
                    Padding = new Padding(4, 0, 4, 0)
                },
                AlternatingRowsDefaultCellStyle =
                {
                    BackColor = Color.FromArgb(248, 250, 253),
                    ForeColor = Color.FromArgb(43, 47, 58),
                    SelectionBackColor = Color.FromArgb(224, 235, 255),
                    SelectionForeColor = Color.FromArgb(30, 55, 95)
                }
            };
        }

        private static Panel CrearPanelGrilla(string titulo, Control grilla)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 12, 0),
                Padding = new Padding(14, 46, 14, 14)
            };
            Label etiqueta = new Label
            {
                Text = titulo,
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(43, 47, 58),
                Location = new Point(15, 13)
            };
            panel.Controls.Add(grilla);
            panel.Controls.Add(etiqueta);
            return panel;
        }

        private static Button CrearBotonDashboard(string texto, Color color)
        {
            return new Button
            {
                Text = texto,
                Width = 122,
                Height = 34,
                FlatStyle = FlatStyle.Flat,
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(8, 0, 0, 0)
            };
        }
    }
}
