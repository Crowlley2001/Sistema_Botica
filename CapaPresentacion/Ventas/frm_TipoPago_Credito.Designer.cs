namespace CapaPresentacion.Ventas
{
    partial class frm_TipoPago_Credito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TipoPago_Credito));
            this.Lbl_msm1 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_Nomalgo = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_msm1
            // 
            this.Lbl_msm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_msm1.ForeColor = System.Drawing.Color.DimGray;
            this.Lbl_msm1.Location = new System.Drawing.Point(12, 194);
            this.Lbl_msm1.Name = "Lbl_msm1";
            this.Lbl_msm1.Size = new System.Drawing.Size(361, 116);
            this.Lbl_msm1.TabIndex = 640;
            this.Lbl_msm1.Text = "¿Quieres Quitarlo del Carrito?";
            this.Lbl_msm1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(191)))));
            this.panel1.Controls.Add(this.lbl_Nomalgo);
            this.panel1.Controls.Add(this.PictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 163);
            this.panel1.TabIndex = 641;
            // 
            // lbl_Nomalgo
            // 
            this.lbl_Nomalgo.AutoSize = true;
            this.lbl_Nomalgo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Nomalgo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nomalgo.ForeColor = System.Drawing.Color.White;
            this.lbl_Nomalgo.Location = new System.Drawing.Point(119, 124);
            this.lbl_Nomalgo.Name = "lbl_Nomalgo";
            this.lbl_Nomalgo.Size = new System.Drawing.Size(147, 24);
            this.lbl_Nomalgo.TabIndex = 27;
            this.lbl_Nomalgo.Text = "Proceso Exitoso";
            this.lbl_Nomalgo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(147, 24);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(83, 79);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox1.TabIndex = 26;
            this.PictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Tomato;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(389, 5);
            this.label2.TabIndex = 801;
            // 
            // frm_TipoPago_Credito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(389, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lbl_msm1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_TipoPago_Credito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_TipoPago_Credito";
            this.Load += new System.EventHandler(this.frm_TipoPago_Credito_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Lbl_msm1;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lbl_Nomalgo;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Label label2;
    }
}