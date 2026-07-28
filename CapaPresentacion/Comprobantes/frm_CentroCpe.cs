using CapaNegocio;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion.Comprobantes
{
    public sealed class frm_CentroCpe : Form
    {
        private readonly CN_CpeElectronico servicio = new CN_CpeElectronico();
        private readonly DataGridView tabla = new DataGridView();
        private readonly TextBox txtBuscar = new TextBox();
        private readonly ComboBox cboEstado = new ComboBox();
        private readonly Label lblResumen = new Label();
        private readonly Label lblDocumento = new Label();
        private readonly Label lblHash = new Label();
        private readonly Label lblRespuesta = new Label();
        private readonly TabControl tabs = new TabControl();
        private readonly TextBox txtXml = CrearVisor();
        private readonly TextBox txtCdr = CrearVisor();
        private readonly Button btnReintentar = CrearBoton(
            "Reintentar simulación", Color.FromArgb(143, 40, 205));
        private readonly Button btnExportarXml = CrearBoton(
            "Guardar XML", Color.FromArgb(47, 117, 181));
        private readonly Button btnExportarCdr = CrearBoton(
            "Guardar CDR", Color.FromArgb(35, 165, 118));

        public frm_CentroCpe()
        {
            Text = "Centro de Facturación Electrónica - Simulación";
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(1180, 620);
            Size = new Size(1240, 700);
            BackColor = Color.FromArgb(245, 247, 251);
            Font = new Font("Segoe UI", 9F);
            ConstruirInterfaz();
            Load += frm_CentroCpe_Load;
        }

        private void ConstruirInterfaz()
        {
            Panel cabecera = new Panel
            {
                Dock = DockStyle.Top,
                Height = 74,
                BackColor = Color.FromArgb(143, 40, 205)
            };
            cabecera.Controls.Add(new Label
            {
                Text = "Centro de Facturación Electrónica",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(22, 10)
            });
            cabecera.Controls.Add(new Label
            {
                Text = "AMBIENTE DE SIMULACIÓN · SIN VALIDEZ TRIBUTARIA · SIN ENVÍO A SUNAT",
                ForeColor = Color.FromArgb(255, 231, 167),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(25, 48)
            });

            Panel filtros = new Panel
            {
                Dock = DockStyle.Top,
                Height = 64,
                Padding = new Padding(18, 13, 18, 10),
                BackColor = Color.White
            };
            Label lblBuscar = new Label
            {
                Text = "Buscar:",
                AutoSize = true,
                Location = new Point(20, 22),
                ForeColor = Color.DimGray
            };
            txtBuscar.Width = 255;
            txtBuscar.Location = new Point(78, 18);
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.TextChanged += delegate { CargarDatos(); };

            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.Items.AddRange(new object[]
            {
                "Todos",
                "ACEPTADO_SIMULADO",
                "PENDIENTE_SIMULACION",
                "RECHAZADO_SIMULADO"
            });
            cboEstado.SelectedIndex = 0;
            cboEstado.Location = new Point(350, 17);
            cboEstado.Width = 210;
            cboEstado.SelectedIndexChanged += delegate { CargarDatos(); };

            Button btnActualizar = CrearBoton(
                "Actualizar", Color.FromArgb(47, 117, 181));
            btnActualizar.Location = new Point(580, 14);
            btnActualizar.Click += delegate { CargarDatos(); };

            lblResumen.AutoSize = true;
            lblResumen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResumen.ForeColor = Color.DimGray;
            lblResumen.Location = new Point(730, 22);

            filtros.Controls.Add(lblBuscar);
            filtros.Controls.Add(txtBuscar);
            filtros.Controls.Add(cboEstado);
            filtros.Controls.Add(btnActualizar);
            filtros.Controls.Add(lblResumen);

            SplitContainer principal = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 250,
                BackColor = Color.FromArgb(226, 230, 238)
            };
            ConfigurarTabla();
            principal.Panel1.Padding = new Padding(16, 8, 16, 8);
            principal.Panel1.Controls.Add(tabla);
            principal.Panel2.Padding = new Padding(16, 8, 16, 14);
            principal.Panel2.Controls.Add(CrearPanelDetalle());

            Controls.Add(principal);
            Controls.Add(filtros);
            Controls.Add(cabecera);
        }

        private void ConfigurarTabla()
        {
            tabla.Dock = DockStyle.Fill;
            tabla.ReadOnly = true;
            tabla.AllowUserToAddRows = false;
            tabla.AllowUserToDeleteRows = false;
            tabla.AllowUserToResizeRows = false;
            tabla.MultiSelect = false;
            tabla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla.BackgroundColor = Color.White;
            tabla.BorderStyle = BorderStyle.None;
            tabla.RowHeadersVisible = false;
            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(47, 117, 181);
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tabla.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);
            tabla.ColumnHeadersHeight = 34;
            tabla.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(222, 232, 250);
            tabla.DefaultCellStyle.SelectionForeColor = Color.Black;
            tabla.SelectionChanged += tabla_SelectionChanged;
        }

        private Control CrearPanelDetalle()
        {
            Panel panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            Panel info = new Panel
            {
                Dock = DockStyle.Top,
                Height = 84,
                Padding = new Padding(14, 8, 14, 6)
            };
            lblDocumento.AutoSize = true;
            lblDocumento.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDocumento.Location = new Point(14, 10);
            lblHash.AutoSize = false;
            lblHash.Location = new Point(14, 35);
            lblHash.Size = new Size(760, 20);
            lblRespuesta.AutoSize = false;
            lblRespuesta.Location = new Point(14, 57);
            lblRespuesta.Size = new Size(900, 20);
            lblRespuesta.ForeColor = Color.DimGray;

            btnReintentar.Location = new Point(930, 8);
            btnReintentar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReintentar.Click += btnReintentar_Click;
            btnExportarXml.Location = new Point(930, 44);
            btnExportarXml.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarXml.Click += delegate { GuardarContenido(txtXml.Text, "xml"); };
            btnExportarCdr.Location = new Point(1082, 44);
            btnExportarCdr.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportarCdr.Click += delegate { GuardarContenido(txtCdr.Text, "xml"); };

            info.Resize += delegate
            {
                btnExportarCdr.Left = Math.Max(14,
                    info.ClientSize.Width - btnExportarCdr.Width - 10);
                btnExportarXml.Left = Math.Max(14,
                    btnExportarCdr.Left - btnExportarXml.Width - 12);
                btnReintentar.Left = btnExportarXml.Left;
                lblHash.Width = Math.Max(200, btnReintentar.Left - 28);
                lblRespuesta.Width = Math.Max(200, btnExportarXml.Left - 28);
            };

            info.Controls.Add(lblDocumento);
            info.Controls.Add(lblHash);
            info.Controls.Add(lblRespuesta);
            info.Controls.Add(btnReintentar);
            info.Controls.Add(btnExportarXml);
            info.Controls.Add(btnExportarCdr);

            tabs.Dock = DockStyle.Fill;
            TabPage paginaXml = new TabPage("XML UBL 2.1 simulado");
            paginaXml.Controls.Add(txtXml);
            TabPage paginaCdr = new TabPage("CDR simulada");
            paginaCdr.Controls.Add(txtCdr);
            tabs.TabPages.Add(paginaXml);
            tabs.TabPages.Add(paginaCdr);

            panel.Controls.Add(tabs);
            panel.Controls.Add(info);
            return panel;
        }

        private void frm_CentroCpe_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                string estado = cboEstado.SelectedIndex <= 0
                    ? string.Empty : Convert.ToString(cboEstado.SelectedItem);
                DataTable datos = servicio.ListarCentro(txtBuscar.Text, estado);
                tabla.DataSource = datos;
                lblResumen.Text = datos.Rows.Count + " comprobante(s)";
                AjustarColumnas();
                if (tabla.Rows.Count > 0)
                    tabla.Rows[0].Selected = true;
                else
                    LimpiarDetalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el Centro CPE.\n\n" + ex.Message +
                    "\n\nVerifique que la migración 014 esté aplicada.",
                    "Centro CPE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AjustarColumnas()
        {
            if (tabla.Columns.Contains("MensajeRespuesta"))
                tabla.Columns["MensajeRespuesta"].Visible = false;
            if (tabla.Columns.Contains("HashCpe"))
                tabla.Columns["HashCpe"].Visible = false;
            if (tabla.Columns.Contains("CodigoRespuesta"))
                tabla.Columns["CodigoRespuesta"].HeaderText = "Código";
            if (tabla.Columns.Contains("EstadoCpe"))
                tabla.Columns["EstadoCpe"].HeaderText = "Estado CPE";
            if (tabla.Columns.Contains("FechaProceso"))
                tabla.Columns["FechaProceso"].HeaderText = "Procesado";
            if (tabla.Columns.Contains("FechaEmision"))
                tabla.Columns["FechaEmision"].HeaderText = "Emisión";

            AsignarPesoColumna("Comprobante", 105);
            AsignarPesoColumna("Tipo", 70);
            AsignarPesoColumna("FechaEmision", 115);
            AsignarPesoColumna("Cliente", 125);
            AsignarPesoColumna("Importe", 70);
            AsignarPesoColumna("Moneda", 60);
            AsignarPesoColumna("Ambiente", 90);
            AsignarPesoColumna("EstadoCpe", 140);
            AsignarPesoColumna("CodigoRespuesta", 70);
            AsignarPesoColumna("FechaProceso", 115);
            AsignarPesoColumna("Intentos", 55);
        }

        private void AsignarPesoColumna(string nombre, float peso)
        {
            if (tabla.Columns.Contains(nombre))
                tabla.Columns[nombre].FillWeight = peso;
        }

        private void tabla_SelectionChanged(object sender, EventArgs e)
        {
            if (tabla.CurrentRow == null)
                return;

            string id = Convert.ToString(
                tabla.CurrentRow.Cells["Comprobante"].Value).Trim();
            try
            {
                DataRow fila = servicio.Obtener(id);
                if (fila == null)
                {
                    LimpiarDetalle();
                    return;
                }

                lblDocumento.Text =
                    id + " · " + Convert.ToString(fila["EstadoCpe"]) +
                    " · Intentos: " + Convert.ToString(fila["Intentos"]);
                lblHash.Text = "Hash: " + Convert.ToString(fila["HashCpe"]);
                lblRespuesta.Text =
                    Convert.ToString(fila["CodigoRespuesta"]) + " · " +
                    Convert.ToString(fila["MensajeRespuesta"]);
                txtXml.Text = Convert.ToString(fila["XmlGenerado"]);
                txtCdr.Text = Convert.ToString(fila["CdrContenido"]);
                bool simulado = Convert.ToString(fila["Ambiente"])
                    .Equals("SIMULACION", StringComparison.OrdinalIgnoreCase);
                btnReintentar.Enabled = simulado;
                btnExportarXml.Enabled = txtXml.TextLength > 0;
                btnExportarCdr.Enabled = txtCdr.TextLength > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Detalle CPE",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReintentar_Click(object sender, EventArgs e)
        {
            if (tabla.CurrentRow == null)
                return;
            string id = Convert.ToString(
                tabla.CurrentRow.Cells["Comprobante"].Value).Trim();
            if (MessageBox.Show(
                "¿Reprocesar " + id + " en el simulador local?\n\n" +
                "No se enviará información a SUNAT.",
                "Reintentar CPE simulado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                servicio.ReintentarSimulacion(id);
                CargarDatos();
                MessageBox.Show(
                    "Reintento simulado completado correctamente.",
                    "Centro CPE",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reintento CPE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarContenido(string contenido, string extension)
        {
            if (string.IsNullOrWhiteSpace(contenido))
                return;
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                string id = tabla.CurrentRow == null ? "CPE" :
                    Convert.ToString(tabla.CurrentRow.Cells["Comprobante"].Value);
                dialogo.Filter = "Archivo XML (*.xml)|*.xml";
                dialogo.FileName = id.Trim() + "." + extension;
                if (dialogo.ShowDialog(this) == DialogResult.OK)
                    File.WriteAllText(dialogo.FileName, contenido);
            }
        }

        private void LimpiarDetalle()
        {
            lblDocumento.Text = "Seleccione un comprobante.";
            lblHash.Text = "Hash:";
            lblRespuesta.Text = string.Empty;
            txtXml.Clear();
            txtCdr.Clear();
            btnReintentar.Enabled = false;
            btnExportarXml.Enabled = false;
            btnExportarCdr.Enabled = false;
        }

        private static TextBox CrearVisor()
        {
            return new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both,
                WordWrap = false,
                BackColor = Color.FromArgb(251, 252, 254),
                Font = new Font("Consolas", 9F)
            };
        }

        private static Button CrearBoton(string texto, Color color)
        {
            return new Button
            {
                Text = texto,
                Size = new Size(140, 32),
                FlatStyle = FlatStyle.Flat,
                BackColor = color,
                ForeColor = Color.White,
                FlatAppearance = { BorderSize = 0 },
                Cursor = Cursors.Hand
            };
        }
    }
}
