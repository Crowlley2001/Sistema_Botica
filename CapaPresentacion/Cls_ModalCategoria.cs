using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    //----------------------------- METODO PARA MOVERFORMULARIO PARA EL mdCategoria--------------------------------//
    public class Cls_ModalCategoria
    {
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void MoverFormulario(System.Windows.Forms.Form frm)
        {
            ReleaseCapture();
            SendMessage(frm.Handle, 0x112, 0xf012, 0);
        }


        //----------------------------- METODO PARA VALIDAR SOLO LETRAS--------------------------------//
        public int Solo_Letras(int Teclas)
        {
            switch (Teclas)
            {
                case 65:
                case 66:
                case 67:
                case 68:
                case 69:
                case 70:
                case 71:
                case 72:
                case 73:
                case 74:
                case 75:
                case 76:
                case 77:
                case 78:
                case 79:
                case 80:
                case 81:
                case 82:
                case 83:
                case 84:
                case 85:
                case 86:
                case 87:
                case 88:
                case 89:
                case 90: // A-Z

                case 97:
                case 98:
                case 99:
                case 100:
                case 101:
                case 102:
                case 103:
                case 104:
                case 105:
                case 106:
                case 107:
                case 108:
                case 109:
                case 110:
                case 111:
                case 112:
                case 113:
                case 114:
                case 115:
                case 116:
                case 117:
                case 118:
                case 119:
                case 120:
                case 121:
                case 122: // a-z

                case 32: // ESPACIO
                case 13: // ENTER
                case 8:  // RETROCESO
                    return Teclas;

                default:
                    MessageBox.Show("Solo se permiten Letras", "Validación de Datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
            return Teclas = 0;
        }


        //----------------------------- METODO PARA VALIDAR SOLO NUMEROS--------------------------------//
        public int Solo_Numeros(int Teclas)
        {
            switch (Teclas)
            {
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:

                case 13:
                case 8: // TECLA RETROCESO
                    return Teclas;

                default:
                    MessageBox.Show("Solo se permiten Números", "Validación de Datos",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
            return Teclas = 0;
        }

        //----------------------------- METODO PARA VALIDAR SOLO NUMEROS ENTEROS--------------------------------//
        public int Solo_NumeroEnteros(int TECLAS)
        {
            switch (TECLAS)
            {
                case 48:
                case 49:
                case 50:
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                case 56:
                case 57:

                case 13:
                case 8: //TECLA DE RETROCESO
                    return TECLAS;
                default:

                    MessageBox.Show("Solo se permiten Numeros Enteros [0-9]", "Validacion de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
            return TECLAS = 0;
        }

        //----------------------------- VARIABLES PARA DATOS USUARIOS INICIO --------------------------------//
        //Variables
        private static int _idUsu;
        private static string _nombre;
        private static string _apellido;
        private static string _foto;
        private static string _idrol;
        private static string _nomerol;

        public static int IdUsu { get => _idUsu; set => _idUsu = value; }
        public static string Nombre { get => _nombre; set => _nombre = value; }
        public static string Apellido { get => _apellido; set => _apellido = value; }
        public static string Foto { get => _foto; set => _foto = value; }
        public static string Idrol { get => _idrol; set => _idrol = value; }
        public static string Nomerol { get => _nomerol; set => _nomerol = value; }
    }
}








