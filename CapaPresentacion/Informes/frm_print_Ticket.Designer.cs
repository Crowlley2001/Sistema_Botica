namespace CapaPresentacion.Informes
{
    partial class frm_print_Ticket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_print_Ticket));
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_nroDoc = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_reimprimir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Crys_visor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(0, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(457, 11);
            this.label2.TabIndex = 29;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbl_nroDoc);
            this.panel1.Controls.Add(this.btn_Print);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_reimprimir);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 49);
            this.panel1.TabIndex = 682;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // lbl_nroDoc
            // 
            this.lbl_nroDoc.AutoSize = true;
            this.lbl_nroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nroDoc.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_nroDoc.Location = new System.Drawing.Point(167, 17);
            this.lbl_nroDoc.Name = "lbl_nroDoc";
            this.lbl_nroDoc.Size = new System.Drawing.Size(16, 20);
            this.lbl_nroDoc.TabIndex = 683;
            this.lbl_nroDoc.Text = "-";
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Print.FlatAppearance.BorderSize = 0;
            this.btn_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.ForeColor = System.Drawing.Color.White;
            this.btn_Print.Image = ((System.Drawing.Image)(resources.GetObject("btn_Print.Image")));
            this.btn_Print.Location = new System.Drawing.Point(370, 10);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(32, 35);
            this.btn_Print.TabIndex = 461;
            this.btn_Print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Image = ((System.Drawing.Image)(resources.GetObject("btn_close.Image")));
            this.btn_close.Location = new System.Drawing.Point(418, 9);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(32, 35);
            this.btn_close.TabIndex = 460;
            this.btn_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_reimprimir
            // 
            this.btn_reimprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reimprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reimprimir.FlatAppearance.BorderSize = 0;
            this.btn_reimprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_reimprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_reimprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reimprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reimprimir.ForeColor = System.Drawing.Color.White;
            this.btn_reimprimir.Image = ((System.Drawing.Image)(resources.GetObject("btn_reimprimir.Image")));
            this.btn_reimprimir.Location = new System.Drawing.Point(327, 9);
            this.btn_reimprimir.Name = "btn_reimprimir";
            this.btn_reimprimir.Size = new System.Drawing.Size(32, 35);
            this.btn_reimprimir.TabIndex = 459;
            this.btn_reimprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_reimprimir.UseVisualStyleBackColor = true;
            this.btn_reimprimir.Click += new System.EventHandler(this.btn_reimprimir_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(11, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 20);
            this.label7.TabIndex = 458;
            this.label7.Text = "Impresion de";
            // 
            // Crys_visor
            // 
            this.Crys_visor.ActiveViewIndex = -1;
            this.Crys_visor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Crys_visor.Cursor = System.Windows.Forms.Cursors.Default;
            this.Crys_visor.Location = new System.Drawing.Point(0, 55);
            this.Crys_visor.Name = "Crys_visor";
            this.Crys_visor.ShowCloseButton = false;
            this.Crys_visor.ShowCopyButton = false;
            this.Crys_visor.ShowGotoPageButton = false;
            this.Crys_visor.ShowGroupTreeButton = false;
            this.Crys_visor.ShowPageNavigateButtons = false;
            this.Crys_visor.ShowParameterPanelButton = false;
            this.Crys_visor.Size = new System.Drawing.Size(457, 743);
            this.Crys_visor.TabIndex = 683;
            this.Crys_visor.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frm_print_Ticket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(459, 810);
            this.Controls.Add(this.Crys_visor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_print_Ticket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresion de Reportes";
            this.Load += new System.EventHandler(this.frm_print_Ticket_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_print_Ticket_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label lbl_nroDoc;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_reimprimir;
        internal System.Windows.Forms.Label label7;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer Crys_visor;
    }
}