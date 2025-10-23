using Dados.Constantes;
using Dados.Data;
using Dados.Enums;
using Dados.Helpers;
using Dados.Model.PessoaEnderecoModel;
using Dados.Model.PessoaModel;
using Dados.ViewModel.Pessoa;
using Microsoft.EntityFrameworkCore;
using Dados.Constantes.Forms;
using Dados.Constantes.Grids;
using Dados.Constantes.Mensagens.Global;
using Dados.Helpers.Form;
using Dados.Helpers.Grid;
using Dados.View.PessoaCadastroFormulario;

namespace Dados.View.PessoaFormulario
{
    public partial class PessoaForm : Form
    {
        private readonly DataContext _context = new();
        private int paginaAtual = 0;
        private const int registrosPorPagina = 100;
        private bool ultimaPagina = false;
        private List<PessoaViewModel> dadosCarregados = new();
        private bool modoBuscaCompleta = false;

        public PessoaForm()
        {
            InitializeComponent();
        }

        private void PessoaForm_Load(object sender, EventArgs e)
        {
            dadosCarregados.Clear();
            paginaAtual = 0;
            ultimaPagina = false;
            Filtrar(primeiraBusca: true);
            CarregarSalvarGrid(Salvar: false);
            FormSettingsHelper.RestaurarConfiguracao(this, FormsConstantes.GerencialPessoaForm);
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
        }

        private void AtualizarDescricaoComSelecionado()
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is PessoaViewModel selecionado)
                lblDescricao.Text = selecionado.NomeCliente;
            else
                lblDescricao.Text = string.Empty;
        }

        private IQueryable<ViewClienteGerencial> AplicarFiltrosBasicos(IQueryable<ViewClienteGerencial> query)
        {
            if (!string.IsNullOrWhiteSpace(txtBusca.Text))
            {
                query = query.FiltrarComCamposNoBanco(txtBusca.Text);
            }
            return query;
        }

        private void FiltrarScrollInfinito()
        {
            if (ultimaPagina)
                return;

            var query = _context.ViewClienteGerencial.AsNoTracking();
            query = AplicarFiltrosBasicos(query);

            var novos = query
                .OrderBy(c => c.Codigo)
                .Skip(paginaAtual * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList()
                .Select(item =>
                {
                    var vm = new PessoaViewModel();
                    vm.PreencherCom(item);
                    return vm;
                })
                .ToList();

            if (novos.Count < registrosPorPagina)
                ultimaPagina = true;

            dadosCarregados.AddRange(novos);

            CarregarSalvarGrid(Salvar: true);
            gridConteudo.DataSource = null;
            gridConteudo.DataSource = dadosCarregados.ToList();
            CarregarSalvarGrid(Salvar: false);
            paginaAtual++;
        }

        private void Filtrar(bool inclusao = false, bool buscaCompleta = false, bool primeiraBusca = false)
        {
            try
            {
                modoBuscaCompleta = buscaCompleta;

                if (inclusao)
                {
                    txtBusca.Text = string.Empty;
                }

                var query = _context.ViewClienteGerencial.AsNoTracking();
                query = AplicarFiltrosBasicos(query);

                query = query.OrderBy(c => c.Codigo);

                if (!buscaCompleta)
                    query = query.Take(registrosPorPagina);

                var itens = query
                    .ToList()
                    .Select(item =>
                    {
                        var vm = new PessoaViewModel();
                        vm.PreencherCom(item);
                        return vm;
                    })
                    .ToList();

                if (!primeiraBusca)
                    CarregarSalvarGrid(Salvar: true);

                gridConteudo.DataSource = itens;

                if (!primeiraBusca)
                    CarregarSalvarGrid(Salvar: false);

                if (inclusao)
                {
                    gridConteudo.SelecionarUltimaLinha();
                    AtualizarDescricaoComSelecionado();
                }
            }
            catch (Exception ex)
            {
                MensagemHelper.Erro($"Erro ao filtrar: {ex.Message}");
            }
        }

        private Pessoa? CarregarPessoaCompleta(int id)
        {
            return _context.Pessoas
                .Include(p => p.PessoaFisica)
                .Include(p => p.PessoaJuridica)
                .Include(p => p.Contatos)
                .Include(p => p.Enderecos)
                .Include(p => p.Documentos)
                .Include(p => p.Adicionais)
                .FirstOrDefault(p => p.Id == id);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var form = new PessoaCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                Filtrar(true);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is not PessoaViewModel selecionado)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            var pessoa = CarregarPessoaCompleta(selecionado.Codigo);
            if (pessoa == null)
            {
                MensagemHelper.Alerta("Pessoa não encontrada.");
                return;
            }

            var form = new PessoaCadastroForm(_context)
            {
                itemSelecionado = pessoa,
                Operacao = TipoOperacao.Edicao
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                Filtrar();
                AtualizarDescricaoComSelecionado();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is not PessoaViewModel selecionado)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            var confirmar = MessageBox.Show(MensagensComuns.ConfirmarExclusao, AppInfo.NomeSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                var pessoa = CarregarPessoaCompleta(selecionado.Codigo);
                if (pessoa != null)
                {
                    _context.Pessoas.Remove(pessoa);
                    _context.SaveChanges();
                    Filtrar();
                    MensagemHelper.Info(MensagensComuns.SucessoExclusao);
                }
            }
            catch
            {
                MensagemHelper.Erro(MensagensComuns.ErroExclusao);
            }
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

        private void PessoaForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F3:
                    txtBusca.Focus();
                    break;
                case Keys.F4:
                    btnExcluir.PerformClick();
                    break;
                case Keys.F5:
                    btnAlterar.PerformClick();
                    break;
                case Keys.F6:
                    btnCadastrar.PerformClick();
                    break;
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CarregarSalvarGrid(bool Salvar)
        {
            if (Salvar)
            {
                GridSettingsHelper.SalvarConfiguracao(gridConteudo, GridConstantes.GerencialGridPessoa);
            }
            else
            {
                GridSettingsHelper.RestaurarConfiguracao(gridConteudo, GridConstantes.GerencialGridPessoa);
            }
        }

        private void PessoaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CarregarSalvarGrid(Salvar: true);
            FormSettingsHelper.SalvarConfiguracao(this, FormsConstantes.GerencialPessoaForm);
        }

        private void gridConteudo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string nomeColuna = gridConteudo.Columns[e.ColumnIndex].DataPropertyName;
            if (!string.IsNullOrWhiteSpace(nomeColuna))
            {
                gridConteudo.OrdenarPorColuna(nomeColuna);
            }
        }

        private void PessoaForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();
        }
    }
}
