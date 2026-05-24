using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        private string _idcliente;
        private string _nombre;
        private string _dniruc;
        private string _direccion;
        private string _telefono;
        private string _email;
        private DateTime _fechaAniver;

        public string Idcliente { get => _idcliente; set => _idcliente = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Dniruc { get => _dniruc; set => _dniruc = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Email { get => _email; set => _email = value; }
        public DateTime FechaAniver { get => _fechaAniver; set => _fechaAniver = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
    }
}
