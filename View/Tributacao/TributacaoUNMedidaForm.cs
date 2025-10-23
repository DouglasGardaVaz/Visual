using Dados.Data;
using Dados.Enums;
using Dados.Helpers;
using Dados.Model.Tributacao;
using Dados.ViewModel.Tributacao;
using Microsoft.EntityFrameworkCore;
using Dados.Constantes.Mensagens.Global;
using Dados.Helpers.Form;
using Dados.Helpers.Grid;
using Dados.View.Tributacao.UNMedidaCadastroFormulario;

namespace Dados.View.Tributacao.UnidadeMedidaFormulario
{
    public partial class TributacaoUNMedidaForm : Form
    {
        private readonly DataContext _context;
        public TributacaoUnidadeMedida ItemSelecionado { get; set; }
        public TributacaoUNMedidaForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void Filtrar(bool inclusao = false)
        {
            try
            {
                var textoBusca = txtBusca.Text?.Trim() ?? string.Empty;

                if (inclusao)
                {
                    txtBusca.Text = string.Empty;
                    textoBusca = string.Empty;
                }

                var UnidadesMedidas = _context.TributacoesUnidadesMedida
                    .AsNoTracking()
                    .MapearFormatado<TributacaoUnidadeMedida, TributacaoUnidadeMedidaViewModel>()
                    .FiltrarComCampos(textoBusca)
                    .ToList();

                gridConteudo.DataSource = UnidadesMedidas;

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
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            GridEnterHelper.HabilitarEnterParaSelecionar(gridConteudo, () => btnSelecionar.PerformClick());
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
            FormSettingsHelper.RestaurarConfiguracao(this, "SelecaoUNMedidaForm");
            txtBusca.Font = new Font("Arial", 23, FontStyle.Regular);
            lblDescricao.Font = new Font("Arial", 18, FontStyle.Regular);
        }
        private void AtualizarDescricaoComSelecionado()
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoUnidadeMedidaViewModel selecionado)
                lblDescricao.Text = $"{selecionado.Codigo} - {selecionado.Descricao}";
            else
                lblDescricao.Text = string.Empty;
        }

        private void TributacaoUNMedidaSelecaoForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "SelecaoGridUNMedida");
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

        private void TributacaoUNMedidaSelecaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "SelecaoGridUNMedida");
            FormSettingsHelper.SalvarConfiguracao(this, "SelecaoUNMedidaForm");
        }

        private void TributacaoUNMedidaSelecaoForm_KeyDown(object sender, KeyEventArgs e)
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
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                DialogResult = DialogResult.None;
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoUnidadeMedidaViewModel selecionado)
            {
                ItemSelecionado = CarregarUNMedidaCompleta(selecionado.Id);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
        private TributacaoUnidadeMedida? CarregarUNMedidaCompleta(int id)
        {
            return _context.TributacoesUnidadesMedida
                .FirstOrDefault(p => p.Id == id);
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoUnidadeMedidaViewModel selecionado)
            {
                if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) == DialogResult.Yes)
                {
                    try
                    {
                        var item = CarregarUNMedidaCompleta(selecionado.Id);
                        if (item != null)
                        {
                            _context.TributacoesUnidadesMedida.Remove(item);
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

        private void TributacaoUNMedidaForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var formCadastro = new TributacaoUNMedidaCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                Filtrar(inclusao: true);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoUnidadeMedidaViewModel selecionado)
            {
                var tributacao = CarregarUNMedidaCompleta(selecionado.Id);
                var formCadastro = new TributacaoUNMedidaCadastroForm(_context)
                {
                    ItemSelecionado = tributacao,
                    Operacao = TipoOperacao.Edicao
                };

                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<TributacaoUnidadeMedida, TributacaoUnidadeMedidaViewModel>(tributacao);
                    AtualizarDescricaoComSelecionado();
                }

            }
        }
    }
}
