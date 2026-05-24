using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Documento_Compras
    {
        private string _Id_DocComp;
        private string _NroFac_Fisico;
        private double _SubTotal_ingre;
        private DateTime _Fecha_Ingre;
        private double _Total_Ingre;
        private int _id_Usu;
        private string _ModalidadPago;
        private int _TiempoEspera;
        private DateTime _Fecha_Vencimiento;
        private string _Estado_Ingre;
        private string _Datos_Adicional;
        private string _TipoDoc_Compra;
        private string _Tiporegistro;
        private string _LugarSalida;
        private string _TipoProceso;

        public string Id_DocComp { get => _Id_DocComp; set => _Id_DocComp = value; }
        public string NroFac_Fisico { get => _NroFac_Fisico; set => _NroFac_Fisico = value; }
        public double SubTotal_ingre { get => _SubTotal_ingre; set => _SubTotal_ingre = value; }
        public DateTime Fecha_Ingre { get => _Fecha_Ingre; set => _Fecha_Ingre = value; }
        public double Total_Ingre { get => _Total_Ingre; set => _Total_Ingre = value; }
        public int id_Usu { get => _id_Usu; set => _id_Usu = value; }
        public string ModalidadPago { get => _ModalidadPago; set => _ModalidadPago = value; }
        public int TiempoEspera { get => _TiempoEspera; set => _TiempoEspera = value; }
        public DateTime Fecha_Vencimiento { get => _Fecha_Vencimiento; set => _Fecha_Vencimiento = value; }
        public string Estado_Ingre { get => _Estado_Ingre; set => _Estado_Ingre = value; }
        public string Datos_Adicional { get => _Datos_Adicional; set => _Datos_Adicional = value; }
        public string TipoDoc_Compra { get => _TipoDoc_Compra; set => _TipoDoc_Compra = value; }
        public string Tiporegistro { get => _Tiporegistro; set => _Tiporegistro = value; }
        public string LugarSalida { get => _LugarSalida; set => _LugarSalida = value; }
        public string TipoProceso { get => _TipoProceso; set => _TipoProceso = value; }

    }
}
