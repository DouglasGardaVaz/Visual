using Visual.Helpers.Form;

namespace Visual.View.Saida.PDV.DescontoAcrescimoItemFormulario
{
    public partial class DescontoAcrescimoItemForm : Form
    {
        public enum AbaInicial
        {
            Desconto,
            Acrescimo
        }

        private readonly AbaInicial _abaInicial;
        private readonly decimal _valorOriginal;
        private readonly decimal _descontoAtual;
        private readonly decimal _acrescimoAtual;

        public decimal ValorDesconto { get; private set; }
        public decimal ValorAcrescimo { get; private set; }

        public DescontoAcrescimoItemForm(
            AbaInicial abaInicial,
            decimal valorOriginal,
            decimal descontoAtual = 0,
            decimal acrescimoAtual = 0)
        {
            InitializeComponent();

            _abaInicial = abaInicial;
            _valorOriginal = valorOriginal;
            _descontoAtual = descontoAtual;
            _acrescimoAtual = acrescimoAtual;

            Shown += DescontoAcrescimoItemForm_Shown;
        }

        private void InicializarPercentuais()
        {
            if (_valorOriginal <= 0) return;

            if (_descontoAtual > 0)
            {
                var percentualDesconto = (_descontoAtual / _valorOriginal) * 100;
                txtValorDescontoPercentual.Text = percentualDesconto.ToString("N2");
            }

            if (_acrescimoAtual > 0)
            {
                var percentualAcrescimo = (_acrescimoAtual / _valorOriginal) * 100;
                txtValorAcrescimoPercentual.Text = percentualAcrescimo.ToString("N2");
            }
        }

        private void DescontoAcrescimoItemForm_Shown(object sender, EventArgs e)
        {
            txtValorTotalDesconto.Text = _valorOriginal.ToString("N2");
            txtValorTotalAcrescimo.Text = _valorOriginal.ToString("N2");

            txtValorDesconto.Text = _descontoAtual.ToString("N2");
            txtValorAcrescimo.Text = _acrescimoAtual.ToString("N2");

            InicializarPercentuais();
            AtualizarValorTotal();

            // Ajusta visual conforme aba inicial
            switch (_abaInicial)
            {
                case AbaInicial.Desconto:
                    tbGeral.TabPages.Remove(tbAcrescimo);
                    tbGeral.SelectedTab = tbDesconto;
                    this.Text = "Desconto no item";
                    txtValorDesconto.Focus();
                    break;

                case AbaInicial.Acrescimo:
                    tbGeral.TabPages.Remove(tbDesconto);
                    tbGeral.SelectedTab = tbAcrescimo;
                    this.Text = "Acréscimo no item";
                    txtValorAcrescimo.Focus();
                    break;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            decimal.TryParse(txtValorDesconto.Text, out var desconto);
            decimal.TryParse(txtValorAcrescimo.Text, out var acrescimo);

            ValorDesconto = desconto;
            ValorAcrescimo = acrescimo;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            txtValorDesconto.Leave += TxtValorDesconto_Leave;
            txtValorDescontoPercentual.Leave += TxtValorDescontoPercentual_Leave;

            txtValorAcrescimo.Leave += TxtValorAcrescimo_Leave;
            txtValorAcrescimoPercentual.Leave += TxtValorAcrescimoPercentual_Leave;

            txtValorTotalAcrescimo.Font = new Font("Arial", 11, FontStyle.Bold);
            txtValorTotalDesconto.Font = new Font("Arial", 11, FontStyle.Bold);

        }
        private void AtualizarValorTotal()
        {
            if (_abaInicial == AbaInicial.Desconto)
            {
                if (decimal.TryParse(txtValorDesconto.Text, out var desconto))
                {
                    var total = _valorOriginal - desconto;
                    txtValorTotalDesconto.Text = total.ToString("N2");
                }
            }
            else if (_abaInicial == AbaInicial.Acrescimo)
            {
                if (decimal.TryParse(txtValorAcrescimo.Text, out var acrescimo))
                {
                    var total = _valorOriginal + acrescimo;
                    txtValorTotalAcrescimo.Text = total.ToString("N2");
                }
            }
        }

        private void TxtValorDesconto_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValorDesconto.Text, out var valor))
            {
                if (valor >= _valorOriginal)
                {
                    MensagemHelper.Alerta("O valor de desconto não pode ser maior ou igual ao valor do item.");
                    txtValorDesconto.Text = "0,00";
                    txtValorDesconto.Focus();
                    return;
                }

                var percentual = (_valorOriginal > 0) ? (valor / _valorOriginal) * 100 : 0;
                txtValorDescontoPercentual.Text = percentual.ToString("N2");
            }

            AtualizarValorTotal();
        }


        private void TxtValorDescontoPercentual_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValorDescontoPercentual.Text, out var percentual))
            {
                if (percentual >= 100)
                {
                    MensagemHelper.Alerta("O percentual de desconto não pode ser maior ou igual a 100%.");
                    txtValorDescontoPercentual.Text = "0,00";
                    txtValorDescontoPercentual.Focus();
                    return;
                }

                var valor = (_valorOriginal * percentual) / 100;
                txtValorDesconto.Text = valor.ToString("N2");
            }

            AtualizarValorTotal();
        }


        private void TxtValorAcrescimo_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValorAcrescimo.Text, out var valor) && _valorOriginal > 0)
            {
                var percentual = (valor / _valorOriginal) * 100;
                txtValorAcrescimoPercentual.Text = percentual.ToString("N2");
            }
            AtualizarValorTotal();
        }

        private void TxtValorAcrescimoPercentual_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtValorAcrescimoPercentual.Text, out var percentual) && _valorOriginal > 0)
            {
                var valor = (_valorOriginal * percentual) / 100;
                txtValorAcrescimo.Text = valor.ToString("N2");
            }
            AtualizarValorTotal();
        }

        private void DescontoAcrescimoItemForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
        }

        private void DescontoAcrescimoItemForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btnCancelar.PerformClick();
                    break;

                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;

                case Keys.F6:
                    btnConfirmar.Focus();
                    btnConfirmar.PerformClick();
                    break;

                case Keys.F7:
                    if (tbGeral.SelectedTab == tbDesconto)
                        txtValorDesconto.Focus();
                    else if (tbGeral.SelectedTab == tbAcrescimo)
                        txtValorAcrescimo.Focus();
                    break;

                case Keys.F8:
                    if (tbGeral.SelectedTab == tbDesconto)
                        txtValorDescontoPercentual.Focus();
                    else if (tbGeral.SelectedTab == tbAcrescimo)
                        txtValorAcrescimoPercentual.Focus();
                    break;


            }
        }
    }
}
