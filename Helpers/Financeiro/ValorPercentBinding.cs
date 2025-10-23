using System.Globalization;
using Dados.Helpers.Form.Helper;      // Tb_KeyPressMonetario

namespace Dados.Helpers.Financeiro
{
    /// <summary>
    /// Faz o vínculo entre dois TextBoxes (Valor e Percentual).
    /// - Calcula sempre sobre um SUBTOTAL fornecido (Func<decimal>).
    /// - Só recalcula quando o usuário alterar (dirty).
    /// - Suporta validadores opcionais para Valor e Percentual.
    /// - Suporta "beforeApply" para vetar a alteração ANTES de aplicá-la (e reverter).
    /// </summary>
    public sealed class ValorPercentBinding : IDisposable
    {
        private readonly TextBox _txtValor;
        private readonly TextBox _txtPercent;
        private readonly Func<decimal> _getSubtotal;
        private readonly Action _onChanged;
        private readonly Func<decimal, decimal, bool>? _validateValue;    // (valor, subtotal) => ok?
        private readonly Func<decimal, decimal, bool>? _validatePercent;  // (percent, subtotal) => ok?
        private readonly Func<decimal, decimal, decimal, bool>? _beforeApply; // (subtotal, valor, percent) => ok?

        private readonly CultureInfo _pt = new("pt-BR");

        private bool _updating;
        private bool _dirtyValor;
        private bool _dirtyPercent;

        // Snapshot do último estado válido para reverter rapidamente
        private string _lastValidValorText = "0,00";
        private string _lastValidPercentText = "0,00";

        /// <summary>
        /// Cria e conecta o binding.
        /// </summary>
        public static ValorPercentBinding Attach(
            TextBox txtValor,
            TextBox txtPercentual,
            Func<decimal> getSubtotal,
            Action onChanged,
            int maxLenValor = 10,
            int maxLenPercent = 6,
            bool hookKeyPressMonetario = true,
            Func<decimal, decimal, bool>? validateValue = null,
            Func<decimal, decimal, bool>? validatePercent = null,
            Func<decimal, decimal, decimal, bool>? beforeApply = null)
        {
            return new ValorPercentBinding(
                txtValor,
                txtPercentual,
                getSubtotal,
                onChanged,
                maxLenValor,
                maxLenPercent,
                hookKeyPressMonetario,
                validateValue,
                validatePercent,
                beforeApply
            );
        }

        private ValorPercentBinding(
            TextBox txtValor,
            TextBox txtPercentual,
            Func<decimal> getSubtotal,
            Action onChanged,
            int maxLenValor,
            int maxLenPercent,
            bool hookKeyPressMonetario,
            Func<decimal, decimal, bool>? validateValue,
            Func<decimal, decimal, bool>? validatePercent,
            Func<decimal, decimal, decimal, bool>? beforeApply)
        {
            _txtValor = txtValor ?? throw new ArgumentNullException(nameof(txtValor));
            _txtPercent = txtPercentual ?? throw new ArgumentNullException(nameof(txtPercentual));
            _getSubtotal = getSubtotal ?? throw new ArgumentNullException(nameof(getSubtotal));
            _onChanged = onChanged ?? (() => { });
            _validateValue = validateValue;
            _validatePercent = validatePercent;
            _beforeApply = beforeApply;

            // Máscara e limites
            _txtValor.MaxLength = maxLenValor;
            _txtPercent.MaxLength = maxLenPercent;

            if (hookKeyPressMonetario)
            {
                _txtValor.KeyPress -= FormHelper.Tb_KeyPressMonetario;
                _txtValor.KeyPress += FormHelper.Tb_KeyPressMonetario;
                _txtPercent.KeyPress -= FormHelper.Tb_KeyPressMonetario;
                _txtPercent.KeyPress += FormHelper.Tb_KeyPressMonetario;
            }

            // Normaliza textos atuais e define snapshot inicial
            _lastValidValorText = MoneyTextHelper.F2(MoneyTextHelper.Parse(_txtValor.Text, _pt), _pt);
            _lastValidPercentText = MoneyTextHelper.F2(MoneyTextHelper.Parse(_txtPercent.Text, _pt), _pt);
            _txtValor.Text = _lastValidValorText;
            _txtPercent.Text = _lastValidPercentText;

            // Dirty flags
            _txtValor.Enter += OnValorEnter;
            _txtValor.TextChanged += OnValorTextChanged;
            _txtValor.Validated += OnValorValidated;

            _txtPercent.Enter += OnPercentEnter;
            _txtPercent.TextChanged += OnPercentTextChanged;
            _txtPercent.Validated += OnPercentValidated;
        }

        // --------- Eventos locais ---------
        private void OnValorEnter(object? s, EventArgs e) => _dirtyValor = false;
        private void OnValorTextChanged(object? s, EventArgs e) { if (!_updating) _dirtyValor = true; }
        private void OnPercentEnter(object? s, EventArgs e) => _dirtyPercent = false;
        private void OnPercentTextChanged(object? s, EventArgs e) { if (!_updating) _dirtyPercent = true; }

        private void OnValorValidated(object? sender, EventArgs e)
        {
            if (!_dirtyValor) return;

            var subtotal = Math.Max(0m, _getSubtotal());
            var val = MoneyTextHelper.Parse(_txtValor.Text, _pt);
            if (val < 0) val = 0;

            // Validação específica (ex.: valor desconto <= subtotal, etc.)
            if (_validateValue != null && !_validateValue(val, subtotal))
            {
                ReverterParaUltimoValido();
                _dirtyValor = false;
                return;
            }

            var perc = subtotal == 0 ? 0 : (val / subtotal) * 100m;

            // Veto antes de aplicar (ex.: impedir alteração que invalide regra cruzada)
            if (_beforeApply != null && !_beforeApply(subtotal, val, perc))
            {
                ReverterParaUltimoValido();
                _dirtyValor = false;
                return;
            }

            Aplicar(val, perc);
            _dirtyValor = false;
        }

        private void OnPercentValidated(object? sender, EventArgs e)
        {
            if (!_dirtyPercent) return;

            var subtotal = Math.Max(0m, _getSubtotal());
            var perc = MoneyTextHelper.Parse(_txtPercent.Text, _pt);
            if (perc < 0) perc = 0;

            // Validação específica (ex.: % desconto <= 100, etc.)
            if (_validatePercent != null && !_validatePercent(perc, subtotal))
            {
                ReverterParaUltimoValido();
                _dirtyPercent = false;
                return;
            }

            var val = (subtotal * perc) / 100m;

            // Veto antes de aplicar
            if (_beforeApply != null && !_beforeApply(subtotal, val, perc))
            {
                ReverterParaUltimoValido();
                _dirtyPercent = false;
                return;
            }

            Aplicar(val, perc);
            _dirtyPercent = false;
        }

        // --------- Operações internas ---------
        private void Aplicar(decimal valor, decimal percent)
        {
            _updating = true;
            try
            {
                var valTxt = MoneyTextHelper.F2(valor, _pt);
                var perTxt = MoneyTextHelper.F2(percent, _pt);

                _txtValor.Text = valTxt;
                _txtPercent.Text = perTxt;

                _lastValidValorText = valTxt;
                _lastValidPercentText = perTxt;

                _onChanged?.Invoke();
            }
            finally
            {
                _updating = false;
            }
        }

        private void ReverterParaUltimoValido()
        {
            _updating = true;
            try
            {
                _txtValor.Text = _lastValidValorText;
                _txtPercent.Text = _lastValidPercentText;
            }
            finally
            {
                _updating = false;
            }
        }

        /// <summary>Permite reverter manualmente para o último estado válido.</summary>
        public void RevertToLastValid() => ReverterParaUltimoValido();

        // --------- Disposable ---------
        public void Dispose()
        {
            _txtValor.Enter -= OnValorEnter;
            _txtValor.TextChanged -= OnValorTextChanged;
            _txtValor.Validated -= OnValorValidated;

            _txtPercent.Enter -= OnPercentEnter;
            _txtPercent.TextChanged -= OnPercentTextChanged;
            _txtPercent.Validated -= OnPercentValidated;
        }
    }
}
