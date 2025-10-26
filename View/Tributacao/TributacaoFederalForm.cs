using Dados.Data;
using Dados.Data.Repositories;
using Dados.Enums;
using Dados.Helpers;
using Dados.Model.Tributacao;
using Dados.ViewModel.Tributacao;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.View.Tributacao.FederalCadastroFormulario;

namespace Visual.View.Tributacao.FederalFormulario
{
    public partial class TributacaoFederalForm : Form
    {
        private readonly DataContext _context;
        private readonly GenericRepository<TributacaoFederal> _repo;
        public TributacaoFederal ItemSelecionado { get; private set; }

        public TributacaoFederalForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
            _repo = new GenericRepository<TributacaoFederal>(_context);
        }

        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            lblDescricao.Font = new Font("Arial", 18, FontStyle.Regular);
            txtBusca.Font = new Font("Arial", 22, FontStyle.Regular);
        }

        private void TributacaoFederalForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "SelecaoGridTributacaoFederal");
            FormSettingsHelper.RestaurarConfiguracao(this, "SelecaoTributacaoFederalForm");
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
        }

        private void Filtrar(bool inclusao = false)
        {
            try
            {
                var textoBusca = txtBusca.Text;

                if (inclusao)
                {
                    txtBusca.Text = string.Empty;
                    textoBusca = string.Empty;
                }

                IEnumerable<TributacaoFederalViewModel> resultados;

                resultados = _repo.GetAll(noTracking: true)
                    .MapearFormatado<TributacaoFederal, TributacaoFederalViewModel>()
                    .FiltrarComCampos(textoBusca)
                    .ToList();

                gridConteudo.DataSource = resultados.ToList();

                if (inclusao)
                {
                    gridConteudo.SelecionarUltimaLinha();
                }
                AtualizarDescricaoComSelecionado();

            }
            catch (Exception ex)
            {
                MensagemHelper.Erro($"Erro ao filtrar: {ex.Message}");
            }
        }

        private void AtualizarDescricaoComSelecionado()
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoFederalViewModel selecionado)
                lblDescricao.Text = selecionado.Nome;
            else
                lblDescricao.Text = string.Empty;
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Filtrar();
            }
        }

        private void gridConteudo_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarDescricaoComSelecionado();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                DialogResult = DialogResult.None;
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoFederalViewModel selecionado)
            {
                ItemSelecionado = _context.TributacoesFederais
                                             .FirstOrDefault(p => p.Id == selecionado.Id);
            }
        }

        private void TributacaoFederalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "SelecaoGridTributacaoFederal");
            FormSettingsHelper.SalvarConfiguracao(this, "SelecaoTributacaoFederalForm");
        }

        private void TributacaoFederalForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F6:
                    btnSelecionar.PerformClick();
                    break;
                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void gridConteudo_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSelecionar.PerformClick();
        }

        private TributacaoFederal? CarregarTributacaoCompleta(int id)
        {
            return _context.TributacoesFederais
                .FirstOrDefault(p => p.Id == id);
        }
        private void btnExcluirTributacao_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoFederalViewModel selecionado)
            {
                if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) == DialogResult.Yes)
                {
                    try
                    {
                        var item = CarregarTributacaoCompleta(selecionado.Id);
                        if (item != null)
                        {
                            _context.TributacoesFederais.Remove(item);
                            _context.SaveChanges();
                            Filtrar();
                        }
                    }
                    catch (Exception ex)
                    {
                        MensagemHelper.Erro($"Erro na exclusão: {ex.Message}");
                    }
                }
            }
        }

        private void btnAlterarTributacao_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoFederalViewModel selecionado)
            {
                var tributacao = CarregarTributacaoCompleta(selecionado.Id);
                var formCadastro = new TributacaoFederalCadastroForm(_context)
                {
                    ItemSelecionado = tributacao,
                    Operacao = TipoOperacao.Edicao
                };

                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<TributacaoFederal, TributacaoFederalViewModel>(tributacao);
                    AtualizarDescricaoComSelecionado();
                }

            }

        }

        private void btnAdicionarTributacao_Click(object sender, EventArgs e)
        {
            var formCadastro = new TributacaoFederalCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                Filtrar(inclusao: true);
            }
        }

        private void TributacaoFederalForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();
        }
    }
}
