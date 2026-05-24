namespace CapaPresentacion.Producto
{
    partial class frm_Menu_Kardex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Menu_Kardex));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.dtp_hoy = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbl_TotalItem = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_fechaKardex = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lbl_new = new System.Windows.Forms.Label();
            this.txt_buscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_usuario = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.btn_minimizar = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsv_prod = new System.Windows.Forms.ListView();
            this.Consultar_Kardex_MenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Ver_Movimientos_KardexStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator45 = new System.Windows.Forms.ToolStripSeparator();
            this.Copiar_IdKardexStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator46 = new System.Windows.Forms.ToolStripSeparator();
            this.Calcular_Valor_KardexStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator47 = new System.Windows.Forms.ToolStripSeparator();
            this.verProductosDeNivelacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk_mostrar_todo = new Guna.UI2.WinForms.Guna2CheckBox();
            this.group_totales = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txt_totalnegativo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_totalpositivo = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.pnl_resul = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.pic_prod = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.Consultar_Kardex_MenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.group_totales.SuspendLayout();
            this.pnl_resul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnl_titu.Controls.Add(this.dtp_hoy);
            this.pnl_titu.Controls.Add(this.lbl_TotalItem);
            this.pnl_titu.Controls.Add(this.label25);
            this.pnl_titu.Controls.Add(this.label3);
            this.pnl_titu.Controls.Add(this.dtp_fechaKardex);
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
            this.pnl_titu.Size = new System.Drawing.Size(1277, 64);
            this.pnl_titu.TabIndex = 2;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // dtp_hoy
            // 
            this.dtp_hoy.BackColor = System.Drawing.Color.Transparent;
            this.dtp_hoy.BorderColor = System.Drawing.Color.White;
            this.dtp_hoy.BorderRadius = 6;
            this.dtp_hoy.BorderThickness = 1;
            this.dtp_hoy.Checked = true;
            this.dtp_hoy.CheckedState.FillColor = System.Drawing.Color.White;
            this.dtp_hoy.CustomFormat = "dd/MM/yyyy";
            this.dtp_hoy.FillColor = System.Drawing.Color.White;
            this.dtp_hoy.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dtp_hoy.ForeColor = System.Drawing.Color.Gray;
            this.dtp_hoy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_hoy.Location = new System.Drawing.Point(148, 32);
            this.dtp_hoy.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_hoy.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_hoy.Name = "dtp_hoy";
            this.dtp_hoy.Size = new System.Drawing.Size(120, 27);
            this.dtp_hoy.TabIndex = 661;
            this.dtp_hoy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtp_hoy.UseTransparentBackground = true;
            this.dtp_hoy.Value = new System.DateTime(2025, 12, 27, 16, 59, 37, 704);
            this.dtp_hoy.Visible = false;
            // 
            // lbl_TotalItem
            // 
            this.lbl_TotalItem.AutoSize = true;
            this.lbl_TotalItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalItem.ForeColor = System.Drawing.Color.White;
            this.lbl_TotalItem.Location = new System.Drawing.Point(99, 46);
            this.lbl_TotalItem.Name = "lbl_TotalItem";
            this.lbl_TotalItem.Size = new System.Drawing.Size(19, 13);
            this.lbl_TotalItem.TabIndex = 660;
            this.lbl_TotalItem.Text = "00";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(79, 29);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 13);
            this.label25.TabIndex = 659;
            this.label25.Text = "Total Items";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(819, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 658;
            this.label3.Text = "Buscar por Dia";
            // 
            // dtp_fechaKardex
            // 
            this.dtp_fechaKardex.BackColor = System.Drawing.Color.Transparent;
            this.dtp_fechaKardex.BorderColor = System.Drawing.Color.White;
            this.dtp_fechaKardex.BorderRadius = 6;
            this.dtp_fechaKardex.BorderThickness = 1;
            this.dtp_fechaKardex.Checked = true;
            this.dtp_fechaKardex.CheckedState.FillColor = System.Drawing.Color.White;
            this.dtp_fechaKardex.CustomFormat = "dd/MM/yyyy";
            this.dtp_fechaKardex.FillColor = System.Drawing.Color.White;
            this.dtp_fechaKardex.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.dtp_fechaKardex.ForeColor = System.Drawing.Color.Gray;
            this.dtp_fechaKardex.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fechaKardex.Location = new System.Drawing.Point(820, 20);
            this.dtp_fechaKardex.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fechaKardex.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fechaKardex.Name = "dtp_fechaKardex";
            this.dtp_fechaKardex.Size = new System.Drawing.Size(120, 27);
            this.dtp_fechaKardex.TabIndex = 657;
            this.dtp_fechaKardex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtp_fechaKardex.UseTransparentBackground = true;
            this.dtp_fechaKardex.Value = new System.DateTime(2025, 12, 27, 16, 59, 37, 704);
            this.dtp_fechaKardex.ValueChanged += new System.EventHandler(this.dtp_fechaKardex_ValueChanged);
            // 
            // lbl_new
            // 
            this.lbl_new.BackColor = System.Drawing.Color.White;
            this.lbl_new.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_new.Image = ((System.Drawing.Image)(resources.GetObject("lbl_new.Image")));
            this.lbl_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_new.Location = new System.Drawing.Point(1143, 12);
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
            this.txt_buscar.Size = new System.Drawing.Size(164, 38);
            this.txt_buscar.TabIndex = 34;
            this.txt_buscar.TextChanged += new System.EventHandler(this.txt_buscar_TextChanged_1);
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
            this.txt_usuario.Size = new System.Drawing.Size(214, 42);
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
            this.btn_close.Location = new System.Drawing.Point(1218, 15);
            this.btn_close.Name = "btn_close";
            this.btn_close.PressedColor = System.Drawing.Color.Transparent;
            this.btn_close.Size = new System.Drawing.Size(51, 40);
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
            this.btn_minimizar.Location = new System.Drawing.Point(1192, 15);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.PressedColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.Size = new System.Drawing.Size(37, 39);
            this.btn_minimizar.TabIndex = 6;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Menu de Todos los Movimientos de los  Productos";
            // 
            // lsv_prod
            // 
            this.lsv_prod.BackColor = System.Drawing.Color.White;
            this.lsv_prod.ContextMenuStrip = this.Consultar_Kardex_MenuStrip1;
            this.lsv_prod.HideSelection = false;
            this.lsv_prod.Location = new System.Drawing.Point(0, 64);
            this.lsv_prod.Name = "lsv_prod";
            this.lsv_prod.Size = new System.Drawing.Size(1277, 527);
            this.lsv_prod.TabIndex = 3;
            this.lsv_prod.UseCompatibleStateImageBehavior = false;
            this.lsv_prod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsv_prod_KeyDown);
            // 
            // Consultar_Kardex_MenuStrip1
            // 
            this.Consultar_Kardex_MenuStrip1.BackColor = System.Drawing.Color.White;
            this.Consultar_Kardex_MenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Consultar_Kardex_MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ver_Movimientos_KardexStripMenuItem1,
            this.toolStripSeparator45,
            this.Copiar_IdKardexStripMenuItem2,
            this.toolStripSeparator46,
            this.Calcular_Valor_KardexStripMenuItem3,
            this.toolStripSeparator47,
            this.verProductosDeNivelacionToolStripMenuItem});
            this.Consultar_Kardex_MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.Consultar_Kardex_MenuStrip1.Name = "contextMenuStrip1";
            this.Consultar_Kardex_MenuStrip1.Size = new System.Drawing.Size(235, 142);
            this.Consultar_Kardex_MenuStrip1.Text = "Consultar por Rango Fecha";
            // 
            // Ver_Movimientos_KardexStripMenuItem1
            // 
            this.Ver_Movimientos_KardexStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.Ver_Movimientos_KardexStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Ver_Movimientos_KardexStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("Ver_Movimientos_KardexStripMenuItem1.Image")));
            this.Ver_Movimientos_KardexStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Ver_Movimientos_KardexStripMenuItem1.Name = "Ver_Movimientos_KardexStripMenuItem1";
            this.Ver_Movimientos_KardexStripMenuItem1.Size = new System.Drawing.Size(234, 30);
            this.Ver_Movimientos_KardexStripMenuItem1.Text = "Ver Movimientos del Dia";
            this.Ver_Movimientos_KardexStripMenuItem1.Click += new System.EventHandler(this.Ver_Movimientos_KardexStripMenuItem1_Click);
            // 
            // toolStripSeparator45
            // 
            this.toolStripSeparator45.Name = "toolStripSeparator45";
            this.toolStripSeparator45.Size = new System.Drawing.Size(231, 6);
            // 
            // Copiar_IdKardexStripMenuItem2
            // 
            this.Copiar_IdKardexStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Copiar_IdKardexStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("Copiar_IdKardexStripMenuItem2.Image")));
            this.Copiar_IdKardexStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Copiar_IdKardexStripMenuItem2.Name = "Copiar_IdKardexStripMenuItem2";
            this.Copiar_IdKardexStripMenuItem2.Size = new System.Drawing.Size(234, 30);
            this.Copiar_IdKardexStripMenuItem2.Text = "Copiar ID del Producto";
            this.Copiar_IdKardexStripMenuItem2.Click += new System.EventHandler(this.Copiar_IdKardexStripMenuItem2_Click);
            // 
            // toolStripSeparator46
            // 
            this.toolStripSeparator46.Name = "toolStripSeparator46";
            this.toolStripSeparator46.Size = new System.Drawing.Size(231, 6);
            // 
            // Calcular_Valor_KardexStripMenuItem3
            // 
            this.Calcular_Valor_KardexStripMenuItem3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Calcular_Valor_KardexStripMenuItem3.Image = ((System.Drawing.Image)(resources.GetObject("Calcular_Valor_KardexStripMenuItem3.Image")));
            this.Calcular_Valor_KardexStripMenuItem3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Calcular_Valor_KardexStripMenuItem3.Name = "Calcular_Valor_KardexStripMenuItem3";
            this.Calcular_Valor_KardexStripMenuItem3.Size = new System.Drawing.Size(234, 30);
            this.Calcular_Valor_KardexStripMenuItem3.Text = "Copiar Nro Doc.";
            this.Calcular_Valor_KardexStripMenuItem3.Click += new System.EventHandler(this.Calcular_Valor_KardexStripMenuItem3_Click);
            // 
            // toolStripSeparator47
            // 
            this.toolStripSeparator47.Name = "toolStripSeparator47";
            this.toolStripSeparator47.Size = new System.Drawing.Size(231, 6);
            // 
            // verProductosDeNivelacionToolStripMenuItem
            // 
            this.verProductosDeNivelacionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verProductosDeNivelacionToolStripMenuItem.Image")));
            this.verProductosDeNivelacionToolStripMenuItem.Name = "verProductosDeNivelacionToolStripMenuItem";
            this.verProductosDeNivelacionToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.verProductosDeNivelacionToolStripMenuItem.Text = "Ver Productos de Nivelacion";
            this.verProductosDeNivelacionToolStripMenuItem.Click += new System.EventHandler(this.verProductosDeNivelacionToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.chk_mostrar_todo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 554);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1277, 38);
            this.panel2.TabIndex = 9;
            // 
            // chk_mostrar_todo
            // 
            this.chk_mostrar_todo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_mostrar_todo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chk_mostrar_todo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chk_mostrar_todo.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.chk_mostrar_todo.CheckedState.BorderRadius = 1;
            this.chk_mostrar_todo.CheckedState.BorderThickness = 1;
            this.chk_mostrar_todo.CheckedState.FillColor = System.Drawing.Color.White;
            this.chk_mostrar_todo.CheckMarkColor = System.Drawing.Color.Black;
            this.chk_mostrar_todo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_mostrar_todo.ForeColor = System.Drawing.Color.White;
            this.chk_mostrar_todo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_mostrar_todo.Location = new System.Drawing.Point(1175, 5);
            this.chk_mostrar_todo.Name = "chk_mostrar_todo";
            this.chk_mostrar_todo.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.chk_mostrar_todo.Size = new System.Drawing.Size(91, 28);
            this.chk_mostrar_todo.TabIndex = 50;
            this.chk_mostrar_todo.Text = "Ver Todos:";
            this.chk_mostrar_todo.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.chk_mostrar_todo.UncheckedState.BorderRadius = 0;
            this.chk_mostrar_todo.UncheckedState.BorderThickness = 0;
            this.chk_mostrar_todo.UncheckedState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.chk_mostrar_todo.UseVisualStyleBackColor = false;
            // 
            // group_totales
            // 
            this.group_totales.AutoScroll = true;
            this.group_totales.BackColor = System.Drawing.Color.Transparent;
            this.group_totales.BorderColor = System.Drawing.Color.DarkOrchid;
            this.group_totales.BorderRadius = 10;
            this.group_totales.Controls.Add(this.txt_totalnegativo);
            this.group_totales.Controls.Add(this.txt_totalpositivo);
            this.group_totales.Controls.Add(this.label5);
            this.group_totales.Controls.Add(this.label4);
            this.group_totales.Cursor = System.Windows.Forms.Cursors.Default;
            this.group_totales.CustomBorderColor = System.Drawing.Color.White;
            this.group_totales.CustomBorderThickness = new System.Windows.Forms.Padding(0);
            this.group_totales.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.group_totales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.group_totales.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.group_totales.Location = new System.Drawing.Point(979, 472);
            this.group_totales.Margin = new System.Windows.Forms.Padding(0);
            this.group_totales.Name = "group_totales";
            this.group_totales.ShadowDecoration.BorderRadius = 0;
            this.group_totales.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0);
            this.group_totales.Size = new System.Drawing.Size(283, 71);
            this.group_totales.TabIndex = 803;
            this.group_totales.UseTransparentBackground = true;
            this.group_totales.Visible = false;
            // 
            // txt_totalnegativo
            // 
            this.txt_totalnegativo.BackColor = System.Drawing.Color.White;
            this.txt_totalnegativo.BorderColor = System.Drawing.Color.White;
            this.txt_totalnegativo.BorderRadius = 6;
            this.txt_totalnegativo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_totalnegativo.DefaultText = "0.00";
            this.txt_totalnegativo.DisabledState.BorderColor = System.Drawing.Color.White;
            this.txt_totalnegativo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_totalnegativo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalnegativo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalnegativo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalnegativo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txt_totalnegativo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalnegativo.Location = new System.Drawing.Point(189, 37);
            this.txt_totalnegativo.Name = "txt_totalnegativo";
            this.txt_totalnegativo.PlaceholderText = "";
            this.txt_totalnegativo.SelectedText = "";
            this.txt_totalnegativo.Size = new System.Drawing.Size(59, 25);
            this.txt_totalnegativo.TabIndex = 818;
            // 
            // txt_totalpositivo
            // 
            this.txt_totalpositivo.BackColor = System.Drawing.Color.White;
            this.txt_totalpositivo.BorderColor = System.Drawing.Color.White;
            this.txt_totalpositivo.BorderRadius = 6;
            this.txt_totalpositivo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_totalpositivo.DefaultText = "0.00";
            this.txt_totalpositivo.DisabledState.BorderColor = System.Drawing.Color.White;
            this.txt_totalpositivo.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_totalpositivo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalpositivo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalpositivo.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txt_totalpositivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txt_totalpositivo.HoverState.BorderColor = System.Drawing.Color.White;
            this.txt_totalpositivo.HoverState.FillColor = System.Drawing.Color.White;
            this.txt_totalpositivo.Location = new System.Drawing.Point(53, 37);
            this.txt_totalpositivo.Name = "txt_totalpositivo";
            this.txt_totalpositivo.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txt_totalpositivo.PlaceholderText = "";
            this.txt_totalpositivo.SelectedText = "";
            this.txt_totalpositivo.Size = new System.Drawing.Size(59, 25);
            this.txt_totalpositivo.TabIndex = 819;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(27, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 818;
            this.label5.Text = "Total Positivo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(173, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 816;
            this.label4.Text = "Total Negativo";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_save.BorderRadius = 13;
            this.btn_save.BorderThickness = 1;
            this.btn_save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_save.Enabled = false;
            this.btn_save.FillColor = System.Drawing.Color.DarkOrchid;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_save.Location = new System.Drawing.Point(988, 459);
            this.btn_save.Name = "btn_save";
            this.btn_save.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_save.Size = new System.Drawing.Size(125, 25);
            this.btn_save.TabIndex = 817;
            this.btn_save.Text = "Totales";
            this.btn_save.UseTransparentBackground = true;
            this.btn_save.Visible = false;
            // 
            // pnl_resul
            // 
            this.pnl_resul.ContextMenuStrip = this.Consultar_Kardex_MenuStrip1;
            this.pnl_resul.Controls.Add(this.guna2Separator2);
            this.pnl_resul.Controls.Add(this.pic_prod);
            this.pnl_resul.Controls.Add(this.label2);
            this.pnl_resul.Location = new System.Drawing.Point(1, 65);
            this.pnl_resul.Name = "pnl_resul";
            this.pnl_resul.Size = new System.Drawing.Size(1276, 489);
            this.pnl_resul.TabIndex = 818;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Separator2.BackgroundImage")));
            this.guna2Separator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Separator2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Separator2.FillThickness = 3;
            this.guna2Separator2.Location = new System.Drawing.Point(194, 256);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(933, 24);
            this.guna2Separator2.TabIndex = 8;
            // 
            // pic_prod
            // 
            this.pic_prod.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_prod.BackgroundImage")));
            this.pic_prod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_prod.ErrorImage = null;
            this.pic_prod.FillColor = System.Drawing.Color.Transparent;
            this.pic_prod.ImageRotate = 1F;
            this.pic_prod.InitialImage = null;
            this.pic_prod.Location = new System.Drawing.Point(568, 130);
            this.pic_prod.Name = "pic_prod";
            this.pic_prod.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pic_prod.Size = new System.Drawing.Size(120, 83);
            this.pic_prod.TabIndex = 7;
            this.pic_prod.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(385, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(491, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "LA BUSQUEDA NO TUVO RESULTADO";
            // 
            // frm_Menu_Kardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 592);
            this.Controls.Add(this.pnl_resul);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.group_totales);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lsv_prod);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_Menu_Kardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu_Producto";
            this.Load += new System.EventHandler(this.Menu_Producto_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.Consultar_Kardex_MenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.group_totales.ResumeLayout(false);
            this.group_totales.PerformLayout();
            this.pnl_resul.ResumeLayout(false);
            this.pnl_resul.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private Guna.UI2.WinForms.Guna2Button btn_minimizar;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_new;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txt_buscar;
        private Guna.UI2.WinForms.Guna2TextBox txt_usuario;
        internal System.Windows.Forms.ListView lsv_prod;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2CheckBox chk_mostrar_todo;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_fechaKardex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_TotalItem;
        private System.Windows.Forms.Label label25;
        public Guna.UI2.WinForms.Guna2GroupBox group_totales;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public Guna.UI2.WinForms.Guna2TextBox txt_totalpositivo;
        public Guna.UI2.WinForms.Guna2TextBox txt_totalnegativo;
        private System.Windows.Forms.ContextMenuStrip Consultar_Kardex_MenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Ver_Movimientos_KardexStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator45;
        private System.Windows.Forms.ToolStripMenuItem Copiar_IdKardexStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator46;
        private System.Windows.Forms.ToolStripMenuItem Calcular_Valor_KardexStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator47;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_hoy;
        internal Guna.UI2.WinForms.Guna2Panel pnl_resul;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_prod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem verProductosDeNivelacionToolStripMenuItem;
    }
}