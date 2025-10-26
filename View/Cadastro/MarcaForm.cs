using Dados.Data;
using Dados.Enums;
using Dados.Helpers;
using Dados.Model.Cadastro;
using Dados.ViewModel.Cadastro;
using Microsoft.EntityFrameworkCore;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.View.Cadastro.MarcaCadastroFormulario;

namespace Visual.View.Cadastro.MarcaFormulario
{
    public partial class MarcaForm : Form
    {
        private readonly DataContext _context;
        public Marca ItemSelecionado { get; set; }
        public MarcaForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
            GridEnterHelper.HabilitarEnterParaSelecionar(gridConteudo, () => btnSelecionar.PerformClick());
            FormSettingsHelper.RestaurarConfiguracao(this, "SelecaoMarcaForm");
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

                var Marcas = _context.Marcas
                    .AsNoTracking()
                    .MapearFormatado<Marca, MarcaViewModel>()
                    .FiltrarComCampos(textoBusca)
                    .ToList();

                gridConteudo.DataSource = Marcas;

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
        private void MarcaForm_KeyDown(object sender, KeyEventArgs e)
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

        private void MarcaForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            Filtrar();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "SelecaoGridMarca");
        }

        private void MarcaForm_Shown(object sender, EventArgs e)
        {
            txtBusca.Focus();
        }

        private void MarcaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "SelecaoGridMarca");
            FormSettingsHelper.SalvarConfiguracao(this, "SelecaoMarcaForm");
        }

        private Marca? CarregarMarcaCompleta(int id)
        {
            return _context.Marcas
                .FirstOrDefault(p => p.Id == id);
        }
        private void btnExcluirMarca_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaExcluir);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is MarcaViewModel selecionado)
            {
                if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) == DialogResult.Yes)
                {
                    try
                    {
                        var item = CarregarMarcaCompleta(selecionado.Id);
                        if (item != null)
                        {
                            _context.Marcas.Remove(item);
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
            if (gridConteudo.CurrentRow?.DataBoundItem is MarcaViewModel selecionado)
            {
                ItemSelecionado = CarregarMarcaCompleta(selecionado.Id);
            }
        }
        private void AtualizarDescricaoComSelecionado()
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is MarcaViewModel selecionado)
                lblDescricao.Text = selecionado.Nome;
            else
                lblDescricao.Text = string.Empty;
        }
        private void gridConteudo_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarDescricaoComSelecionado();
        }

        private void btnAdicionarMarca_Click(object sender, EventArgs e)
        {
            var formCadastro = new MarcaCadastroForm(_context)
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                Filtrar(inclusao: true);
            }
        }

        private void btnAlterarMarca_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta(MensagensComuns.SelecioneParaAlterar);
                return;
            }

            if (gridConteudo.CurrentRow.DataBoundItem is MarcaViewModel selecionado)
            {
                var marca = CarregarMarcaCompleta(selecionado.Id);
                var formCadastro = new MarcaCadastroForm(_context)
                {
                    ItemSelecionado = marca,
                    Operacao = TipoOperacao.Edicao
                };

                if (formCadastro.ShowDialog() == DialogResult.OK)
                {
                    gridConteudo.AtualizarLinha<Marca, MarcaViewModel>(marca);
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
