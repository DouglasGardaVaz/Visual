using Dados.Helpers.Form;
using Microsoft.EntityFrameworkCore;
using Dados.Enums;
using Dados.Model.Cadastro;
using Dados.Data;

namespace Dados.View.Cadastro
{
    public partial class MarcaCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public Marca ItemSelecionado { get; set; }
        public MarcaCadastroForm(DataContext context)
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
                ItemSelecionado = new Marca();
            }
        }
        private void CarregarCampos()
        {
            if (ItemSelecionado == null)
                return;

            txtDescricao.Text = ItemSelecionado.Nome;
            ckAtivo.Checked = ItemSelecionado.Ativo;
        }

        private void MarcaCadastroForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            InicializarNovaMarca();
            CarregarCampos();
        }
        private bool ValidarCamposCadastro()
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("Informe o nome da marca.");
                txtDescricao.Focus();
                return false;
            }

            var nomeMarca = txtDescricao.Text.Trim();

            var existe = _context.Marcas
                .AsNoTracking()
                .Any(g => g.Nome.ToLower() == nomeMarca.ToLower() && g.Id != ItemSelecionado.Id);

            if (existe)
            {
                MensagemHelper.Alerta("Já existe uma marca com esse nome.");
                txtDescricao.Focus();
                return false;
            }
            return true;
        }

        private void AtualizarObjetoMarca()
        {
            if (ItemSelecionado == null)
                ItemSelecionado = new Marca();

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

            AtualizarObjetoMarca();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.Marcas.Add(ItemSelecionado);
                    break;

                case TipoOperacao.Edicao:
                    _context.Entry(ItemSelecionado).State = EntityState.Modified;
                    break;

            }
            _context.SaveChanges();
        }

        private void MarcaCadastroForm_Shown(object sender, EventArgs e)
        {
            txtDescricao.Focus();
        }

        private void MarcaCadastroForm_KeyDown(object sender, KeyEventArgs e)
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
