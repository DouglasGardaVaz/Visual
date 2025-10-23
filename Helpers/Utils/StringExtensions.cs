using System.Text.RegularExpressions;

namespace Dados.Helpers.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// Remove todos os caracteres que não sejam dígitos de uma string.
        /// </summary>
        public static string SomenteNumeros(this string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return string.Empty;

            return Regex.Replace(valor, "[^0-9]", "");
        }
    }
}
