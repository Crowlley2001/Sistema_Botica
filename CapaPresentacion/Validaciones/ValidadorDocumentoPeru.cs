using System.Linq;

namespace CapaPresentacion
{
    internal static class ValidadorDocumentoPeru
    {
        public static bool EsRucValido(string valor)
        {
            string ruc = SoloDigitos(valor);
            if (ruc.Length != 11 || ruc.All(c => c == ruc[0]))
                return false;

            int[] pesos = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int suma = 0;
            for (int i = 0; i < pesos.Length; i++)
                suma += (ruc[i] - '0') * pesos[i];

            int digito = 11 - (suma % 11);
            if (digito == 10)
                digito = 0;
            else if (digito == 11)
                digito = 1;

            return digito == ruc[10] - '0';
        }

        public static bool EsDniValido(string valor)
        {
            string dni = SoloDigitos(valor);
            return dni.Length == 8 && !dni.All(c => c == dni[0]);
        }

        private static string SoloDigitos(string valor)
        {
            return new string((valor ?? string.Empty).Where(char.IsDigit).ToArray());
        }
    }
}
