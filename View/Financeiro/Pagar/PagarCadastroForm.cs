using Dados.Data;
using Dados.Enums;
using Dados.Enums.Financeiro.Pagar;
using Dados.Enums.Pessoa;
using Dados.Model.Cadastro;
using Dados.Model.Configuracao.Parametros.Financeiro.Pagar;
using Dados.Model.Financeiro.Pagar;
using Microsoft.EntityFrameworkCore;
using Dados.Helpers.Form;
using Dados.View.Financeiro.PagarReplicarParcelaFormulario;
using Dados.View.PessoaSelecaoFormulario;

namespace Dados.View.Financeiro.PagarCadastroFormulario
{
    public partial class PagarCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public FinanceiroPagar itemSelecionado { get; set; }
        public PagarCadastroForm(DataContext context)
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
            _context = context;
        }

        private void CarregarCampos()
        {
            if (itemSelecionado == null)
            {
                return;
            }
            AtualizarNomeFornecedor();
            txtDescricao.Text = itemSelecionado.Descricao;
            txtDocumento.Text = itemSelecionado.Documento;
            txtValor.Text = itemSelecionado.ValorParcela.ToString("N2");
            dtVencimento.Value = itemSelecionado.DataVencimento;
            txtNumeroParcela.Text = itemSelecionado.NumeroParcela.ToString();
            txtQtdeParcela.Text = itemSelecionado.QtdeParcelas.ToString();
           
            if (itemSelecionado.Detalhe != null)
            {
                cmbCentroCusto.SelectedValue = itemSelecionado.Detalhe.CentroCustoId ?? -1;
                cmbPlanoConta.SelectedValue = itemSelecionado.Detalhe.PlanoContaId ?? -1;
                cmbEspecie.SelectedValue = itemSelecionado.Detalhe.EspecieId ?? -1;
                txtObservacao.Text = itemSelecionado.Detalhe.Observacao ?? "";
            }

            if (itemSelecionado.DataPagamento.HasValue)
            {
                dtPagamento.Value = itemSelecionado.DataPagamento.Value;
                txtValorPago.Text = itemSelecionado.Valores?.ValorPago.ToString("N2") ?? "0,00";
                dtPagamento.Visible = true;
                lblPagamento.Visible = true;
                lblValorPago.Visible = true;
                txtValorPago.Visible = true;
            }
            else
            {
                dtPagamento.Visible = false;
                lblPagamento.Visible = false;
                lblValorPago.Visible = false;
                txtValorPago.Visible = false;
            }

            if (Operacao == TipoOperacao.Detalhes)
            {
                txtDescricao.Enabled = false;
                txtDocumento.Enabled = false;
                txtValor.Enabled = false;
                dtVencimento.Enabled = false;
                dtPagamento.Enabled = false;
                cmbCentroCusto.Enabled = false;
                cmbPlanoConta.Enabled = false;
                cmbEspecie.Enabled = false;
                txtQtdeParcela.Enabled = false;
                txtNumeroParcela.Enabled = false;
                txtObservacao.Enabled = false;
                btnCancelar.Visible = false;
                btnGravar.Text = "&Fechar | F6";
            }
        }
        private void InicializarNovoPagar()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                itemSelecionado = new FinanceiroPagar
                {
                    DataVencimento = DateTime.Today,
                    Situacao = SituacaoPagar.Aberta,
                    Origem = OrigemPagar.Pagar
                };
            }
        }
        private void CarregarCombosFinanceiros()
        {
            cmbCentroCusto.PreencherComboComDbSet<CentroCusto>(_context, x => x.Descricao, x => x.Id);
            cmbPlanoConta.PreencherComboComDbSet<PlanoConta>(_context, x => x.Descricao, x => x.Id);
            cmbEspecie.PreencherComboComDbSet<Especie>(_context, x => x.Descricao, x => x.Id);

            if (Operacao == TipoOperacao.Inclusao)
            {
               cmbPlanoConta.SelectedValue = ParametrosPagar.PlanoContaPadrao;
               cmbCentroCusto.SelectedValue = ParametrosPagar.CentroCustoPadrao;
               cmbEspecie.SelectedValue = ParametrosPagar.EspeciePadrao;
            }
        }
        private void AtualizarNomeFornecedor()
        {
            if (itemSelecionado?.Pessoa == null)
            {
                txtFornecedor.Text = "";
                return;
            }

            txtFornecedor.Text = itemSelecionado.Pessoa.Tipo switch
            {
                TipoPessoa.Fisica => string.IsNullOrWhiteSpace(itemSelecionado.Pessoa.PessoaFisica?.NomeCompleto)
                    ? ""
                    : itemSelecionado.Pessoa.PessoaFisica.NomeCompleto,

                TipoPessoa.Juridica => string.IsNullOrWhiteSpace(itemSelecionado.Pessoa.PessoaJuridica?.RazaoSocial)
                    ? ""
                    : itemSelecionado.Pessoa.PessoaJuridica.RazaoSocial,

                _ => ""
            };
        }


        private void PagarCadastroForm_Load(object sender, EventArgs e)
        {
            InicializarNovoPagar();
            CarregarCombosFinanceiros();
            CarregarCampos();
        }
        private void AtualizarObjetoPagar()
        {            
            itemSelecionado.Descricao = txtDescricao.Text.Trim();
            itemSelecionado.Documento = txtDocumento.Text.Trim();
            itemSelecionado.ValorParcela = decimal.Parse(txtValor.Text);
            itemSelecionado.DataVencimento = dtVencimento.Value.ToUniversalTime();

            itemSelecionado.Situacao = itemSelecionado.DataVencimento.Date < DateTime.Now.Date
                ? SituacaoPagar.Vencida
                : SituacaoPagar.Aberta;

            itemSelecionado.NumeroParcela = int.TryParse(txtNumeroParcela.Text, out var numParcela) ? numParcela : 1;
            itemSelecionado.QtdeParcelas = int.TryParse(txtQtdeParcela.Text, out var qtdeParcela) ? qtdeParcela : 1;

            if (itemSelecionado.Detalhe == null)
            {
                itemSelecionado.Detalhe = new FinanceiroPagarDetalheModel
                {
                    FinanceiroPagar = itemSelecionado
                };
            }

            itemSelecionado.Detalhe.CentroCustoId = (int)cmbCentroCusto.SelectedValue;
            itemSelecionado.Detalhe.PlanoContaId = (int)cmbPlanoConta.SelectedValue;
            itemSelecionado.Detalhe.EspecieId = (int)cmbEspecie.SelectedValue;
            itemSelecionado.Detalhe.Observacao = txtObservacao.Text.Trim();

            if (itemSelecionado.Valores == null)
            {
                itemSelecionado.Valores = new FinanceiroPagarValores
                {
                    FinanceiroPagar = itemSelecionado
                };
            }

            itemSelecionado.Valores.ValorDesconto = 0;
            itemSelecionado.Valores.ValorDescontoTipo = TipoValorAplicadoPagar.Fixo;

            itemSelecionado.Valores.ValorAcrescimo = 0;
            itemSelecionado.Valores.ValorAcrescimoTipo = TipoValorAplicadoPagar.Fixo;

            itemSelecionado.Valores.ValorMulta = 0;
            itemSelecionado.Valores.ValorMultaTipo = TipoValorAplicadoPagar.Fixo;

            itemSelecionado.Valores.ValorJuro = 0;
            itemSelecionado.Valores.ValorJuroTipo = TipoValorAplicadoPagar.Fixo;

            itemSelecionado.Valores.ValorTaxaCartao = 0;
            itemSelecionado.Valores.ValorTaxaCartaoTipo = TipoValorAplicadoPagar.Fixo;
        }


        private bool ValidarCamposCadastro()
        {

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("O campo descrição é obrigatório.");
                DefinirTab(tbCadastro);
                txtDescricao.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MensagemHelper.Alerta("O campo documento é obrigatório.");
                DefinirTab(tbCadastro);
                txtDocumento.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFornecedor.Text))
            {
                MensagemHelper.Alerta("Informe a pessoa referente a parcela.");
                DefinirTab(tbCadastro);
                txtFornecedor.Focus();
                return false;
            }

            if (cmbCentroCusto.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione um centro de custo.");
                DefinirTab(tbCadastro);
                cmbCentroCusto.Focus();
                return false;
            }

            if (cmbPlanoConta.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione um plano de conta.");
                DefinirTab(tbCadastro);
                cmbPlanoConta.Focus();
                return false;
            }

            if (cmbEspecie.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione uma espécie.");
                DefinirTab(tbCadastro);
                cmbEspecie.Focus();
                return false;
            }
            if (dtVencimento.Value.Date < DateTime.Today)
            {
                if (MensagemHelper.Confirmar("A data de vencimento está no passado. Deseja continuar mesmo assim?") != DialogResult.Yes)
                {
                    DefinirTab(tbCadastro);
                    dtVencimento.Focus();
                    return false;
                }
            }
            if (!int.TryParse(txtNumeroParcela.Text, out var numeroParcela) || numeroParcela <= 0)
            {
                MensagemHelper.Alerta("Informe um número de parcela válido.");
                DefinirTab(tbCadastro);
                txtNumeroParcela.Focus();
                return false;
            }

            if (!int.TryParse(txtQtdeParcela.Text, out var qtdeParcela) || qtdeParcela <= 0)
            {
                MensagemHelper.Alerta("Informe a quantidade de parcelas válida.");
                DefinirTab(tbCadastro);
                txtQtdeParcela.Focus();
                return false;
            }

            if (numeroParcela > qtdeParcela)
            {
                MensagemHelper.Alerta("O número da parcela não pode ser maior que a quantidade total.");
                DefinirTab(tbCadastro);
                txtNumeroParcela.Focus();
                return false;
            }

            if (!decimal.TryParse(txtValor.Text, out var valor) || valor <= 0)
            {
                MensagemHelper.Alerta("Informe um valor válido e maior que zero.");
                DefinirTab(tbCadastro);
                txtValor.Focus();
                return false;
            }

            return true;
        }

        private void DefinirTab(TabPage tabParaMostrar)
        {
            tbPagar.SelectedTab = tabParaMostrar;
        }
        private void MarcarComoModificado()
        {
            _context.Entry(itemSelecionado).State = EntityState.Modified;

            if (itemSelecionado.Detalhe != null)
            {
                _context.Entry(itemSelecionado.Detalhe).State = itemSelecionado.Detalhe.Id == 0 ? EntityState.Added : EntityState.Modified;
            }

            if (itemSelecionado.Valores != null)
            {
                _context.Entry(itemSelecionado.Valores).State = itemSelecionado.Valores.Id == 0 ? EntityState.Added : EntityState.Modified;
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (Operacao == TipoOperacao.Detalhes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }
            AtualizarObjetoPagar();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:

                    if (itemSelecionado.QtdeParcelas > 1)
                    {
                        var form = new PagarReplicarParcelaForm(_context)
                        {
                            ParcelaBase = itemSelecionado
                        };

                        if (form.ShowDialog() == DialogResult.OK && form.ParcelasGeradas.Any())
                        {
                            _context.FinanceiroPagar.AddRange(form.ParcelasGeradas);
                        }
                    }

                    _context.FinanceiroPagar.Add(itemSelecionado);
                    break;
                case TipoOperacao.Edicao:
                    MarcarComoModificado();
                    break;

                default:
                    break;
            }
            _context.SaveChanges();
        }

        private void PagarCadastroForm_KeyDown(object sender, KeyEventArgs e)
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
                    btnGravar.PerformClick();
                    break;
            }
        }

        private void PagarCadastroForm_Shown(object sender, EventArgs e)
        {
            if (Operacao != TipoOperacao.Detalhes)
            {
                txtDescricao.Focus();
            }
        }

        private void pbBuscaPessoa_Click(object sender, EventArgs e)
        {
            var formSelecaoPessoa = new PessoaSelecaoForm(_context);

            if (formSelecaoPessoa.ShowDialog() == DialogResult.OK)
            {
                var pessoaSelecionada = formSelecaoPessoa.ItemSelecionado;
                itemSelecionado.PessoaId = pessoaSelecionada.Id;
                itemSelecionado.Pessoa = pessoaSelecionada;
                AtualizarNomeFornecedor();
            }
        }

    }
}
