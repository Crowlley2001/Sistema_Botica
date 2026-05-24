using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Ventas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class mdCorrelativo : Form
    {
        public mdCorrelativo()
        {
            InitializeComponent();
        }

        bool yacargo = false; // Variable para controlar la carga inicial del combo
        private void mdCorrelativo_Load(object sender, EventArgs e)
        {
            Cargar_TipoDoc();
            yacargo = true; 
        }
        private void pnl_titulo_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria obj = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                obj.MoverFormulario(this);

            }
        }

        private void Cargar_TipoDoc()
        {
            CN_TipoDoc obj = new CN_TipoDoc();
            DataTable dato = new DataTable();

            dato = obj.CN_Cargar_Todos_Los_Correlativos();
            if (dato.Rows.Count > 0)
            {
                cbo_Docs.DataSource = dato;
                cbo_Docs.DisplayMember = "Documento";
                cbo_Docs.ValueMember = "Id_Tipo";
                cbo_Docs.SelectedIndex = -1;
            }
        }

        private void btn_cancelPago_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void cbo_Docs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yacargo == true)
            {
                if (cbo_Docs.SelectedIndex > -1)
                {
                    int idtipo = Convert.ToInt32(cbo_Docs.SelectedValue);
                    Buscar_tipoDoc(idtipo);
                }

            }
        }

        private void Buscar_tipoDoc(int idtipo)
        {
            CN_TipoDoc obj = new CN_TipoDoc();
            DataTable dato = new DataTable();
            string nom = "";

            dato = obj.CN_Cargar_Correlativo_porId(idtipo);
            if (dato.Rows.Count > 0)
            {
                txt_idCorrelativo.Text = Convert.ToString(dato.Rows[0]["Id_Tipo"]);
                nom = Convert.ToString(dato.Rows[0]["Documento"]);
                txt_serie.Text = Convert.ToString(dato.Rows[0]["Serie"]);
                txt_numeroCorrelativo.Text = Convert.ToString(dato.Rows[0]["Numero"]);

                lbl_nom.Text = "Edicion de: " + nom;

                pnl_edit.Enabled = true;
                btn_save.Enabled = true;
                txt_serie.Focus();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            CN_TipoDoc obj = new CN_TipoDoc();
            Filtro fil = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_Msm_bueno ok = new frm_Msm_bueno();
            TipoDoc ti = new TipoDoc();

            if (txt_idCorrelativo.Text.Trim().Length == 0) { fil.Show(); ver.lbl_msm.Text = "Falta el ID del Documento"; ver.ShowDialog(); fil.Hide(); cbo_Docs.Focus(); return; }
            if (txt_serie.Text.Trim().Length == 0) { fil.Show(); ver.lbl_msm.Text = "Falta la Serie del Documento"; ver.ShowDialog(); fil.Hide(); txt_serie.Focus(); return; }
            if (txt_numeroCorrelativo.Text.Trim().Length < 5) { fil.Show(); ver.lbl_msm.Text = "Falta el Nro del Documento"; ver.ShowDialog(); fil.Hide(); txt_numeroCorrelativo.Focus(); return; }

            try
            {
                ti.Id_Tipo = Convert.ToInt32(txt_idCorrelativo.Text);
                ti.Documento = cbo_Docs.Text;
                ti.Serie = txt_serie.Text;
                ti.Numero = txt_numeroCorrelativo.Text;
                obj.CN_Editar_Correlativo(ti);
                if (CD_TipoDoc.Saved == true)
                {
                    fil.Show();
                    ok.Lbl_msm1.Text = "Los Cambios se han Guardado correctamente";
                    ok.ShowDialog(this);
                    fil.Hide();

                    txt_serie.Text = "";
                    txt_numeroCorrelativo.Text = "";
                    txt_idCorrelativo.Text = "";

                    pnl_edit.Enabled = false;
                    btn_save.Enabled = false;
                    this.Close();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al guardar los cambios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}
