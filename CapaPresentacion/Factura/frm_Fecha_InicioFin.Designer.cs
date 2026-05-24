namespace CapaPresentacion.Factura
{
    partial class frm_Fecha_InicioFin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btrn_aceptar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.dtp_inicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtp_fin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.pnl_titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnl_titulo.Controls.Add(this.label1);
            this.pnl_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(554, 68);
            this.pnl_titulo.TabIndex = 797;
            this.pnl_titulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titulo_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 32);
            this.label1.TabIndex = 802;
            this.label1.Text = "Seleccionar Fecha Inicio && Fin";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 12;
            this.bunifuElipse1.TargetControl = this;
            // 
            // btrn_aceptar
            // 
            this.btrn_aceptar.BackColor = System.Drawing.Color.Transparent;
            this.btrn_aceptar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btrn_aceptar.BorderRadius = 20;
            this.btrn_aceptar.BorderThickness = 1;
            this.btrn_aceptar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btrn_aceptar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btrn_aceptar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btrn_aceptar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btrn_aceptar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btrn_aceptar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btrn_aceptar.ForeColor = System.Drawing.Color.White;
            this.btrn_aceptar.ImageSize = new System.Drawing.Size(30, 30);
            this.btrn_aceptar.Location = new System.Drawing.Point(390, 99);
            this.btrn_aceptar.Name = "btrn_aceptar";
            this.btrn_aceptar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btrn_aceptar.Size = new System.Drawing.Size(137, 39);
            this.btrn_aceptar.TabIndex = 800;
            this.btrn_aceptar.Text = "Aceptar";
            this.btrn_aceptar.UseTransparentBackground = true;
            this.btrn_aceptar.Click += new System.EventHandler(this.btrn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.BorderColor = System.Drawing.Color.Silver;
            this.btn_cancelar.BorderRadius = 20;
            this.btn_cancelar.BorderThickness = 1;
            this.btn_cancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancelar.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cancelar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_cancelar.ImageSize = new System.Drawing.Size(25, 25);
            this.btn_cancelar.Location = new System.Drawing.Point(389, 161);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_cancelar.Size = new System.Drawing.Size(139, 41);
            this.btn_cancelar.TabIndex = 799;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseTransparentBackground = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // dtp_inicio
            // 
            this.dtp_inicio.BackColor = System.Drawing.Color.White;
            this.dtp_inicio.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtp_inicio.BorderRadius = 10;
            this.dtp_inicio.BorderThickness = 1;
            this.dtp_inicio.Checked = true;
            this.dtp_inicio.CustomFormat = "dd/MM/yyyy";
            this.dtp_inicio.FillColor = System.Drawing.Color.White;
            this.dtp_inicio.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.dtp_inicio.ForeColor = System.Drawing.Color.DimGray;
            this.dtp_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_inicio.HoverState.FillColor = System.Drawing.Color.White;
            this.dtp_inicio.Location = new System.Drawing.Point(22, 99);
            this.dtp_inicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_inicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_inicio.Name = "dtp_inicio";
            this.dtp_inicio.Size = new System.Drawing.Size(327, 36);
            this.dtp_inicio.TabIndex = 798;
            this.dtp_inicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtp_inicio.Value = new System.DateTime(2026, 1, 31, 0, 0, 0, 0);
            // 
            // dtp_fin
            // 
            this.dtp_fin.BackColor = System.Drawing.Color.White;
            this.dtp_fin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtp_fin.BorderRadius = 10;
            this.dtp_fin.BorderThickness = 1;
            this.dtp_fin.Checked = true;
            this.dtp_fin.CustomFormat = "dd/MM/yyyy";
            this.dtp_fin.FillColor = System.Drawing.Color.White;
            this.dtp_fin.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.dtp_fin.ForeColor = System.Drawing.Color.DimGray;
            this.dtp_fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fin.HoverState.FillColor = System.Drawing.Color.White;
            this.dtp_fin.Location = new System.Drawing.Point(22, 163);
            this.dtp_fin.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fin.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fin.Name = "dtp_fin";
            this.dtp_fin.Size = new System.Drawing.Size(327, 36);
            this.dtp_fin.TabIndex = 801;
            this.dtp_fin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtp_fin.Value = new System.DateTime(2026, 1, 31, 0, 0, 0, 0);
            // 
            // frm_Fecha_InicioFin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(554, 237);
            this.Controls.Add(this.dtp_fin);
            this.Controls.Add(this.pnl_titulo);
            this.Controls.Add(this.btrn_aceptar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.dtp_inicio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Fecha_InicioFin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Fecha_InicioFin";
            this.Load += new System.EventHandler(this.frm_Fecha_InicioFin_Load);
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Guna.UI2.WinForms.Guna2Button btrn_aceptar;
        private Guna.UI2.WinForms.Guna2Button btn_cancelar;
        internal Guna.UI2.WinForms.Guna2DateTimePicker dtp_inicio;
        internal Guna.UI2.WinForms.Guna2DateTimePicker dtp_fin;
    }
}