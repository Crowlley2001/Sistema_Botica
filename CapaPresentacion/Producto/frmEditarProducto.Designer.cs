namespace CapaPresentacion.Producto
{
    partial class frmEditarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarProducto));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimizar = new Guna.UI2.WinForms.Guna2Button();
            this.pic_prod = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_fechaVence = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nomprod = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_idProd = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_catg = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbo_presentacion = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_PA = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_lab = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbo_receta = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_preventa = new Guna.UI2.WinForms.Guna2TextBox();
            this.nud_min = new System.Windows.Forms.NumericUpDown();
            this.nud_max = new System.Windows.Forms.NumericUpDown();
            this.txt_precompra = new Guna.UI2.WinForms.Guna2TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_Limpiar_Productos = new Guna.UI2.WinForms.Guna2Button();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.chk_fechvence = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btn_id = new Guna.UI2.WinForms.Guna2Button();
            this.btn_eliminar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.bt_eliminarProductoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_DarBajaProductoTool = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_max)).BeginInit();
            this.guna2ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.DarkOrchid;
            this.pnl_titu.Controls.Add(this.btn_minimizar);
            this.pnl_titu.Controls.Add(this.pic_prod);
            this.pnl_titu.Controls.Add(this.btn_close);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(699, 68);
            this.pnl_titu.TabIndex = 1;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
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
            this.btn_minimizar.ImageSize = new System.Drawing.Size(99, 69);
            this.btn_minimizar.Location = new System.Drawing.Point(585, 14);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.PressedColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.Size = new System.Drawing.Size(43, 39);
            this.btn_minimizar.TabIndex = 8;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // pic_prod
            // 
            this.pic_prod.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_prod.BackgroundImage")));
            this.pic_prod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_prod.ErrorImage = null;
            this.pic_prod.FillColor = System.Drawing.Color.Transparent;
            this.pic_prod.ImageRotate = 1F;
            this.pic_prod.InitialImage = null;
            this.pic_prod.Location = new System.Drawing.Point(3, 3);
            this.pic_prod.Name = "pic_prod";
            this.pic_prod.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pic_prod.Size = new System.Drawing.Size(92, 66);
            this.pic_prod.TabIndex = 6;
            this.pic_prod.TabStop = false;
            this.pic_prod.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
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
            this.btn_close.ImageSize = new System.Drawing.Size(55, 55);
            this.btn_close.Location = new System.Drawing.Point(625, 10);
            this.btn_close.Name = "btn_close";
            this.btn_close.PressedColor = System.Drawing.Color.Transparent;
            this.btn_close.Size = new System.Drawing.Size(63, 46);
            this.btn_close.TabIndex = 5;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(95, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Edicion de Productos";
            // 
            // dtp_fechaVence
            // 
            this.dtp_fechaVence.BackColor = System.Drawing.Color.Transparent;
            this.dtp_fechaVence.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtp_fechaVence.BorderRadius = 6;
            this.dtp_fechaVence.BorderThickness = 1;
            this.dtp_fechaVence.Checked = true;
            this.dtp_fechaVence.CustomFormat = "dd/MM/yyyy";
            this.dtp_fechaVence.FillColor = System.Drawing.Color.White;
            this.dtp_fechaVence.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_fechaVence.ForeColor = System.Drawing.Color.Black;
            this.dtp_fechaVence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fechaVence.HoverState.FillColor = System.Drawing.Color.White;
            this.dtp_fechaVence.Location = new System.Drawing.Point(22, 359);
            this.dtp_fechaVence.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fechaVence.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fechaVence.Name = "dtp_fechaVence";
            this.dtp_fechaVence.Size = new System.Drawing.Size(304, 36);
            this.dtp_fechaVence.TabIndex = 6;
            this.dtp_fechaVence.Value = new System.DateTime(2025, 12, 27, 16, 59, 37, 704);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Id Producto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Descripcion del Producto/articulo:";
            // 
            // txt_nomprod
            // 
            this.txt_nomprod.BorderRadius = 6;
            this.txt_nomprod.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_nomprod.DefaultText = "";
            this.txt_nomprod.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_nomprod.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_nomprod.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_nomprod.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_nomprod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_nomprod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_nomprod.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_nomprod.Location = new System.Drawing.Point(22, 166);
            this.txt_nomprod.Name = "txt_nomprod";
            this.txt_nomprod.PlaceholderText = "";
            this.txt_nomprod.SelectedText = "";
            this.txt_nomprod.Size = new System.Drawing.Size(457, 32);
            this.txt_nomprod.TabIndex = 14;
            // 
            // txt_idProd
            // 
            this.txt_idProd.BorderRadius = 6;
            this.txt_idProd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_idProd.DefaultText = "";
            this.txt_idProd.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_idProd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_idProd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_idProd.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_idProd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_idProd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_idProd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_idProd.Location = new System.Drawing.Point(22, 106);
            this.txt_idProd.Name = "txt_idProd";
            this.txt_idProd.PlaceholderText = "";
            this.txt_idProd.SelectedText = "";
            this.txt_idProd.Size = new System.Drawing.Size(200, 32);
            this.txt_idProd.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Categoria/Familia:";
            // 
            // cbo_catg
            // 
            this.cbo_catg.BackColor = System.Drawing.Color.Transparent;
            this.cbo_catg.BorderRadius = 6;
            this.cbo_catg.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_catg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_catg.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_catg.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_catg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_catg.ForeColor = System.Drawing.Color.Black;
            this.cbo_catg.ItemHeight = 30;
            this.cbo_catg.Location = new System.Drawing.Point(22, 226);
            this.cbo_catg.MaxDropDownItems = 2;
            this.cbo_catg.Name = "cbo_catg";
            this.cbo_catg.Size = new System.Drawing.Size(457, 36);
            this.cbo_catg.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Presentacion:";
            // 
            // cbo_presentacion
            // 
            this.cbo_presentacion.BackColor = System.Drawing.Color.Transparent;
            this.cbo_presentacion.BorderRadius = 6;
            this.cbo_presentacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_presentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_presentacion.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_presentacion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_presentacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_presentacion.ForeColor = System.Drawing.Color.Black;
            this.cbo_presentacion.ItemHeight = 30;
            this.cbo_presentacion.Items.AddRange(new object[] {
            "Caja",
            "Blister",
            "Capsula",
            "Pastilla",
            "Bolsa",
            "Otro"});
            this.cbo_presentacion.Location = new System.Drawing.Point(503, 226);
            this.cbo_presentacion.MaxDropDownItems = 2;
            this.cbo_presentacion.Name = "cbo_presentacion";
            this.cbo_presentacion.Size = new System.Drawing.Size(170, 36);
            this.cbo_presentacion.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Principio Activo:";
            // 
            // txt_PA
            // 
            this.txt_PA.BorderRadius = 6;
            this.txt_PA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PA.DefaultText = "";
            this.txt_PA.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_PA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_PA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_PA.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_PA.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_PA.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_PA.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_PA.Location = new System.Drawing.Point(22, 290);
            this.txt_PA.Name = "txt_PA";
            this.txt_PA.PlaceholderText = "";
            this.txt_PA.SelectedText = "";
            this.txt_PA.Size = new System.Drawing.Size(304, 32);
            this.txt_PA.TabIndex = 22;
            // 
            // txt_lab
            // 
            this.txt_lab.BorderRadius = 6;
            this.txt_lab.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_lab.DefaultText = "";
            this.txt_lab.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_lab.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_lab.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_lab.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_lab.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_lab.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_lab.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_lab.Location = new System.Drawing.Point(369, 290);
            this.txt_lab.Name = "txt_lab";
            this.txt_lab.PlaceholderText = "";
            this.txt_lab.SelectedText = "";
            this.txt_lab.Size = new System.Drawing.Size(304, 32);
            this.txt_lab.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(377, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Laboratorio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(377, 343);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Requiere Receta Med.?:";
            // 
            // cbo_receta
            // 
            this.cbo_receta.BackColor = System.Drawing.Color.Transparent;
            this.cbo_receta.BorderRadius = 6;
            this.cbo_receta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_receta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_receta.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_receta.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_receta.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_receta.ForeColor = System.Drawing.Color.Black;
            this.cbo_receta.ItemHeight = 30;
            this.cbo_receta.Items.AddRange(new object[] {
            "No",
            "Si"});
            this.cbo_receta.Location = new System.Drawing.Point(371, 359);
            this.cbo_receta.MaxDropDownItems = 2;
            this.cbo_receta.Name = "cbo_receta";
            this.cbo_receta.Size = new System.Drawing.Size(302, 36);
            this.cbo_receta.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Und Minimo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(177, 410);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Und Maxima:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(92, 529);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Precio Compra:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(320, 529);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Precio Venta:";
            // 
            // txt_preventa
            // 
            this.txt_preventa.BorderRadius = 6;
            this.txt_preventa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_preventa.DefaultText = "";
            this.txt_preventa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_preventa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_preventa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_preventa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_preventa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_preventa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_preventa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_preventa.Location = new System.Drawing.Point(314, 545);
            this.txt_preventa.Name = "txt_preventa";
            this.txt_preventa.PlaceholderText = "";
            this.txt_preventa.SelectedText = "";
            this.txt_preventa.Size = new System.Drawing.Size(156, 32);
            this.txt_preventa.TabIndex = 35;
            this.txt_preventa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_preventa_KeyPress);
            // 
            // nud_min
            // 
            this.nud_min.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_min.Location = new System.Drawing.Point(22, 426);
            this.nud_min.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_min.Name = "nud_min";
            this.nud_min.Size = new System.Drawing.Size(120, 25);
            this.nud_min.TabIndex = 37;
            this.nud_min.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_max
            // 
            this.nud_max.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_max.Location = new System.Drawing.Point(170, 426);
            this.nud_max.Name = "nud_max";
            this.nud_max.Size = new System.Drawing.Size(120, 25);
            this.nud_max.TabIndex = 38;
            // 
            // txt_precompra
            // 
            this.txt_precompra.BorderRadius = 6;
            this.txt_precompra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_precompra.DefaultText = "";
            this.txt_precompra.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_precompra.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_precompra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_precompra.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_precompra.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_precompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_precompra.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_precompra.Location = new System.Drawing.Point(86, 545);
            this.txt_precompra.Name = "txt_precompra";
            this.txt_precompra.PlaceholderText = "";
            this.txt_precompra.SelectedText = "";
            this.txt_precompra.Size = new System.Drawing.Size(156, 32);
            this.txt_precompra.TabIndex = 33;
            this.txt_precompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_precompra_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Silver;
            this.label14.Location = new System.Drawing.Point(56, 589);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(445, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "_________________________________________________________________________";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(18, 470);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 21);
            this.label15.TabIndex = 44;
            this.label15.Text = "Establecer Precios:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_Limpiar_Productos
            // 
            this.btn_Limpiar_Productos.BackColor = System.Drawing.Color.White;
            this.btn_Limpiar_Productos.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_Limpiar_Productos.BorderRadius = 6;
            this.btn_Limpiar_Productos.BorderThickness = 1;
            this.btn_Limpiar_Productos.DisabledState.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_Limpiar_Productos.DisabledState.CustomBorderColor = System.Drawing.Color.MediumPurple;
            this.btn_Limpiar_Productos.DisabledState.FillColor = System.Drawing.Color.MediumPurple;
            this.btn_Limpiar_Productos.DisabledState.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_Limpiar_Productos.FillColor = System.Drawing.Color.White;
            this.btn_Limpiar_Productos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_Limpiar_Productos.ForeColor = System.Drawing.Color.Black;
            this.btn_Limpiar_Productos.Image = ((System.Drawing.Image)(resources.GetObject("btn_Limpiar_Productos.Image")));
            this.btn_Limpiar_Productos.Location = new System.Drawing.Point(75, 617);
            this.btn_Limpiar_Productos.Name = "btn_Limpiar_Productos";
            this.btn_Limpiar_Productos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_Limpiar_Productos.Size = new System.Drawing.Size(135, 43);
            this.btn_Limpiar_Productos.TabIndex = 41;
            this.btn_Limpiar_Productos.Text = "Limpiar";
            this.btn_Limpiar_Productos.Click += new System.EventHandler(this.btn_Limpiar_Productos_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.White;
            this.btn_save.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_save.BorderRadius = 6;
            this.btn_save.BorderThickness = 1;
            this.btn_save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_save.FillColor = System.Drawing.Color.Transparent;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.Location = new System.Drawing.Point(216, 617);
            this.btn_save.Name = "btn_save";
            this.btn_save.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_save.Size = new System.Drawing.Size(116, 43);
            this.btn_save.TabIndex = 40;
            this.btn_save.Text = "Guardar";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // chk_fechvence
            // 
            this.chk_fechvence.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_fechvence.BackColor = System.Drawing.Color.White;
            this.chk_fechvence.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chk_fechvence.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.chk_fechvence.CheckedState.BorderRadius = 1;
            this.chk_fechvence.CheckedState.BorderThickness = 1;
            this.chk_fechvence.CheckedState.FillColor = System.Drawing.Color.White;
            this.chk_fechvence.CheckMarkColor = System.Drawing.Color.Black;
            this.chk_fechvence.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chk_fechvence.ForeColor = System.Drawing.Color.Black;
            this.chk_fechvence.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_fechvence.Location = new System.Drawing.Point(22, 328);
            this.chk_fechvence.Name = "chk_fechvence";
            this.chk_fechvence.Size = new System.Drawing.Size(195, 28);
            this.chk_fechvence.TabIndex = 47;
            this.chk_fechvence.Text = "Tiene Fecha Vence:";
            this.chk_fechvence.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.chk_fechvence.UncheckedState.BorderRadius = 0;
            this.chk_fechvence.UncheckedState.BorderThickness = 0;
            this.chk_fechvence.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_fechvence.UseVisualStyleBackColor = false;
            this.chk_fechvence.CheckedChanged += new System.EventHandler(this.chk_fechvence_CheckedChanged_1);
            // 
            // btn_id
            // 
            this.btn_id.BackColor = System.Drawing.Color.White;
            this.btn_id.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_id.BorderRadius = 6;
            this.btn_id.BorderThickness = 1;
            this.btn_id.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_id.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_id.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_id.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_id.FillColor = System.Drawing.Color.Transparent;
            this.btn_id.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_id.ForeColor = System.Drawing.Color.Black;
            this.btn_id.Image = ((System.Drawing.Image)(resources.GetObject("btn_id.Image")));
            this.btn_id.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_id.Location = new System.Drawing.Point(566, 106);
            this.btn_id.Name = "btn_id";
            this.btn_id.Size = new System.Drawing.Size(113, 27);
            this.btn_id.TabIndex = 48;
            this.btn_id.Text = "Registrar ID";
            this.btn_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_id.Visible = false;
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.White;
            this.btn_eliminar.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_eliminar.BorderRadius = 6;
            this.btn_eliminar.BorderThickness = 1;
            this.btn_eliminar.ContextMenuStrip = this.guna2ContextMenuStrip1;
            this.btn_eliminar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_eliminar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_eliminar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_eliminar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_eliminar.FillColor = System.Drawing.Color.Transparent;
            this.btn_eliminar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_eliminar.ForeColor = System.Drawing.Color.Black;
            this.btn_eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_eliminar.Image")));
            this.btn_eliminar.Location = new System.Drawing.Point(338, 617);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_eliminar.Size = new System.Drawing.Size(141, 43);
            this.btn_eliminar.TabIndex = 49;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bt_eliminarProductoTool,
            this.bt_DarBajaProductoTool});
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(170, 48);
            // 
            // bt_eliminarProductoTool
            // 
            this.bt_eliminarProductoTool.Name = "bt_eliminarProductoTool";
            this.bt_eliminarProductoTool.Size = new System.Drawing.Size(169, 22);
            this.bt_eliminarProductoTool.Text = "Eliminar Producto";
            this.bt_eliminarProductoTool.Click += new System.EventHandler(this.bt_eliminarProductoTool_Click);
            // 
            // bt_DarBajaProductoTool
            // 
            this.bt_DarBajaProductoTool.Name = "bt_DarBajaProductoTool";
            this.bt_DarBajaProductoTool.Size = new System.Drawing.Size(169, 22);
            this.bt_DarBajaProductoTool.Text = "Dar Baja Producto";
            this.bt_DarBajaProductoTool.Click += new System.EventHandler(this.bt_DarBajaProductoTool_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(22, 494);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 23);
            this.panel2.TabIndex = 50;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.DarkOrchid;
            this.label27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label27.Location = new System.Drawing.Point(0, 683);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(699, 11);
            this.label27.TabIndex = 802;
            // 
            // frmEditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(699, 694);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_id);
            this.Controls.Add(this.chk_fechvence);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_Limpiar_Productos);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.nud_max);
            this.Controls.Add(this.nud_min);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_preventa);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt_precompra);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbo_receta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_lab);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_PA);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbo_presentacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbo_catg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_idProd);
            this.Controls.Add(this.txt_nomprod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_fechaVence);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProducto";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_max)).EndInit();
            this.guna2ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_fechaVence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_idProd;
        private Guna.UI2.WinForms.Guna2TextBox txt_nomprod;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_catg;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txt_PA;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_presentacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txt_lab;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2ComboBox cbo_receta;
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox txt_preventa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nud_min;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_prod;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private Guna.UI2.WinForms.Guna2Button btn_Limpiar_Productos;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2TextBox txt_precompra;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.NumericUpDown nud_max;
        private Guna.UI2.WinForms.Guna2CheckBox chk_fechvence;
        private Guna.UI2.WinForms.Guna2Button btn_id;
        private Guna.UI2.WinForms.Guna2Button btn_eliminar;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bt_eliminarProductoTool;
        private System.Windows.Forms.ToolStripMenuItem bt_DarBajaProductoTool;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btn_minimizar;
        private System.Windows.Forms.Label label27;
    }
}