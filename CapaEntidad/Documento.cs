using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Documento
    {
        private string _id_Doc;
        private string _id_Ped;
        private int _Id_Tipo;
        private DateTime _Fecha_Emi;
        private double _ImporteDoc;
        private string _TipoPago;
        private string _Nro_Operation;
        private int _Id_Usu;
        private double _TotalGanancia;
        private double _TotalDscuento;
        private string _Estado_Doc;
        private string _CodigoMoneda = "PEN";
        private decimal _TipoCambio = 1m;
        private decimal _ImporteMoneda;
        private decimal _ImporteSoles;

        public string Id_Doc { get => _id_Doc; set => _id_Doc = value; }
        public string Id_Ped { get => _id_Ped; set => _id_Ped = value; }
        public int Id_Tipo { get => _Id_Tipo; set => _Id_Tipo = value; }
        public DateTime Fecha_Emi { get => _Fecha_Emi; set => _Fecha_Emi = value; }
        public double ImporteDoc { get => _ImporteDoc; set => _ImporteDoc = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string Nro_Operation { get => _Nro_Operation; set => _Nro_Operation = value; }
        public int Id_Usu { get => _Id_Usu; set => _Id_Usu = value; }
        public double TotalGanancia { get => _TotalGanancia; set => _TotalGanancia = value; }
        public double TotalDscuento { get => _TotalDscuento; set => _TotalDscuento = value; }
        public string Estado_Doc { get => _Estado_Doc; set => _Estado_Doc = value; }
        public string CodigoMoneda { get => _CodigoMoneda; set => _CodigoMoneda = value; }
        public decimal TipoCambio { get => _TipoCambio; set => _TipoCambio = value; }
        public decimal ImporteMoneda { get => _ImporteMoneda; set => _ImporteMoneda = value; }
        public decimal ImporteSoles { get => _ImporteSoles; set => _ImporteSoles = value; }
    }
}
