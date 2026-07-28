using System;
using System.Security.Cryptography;
using System.Text;

namespace CapaDatos
{
    internal static class ProtectorSecretos
    {
        private const string Prefijo = "DPAPI:";
        private static readonly byte[] Entropia =
            Encoding.UTF8.GetBytes("SistemaBotica.Elicler.Credenciales.v1");

        public static string Proteger(string valor)
        {
            if (String.IsNullOrEmpty(valor))
                return String.Empty;

            if (valor.StartsWith(Prefijo, StringComparison.Ordinal))
                return valor;

            byte[] plano = Encoding.UTF8.GetBytes(valor);
            byte[] protegido = ProtectedData.Protect(
                plano,
                Entropia,
                DataProtectionScope.CurrentUser);
            return Prefijo + Convert.ToBase64String(protegido);
        }

        public static string Desproteger(string valor)
        {
            if (String.IsNullOrEmpty(valor))
                return String.Empty;

            if (!valor.StartsWith(Prefijo, StringComparison.Ordinal))
                return valor;

            try
            {
                byte[] protegido = Convert.FromBase64String(
                    valor.Substring(Prefijo.Length));
                byte[] plano = ProtectedData.Unprotect(
                    protegido,
                    Entropia,
                    DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(plano);
            }
            catch (CryptographicException)
            {
                throw new InvalidOperationException(
                    "Las credenciales fueron protegidas por otro usuario de Windows. " +
                    "Vuelva a ingresarlas.");
            }
        }
    }
}
