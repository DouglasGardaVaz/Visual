using Dados.Data;
using Dados.Data.Repositories;
using Dados.Enums;
using Dados.Helpers;
using Dados.Model.Financeiro.Caixa;
using Dados.ViewModel.Financeiro.Caixa;
using Dados.Constantes;
using Dados.Constantes.Mensagens.Financeiro;
using Dados.Constantes.Mensagens.Global;
using Dados.Helpers.Combobox.Financeiro.Receber;
using Dados.Helpers.Form;
using Dados.Helpers.Grid;
using Dados.View.Financeiro.CaixaCadastroFormulario;

namespace Dados.View.Financeiro.CaixaFormulario
{
    public partial class CaixaForm : Form
    {
        private readonly DataContext _context = new();
        private readonly GenericRepository<FinanceiroCaixa> repo;
        private int paginaAtual = 0;
        private const int registrosPorPagina = 100;
        private bool ultimaPagina = false;
        private List<CaixaViewModel> dadosCarregados = new();
        private bool modoBuscaCompleta = false;

        public CaixaForm()
        {
            InitializeComponent();            
            repo = new GenericRepository<FinanceiroCaixa>(_context);
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

                List<FinanceiroCaixa> itensBase;

                if (buscaCompleta)
                {
                    itensBase = repo.GetAll(noTracking: true)
                        .FiltrarComCampos(textoBusca)
                        .ToList();
                }
                else
                {
                    itensBase = repo.GetPaged(0, registrosPorPagina, noTracking: true)
                        .ToList();
                }

                var dataInicio = dtInicial.Value.Date;
                var dataFim = dtFinal.Value.Date;

                itensBase = itensBase.Where(p => p.Data.Date >= dataInicio && p.Data.Date <= dataFim).ToList();

                if (cmbTipoMovimentacao.SelectedItem is string campoSelecionado)
                {
                    if (campoSelecionado == "Entrada")
                        itensBase = itensBase.Where(p => p.Entrada == true).ToList();
                    else if (campoSelecionado == "Saída")
                        itensBase = itensBase.Where(p => p.Entrada == false).ToList();
                }

                var itens = itensBase
                    .Select(item =>
                    {
                        var vm = new CaixaViewModel();
                        vm.PreencherCom(item);
                        return vm;
                    })
                    .ToList();

                gridConteudo.DataSource = itens;
                AtualizarTotaisFinanceiro();

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

        private FinanceiroCaixa? CarregarCaixaCompleto(int id)
        {
            return _context.FinanceiroCaixa
                .FirstOrDefault(p => p.Id == id);
        }

        private void FiltrarScrollInfinito()
        {
            if (ultimaPagina) return;

            var itensBase = repo.GetPaged(paginaAtual, registrosPorPagina, noTracking: true)
                .ToList();

            var novos = itensBase
                .Select(item =>
                {
                    var vm = new CaixaViewModel();
                    vm.PreencherCom(item);
                    return vm;
                })
                .ToList();

            if (novos.Count < registrosPorPagina)
                ultimaPagina = true;

            dadosCarregados.AddRange(novos);
            gridConteudo.DataSource = null;
            gridConteudo.DataSource = dadosCarregados.ToList();
            AtualizarTotaisFinanceiro();

            paginaAtual++;
        }

        private void AtualizarDescricaoComSelecionado()
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is CaixaViewModel selecionado)
                lblDescricao.Text = selecionado.Descricao;
            else
                lblDescricao.Text = string.Empty;
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

        private void CaixaForm_Load(object sender, EventArgs e)
        {            
            dadosCarregados.Clear();
            paginaAtual = 0;
            ultimaPagina = false;            
            FiltroCaixaHelper.PreencherTipoMovimentacao(cmbTipoMovimentacao);
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "GerencialGridCaixa");
            FormSettingsHelper.RestaurarConfiguracao(this, "GerencialCaixaForm");
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
        }
        private void AtualizarTotaisFinanceiro()
        {
            if (gridConteudo.DataSource is not List<CaixaViewModel> lista) 
                return;

            decimal total = lista
                .Sum(x => decimal.TryParse(x.Valor.Replace("R$", "").Trim(), out var valor) ? valor : 0);

            decimal totalSaida = lista
                .Where(x => x.Entrada == false)
                .Sum(x => decimal.TryParse(x.Valor.Replace("R$", "").Trim(), out var valor) ? valor : 0);

            decimal totalEntrada = lista
                .Where(x => x.Entrada == true)
                .Sum(x => decimal.TryParse(x.Valor.Replace("R$", "").Trim(), out var valor) ? valor : 0);

            lblTotal.Text = $"Total: {total:C2}";
            lblTotalSaida.Text = $"Saídas: {totalSaida:C2}";
            lblTotalEntrada.Text = $"Entradas: {totalEntrada:C2}";

            lblTotalEntrada.ForeColor = Color.ForestGreen;
            lblTotalSaida.ForeColor = Color.DarkRed;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var formCadastroCaixa = new CaixaCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastroCaixa.ShowDialog() == DialogResult.OK)
            {
                Filtrar(true);
            }
        }

        private void gridConteudo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (gridConteudo.Rows[e.RowIndex].DataBoundItem is CaixaViewModel item)
            {
                var row = gridConteudo.Rows[e.RowIndex];
                
                if (item.Entrada)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void CaixaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "GerencialGridCaixa");
            FormSettingsHelper.SalvarConfiguracao(this, "GerencialCaixaForm");
        }

        private void pnlTotais_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is CaixaViewModel selecionado)
            {
                var item = CarregarCaixaCompleto(selecionado.Id);

                if (item == null)
                {
                    MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                    return;
                }

                var form = new CaixaCadastroForm(_context)
                {
                    Operacao = TipoOperacao.Edicao,
                    itemSelecionado = item
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<FinanceiroCaixa, CaixaViewModel>(item);
                    AtualizarDescricaoComSelecionado();
                    AtualizarTotaisFinanceiro();
                }
            }
        }

        private void btnDetalhe_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {               
                MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is CaixaViewModel selecionado)
            {
                var item = CarregarCaixaCompleto(selecionado.Id);

                if (item == null)
                {
                    MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                    return;
                }

                var form = new CaixaCadastroForm(_context)
                {
                    Operacao = TipoOperacao.Detalhes,
                    itemSelecionado = item                    
                };
                form.ShowDialog();
            }
        }
        private void CaixaForm_KeyDown(object sender, KeyEventArgs e)
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
                    btnCadastrar.PerformClick();
                    break;

                case Keys.F8:
                    btnQuitar.PerformClick();
                    break;
            }
        }
    }
}
