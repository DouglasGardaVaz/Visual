using Dados.Data;
using Dados.Enums.Financeiro.Caixa;
using Dados.Enums.Financeiro.Pagar;
using Dados.Model.Cadastro;
using Dados.Model.Financeiro.Caixa;
using Dados.Model.Financeiro.Pagar;
using Dados.Helpers.Form;

namespace Dados.View.Financeiro.PagarQuitarParcelaFormulario
{
    public partial class PagarQuitarParcelaForm : Form
    {
        private readonly DataContext _context;
        public FinanceiroPagar itemSelecionado { get; set; }
        private string _observacaoParcialQuitacao = string.Empty;
        public PagarQuitarParcelaForm(DataContext context)
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
            _context = context;
        }

        private void CarregarCombosFinanceiros()
        {
            cmbDestino.PreencherComboComDbSet<CentroCusto>(_context, x => x.Descricao, x => x.Id);
            cmbPlanoConta.PreencherComboComDbSet<PlanoConta>(_context, x => x.Descricao, x => x.Id);
            cmbEspecie.PreencherComboComDbSet<Especie>(_context, x => x.Descricao, x => x.Id);
        }

        private void AjustarComponentesVisuais()
        {
            lblTotal.Font = new Font(lblTotal.Font.FontFamily, 12, FontStyle.Bold);

            txtValorPago.Font = new Font(txtValorPago.Font.FontFamily, 16, FontStyle.Bold);

        }

        private void CarregarCampos()
        {
            if (itemSelecionado == null)
            {
                return;
            }
            dtVencimento.Value = itemSelecionado.DataVencimento;
            txtValorOriginal.Text = itemSelecionado.ValorParcela.ToString("N2");
            txtValoraSerPago.Text = itemSelecionado.ValorParcela.ToString("N2");

            if (itemSelecionado.Detalhe != null)
            {
                cmbDestino.SelectedValue = itemSelecionado.Detalhe.CentroCustoId ?? -1;
                cmbPlanoConta.SelectedValue = itemSelecionado.Detalhe.PlanoContaId ?? -1;
                cmbEspecie.SelectedValue = itemSelecionado.Detalhe.EspecieId ?? -1;
            }
        }
        private decimal CalcularValor(decimal baseValor, decimal valor, TipoValorAplicadoPagar tipo)
        {
            return tipo == TipoValorAplicadoPagar.Percentual
                ? Math.Round(baseValor * valor / 100, 2)
                : valor;
        }

        private void AtualizarValorASerPago()
        {
            decimal valorBase = itemSelecionado.ValorParcela;

            // Pega valores da tela ou do banco se não for editável
            decimal.TryParse(txtValorDesconto.Text, out var desconto);
            decimal.TryParse(txtValorAcrescimo.Text, out var acrescimo);
            decimal.TryParse(txtValorPago.Text, out var valorPago);
            decimal.TryParse("0", out var multa);
            decimal.TryParse("0", out var juro);
            decimal.TryParse("0", out var taxaCartao);

            // Pega tipos (por enquanto exemplo fixo, depois você pode usar comboboxes na UI)
            var tipoDesconto = TipoValorAplicadoPagar.Fixo;
            var tipoAcrescimo = TipoValorAplicadoPagar.Fixo;
            var tipoMulta = TipoValorAplicadoPagar.Fixo;
            var tipoJuro = TipoValorAplicadoPagar.Fixo;
            var tipoTaxaCartao = TipoValorAplicadoPagar.Fixo;

            // Cálculo com tipo fixo/percentual
            var valorTotal =
                valorBase
                + CalcularValor(valorBase, multa, tipoMulta)
                + CalcularValor(valorBase, juro, tipoJuro)
                + CalcularValor(valorBase, acrescimo, tipoAcrescimo)
                - CalcularValor(valorBase, desconto, tipoDesconto)
                - CalcularValor(valorBase, taxaCartao, tipoTaxaCartao);

            txtValoraSerPago.Text = valorTotal.ToString("N2");

            // diferença
            var diferenca = valorPago - valorTotal;

            if (diferenca < 0)
            {
                lblTotal.Text = $"Valor faltante: {Math.Abs(diferenca):C2}";
                lblTotal.ForeColor = Color.DarkRed;
            }
            else if (diferenca > 0)
            {
                lblTotal.Text = $"Troco: {diferenca:C2}";
                lblTotal.ForeColor = Color.DarkOrange;
            }
            else
            {
                lblTotal.Text = "";
                lblTotal.ForeColor = Color.ForestGreen;
            }
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            ValidarDesconto();
            AtualizarValorASerPago();
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            AtualizarValorASerPago();
        }

        private void ValidarDesconto()
        {
            decimal valorOriginal = itemSelecionado?.ValorParcela ?? 0;
            decimal.TryParse(txtValorDesconto.Text, out var desconto);

            if (desconto >= valorOriginal)
            {
                MensagemHelper.Alerta("O valor do desconto não pode ser maior ou igual ao valor original.");
                txtValorDesconto.Text = "0,00";
                txtValorDesconto.Focus();
            }
        }

        private void AjustarDestino()
        {
            if (rbCentroCusto.Checked)
            {
                cmbDestino.PreencherComboComDbSet<CentroCusto>(_context, x => x.Descricao, x => x.Id);
            }
            else
            {

            }
        }

        private void PagarQuitarParcelaForm_Load(object sender, EventArgs e)
        {
            CarregarCombosFinanceiros();
            CarregarCampos();
            AjustarComponentesVisuais();
            txtValorAcrescimo.TextChanged += (_, _) => AtualizarValorASerPago();
            txtValorDesconto.Leave += txtDesconto_Leave;
            txtValorPago.Leave += txtValorPago_Leave;

        }
        private bool ValidarCamposCadastro()
        {
            if (cmbDestino.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione um centro de custo.");
                cmbDestino.Focus();
                return false;
            }

            if (cmbPlanoConta.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione um plano de conta.");
                cmbPlanoConta.Focus();
                return false;
            }

            if (cmbEspecie.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione uma espécie.");
                cmbEspecie.Focus();
                return false;
            }

            if (!decimal.TryParse(txtValorPago.Text, out var valorPago) || valorPago <= 0)
            {
                MensagemHelper.Alerta("Informe um valor válido e maior que zero.");
                txtValorPago.Focus();
                return false;
            }

            return true;
        }
        private void AtualizarObjetoPagar()
        {
            itemSelecionado.DataPagamento = dtPagamento.Value.ToUniversalTime();
            if (itemSelecionado.DataPagamento.HasValue && itemSelecionado.DataPagamento.Value.Date > itemSelecionado.DataVencimento.Date)
            {
                itemSelecionado.Situacao = SituacaoPagar.PagaComAtraso;
            }
            else
            {
                itemSelecionado.Situacao = SituacaoPagar.Paga;
            }
            decimal.TryParse(txtValorPago.Text, out var valorPago);
            decimal.TryParse(txtValorDesconto.Text, out var desconto);
            decimal.TryParse(txtValorAcrescimo.Text, out var acrescimo);
            decimal.TryParse("0", out var juro);
            decimal.TryParse("0", out var multa);
            decimal.TryParse("0", out var taxaCartao);

            itemSelecionado.Valores ??= new FinanceiroPagarValores();

            itemSelecionado.Valores.ValorPago = valorPago;
            itemSelecionado.Valores.ValorDesconto = desconto;
            itemSelecionado.Valores.ValorAcrescimo = acrescimo;
            itemSelecionado.Valores.ValorJuro = juro;
            itemSelecionado.Valores.ValorMulta = multa;
            itemSelecionado.Valores.ValorTaxaCartao = taxaCartao;

            itemSelecionado.Valores.ValorDescontoTipo = TipoValorAplicadoPagar.Fixo;
            itemSelecionado.Valores.ValorAcrescimoTipo = TipoValorAplicadoPagar.Fixo;
            itemSelecionado.Valores.ValorJuroTipo = TipoValorAplicadoPagar.Fixo;
            itemSelecionado.Valores.ValorMultaTipo = TipoValorAplicadoPagar.Fixo;
            itemSelecionado.Valores.ValorTaxaCartaoTipo = TipoValorAplicadoPagar.Fixo;

            itemSelecionado.Detalhe ??= new FinanceiroPagarDetalheModel();

            itemSelecionado.Detalhe.CentroCustoId = (int)cmbDestino.SelectedValue;
            itemSelecionado.Detalhe.PlanoContaId = (int)cmbPlanoConta.SelectedValue;
            itemSelecionado.Detalhe.EspecieId = (int)cmbEspecie.SelectedValue;
            if (!string.IsNullOrWhiteSpace(_observacaoParcialQuitacao))
            {
                itemSelecionado.Detalhe.Observacao = (itemSelecionado.Detalhe.Observacao ?? "") +
                                                        "\n" + _observacaoParcialQuitacao;
            }

        }

        private void GerarNovaParcelaComDiferenca(decimal diferenca)
        {
            var novaParcela = new FinanceiroPagar
            {
                Descricao = $"Parcela gerada ao quitar parcialmente o documento: {itemSelecionado.Documento}",
                DataVencimento = DateTime.SpecifyKind(itemSelecionado.DataVencimento.Date, DateTimeKind.Utc),
                ValorParcela = diferenca,
                Situacao = SituacaoPagar.Aberta,
                PessoaId = itemSelecionado.PessoaId,
                Documento = itemSelecionado.Documento,
                Detalhe = new FinanceiroPagarDetalheModel
                {
                    CentroCustoId = (int)cmbDestino.SelectedValue,
                    PlanoContaId = (int)cmbPlanoConta.SelectedValue,
                    EspecieId = (int)cmbEspecie.SelectedValue,
                    Observacao = itemSelecionado.Detalhe?.Observacao + $"Gerado automaticamente por diferença da parcela {itemSelecionado.Documento}"

                },
                Valores = new FinanceiroPagarValores
                {
                    ValorDesconto = 0,
                    ValorDescontoTipo = TipoValorAplicadoPagar.Fixo,
                    ValorAcrescimo = 0,
                    ValorAcrescimoTipo = TipoValorAplicadoPagar.Fixo,
                    ValorJuro = 0,
                    ValorJuroTipo = TipoValorAplicadoPagar.Fixo,
                    ValorMulta = 0,
                    ValorMultaTipo = TipoValorAplicadoPagar.Fixo,
                    ValorTaxaCartao = 0,
                    ValorTaxaCartaoTipo = TipoValorAplicadoPagar.Fixo,
                    ValorPago = 0
                }
            };

            _context.FinanceiroPagar.Add(novaParcela);
        }

        private void RegistrarMovimentoCaixa()
        {
            decimal.TryParse(txtValorPago.Text, out var valorPago);
            decimal.TryParse(txtValoraSerPago.Text, out var valorDevido);
            
            var valorParaRegistrar = valorPago > valorDevido ? valorDevido : valorPago;

            var movimentoCaixa = new FinanceiroCaixa
            {
                PessoaId = itemSelecionado.PessoaId,
                Data = DateTime.UtcNow,
                DataHoraCadastro = DateTime.UtcNow,
                Valor = valorParaRegistrar,
                Entrada = false,
                Descricao = $"Pagamento da parcela {itemSelecionado.Documento}",
                Origem = OrigemFinanceiraCaixa.Pagar,
                IdOrigem = itemSelecionado.Id,
                TipoMovimentacao = null,

                Detalhe = new FinanceiroCaixaDetalhe
                {
                    CentroCustoId = (int?)cmbDestino.SelectedValue,
                    PlanoContaId = (int?)cmbPlanoConta.SelectedValue,
                    EspecieId = (int?)cmbEspecie.SelectedValue,
                    Observacao = itemSelecionado.Detalhe?.Observacao
                }
            };

            _context.FinanceiroCaixa.Add(movimentoCaixa);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }
            decimal valorOriginal = itemSelecionado?.ValorParcela ?? 0;
            decimal.TryParse(txtValorAcrescimo.Text, out var acrescimo);
            decimal.TryParse(txtValorDesconto.Text, out var desconto);
            decimal.TryParse(txtValorPago.Text, out var valorPago);
            decimal valorCorrigido = valorOriginal + acrescimo - desconto;

            if (valorPago < decimal.Parse(txtValoraSerPago.Text))
            {
                decimal diferenca = valorCorrigido - valorPago;

                var continuar = MensagemHelper.Confirmar(
                    $"O valor pago ({valorPago:C2}) é menor que o valor total da parcela ({valorCorrigido:C2}).\nDeseja continuar?"
                );

                if (continuar != DialogResult.Yes)
                {
                    DialogResult = DialogResult.None;
                    return;
                }

                var gerarNovaParcela = MensagemHelper.Confirmar($"Deseja gerar uma nova parcela com a diferença de {diferenca:C2}?");
                _observacaoParcialQuitacao = $"Parcela quitada parcialmente em {DateTime.Now:dd/MM/yyyy}. Diferença de {diferenca:C2}.\n";

                if (gerarNovaParcela == DialogResult.Yes)
                {
                    GerarNovaParcelaComDiferenca(diferenca);
                    _observacaoParcialQuitacao += "Nova parcela foi criada para a diferença.";
                }
                else
                {
                    decimal.TryParse(txtValorDesconto.Text, out var descontoAtual);
                    txtValorDesconto.Text = (descontoAtual + diferenca).ToString("N2");
                    _observacaoParcialQuitacao += "Usuário optou por aplicar a diferença como desconto.";
                }
            }
            AtualizarObjetoPagar();
            RegistrarMovimentoCaixa();
            _context.SaveChanges();
        }

        private void rbCentroCusto_CheckedChanged(object sender, EventArgs e)
        {
            AjustarDestino();
        }

        private void rbBanco_CheckedChanged(object sender, EventArgs e)
        {
            AjustarDestino();
        }

        private void PagarQuitarParcelaForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;

                case Keys.F6:
                    btnConfirmar.PerformClick();
                    break;
               
            }
        }
    }
}
