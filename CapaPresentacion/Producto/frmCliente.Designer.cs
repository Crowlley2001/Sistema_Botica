namespace CapaPresentacion.Producto
{
    partial class frmCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.dtp_fechanaci = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txt_dni = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_idcliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_direccion = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_mail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_tel = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimizar = new Guna.UI2.WinForms.Guna2Button();
            this.pic_prod = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btn_limpiar_cliente = new Guna.UI2.WinForms.Guna2Button();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // dtp_fechanaci
            // 
            this.dtp_fechanaci.BackColor = System.Drawing.Color.White;
            this.dtp_fechanaci.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtp_fechanaci.BorderRadius = 6;
            this.dtp_fechanaci.BorderThickness = 1;
            this.dtp_fechanaci.Checked = true;
            this.dtp_fechanaci.CustomFormat = "dd/MM/yyyy";
            this.dtp_fechanaci.FillColor = System.Drawing.Color.White;
            this.dtp_fechanaci.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_fechanaci.ForeColor = System.Drawing.Color.Black;
            this.dtp_fechanaci.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fechanaci.HoverState.FillColor = System.Drawing.Color.White;
            this.dtp_fechanaci.Location = new System.Drawing.Point(29, 367);
            this.dtp_fechanaci.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fechanaci.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fechanaci.Name = "dtp_fechanaci";
            this.dtp_fechanaci.Size = new System.Drawing.Size(239, 36);
            this.dtp_fechanaci.TabIndex = 6;
            this.dtp_fechanaci.Value = new System.DateTime(2025, 12, 27, 16, 59, 37, 704);
            // 
            // txt_dni
            // 
            this.txt_dni.BorderRadius = 6;
            this.txt_dni.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_dni.DefaultText = "";
            this.txt_dni.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_dni.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_dni.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_dni.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_dni.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_dni.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_dni.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_dni.Location = new System.Drawing.Point(366, 113);
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.PlaceholderText = "";
            this.txt_dni.SelectedText = "";
            this.txt_dni.Size = new System.Drawing.Size(177, 32);
            this.txt_dni.TabIndex = 7;
            this.txt_dni.TextChanged += new System.EventHandler(this.txt_dni_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Id Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nombre o Razon Social:";
            // 
            // txt_nombre
            // 
            this.txt_nombre.BorderRadius = 6;
            this.txt_nombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_nombre.DefaultText = "";
            this.txt_nombre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_nombre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_nombre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_nombre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_nombre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_nombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_nombre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_nombre.Location = new System.Drawing.Point(28, 173);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.PlaceholderText = "";
            this.txt_nombre.SelectedText = "";
            this.txt_nombre.Size = new System.Drawing.Size(515, 32);
            this.txt_nombre.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(369, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nro Ruc - Dni:";
            // 
            // txt_idcliente
            // 
            this.txt_idcliente.BorderRadius = 6;
            this.txt_idcliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_idcliente.DefaultText = "";
            this.txt_idcliente.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_idcliente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_idcliente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_idcliente.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_idcliente.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_idcliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_idcliente.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_idcliente.Location = new System.Drawing.Point(28, 113);
            this.txt_idcliente.Name = "txt_idcliente";
            this.txt_idcliente.PlaceholderText = "";
            this.txt_idcliente.SelectedText = "";
            this.txt_idcliente.Size = new System.Drawing.Size(177, 32);
            this.txt_idcliente.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Direccion:";
            // 
            // txt_direccion
            // 
            this.txt_direccion.BorderRadius = 6;
            this.txt_direccion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_direccion.DefaultText = "";
            this.txt_direccion.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_direccion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_direccion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_direccion.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_direccion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_direccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_direccion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_direccion.Location = new System.Drawing.Point(28, 234);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.PlaceholderText = "";
            this.txt_direccion.SelectedText = "";
            this.txt_direccion.Size = new System.Drawing.Size(515, 32);
            this.txt_direccion.TabIndex = 22;
            // 
            // txt_mail
            // 
            this.txt_mail.BorderRadius = 6;
            this.txt_mail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_mail.DefaultText = "";
            this.txt_mail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_mail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_mail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_mail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_mail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_mail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_mail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_mail.Location = new System.Drawing.Point(28, 300);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.PlaceholderText = "";
            this.txt_mail.SelectedText = "";
            this.txt_mail.Size = new System.Drawing.Size(240, 32);
            this.txt_mail.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Correo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Fecha Nacimiento:";
            // 
            // txt_tel
            // 
            this.txt_tel.BorderRadius = 6;
            this.txt_tel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_tel.DefaultText = "";
            this.txt_tel.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_tel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_tel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_tel.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_tel.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_tel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_tel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_tel.Location = new System.Drawing.Point(303, 300);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.PlaceholderText = "";
            this.txt_tel.SelectedText = "";
            this.txt_tel.Size = new System.Drawing.Size(240, 32);
            this.txt_tel.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Telefono:";
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
            this.pnl_titu.Size = new System.Drawing.Size(576, 63);
            this.pnl_titu.TabIndex = 71;
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
            this.btn_minimizar.Location = new System.Drawing.Point(454, 14);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.PressedColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.Size = new System.Drawing.Size(43, 39);
            this.btn_minimizar.TabIndex = 7;
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
            this.pic_prod.Location = new System.Drawing.Point(6, 3);
            this.pic_prod.Name = "pic_prod";
            this.pic_prod.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pic_prod.Size = new System.Drawing.Size(90, 54);
            this.pic_prod.TabIndex = 6;
            this.pic_prod.TabStop = false;
            // 
            // btn_close
            // 
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
            this.btn_close.Location = new System.Drawing.Point(498, 14);
            this.btn_close.Name = "btn_close";
            this.btn_close.PressedColor = System.Drawing.Color.Transparent;
            this.btn_close.Size = new System.Drawing.Size(43, 39);
            this.btn_close.TabIndex = 5;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(103, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Registro de Cliente";
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.DarkOrchid;
            this.label27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label27.Location = new System.Drawing.Point(0, 536);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(576, 10);
            this.label27.TabIndex = 802;
            // 
            // btn_limpiar_cliente
            // 
            this.btn_limpiar_cliente.BackColor = System.Drawing.Color.White;
            this.btn_limpiar_cliente.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_limpiar_cliente.BorderRadius = 6;
            this.btn_limpiar_cliente.BorderThickness = 1;
            this.btn_limpiar_cliente.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_limpiar_cliente.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_limpiar_cliente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_limpiar_cliente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_limpiar_cliente.FillColor = System.Drawing.Color.White;
            this.btn_limpiar_cliente.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_limpiar_cliente.ForeColor = System.Drawing.Color.Black;
            this.btn_limpiar_cliente.Image = ((System.Drawing.Image)(resources.GetObject("btn_limpiar_cliente.Image")));
            this.btn_limpiar_cliente.Location = new System.Drawing.Point(102, 471);
            this.btn_limpiar_cliente.Name = "btn_limpiar_cliente";
            this.btn_limpiar_cliente.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_limpiar_cliente.Size = new System.Drawing.Size(175, 43);
            this.btn_limpiar_cliente.TabIndex = 41;
            this.btn_limpiar_cliente.Text = "Limpiar";
            this.btn_limpiar_cliente.Click += new System.EventHandler(this.btn_limpiar_cliente_Click);
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
            this.btn_save.Location = new System.Drawing.Point(299, 471);
            this.btn_save.Name = "btn_save";
            this.btn_save.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_save.Size = new System.Drawing.Size(175, 43);
            this.btn_save.TabIndex = 40;
            this.btn_save.Text = "Guardar";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Separator2.BackgroundImage")));
            this.guna2Separator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Separator2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Separator2.FillThickness = 3;
            this.guna2Separator2.Location = new System.Drawing.Point(28, 429);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(515, 24);
            this.guna2Separator2.TabIndex = 803;
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(576, 546);
            this.Controls.Add(this.guna2Separator2);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_tel);
            this.Controls.Add(this.btn_limpiar_cliente);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_mail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_idcliente);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_dni);
            this.Controls.Add(this.dtp_fechanaci);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCliente";
            this.Load += new System.EventHandler(this.frmCliente_Load_1);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_fechanaci;
        private Guna.UI2.WinForms.Guna2TextBox txt_dni;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txt_idcliente;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txt_nombre;
        private Guna.UI2.WinForms.Guna2TextBox txt_direccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txt_mail;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private Guna.UI2.WinForms.Guna2Button btn_limpiar_cliente;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txt_tel;
        private System.Windows.Forms.Panel pnl_titu;
        private Guna.UI2.WinForms.Guna2Button btn_minimizar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_prod;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label27;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
    }
}