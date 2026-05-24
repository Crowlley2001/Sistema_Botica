using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Credito
    {
        private int _Id_DetCred;
        private string _IdNotaCred;
        private double _A_cuenta;
        private double _Saldo_Actual;
        private DateTime _Fecha_Pago;
        private string _TipoPago;
        private string _Nro_Opera_Coment;
        private int _Id_Usu;

        public int Id_DetCred { get => _Id_DetCred; set => _Id_DetCred = value; }
        public string IdNotaCred { get => _IdNotaCred; set => _IdNotaCred = value; }
        public double A_cuenta { get => _A_cuenta; set => _A_cuenta = value; }
        public double Saldo_Actual { get => _Saldo_Actual; set => _Saldo_Actual = value; }
        public DateTime Fecha_Pago { get => _Fecha_Pago; set => _Fecha_Pago = value; }
        public string TipoPago { get => _TipoPago; set => _TipoPago = value; }
        public string Nro_Opera_Coment { get => _Nro_Opera_Coment; set => _Nro_Opera_Coment = value; }
        public int Id_Usu { get => _Id_Usu; set => _Id_Usu = value; }
    }
}
