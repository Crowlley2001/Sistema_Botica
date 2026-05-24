using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuarios
    {
        private int _idusu;
        private string _nombres;
        private string _apellidos;
        private string _usu;
        private string _clave;
        private string _foto;
        private string _fechaNaci;
        private string _idrol;
        private string _correo;

        public int Idusu { get => _idusu; set => _idusu = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string Usu { get => _usu; set => _usu = value; }
        public string Clave { get => _clave; set => _clave = value; }
        public string Foto { get => _foto; set => _foto = value; }
        public string FechaNaci { get => _fechaNaci; set => _fechaNaci = value; }
        public string Idrol { get => _idrol; set => _idrol = value; }
        public string Correo { get => _correo; set => _correo = value; }
    }
}
