using Dados.Constantes;
using Dados.Data;
using Dados.Data.Repositories;
using Dados.Enums;
using Dados.Enums.Financeiro.Receber;
using Dados.Helpers;
using Dados.Model.Financeiro.Receber;
using Dados.ViewModel.Financeiro.Receber;
using Microsoft.EntityFrameworkCore;
using Visual.Constantes.Mensagens.Financeiro;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Combobox.Financeiro.Receber;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.View.Financeiro.ReceberCadastroFormulario;
using Visual.View.Financeiro.ReceberQuitarParcelaFormulario;

namespace Visual.View.Financeiro.ReceberFormulario
{
    public partial class ReceberForm : Form
    {
        private readonly DataContext _context = new();
        private readonly GenericRepository<FinanceiroReceber> repo;
        private int paginaAtual = 0;
        private const int registrosPorPagina = 100;
        private bool ultimaPagina = false;
        private List<FinanceiroReceberViewModel> dadosCarregados = new();
        private bool modoBuscaCompleta = false;

        public ReceberForm()
        {
            InitializeComponent();
            //EstiloGlobal.AplicarEstilo(this);
            repo = new GenericRepository<FinanceiroReceber>(_context);
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

                List<FinanceiroReceber> itensBase;

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
                        itensBase = itensBase.Where(p => p.DataRecebimento.HasValue &&
                                                         p.DataRecebimento.Value.Date >= dataInicio &&
                                                         p.DataRecebimento.Value.Date <= dataFim).ToList();
                }

                if (cmbSituacao.SelectedIndex > 0 && cmbSituacao.SelectedValue is SituacaoReceber situacaoSelecionada)
                {
                    itensBase = itensBase.Where(p => p.Situacao == situacaoSelecionada).ToList();
                }

                var itens = itensBase
                    .Select(item =>
                    {
                        var vm = new FinanceiroReceberViewModel();
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

        private FinanceiroReceber? CarregarReceberCompleto(int id)
        {
            return _context.FinanceiroReceber
                .Include(p => p.Detalhe)
                .Include(p => p.Valores)
                .Include(p => p.Pessoa!.PessoaFisica)
                .Include(p => p.Pessoa!.PessoaJuridica)
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
                    var vm = new FinanceiroReceberViewModel();
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
            if (gridConteudo.CurrentRow?.DataBoundItem is FinanceiroReceberViewModel selecionado)
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
            var registros = _context.FinanceiroReceber
                .Where(p =>
                    p.Situacao == null ||
                    p.Situacao == SituacaoReceber.Aberta ||
                    p.Situacao == SituacaoReceber.Atrasada)
                .ToList();

            var hoje = DateTime.Today.Date;

            foreach (var item in registros)
            {
                if (item.DataRecebimento != null)
                {
                    item.Situacao = item.DataRecebimento > item.DataVencimento
                        ? SituacaoReceber.RecebidaComAtraso
                        : SituacaoReceber.Recebida;
                }
                else if (item.DataVencimento.Date < hoje)
                {
                    item.Situacao = SituacaoReceber.Vencida;
                }
                else
                {
                    item.Situacao = SituacaoReceber.Aberta;
                }
            }

            _context.SaveChanges();
        }

        private void ReceberForm_Load(object sender, EventArgs e)
        {
            AtualizarSituacoesAutomaticamente();
            dadosCarregados.Clear();
            paginaAtual = 0;
            ultimaPagina = false;
            FiltroReceberHelper.PreencherCampoData(cmbCampo);
            FiltroReceberHelper.PreencherSituacoes(cmbSituacao);
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "GerencialGridReceber");
            FormSettingsHelper.RestaurarConfiguracao(this, "GerencialReceberForm");
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
        }
        private void AtualizarTotaisFinanceiro()
        {
            if (gridConteudo.DataSource is not List<FinanceiroReceberViewModel> lista) 
                return;

            decimal totalPaga = lista
                .Where(x => x.Situacao.Equals("Recebida", StringComparison.OrdinalIgnoreCase)
                         || x.Situacao.Equals("RecebidaComAtraso", StringComparison.OrdinalIgnoreCase))
                .Sum(x => decimal.TryParse(x.ValorRecebido.Replace("R$", "").Trim(), out var valor) ? valor : 0);

            decimal totalVencida = lista
                .Where(x => x.Situacao.Equals("Vencida", StringComparison.OrdinalIgnoreCase)
                         || x.Situacao.Equals("Atrasada", StringComparison.OrdinalIgnoreCase))
                .Sum(x => decimal.TryParse(x.ValorParcela.Replace("R$", "").Trim(), out var valor) ? valor : 0);

            decimal totalAberta = lista
                .Where(x => x.Situacao.Equals("Aberta", StringComparison.OrdinalIgnoreCase))
                .Sum(x => decimal.TryParse(x.ValorParcela.Replace("R$", "").Trim(), out var valor) ? valor : 0);

            lblTotalRecebido.Text = $"Recebidas: {totalPaga:C2}";
            lblTotalVencida.Text = $"Vencidas: {totalVencida:C2}";
            lblTotalaReceber.Text = $"Em Aberto: {totalAberta:C2}";

            lblTotalRecebido.ForeColor = Color.ForestGreen;
            lblTotalVencida.ForeColor = Color.DarkRed;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var formCadastroPagar = new ReceberCadastroForm(_context)
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
            if (gridConteudo.Rows[e.RowIndex].DataBoundItem is FinanceiroReceberViewModel item)
            {
                var row = gridConteudo.Rows[e.RowIndex];

                if (Enum.TryParse<SituacaoReceber>(item.Situacao.Replace(" ", ""), true, out var situacaoEnum))
                {
                    switch (situacaoEnum)
                    {
                        case SituacaoReceber.Atrasada:
                            row.DefaultCellStyle.BackColor = Color.Orange;
                            break;

                        case SituacaoReceber.Vencida:
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                            break;

                        case SituacaoReceber.Recebida:
                            row.DefaultCellStyle.BackColor = Color.MediumSeaGreen;
                            break;

                        case SituacaoReceber.RecebidaComAtraso:
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;

                        case SituacaoReceber.Cancelada:
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            break;

                    }
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is not FinanceiroReceberViewModel selecionado)
            {
                MensagemHelper.Alerta(MensagensFinanceiro.ReceberNaoSelecionada);
                return;
            }

            var item = CarregarReceberCompleto(selecionado.Id);

            if (item == null)
            {
                MensagemHelper.Alerta(MensagensFinanceiro.ReceberNaoEncontrada);
                return;
            }

            if (item.Situacao == SituacaoReceber.Cancelada)
            {
                MensagemHelper.Alerta(MensagensFinanceiro.ParcelaCancelada);
                return;
            }

            if (item.Situacao == SituacaoReceber.Recebida || item.Situacao == SituacaoReceber.RecebidaComAtraso)
            {
                MensagemHelper.Alerta(MensagensFinanceiro.ReceberJaRecebida);
                return;
            }

            if (MensagemHelper.Confirmar(MensagensFinanceiro.ReceberConfirmarCancelamento) != DialogResult.Yes)
                return;

            item.Situacao = SituacaoReceber.Cancelada;
            _context.SaveChanges();

            gridConteudo.AtualizarLinha<FinanceiroReceber, FinanceiroReceberViewModel>(item);
            AtualizarDescricaoComSelecionado();
            AtualizarTotaisFinanceiro();

            MensagemHelper.Info(MensagensFinanceiro.ReceberCanceladaComSucesso);
        }

        private void ReceberForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "GerencialGridReceber");
            FormSettingsHelper.SalvarConfiguracao(this, "GerencialReceberForm");

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

            if (gridConteudo.CurrentRow?.DataBoundItem is FinanceiroReceberViewModel selecionado)
            {
                var item = CarregarReceberCompleto(selecionado.Id);

                if (item == null)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ReceberNaoEncontrada);
                    return;
                }

                if (item.Situacao is SituacaoReceber.Recebida or SituacaoReceber.RecebidaComAtraso)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ParcelaQuitada);
                    return;
                }

                if (item.Situacao is SituacaoReceber.Cancelada)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ParcelaCancelada);
                    return;
                }

                var form = new ReceberCadastroForm(_context)
                {
                    itemSelecionado = item,
                    Operacao = TipoOperacao.Edicao
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<FinanceiroReceber, FinanceiroReceberViewModel>(item);
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

            if (gridConteudo.CurrentRow?.DataBoundItem is FinanceiroReceberViewModel selecionado)
            {                
                var item = CarregarReceberCompleto(selecionado.Id);

                if (item == null)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ReceberNaoEncontrada);
                    return;
                }

                var form = new ReceberCadastroForm(_context)
                {
                    itemSelecionado = item,
                    Operacao = TipoOperacao.Detalhes
                };
                form.ShowDialog();
            }
        }

        private void ReceberForm_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show(MensagensComuns.NenhumRegistroSelecionado, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is FinanceiroReceberViewModel selecionado)
            {
                var item = CarregarReceberCompleto(selecionado.Id);

                if (item == null)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ReceberNaoEncontrada);
                    return;
                }
                if (item.Situacao is SituacaoReceber.Recebida or SituacaoReceber.RecebidaComAtraso)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ParcelaQuitada);
                    return;
                }

                if (item.Situacao is SituacaoReceber.Cancelada)
                {
                    MensagemHelper.Alerta(MensagensFinanceiro.ParcelaCancelada);
                    return;
                }
                var form = new ReceberQuitarParcelaForm(_context)
                {
                    itemSelecionado = item
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<FinanceiroReceber, FinanceiroReceberViewModel>(item);
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
                if (gridConteudo.Rows[e.RowIndex].DataBoundItem is FinanceiroReceberViewModel itemVM)
                {
                    if (itemVM.Situacao.Equals("Paga", StringComparison.OrdinalIgnoreCase) ||
                        itemVM.Situacao.Equals("PagaComAtraso", StringComparison.OrdinalIgnoreCase) ||
                        itemVM.Situacao.Equals("Cancelada", StringComparison.OrdinalIgnoreCase))
                    {
                        gridConteudo.CancelEdit();
                        MensagemHelper.Alerta("Não é possível selecionar uma parcela já recebida ou cancelada.");
                        return;
                    }

                    // Salva direto no banco!
                    var entidade = _context.FinanceiroReceber.FirstOrDefault(p => p.Id == itemVM.Id);
                    if (entidade != null)
                    {
                        entidade.Selecionado = !itemVM.Selecionado; // Inverte para refletir clique
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
    }
}
