using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Pedido
    {
        private string _id_Ped;
        private string _id_Pro;
        private double _Precio;
        private double _Cantidad;
        private double _Importe;
        private double _Utilidad_Unit;
        private double _TotalUtilidad;
        private double _DescuentoDet;

        public string Id_Ped { get => _id_Ped; set => _id_Ped = value; }
        public string Id_Pro { get => _id_Pro; set => _id_Pro = value; }
        public double Precio { get => _Precio; set => _Precio = value; }
        public double Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public double Importe { get => _Importe; set => _Importe = value; }
        public double Utilidad_Unit { get => _Utilidad_Unit; set => _Utilidad_Unit = value; }
        public double TotalUtilidad { get => _TotalUtilidad; set => _TotalUtilidad = value; }
        public double DescuentoDet { get => _DescuentoDet; set => _DescuentoDet = value; }
    }
}
