using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Helpers.Utils
{
    public static class FormatoValores
    {
        public static void FormatarCampoMonetario(this TextBox textBox, int casasDecimais = 2)
        {
            textBox.Leave += (s, e) =>
            {
                if (!decimal.TryParse(textBox.Text, out var valor))
                    valor = 0;

                string formato = casasDecimais == 4 ? "N4" : "N2";
                textBox.Text = valor.ToString(formato, CultureInfo.CurrentCulture);
            };

            textBox.TextAlign = HorizontalAlignment.Right;
            textBox.MaxLength = 9;
        }
    }
}
