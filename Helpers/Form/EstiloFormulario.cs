using System.ComponentModel;
using System.Globalization;
using Visual.Constantes.Forms;

namespace Visual.Helpers.Form
{
    public static class EstiloGlobal
    {
        private static readonly Color CorTexto = FormsConstantes.CorPadraoFonte;
        private static readonly Color CorFundo = Color.White;
        private static readonly Color CorHover = Color.FromArgb(200, 200, 200);
        private static readonly Color CorClique = Color.FromArgb(160, 160, 160);
        private static readonly Font FontePadrao = new Font("Arial", 9F, FontStyle.Regular);

        public static void AplicarEstilo(Control root, bool isPDV = false)
        {
            var fonteAtual = isPDV ? new Font("Arial", 10F, FontStyle.Regular) : FontePadrao;

            if (root is System.Windows.Forms.Form formulario)
            {
                AplicarEstiloFormulario(formulario, fonteAtual);
                FormHelper.AplicarFormatacaoMonetaria(formulario);
                formulario.KeyPreview = true;
                formulario.KeyDown += Formulario_KeyDown;
            }

            foreach (Control c in root.Controls)
            {
                switch (c)
                {
                    case Button btn:
                        AplicarEstiloBotao(btn, fonteAtual);
                        break;
                    case TextBox txt:
                        AplicarEstiloTextBox(txt, fonteAtual);
                        break;
                    case ComboBox cb:
                        AplicarEstiloComboBox(cb, fonteAtual);
                        break;
                    case Label lbl:
                        AplicarEstiloLabel(lbl, fonteAtual);
                        break;
                    case MaskedTextBox msk:
                        AplicarEstiloMaskedTextBox(msk, fonteAtual);
                        break;
                    case DateTimePicker dtp:
                        AplicarEstiloDateTimePicker(dtp, fonteAtual);
                        break;
                }

                if (c.HasChildren)
                    AplicarEstilo(c, isPDV);
            }
        }

        private static void AplicarEstiloFormulario(System.Windows.Forms.Form formulario, Font fonte)
        {
            formulario.FormBorderStyle = FormBorderStyle.FixedSingle;
            formulario.MaximizeBox = false;
            formulario.MinimizeBox = false;
            formulario.ShowIcon = false;
            formulario.ShowInTaskbar = false;
            formulario.Font = fonte;
        }

        private static void AplicarEstiloBotao(Button btn, Font fonte)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = CorHover;
            btn.FlatAppearance.MouseDownBackColor = CorClique;
            btn.BackColor = CorFundo;
            btn.ForeColor = CorTexto;
            btn.Font = fonte;
        }

        private static void AplicarEstiloTextBox(TextBox txt, Font fonte)
        {            
            txt.BackColor = CorFundo;
            txt.ForeColor = CorTexto;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = fonte;
            if (txt.Tag == null)
            {
                txt.MaxLength = 130;
            }

            txt.CharacterCasing = CharacterCasing.Upper;
        }

        private static void AplicarEstiloComboBox(ComboBox cb, Font fonte)
        {
            cb.BackColor = CorFundo;
            cb.ForeColor = CorTexto;
            cb.FlatStyle = FlatStyle.Flat;
            cb.Font = fonte;
        }

        private static void AplicarEstiloLabel(Label lbl, Font fonte)
        {
            lbl.ForeColor = CorTexto;
            lbl.Font = fonte;
        }

        private static void AplicarEstiloDateTimePicker(DateTimePicker dtp, Font fonte)
        {
            dtp.CalendarForeColor = CorTexto;
            dtp.CalendarMonthBackground = CorFundo;
            dtp.CalendarTitleBackColor = CorHover;
            dtp.CalendarTitleForeColor = CorTexto;
            dtp.CalendarTrailingForeColor = Color.Gray;
            dtp.Font = fonte;
            dtp.ForeColor = CorTexto;
            dtp.BackColor = CorFundo;
            dtp.Format = DateTimePickerFormat.Short;
        }

        private static void AplicarEstiloMaskedTextBox(MaskedTextBox msk, Font fonte)
        {
            msk.BackColor = CorFundo;
            msk.ForeColor = CorTexto;
            msk.BorderStyle = BorderStyle.FixedSingle;
            msk.Font = fonte;
            msk.PromptChar = '_';

            if (msk.Tag is not string tag)
                return;

            string tagUpper = tag.ToUpperInvariant();
            string numeros = new string(msk.Text.Where(char.IsDigit).ToArray());

            switch (tagUpper)
            {
                case "CPF":
                    msk.Mask = "000.000.000-00";
                    msk.Culture = new CultureInfo("en-US");
                    var providerCpf = new MaskedTextProvider(msk.Mask, msk.Culture);
                    providerCpf.Set(numeros);
                    msk.Text = providerCpf.ToDisplayString();
                    break;

                case "CNPJ":
                    msk.Mask = "00.000.000/0000-00";
                    msk.Culture = new CultureInfo("en-US");
                    var providerCnpj = new MaskedTextProvider(msk.Mask, msk.Culture);
                    providerCnpj.Set(numeros);
                    msk.Text = providerCnpj.ToDisplayString();
                    break;
            }
        }

        private static void Formulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender is not System.Windows.Forms.Form formulario) return;

                var controleFocado = formulario.ActiveControl;

                if (controleFocado?.Tag?.ToString().ToUpperInvariant() == "PERSONALIZADO")
                    return;

                var proximoControle = formulario.GetNextControl(controleFocado, true);
                proximoControle?.Focus();
                e.SuppressKeyPress = true;
            }
        }
    }
}
