namespace CapaPresentacion.Ventas
{
    partial class frm_TerminarVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TerminarVenta));
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.BunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Total_acobrar = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_vuelto = new Guna.UI2.WinForms.Guna2TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_Acuenta = new Guna.UI2.WinForms.Guna2TextBox();
            this.btrn_imprimir = new Guna.UI2.WinForms.Guna2Button();
            this.btn_salir = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_msm = new System.Windows.Forms.Label();
            this.pnl_tarjeta = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            this.pnl_tarjeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(12, 426);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(373, 24);
            this.label10.TabIndex = 644;
            this.label10.Text = "_________________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(106, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Terminar Venta";
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DarkGreen;
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(404, 69);
            this.pnl_titu.TabIndex = 640;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // BunifuElipse1
            // 
            this.BunifuElipse1.ElipseRadius = 20;
            this.BunifuElipse1.TargetControl = this;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(68, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 22);
            this.label3.TabIndex = 649;
            this.label3.Text = "Total venta S/.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Total_acobrar
            // 
            this.txt_Total_acobrar.BackColor = System.Drawing.Color.Transparent;
            this.txt_Total_acobrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_Total_acobrar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_Total_acobrar.BorderRadius = 5;
            this.txt_Total_acobrar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Total_acobrar.DefaultText = "";
            this.txt_Total_acobrar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Total_acobrar.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_Total_acobrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Total_acobrar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Total_acobrar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_Total_acobrar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Total_acobrar.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total_acobrar.ForeColor = System.Drawing.Color.White;
            this.txt_Total_acobrar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Total_acobrar.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_Total_acobrar.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_Total_acobrar.Location = new System.Drawing.Point(67, 192);
            this.txt_Total_acobrar.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.txt_Total_acobrar.Name = "txt_Total_acobrar";
            this.txt_Total_acobrar.PlaceholderForeColor = System.Drawing.Color.White;
            this.txt_Total_acobrar.PlaceholderText = "00";
            this.txt_Total_acobrar.ReadOnly = true;
            this.txt_Total_acobrar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Total_acobrar.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_Total_acobrar.SelectedText = "";
            this.txt_Total_acobrar.Size = new System.Drawing.Size(271, 68);
            this.txt_Total_acobrar.TabIndex = 648;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Tomato;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(68, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 26);
            this.label4.TabIndex = 651;
            this.label4.Text = "Su Cambio S/";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_vuelto
            // 
            this.txt_vuelto.BackColor = System.Drawing.Color.Transparent;
            this.txt_vuelto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_vuelto.BorderColor = System.Drawing.Color.Tomato;
            this.txt_vuelto.BorderRadius = 5;
            this.txt_vuelto.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_vuelto.DefaultText = "";
            this.txt_vuelto.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_vuelto.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_vuelto.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_vuelto.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_vuelto.FillColor = System.Drawing.Color.Tomato;
            this.txt_vuelto.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_vuelto.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_vuelto.ForeColor = System.Drawing.Color.White;
            this.txt_vuelto.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_vuelto.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_vuelto.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_vuelto.Location = new System.Drawing.Point(67, 298);
            this.txt_vuelto.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.txt_vuelto.Name = "txt_vuelto";
            this.txt_vuelto.PlaceholderForeColor = System.Drawing.Color.White;
            this.txt_vuelto.PlaceholderText = "00.00";
            this.txt_vuelto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_vuelto.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_vuelto.SelectedText = "";
            this.txt_vuelto.Size = new System.Drawing.Size(271, 68);
            this.txt_vuelto.TabIndex = 650;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DimGray;
            this.label19.Location = new System.Drawing.Point(70, 96);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 22);
            this.label19.TabIndex = 653;
            this.label19.Text = "Pagó con S/.";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_Acuenta
            // 
            this.txt_Acuenta.BackColor = System.Drawing.Color.Transparent;
            this.txt_Acuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_Acuenta.BorderColor = System.Drawing.Color.DimGray;
            this.txt_Acuenta.BorderRadius = 5;
            this.txt_Acuenta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Acuenta.DefaultText = "";
            this.txt_Acuenta.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Acuenta.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_Acuenta.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Acuenta.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Acuenta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Acuenta.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Acuenta.ForeColor = System.Drawing.Color.DimGray;
            this.txt_Acuenta.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Acuenta.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_Acuenta.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_Acuenta.Location = new System.Drawing.Point(67, 93);
            this.txt_Acuenta.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.txt_Acuenta.Name = "txt_Acuenta";
            this.txt_Acuenta.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txt_Acuenta.PlaceholderText = "0";
            this.txt_Acuenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_Acuenta.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_Acuenta.SelectedText = "";
            this.txt_Acuenta.Size = new System.Drawing.Size(271, 68);
            this.txt_Acuenta.TabIndex = 652;
            this.txt_Acuenta.TextChanged += new System.EventHandler(this.txt_Acuenta_TextChanged);
            this.txt_Acuenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Acuenta_KeyDown);
            this.txt_Acuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Acuenta_KeyPress);
            // 
            // btrn_imprimir
            // 
            this.btrn_imprimir.BackColor = System.Drawing.Color.Transparent;
            this.btrn_imprimir.BorderColor = System.Drawing.Color.DimGray;
            this.btrn_imprimir.BorderRadius = 30;
            this.btrn_imprimir.BorderThickness = 1;
            this.btrn_imprimir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btrn_imprimir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btrn_imprimir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btrn_imprimir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btrn_imprimir.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btrn_imprimir.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btrn_imprimir.ForeColor = System.Drawing.Color.DimGray;
            this.btrn_imprimir.Image = ((System.Drawing.Image)(resources.GetObject("btrn_imprimir.Image")));
            this.btrn_imprimir.ImageSize = new System.Drawing.Size(30, 30);
            this.btrn_imprimir.Location = new System.Drawing.Point(210, 465);
            this.btrn_imprimir.Name = "btrn_imprimir";
            this.btrn_imprimir.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btrn_imprimir.Size = new System.Drawing.Size(161, 60);
            this.btrn_imprimir.TabIndex = 655;
            this.btrn_imprimir.Text = "Imprimir";
            this.btrn_imprimir.UseTransparentBackground = true;
            this.btrn_imprimir.Click += new System.EventHandler(this.btrn_imprimir_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Transparent;
            this.btn_salir.BorderColor = System.Drawing.Color.DimGray;
            this.btn_salir.BorderRadius = 30;
            this.btn_salir.BorderThickness = 1;
            this.btn_salir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_salir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_salir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_salir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_salir.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btn_salir.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_salir.ForeColor = System.Drawing.Color.DimGray;
            this.btn_salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_salir.Image")));
            this.btn_salir.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_salir.Location = new System.Drawing.Point(34, 465);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_salir.Size = new System.Drawing.Size(142, 60);
            this.btn_salir.TabIndex = 654;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseTransparentBackground = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // lbl_msm
            // 
            this.lbl_msm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_msm.ForeColor = System.Drawing.Color.Red;
            this.lbl_msm.Location = new System.Drawing.Point(63, 399);
            this.lbl_msm.Name = "lbl_msm";
            this.lbl_msm.Size = new System.Drawing.Size(277, 21);
            this.lbl_msm.TabIndex = 660;
            this.lbl_msm.Text = "(*) A cuenta no debe ser superior al Total";
            this.lbl_msm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_tarjeta
            // 
            this.pnl_tarjeta.Controls.Add(this.label2);
            this.pnl_tarjeta.Location = new System.Drawing.Point(7, 75);
            this.pnl_tarjeta.Name = "pnl_tarjeta";
            this.pnl_tarjeta.Size = new System.Drawing.Size(385, 364);
            this.pnl_tarjeta.TabIndex = 661;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(90, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Pago con Tarjeta";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Tomato;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(404, 5);
            this.label5.TabIndex = 801;
            // 
            // frm_TerminarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 555);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnl_tarjeta);
            this.Controls.Add(this.lbl_msm);
            this.Controls.Add(this.btrn_imprimir);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txt_Acuenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_vuelto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Total_acobrar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_TerminarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_TerminarVenta";
            this.Load += new System.EventHandler(this.frm_TerminarVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_TerminarVenta_KeyDown);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.pnl_tarjeta.ResumeLayout(false);
            this.pnl_tarjeta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_titu;
        internal Bunifu.Framework.UI.BunifuElipse BunifuElipse1;
        internal System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txt_vuelto;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label19;
        private Guna.UI2.WinForms.Guna2Button btrn_imprimir;
        private Guna.UI2.WinForms.Guna2Button btn_salir;
        public Guna.UI2.WinForms.Guna2TextBox txt_Total_acobrar;
        public Guna.UI2.WinForms.Guna2TextBox txt_Acuenta;
        public System.Windows.Forms.Panel pnl_tarjeta;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lbl_msm;
        private System.Windows.Forms.Label label5;
    }
}