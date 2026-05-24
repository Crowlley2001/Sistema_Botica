using CapaDatos;
using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Ventas;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion.Usuario
{
    public partial class frm_Registrar_Usuario : Form
    {
        public frm_Registrar_Usuario()
        {
            InitializeComponent();
        }

        bool editMode = false;
        string xFotoruta = "";

        private void frm_Registrar_Usuario_Load(object sender, EventArgs e)
        {
            Configurar_Lisvie();
            Cargar_Todos_Usuarios();
            Cargar_Roles();
            //         FECHA - ACTUAL         //
            dtp_fecha.Value = DateTime.Now;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        private void Configurar_Lisvie()
        {
            var lis = lsv_usu;
            lis.Items.Clear();
            lis.Columns.Clear();
            lis.View = View.Details;
            lis.FullRowSelect = true;

            lis.Columns.Add("ID", 60, HorizontalAlignment.Center);
            lis.Columns.Add("Nombres", 150, HorizontalAlignment.Center);
            lis.Columns.Add("Usuario", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Clave", 125, HorizontalAlignment.Center);
            lis.Columns.Add("Rol", 120, HorizontalAlignment.Center);
            lis.Columns.Add("Estado", 120, HorizontalAlignment.Center);
        }

        private void Llenar_ListView_Prod(DataTable data)
        {
            lsv_usu.Items.Clear();

            foreach (DataRow row in data.Rows)
            {
                ListViewItem item = new ListViewItem(row["Id_Usu"].ToString());
                item.SubItems.Add(row["Nombres"].ToString());
                item.SubItems.Add(row["Usuario"].ToString());
                item.SubItems.Add(row["Contraseña"].ToString());

               
                item.SubItems.Add(row["Rol"].ToString());

                item.SubItems.Add(row["Estado_Usu"].ToString());

                lsv_usu.Items.Add(item);
            }
        }

        private void Cargar_Todos_Usuarios()
        {
            CN_Usuario obj = new CN_Usuario();
            DataTable data = obj.CN_Cargar_todos_Usuarios();

            if (data.Rows.Count > 0)
                Llenar_ListView_Prod(data);
            else
                lsv_usu.Items.Clear();
        }

        private void Cargar_Roles()
        {
            CN_Usuario obj = new CN_Usuario();
            DataTable data = obj.CN_Cargar_todos_Roels("");

            if (data.Rows.Count > 0)
            {
                cbo_rol.DataSource = data;
                cbo_rol.ValueMember = "Id_Rol";
                cbo_rol.DisplayMember = "Rol";
                cbo_rol.SelectedIndex = -1;
            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            pnl_nuevo.Visible = true;
            txt_id.Text = (lsv_usu.Items.Count + 1).ToString();
            txt_nombre.Focus();
            editMode = false;
        }

        private void btn_cancelar3_Click(object sender, EventArgs e)
        {
            pnl_nuevo.Visible = false;
            Limpiar();
        }

        private bool Validar_Texbox()
        {
            if (txt_id.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese el ID del Usuario");
                return false;
            }

            if (txt_nombre.Text.Trim().Length < 2)
            {
                MessageBox.Show("Ingrese tu nombre");
                txt_nombre.Focus();
                return false;
            }

            if (txt_apellido.Text.Trim().Length < 2)
            {
                MessageBox.Show("Ingrese tu apellido");
                txt_apellido.Focus();
                return false;
            }

            if (txt_usu.Text.Trim().Length < 4)
            {
                MessageBox.Show("Ingrese tu usuario de login (mínimo 4 caracteres)");
                txt_usu.Focus();
                return false;
            }

            if (txt_pass.Text.Trim().Length < 4)
            {
                MessageBox.Show("Ingrese tu clave de Login (mínimo 4 caracteres)");
                txt_pass.Focus();
                return false;
            }

            if (cbo_rol.SelectedIndex == -1)
            {
                MessageBox.Show("Elige un Rol");
                cbo_rol.Focus();
                return false;
            }

            return true;
        }

        private void btrn_registrar_Click(object sender, EventArgs e)
        {
            if (Validar_Texbox())
            {
                if (editMode)
                    Modificar_Usuario();
                else
                    Registrar_Usuario();
            }
        }

        private void Registrar_Usuario()
        {
            try
            {
                CN_Usuario obj = new CN_Usuario();
                Usuarios use = new Usuarios();
                Filtro fill = new Filtro();
                frm_Advertencia ver = new frm_Advertencia();
                frm_Msm_bueno ok = new frm_Msm_bueno();

                use.Idusu = Convert.ToInt32(txt_id.Text);
                use.Nombres = txt_nombre.Text;
                use.Apellidos = txt_apellido.Text;
                use.Usu = txt_usu.Text;
                use.Clave = txt_pass.Text;
                use.Foto = xFotoruta;
                use.FechaNaci = dtp_fecha.Value.ToString("yyyy-MM-dd");
                use.Idrol = cbo_rol.SelectedValue.ToString();
                use.Correo = txt_correo.Text;

                obj.CN_Registrar_Usuario(use);

                if (CD_Usuario.saved == true)
                {
                    fill.Show();
                    ok.Lbl_msm1.Text = "Usuario Registrado Correctamente";
                    ok.ShowDialog(this);
                    fill.Close();

                    Limpiar();
                    pnl_nuevo.Visible = false;
                    Cargar_Todos_Usuarios();
                }
                else
                {
                    fill.Show();
                    ver.lbl_msm.Text = "No se pudo registrar el usuario";
                    ver.ShowDialog(this);
                    fill.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Modificar_Usuario()
        {
            try
            {
                CN_Usuario obj = new CN_Usuario();
                Usuarios use = new Usuarios();
                Filtro fill = new Filtro();
                frm_Advertencia ver = new frm_Advertencia();
                frm_Msm_bueno ok = new frm_Msm_bueno();

                use.Idusu = Convert.ToInt32(txt_id.Text);
                use.Nombres = txt_nombre.Text;
                use.Apellidos = txt_apellido.Text;
                use.Usu = txt_usu.Text;
                use.Clave = txt_pass.Text;
                use.Foto = xFotoruta;
                use.FechaNaci = dtp_fecha.Value.ToString("yyyy-MM-dd");
                use.Idrol = cbo_rol.SelectedValue.ToString();
                use.Correo = txt_correo.Text;

                obj.Cn_Modificar_Usaurio(use);
                if (CD_Usuario.saved == true)
                {
                    fill.Show();
                    ok.Lbl_msm1.Text = "Usuario Modificado Correctamente";
                    ok.ShowDialog(this);
                    fill.Close();

                    Limpiar();
                    pnl_nuevo.Visible = false;
                    Cargar_Todos_Usuarios();
                }

                Limpiar();
                pnl_nuevo.Visible = false;
                Cargar_Todos_Usuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Limpiar()
        {
            txt_id.Clear();
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_usu.Clear();
            txt_pass.Clear();
            txt_correo.Clear();
            cbo_rol.SelectedIndex = -1;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void piclogo_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Imagenes|*.jpg;*.png;*.jpeg";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    xFotoruta = openFile.FileName;
                    piclogo.Load(xFotoruta);
                }
            }
            catch
            {
                piclogo.Load(Application.StartupPath + @"\user.png");
                xFotoruta = Application.StartupPath + @"\user.png";
                MessageBox.Show("Error al cargar la imagen");
            }
        }

        private void lsv_usu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int idusu = 0;
            var lis = lsv_usu.SelectedItems[0];
            idusu = Convert.ToInt32(lis.SubItems[0].Text);
            Buscar_Datos_Usuario(idusu);
           
        }

        private void Buscar_Datos_Usuario(int idusu)
        {
            CN_Usuario obj = new CN_Usuario();
            DataTable data = new DataTable();

            try
            {
                data = obj.CN_Buscar_Usuario_porId(idusu);
                if (data.Rows.Count == 0) return;

                    txt_id.Text = Convert.ToString(data.Rows[0]["Id_Usu"]);
                    txt_nombre.Text = Convert.ToString(data.Rows[0]["Nombres"]);
                    txt_apellido.Text = Convert.ToString(data.Rows[0]["Apellidos"]);
                    txt_usu.Text = Convert.ToString(data.Rows[0]["Usuario"]);
                    txt_pass.Text = Convert.ToString(data.Rows[0]["Contraseña"]);
                    txt_correo.Text = Convert.ToString(data.Rows[0]["Correo"]);
                    cbo_rol.SelectedValue = Convert.ToString(data.Rows[0]["Id_Rol"]);
                    dtp_fecha.Value = Convert.ToDateTime(data.Rows[0]["Fecha_Ncmiento"]);
         
                    xFotoruta = Convert.ToString(data.Rows[0]["FotoUsu"]);

                    if (File.Exists(xFotoruta) == false)
                    {
                        piclogo.Load(Application.StartupPath + @"\user.png");

                    }
                    else
                    {
                        piclogo.Load(xFotoruta);
                    }
                    pnl_nuevo.Visible = true;
                    editMode = true;
                    lbl_nom.Text = "Modificar Usuario";
                    txt_nombre.Focus();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            int idusu = 0;
            CN_Usuario obj = new CN_Usuario();
            Filtro fill = new Filtro();
            frm_Advertencia ver = new frm_Advertencia();
            frm_Msm_bueno ok = new frm_Msm_bueno();

            if (lsv_usu.SelectedItems.Count == 0)
            {
                fill.Show();
                ver.lbl_msm.Text = "Seleccione un usuario para eliminar";
                ver.ShowDialog(this);
                fill.Close();
                return;
            }

            var lis = lsv_usu.SelectedItems[0];
            idusu = Convert.ToInt32(lis.SubItems[0].Text);

            obj.CN_Eliminar_Usuario(idusu);

            if (CD_Usuario.saved == true)
            {
                fill.Show();
                ok.Lbl_msm1.Text = "Usuario eliminado correctamente";
                ok.ShowDialog(this);
                fill.Close();

                Cargar_Todos_Usuarios();
            }
            else
            {
                fill.Show();
                ver.lbl_msm.Text = "No se pudo eliminar el usuario";
                ver.ShowDialog(this);
                fill.Close();
            }
        }
    }
}