namespace CapaPresentacion.Compras
{
    partial class frm_PrecompraVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PrecompraVenta));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_idProd = new System.Windows.Forms.Label();
            this.btn_aceptar = new Guna.UI2.WinForms.Guna2Button();
            this.bt_cancelar = new Guna.UI2.WinForms.Guna2Button();
            this.txt_totalpagar = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_cantidad = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_preventa = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_preciocompra = new Guna.UI2.WinForms.Guna2TextBox();
            this.bt_editCant = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_add = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.pnl_titu.Controls.Add(this.label2);
            this.pnl_titu.Controls.Add(this.lbl_idProd);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(403, 85);
            this.pnl_titu.TabIndex = 3;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 31);
            this.label2.TabIndex = 803;
            this.label2.Text = "Precios de Compra y Venta";
            // 
            // lbl_idProd
            // 
            this.lbl_idProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_idProd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_idProd.Location = new System.Drawing.Point(19, 48);
            this.lbl_idProd.Name = "lbl_idProd";
            this.lbl_idProd.Size = new System.Drawing.Size(354, 34);
            this.lbl_idProd.TabIndex = 478;
            this.lbl_idProd.Text = "-";
            this.lbl_idProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackColor = System.Drawing.Color.Transparent;
            this.btn_aceptar.BorderColor = System.Drawing.Color.Tomato;
            this.btn_aceptar.BorderRadius = 18;
            this.btn_aceptar.BorderThickness = 1;
            this.btn_aceptar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_aceptar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_aceptar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_aceptar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_aceptar.FillColor = System.Drawing.Color.Tomato;
            this.btn_aceptar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_aceptar.ForeColor = System.Drawing.Color.White;
            this.btn_aceptar.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_aceptar.Location = new System.Drawing.Point(223, 399);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_aceptar.Size = new System.Drawing.Size(141, 49);
            this.btn_aceptar.TabIndex = 649;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.UseTransparentBackground = true;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.BackColor = System.Drawing.Color.Transparent;
            this.bt_cancelar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.bt_cancelar.BorderRadius = 18;
            this.bt_cancelar.BorderThickness = 1;
            this.bt_cancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bt_cancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bt_cancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bt_cancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bt_cancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.bt_cancelar.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.bt_cancelar.ForeColor = System.Drawing.Color.White;
            this.bt_cancelar.ImageSize = new System.Drawing.Size(30, 30);
            this.bt_cancelar.Location = new System.Drawing.Point(42, 399);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.bt_cancelar.Size = new System.Drawing.Size(141, 49);
            this.bt_cancelar.TabIndex = 648;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseTransparentBackground = true;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // txt_totalpagar
            // 
            this.txt_totalpagar.BackColor = System.Drawing.Color.Transparent;
            this.txt_totalpagar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_totalpagar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.txt_totalpagar.BorderRadius = 5;
            this.txt_totalpagar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_totalpagar.DefaultText = "";
            this.txt_totalpagar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_totalpagar.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_totalpagar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalpagar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_totalpagar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalpagar.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold);
            this.txt_totalpagar.ForeColor = System.Drawing.Color.White;
            this.txt_totalpagar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_totalpagar.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_totalpagar.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_totalpagar.Location = new System.Drawing.Point(42, 205);
            this.txt_totalpagar.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.txt_totalpagar.Name = "txt_totalpagar";
            this.txt_totalpagar.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txt_totalpagar.PlaceholderText = "";
            this.txt_totalpagar.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_totalpagar.SelectedText = "";
            this.txt_totalpagar.Size = new System.Drawing.Size(322, 66);
            this.txt_totalpagar.TabIndex = 650;
            this.txt_totalpagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2TextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2TextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.guna2TextBox1.BorderRadius = 5;
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.White;
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold);
            this.guna2TextBox1.ForeColor = System.Drawing.Color.White;
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.guna2TextBox1.IconLeftSize = new System.Drawing.Size(16, 16);
            this.guna2TextBox1.Location = new System.Drawing.Point(42, 112);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(322, 66);
            this.guna2TextBox1.TabIndex = 651;
            this.guna2TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(55, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 20);
            this.label9.TabIndex = 698;
            this.label9.Text = "Precio Compra";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(55, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 699;
            this.label1.Text = "Precio Venta";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(174, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 20);
            this.label5.TabIndex = 705;
            this.label5.Text = "S/.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(174, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 706;
            this.label3.Text = "S/.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2TextBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2TextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.guna2TextBox2.BorderRadius = 5;
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.White;
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold);
            this.guna2TextBox2.ForeColor = System.Drawing.Color.White;
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.guna2TextBox2.IconLeftSize = new System.Drawing.Size(16, 16);
            this.guna2TextBox2.Location = new System.Drawing.Point(42, 299);
            this.guna2TextBox2.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.guna2TextBox2.PlaceholderText = "";
            this.guna2TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.Size = new System.Drawing.Size(322, 66);
            this.guna2TextBox2.TabIndex = 707;
            this.guna2TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.BackColor = System.Drawing.Color.Transparent;
            this.txt_cantidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_cantidad.BorderColor = System.Drawing.Color.White;
            this.txt_cantidad.BorderRadius = 5;
            this.txt_cantidad.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_cantidad.DefaultText = "";
            this.txt_cantidad.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_cantidad.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_cantidad.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_cantidad.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_cantidad.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_cantidad.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txt_cantidad.ForeColor = System.Drawing.Color.DimGray;
            this.txt_cantidad.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_cantidad.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_cantidad.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_cantidad.Location = new System.Drawing.Point(245, 315);
            this.txt_cantidad.Margin = new System.Windows.Forms.Padding(9);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txt_cantidad.PlaceholderText = "0";
            this.txt_cantidad.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_cantidad.SelectedText = "";
            this.txt_cantidad.Size = new System.Drawing.Size(59, 35);
            this.txt_cantidad.TabIndex = 708;
            this.txt_cantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_cantidad.TextChanged += new System.EventHandler(this.txt_cantidad_TextChanged);
            this.txt_cantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cantidad_KeyDown);
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cantidad_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(55, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 709;
            this.label4.Text = "Cantidad";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(174, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 20);
            this.label6.TabIndex = 712;
            this.label6.Text = "S/.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_preventa
            // 
            this.txt_preventa.BackColor = System.Drawing.Color.Transparent;
            this.txt_preventa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_preventa.BorderColor = System.Drawing.Color.White;
            this.txt_preventa.BorderRadius = 5;
            this.txt_preventa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_preventa.DefaultText = "";
            this.txt_preventa.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_preventa.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_preventa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_preventa.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_preventa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_preventa.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txt_preventa.ForeColor = System.Drawing.Color.DimGray;
            this.txt_preventa.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_preventa.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_preventa.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_preventa.Location = new System.Drawing.Point(245, 219);
            this.txt_preventa.Margin = new System.Windows.Forms.Padding(9);
            this.txt_preventa.Name = "txt_preventa";
            this.txt_preventa.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txt_preventa.PlaceholderText = "0";
            this.txt_preventa.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_preventa.SelectedText = "";
            this.txt_preventa.Size = new System.Drawing.Size(59, 35);
            this.txt_preventa.TabIndex = 713;
            this.txt_preventa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_preciocompra
            // 
            this.txt_preciocompra.BackColor = System.Drawing.Color.Transparent;
            this.txt_preciocompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_preciocompra.BorderColor = System.Drawing.Color.White;
            this.txt_preciocompra.BorderRadius = 5;
            this.txt_preciocompra.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_preciocompra.DefaultText = "";
            this.txt_preciocompra.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_preciocompra.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_preciocompra.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_preciocompra.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_preciocompra.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_preciocompra.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.txt_preciocompra.ForeColor = System.Drawing.Color.DimGray;
            this.txt_preciocompra.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_preciocompra.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_preciocompra.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_preciocompra.Location = new System.Drawing.Point(245, 127);
            this.txt_preciocompra.Margin = new System.Windows.Forms.Padding(9);
            this.txt_preciocompra.Name = "txt_preciocompra";
            this.txt_preciocompra.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txt_preciocompra.PlaceholderText = "0";
            this.txt_preciocompra.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_preciocompra.SelectedText = "";
            this.txt_preciocompra.Size = new System.Drawing.Size(59, 35);
            this.txt_preciocompra.TabIndex = 714;
            this.txt_preciocompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_preciocompra.TextChanged += new System.EventHandler(this.txt_preciocompra_TextChanged);
            this.txt_preciocompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_preciocompra_KeyDown);
            this.txt_preciocompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_preciocompra_KeyPress);
            // 
            // bt_editCant
            // 
            this.bt_editCant.FlatAppearance.BorderSize = 0;
            this.bt_editCant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.bt_editCant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.bt_editCant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_editCant.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_editCant.ForeColor = System.Drawing.Color.White;
            this.bt_editCant.Image = ((System.Drawing.Image)(resources.GetObject("bt_editCant.Image")));
            this.bt_editCant.Location = new System.Drawing.Point(319, 314);
            this.bt_editCant.Margin = new System.Windows.Forms.Padding(4);
            this.bt_editCant.Name = "bt_editCant";
            this.bt_editCant.Size = new System.Drawing.Size(30, 36);
            this.bt_editCant.TabIndex = 711;
            this.bt_editCant.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_editCant.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(320, 225);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 26);
            this.button1.TabIndex = 701;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // bt_add
            // 
            this.bt_add.FlatAppearance.BorderSize = 0;
            this.bt_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SkyBlue;
            this.bt_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            this.bt_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_add.ForeColor = System.Drawing.Color.White;
            this.bt_add.Image = ((System.Drawing.Image)(resources.GetObject("bt_add.Image")));
            this.bt_add.Location = new System.Drawing.Point(318, 130);
            this.bt_add.Margin = new System.Windows.Forms.Padding(4);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(36, 32);
            this.bt_add.TabIndex = 700;
            this.bt_add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_add.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Tomato;
            this.label27.Dock = System.Windows.Forms.DockStyle.Top;
            this.label27.Location = new System.Drawing.Point(0, 85);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(403, 5);
            this.label27.TabIndex = 802;
            // 
            // frm_PrecompraVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 472);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txt_preciocompra);
            this.Controls.Add(this.txt_preventa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bt_editCant);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.guna2TextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.txt_totalpagar);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.bt_cancelar);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_PrecompraVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_PrecompraVenta";
            this.Load += new System.EventHandler(this.frm_PrecompraVenta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_PrecompraVenta_KeyDown);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private Guna.UI2.WinForms.Guna2Button btn_aceptar;
        private Guna.UI2.WinForms.Guna2Button bt_cancelar;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt_add;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_editCant;
        internal System.Windows.Forms.Label lbl_idProd;
        internal Guna.UI2.WinForms.Guna2TextBox txt_cantidad;
        internal Guna.UI2.WinForms.Guna2TextBox txt_preciocompra;
        internal Guna.UI2.WinForms.Guna2TextBox txt_preventa;
        internal Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        internal Guna.UI2.WinForms.Guna2TextBox txt_totalpagar;
        internal Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private System.Windows.Forms.Label label27;
    }
}