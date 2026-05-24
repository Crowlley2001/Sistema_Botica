namespace CapaPresentacion.Modales
{
    partial class mdCorrelativo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdCorrelativo));
            this.pnl_titulo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_Docs = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnl_edit = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_numeroCorrelativo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_idCorrelativo = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_serie = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.btn_cancelPago = new Guna.UI2.WinForms.Guna2Button();
            this.pnl_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_edit.SuspendLayout();
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
            this.pnl_titulo.Size = new System.Drawing.Size(453, 90);
            this.pnl_titulo.TabIndex = 729;
            this.pnl_titulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titulo_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(188, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 785;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(120, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Editar Correlativo";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(118, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 16);
            this.label2.TabIndex = 784;
            this.label2.Text = "Elige el Documento a Editar";
            // 
            // cbo_Docs
            // 
            this.cbo_Docs.BackColor = System.Drawing.Color.Transparent;
            this.cbo_Docs.BorderColor = System.Drawing.Color.DarkGray;
            this.cbo_Docs.BorderRadius = 6;
            this.cbo_Docs.BorderThickness = 2;
            this.cbo_Docs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbo_Docs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Docs.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_Docs.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbo_Docs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbo_Docs.ForeColor = System.Drawing.Color.DarkGray;
            this.cbo_Docs.ItemHeight = 30;
            this.cbo_Docs.Items.AddRange(new object[] {
            "Por Traslado",
            "Por Vencimiento",
            "Por Merma",
            "Otros"});
            this.cbo_Docs.Location = new System.Drawing.Point(121, 129);
            this.cbo_Docs.MaxDropDownItems = 2;
            this.cbo_Docs.Name = "cbo_Docs";
            this.cbo_Docs.Size = new System.Drawing.Size(197, 36);
            this.cbo_Docs.TabIndex = 811;
            this.cbo_Docs.SelectedIndexChanged += new System.EventHandler(this.cbo_Docs_SelectedIndexChanged);
            // 
            // pnl_edit
            // 
            this.pnl_edit.BackColor = System.Drawing.Color.Transparent;
            this.pnl_edit.Controls.Add(this.label5);
            this.pnl_edit.Controls.Add(this.label4);
            this.pnl_edit.Controls.Add(this.label3);
            this.pnl_edit.Controls.Add(this.txt_numeroCorrelativo);
            this.pnl_edit.Controls.Add(this.txt_idCorrelativo);
            this.pnl_edit.Controls.Add(this.txt_serie);
            this.pnl_edit.Controls.Add(this.lbl_nom);
            this.pnl_edit.FillColor = System.Drawing.Color.White;
            this.pnl_edit.Location = new System.Drawing.Point(12, 184);
            this.pnl_edit.Name = "pnl_edit";
            this.pnl_edit.ShadowColor = System.Drawing.Color.Black;
            this.pnl_edit.Size = new System.Drawing.Size(424, 228);
            this.pnl_edit.TabIndex = 812;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(248, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 796;
            this.label5.Text = "Numero";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(66, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 795;
            this.label4.Text = "Serie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(155, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 794;
            this.label3.Text = "Id";
            // 
            // txt_numeroCorrelativo
            // 
            this.txt_numeroCorrelativo.BorderColor = System.Drawing.Color.DarkGray;
            this.txt_numeroCorrelativo.BorderRadius = 6;
            this.txt_numeroCorrelativo.BorderThickness = 2;
            this.txt_numeroCorrelativo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_numeroCorrelativo.DefaultText = "0";
            this.txt_numeroCorrelativo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_numeroCorrelativo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_numeroCorrelativo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_numeroCorrelativo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_numeroCorrelativo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_numeroCorrelativo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_numeroCorrelativo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_numeroCorrelativo.Location = new System.Drawing.Point(251, 162);
            this.txt_numeroCorrelativo.Name = "txt_numeroCorrelativo";
            this.txt_numeroCorrelativo.PlaceholderText = "";
            this.txt_numeroCorrelativo.SelectedText = "";
            this.txt_numeroCorrelativo.Size = new System.Drawing.Size(95, 30);
            this.txt_numeroCorrelativo.TabIndex = 793;
            // 
            // txt_idCorrelativo
            // 
            this.txt_idCorrelativo.BorderColor = System.Drawing.Color.DarkGray;
            this.txt_idCorrelativo.BorderRadius = 6;
            this.txt_idCorrelativo.BorderThickness = 2;
            this.txt_idCorrelativo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_idCorrelativo.DefaultText = "0";
            this.txt_idCorrelativo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_idCorrelativo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_idCorrelativo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_idCorrelativo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_idCorrelativo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_idCorrelativo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_idCorrelativo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_idCorrelativo.Location = new System.Drawing.Point(158, 43);
            this.txt_idCorrelativo.Name = "txt_idCorrelativo";
            this.txt_idCorrelativo.PlaceholderText = "";
            this.txt_idCorrelativo.SelectedText = "";
            this.txt_idCorrelativo.Size = new System.Drawing.Size(66, 30);
            this.txt_idCorrelativo.TabIndex = 792;
            // 
            // txt_serie
            // 
            this.txt_serie.BorderColor = System.Drawing.Color.DarkGray;
            this.txt_serie.BorderRadius = 6;
            this.txt_serie.BorderThickness = 2;
            this.txt_serie.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_serie.DefaultText = "0";
            this.txt_serie.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_serie.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_serie.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_serie.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_serie.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_serie.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_serie.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_serie.Location = new System.Drawing.Point(69, 162);
            this.txt_serie.Name = "txt_serie";
            this.txt_serie.PlaceholderText = "";
            this.txt_serie.SelectedText = "";
            this.txt_serie.Size = new System.Drawing.Size(95, 30);
            this.txt_serie.TabIndex = 791;
            // 
            // lbl_nom
            // 
            this.lbl_nom.Enabled = false;
            this.lbl_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nom.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_nom.Location = new System.Drawing.Point(85, 91);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(258, 27);
            this.lbl_nom.TabIndex = 790;
            this.lbl_nom.Text = "Editar Correlativo";
            this.lbl_nom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_save.BorderRadius = 20;
            this.btn_save.BorderThickness = 1;
            this.btn_save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_save.Enabled = false;
            this.btn_save.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_save.Location = new System.Drawing.Point(240, 444);
            this.btn_save.Name = "btn_save";
            this.btn_save.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_save.Size = new System.Drawing.Size(137, 39);
            this.btn_save.TabIndex = 815;
            this.btn_save.Text = "Aceptar";
            this.btn_save.UseTransparentBackground = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancelPago
            // 
            this.btn_cancelPago.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancelPago.BorderColor = System.Drawing.Color.Silver;
            this.btn_cancelPago.BorderRadius = 20;
            this.btn_cancelPago.BorderThickness = 1;
            this.btn_cancelPago.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelPago.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_cancelPago.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_cancelPago.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_cancelPago.FillColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cancelPago.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_cancelPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.btn_cancelPago.ImageSize = new System.Drawing.Size(25, 25);
            this.btn_cancelPago.Location = new System.Drawing.Point(59, 442);
            this.btn_cancelPago.Name = "btn_cancelPago";
            this.btn_cancelPago.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_cancelPago.Size = new System.Drawing.Size(139, 41);
            this.btn_cancelPago.TabIndex = 814;
            this.btn_cancelPago.Text = "Cancelar";
            this.btn_cancelPago.UseTransparentBackground = true;
            this.btn_cancelPago.Click += new System.EventHandler(this.btn_cancelPago_Click);
            // 
            // mdCorrelativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 508);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancelPago);
            this.Controls.Add(this.pnl_edit);
            this.Controls.Add(this.cbo_Docs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnl_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mdCorrelativo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdCorrelativo";
            this.Load += new System.EventHandler(this.mdCorrelativo_Load);
            this.pnl_titulo.ResumeLayout(false);
            this.pnl_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_edit.ResumeLayout(false);
            this.pnl_edit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_titulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label2;
        internal Guna.UI2.WinForms.Guna2ComboBox cbo_Docs;
        private Guna.UI2.WinForms.Guna2ShadowPanel pnl_edit;
        private System.Windows.Forms.Label lbl_nom;
        internal Guna.UI2.WinForms.Guna2TextBox txt_numeroCorrelativo;
        internal Guna.UI2.WinForms.Guna2TextBox txt_idCorrelativo;
        internal Guna.UI2.WinForms.Guna2TextBox txt_serie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private Guna.UI2.WinForms.Guna2Button btn_cancelPago;
    }
}