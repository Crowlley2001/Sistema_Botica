namespace CapaPresentacion.Modales
{
    partial class mdCategoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mdCategoria));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.btn_minimizar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lsv_Cat = new System.Windows.Forms.ListView();
            this.pnl_reg = new System.Windows.Forms.Panel();
            this.btn_save = new Guna.UI2.WinForms.Guna2Button();
            this.txt_catg = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_new = new System.Windows.Forms.Label();
            this.txt_id = new Guna.UI2.WinForms.Guna2TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            this.pnl_reg.SuspendLayout();
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
            this.pnl_titu.Controls.Add(this.btn_minimizar);
            this.pnl_titu.Controls.Add(this.btn_close);
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(441, 61);
            this.pnl_titu.TabIndex = 0;
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
            this.btn_minimizar.Location = new System.Drawing.Point(344, 14);
            this.btn_minimizar.Name = "btn_minimizar";
            this.btn_minimizar.PressedColor = System.Drawing.Color.Transparent;
            this.btn_minimizar.Size = new System.Drawing.Size(43, 39);
            this.btn_minimizar.TabIndex = 8;
            this.btn_minimizar.Click += new System.EventHandler(this.btn_minimizar_Click);
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
            this.btn_close.Location = new System.Drawing.Point(383, 15);
            this.btn_close.Name = "btn_close";
            this.btn_close.PressedColor = System.Drawing.Color.Transparent;
            this.btn_close.Size = new System.Drawing.Size(48, 34);
            this.btn_close.TabIndex = 5;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mantenimiento de Categorias";
            // 
            // lsv_Cat
            // 
            this.lsv_Cat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsv_Cat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsv_Cat.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_Cat.HideSelection = false;
            this.lsv_Cat.Location = new System.Drawing.Point(9, 67);
            this.lsv_Cat.Name = "lsv_Cat";
            this.lsv_Cat.Size = new System.Drawing.Size(425, 446);
            this.lsv_Cat.TabIndex = 1;
            this.lsv_Cat.UseCompatibleStateImageBehavior = false;
            this.lsv_Cat.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsv_Cat_MouseDoubleClick);
            // 
            // pnl_reg
            // 
            this.pnl_reg.Controls.Add(this.btn_save);
            this.pnl_reg.Controls.Add(this.txt_catg);
            this.pnl_reg.Enabled = false;
            this.pnl_reg.Location = new System.Drawing.Point(9, 519);
            this.pnl_reg.Name = "pnl_reg";
            this.pnl_reg.Size = new System.Drawing.Size(423, 45);
            this.pnl_reg.TabIndex = 2;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.White;
            this.btn_save.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_save.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_save.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_save.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_save.FillColor = System.Drawing.Color.White;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_save.Location = new System.Drawing.Point(358, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(64, 34);
            this.btn_save.TabIndex = 1;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_catg
            // 
            this.txt_catg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txt_catg.BorderColor = System.Drawing.Color.White;
            this.txt_catg.BorderRadius = 7;
            this.txt_catg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_catg.DefaultText = "";
            this.txt_catg.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_catg.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_catg.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_catg.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_catg.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_catg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_catg.ForeColor = System.Drawing.Color.Black;
            this.txt_catg.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_catg.Location = new System.Drawing.Point(3, 3);
            this.txt_catg.Name = "txt_catg";
            this.txt_catg.PlaceholderForeColor = System.Drawing.Color.White;
            this.txt_catg.PlaceholderText = "";
            this.txt_catg.SelectedText = "";
            this.txt_catg.Size = new System.Drawing.Size(329, 34);
            this.txt_catg.TabIndex = 0;
            this.txt_catg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_catg_KeyDown);
            // 
            // lbl_new
            // 
            this.lbl_new.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_new.Image = ((System.Drawing.Image)(resources.GetObject("lbl_new.Image")));
            this.lbl_new.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_new.Location = new System.Drawing.Point(145, 575);
            this.lbl_new.Name = "lbl_new";
            this.lbl_new.Size = new System.Drawing.Size(112, 41);
            this.lbl_new.TabIndex = 3;
            this.lbl_new.Text = "Nuevo";
            this.lbl_new.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_new.Click += new System.EventHandler(this.lbl_new_Click);
            // 
            // txt_id
            // 
            this.txt_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_id.DefaultText = "";
            this.txt_id.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_id.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_id.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_id.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_id.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_id.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_id.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_id.Location = new System.Drawing.Point(222, 408);
            this.txt_id.Name = "txt_id";
            this.txt_id.PlaceholderText = "";
            this.txt_id.SelectedText = "";
            this.txt_id.Size = new System.Drawing.Size(34, 34);
            this.txt_id.TabIndex = 4;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.DarkOrchid;
            this.label27.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label27.Location = new System.Drawing.Point(0, 623);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(441, 10);
            this.label27.TabIndex = 803;
            // 
            // mdCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(441, 633);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.lbl_new);
            this.Controls.Add(this.pnl_reg);
            this.Controls.Add(this.lsv_Cat);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.txt_id);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "mdCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modal de Categoria";
            this.Load += new System.EventHandler(this.mdCategoria_Load);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.pnl_reg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.ListView lsv_Cat;
        private System.Windows.Forms.Panel pnl_reg;
        private Guna.UI2.WinForms.Guna2Button btn_save;
        private Guna.UI2.WinForms.Guna2TextBox txt_catg;
        private System.Windows.Forms.Label lbl_new;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txt_id;
        private Guna.UI2.WinForms.Guna2Button btn_close;
        private System.Windows.Forms.Label label27;
        private Guna.UI2.WinForms.Guna2Button btn_minimizar;
    }
}