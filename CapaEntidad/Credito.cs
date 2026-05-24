using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Credito
    {
        private string _IdNotaCred;
        private string _Id_Doc;
        private DateTime _Fecha_Credito;
        private string _Nom_Cliente;
        private double _Total_Cre;
        private double _Saldo_Pdnte;
        private DateTime _Fecha_Vncimnto;
        private string _Estado_Cred;

        public string IdNotaCred { get => _IdNotaCred; set => _IdNotaCred = value; }
        public string Id_Doc { get => _Id_Doc; set => _Id_Doc = value; }
        public DateTime Fecha_Credito { get => _Fecha_Credito; set => _Fecha_Credito = value; }
        public string Nom_Cliente { get => _Nom_Cliente; set => _Nom_Cliente = value; }
        public double Total_Cre { get => _Total_Cre; set => _Total_Cre = value; }
        public double Saldo_Pdnte { get => _Saldo_Pdnte; set => _Saldo_Pdnte = value; }
        public DateTime Fecha_Vncimnto { get => _Fecha_Vncimnto; set => _Fecha_Vncimnto = value; }
        public string Estado_Cred { get => _Estado_Cred; set => _Estado_Cred = value; }
    }
}
