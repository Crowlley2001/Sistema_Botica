namespace CapaPresentacion.Factura
{
    partial class frmSoloMes
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
            this.dtp_mes = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btrn_aceptar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancelar = new Guna.UI2.WinForms.Guna2Button();
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
            this.pnl_titulo.Size = new System.Drawing.Size(443, 59);
            this.pnl_titulo.TabIndex = 797;
            this.pnl_titulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titulo_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(71, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 46);
            this.label1.TabIndex = 801;
            this.label1.Text = "Consultar por Mes";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 12;
            this.bunifuElipse1.TargetControl = this;
            // 
            // dtp_mes
            // 
            this.dtp_mes.BackColor = System.Drawing.Color.White;
            this.dtp_mes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtp_mes.BorderRadius = 12;
            this.dtp_mes.BorderThickness = 1;
            this.dtp_mes.Checked = true;
            this.dtp_mes.CustomFormat = "MM/yyyy";
            this.dtp_mes.FillColor = System.Drawing.Color.White;
            this.dtp_mes.Font = new System.Drawing.Font("Segoe UI", 19F);
            this.dtp_mes.ForeColor = System.Drawing.Color.DimGray;
            this.dtp_mes.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_mes.HoverState.FillColor = System.Drawing.Color.White;
            this.dtp_mes.Location = new System.Drawing.Point(57, 93);
            this.dtp_mes.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_mes.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_mes.Name = "dtp_mes";
            this.dtp_mes.Size = new System.Drawing.Size(328, 36);
            this.dtp_mes.TabIndex = 798;
            this.dtp_mes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtp_mes.Value = new System.DateTime(2026, 1, 31, 0, 0, 0, 0);
            // 
            // btrn_aceptar
            // 
            this.btrn_aceptar.BackColor = System.Drawing.Color.Transparent;
            this.btrn_aceptar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btrn_aceptar.BorderRadius = 25;
            this.btrn_aceptar.BorderThickness = 1;
            this.btrn_aceptar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btrn_aceptar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btrn_aceptar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btrn_aceptar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btrn_aceptar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btrn_aceptar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btrn_aceptar.ForeColor = System.Drawing.Color.White;
            this.btrn_aceptar.ImageSize = new System.Drawing.Size(30, 30);
            this.btrn_aceptar.Location = new System.Drawing.Point(231, 160);
            this.btrn_aceptar.Name = "btrn_aceptar";
            this.btrn_aceptar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btrn_aceptar.Size = new System.Drawing.Size(154, 48);
            this.btrn_aceptar.TabIndex = 800;
            this.btrn_aceptar.Text = "Aceptar";
            this.btrn_aceptar.UseTransparentBackground = true;
            this.btrn_aceptar.Click += new System.EventHandler(this.btrn_aceptar_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.BorderColor = System.Drawing.Color.Silver;
            this.btn_cancelar.BorderRadius = 25;
            this.btn_cancelar.BorderThickness = 1;
            this.btn_cancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancelar.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cancelar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_cancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_cancelar.ImageSize = new System.Drawing.Size(25, 25);
            this.btn_cancelar.Location = new System.Drawing.Point(48, 160);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_cancelar.Size = new System.Drawing.Size(154, 48);
            this.btn_cancelar.TabIndex = 799;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseTransparentBackground = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // frmSoloMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 244);
            this.Controls.Add(this.pnl_titulo);
            this.Controls.Add(this.dtp_mes);
            this.Controls.Add(this.btrn_aceptar);
            this.Controls.Add(this.btn_cancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSoloMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSoloMes";
            this.Load += new System.EventHandler(this.frmSoloMes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSoloMes_KeyDown);
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        internal Guna.UI2.WinForms.Guna2DateTimePicker dtp_mes;
        private Guna.UI2.WinForms.Guna2Button btrn_aceptar;
        private Guna.UI2.WinForms.Guna2Button btn_cancelar;
        private System.Windows.Forms.Label label1;
    }
}