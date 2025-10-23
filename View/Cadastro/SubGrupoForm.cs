using Dados.Constantes.Mensagens.Global;
using Dados.Helpers.Form;
using Dados.Helpers.Grid;
using Microsoft.EntityFrameworkCore;
using Dados.Helpers.Grid;
using Dados.View.Cadastro.SubgrupoCadastroFormulario;
using Dados.Enums;
using Dados.Helpers;
using Dados.Data;
using Dados.Model.Cadastro;

namespace Dados.View.Cadastro.SubgrupoFormulario
{
    public partial class SubGrupoForm : Form
    {
        private readonly DataContext _context;
        public Subgrupo ItemSelecionado { get; set; }
        public SubGrupoForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
            GridEnterHelper.HabilitarEnterParaSelecionar(gridConteudo, () => btnSelecionar.PerformClick());
            FormSettingsHelper.RestaurarConfiguracao(this, "SelecaoSubGrupoForm");
            txtBusca.Font = new Font("Arial", 23, FontStyle.Regular);
            lblDescricao.Font = new Font("Arial", 18, FontStyle.Regular);
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

                var subGrupos = _context.Subgrupos
                    .Include(s => s.Grupo)
                    .AsNoTracking()
                    .MapearFormatado<Subgrupo, SubgrupoViewModel>()
                    .FiltrarComCampos(textoBusca)
                    .ToList();

                gridConteudo.DataSource = subGrupos;

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
        private void SubGrupoForm_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Filtrar();
            }
        }

        private void SubGrupoForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "SelecaoGridSubGrupo");
        }

        private void SubGrupoForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();
        }

        private void SubGrupoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "SelecaoGridSubGrupo");
            FormSettingsHelper.SalvarConfiguracao(this, "SelecaoSubGrupoForm");
        }

        private Subgrupo? CarregarSubGrupoCompleto(int id)
        {
            return _context.Subgrupos
                .Include(s => s.Grupo)
                .FirstOrDefault(p => p.Id == id);
        }
        private void btnExcluirSubGrupo_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is SubgrupoViewModel selecionado)
            {
                if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) == DialogResult.Yes)
                {
                    try
                    {
                        var item = CarregarSubGrupoCompleto(selecionado.Id);
                        if (item != null)
                        {
                            _context.Subgrupos.Remove(item);
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

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                DialogResult = DialogResult.None;
                return;
            }
            if (gridConteudo.CurrentRow?.DataBoundItem is SubgrupoViewModel selecionado)
            {
                ItemSelecionado = CarregarSubGrupoCompleto(selecionado.Id);
            }
        }
        private void AtualizarDescricaoComSelecionado()
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is SubgrupoViewModel selecionado)
                lblDescricao.Text = selecionado.Nome;
            else
                lblDescricao.Text = string.Empty;
        }
        private void gridConteudo_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarDescricaoComSelecionado();
        }

        private void btnAdicionarSubGrupo_Click(object sender, EventArgs e)
        {
            var formCadastro = new SubGrupoCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                Filtrar(inclusao: true);
            }
        }

        private void btnAlterarSubGrupo_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is SubgrupoViewModel selecionado)
            {
                var subGrupo = CarregarSubGrupoCompleto(selecionado.Id);
                var formCadastro = new SubGrupoCadastroForm(_context)
                {
                    ItemSelecionado = subGrupo,
                    Operacao = TipoOperacao.Edicao
                };

                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<Subgrupo, SubgrupoViewModel>(subGrupo);
                    AtualizarDescricaoComSelecionado();
                }

            }
        }

        private void gridConteudo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelecionar.PerformClick();
        }
    }
}
