namespace CapaPresentacion.Cajas
{
    partial class frm_Inicio_Caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Inicio_Caja));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_importe = new Guna.UI2.WinForms.Guna2TextBox();
            this.btrn_aceptar = new Guna.UI2.WinForms.Guna2Button();
            this.pnl_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnl_titulo.Controls.Add(this.btn_cerrar);
            this.pnl_titulo.Controls.Add(this.pictureBox1);
            this.pnl_titulo.Controls.Add(this.label1);
            this.pnl_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(308, 90);
            this.pnl_titulo.TabIndex = 786;
            this.pnl_titulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titulo_MouseMove);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkOrchid;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrchid;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cerrar.Image")));
            this.btn_cerrar.Location = new System.Drawing.Point(274, 12);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(15, 21);
            this.btn_cerrar.TabIndex = 786;
            this.btn_cerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(123, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 785;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(71, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inicio de Caja";
            // 
            // txt_importe
            // 
            this.txt_importe.BorderRadius = 6;
            this.txt_importe.BorderThickness = 3;
            this.txt_importe.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_importe.DefaultText = "00.0";
            this.txt_importe.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_importe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_importe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_importe.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_importe.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_importe.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.txt_importe.ForeColor = System.Drawing.Color.DimGray;
            this.txt_importe.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_importe.Location = new System.Drawing.Point(55, 111);
            this.txt_importe.Margin = new System.Windows.Forms.Padding(5);
            this.txt_importe.Name = "txt_importe";
            this.txt_importe.PlaceholderText = "";
            this.txt_importe.SelectedText = "";
            this.txt_importe.Size = new System.Drawing.Size(190, 51);
            this.txt_importe.TabIndex = 1;
            this.txt_importe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_importe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_importe_KeyDown);
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
            this.btrn_aceptar.Location = new System.Drawing.Point(83, 204);
            this.btrn_aceptar.Name = "btrn_aceptar";
            this.btrn_aceptar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btrn_aceptar.Size = new System.Drawing.Size(137, 39);
            this.btrn_aceptar.TabIndex = 808;
            this.btrn_aceptar.Text = "Aceptar";
            this.btrn_aceptar.UseTransparentBackground = true;
            this.btrn_aceptar.Click += new System.EventHandler(this.btrn_aceptar_Click);
            // 
            // frm_Inicio_Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(308, 277);
            this.Controls.Add(this.btrn_aceptar);
            this.Controls.Add(this.txt_importe);
            this.Controls.Add(this.pnl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_Inicio_Caja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Caja";
            this.Load += new System.EventHandler(this.frm_Inicio_Caja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Inicio_Caja_KeyDown);
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        internal Guna.UI2.WinForms.Guna2TextBox txt_importe;
        private Guna.UI2.WinForms.Guna2Button btrn_aceptar;
        private System.Windows.Forms.Button btn_cerrar;
    }
}