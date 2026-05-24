namespace CapaPresentacion.Usuario
{
    partial class frm_Editar_Cliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Editar_Cliente));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label27 = new System.Windows.Forms.Label();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimizar = new Guna.UI2.WinForms.Guna2Button();
            this.pic_prod = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tel = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_mail = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_direccion = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_idcliente = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nombre = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_dni = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtp_fechanaci = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btn_limpiar_editarcliente = new Guna.UI2.WinForms.Guna2Button();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.pnl_titu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.DarkOrchid;
            this.label27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label27.Location = new System.Drawing.Point(0, 623);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(750, 10);
            this.label27.TabIndex = 821;
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
            this.pnl_titu.Size = new System.Drawing.Size(750, 61);
            this.pnl_titu.TabIndex = 820;
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
            this.btn_minimizar.Location = new System.Drawing.Point(641, 11);
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
            this.pic_prod.Size = new System.Drawing.Size(90, 53);
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
            this.btn_close.Location = new System.Drawing.Point(689, 10);
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
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Editar Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 818;
            this.label5.Text = "Telefono:";
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
            this.txt_tel.Location = new System.Drawing.Point(238, 242);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.PlaceholderText = "";
            this.txt_tel.SelectedText = "";
            this.txt_tel.Size = new System.Drawing.Size(268, 32);
            this.txt_tel.TabIndex = 817;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 424);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 814;
            this.label9.Text = "Fecha Nacimiento:";
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
            this.txt_mail.Location = new System.Drawing.Point(238, 297);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.PlaceholderText = "";
            this.txt_mail.SelectedText = "";
            this.txt_mail.Size = new System.Drawing.Size(464, 32);
            this.txt_mail.TabIndex = 813;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 812;
            this.label8.Text = "Correo:";
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
            this.txt_direccion.Location = new System.Drawing.Point(238, 188);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.PlaceholderText = "";
            this.txt_direccion.SelectedText = "";
            this.txt_direccion.Size = new System.Drawing.Size(464, 32);
            this.txt_direccion.TabIndex = 811;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 810;
            this.label7.Text = "Direccion:";
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
            this.txt_idcliente.Location = new System.Drawing.Point(238, 94);
            this.txt_idcliente.Name = "txt_idcliente";
            this.txt_idcliente.PlaceholderText = "";
            this.txt_idcliente.SelectedText = "";
            this.txt_idcliente.Size = new System.Drawing.Size(177, 32);
            this.txt_idcliente.TabIndex = 809;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 808;
            this.label4.Text = "Nro Ruc - Dni:";
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
            this.txt_nombre.Location = new System.Drawing.Point(238, 137);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.PlaceholderText = "";
            this.txt_nombre.SelectedText = "";
            this.txt_nombre.Size = new System.Drawing.Size(464, 32);
            this.txt_nombre.TabIndex = 807;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 806;
            this.label3.Text = "Nombre o Razon Social:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 805;
            this.label2.Text = "Id Cliente:";
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
            this.txt_dni.Location = new System.Drawing.Point(238, 352);
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.PlaceholderText = "";
            this.txt_dni.SelectedText = "";
            this.txt_dni.Size = new System.Drawing.Size(268, 32);
            this.txt_dni.TabIndex = 804;
            // 
            // dtp_fechanaci
            // 
            this.dtp_fechanaci.BackColor = System.Drawing.Color.White;
            this.dtp_fechanaci.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtp_fechanaci.BorderRadius = 6;
            this.dtp_fechanaci.BorderThickness = 1;
            this.dtp_fechanaci.Checked = true;
            this.dtp_fechanaci.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dtp_fechanaci.CustomFormat = "dd/MM/yyyy";
            this.dtp_fechanaci.FillColor = System.Drawing.Color.White;
            this.dtp_fechanaci.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_fechanaci.ForeColor = System.Drawing.Color.Black;
            this.dtp_fechanaci.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_fechanaci.HoverState.FillColor = System.Drawing.Color.White;
            this.dtp_fechanaci.Location = new System.Drawing.Point(238, 408);
            this.dtp_fechanaci.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fechanaci.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fechanaci.Name = "dtp_fechanaci";
            this.dtp_fechanaci.Size = new System.Drawing.Size(464, 36);
            this.dtp_fechanaci.TabIndex = 803;
            this.dtp_fechanaci.Value = new System.DateTime(2025, 12, 27, 16, 59, 37, 704);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 15;
            this.bunifuElipse2.TargetControl = this;
            // 
            // btn_limpiar_editarcliente
            // 
            this.btn_limpiar_editarcliente.BackColor = System.Drawing.Color.White;
            this.btn_limpiar_editarcliente.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_limpiar_editarcliente.BorderRadius = 6;
            this.btn_limpiar_editarcliente.BorderThickness = 1;
            this.btn_limpiar_editarcliente.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_limpiar_editarcliente.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_limpiar_editarcliente.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_limpiar_editarcliente.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_limpiar_editarcliente.FillColor = System.Drawing.Color.White;
            this.btn_limpiar_editarcliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_limpiar_editarcliente.ForeColor = System.Drawing.Color.Black;
            this.btn_limpiar_editarcliente.Image = ((System.Drawing.Image)(resources.GetObject("btn_limpiar_editarcliente.Image")));
            this.btn_limpiar_editarcliente.Location = new System.Drawing.Point(190, 558);
            this.btn_limpiar_editarcliente.Name = "btn_limpiar_editarcliente";
            this.btn_limpiar_editarcliente.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_limpiar_editarcliente.Size = new System.Drawing.Size(175, 43);
            this.btn_limpiar_editarcliente.TabIndex = 816;
            this.btn_limpiar_editarcliente.Text = "Limpiar";
            this.btn_limpiar_editarcliente.Click += new System.EventHandler(this.btn_limpiar_editarcliente_Click);
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
            this.btn_save.Location = new System.Drawing.Point(387, 558);
            this.btn_save.Name = "btn_save";
            this.btn_save.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_save.Size = new System.Drawing.Size(175, 43);
            this.btn_save.TabIndex = 815;
            this.btn_save.Text = "Guardar";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Separator2.BackgroundImage")));
            this.guna2Separator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2Separator2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Separator2.FillThickness = 3;
            this.guna2Separator2.Location = new System.Drawing.Point(37, 508);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(665, 24);
            this.guna2Separator2.TabIndex = 822;
            // 
            // frm_Editar_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 633);
            this.Controls.Add(this.guna2Separator2);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_tel);
            this.Controls.Add(this.btn_limpiar_editarcliente);
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
            this.Name = "frm_Editar_Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Editar_Cliente";
            this.Load += new System.EventHandler(this.frm_Editar_Cliente_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_prod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel pnl_titu;
        private Guna.UI2.WinForms.Guna2Button btn_minimizar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pic_prod;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txt_tel;
        private Guna.UI2.WinForms.Guna2Button btn_limpiar_editarcliente;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txt_mail;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2TextBox txt_direccion;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txt_idcliente;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txt_nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txt_dni;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_fechanaci;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
    }
}