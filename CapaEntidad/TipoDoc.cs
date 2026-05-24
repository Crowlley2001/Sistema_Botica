using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TipoDoc
    {
        private int _Id_Tipo;
        private string _Documento;
        private string _Serie;
        private string _Numero;
        private string _Estado_TiDoc;

        public int Id_Tipo { get => _Id_Tipo; set => _Id_Tipo = value; }
        public string Documento { get => _Documento; set => _Documento = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Numero { get => _Numero; set => _Numero = value; }
        public string Estado_TiDoc { get => _Estado_TiDoc; set => _Estado_TiDoc = value; }
    }
}
