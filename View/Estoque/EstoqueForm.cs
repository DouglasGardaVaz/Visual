using Dados.Data;
using Dados.Data.Repositories;
using Dados.Enums;
using Dados.Helpers.Filtro;
using Dados.Model.Estoque;
using Dados.ViewModel.Estoque;
using GerencialLoja.View.EstoqueCadastroFormulario;
using Microsoft.EntityFrameworkCore;
using Dados.Constantes.Mensagens.Global;
using Dados.Helpers.Form;
using Dados.Helpers.Grid;

namespace Dados.View.EstoqueFormulario
{
    public partial class EstoqueForm : Form
    {
        private readonly DataContext _context = new();
        private readonly GenericRepository<EstoqueItem> repo;
        private int paginaAtual = 0;
        private const int registrosPorPagina = 100;
        private bool ultimaPagina = false;
        private List<EstoqueItemViewModel> dadosCarregados = new();
        private bool modoBuscaCompleta = false;

        public EstoqueForm()
        {
            InitializeComponent();
            repo = new GenericRepository<EstoqueItem>(_context);
        }

        private void Filtrar(bool inclusao = false, bool buscaCompleta = false)
        {
            CarregarItensEstoque(inclusao, buscaCompleta, scrollInfinito: false);
        }

        private EstoqueItem? CarregarItemCompleto(int id)
        {
            return _context.EstoqueItens
                .Include(i => i.Tributacao)
                .Include(i => i.Grades)
                .Include(i => i.Valores)
                .Include(i => i.Classificacao)
                .Include(i => i.Qtde)
                .Include(i => i.Adicional)
                .FirstOrDefault(i => i.Id == id);
        }

        private void FiltrarScrollInfinito()
        {
            if (!ultimaPagina && !modoBuscaCompleta)
                CarregarItensEstoque(scrollInfinito: true);
        }


        private void CarregarItensEstoque(bool inclusao = false, bool buscaCompleta = false, bool scrollInfinito = false)
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
               
                EstoqueItemGrade? gradeEncontrada = null;
                int? idBuscaDireta = null;

                if (!string.IsNullOrWhiteSpace(textoBusca))
                {
                    string normalizado = textoBusca.Trim().Replace(".", "").Replace("-", "");

                    if (int.TryParse(normalizado, out int id))
                        idBuscaDireta = id;

                    if (idBuscaDireta == null)
                    {
                        gradeEncontrada = _context.EstoqueItensGrades
                            .AsNoTracking()
                            .FirstOrDefault(g => g.CodigoBarras.Replace(".", "").Replace("-", "").Replace("/", "") == normalizado);
                    }
                }

                var query = repo.GetAllQueryable()
                    .AsNoTracking()
                    .Include(i => i.Grades)
                    .AsQueryable();

                if (idBuscaDireta.HasValue)
                {
                    query = query.Where(i => i.Id == idBuscaDireta.Value);
                }
                else if (gradeEncontrada != null)
                {
                    query = query.Where(i => i.Id == gradeEncontrada.EstoqueItemId);
                }
                else if (!buscaCompleta)
                {
                    query = query
                        .Skip(paginaAtual * registrosPorPagina)
                        .Take(registrosPorPagina);
                }

                var itensBase = query.ToList();
                var ids = itensBase.Select(i => i.Id).ToList();

                var qtdeView = _context.ViewEstoqueQtdeTotal
                    .AsNoTracking()
                    .Where(q => ids.Contains(q.EstoqueItemId))
                    .ToList();

                var novos = itensBase
                    .Select(item =>
                    {
                        var vm = new EstoqueItemViewModel();
                        var viewQtde = qtdeView.FirstOrDefault(v => v.EstoqueItemId == item.Id);
                        vm.PreencherCom(item, viewQtde);
                        return vm;
                    })
                    .ToList();
               
                if (!string.IsNullOrWhiteSpace(textoBusca) && idBuscaDireta == null && gradeEncontrada == null)
                {
                    novos = novos.FiltrarEstoqueComCamposEGrades(textoBusca).ToList();
                }

                if (scrollInfinito)
                {
                    if (novos.Count < registrosPorPagina)
                        ultimaPagina = true;

                    dadosCarregados.AddRange(novos);
                    gridConteudo.DataSource = dadosCarregados.ToList();
                    paginaAtual++;
                }
                else
                {
                    gridConteudo.DataSource = novos;
                    dadosCarregados = novos;

                    if (inclusao)
                    {
                        gridConteudo.SelecionarUltimaLinha();
                        AtualizarDescricaoComSelecionado();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagemHelper.Erro($"Erro ao carregar dados: {ex.Message}");
            }
        }





        private void AtualizarDescricaoComSelecionado()
        {
            try
            {
                if (gridConteudo.Rows.Count == 0 || gridConteudo.CurrentRow == null || gridConteudo.CurrentCell == null)
                {
                    lblDescricao.Text = string.Empty;
                    return;
                }

                if (gridConteudo.CurrentRow.DataBoundItem is EstoqueItemViewModel selecionado)
                {
                    lblDescricao.Text = selecionado.Nome;
                }
                else
                {
                    lblDescricao.Text = string.Empty;
                }
            }
            catch
            {
                lblDescricao.Text = string.Empty;
            }
        }



        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            var formCadastroEstoque = new EstoqueCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastroEstoque.ShowDialog() == DialogResult.OK)
            {
                Filtrar(true);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is EstoqueItemViewModel selecionado)
            {
                var item = CarregarItemCompleto(selecionado.Id);

                var form = new EstoqueCadastroForm(_context)
                {
                    itemSelecionado = item,
                    Operacao = TipoOperacao.Edicao
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    AtualizarItemNaGrid(item.Id);
                    AtualizarDescricaoComSelecionado();
                }
            }
        }

        private void AtualizarItemNaGrid(int itemId)
        {
            var item = CarregarItemCompleto(itemId);
            if (item == null)
                return;

            var qtdeAtual = _context.ViewEstoqueQtdeTotal
                .AsNoTracking()
                .FirstOrDefault(v => v.EstoqueItemId == itemId);

            var novoVM = new EstoqueItemViewModel();
            novoVM.PreencherCom(item, qtdeAtual);

            for (int i = 0; i < gridConteudo.Rows.Count; i++)
            {
                if (gridConteudo.Rows[i].DataBoundItem is EstoqueItemViewModel linhaVM && linhaVM.Id == itemId)
                {
                    linhaVM.PreencherCom(item, qtdeAtual);
                    gridConteudo.InvalidateRow(i);
                    break;
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is EstoqueItemViewModel selecionado)
            {
                if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) == DialogResult.Yes)
                {
                    try
                    {
                        string filtroAtual = txtBusca.Text;
                        var item = CarregarItemCompleto(selecionado.Id);

                        if (item != null)
                        {
                            repo.Remove(item);

                            txtBusca.Text = filtroAtual;
                            Filtrar();

                            MensagemHelper.Info(MensagensComuns.SucessoExclusao);
                        }
                    }
                    catch (Exception ex)
                    {
                        MensagemHelper.Erro($"Erro ao exclusão: {ex.Message}");
                    }

                }
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

        private void EstoqueForm_KeyDown(object sender, KeyEventArgs e)
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

        private void EstoqueForm_Load(object sender, EventArgs e)
        {
            dadosCarregados.Clear();
            paginaAtual = 0;
            ultimaPagina = false;
            CarregarItensEstoque(inclusao: false, buscaCompleta: true, scrollInfinito: false);
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "GerencialGridEstoque");
            FormSettingsHelper.RestaurarConfiguracao(this, "GerencialEstoqueForm");
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EstoqueForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "GerencialGridEstoque");
            FormSettingsHelper.SalvarConfiguracao(this, "GerencialEstoqueForm");
        }

        private void gridConteudo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string nomeColuna = gridConteudo.Columns[e.ColumnIndex].DataPropertyName;
            if (!string.IsNullOrWhiteSpace(nomeColuna))
            {
                gridConteudo.OrdenarPorColuna(nomeColuna);
            }
        }
    }
}
