using System.Globalization;

namespace Dados.Helpers.Financeiro
{
    public static class MoneyTextHelper
    {
        private static readonly CultureInfo _pt = new("pt-BR");

        public static decimal Parse(string? txt, CultureInfo? culture = null)
        {
            if (string.IsNullOrWhiteSpace(txt)) return 0m;

            var ci = culture ?? _pt;
            var s = txt.Trim()
                       .Replace("R$", "", StringComparison.OrdinalIgnoreCase)
                       .Trim();

            // normaliza: remove milhar e força separador decimal da cultura
            s = s.Replace(".", "").Replace(",", ci.NumberFormat.NumberDecimalSeparator);

            decimal.TryParse(s, NumberStyles.Any, ci, out var v);
            return v;
        }

        public static string F2(decimal v, CultureInfo? culture = null)
            => v.ToString("N2", culture ?? _pt);
    }
}
