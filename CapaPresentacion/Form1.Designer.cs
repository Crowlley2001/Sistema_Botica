namespace CapaPresentacion
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_prueba = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_cargar = new Guna.UI2.WinForms.Guna2Button();
            this.btn_actualizar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.SuspendLayout();
            // 
            // txt_prueba
            // 
            this.txt_prueba.BackColor = System.Drawing.Color.Transparent;
            this.txt_prueba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.txt_prueba.BorderColor = System.Drawing.Color.White;
            this.txt_prueba.BorderRadius = 16;
            this.txt_prueba.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_prueba.DefaultText = "";
            this.txt_prueba.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_prueba.DisabledState.FillColor = System.Drawing.Color.White;
            this.txt_prueba.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_prueba.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_prueba.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_prueba.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_prueba.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_prueba.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txt_prueba.IconLeftSize = new System.Drawing.Size(16, 16);
            this.txt_prueba.Location = new System.Drawing.Point(251, 243);
            this.txt_prueba.Name = "txt_prueba";
            this.txt_prueba.PlaceholderForeColor = System.Drawing.Color.White;
            this.txt_prueba.PlaceholderText = "";
            this.txt_prueba.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_prueba.SelectedText = "";
            this.txt_prueba.Size = new System.Drawing.Size(332, 51);
            this.txt_prueba.TabIndex = 44;
            // 
            // btn_cargar
            // 
            this.btn_cargar.BackColor = System.Drawing.Color.White;
            this.btn_cargar.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_cargar.BorderRadius = 6;
            this.btn_cargar.BorderThickness = 1;
            this.btn_cargar.DisabledState.BorderColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cargar.DisabledState.CustomBorderColor = System.Drawing.Color.MediumPurple;
            this.btn_cargar.DisabledState.FillColor = System.Drawing.Color.MediumPurple;
            this.btn_cargar.DisabledState.ForeColor = System.Drawing.Color.MediumPurple;
            this.btn_cargar.FillColor = System.Drawing.Color.White;
            this.btn_cargar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_cargar.ForeColor = System.Drawing.Color.Black;
            this.btn_cargar.Image = ((System.Drawing.Image)(resources.GetObject("btn_cargar.Image")));
            this.btn_cargar.Location = new System.Drawing.Point(188, 163);
            this.btn_cargar.Name = "btn_cargar";
            this.btn_cargar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_cargar.Size = new System.Drawing.Size(170, 43);
            this.btn_cargar.TabIndex = 43;
            this.btn_cargar.Text = "Cargar";
            this.btn_cargar.Click += new System.EventHandler(this.btn_cargar_Click);
            // 
            // btn_actualizar
            // 
            this.btn_actualizar.BackColor = System.Drawing.Color.White;
            this.btn_actualizar.BorderColor = System.Drawing.Color.DarkOrchid;
            this.btn_actualizar.BorderRadius = 6;
            this.btn_actualizar.BorderThickness = 1;
            this.btn_actualizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_actualizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_actualizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_actualizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_actualizar.FillColor = System.Drawing.Color.Transparent;
            this.btn_actualizar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_actualizar.ForeColor = System.Drawing.Color.Black;
            this.btn_actualizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_actualizar.Image")));
            this.btn_actualizar.Location = new System.Drawing.Point(463, 163);
            this.btn_actualizar.Name = "btn_actualizar";
            this.btn_actualizar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_actualizar.Size = new System.Drawing.Size(170, 43);
            this.btn_actualizar.TabIndex = 42;
            this.btn_actualizar.Text = "Actualizar";
            this.btn_actualizar.Click += new System.EventHandler(this.btn_actualizar_Click);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.guna2Separator1.CausesValidation = false;
            this.guna2Separator1.FillColor = System.Drawing.Color.Red;
            this.guna2Separator1.FillStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.guna2Separator1.Location = new System.Drawing.Point(97, 327);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(639, 48);
            this.guna2Separator1.TabIndex = 45;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 451);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.txt_prueba);
            this.Controls.Add(this.btn_cargar);
            this.Controls.Add(this.btn_actualizar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btn_cargar;
        private Guna.UI2.WinForms.Guna2Button btn_actualizar;
        private Guna.UI2.WinForms.Guna2TextBox txt_prueba;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}