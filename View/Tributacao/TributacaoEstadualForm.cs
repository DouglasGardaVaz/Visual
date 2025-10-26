using Dados.Data;
using Dados.Data.Repositories;
using Dados.Enums;
using Dados.Helpers;
using Dados.Model.Tributacao;
using Dados.ViewModel.Tributacao;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.View.Tributacao.EstadualCadastroFormulario;

namespace Visual.View.Tributacao.EstadualFormulario
{
    public partial class TributacaoEstadualForm : Form
    {
        private readonly DataContext _context;
        private readonly GenericRepository<TributacaoEstadual> _repo;
        public TributacaoEstadual ItemSelecionado { get; private set; }

        public TributacaoEstadualForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
            _repo = new GenericRepository<TributacaoEstadual>(_context);
        }
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            lblDescricao.Font = new Font("Arial", 18, FontStyle.Regular);
            txtBusca.Font = new Font("Arial", 22, FontStyle.Regular);
        }
        private void TributacaoEstadualForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "SelecaoGridTributacaoEstadual");
            FormSettingsHelper.RestaurarConfiguracao(this, "SelecaoTributacaoEstadualForm");
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

                IEnumerable<TributacaoEstadualViewModel> resultados;

                resultados = _repo.GetAll(noTracking: true)
                    .MapearFormatado<TributacaoEstadual, TributacaoEstadualViewModel>()
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
            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoEstadualViewModel selecionado)
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

            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoEstadualViewModel selecionado)
            {
                ItemSelecionado = _context.TributacoesEstaduais
                                             .FirstOrDefault(p => p.Id == selecionado.Id);
            }
        }

        private void TributacaoEstadualForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "SelecaoGridTributacaoEstadual");
            FormSettingsHelper.SalvarConfiguracao(this, "SelecaoTributacaoEstadualForm");
        }

        private void TributacaoEstadualForm_KeyDown(object sender, KeyEventArgs e)
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

        private TributacaoEstadual? CarregarTributacaoCompleta(int id)
        {
            return _context.TributacoesEstaduais
                .FirstOrDefault(p => p.Id == id);
        }
        private void btnExcluirTributacao_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoEstadualViewModel selecionado)
            {
                if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) == DialogResult.Yes)
                {
                    try
                    {
                        var item = CarregarTributacaoCompleta(selecionado.Id);
                        if (item != null)
                        {
                            _context.TributacoesEstaduais.Remove(item);
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

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoEstadualViewModel selecionado)
            {
                var tributacao = CarregarTributacaoCompleta(selecionado.Id);
                var formCadastro = new TributacaoEstadualCadastroForm(_context)
                {
                    ItemSelecionado = tributacao,
                    Operacao = TipoOperacao.Edicao
                };

                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<TributacaoEstadual, TributacaoEstadualViewModel>(tributacao);
                    AtualizarDescricaoComSelecionado();
                }
            }
        }

        private void btnAdicionarTributacao_Click(object sender, EventArgs e)
        {
            var formCadastro = new TributacaoEstadualCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                Filtrar(inclusao: true);
            }
        }

        private void TributacaoEstadualForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();
        }
    }
}
