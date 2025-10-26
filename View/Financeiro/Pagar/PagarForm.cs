using Dados.Data;
using Dados.Data.Repositories;
using Dados.Enums;
using Dados.Enums.Financeiro.Pagar;
using Dados.Helpers;
using Dados.Model.Financeiro.Pagar;
using Dados.ViewModel.Financeiro.Pagar;
using Microsoft.EntityFrameworkCore;
using Visual.Constantes.Mensagens.Financeiro;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Combobox.Financeiro.Pagar;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.View.Financeiro.PagarCadastroFormulario;
using Visual.View.Financeiro.PagarQuitarParcelaFormulario;

namespace Visual.View.Financeiro.PagarFormulario
{
    public partial class PagarForm : Form
    {
        private readonly DataContext _context = new();
        private readonly GenericRepository<FinanceiroPagar> repo;
        private int paginaAtual = 0;
        private const int registrosPorPagina = 100;
        private bool ultimaPagina = false;
        private List<FinanceiroPagarViewModel> dadosCarregados = new();
        private bool modoBuscaCompleta = false;

        public PagarForm()
        {
            InitializeComponent();
            repo = new GenericRepository<FinanceiroPagar>(_context);
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

                List<FinanceiroPagar> itensBase;

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

                if (cmbCampo.SelectedItem is string campoSelecionado)
                {
                    if (campoSelecionado == "Data de vencimento")
                        itensBase = itensBase.Where(p => p.DataVencimento.Date >= dataInicio && p.DataVencimento.Date <= dataFim).ToList();
                    else if (campoSelecionado == "Data de cadastro")
                        itensBase = itensBase.Where(p => p.DataHoraCadastro.Date >= dataInicio && p.DataHoraCadastro.Date <= dataFim).ToList();
                    else if (campoSelecionado == "Data de pagamento")
                        itensBase = itensBase.Where(p => p.DataPagamento.HasValue &&
                                                         p.DataPagamento.Value.Date >= dataInicio &&
                                                         p.DataPagamento.Value.Date <= dataFim).ToList();
                }

                if (cmbSituacao.SelectedIndex > 0 && cmbSituacao.SelectedValue is SituacaoPagar situacaoSelecionada)
                {
                    itensBase = itensBase.Where(p => p.Situacao == situacaoSelecionada).ToList();
                }

                var itens = itensBase
                    .Select(item =>
                    {
                        var vm = new FinanceiroPagarViewModel();
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


        private void FiltrarScrollInfinito()
        {
            if (ultimaPagina) return;

            var itensBase = repo.GetPaged(paginaAtual, registrosPorPagina, noTracking: true)
                .ToList();

            var novos = itensBase
                .Select(item =>
                {
                    var vm = new FinanceiroPagarViewModel();
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
            if (gridConteudo.CurrentRow?.DataBoundItem is FinanceiroPagarViewModel selecionado)
                lblDescricao.Text = $"{selecionado.Documento} - {selecionado.Descricao}";
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

        private void AtualizarSituacoesAutomaticamente()
        {
            var registros = _context.FinanceiroPagar
                .Where(p =>
                    p.Situacao == null ||
                    p.Situacao == SituacaoPagar.Aberta ||
                    p.Situacao == SituacaoPagar.Atrasada)
                .ToList();

            var hoje = DateTime.Today.Date;

            foreach (var item in registros)
            {
                if (item.DataPagamento != null)
                {
                    item.Situacao = item.DataPagamento > item.DataVencimento
                        ? SituacaoPagar.PagaComAtraso
                        : SituacaoPagar.Paga;
                }
                else if (item.DataVencimento.Date < hoje)
                {
                    item.Situacao = SituacaoPagar.Vencida;
                }
                else
                {
                    item.Situacao = SituacaoPagar.Aberta;
                }
            }

            _context.SaveChanges();
        }

        private void PagarForm_Load(object sender, EventArgs e)
        {
            AtualizarSituacoesAutomaticamente();
            dadosCarregados.Clear();
            paginaAtual = 0;
            ultimaPagina = false;
            FiltroPagarHelper.PreencherCampoData(cmbCampo);
            FiltroPagarHelper.PreencherSituacoes(cmbSituacao);
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "GerencialGridPagar");
            FormSettingsHelper.RestaurarConfiguracao(this, "GerencialPagarForm");
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
        }
        private void AtualizarTotaisFinanceiro()
        {
            if (gridConteudo.DataSource is not List<FinanceiroPagarViewModel> lista) return;

            decimal totalPaga = lista
                .Where(x => x.Situacao.Equals("Paga", StringComparison.OrdinalIgnoreCase)
                         || x.Situacao.Equals("PagaComAtraso", StringComparison.OrdinalIgnoreCase))
                .Sum(x => decimal.TryParse(x.ValorPago.Replace("R$", "").Trim(), out var valor) ? valor : 0);

            decimal totalVencida = lista
                .Where(x => x.Situacao.Equals("Vencida", StringComparison.OrdinalIgnoreCase)
                         || x.Situacao.Equals("Atrasada", StringComparison.OrdinalIgnoreCase))
                .Sum(x => decimal.TryParse(x.ValorParcela.Replace("R$", "").Trim(), out var valor) ? valor : 0);

            decimal totalAberta = lista
                .Where(x => x.Situacao.Equals("Aberta", StringComparison.OrdinalIgnoreCase))
                .Sum(x => decimal.TryParse(x.ValorParcela.Replace("R$", "").Trim(), out var valor) ? valor : 0);

            lblTotalPaga.Text = $"Pagas: {totalPaga:C2}";
            lblTotalVencida.Text = $"Vencidas: {totalVencida:C2}";
            lblTotalaPagar.Text = $"Em Aberto: {totalAberta:C2}";

            lblTotalPaga.ForeColor = Color.ForestGreen;
            lblTotalVencida.ForeColor = Color.DarkRed;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var formCadastroPagar = new PagarCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastroPagar.ShowDialog() == DialogResult.OK)
            {
                Filtrar(true);
            }
        }

        private void gridConteudo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (gridConteudo.Rows[e.RowIndex].DataBoundItem is FinanceiroPagarViewModel item)
            {
                var row = gridConteudo.Rows[e.RowIndex];

                if (Enum.TryParse<SituacaoPagar>(item.Situacao.Replace(" ", ""), true, out var situacaoEnum))
                {
                    switch (situacaoEnum)
                    {
                        case SituacaoPagar.Atrasada:
                            row.DefaultCellStyle.BackColor = Color.Orange;
                            break;

                        case SituacaoPagar.Vencida:
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;

                        case SituacaoPagar.Paga:
                            row.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                            break;

                        case SituacaoPagar.PagaComAtraso:
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;

                        case SituacaoPagar.Cancelada:
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            break;

                    }
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is not FinanceiroPagarViewModel selecionado)
            {
                MensagemHelper.Alerta(MensagensFinanceiro.PagarNaoSelecionada);
                return;
            }

            var conta = _context.FinanceiroPagar.FirstOrDefault(p => p.Id == selecionado.Id);

            if (conta == null)
            {
                MensagemHelper.Alerta(MensagensFinanceiro.PagarNaoEncontrada);
                return;
            }

            if (conta.Situacao == SituacaoPagar.Cancelada)
            {
                MensagemHelper.Alerta(MensagensFinanceiro.ParcelaCancelada);
                return;
            }

            if (conta.Situacao == SituacaoPagar.Paga || conta.Situacao == SituacaoPagar.PagaComAtraso)
            {
                MensagemHelper.Alerta(MensagensFinanceiro.PagarJaPaga);
                return;
            }

            if (MensagemHelper.Confirmar(MensagensFinanceiro.PagarConfirmarCancelamento) != DialogResult.Yes)
                return;

            conta.Situacao = SituacaoPagar.Cancelada;
            _context.SaveChanges();

            gridConteudo.AtualizarLinha<FinanceiroPagar, FinanceiroPagarViewModel>(conta);
            AtualizarDescricaoComSelecionado();
            AtualizarTotaisFinanceiro();

            MensagemHelper.Info(MensagensFinanceiro.PagarCanceladaComSucesso);
        }

        private void PagarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "GerencialGridPagar");
            FormSettingsHelper.SalvarConfiguracao(this, "GerencialPagarForm");

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is FinanceiroPagarViewModel selecionado)
            {
                var item = _context.FinanceiroPagar
                                    .Include(p => p.Detalhe)
                                    .Include(p => p.Valores)
                                    .Include(p => p.Pessoa!.PessoaFisica)
                                    .Include(p => p.Pessoa!.PessoaJuridica)
                                    .FirstOrDefault(p => p.Id == selecionado.Id);


                if (item == null)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.PagarNaoEncontrada);
                    return;
                }

                if (item.Situacao is SituacaoPagar.Paga or SituacaoPagar.PagaComAtraso)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ParcelaQuitada);
                    return;
                }

                if (item.Situacao is SituacaoPagar.Cancelada)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ParcelaCancelada);
                    return;
                }

                var form = new PagarCadastroForm(_context)
                {
                    itemSelecionado = item,
                    Operacao = TipoOperacao.Edicao
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<FinanceiroPagar, FinanceiroPagarViewModel>(item);
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

            if (gridConteudo.CurrentRow?.DataBoundItem is FinanceiroPagarViewModel selecionado)
            {
                int idAnterior = selecionado.Id;

                using var contextEdicao = new DataContext();
                var repo = new GenericRepository<FinanceiroPagar>(contextEdicao);
                var item = repo.GetAll().First(e => e.Id == idAnterior);

                if (item == null)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.PagarNaoEncontrada);
                    return;
                }

                var form = new PagarCadastroForm(contextEdicao)
                {
                    itemSelecionado = item,
                    Operacao = TipoOperacao.Detalhes
                };
                form.ShowDialog();
            }
        }

        private void PagarForm_KeyDown(object sender, KeyEventArgs e)
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is FinanceiroPagarViewModel selecionado)
            {
                var item = _context.FinanceiroPagar
                                    .Include(p => p.Detalhe)
                                    .Include(p => p.Valores)
                                    .FirstOrDefault(p => p.Id == selecionado.Id);

                if (item == null)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.PagarNaoEncontrada);
                    return;
                }
                if (item.Situacao is SituacaoPagar.Paga or SituacaoPagar.PagaComAtraso)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ParcelaQuitada);
                    return;
                }

                if (item.Situacao is SituacaoPagar.Cancelada)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ParcelaCancelada);
                    return;
                }
                var form = new PagarQuitarParcelaForm(_context)
                {
                    itemSelecionado = item
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<FinanceiroPagar, FinanceiroPagarViewModel>(item);
                    AtualizarTotaisFinanceiro();
                }

            }
        }

        private void gridConteudo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (gridConteudo.Columns[e.ColumnIndex].DataPropertyName == "Selecionado")
            {
                var cell = gridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (gridConteudo.Rows[e.RowIndex].DataBoundItem is FinanceiroPagarViewModel itemVM)
                {
                    if (itemVM.Situacao.Equals("Paga", StringComparison.OrdinalIgnoreCase) ||
                        itemVM.Situacao.Equals("PagaComAtraso", StringComparison.OrdinalIgnoreCase) ||
                        itemVM.Situacao.Equals("Cancelada", StringComparison.OrdinalIgnoreCase))
                    {
                        gridConteudo.CancelEdit();
                        MensagemHelper.Alerta("Não é possível selecionar uma parcela já paga ou cancelada.");
                        return;
                    }
                    var entidade = _context.FinanceiroPagar.FirstOrDefault(p => p.Id == itemVM.Id);
                    if (entidade != null)
                    {
                        entidade.Selecionado = !itemVM.Selecionado;
                        _context.SaveChanges();
                    }
                }

                gridConteudo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void gridConteudo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            gridConteudo.ReadOnly = gridConteudo.Columns[e.ColumnIndex].DataPropertyName != "Selecionado";
        }

        private void gridConteudo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var nomeColuna = gridConteudo.Columns[e.ColumnIndex].DataPropertyName;
            if (!string.IsNullOrWhiteSpace(nomeColuna))
            {
                gridConteudo.OrdenarPorColuna(nomeColuna);
            }
        }
    }
}
