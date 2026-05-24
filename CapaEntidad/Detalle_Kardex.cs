using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Kardex
    {
        private string _idKardex;
        private int _item;
        private string _doc_soporte;
        private string _Det_Operacion;
        private double _cantidad_In;
        private double _precio_In;
        private double _total_In;

        private double _cantidad_Out;
        private double _Precio_Out;
        private double _Total_Out;

        private double _cantidad_saldo;
        private double _Promedio;
        private double _Total_saldo;

        private int _idusu;
        private string _tipo_operacion;

        private string _cant_diferencial;
        private Double _importeDiferente;

        public string IdKardex { get => _idKardex; set => _idKardex = value; }
        public int Item { get => _item; set => _item = value; }
        public string Doc_soporte { get => _doc_soporte; set => _doc_soporte = value; }
        public string Det_Operacion { get => _Det_Operacion; set => _Det_Operacion = value; }
        public double Cantidad_In { get => _cantidad_In; set => _cantidad_In = value; }
        public double Precio_In { get => _precio_In; set => _precio_In = value; }
        public double Total_In { get => _total_In; set => _total_In = value; }
        public double Cantidad_Out { get => _cantidad_Out; set => _cantidad_Out = value; }
        public double Precio_Out { get => _Precio_Out; set => _Precio_Out = value; }
        public double Total_Out { get => _Total_Out; set => _Total_Out = value; }
        public double Cantidad_saldo { get => _cantidad_saldo; set => _cantidad_saldo = value; }
        public double Promedio { get => _Promedio; set => _Promedio = value; }
        public double Total_saldo { get => _Total_saldo; set => _Total_saldo = value; }
        public string Tipo_operacion { get => _tipo_operacion; set => _tipo_operacion = value; }
        public int Idusu { get => _idusu; set => _idusu = value; }
        public string Cant_diferencial { get => _cant_diferencial; set => _cant_diferencial = value; }
        public double ImporteDiferente { get => _importeDiferente; set => _importeDiferente = value; }
    }
}
