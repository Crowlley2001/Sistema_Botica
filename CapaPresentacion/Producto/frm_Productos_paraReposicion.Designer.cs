namespace CapaPresentacion.Producto
{
    partial class frm_Productos_paraReposicion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Productos_paraReposicion));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.lblTotalReposicion = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lbl_new = new System.Windows.Forms.Label();
            this.txt_buscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_usuario = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.btn_minimizar = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsv_reposicion = new Krypton.Toolkit.KryptonListView();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnl_titu.Controls.Add(this.lblTotalReposicion);
            this.pnl_titu.Controls.Add(this.label25);
            this.pnl_titu.Controls.Add(this.lbl_new);
            this.pnl_titu.Controls.Add(this.txt_buscar);
            this.pnl_titu.Controls.Add(this.txt_usuario);
            this.pnl_titu.Controls.Add(this.guna2CirclePictureBox1);
            this.pnl_titu.Controls.Add(this.btn_close);
            this.pnl_titu.Controls.Add(this.btn_minimizar);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(871, 64);
            this.pnl_titu.TabIndex = 3;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // lblTotalReposicion
            // 
            this.lblTotalReposicion.AutoSize = true;
            this.lblTotalReposicion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReposicion.ForeColor = System.Drawing.Color.White;
            this.lblTotalReposicion.Location = new System.Drawing.Point(705, 33);
            this.lblTotalReposicion.Name = "lblTotalReposicion";
            this.lblTotalReposicion.Size = new System.Drawing.Size(28, 21);
            this.lblTotalReposicion.TabIndex = 55;
            this.lblTotalReposicion.Text = "00";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(672, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(94, 21);
            this.label25.TabIndex = 54;
            this.label25.Text = "Total Items";
            // 
            // lbl_new
            // 
            this.lbl_new.BackColor = System.Drawing.Color.White;
            this.lbl_new.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_new.Image = ((System.Drawing.Image)(resources.GetObject("lbl_new.Image")));
            this.lbl_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_new.Location = new System.Drawing.Point(1123, 12);
            this.lbl_new.Name = "lbl_new";
            this.lbl_new.Size = new System.Drawing.Size(36, 39);
            this.lbl_new.TabIndex = 4;
            this.lbl_new.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_buscar
            // 
            this.txt_buscar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_buscar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.DefaultText = "";
            this.txt_buscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_buscar.DisabledState.FillColor = System.Drawing.Color.Silver;
            this.txt_buscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_buscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_buscar.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txt_buscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txt_buscar.HoverState.BorderColor = System.Drawing.Color.White;
            this.txt_buscar.Location = new System.Drawing.Point(981, 12);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txt_buscar.PlaceholderText = "Buscar producto";
            this.txt_buscar.SelectedText = "";
            this.txt_buscar.Size = new System.Drawing.Size(146, 38);
            this.txt_buscar.TabIndex = 34;
            // 
            // txt_usuario
            // 
            this.txt_usuario.BackColor = System.Drawing.Color.Transparent;
            this.txt_usuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_usuario.BorderColor = System.Drawing.Color.White;
            this.txt_usuario.BorderRadius = 10;
            this.txt_usuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_usuario.DefaultText = "";
            this.txt_usuario.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_usuario.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_usuario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_usuario.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_usuario.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txt_usuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_usuario.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_usuario.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_usuario.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_usuario.Location = new System.Drawing.Point(972, 11);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.PlaceholderForeColor = System.Drawing.Color.White;
            this.txt_usuario.PlaceholderText = "";
            this.txt_usuario.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_usuario.SelectedText = "";
            this.txt_usuario.Size = new System.Drawing.Size(198, 42);
            this.txt_usuario.TabIndex = 33;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.BackgroundImage")));
            this.guna2CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2CirclePictureBox1.ErrorImage = null;
            this.guna2CirclePictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.ImageRotate = 1F;
            this.guna2CirclePictureBox1.InitialImage = null;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(3, 0);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(73, 64);
            this.guna2CirclePictureBox1.TabIndex = 8;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_close.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_close.FillColor = System.Drawing.Color.DarkOrchid;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btn_close.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btn_close.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageSize = new System.Drawing.Size(35, 35);
            this.btn_close.Location = new System.Drawing.Point(835, 15);
            this.btn_close.Name = "btn_close";
            this.btn_close.PressedColor = System.Drawing.Color.Transparent;
            this.btn_close.Size = new System.Drawing.Size(33, 40);
            this.btn_close.TabIndex = 5;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_minimizar
            // 
            this.btn_minimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_minimizar.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_minimizar.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_minimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_minimizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_minimizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_minimizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_minimizar.FillColor = System.Drawing.Color.DarkOrchid;
            this.btn_minimizar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_minimizar.ForeColor = System.Drawing.Color.White;
            this.btn_minimizar.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_minimizar.Image")));
            this.btn_minimizar.ImageSize = new System.Drawing.Size(64, 45);
            this.btn_minimizar.Location = new System.Drawing.Point(806, 15);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.PressedColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.Size = new System.Drawing.Size(29, 39);
            this.btn_minimizar.TabIndex = 6;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Productos para Repisicion por Stock";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 608);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(871, 16);
            this.panel2.TabIndex = 693;
            // 
            // lsv_reposicion
            // 
            this.lsv_reposicion.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.GridDataCellList;
            this.lsv_reposicion.FullRowSelect = true;
            this.lsv_reposicion.HideSelection = false;
            this.lsv_reposicion.Location = new System.Drawing.Point(3, 70);
            this.lsv_reposicion.Name = "lsv_reposicion";
            this.lsv_reposicion.Size = new System.Drawing.Size(865, 532);
            this.lsv_reposicion.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.lsv_reposicion.TabIndex = 692;
            // 
            // frm_Productos_paraReposicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 624);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lsv_reposicion);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Productos_paraReposicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Productos_paraReposicion";
            this.Load += new System.EventHandler(this.frm_Productos_paraReposicion_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label lbl_new;
        private Guna.UI2.WinForms.Guna2TextBox txt_buscar;
        private Guna.UI2.WinForms.Guna2TextBox txt_usuario;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private Guna.UI2.WinForms.Guna2Button btn_minimizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        public Krypton.Toolkit.KryptonListView lsv_reposicion;
        private System.Windows.Forms.Label lblTotalReposicion;
        private System.Windows.Forms.Label label25;
    }
}