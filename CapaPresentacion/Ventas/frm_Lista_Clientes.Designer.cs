namespace CapaPresentacion.Ventas
{
    partial class frm_Lista_Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Lista_Clientes));
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.txt_buscar = new Guna.UI2.WinForms.Guna2TextBox();
            this.pic_prod = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.lbl_direccion = new System.Windows.Forms.Label();
            this.lbl_ruc = new System.Windows.Forms.Label();
            this.Lsv_Cliente = new System.Windows.Forms.ListView();
            this.pnl_newCli = new System.Windows.Forms.Panel();
            this.kryptonBorderEdge2 = new Krypton.Toolkit.KryptonBorderEdge();
            this.dtp_fn = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.btrn_registrar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancelar2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bunifuMaterialTextbox1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuMaterialTextbox2 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_id = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_direccion = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_nombre = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txt_ruc = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_elegir = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_nuevo = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).BeginInit();
            this.pnl_newCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.pnl_titu.Controls.Add(this.txt_buscar);
            this.pnl_titu.Controls.Add(this.pic_prod);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(591, 65);
            this.pnl_titu.TabIndex = 2;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove_1);
            // 
            // txt_buscar
            // 
            this.txt_buscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_buscar.BackgroundImage")));
            this.txt_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.txt_buscar.BorderColor = System.Drawing.Color.White;
            this.txt_buscar.BorderRadius = 6;
            this.txt_buscar.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txt_buscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_buscar.DefaultText = "";
            this.txt_buscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_buscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_buscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_buscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_buscar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_buscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_buscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txt_buscar.ForeColor = System.Drawing.Color.White;
            this.txt_buscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_buscar.IconLeft = ((System.Drawing.Image)(resources.GetObject("txt_buscar.IconLeft")));
            this.txt_buscar.Location = new System.Drawing.Point(370, 26);
            this.txt_buscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_buscar.Name = "txt_buscar";
            this.txt_buscar.PlaceholderForeColor = System.Drawing.Color.White;
            this.txt_buscar.PlaceholderText = "Buscar";
            this.txt_buscar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_buscar.SelectedText = "";
            this.txt_buscar.Size = new System.Drawing.Size(205, 24);
            this.txt_buscar.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txt_buscar.TabIndex = 8;
            this.txt_buscar.TextChanged += new System.EventHandler(this.txt_buscar_TextChanged);
            // 
            // pic_prod
            // 
            this.pic_prod.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_prod.BackgroundImage")));
            this.pic_prod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_prod.ErrorImage = null;
            this.pic_prod.FillColor = System.Drawing.Color.Transparent;
            this.pic_prod.ImageRotate = 1F;
            this.pic_prod.InitialImage = null;
            this.pic_prod.Location = new System.Drawing.Point(4, 3);
            this.pic_prod.Name = "pic_prod";
            this.pic_prod.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pic_prod.Size = new System.Drawing.Size(62, 61);
            this.pic_prod.TabIndex = 6;
            this.pic_prod.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Listado de Clientes";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(507, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.TabIndex = 612;
            this.label10.Text = "Estado";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(392, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 611;
            this.label9.Text = "Ruc - Dni";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(31, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 20);
            this.label8.TabIndex = 610;
            this.label8.Text = "Nombre - Razon Social";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Tomato;
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(1, 104);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(590, 11);
            this.guna2Separator1.TabIndex = 613;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Tomato;
            this.label6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label6.Location = new System.Drawing.Point(0, 727);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(591, 29);
            this.label6.TabIndex = 683;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.BackColor = System.Drawing.Color.Tomato;
            this.lbl_id.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_id.Location = new System.Drawing.Point(233, 733);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(15, 20);
            this.lbl_id.TabIndex = 690;
            this.lbl_id.Text = "-";
            this.lbl_id.Visible = false;
            // 
            // lbl_nom
            // 
            this.lbl_nom.AutoSize = true;
            this.lbl_nom.BackColor = System.Drawing.Color.Tomato;
            this.lbl_nom.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nom.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nom.Location = new System.Drawing.Point(201, 732);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(15, 20);
            this.lbl_nom.TabIndex = 689;
            this.lbl_nom.Text = "-";
            this.lbl_nom.Visible = false;
            // 
            // lbl_direccion
            // 
            this.lbl_direccion.AutoSize = true;
            this.lbl_direccion.BackColor = System.Drawing.Color.Tomato;
            this.lbl_direccion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_direccion.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_direccion.Location = new System.Drawing.Point(169, 732);
            this.lbl_direccion.Name = "lbl_direccion";
            this.lbl_direccion.Size = new System.Drawing.Size(15, 20);
            this.lbl_direccion.TabIndex = 688;
            this.lbl_direccion.Text = "-";
            this.lbl_direccion.Visible = false;
            // 
            // lbl_ruc
            // 
            this.lbl_ruc.AutoSize = true;
            this.lbl_ruc.BackColor = System.Drawing.Color.Tomato;
            this.lbl_ruc.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ruc.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_ruc.Location = new System.Drawing.Point(143, 732);
            this.lbl_ruc.Name = "lbl_ruc";
            this.lbl_ruc.Size = new System.Drawing.Size(15, 20);
            this.lbl_ruc.TabIndex = 687;
            this.lbl_ruc.Text = "-";
            this.lbl_ruc.Visible = false;
            // 
            // Lsv_Cliente
            // 
            this.Lsv_Cliente.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.Lsv_Cliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Lsv_Cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lsv_Cliente.ForeColor = System.Drawing.Color.DimGray;
            this.Lsv_Cliente.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.Lsv_Cliente.HideSelection = false;
            this.Lsv_Cliente.Location = new System.Drawing.Point(1, 113);
            this.Lsv_Cliente.Name = "Lsv_Cliente";
            this.Lsv_Cliente.Size = new System.Drawing.Size(590, 611);
            this.Lsv_Cliente.TabIndex = 693;
            this.Lsv_Cliente.UseCompatibleStateImageBehavior = false;
            this.Lsv_Cliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lsv_Cliente_KeyDown);
            this.Lsv_Cliente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Lsv_Cliente_MouseDoubleClick_2);
            // 
            // pnl_newCli
            // 
            this.pnl_newCli.BackColor = System.Drawing.Color.White;
            this.pnl_newCli.Controls.Add(this.kryptonBorderEdge2);
            this.pnl_newCli.Controls.Add(this.dtp_fn);
            this.pnl_newCli.Controls.Add(this.btn_close);
            this.pnl_newCli.Controls.Add(this.guna2Button2);
            this.pnl_newCli.Controls.Add(this.btrn_registrar);
            this.pnl_newCli.Controls.Add(this.btn_cancelar2);
            this.pnl_newCli.Controls.Add(this.guna2Separator3);
            this.pnl_newCli.Controls.Add(this.label2);
            this.pnl_newCli.Controls.Add(this.label3);
            this.pnl_newCli.Controls.Add(this.label4);
            this.pnl_newCli.Controls.Add(this.label5);
            this.pnl_newCli.Controls.Add(this.bunifuMaterialTextbox1);
            this.pnl_newCli.Controls.Add(this.bunifuMaterialTextbox2);
            this.pnl_newCli.Controls.Add(this.txt_id);
            this.pnl_newCli.Controls.Add(this.txt_direccion);
            this.pnl_newCli.Controls.Add(this.txt_nombre);
            this.pnl_newCli.Controls.Add(this.txt_ruc);
            this.pnl_newCli.Controls.Add(this.label7);
            this.pnl_newCli.Location = new System.Drawing.Point(0, 65);
            this.pnl_newCli.Name = "pnl_newCli";
            this.pnl_newCli.Size = new System.Drawing.Size(593, 691);
            this.pnl_newCli.TabIndex = 694;
            this.pnl_newCli.Visible = false;
            // 
            // kryptonBorderEdge2
            // 
            this.kryptonBorderEdge2.AutoSize = false;
            this.kryptonBorderEdge2.Location = new System.Drawing.Point(17, 553);
            this.kryptonBorderEdge2.Name = "kryptonBorderEdge2";
            this.kryptonBorderEdge2.Size = new System.Drawing.Size(551, 10);
            this.kryptonBorderEdge2.StateCommon.Image = ((System.Drawing.Image)(resources.GetObject("kryptonBorderEdge2.StateCommon.Image")));
            this.kryptonBorderEdge2.StateCommon.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.kryptonBorderEdge2.Text = "kryptonBorderEdge2";
            // 
            // dtp_fn
            // 
            this.dtp_fn.BackColor = System.Drawing.Color.White;
            this.dtp_fn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtp_fn.BorderRadius = 6;
            this.dtp_fn.BorderThickness = 1;
            this.dtp_fn.Checked = true;
            this.dtp_fn.CheckedState.FillColor = System.Drawing.Color.White;
            this.dtp_fn.CustomFormat = "dd/MM/yyyy";
            this.dtp_fn.FillColor = System.Drawing.Color.White;
            this.dtp_fn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_fn.ForeColor = System.Drawing.Color.Black;
            this.dtp_fn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fn.Location = new System.Drawing.Point(107, 575);
            this.dtp_fn.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fn.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fn.Name = "dtp_fn";
            this.dtp_fn.Size = new System.Drawing.Size(397, 36);
            this.dtp_fn.TabIndex = 650;
            this.dtp_fn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtp_fn.Value = new System.DateTime(2025, 12, 27, 16, 59, 37, 704);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BorderColor = System.Drawing.Color.Transparent;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_close.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_close.FillColor = System.Drawing.Color.White;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_close.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.btn_close.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btn_close.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_close.Location = new System.Drawing.Point(524, 15);
            this.btn_close.Name = "btn_close";
            this.btn_close.PressedColor = System.Drawing.Color.Transparent;
            this.btn_close.Size = new System.Drawing.Size(44, 32);
            this.btn_close.TabIndex = 649;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.White;
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.guna2Button2.BorderRadius = 6;
            this.guna2Button2.BorderThickness = 1;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(271, 150);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.guna2Button2.Size = new System.Drawing.Size(186, 34);
            this.guna2Button2.TabIndex = 648;
            this.guna2Button2.Text = "Consultar a Sunat";
            // 
            // btrn_registrar
            // 
            this.btrn_registrar.BackColor = System.Drawing.Color.Transparent;
            this.btrn_registrar.BorderColor = System.Drawing.Color.Tomato;
            this.btrn_registrar.BorderRadius = 12;
            this.btrn_registrar.BorderThickness = 1;
            this.btrn_registrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btrn_registrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btrn_registrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btrn_registrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btrn_registrar.FillColor = System.Drawing.Color.Tomato;
            this.btrn_registrar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btrn_registrar.ForeColor = System.Drawing.Color.White;
            this.btrn_registrar.Image = ((System.Drawing.Image)(resources.GetObject("btrn_registrar.Image")));
            this.btrn_registrar.ImageSize = new System.Drawing.Size(30, 30);
            this.btrn_registrar.Location = new System.Drawing.Point(324, 490);
            this.btrn_registrar.Name = "btrn_registrar";
            this.btrn_registrar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btrn_registrar.Size = new System.Drawing.Size(180, 51);
            this.btrn_registrar.TabIndex = 647;
            this.btrn_registrar.Text = "Registrar";
            this.btrn_registrar.UseTransparentBackground = true;
            this.btrn_registrar.Click += new System.EventHandler(this.btrn_registrar_Click_1);
            // 
            // btn_cancelar2
            // 
            this.btn_cancelar2.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancelar2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_cancelar2.BorderRadius = 12;
            this.btn_cancelar2.BorderThickness = 1;
            this.btn_cancelar2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancelar2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancelar2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_cancelar2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_cancelar2.ForeColor = System.Drawing.Color.White;
            this.btn_cancelar2.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar2.Image")));
            this.btn_cancelar2.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_cancelar2.Location = new System.Drawing.Point(107, 490);
            this.btn_cancelar2.Name = "btn_cancelar2";
            this.btn_cancelar2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_cancelar2.Size = new System.Drawing.Size(180, 51);
            this.btn_cancelar2.TabIndex = 646;
            this.btn_cancelar2.Text = "Limpiar";
            this.btn_cancelar2.UseTransparentBackground = true;
            this.btn_cancelar2.Click += new System.EventHandler(this.btn_cancelar2_Click_1);
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.FillColor = System.Drawing.Color.Tomato;
            this.guna2Separator3.FillThickness = 3;
            this.guna2Separator3.Location = new System.Drawing.Point(10, 53);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(558, 11);
            this.guna2Separator3.TabIndex = 645;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(7, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 631;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(7, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 630;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(7, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 629;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(7, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 628;
            // 
            // bunifuMaterialTextbox1
            // 
            this.bunifuMaterialTextbox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.bunifuMaterialTextbox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.bunifuMaterialTextbox1.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.bunifuMaterialTextbox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMaterialTextbox1.Enabled = false;
            this.bunifuMaterialTextbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.bunifuMaterialTextbox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMaterialTextbox1.HintForeColor = System.Drawing.Color.Empty;
            this.bunifuMaterialTextbox1.HintText = "Tipo  ";
            this.bunifuMaterialTextbox1.isPassword = false;
            this.bunifuMaterialTextbox1.LineFocusedColor = System.Drawing.Color.DarkCyan;
            this.bunifuMaterialTextbox1.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.bunifuMaterialTextbox1.LineMouseHoverColor = System.Drawing.Color.DarkCyan;
            this.bunifuMaterialTextbox1.LineThickness = 2;
            this.bunifuMaterialTextbox1.Location = new System.Drawing.Point(42, 382);
            this.bunifuMaterialTextbox1.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMaterialTextbox1.MaxLength = 32767;
            this.bunifuMaterialTextbox1.Name = "bunifuMaterialTextbox1";
            this.bunifuMaterialTextbox1.Size = new System.Drawing.Size(282, 33);
            this.bunifuMaterialTextbox1.TabIndex = 627;
            this.bunifuMaterialTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuMaterialTextbox2
            // 
            this.bunifuMaterialTextbox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.bunifuMaterialTextbox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.bunifuMaterialTextbox2.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.bunifuMaterialTextbox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuMaterialTextbox2.Enabled = false;
            this.bunifuMaterialTextbox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.bunifuMaterialTextbox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuMaterialTextbox2.HintForeColor = System.Drawing.Color.Empty;
            this.bunifuMaterialTextbox2.HintText = "Condicion";
            this.bunifuMaterialTextbox2.isPassword = false;
            this.bunifuMaterialTextbox2.LineFocusedColor = System.Drawing.Color.DarkCyan;
            this.bunifuMaterialTextbox2.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.bunifuMaterialTextbox2.LineMouseHoverColor = System.Drawing.Color.DarkCyan;
            this.bunifuMaterialTextbox2.LineThickness = 2;
            this.bunifuMaterialTextbox2.Location = new System.Drawing.Point(42, 314);
            this.bunifuMaterialTextbox2.Margin = new System.Windows.Forms.Padding(4);
            this.bunifuMaterialTextbox2.MaxLength = 32767;
            this.bunifuMaterialTextbox2.Name = "bunifuMaterialTextbox2";
            this.bunifuMaterialTextbox2.Size = new System.Drawing.Size(282, 33);
            this.bunifuMaterialTextbox2.TabIndex = 623;
            this.bunifuMaterialTextbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_id
            // 
            this.txt_id.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_id.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_id.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_id.Enabled = false;
            this.txt_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_id.HintForeColor = System.Drawing.Color.Empty;
            this.txt_id.HintText = "Codigo";
            this.txt_id.isPassword = false;
            this.txt_id.LineFocusedColor = System.Drawing.Color.DarkCyan;
            this.txt_id.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_id.LineMouseHoverColor = System.Drawing.Color.DarkCyan;
            this.txt_id.LineThickness = 2;
            this.txt_id.Location = new System.Drawing.Point(42, 92);
            this.txt_id.Margin = new System.Windows.Forms.Padding(4);
            this.txt_id.MaxLength = 32767;
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(245, 33);
            this.txt_id.TabIndex = 622;
            this.txt_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_direccion
            // 
            this.txt_direccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_direccion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_direccion.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_direccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_direccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_direccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_direccion.HintForeColor = System.Drawing.Color.Empty;
            this.txt_direccion.HintText = "Direccion";
            this.txt_direccion.isPassword = false;
            this.txt_direccion.LineFocusedColor = System.Drawing.Color.DarkCyan;
            this.txt_direccion.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_direccion.LineMouseHoverColor = System.Drawing.Color.DarkCyan;
            this.txt_direccion.LineThickness = 2;
            this.txt_direccion.Location = new System.Drawing.Point(42, 255);
            this.txt_direccion.Margin = new System.Windows.Forms.Padding(4);
            this.txt_direccion.MaxLength = 32767;
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(499, 33);
            this.txt_direccion.TabIndex = 621;
            this.txt_direccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_nombre
            // 
            this.txt_nombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_nombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_nombre.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_nombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_nombre.HintForeColor = System.Drawing.Color.Empty;
            this.txt_nombre.HintText = "Razon Social - Nombres";
            this.txt_nombre.isPassword = false;
            this.txt_nombre.LineFocusedColor = System.Drawing.Color.DarkCyan;
            this.txt_nombre.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_nombre.LineMouseHoverColor = System.Drawing.Color.DarkCyan;
            this.txt_nombre.LineThickness = 2;
            this.txt_nombre.Location = new System.Drawing.Point(42, 198);
            this.txt_nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_nombre.MaxLength = 32767;
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(499, 33);
            this.txt_nombre.TabIndex = 620;
            this.txt_nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_ruc
            // 
            this.txt_ruc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txt_ruc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txt_ruc.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_ruc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_ruc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txt_ruc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_ruc.HintForeColor = System.Drawing.Color.Empty;
            this.txt_ruc.HintText = "Nro de Ruc - Dni";
            this.txt_ruc.isPassword = false;
            this.txt_ruc.LineFocusedColor = System.Drawing.Color.DarkCyan;
            this.txt_ruc.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_ruc.LineMouseHoverColor = System.Drawing.Color.DarkCyan;
            this.txt_ruc.LineThickness = 2;
            this.txt_ruc.Location = new System.Drawing.Point(42, 143);
            this.txt_ruc.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ruc.MaxLength = 32767;
            this.txt_ruc.Name = "txt_ruc";
            this.txt_ruc.Size = new System.Drawing.Size(197, 33);
            this.txt_ruc.TabIndex = 619;
            this.txt_ruc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_ruc.OnValueChanged += new System.EventHandler(this.txt_ruc_OnValueChanged_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(126, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(263, 25);
            this.label7.TabIndex = 453;
            this.label7.Text = "Registrar Nuevo Cliente";
            // 
            // btn_elegir
            // 
            this.btn_elegir.BackColor = System.Drawing.Color.Transparent;
            this.btn_elegir.BorderColor = System.Drawing.Color.White;
            this.btn_elegir.BorderRadius = 6;
            this.btn_elegir.BorderThickness = 1;
            this.btn_elegir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_elegir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_elegir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_elegir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_elegir.FillColor = System.Drawing.Color.White;
            this.btn_elegir.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btn_elegir.ForeColor = System.Drawing.Color.Black;
            this.btn_elegir.Image = ((System.Drawing.Image)(resources.GetObject("btn_elegir.Image")));
            this.btn_elegir.ImageSize = new System.Drawing.Size(11, 11);
            this.btn_elegir.Location = new System.Drawing.Point(486, 731);
            this.btn_elegir.Name = "btn_elegir";
            this.btn_elegir.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_elegir.Size = new System.Drawing.Size(89, 22);
            this.btn_elegir.TabIndex = 686;
            this.btn_elegir.Text = "Elegir";
            this.btn_elegir.UseTransparentBackground = true;
            this.btn_elegir.Click += new System.EventHandler(this.btn_elegir_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancelar.BorderColor = System.Drawing.Color.White;
            this.btn_cancelar.BorderRadius = 6;
            this.btn_cancelar.BorderThickness = 1;
            this.btn_cancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancelar.FillColor = System.Drawing.Color.White;
            this.btn_cancelar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btn_cancelar.ForeColor = System.Drawing.Color.Black;
            this.btn_cancelar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancelar.Image")));
            this.btn_cancelar.ImageSize = new System.Drawing.Size(11, 11);
            this.btn_cancelar.Location = new System.Drawing.Point(384, 732);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_cancelar.Size = new System.Drawing.Size(86, 20);
            this.btn_cancelar.TabIndex = 685;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseTransparentBackground = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click_1);
            // 
            // lbl_nuevo
            // 
            this.lbl_nuevo.BackColor = System.Drawing.Color.Tomato;
            this.lbl_nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_nuevo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nuevo.ForeColor = System.Drawing.Color.White;
            this.lbl_nuevo.Image = ((System.Drawing.Image)(resources.GetObject("lbl_nuevo.Image")));
            this.lbl_nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_nuevo.Location = new System.Drawing.Point(14, 731);
            this.lbl_nuevo.Name = "lbl_nuevo";
            this.lbl_nuevo.Size = new System.Drawing.Size(92, 23);
            this.lbl_nuevo.TabIndex = 684;
            this.lbl_nuevo.Text = "     Nuevo";
            this.lbl_nuevo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_nuevo.Click += new System.EventHandler(this.lbl_nuevo_Click_1);
            // 
            // frm_Lista_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 756);
            this.Controls.Add(this.pnl_newCli);
            this.Controls.Add(this.Lsv_Cliente);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.lbl_nom);
            this.Controls.Add(this.lbl_direccion);
            this.Controls.Add(this.lbl_ruc);
            this.Controls.Add(this.btn_elegir);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.lbl_nuevo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Lista_Clientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Lista_Clientes";
            this.Load += new System.EventHandler(this.frm_Lista_Clientes_Load_1);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).EndInit();
            this.pnl_newCli.ResumeLayout(false);
            this.pnl_newCli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titu;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_prod;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_buscar;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lbl_id;
        public System.Windows.Forms.Label lbl_nom;
        public System.Windows.Forms.Label lbl_direccion;
        public System.Windows.Forms.Label lbl_ruc;
        private Guna.UI2.WinForms.Guna2Button btn_elegir;
        private Guna.UI2.WinForms.Guna2Button btn_cancelar;
        public System.Windows.Forms.Label lbl_nuevo;
        internal System.Windows.Forms.ListView Lsv_Cliente;
        internal System.Windows.Forms.Panel pnl_newCli;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button btrn_registrar;
        private Guna.UI2.WinForms.Guna2Button btn_cancelar2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal Bunifu.Framework.UI.BunifuMaterialTextbox bunifuMaterialTextbox1;
        internal Bunifu.Framework.UI.BunifuMaterialTextbox bunifuMaterialTextbox2;
        internal Bunifu.Framework.UI.BunifuMaterialTextbox txt_id;
        internal Bunifu.Framework.UI.BunifuMaterialTextbox txt_direccion;
        internal Bunifu.Framework.UI.BunifuMaterialTextbox txt_nombre;
        internal Bunifu.Framework.UI.BunifuMaterialTextbox txt_ruc;
        internal System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_fn;
        private Krypton.Toolkit.KryptonBorderEdge kryptonBorderEdge2;
    }
}