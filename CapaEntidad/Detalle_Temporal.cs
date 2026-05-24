using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Temporal
    {
        private string _codTem;
        private string _CodPro;
        private string _cantidad;
        private string _Producto;
        private string _Pre_Unt;
        private string _ImporteT;

        public string CodTem { get => _codTem; set => _codTem = value; }
        public string CodPro { get => _CodPro; set => _CodPro = value; }
        public string Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Producto { get => _Producto; set => _Producto = value; }
        public string Pre_Unt { get => _Pre_Unt; set => _Pre_Unt = value; }
        public string ImporteT { get => _ImporteT; set => _ImporteT = value; }
    }
}
