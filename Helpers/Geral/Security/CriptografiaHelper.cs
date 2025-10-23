using BCrypt.Net;

namespace Dados.Helpers.Security
{
    public static class CriptografiaHelper
    {
        private const int WorkFactor = 12; // custo, pode ser 10–14

        /// <summary>
        /// Gera um hash BCrypt (salt embutido).
        /// </summary>
        public static string GerarHash(string senhaPura)
        {
            return BCrypt.Net.BCrypt.HashPassword(senhaPura, WorkFactor);
        }

        /// <summary>
        /// Verifica senha digitada contra hash armazenado.
        /// </summary>
        public static bool VerificarSenha(string senhaDigitada, string hashArmazenado)
        {
            return BCrypt.Net.BCrypt.Verify(senhaDigitada, hashArmazenado);
        }
    }
}
