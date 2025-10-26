using Dados.Data;
using Dados.Enums;
using Dados.Helpers;
using Dados.Model.Tributacao;
using Dados.ViewModel.Tributacao;
using Microsoft.EntityFrameworkCore;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.View.Tributacao.CadastroCFOPFormulario;

namespace Visual.View.Tributacao.CFOPFormulario
{
    public partial class TributacaoCFOPForm : Form
    {
        private readonly DataContext _context;
        public TributacaoCFOP ItemSelecionado { get; set; }
        public TributacaoCFOPForm(DataContext context)
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

                var cfops = _context.TributacoesCFOP
                    .AsNoTracking()
                    .MapearFormatado<TributacaoCFOP, TributacaoCFOPViewModel>()
                    .FiltrarComCampos(textoBusca)
                    .ToList();

                gridConteudo.DataSource = cfops;

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
            FormSettingsHelper.RestaurarConfiguracao(this, "SelecaoNCMForm");
            txtBusca.Font = new Font("Arial", 23, FontStyle.Regular);
            lblDescricao.Font = new Font("Arial", 18, FontStyle.Regular);
        }
        private void AtualizarDescricaoComSelecionado()
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoCFOPViewModel selecionado)
                lblDescricao.Text = $"{selecionado.Codigo} - {selecionado.Descricao}";
            else
                lblDescricao.Text = string.Empty;
        }
        private void TributacaoCFOPSelecaoForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "SelecaoGridNCM");
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

            if (gridConteudo.CurrentRow?.DataBoundItem is TributacaoCFOPViewModel selecionado)
            {
                ItemSelecionado = CarregarCFOPCompleto(selecionado.Id);
            }
        }

        private void TributacaoCFOPSelecaoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "SelecaoGridCFOP");
            FormSettingsHelper.SalvarConfiguracao(this, "SelecaoCFOPForm");
        }

        private void TributacaoCFOPSelecaoForm_KeyDown(object sender, KeyEventArgs e)
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
        private TributacaoCFOP? CarregarCFOPCompleto(int id)
        {
            return _context.TributacoesCFOP
                .FirstOrDefault(p => p.Id == id);
        }
        private void btnExcluirCFOP_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoCFOPViewModel selecionado)
            {
                if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) == DialogResult.Yes)
                {
                    try
                    {
                        var item = CarregarCFOPCompleto(selecionado.Id);
                        if (item != null)
                        {
                            _context.TributacoesCFOP.Remove(item);
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

        private void TributacaoCFOPForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();
        }

        private void btnAdicionarCFOP_Click(object sender, EventArgs e)
        {
            var formCadastro = new TributacaoCFOPCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                Filtrar(inclusao: true);
            }
        }

        private void btnAlterarCFOP_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is TributacaoCFOPViewModel selecionado)
            {
                var tributacao = CarregarCFOPCompleto(selecionado.Id);
                var formCadastro = new TributacaoCFOPCadastroForm(_context)
                {
                    ItemSelecionado = tributacao,
                    Operacao = TipoOperacao.Edicao
                };

                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<TributacaoCFOP, TributacaoCFOPViewModel>(tributacao);
                    AtualizarDescricaoComSelecionado();
                }

            }
        }
    }
}
