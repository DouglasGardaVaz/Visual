using Dados.Data;
using Dados.Enums;
using Dados.Model.Cadastro;
using Microsoft.EntityFrameworkCore;
using Dados.Helpers.Form;

namespace Dados.View.Cadastro.GrupoCadastroFormulario
{
    public partial class GrupoCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public Grupo ItemSelecionado { get; set; }
        public GrupoCadastroForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            txtDescricao.MaxLength = 100;

        }
        private void InicializarNovoGrupo()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                ItemSelecionado = new Grupo();
            }
        }
        private void CarregarCampos()
        {
            if (ItemSelecionado == null)
                return;

            txtDescricao.Text = ItemSelecionado.Nome;
            ckAtivo.Checked = ItemSelecionado.Ativo;
        }

        private void GrupoCadastroForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            InicializarNovoGrupo();
            CarregarCampos();
        }
        private bool ValidarCamposCadastro()
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("Informe o nome do grupo.");
                txtDescricao.Focus();
                return false;
            }

            var nomeGrupo = txtDescricao.Text.Trim();

            var existe = _context.Grupos
                .AsNoTracking()
                .Any(g => g.Nome.ToLower() == nomeGrupo.ToLower() && g.Id != ItemSelecionado.Id);

            if (existe)
            {
                MensagemHelper.Alerta("Já existe um grupo com esse nome.");
                txtDescricao.Focus();
                return false;
            }

            return true;
        }

        private void AtualizarObjetoGrupo()
        {
            if (ItemSelecionado == null)
                ItemSelecionado = new Grupo();

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

            AtualizarObjetoGrupo();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.Grupos.Add(ItemSelecionado);
                    break;

                case TipoOperacao.Edicao:
                    _context.Entry(ItemSelecionado).State = EntityState.Modified;
                    break;

            }
            _context.SaveChanges();
        }

        private void GrupoCadastroForm_Shown(object sender, EventArgs e)
        {
            txtDescricao.Focus();
        }

        private void GrupoCadastroForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}
