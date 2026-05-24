namespace CapaPresentacion.Ventas
{
    partial class frm_Si_No
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Si_No));
            this.BunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lbl_msm = new System.Windows.Forms.Label();
            this.btn_no = new Guna.UI2.WinForms.Guna2Button();
            this.btn_si = new Guna.UI2.WinForms.Guna2Button();
            this.pnl_titu = new System.Windows.Forms.Panel();
            this.lbl_Nomalgo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_titu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BunifuElipse1
            // 
            this.BunifuElipse1.ElipseRadius = 15;
            this.BunifuElipse1.TargetControl = this;
            // 
            // lbl_msm
            // 
            this.lbl_msm.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_msm.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_msm.Location = new System.Drawing.Point(8, 247);
            this.lbl_msm.Name = "lbl_msm";
            this.lbl_msm.Size = new System.Drawing.Size(390, 240);
            this.lbl_msm.TabIndex = 644;
            this.lbl_msm.Text = "¿Quieres quitarlo del Carrito?";
            this.lbl_msm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_no
            // 
            this.btn_no.BackColor = System.Drawing.Color.White;
            this.btn_no.BorderColor = System.Drawing.Color.DimGray;
            this.btn_no.BorderRadius = 6;
            this.btn_no.BorderThickness = 1;
            this.btn_no.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_no.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_no.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_no.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_no.FillColor = System.Drawing.Color.White;
            this.btn_no.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_no.ForeColor = System.Drawing.Color.DimGray;
            this.btn_no.Image = ((System.Drawing.Image)(resources.GetObject("btn_no.Image")));
            this.btn_no.Location = new System.Drawing.Point(219, 501);
            this.btn_no.Name = "btn_no";
            this.btn_no.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_no.Size = new System.Drawing.Size(122, 43);
            this.btn_no.TabIndex = 646;
            this.btn_no.Text = "NO";
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // btn_si
            // 
            this.btn_si.BackColor = System.Drawing.Color.White;
            this.btn_si.BorderColor = System.Drawing.Color.DimGray;
            this.btn_si.BorderRadius = 6;
            this.btn_si.BorderThickness = 1;
            this.btn_si.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_si.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_si.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_si.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_si.FillColor = System.Drawing.Color.Transparent;
            this.btn_si.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_si.ForeColor = System.Drawing.Color.DimGray;
            this.btn_si.Image = ((System.Drawing.Image)(resources.GetObject("btn_si.Image")));
            this.btn_si.Location = new System.Drawing.Point(58, 501);
            this.btn_si.Name = "btn_si";
            this.btn_si.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_si.Size = new System.Drawing.Size(122, 43);
            this.btn_si.TabIndex = 645;
            this.btn_si.Text = "SI";
            this.btn_si.Click += new System.EventHandler(this.btn_si_Click);
            // 
            // pnl_titu
            // 
            this.pnl_titu.BackColor = System.Drawing.Color.White;
            this.pnl_titu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_titu.BackgroundImage")));
            this.pnl_titu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_titu.Controls.Add(this.lbl_Nomalgo);
            this.pnl_titu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_titu.Location = new System.Drawing.Point(0, 0);
            this.pnl_titu.Name = "pnl_titu";
            this.pnl_titu.Size = new System.Drawing.Size(406, 236);
            this.pnl_titu.TabIndex = 643;
            this.pnl_titu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_titu_MouseMove);
            // 
            // lbl_Nomalgo
            // 
            this.lbl_Nomalgo.AutoSize = true;
            this.lbl_Nomalgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nomalgo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_Nomalgo.Location = new System.Drawing.Point(124, 209);
            this.lbl_Nomalgo.Name = "lbl_Nomalgo";
            this.lbl_Nomalgo.Size = new System.Drawing.Size(161, 24);
            this.lbl_Nomalgo.TabIndex = 23;
            this.lbl_Nomalgo.Text = "¡Hepaa! Espera!";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Tomato;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 5);
            this.label2.TabIndex = 766;
            // 
            // frm_Si_No
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(406, 577);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_no);
            this.Controls.Add(this.btn_si);
            this.Controls.Add(this.pnl_titu);
            this.Controls.Add(this.lbl_msm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Si_No";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Si_No";
            this.pnl_titu.ResumeLayout(false);
            this.pnl_titu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Bunifu.Framework.UI.BunifuElipse BunifuElipse1;
        private System.Windows.Forms.Panel pnl_titu;
        internal System.Windows.Forms.Label lbl_Nomalgo;
        internal System.Windows.Forms.Label lbl_msm;
        private Guna.UI2.WinForms.Guna2Button btn_no;
        private Guna.UI2.WinForms.Guna2Button btn_si;
        private System.Windows.Forms.Label label2;
    }
}