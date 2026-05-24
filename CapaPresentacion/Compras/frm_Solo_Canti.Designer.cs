namespace CapaPresentacion.Compras
{
    partial class frm_Solo_Canti
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Solo_Canti));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_stock = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_nom = new System.Windows.Forms.Label();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.kryptonBorderEdge2 = new Krypton.Toolkit.KryptonBorderEdge();
            this.txt_cant = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(98, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 25);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cantidad";
            // 
            // lbl_stock
            // 
            this.lbl_stock.AutoSize = true;
            this.lbl_stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stock.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_stock.Location = new System.Drawing.Point(258, 133);
            this.lbl_stock.Name = "lbl_stock";
            this.lbl_stock.Size = new System.Drawing.Size(24, 18);
            this.lbl_stock.TabIndex = 492;
            this.lbl_stock.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(249, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 491;
            this.label3.Text = "Stock";
            // 
            // lbl_nom
            // 
            this.lbl_nom.AutoSize = true;
            this.lbl_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nom.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nom.Location = new System.Drawing.Point(12, 169);
            this.lbl_nom.Name = "lbl_nom";
            this.lbl_nom.Size = new System.Drawing.Size(11, 15);
            this.lbl_nom.TabIndex = 490;
            this.lbl_nom.Text = "-";
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.pnl_titu.Controls.Add(this.label1);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(313, 49);
            this.pnl_titu.TabIndex = 489;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // kryptonBorderEdge2
            // 
            this.kryptonBorderEdge2.AutoSize = false;
            this.kryptonBorderEdge2.Location = new System.Drawing.Point(37, 173);
            this.kryptonBorderEdge2.Name = "kryptonBorderEdge2";
            this.kryptonBorderEdge2.Size = new System.Drawing.Size(221, 10);
            this.kryptonBorderEdge2.StateCommon.Image = ((System.Drawing.Image)(resources.GetObject("kryptonBorderEdge2.StateCommon.Image")));
            this.kryptonBorderEdge2.StateCommon.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.kryptonBorderEdge2.Text = "kryptonBorderEdge2";
            // 
            // txt_cant
            // 
            this.txt_cant.BackColor = System.Drawing.Color.Transparent;
            this.txt_cant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_cant.BorderColor = System.Drawing.Color.DimGray;
            this.txt_cant.BorderRadius = 5;
            this.txt_cant.BorderThickness = 2;
            this.txt_cant.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_cant.DefaultText = "";
            this.txt_cant.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_cant.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_cant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_cant.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_cant.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_cant.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold);
            this.txt_cant.ForeColor = System.Drawing.Color.DimGray;
            this.txt_cant.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_cant.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_cant.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_cant.Location = new System.Drawing.Point(81, 96);
            this.txt_cant.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.txt_cant.Name = "txt_cant";
            this.txt_cant.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.txt_cant.PlaceholderText = "1";
            this.txt_cant.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_cant.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_cant.SelectedText = "";
            this.txt_cant.Size = new System.Drawing.Size(137, 72);
            this.txt_cant.TabIndex = 496;
            this.txt_cant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_cant.TextOffset = new System.Drawing.Point(44, 0);
            this.txt_cant.TextChanged += new System.EventHandler(this.txt_cant_TextChanged);
            this.txt_cant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cant_KeyDown);
            this.txt_cant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cant_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(79, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 763;
            this.label2.Text = "Focus con Ctrl+A";
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Tomato;
            this.label27.Dock = System.Windows.Forms.DockStyle.Top;
            this.label27.Location = new System.Drawing.Point(0, 49);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(313, 5);
            this.label27.TabIndex = 802;
            // 
            // frm_Solo_Canti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(313, 203);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_cant);
            this.Controls.Add(this.kryptonBorderEdge2);
            this.Controls.Add(this.lbl_stock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_nom);
            this.Controls.Add(this.pnl_titu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Solo_Canti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Solo_Canti";
            this.Load += new System.EventHandler(this.frm_Solo_Canti_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_Solo_Canti_KeyDown);
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        internal System.Windows.Forms.Label lbl_stock;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lbl_nom;
        private System.Windows.Forms.Panel pnl_titu;
        private System.Windows.Forms.Label label1;
        private Krypton.Toolkit.KryptonBorderEdge kryptonBorderEdge2;
        public Guna.UI2.WinForms.Guna2TextBox txt_cant;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label27;
    }
}