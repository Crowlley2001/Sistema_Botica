using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_DocumentoCompra
    {
        private string _Id_DocComp;
        private string _Id_Pro;
        private double _PrecioUnit;
        private double _Cantidad;
        private double _Importe;
        private double _preventa;

        public string Id_DocComp { get => _Id_DocComp; set => _Id_DocComp = value; }
        public string Id_Pro { get => _Id_Pro; set => _Id_Pro = value; }
        public double PrecioUnit { get => _PrecioUnit; set => _PrecioUnit = value; }
        public double Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Importe { get => _Importe; set => _Importe = value; }
        public double Preventa { get => _preventa; set => _preventa = value; }
    }
}
