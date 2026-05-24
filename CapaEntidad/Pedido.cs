using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pedido
    {
        private string _id_Ped;
        private string _id_Cliente;
        private DateTime _Fecha_Ped;
        private double _SubTotal;
        private double _IgvPed;
        private double _TotalPed;
        private int _id_Usu;
        private double _TotalGancia;
        private double _Total_Dscuento;
        private string _Estado_Ped;

        public string Id_Ped { get => _id_Ped; set => _id_Ped = value; }
        public string Id_Cliente { get => _id_Cliente; set => _id_Cliente = value; }
        public DateTime Fecha_Ped { get => _Fecha_Ped; set => _Fecha_Ped = value; }
        public double SubTotal { get => _SubTotal; set => _SubTotal = value; }
        public double IgvPed { get => _IgvPed; set => _IgvPed = value; }
        public double TotalPed { get => _TotalPed; set => _TotalPed = value; }
        public int Id_Usu { get => _id_Usu; set => _id_Usu = value; }
        public double TotalGancia { get => _TotalGancia; set => _TotalGancia = value; }
        public double Total_Dscuento { get => _Total_Dscuento; set => _Total_Dscuento = value; }
        public string Estado_Ped { get => _Estado_Ped; set => _Estado_Ped = value; }
    }
}
