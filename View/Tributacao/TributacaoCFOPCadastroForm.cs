using Dados.Helpers.Form;
using Microsoft.EntityFrameworkCore;
using Dados.Enums;
using Dados.Data;
using Dados.Model.Tributacao;

namespace Dados.View.TributacaoCadastroCFOPFormulario
{
    public partial class TributacaoCFOPCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public TributacaoCFOP ItemSelecionado { get; set; }
        public TributacaoCFOPCadastroForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            txtCFOP.MaxLength = 4;

        }
        private void InicializarNovoCFOP()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                ItemSelecionado = new TributacaoCFOP();
            }
        }
        private void CarregarCampos()
        {
            if (ItemSelecionado == null)
                return;

            txtDescricao.Text = ItemSelecionado.Descricao;
            txtCFOP.Text = ItemSelecionado.Codigo;
            ckAtivo.Checked = ItemSelecionado.Ativo;
        }

        private void TributacaoCFOPCadastroForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            InicializarNovoCFOP();
            CarregarCampos();
        }

        private void TributacaoCFOPCadastroForm_KeyDown(object sender, KeyEventArgs e)
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

        private bool ValidarCamposCadastro()
        {
            if (string.IsNullOrWhiteSpace(txtCFOP.Text))
            {
                MensagemHelper.Alerta("Informe o código CFOP da tributação.");
                txtCFOP.Focus();
                return false;
            }

            var ncm = txtCFOP.Text.Trim();

            if (ncm.Length < 4)
            {
                MensagemHelper.Alerta("O código CFOP deve conter 4 dígitos.");
                txtCFOP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("Informe a descrição do CFOP.");
                txtDescricao.Focus();
                return false;
            }
            return true;
        }



        private void AtualizarObjetoCFOP()
        {
            if (ItemSelecionado == null)
                ItemSelecionado = new TributacaoCFOP();

            ItemSelecionado.Codigo = txtCFOP.Text.Trim();
            ItemSelecionado.Descricao = txtDescricao.Text.Trim();
            ItemSelecionado.Ativo = ckAtivo.Checked;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AtualizarObjetoCFOP();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.TributacoesCFOP.Add(ItemSelecionado);
                    break;

                case TipoOperacao.Edicao:
                    _context.Entry(ItemSelecionado).State = EntityState.Modified;
                    break;

            }
            _context.SaveChanges();
        }

        private void TributacaoCFOPCadastroForm_Shown(object sender, EventArgs e)
        {
            txtCFOP.Focus();
        }
    }
}
