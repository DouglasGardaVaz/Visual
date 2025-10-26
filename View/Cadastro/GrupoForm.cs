using Dados.Data;
using Dados.Enums;
using Dados.Helpers;
using Dados.Model.Cadastro;
using Dados.ViewModel.Cadastro;
using Microsoft.EntityFrameworkCore;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.View.Cadastro.GrupoCadastroFormulario;

namespace Visual.View.Cadastro.GrupoFormulario
{
    public partial class GrupoForm : Form
    {
        private readonly DataContext _context;
        public Grupo ItemSelecionado { get; set; }
        public GrupoForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
            GridEnterHelper.HabilitarEnterParaSelecionar(gridConteudo, () => btnSelecionar.PerformClick());
            FormSettingsHelper.RestaurarConfiguracao(this, "SelecaoGrupoForm");
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

                var Grupos = _context.Grupos
                    .AsNoTracking()
                    .MapearFormatado<Grupo, GrupoViewModel>()
                    .FiltrarComCampos(textoBusca)
                    .ToList();

                gridConteudo.DataSource = Grupos;

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
        private void GrupoForm_KeyDown(object sender, KeyEventArgs e)
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

        private void GrupoForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "SelecaoGridGrupo");
        }

        private void GrupoForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();
        }

        private void GrupoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "SelecaoGridGrupo");
            FormSettingsHelper.SalvarConfiguracao(this, "SelecaoGrupoForm");
        }

        private Grupo? CarregarGrupoCompleto(int id)
        {
            return _context.Grupos
                .Include(p => p.Subgrupos)
                .FirstOrDefault(p => p.Id == id);
        }
        private void btnExcluirGrupo_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is GrupoViewModel selecionado)
            {
                if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) == DialogResult.Yes)
                {
                    try
                    {
                        var item = CarregarGrupoCompleto(selecionado.Id);
                        if (item != null)
                        {
                            _context.Grupos.Remove(item);
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
            if (gridConteudo.CurrentRow?.DataBoundItem is GrupoViewModel selecionado)
            {
                ItemSelecionado = CarregarGrupoCompleto(selecionado.Id);
            }
        }
        private void AtualizarDescricaoComSelecionado()
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is GrupoViewModel selecionado)
                lblDescricao.Text = selecionado.Nome;
            else
                lblDescricao.Text = string.Empty;
        }
        private void gridConteudo_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarDescricaoComSelecionado();
        }

        private void btnAdicionarGrupo_Click(object sender, EventArgs e)
        {
            var formCadastro = new GrupoCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                Filtrar(inclusao: true);
            }
        }

        private void btnAlterarGrupo_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is GrupoViewModel selecionado)
            {
                var grupo = CarregarGrupoCompleto(selecionado.Id);
                var formCadastro = new GrupoCadastroForm(_context)
                {
                    ItemSelecionado = grupo,
                    Operacao = TipoOperacao.Edicao
                };

                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<Grupo, GrupoViewModel>(grupo);
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
