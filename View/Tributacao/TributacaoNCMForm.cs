using Dados.Data;
using Dados.Data.Repositories;
using Dados.Enums;
using Dados.Helpers;
using Dados.Model.Tributacao;
using Dados.ViewModel.Tributacao;
using Microsoft.EntityFrameworkCore;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.View.Tributacao.NCMCadastroFormulario;

namespace Visual.View.Tributacao.NCMSelecaoFormulario
{
    public partial class TributacaoNCMForm : Form
    {
        private readonly DataContext _context = new DataContext();
        private readonly GenericRepository<TributacaoNCM> repo;
        private int paginaAtual = 0;
        private const int registrosPorPagina = 100;
        private bool ultimaPagina = false;
        private List<TributacaoNCMViewModel> dadosCarregados = new();
        private bool modoBuscaCompleta = false;
        public TributacaoNCM ItemSelecionado { get; set; }
        public TributacaoNCMForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
            repo = new GenericRepository<TributacaoNCM>(_context);
        }
        private void FiltrarScrollInfinito(bool Inicio = false)
        {
            if (ultimaPagina)
                return;

            var novos = repo.GetPaged(paginaAtual, registrosPorPagina, noTracking: true)
                .MapearFormatado<TributacaoNCM, TributacaoNCMViewModel>()
                .ToList();

            if (novos.Count < registrosPorPagina)
                ultimaPagina = true;

            dadosCarregados.AddRange(novos);
            try
            {
                if (!Inicio)
                    SalvarGrid();
                gridConteudo.DataSource = dadosCarregados.ToList();
            }
            finally
            {
                CarregarGrid();
            }

            paginaAtual++;
        }
        private void Filtrar(bool inclusao = false, bool buscaCompleta = false)
        {
            try
            {
                modoBuscaCompleta = buscaCompleta;

                var textoBusca = txtBusca.Text;

                if (inclusao)
                {
                    txtBusca.Text = string.Empty;
                    textoBusca = string.Empty;
                }

                IEnumerable<TributacaoNCMViewModel> pessoas;

                if (buscaCompleta)
                {
                    pessoas = repo.GetAll(noTracking: true)
                        .MapearFormatado<TributacaoNCM, TributacaoNCMViewModel>()
                        .FiltrarComCampos(textoBusca)
                        .ToList();
                }
                else
                {
                    pessoas = repo.GetPaged(0, 100, noTracking: true)
                        .MapearFormatado<TributacaoNCM, TributacaoNCMViewModel>();
                }

                gridConteudo.DataSource = pessoas.ToList();

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
            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoNCMViewModel selecionado)
                lblDescricao.Text = $"{selecionado.Codigo} - {selecionado.Descricao}";
            else
                lblDescricao.Text = string.Empty;
        }
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            FormSettingsHelper.RestaurarConfiguracao(this, "SelecaoNCMForm");
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
            txtBusca.Font = new Font("Arial", 23, FontStyle.Regular);
            lblDescricao.Font = new Font("Arial", 18, FontStyle.Regular);

        }

        private void SalvarGrid()
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "SelecaoGridNCM");
        }
        private void CarregarGrid()
        {
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "SelecaoGridNCM");
        }
        private void TributacaoNCMSelecaoForm_Load(object sender, EventArgs e)
        {
            dadosCarregados.Clear();
            paginaAtual = 0;
            ultimaPagina = false;
            GridEnterHelper.HabilitarEnterParaSelecionar(gridConteudo, () => btnSelecionar.PerformClick());
            AjustarLayout();
            FiltrarScrollInfinito(Inicio: true);
            CarregarGrid();
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                dadosCarregados.Clear();
                paginaAtual = 0;
                ultimaPagina = false;
                Filtrar(buscaCompleta: true);
            }
        }

        private void gridConteudo_Scroll(object sender, ScrollEventArgs e)
        {
            if (ultimaPagina || modoBuscaCompleta)
                return;

            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll &&
                e.NewValue + gridConteudo.DisplayedRowCount(false) >= gridConteudo.RowCount)
            {
                FiltrarScrollInfinito();
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

            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoNCMViewModel selecionado)
            {
                ItemSelecionado = _context.TributacoesNCM
                                             .FirstOrDefault(p => p.Id == selecionado.Id);
            }
        }

        private void TributacaoNCMSelecaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalvarGrid();
            FormSettingsHelper.SalvarConfiguracao(this, "SelecaoNCMForm");
        }

        private void TributacaoNCMSelecaoForm_KeyDown(object sender, KeyEventArgs e)
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

        private void gridConteudo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelecionar.PerformClick();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private TributacaoNCM? CarregarNCMCompleto(int id)
        {
            return _context.TributacoesNCM
                .Include(p => p.Valores)
                .FirstOrDefault(p => p.Id == id);
        }

        private void btnExcluirNCM_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoNCMViewModel selecionado)
            {
                if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) == DialogResult.Yes)
                {
                    try
                    {
                        var item = CarregarNCMCompleto(selecionado.Id);
                        if (item != null)
                        {
                            _context.TributacoesNCM.Remove(item);
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

        private void btnAdicionarNCM_Click(object sender, EventArgs e)
        {
            var formCadastro = new TributacaoNCMCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                Filtrar(inclusao: true);                
            }
        }

        private void btnAlterarNCM_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoNCMViewModel selecionado)
            {
                var tributacao = CarregarNCMCompleto(selecionado.Id);
                var formCadastro = new TributacaoNCMCadastroForm(_context)
                {
                    ItemSelecionado = tributacao,
                    Operacao = TipoOperacao.Edicao
                };

                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<TributacaoNCM, TributacaoNCMViewModel>(tributacao);
                    AtualizarDescricaoComSelecionado();
                }

            }
        }

        private void TributacaoNCMForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();   
        }
    }
}
