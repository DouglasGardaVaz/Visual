using Dados.Data;
using Dados.Enums;
using Dados.Enums.Financeiro.Caixa;
using Dados.Enums.Pessoa;
using Dados.Model.Cadastro;
using Dados.Model.Financeiro.Caixa;
using Microsoft.EntityFrameworkCore;
using Visual.Helpers.Combobox.Financeiro.Receber;
using Visual.Helpers.Form;
using Visual.View.PessoaSelecaoFormulario;

namespace Visual.View.Financeiro.CaixaCadastroFormulario
{
    public partial class CaixaCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public FinanceiroCaixa itemSelecionado { get; set; }
        public CaixaCadastroForm(DataContext context)
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
            txtValor.Text = itemSelecionado.Valor.ToString("N2");
            AtualizarNomeCliente();
            if (itemSelecionado.Detalhe != null)
            {
                cmbCentroCusto.SelectedValue = itemSelecionado.Detalhe.CentroCustoId ?? -1;
                cmbPlanoConta.SelectedValue = itemSelecionado.Detalhe.PlanoContaId ?? -1;
                cmbEspecie.SelectedValue = itemSelecionado.Detalhe.EspecieId ?? -1;
                txtObservacao.Text = itemSelecionado.Detalhe.Observacao ?? "";
            }

            if (Operacao == TipoOperacao.Detalhes)
            {
                txtDescricao.Enabled = false;
                txtValor.Enabled = false;
                cmbCentroCusto.Enabled = false;
                cmbPlanoConta.Enabled = false;
                cmbEspecie.Enabled = false;                
                txtObservacao.Enabled = false;
                btnCancelar.Visible = false;
                btnGravar.Text = "&Fechar | F6";
            }
        }
        private void InicializarNovoPagar()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                itemSelecionado = new FinanceiroCaixa
                {
                    Data = DateTime.Today,
                    Entrada = true,
                    Origem = OrigemFinanceiraCaixa.Caixa,
                };
            }
        }
        private void CarregarCombosFinanceiros()
        {
            cmbCentroCusto.PreencherComboComDbSet<CentroCusto>(_context, x => x.Descricao, x => x.Id);
            cmbPlanoConta.PreencherComboComDbSet<PlanoConta>(_context, x => x.Descricao, x => x.Id);
            cmbEspecie.PreencherComboComDbSet<Especie>(_context, x => x.Descricao, x => x.Id);
        }

        private void CaixaCadastroForm_Load(object sender, EventArgs e)
        {
            CaixaHelper.PreencherOperacoes(cmbTipoMovimentacao);
            InicializarNovoPagar();
            CarregarCombosFinanceiros();
            CarregarCampos();
        }
        private void AtualizarObjetoCaixa()
        {
            itemSelecionado.Descricao = txtDescricao.Text.Trim();            
            itemSelecionado.Valor = decimal.Parse(txtValor.Text);
            itemSelecionado.Data = DateTime.Today.Date.ToUniversalTime();
            if (itemSelecionado.Detalhe == null)
            {
                itemSelecionado.Detalhe = new FinanceiroCaixaDetalhe();
                
            }
            var tipoMovimentacao = (TipoOperacaoCaixa)cmbTipoMovimentacao.SelectedValue;
            itemSelecionado.Entrada = tipoMovimentacao == TipoOperacaoCaixa.Entrada;
            itemSelecionado.Detalhe.CentroCustoId = (int)cmbCentroCusto.SelectedValue;
            itemSelecionado.Detalhe.PlanoContaId = (int)cmbPlanoConta.SelectedValue;
            itemSelecionado.Detalhe.EspecieId = (int)cmbEspecie.SelectedValue;
            itemSelecionado.Detalhe.Observacao = txtObservacao.Text.Trim();
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
            AtualizarObjetoCaixa();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.FinanceiroCaixa.Add(itemSelecionado);
                    break;
                case TipoOperacao.Edicao:
                    MarcarComoModificado();
                    break;

                default:
                    break;
            }
            _context.SaveChanges();
        }

        private void CaixaCadastroForm_KeyDown(object sender, KeyEventArgs e)
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

        private void CaixaCadastroForm_Shown(object sender, EventArgs e)
        {
            if (Operacao != TipoOperacao.Detalhes)
            {
                txtDescricao.Focus();
            }
        }
        private void AtualizarNomeCliente()
        {
            if (itemSelecionado.PessoaId == 0)
            {
                txtCliente.Text = "";
                return;
            }
            var pessoaSelecionada = _context.Pessoas
                .Include(x => x.PessoaFisica)
                .Include(x => x.PessoaJuridica)
                .FirstOrDefault(x => x.Id == itemSelecionado.PessoaId);

            txtCliente.Text = pessoaSelecionada.Tipo switch
            {
                TipoPessoa.Fisica => string.IsNullOrWhiteSpace(pessoaSelecionada.PessoaFisica?.NomeCompleto)
                    ? ""
                    : pessoaSelecionada.PessoaFisica.NomeCompleto,

                TipoPessoa.Juridica => string.IsNullOrWhiteSpace(pessoaSelecionada.PessoaJuridica?.RazaoSocial)
                    ? ""
                    : pessoaSelecionada.PessoaJuridica.RazaoSocial,

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
                AtualizarNomeCliente();
            }
        }
    }
}
