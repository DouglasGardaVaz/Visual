using Dados.Data;
using Dados.Enums;
using Dados.Model.Cadastro;
using Microsoft.EntityFrameworkCore;
using Dados.Helpers.Form;
using Dados.View.Cadastro.GrupoFormulario;

namespace Dados.View.Cadastro.SubgrupoCadastroFormulario
{
    public partial class SubGrupoCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public Subgrupo ItemSelecionado { get; set; }
        public SubGrupoCadastroForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            txtDescricao.MaxLength = 100;

        }
        private void InicializarNovaMarca()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                ItemSelecionado = new Subgrupo();
            }
        }
        private void CarregarCampos()
        {
            if (ItemSelecionado == null)
                return;

            txtDescricao.Text = ItemSelecionado.Nome;
            txtGrupo.Text = ItemSelecionado.Grupo.Nome;
            ckAtivo.Checked = ItemSelecionado.Ativo;
        }

        private void SubGrupoCadastroForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            InicializarNovaMarca();
            CarregarCampos();
        }
        private bool ValidarCamposCadastro()
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("Informe o nome do subgrupo.");
                txtDescricao.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGrupo.Text))
            {
                MensagemHelper.Alerta("Informe o grupo do subgrupo.");
                return false;
            }

            var nomeSubgrupo = txtDescricao.Text.Trim();
            int.TryParse(txtGrupo.Text, out var grupoId);

            var existe = _context.Subgrupos
                .AsNoTracking()
                .Any(g => g.Nome.ToLower() == nomeSubgrupo.ToLower()
                        && g.Id != ItemSelecionado.Id &&
                        g.GrupoId == grupoId);

            if (existe)
            {
                MensagemHelper.Alerta("Já existe um subgrupo com este nome.");
                txtDescricao.Focus();
                return false;
            }
            return true;
        }

        private void AtualizarObjetoSubGrupo()
        {
            if (ItemSelecionado == null)
                ItemSelecionado = new Subgrupo();

            ItemSelecionado.Nome = txtDescricao.Text.Trim();
            ItemSelecionado.Ativo = ckAtivo.Checked;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AtualizarObjetoSubGrupo();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.Subgrupos.Add(ItemSelecionado);
                    break;

                case TipoOperacao.Edicao:
                    _context.Entry(ItemSelecionado).State = EntityState.Modified;
                    break;

            }
            _context.SaveChanges();
        }

        private void SubGrupoCadastroForm_Shown(object sender, EventArgs e)
        {
            txtDescricao.Focus();
        }

        private void SubGrupoCadastroForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F6:
                    btnConfirmar.PerformClick();
                    break;
                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;
            }
        }

        private void pbBuscaGrupo_Click(object sender, EventArgs e)
        {
            var formGrupo = new GrupoForm(_context);

            if (formGrupo.ShowDialog() == DialogResult.OK)
            {
                txtGrupo.Text = formGrupo.ItemSelecionado.Nome;
                ItemSelecionado.GrupoId = formGrupo.ItemSelecionado.Id;
            }
            else
            {
                txtGrupo.Text = string.Empty;
            }
        }
    }
}
