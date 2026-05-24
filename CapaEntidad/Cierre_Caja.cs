using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cierre_Caja
    {
        private string _Id_cierre;
        private DateTime _Fecha_Cierre;
        private double _Apertura_Caja;
        private double _Total_Ingreso;
        private double _TotalEgreso;
        private int _Id_Usu;
        private double _TodoDeposito;
        private double _Gananciadeldia;
        private double _TotalEntregado;
        private double _SaldoSiguiente;
        private double _TotalFactura;
        private double _TotalBoleta;
        private double _TotalNotaVenta;
        private double _TotalCreditoCobrado;
        private double _TotalCreditoEmitido;
        private string _Estado_Cierre;

        public string Id_cierre { get => _Id_cierre; set => _Id_cierre = value; }
        public DateTime Fecha_Cierre { get => _Fecha_Cierre; set => _Fecha_Cierre = value; }
        public double Apertura_Caja { get => _Apertura_Caja; set => _Apertura_Caja = value; }
        public double Total_Ingreso { get => _Total_Ingreso; set => _Total_Ingreso = value; }
        public double TotalEgreso { get => _TotalEgreso; set => _TotalEgreso = value; }
        public int Id_Usu { get => _Id_Usu; set => _Id_Usu = value; }
        public double TodoDeposito { get => _TodoDeposito; set => _TodoDeposito = value; }
        public double Gananciadeldia { get => _Gananciadeldia; set => _Gananciadeldia = value; }
        public double TotalEntregado { get => _TotalEntregado; set => _TotalEntregado = value; }
        public double SaldoSiguiente { get => _SaldoSiguiente; set => _SaldoSiguiente = value; }
        public double TotalFactura { get => _TotalFactura; set => _TotalFactura = value; }
        public double TotalBoleta { get => _TotalBoleta; set => _TotalBoleta = value; }
        public double TotalNotaVenta { get => _TotalNotaVenta; set => _TotalNotaVenta = value; }
        public double TotalCreditoCobrado { get => _TotalCreditoCobrado; set => _TotalCreditoCobrado = value; }
        public double TotalCreditoEmitido { get => _TotalCreditoEmitido; set => _TotalCreditoEmitido = value; }
        public string Estado_Cierre { get => _Estado_Cierre; set => _Estado_Cierre = value; }
    }
}
