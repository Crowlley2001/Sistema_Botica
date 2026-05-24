namespace CapaPresentacion.Producto
{
    partial class frmProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducto));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimizar = new Guna.UI2.WinForms.Guna2Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_prod = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.dtp_fechaVence = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txt_stock = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nomprod = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
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
            this.chk_fechvence = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chk_bar = new Guna.UI2.WinForms.Guna2CheckBox();
            this.btn_cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.pnl_reg = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_max)).BeginInit();
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
            this.pnl_titu.Controls.Add(this.label16);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Controls.Add(this.pic_prod);
            this.pnl_titu.Controls.Add(this.btn_close);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(701, 69);
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
            this.btn_minimizar.Location = new System.Drawing.Point(589, 15);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.PressedColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.Size = new System.Drawing.Size(43, 39);
            this.btn_minimizar.TabIndex = 51;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(101, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(177, 21);
            this.label16.TabIndex = 50;
            this.label16.Text = "Registro de Productos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(116, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 49;
            // 
            // pic_prod
            // 
            this.pic_prod.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_prod.BackgroundImage")));
            this.pic_prod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_prod.ErrorImage = null;
            this.pic_prod.FillColor = System.Drawing.Color.Transparent;
            this.pic_prod.ImageRotate = 1F;
            this.pic_prod.InitialImage = null;
            this.pic_prod.Location = new System.Drawing.Point(0, 3);
            this.pic_prod.Name = "pic_prod";
            this.pic_prod.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pic_prod.Size = new System.Drawing.Size(95, 61);
            this.pic_prod.TabIndex = 6;
            this.pic_prod.TabStop = false;
            this.pic_prod.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.DarkOrchid;
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
            this.btn_close.Location = new System.Drawing.Point(632, 16);
            this.btn_close.Name = "btn_close";
            this.btn_close.PressedColor = System.Drawing.Color.Transparent;
            this.btn_close.Size = new System.Drawing.Size(55, 37);
            this.btn_close.TabIndex = 5;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
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
            this.dtp_fechaVence.Location = new System.Drawing.Point(25, 354);
            this.dtp_fechaVence.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fechaVence.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fechaVence.Name = "dtp_fechaVence";
            this.dtp_fechaVence.Size = new System.Drawing.Size(304, 36);
            this.dtp_fechaVence.TabIndex = 6;
            this.dtp_fechaVence.Value = new System.DateTime(2025, 12, 27, 16, 59, 37, 704);
            // 
            // txt_stock
            // 
            this.txt_stock.BorderRadius = 6;
            this.txt_stock.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_stock.DefaultText = "";
            this.txt_stock.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_stock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_stock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_stock.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_stock.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_stock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_stock.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_stock.Location = new System.Drawing.Point(506, 161);
            this.txt_stock.Name = "txt_stock";
            this.txt_stock.PlaceholderText = "";
            this.txt_stock.SelectedText = "";
            this.txt_stock.Size = new System.Drawing.Size(170, 32);
            this.txt_stock.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Id Producto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 145);
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
            this.txt_nomprod.Location = new System.Drawing.Point(25, 161);
            this.txt_nomprod.Name = "txt_nomprod";
            this.txt_nomprod.PlaceholderText = "";
            this.txt_nomprod.SelectedText = "";
            this.txt_nomprod.Size = new System.Drawing.Size(457, 32);
            this.txt_nomprod.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(513, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Stock:";
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
            this.txt_idProd.Location = new System.Drawing.Point(25, 101);
            this.txt_idProd.Name = "txt_idProd";
            this.txt_idProd.PlaceholderText = "";
            this.txt_idProd.SelectedText = "";
            this.txt_idProd.Size = new System.Drawing.Size(200, 32);
            this.txt_idProd.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 205);
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
            this.cbo_catg.Location = new System.Drawing.Point(25, 221);
            this.cbo_catg.MaxDropDownItems = 2;
            this.cbo_catg.Name = "cbo_catg";
            this.cbo_catg.Size = new System.Drawing.Size(457, 36);
            this.cbo_catg.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(513, 205);
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
            this.cbo_presentacion.Location = new System.Drawing.Point(506, 221);
            this.cbo_presentacion.MaxDropDownItems = 2;
            this.cbo_presentacion.Name = "cbo_presentacion";
            this.cbo_presentacion.Size = new System.Drawing.Size(170, 36);
            this.cbo_presentacion.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 269);
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
            this.txt_PA.Location = new System.Drawing.Point(25, 285);
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
            this.txt_lab.Location = new System.Drawing.Point(372, 285);
            this.txt_lab.Name = "txt_lab";
            this.txt_lab.PlaceholderText = "";
            this.txt_lab.SelectedText = "";
            this.txt_lab.Size = new System.Drawing.Size(304, 32);
            this.txt_lab.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Laboratorio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(380, 338);
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
            this.cbo_receta.Location = new System.Drawing.Point(374, 354);
            this.cbo_receta.MaxDropDownItems = 2;
            this.cbo_receta.Name = "cbo_receta";
            this.cbo_receta.Size = new System.Drawing.Size(302, 36);
            this.cbo_receta.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 405);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Und Minimo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(180, 405);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Und Maxima:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(95, 524);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Precio Compra:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(323, 524);
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
            this.txt_preventa.Location = new System.Drawing.Point(317, 540);
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
            this.nud_min.Location = new System.Drawing.Point(25, 421);
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
            this.nud_max.Location = new System.Drawing.Point(173, 421);
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
            this.txt_precompra.Location = new System.Drawing.Point(89, 540);
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
            this.label14.Location = new System.Drawing.Point(59, 584);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(445, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "_________________________________________________________________________";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(21, 465);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 21);
            this.label15.TabIndex = 44;
            this.label15.Text = "Establecer Precios:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            this.chk_fechvence.Location = new System.Drawing.Point(25, 323);
            this.chk_fechvence.Name = "chk_fechvence";
            this.chk_fechvence.Size = new System.Drawing.Size(197, 28);
            this.chk_fechvence.TabIndex = 47;
            this.chk_fechvence.Text = "Tiene Fecha Vence:";
            this.chk_fechvence.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.chk_fechvence.UncheckedState.BorderRadius = 0;
            this.chk_fechvence.UncheckedState.BorderThickness = 0;
            this.chk_fechvence.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_fechvence.UseVisualStyleBackColor = false;
            this.chk_fechvence.CheckedChanged += new System.EventHandler(this.chk_fechvence_CheckedChanged_1);
            // 
            // chk_bar
            // 
            this.chk_bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chk_bar.BackColor = System.Drawing.Color.White;
            this.chk_bar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chk_bar.BackgroundImage")));
            this.chk_bar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chk_bar.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.chk_bar.CheckedState.BorderRadius = 1;
            this.chk_bar.CheckedState.BorderThickness = 1;
            this.chk_bar.CheckedState.FillColor = System.Drawing.Color.White;
            this.chk_bar.CheckMarkColor = System.Drawing.Color.Black;
            this.chk_bar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chk_bar.ForeColor = System.Drawing.Color.Black;
            this.chk_bar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_bar.Location = new System.Drawing.Point(243, 101);
            this.chk_bar.Name = "chk_bar";
            this.chk_bar.Size = new System.Drawing.Size(247, 41);
            this.chk_bar.TabIndex = 46;
            this.chk_bar.Text = "Usar Codigo Barra";
            this.chk_bar.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.chk_bar.UncheckedState.BorderRadius = 0;
            this.chk_bar.UncheckedState.BorderThickness = 0;
            this.chk_bar.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_bar.UseVisualStyleBackColor = false;
            this.chk_bar.CheckedChanged += new System.EventHandler(this.chk_bar_CheckedChanged);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.White;
            this.btn_cancelar.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_cancelar.BorderRadius = 6;
            this.btn_cancelar.BorderThickness = 1;
            this.btn_cancelar.DisabledState.BorderColor = System.Drawing.Color.MediumPurple;
            this.btn_cancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar.DisabledState.FillColor = System.Drawing.Color.MediumPurple;
            this.btn_cancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancelar.FillColor = System.Drawing.Color.White;
            this.btn_cancelar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_cancelar.ForeColor = System.Drawing.Color.Black;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.Location = new System.Drawing.Point(89, 612);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_cancelar.Size = new System.Drawing.Size(173, 43);
            this.btn_cancelar.TabIndex = 41;
            this.btn_cancelar.Text = "Limpiar";
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
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
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Black;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.Location = new System.Drawing.Point(291, 612);
            this.btn_save.Name = "btn_save";
            this.btn_save.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_save.Size = new System.Drawing.Size(173, 43);
            this.btn_save.TabIndex = 40;
            this.btn_save.Text = "Guardar";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // pnl_reg
            // 
            this.pnl_reg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_reg.BackgroundImage")));
            this.pnl_reg.Enabled = false;
            this.pnl_reg.Location = new System.Drawing.Point(25, 489);
            this.pnl_reg.Name = "pnl_reg";
            this.pnl_reg.Size = new System.Drawing.Size(440, 22);
            this.pnl_reg.TabIndex = 48;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.DarkOrchid;
            this.label27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label27.Location = new System.Drawing.Point(0, 676);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(701, 12);
            this.label27.TabIndex = 802;
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(701, 688);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.pnl_reg);
            this.Controls.Add(this.chk_fechvence);
            this.Controls.Add(this.chk_bar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_cancelar);
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
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_nomprod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_stock);
            this.Controls.Add(this.dtp_fechaVence);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmProducto";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_max)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_fechaVence;
        private Guna.UI2.WinForms.Guna2TextBox txt_stock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_idProd;
        private System.Windows.Forms.Label label4;
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
        private Guna.UI2.WinForms.Guna2Button btn_cancelar;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2TextBox txt_precompra;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2CheckBox chk_bar;
        internal System.Windows.Forms.NumericUpDown nud_max;
        private Guna.UI2.WinForms.Guna2CheckBox chk_fechvence;
        internal System.Windows.Forms.Panel pnl_reg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2Button btn_minimizar;
        private System.Windows.Forms.Label label27;
    }
}