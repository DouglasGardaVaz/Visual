using Dados.Data;
using Dados.Enums.Pessoa;
using Dados.Helpers;
using Dados.Model.PessoaEnderecoModel;
using Dados.ViewModel.Pessoa;
using Microsoft.EntityFrameworkCore;
using Visual.Constantes.Grids;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;

namespace Visual.View.PessoaSelecaoFormulario
{
    public partial class PessoaSelecaoForm : Form
    {
        private readonly DataContext _context;
        private int paginaAtual = 0;
        private const int registrosPorPagina = 100;
        private bool ultimaPagina = false;
        private List<PessoaViewModel> dadosCarregados = new();
        private bool modoBuscaCompleta = false;

        public TipoCadastroPessoa tipoCadastroPessoa { get; set; }

        public Dados.Model.PessoaModel.Pessoa ItemSelecionado { get; private set; }

        public PessoaSelecaoForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void AjustarLayout()
        {
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, GridConstantes.PessoaSelecaoForm + tipoCadastroPessoa.ToString());
            FormSettingsHelper.RestaurarConfiguracao(this, GridConstantes.PessoaSelecaoForm + tipoCadastroPessoa.ToString());
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);

            switch (tipoCadastroPessoa)
            {
                case TipoCadastroPessoa.Cliente:
                    this.Text = "Seleção de cliente";
                    break;
                case TipoCadastroPessoa.Fornecedor:
                    this.Text = "Seleção de fornecedor";
                    break;
                case TipoCadastroPessoa.Vendedor:
                    this.Text = "Seleção de vendedor";
                    break;
                case TipoCadastroPessoa.Transportadora:
                    this.Text = "Seleção de transportadora";
                    break;
                default:
                    this.Text = "Selecione...";
                    break;
            }
        }

        private void PessoaSelecaoForm_Load(object sender, EventArgs e)
        {
            dadosCarregados.Clear();
            paginaAtual = 0;
            ultimaPagina = false;
            Filtrar();
            AjustarLayout();

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
            if (ultimaPagina) return;

            var query = _context.ViewClienteGerencial.AsNoTracking();
            query = AplicarFiltrosBasicos(query);

            var novos = query
                .OrderBy(c => c.NomeCliente)
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
            gridConteudo.DataSource = null;
            gridConteudo.DataSource = dadosCarregados.ToList();

            paginaAtual++;
        }

        private void Filtrar(bool inclusao = false, bool buscaCompleta = false)
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

                query = query.OrderBy(c => c.NomeCliente);

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

                gridConteudo.DataSource = itens;

                if (itens.Count > 0)
                {
                    gridConteudo.Focus();
                    gridConteudo.ClearSelection();
                    gridConteudo.Rows[0].Cells[0].Selected = true;
                }


            }
            catch (Exception ex)
            {
                MensagemHelper.Erro($"Erro ao filtrar: {ex.Message}");
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                DialogResult = DialogResult.None;
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is PessoaViewModel selecionado)
            {
                ItemSelecionado = _context.Pessoas
                    .Include(p => p.PessoaFisica)
                    .Include(p => p.PessoaJuridica)
                    .Include(p => p.Contatos)
                    .Include(p => p.Enderecos)
                    .Include(p => p.Documentos)
                    .Include(p => p.Adicionais)
                    .FirstOrDefault(p => p.Id == selecionado.Codigo); // Código novo correto!
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        private void gridConteudo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelecionar.PerformClick();
        }

        private void gridConteudo_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarDescricaoComSelecionado();
        }

        private void PessoaSelecaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, GridConstantes.PessoaSelecaoForm + tipoCadastroPessoa.ToString());
            FormSettingsHelper.SalvarConfiguracao(this, GridConstantes.PessoaSelecaoForm + tipoCadastroPessoa.ToString());
        }

        private void PessoaSelecaoForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F3:
                    txtBusca.Focus();
                    break;
                case Keys.F6:
                    btnSelecionar.PerformClick();
                    break;
                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;
            }
        }

        private void gridConteudo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnSelecionar.PerformClick();
                    break;

            }
        }

        private void PessoaSelecaoForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();
        }
    }
}
