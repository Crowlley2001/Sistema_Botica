namespace CapaPresentacion.Producto
{
    partial class frm_Menu_Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Menu_Producto));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.lbl_new = new System.Windows.Forms.Label();
            this.txt_buscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_usuario = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.btn_minimizar = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsv_prod = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bt_mostrarTodosLosProductosTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_registrarNuevoProductoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_editarEsteProductoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_eliminarProductoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarDeFormaPermanenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_copiarIdDelProductoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_emparejarStockDeProductoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_actualizarPreciosDeProductoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_calcularValorDeAlmacenTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.bt_reportesTool = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_resul = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.pic_prod = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk_todo = new Guna.UI2.WinForms.Guna2CheckBox();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.pnl_resul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.btn_close.Location = new System.Drawing.Point(1213, 15);
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
            this.btn_minimizar.Location = new System.Drawing.Point(1187, 15);
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
            this.label1.Location = new System.Drawing.Point(77, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Menu de Todo los  Productos";
            // 
            // lsv_prod
            // 
            this.lsv_prod.ContextMenuStrip = this.contextMenuStrip1;
            this.lsv_prod.HideSelection = false;
            this.lsv_prod.Location = new System.Drawing.Point(0, 64);
            this.lsv_prod.Name = "lsv_prod";
            this.lsv_prod.Size = new System.Drawing.Size(1277, 527);
            this.lsv_prod.TabIndex = 3;
            this.lsv_prod.UseCompatibleStateImageBehavior = false;
            this.lsv_prod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsv_prod_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bt_mostrarTodosLosProductosTool,
            this.toolStripSeparator1,
            this.bt_registrarNuevoProductoTool,
            this.toolStripSeparator2,
            this.bt_editarEsteProductoTool,
            this.toolStripSeparator3,
            this.bt_eliminarProductoTool,
            this.toolStripSeparator4,
            this.bt_copiarIdDelProductoTool,
            this.toolStripSeparator5,
            this.bt_emparejarStockDeProductoTool,
            this.toolStripSeparator6,
            this.bt_actualizarPreciosDeProductoTool,
            this.bt_calcularValorDeAlmacenTool,
            this.toolStripSeparator7,
            this.bt_reportesTool});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(236, 244);
            // 
            // bt_mostrarTodosLosProductosTool
            // 
            this.bt_mostrarTodosLosProductosTool.Name = "bt_mostrarTodosLosProductosTool";
            this.bt_mostrarTodosLosProductosTool.Size = new System.Drawing.Size(235, 22);
            this.bt_mostrarTodosLosProductosTool.Text = "Mostrar Todos los Productos";
            this.bt_mostrarTodosLosProductosTool.Click += new System.EventHandler(this.bt_mostrarTodosLosProductosTool_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // bt_registrarNuevoProductoTool
            // 
            this.bt_registrarNuevoProductoTool.Name = "bt_registrarNuevoProductoTool";
            this.bt_registrarNuevoProductoTool.Size = new System.Drawing.Size(235, 22);
            this.bt_registrarNuevoProductoTool.Text = "Registrar nuevo Producto";
            this.bt_registrarNuevoProductoTool.Click += new System.EventHandler(this.bt_registrarNuevoProductoTool_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(232, 6);
            // 
            // bt_editarEsteProductoTool
            // 
            this.bt_editarEsteProductoTool.Name = "bt_editarEsteProductoTool";
            this.bt_editarEsteProductoTool.Size = new System.Drawing.Size(235, 22);
            this.bt_editarEsteProductoTool.Text = "Editar este Producto";
            this.bt_editarEsteProductoTool.Click += new System.EventHandler(this.bt_editarEsteProductoTool_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(232, 6);
            // 
            // bt_eliminarProductoTool
            // 
            this.bt_eliminarProductoTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eliminarDeFormaPermanenteToolStripMenuItem,
            this.eliminarDeToolStripMenuItem});
            this.bt_eliminarProductoTool.Name = "bt_eliminarProductoTool";
            this.bt_eliminarProductoTool.Size = new System.Drawing.Size(235, 22);
            this.bt_eliminarProductoTool.Text = "Eliminar Producto";
            // 
            // eliminarDeFormaPermanenteToolStripMenuItem
            // 
            this.eliminarDeFormaPermanenteToolStripMenuItem.Name = "eliminarDeFormaPermanenteToolStripMenuItem";
            this.eliminarDeFormaPermanenteToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.eliminarDeFormaPermanenteToolStripMenuItem.Text = "Eliminar de Forma Permanente";
            // 
            // eliminarDeToolStripMenuItem
            // 
            this.eliminarDeToolStripMenuItem.Name = "eliminarDeToolStripMenuItem";
            this.eliminarDeToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.eliminarDeToolStripMenuItem.Text = "Eliminar de Forma Temporal";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(232, 6);
            // 
            // bt_copiarIdDelProductoTool
            // 
            this.bt_copiarIdDelProductoTool.Name = "bt_copiarIdDelProductoTool";
            this.bt_copiarIdDelProductoTool.Size = new System.Drawing.Size(235, 22);
            this.bt_copiarIdDelProductoTool.Text = "Copiar Id del Producto";
            this.bt_copiarIdDelProductoTool.Click += new System.EventHandler(this.bt_copiarIdDelProductoTool_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(232, 6);
            // 
            // bt_emparejarStockDeProductoTool
            // 
            this.bt_emparejarStockDeProductoTool.Name = "bt_emparejarStockDeProductoTool";
            this.bt_emparejarStockDeProductoTool.Size = new System.Drawing.Size(235, 22);
            this.bt_emparejarStockDeProductoTool.Text = "Emparejar Stock de Producto";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(232, 6);
            // 
            // bt_actualizarPreciosDeProductoTool
            // 
            this.bt_actualizarPreciosDeProductoTool.Name = "bt_actualizarPreciosDeProductoTool";
            this.bt_actualizarPreciosDeProductoTool.Size = new System.Drawing.Size(235, 22);
            this.bt_actualizarPreciosDeProductoTool.Text = "Actualizar Precios de Producto";
            // 
            // bt_calcularValorDeAlmacenTool
            // 
            this.bt_calcularValorDeAlmacenTool.Name = "bt_calcularValorDeAlmacenTool";
            this.bt_calcularValorDeAlmacenTool.Size = new System.Drawing.Size(235, 22);
            this.bt_calcularValorDeAlmacenTool.Text = "Calcular Valor de Almacen";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(232, 6);
            // 
            // bt_reportesTool
            // 
            this.bt_reportesTool.Name = "bt_reportesTool";
            this.bt_reportesTool.Size = new System.Drawing.Size(235, 22);
            this.bt_reportesTool.Text = "<<<< Reportes >>>>";
            // 
            // pnl_resul
            // 
            this.pnl_resul.ContextMenuStrip = this.contextMenuStrip1;
            this.pnl_resul.Controls.Add(this.guna2Separator2);
            this.pnl_resul.Controls.Add(this.pic_prod);
            this.pnl_resul.Controls.Add(this.label2);
            this.pnl_resul.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_resul.Location = new System.Drawing.Point(0, 64);
            this.pnl_resul.Name = "pnl_resul";
            this.pnl_resul.Size = new System.Drawing.Size(1277, 489);
            this.pnl_resul.TabIndex = 4;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.chk_todo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 554);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1277, 38);
            this.panel2.TabIndex = 9;
            // 
            // chk_todo
            // 
            this.chk_todo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_todo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chk_todo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chk_todo.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.chk_todo.CheckedState.BorderRadius = 1;
            this.chk_todo.CheckedState.BorderThickness = 1;
            this.chk_todo.CheckedState.FillColor = System.Drawing.Color.White;
            this.chk_todo.CheckMarkColor = System.Drawing.Color.Black;
            this.chk_todo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_todo.ForeColor = System.Drawing.Color.White;
            this.chk_todo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_todo.Location = new System.Drawing.Point(1175, 5);
            this.chk_todo.Name = "chk_todo";
            this.chk_todo.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.chk_todo.Size = new System.Drawing.Size(91, 28);
            this.chk_todo.TabIndex = 50;
            this.chk_todo.Text = "Ver Todos:";
            this.chk_todo.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.chk_todo.UncheckedState.BorderRadius = 0;
            this.chk_todo.UncheckedState.BorderThickness = 0;
            this.chk_todo.UncheckedState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.chk_todo.UseVisualStyleBackColor = false;
            // 
            // frm_Menu_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 592);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_resul);
            this.Controls.Add(this.lsv_prod);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_Menu_Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu_Producto";
            this.Load += new System.EventHandler(this.Menu_Producto_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pnl_resul.ResumeLayout(false);
            this.pnl_resul.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private Guna.UI2.WinForms.Guna2Button btn_minimizar;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_new;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_prod;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bt_mostrarTodosLosProductosTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem bt_registrarNuevoProductoTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem bt_editarEsteProductoTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem bt_eliminarProductoTool;
        private System.Windows.Forms.ToolStripMenuItem eliminarDeFormaPermanenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem bt_copiarIdDelProductoTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem bt_emparejarStockDeProductoTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem bt_actualizarPreciosDeProductoTool;
        private System.Windows.Forms.ToolStripMenuItem bt_calcularValorDeAlmacenTool;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem bt_reportesTool;
        private System.Windows.Forms.ToolStripMenuItem eliminarDeToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txt_buscar;
        private Guna.UI2.WinForms.Guna2TextBox txt_usuario;
        internal System.Windows.Forms.ListView lsv_prod;
        internal Guna.UI2.WinForms.Guna2Panel pnl_resul;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2CheckBox chk_todo;
    }
}