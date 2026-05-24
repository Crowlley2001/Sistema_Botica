namespace CapaPresentacion.Factura
{
    partial class frm_Solo_Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Solo_Usuario));
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.cbo_users = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btrn_aceptar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.dtp_fn_Usu = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnl_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_titulo
            // 
            this.pnl_titulo.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnl_titulo.Controls.Add(this.pictureBox1);
            this.pnl_titulo.Controls.Add(this.label1);
            this.pnl_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titulo.Location = new System.Drawing.Point(0, 0);
            this.pnl_titulo.Name = "pnl_titulo";
            this.pnl_titulo.Size = new System.Drawing.Size(418, 88);
            this.pnl_titulo.TabIndex = 810;
            this.pnl_titulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titulo_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(154, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 786;
            this.label1.Text = "Consultas";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 12;
            this.bunifuElipse1.TargetControl = this;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.AutoSize = false;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(50, 297);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(312, 10);
            this.kryptonBorderEdge1.StateCommon.Image = ((System.Drawing.Image)(resources.GetObject("kryptonBorderEdge1.StateCommon.Image")));
            this.kryptonBorderEdge1.StateCommon.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // cbo_users
            // 
            this.cbo_users.BackColor = System.Drawing.Color.Transparent;
            this.cbo_users.BorderColor = System.Drawing.Color.DimGray;
            this.cbo_users.BorderRadius = 6;
            this.cbo_users.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_users.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_users.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_users.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_users.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_users.ForeColor = System.Drawing.Color.DimGray;
            this.cbo_users.ItemHeight = 30;
            this.cbo_users.Location = new System.Drawing.Point(84, 147);
            this.cbo_users.MaxDropDownItems = 2;
            this.cbo_users.Name = "cbo_users";
            this.cbo_users.Size = new System.Drawing.Size(240, 36);
            this.cbo_users.TabIndex = 817;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(81, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 816;
            this.label2.Text = "Elige un Usuario:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DimGray;
            this.label20.Location = new System.Drawing.Point(81, 207);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(143, 20);
            this.label20.TabIndex = 815;
            this.label20.Text = "Elegir un Mes y Año:";
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
            this.btrn_aceptar.Location = new System.Drawing.Point(230, 329);
            this.btrn_aceptar.Name = "btrn_aceptar";
            this.btrn_aceptar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btrn_aceptar.Size = new System.Drawing.Size(137, 39);
            this.btrn_aceptar.TabIndex = 814;
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
            this.btn_cancelar.Location = new System.Drawing.Point(49, 327);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_cancelar.Size = new System.Drawing.Size(139, 41);
            this.btn_cancelar.TabIndex = 813;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseTransparentBackground = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // dtp_fn_Usu
            // 
            this.dtp_fn_Usu.BackColor = System.Drawing.Color.White;
            this.dtp_fn_Usu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtp_fn_Usu.BorderRadius = 5;
            this.dtp_fn_Usu.BorderThickness = 1;
            this.dtp_fn_Usu.Checked = true;
            this.dtp_fn_Usu.CustomFormat = "dd/MM/yyyy";
            this.dtp_fn_Usu.FillColor = System.Drawing.Color.White;
            this.dtp_fn_Usu.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.dtp_fn_Usu.ForeColor = System.Drawing.Color.DimGray;
            this.dtp_fn_Usu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fn_Usu.HoverState.FillColor = System.Drawing.Color.White;
            this.dtp_fn_Usu.Location = new System.Drawing.Point(85, 232);
            this.dtp_fn_Usu.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fn_Usu.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fn_Usu.Name = "dtp_fn_Usu";
            this.dtp_fn_Usu.Size = new System.Drawing.Size(240, 36);
            this.dtp_fn_Usu.TabIndex = 812;
            this.dtp_fn_Usu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtp_fn_Usu.Value = new System.DateTime(2026, 1, 31, 0, 0, 0, 0);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(182, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 787;
            this.pictureBox1.TabStop = false;
            // 
            // frm_Solo_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(418, 410);
            this.Controls.Add(this.pnl_titulo);
            this.Controls.Add(this.kryptonBorderEdge1);
            this.Controls.Add(this.cbo_users);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btrn_aceptar);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.dtp_fn_Usu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Solo_Usuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Solo_Usuario";
            this.Load += new System.EventHandler(this.frm_Solo_Usuario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Solo_Usuario_KeyDown);
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Krypton.Toolkit.KryptonBorderEdge kryptonBorderEdge1;
        internal Guna.UI2.WinForms.Guna2ComboBox cbo_users;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private Guna.UI2.WinForms.Guna2Button btrn_aceptar;
        private Guna.UI2.WinForms.Guna2Button btn_cancelar;
        internal Guna.UI2.WinForms.Guna2DateTimePicker dtp_fn_Usu;
    }
}