using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;

namespace CapaPresentacion.Usuario
{
    public partial class frm_Registro_Privilegio : Form
    {
        public frm_Registro_Privilegio()
        {
            InitializeComponent();
        }

        private void frm_Registro_Privilegio_Load(object sender, EventArgs e)
        {
            Buscar_Datos_deUsuario(Convert.ToInt32(this.Tag));
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Cls_ModalCategoria objMover = new Cls_ModalCategoria();
            if (e.Button == MouseButtons.Left)
            {
                objMover.MoverFormulario(this);
            }
        }

        private void Buscar_Datos_deUsuario(int idusu)
        {
            CN_Usuario obj = new CN_Usuario();
            DataTable data = new DataTable();

            string rutafoto = "-";

            try
            {

                data = obj.CN_Buscar_Usuario_porId(idusu);
                if(data.Rows.Count > 0)
                {
                    lbl_usus.Text = Convert.ToString(data.Rows[0]["Id_Usu"]);
                    lbl_user_perfil.Text = Convert.ToString(data.Rows[0]["Nombres"]) + "" + Convert.ToString(data.Rows[0]["Apellidos"]);
                    lbl_rol.Text = Convert.ToString(data.Rows[0]["Rol"]);

                    rutafoto = Convert.ToString(data.Rows[0]["FotoUsu"]);

                    
                    if(File.Exists(rutafoto) == false)
                    {
                        pic_user_2.Image =Properties.Resources.Perfil;
                    }
                    else
                    {
                        pic_user_2.Load(rutafoto);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void btn_Registrar_Privi_Click(object sender, EventArgs e)
        {
            CN_MenuUsuario obj = new CN_MenuUsuario();
            int idUsu = Convert.ToInt32(lbl_usus.Text);

            if(Convert.ToInt32(Cls_ModalCategoria.Idrol) == 1)
            {
                if (obj.CN_VerificarSiTieneMenu(idUsu) == true) 
                {
                    MessageBox.Show("El usuario ya tiene privilegios asignados. Por favor, elimine los privilegios actuales antes de registrar nuevos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btn_Eliminar_Privi.Enabled = true;
                    return;
                }
                else
                {
                    Registrar_Privilegios();
                    this.Close();
                }
            }
            else
            {
               MessageBox.Show("No tiene permisos para asignar privilegios a este usuario.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Eliminar_Privi.Enabled = false;
                return;
            }
        }




        private void Registrar_Privilegios()
        {
            CN_MenuUsuario obj = new CN_MenuUsuario();
            int idUsu = Convert.ToInt32(lbl_usus.Text);

            if (chk_aperturaCaja.Checked == true){ obj.CN_RegistrarPrivilegios(chk_aperturaCaja.Text, idUsu); }
            if (chk_cierrecaja.Checked == true){ obj.CN_RegistrarPrivilegios(chk_cierrecaja.Text, idUsu); }
            if (chk_hacerventa.Checked == true){ obj.CN_RegistrarPrivilegios(chk_hacerventa.Text, idUsu); }
            if(chk_tipocambio.Checked == true) { obj.CN_RegistrarPrivilegios(chk_tipocambio.Text, idUsu); }
            if(chk_admicorrelativo.Checked == true) { obj.CN_RegistrarPrivilegios(chk_admicorrelativo.Text, idUsu); }
            if(chk_sinStock.Checked == true) { obj.CN_RegistrarPrivilegios(chk_sinStock.Text, idUsu); }
            if(chk_ventaperdida.Checked == true) { obj.CN_RegistrarPrivilegios(chk_ventaperdida.Text, idUsu); }
            if(chk_vermovimiento.Checked == true) { obj.CN_RegistrarPrivilegios(chk_vermovimiento.Text, idUsu); }
            if(chk_otrosingresos.Checked == true) { obj.CN_RegistrarPrivilegios(chk_otrosingresos.Text, idUsu); }
            if(chk_gastosdia.Checked == true) { obj.CN_RegistrarPrivilegios(chk_gastosdia.Text, idUsu); }
            if(chk_verComprobantesEmitidos.Checked == true) { obj.CN_RegistrarPrivilegios(chk_verComprobantesEmitidos.Text, idUsu); }
            if(chk_Cierre.Checked == true) { obj.CN_RegistrarPrivilegios(chk_Cierre.Text, idUsu); }

            //Catalogo:
            if(chk_crearProducto.Checked == true) { obj.CN_RegistrarPrivilegios(chk_crearProducto.Text, idUsu); }
            if(chk_CrearCliente.Checked == true) { obj.CN_RegistrarPrivilegios(chk_CrearCliente.Text, idUsu); }
            if(chk_ManteFamilia.Checked == true) { obj.CN_RegistrarPrivilegios(chk_ManteFamilia.Text, idUsu); }
            if(chk_ProductoSnRotacion.Checked == true) { obj.CN_RegistrarPrivilegios(chk_ProductoSnRotacion.Text, idUsu); }
            if(chk_Producto_sinReporsicion.Checked == true) { obj.CN_RegistrarPrivilegios(chk_Producto_sinReporsicion.Text, idUsu); }
            if(chk_Cataologo_Producto.Checked == true) { obj.CN_RegistrarPrivilegios(chk_Cataologo_Producto.Text, idUsu); }

            //Inventario:
            if(chk_TraspasoSalida.Checked == true) { obj.CN_RegistrarPrivilegios(chk_TraspasoSalida.Text, idUsu); }
            if(chk_TraspasoIngreso.Checked == true) { obj.CN_RegistrarPrivilegios(chk_TraspasoIngreso.Text, idUsu); }
            if(chk_AjusteInventario.Checked == true) { obj.CN_RegistrarPrivilegios(chk_AjusteInventario.Text, idUsu); }
            if(chk_ReporteInventario.Checked == true) { obj.CN_RegistrarPrivilegios(chk_ReporteInventario.Text, idUsu); }
            if(chk_VerKardex.Checked == true) { obj.CN_RegistrarPrivilegios(chk_VerKardex.Text, idUsu); }

            //Seguridad:
            if(chk_AdminUsu.Checked == true) { obj.CN_RegistrarPrivilegios(chk_AdminUsu.Text, idUsu); }
            if(chk_ActuaaPrecio.Checked == true) { obj.CN_RegistrarPrivilegios(chk_ActuaaPrecio.Text, idUsu); }
            if(chk_CanjearNotaVenrta.Checked == true) { obj.CN_RegistrarPrivilegios(chk_CanjearNotaVenrta.Text, idUsu); }
            if(chk_AnularCopmprobante.Checked == true) { obj.CN_RegistrarPrivilegios(chk_AnularCopmprobante.Text, idUsu); }
            if(chk_EliminarIngreso.Checked == true) { obj.CN_RegistrarPrivilegios(chk_EliminarIngreso.Text, idUsu); }
            if(chk_eliminarGuiaSalida.Checked == true) { obj.CN_RegistrarPrivilegios(chk_eliminarGuiaSalida.Text, idUsu); }

            //Herramientas:
            if(chk_EditarDatoExcel.Checked == true) { obj.CN_RegistrarPrivilegios(chk_EditarDatoExcel.Text, idUsu); }
            if(chk_ExportarDatos.Checked == true) { obj.CN_RegistrarPrivilegios(chk_ExportarDatos.Text, idUsu); }
            if(chk_ImportarDatos.Checked == true) { obj.CN_RegistrarPrivilegios(chk_ImportarDatos.Text, idUsu); }


            //Reportes:
            if(chk_RecordMensual.Checked == true) { obj.CN_RegistrarPrivilegios(chk_RecordMensual.Text, idUsu); }
            if(chk_RecordGeneral.Checked == true) { obj.CN_RegistrarPrivilegios(chk_RecordGeneral.Text, idUsu); }
            if(chk_ReoporteProducto.Checked == true) { obj.CN_RegistrarPrivilegios(chk_ReoporteProducto.Text, idUsu); }
            if(chk_ImprimirMovmiento.Checked == true) { obj.CN_RegistrarPrivilegios(chk_ImprimirMovmiento.Text, idUsu); }
            if(chk_VerGuia.Checked == true) { obj.CN_RegistrarPrivilegios(chk_VerGuia.Text, idUsu); }
            if(chk_VerClienteRegi.Checked == true) { obj.CN_RegistrarPrivilegios(chk_VerClienteRegi.Text, idUsu); }


        }

        private void btn_Eliminar_Privi_Click(object sender, EventArgs e)
        {
            CN_MenuUsuario obj = new CN_MenuUsuario();
            if (lbl_usus.Text.Trim().Length == 0) { return; }
            obj.CN_EliminarPrivilegios(Convert.ToInt32(lbl_usus.Text));
            btn_Eliminar_Privi.Enabled = false;
            MessageBox.Show("Privilegios eliminados correctamente. Ahora puede registrar nuevos privilegios para este usuario.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_cancelar_Privi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
