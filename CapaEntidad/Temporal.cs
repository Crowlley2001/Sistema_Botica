using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Temporal
    {
        private string _CodTem;
        private string _FechaEmi;
        private string _cliente;
        private string _Ruc;
        private string _Direccion;
        private string _SubTtal;
        private string _IgvT;
        private string _TotalT;
        private string _TotalDscto;
        private string _SonT;
        private string _Vendedor;
        private string _CodigoQr;
        private string _Tipocomprobante;
        private string _HashCpe;
        private string _MotivoEmi;
        private string _TipoPago;
        private string _DireccionTienda;
        private string _NombreSucursal;

        public string CodTem { get => _CodTem; set => _CodTem = value; }
        public string FechaEmi { get => _FechaEmi; set => _FechaEmi = value; }
        public string Cliente { get => _cliente; set => _cliente = value; }
        public string Ruc { get => _Ruc; set => _Ruc = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string SubTtal { get => _SubTtal; set => _SubTtal = value; }
        public string IgvT { get => _IgvT; set => _IgvT = value; }
        public string TotalT { get => _TotalT; set => _TotalT = value; }
        public string TotalDscto { get => _TotalDscto; set => _TotalDscto = value; }
        public string SonT { get => _SonT; set => _SonT = value; }
        public string Vendedor { get => _Vendedor; set => _Vendedor = value; }
        public string Tipocomprobante { get => _Tipocomprobante; set => _Tipocomprobante = value; }
        public string HashCpe { get => _HashCpe; set => _HashCpe = value; }
        public string MotivoEmi { get => _MotivoEmi; set => _MotivoEmi = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string DireccionTienda { get => _DireccionTienda; set => _DireccionTienda = value; }
        public string NombreSucursal { get => _NombreSucursal; set => _NombreSucursal = value; }
        public string CodigoQr { get => _CodigoQr; set => _CodigoQr = value; }
    }
}
