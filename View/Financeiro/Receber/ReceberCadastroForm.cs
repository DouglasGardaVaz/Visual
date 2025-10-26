using Dados.Data;
using Dados.Enums;
using Dados.Enums.Financeiro.Receber;
using Dados.Enums.Pessoa;
using Dados.Model.Cadastro;
using Dados.Model.Configuracao.Parametros.Financeiro.Receber;
using Dados.Model.Financeiro.Receber;
using Microsoft.EntityFrameworkCore;
using Visual.Helpers.Form;
using Visual.View.Financeiro.ReceberReplicarParcelaFormulario;
using Visual.View.PessoaSelecaoFormulario;

namespace Visual.View.Financeiro.ReceberCadastroFormulario
{
    public partial class ReceberCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public FinanceiroReceber itemSelecionado { get; set; }
        public ReceberCadastroForm(DataContext context)
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

            txtDescricao.Text = itemSelecionado.Descricao;
            txtDocumento.Text = itemSelecionado.Documento;
            txtValor.Text = itemSelecionado.ValorParcela.ToString("N2");
            dtVencimento.Value = itemSelecionado.DataVencimento;
            txtNumeroParcela.Text = itemSelecionado.NumeroParcela.ToString();
            txtQtdeParcela.Text = itemSelecionado.QtdeParcelas.ToString();
            AtualizarNomeCliente();
            if (itemSelecionado.Detalhe != null)
            {
                cmbCentroCusto.SelectedValue = itemSelecionado.Detalhe.CentroCustoId ?? -1;
                cmbPlanoConta.SelectedValue = itemSelecionado.Detalhe.PlanoContaId ?? -1;
                cmbEspecie.SelectedValue = itemSelecionado.Detalhe.EspecieId ?? -1;
                txtObservacao.Text = itemSelecionado.Detalhe.Observacao ?? "";
            }

            if (itemSelecionado.DataRecebimento.HasValue)
            {
                dtRecebimento.Value = itemSelecionado.DataRecebimento.Value;
                txtValorPago.Text = itemSelecionado.Valores?.ValorRecebido.ToString("N2") ?? "0,00";
                dtRecebimento.Visible = true;
                lblPagamento.Visible = true;
                lblValorPago.Visible = true;
                txtValorPago.Visible = true;
            }
            else
            {
                dtRecebimento.Visible = false;
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
                dtRecebimento.Enabled = false;
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
                itemSelecionado = new FinanceiroReceber
                {
                    DataVencimento = DateTime.Today,
                    Situacao = SituacaoReceber.Aberta,
                    Origem = OrigemReceber.Pagar
                };
            }
        }
        private void CarregarCombosFinanceiros()
        {
            cmbEspecie.PreencherComboComDbSet<Especie>(_context, x => x.Descricao, x => x.Id);
            cmbCentroCusto.PreencherComboComDbSet<CentroCusto>(_context, x => x.Descricao, x => x.Id);
            cmbPlanoConta.PreencherComboComDbSet<PlanoConta>(_context, x => x.Descricao, x => x.Id);            

            if (Operacao == TipoOperacao.Inclusao)
            {
                cmbPlanoConta.SelectedValue = ParametrosReceber.PlanoContaPadrao;
                cmbCentroCusto.SelectedValue = ParametrosReceber.CentroCustoPadrao;
                cmbEspecie.SelectedValue = ParametrosReceber.EspeciePadrao;
            }
        }

        private void ReceberCadastroForm_Load(object sender, EventArgs e)
        {
            InicializarNovoPagar();
            CarregarCombosFinanceiros();
            CarregarCampos();
        }
        private void AtualizarObjetoReceber()
        {
            itemSelecionado.PessoaId = 6;
            itemSelecionado.Descricao = txtDescricao.Text.Trim();
            itemSelecionado.Documento = txtDocumento.Text.Trim();
            itemSelecionado.ValorParcela = decimal.Parse(txtValor.Text);
            itemSelecionado.DataVencimento = dtVencimento.Value.ToUniversalTime();

            itemSelecionado.Situacao = itemSelecionado.DataVencimento.Date < DateTime.Now.Date
                ? SituacaoReceber.Vencida
                : SituacaoReceber.Aberta;

            itemSelecionado.NumeroParcela = int.TryParse(txtNumeroParcela.Text, out var numParcela) ? numParcela : 1;
            itemSelecionado.QtdeParcelas = int.TryParse(txtQtdeParcela.Text, out var qtdeParcela) ? qtdeParcela : 1;

            if (itemSelecionado.Detalhe == null)
            {
                itemSelecionado.Detalhe = new FinanceiroReceberDetalhe
                {
                    FinanceiroReceber = itemSelecionado
                };
            }

            itemSelecionado.Detalhe.CentroCustoId = (int)cmbCentroCusto.SelectedValue;
            itemSelecionado.Detalhe.PlanoContaId = (int)cmbPlanoConta.SelectedValue;
            itemSelecionado.Detalhe.EspecieId = (int)cmbEspecie.SelectedValue;
            itemSelecionado.Detalhe.Observacao = txtObservacao.Text.Trim();

            if (itemSelecionado.Valores == null)
            {
                itemSelecionado.Valores = new FinanceiroReceberValores
                {
                    FinanceiroReceber = itemSelecionado
                };
            }

            itemSelecionado.Valores.ValorDesconto = 0;
            itemSelecionado.Valores.ValorDescontoTipo = TipoValorAplicadoReceber.Fixo;

            itemSelecionado.Valores.ValorAcrescimo = 0;
            itemSelecionado.Valores.ValorAcrescimoTipo = TipoValorAplicadoReceber.Fixo;

            itemSelecionado.Valores.ValorMulta = 0;
            itemSelecionado.Valores.ValorMultaTipo = TipoValorAplicadoReceber.Fixo;

            itemSelecionado.Valores.ValorJuro = 0;
            itemSelecionado.Valores.ValorJuroTipo = TipoValorAplicadoReceber.Fixo;

            itemSelecionado.Valores.ValorTaxaCartao = 0;
            itemSelecionado.Valores.ValorTaxaCartaoTipo = TipoValorAplicadoReceber.Fixo;
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

            if (string.IsNullOrWhiteSpace(txtCliente.Text))
            {
                MensagemHelper.Alerta("Informe a pessoa referente a parcela.");
                DefinirTab(tbCadastro);
                txtCliente.Focus();
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
            tbReceber.SelectedTab = tabParaMostrar;
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
            AtualizarObjetoReceber();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:

                    if (itemSelecionado.QtdeParcelas > 1)
                    {
                        var form = new ReceberReplicarParcelaForm(_context)
                        {
                            ParcelaBase = itemSelecionado
                        };

                        if (form.ShowDialog() == DialogResult.OK && form.ParcelasGeradas.Any())
                        {
                            _context.FinanceiroReceber.AddRange(form.ParcelasGeradas);
                        }
                    }

                    _context.FinanceiroReceber.Add(itemSelecionado);
                    break;
                case TipoOperacao.Edicao:
                    MarcarComoModificado();
                    break;

                default:
                    break;
            }
            _context.SaveChanges();
        }

        private void ReceberCadastroForm_KeyDown(object sender, KeyEventArgs e)
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

        private void ReceberCadastroForm_Shown(object sender, EventArgs e)
        {
            if (Operacao != TipoOperacao.Detalhes)
            {
                txtDescricao.Focus();
            }
        }
        private void AtualizarNomeCliente()
        {
            if (itemSelecionado?.Pessoa == null)
            {
                txtCliente.Text = "";
                return;
            }

            txtCliente.Text = itemSelecionado.Pessoa.Tipo switch
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
        private void pbBuscaPessoa_Click(object sender, EventArgs e)
        {
            var formSelecaoPessoa = new PessoaSelecaoForm(_context);

            if (formSelecaoPessoa.ShowDialog() == DialogResult.OK)
            {
                var pessoaSelecionada = formSelecaoPessoa.ItemSelecionado;
                itemSelecionado.PessoaId = pessoaSelecionada.Id;
                itemSelecionado.Pessoa = pessoaSelecionada;
                AtualizarNomeCliente();
            }
        }
    }
}
