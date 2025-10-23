using Dados.Enums.Cadastro;

namespace Dados.Helpers.Geral
{
    public static class CodigoBarrasHelper
    {
        public static string GerarCodigoBarras(TipoCodigoBarras tipo = TipoCodigoBarras.EAN13, string prefixo = "789")
        {
            return tipo switch
            {
                TipoCodigoBarras.EAN13 => GerarEAN13(prefixo),
                TipoCodigoBarras.EAN8 => GerarEAN8(prefixo),
                TipoCodigoBarras.Code128 => GerarCode128(prefixo),
                _ => throw new ArgumentException("Tipo de código de barras não suportado.")
            };
        }

        private static string GerarEAN13(string prefixo)
        {
            prefixo = FiltrarNumeros(prefixo);
            var randomSufixo = Random.Shared.Next(0, 99999).ToString("D5");
            var baseCodigo = (prefixo + randomSufixo).PadRight(12, '0').Substring(0, 12);
            var digito = CalcularDigitoEAN13(baseCodigo);
            return baseCodigo + digito;
        }

        private static string GerarEAN8(string prefixo)
        {
            prefixo = FiltrarNumeros(prefixo);
            var sufixo = Random.Shared.Next(0, 999).ToString("D3");
            var baseCodigo = (prefixo + sufixo).PadRight(7, '0').Substring(0, 7);
            var digito = CalcularDigitoEAN8(baseCodigo);
            return baseCodigo + digito;
        }

        private static string GerarCode128(string prefixo)
        {
            var randomPart = Random.Shared.Next(100000, 999999).ToString();
            return $"{prefixo.ToUpperInvariant()}{randomPart}";
        }

        private static string FiltrarNumeros(string input) => new string(input.Where(char.IsDigit).ToArray());

        private static int CalcularDigitoEAN13(string codigo12)
        {
            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                int digito = int.Parse(codigo12[i].ToString());
                soma += (i % 2 == 0) ? digito : digito * 3;
            }
            int resto = soma % 10;
            return (10 - resto) % 10;
        }

        private static int CalcularDigitoEAN8(string codigo7)
        {
            int soma = 0;
            for (int i = 0; i < 7; i++)
            {
                int digito = int.Parse(codigo7[i].ToString());
                soma += (i % 2 == 0) ? digito * 3 : digito;
            }
            int resto = soma % 10;
            return (10 - resto) % 10;
        }
    }
}
