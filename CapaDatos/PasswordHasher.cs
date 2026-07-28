using System;
using System.Security.Cryptography;

namespace CapaDatos
{
    internal static class PasswordHasher
    {
        public const int IteracionesPredeterminadas = 100000;
        private const int TamanoSalt = 32;
        private const int TamanoHash = 32;

        public static void Crear(
            string password,
            out byte[] hash,
            out byte[] salt,
            out int iteraciones)
        {
            if (String.IsNullOrEmpty(password))
                throw new ArgumentException("La contraseña no puede estar vacía.");

            salt = new byte[TamanoSalt];
            using (RandomNumberGenerator generador =
                RandomNumberGenerator.Create())
            {
                generador.GetBytes(salt);
            }

            iteraciones = IteracionesPredeterminadas;
            using (Rfc2898DeriveBytes derivador =
                new Rfc2898DeriveBytes(password, salt, iteraciones))
            {
                hash = derivador.GetBytes(TamanoHash);
            }
        }

        public static bool Verificar(
            string password,
            byte[] hashEsperado,
            byte[] salt,
            int iteraciones)
        {
            if (String.IsNullOrEmpty(password) ||
                hashEsperado == null ||
                salt == null ||
                iteraciones <= 0)
                return false;

            byte[] calculado;
            using (Rfc2898DeriveBytes derivador =
                new Rfc2898DeriveBytes(password, salt, iteraciones))
            {
                calculado = derivador.GetBytes(hashEsperado.Length);
            }

            int diferencia = calculado.Length ^ hashEsperado.Length;
            int limite = Math.Min(calculado.Length, hashEsperado.Length);
            for (int i = 0; i < limite; i++)
                diferencia |= calculado[i] ^ hashEsperado[i];

            return diferencia == 0;
        }
    }
}
