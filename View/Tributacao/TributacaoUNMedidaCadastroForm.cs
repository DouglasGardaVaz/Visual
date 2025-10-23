using Dados.Data;
using Dados.Enums;
using Dados.Enums.Tributacao;
using Dados.Helpers.Utils;
using Dados.Model.Tributacao;
using Microsoft.EntityFrameworkCore;
using Dados.Helpers.Form;

namespace Dados.View.Tributacao.UNMedidaCadastroFormulario
{
    public partial class TributacaoUNMedidaCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public TributacaoUnidadeMedida ItemSelecionado { get; set; }
        public TributacaoUNMedidaCadastroForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            txtCodigoUN.MaxLength = 10;
            txtDescricao.MaxLength = 100;

        }
        private void InicializarNovaUN()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                ItemSelecionado = new TributacaoUnidadeMedida();
            }
        }
        private void CarregarCampos()
        {
            if (ItemSelecionado == null)
                return;

            txtDescricao.Text = ItemSelecionado.Descricao;
            txtCodigoUN.Text = ItemSelecionado.Codigo;
            cmbTipoUso.SelectedValue = (int)ItemSelecionado.TipoUso;
            ckAtivo.Checked = ItemSelecionado.Ativo;
        }
        private void CarregarComboTipoUso()
        {
            cmbTipoUso.PreencherComboBox<TributacaoTipoUsoUnidadeMedida>(usarKeyValue: true);
        }
           
        private void TributacaoUNMedidaCadastroForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            InicializarNovaUN();
            CarregarComboTipoUso();
            CarregarCampos();
        }

        private void TributacaoUNMedidaCadastroForm_KeyDown(object sender, KeyEventArgs e)
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
            if (string.IsNullOrWhiteSpace(txtCodigoUN.Text))
            {
                MensagemHelper.Alerta("Informe o código da unidade de medida.");
                txtCodigoUN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("Informe a descrição da unidade de medida.");
                txtDescricao.Focus();
                return false;
            }

            if (cmbTipoUso.SelectedValue == null)
            {
                MensagemHelper.Alerta("Selecione o tipo de uso da unidade de medida.");
                cmbTipoUso.Focus();
                return false;
            }

            var codigoUN = txtCodigoUN.Text.Trim();
            var existe = _context.TributacoesUnidadesMedida
                .AsNoTracking()
                .Any(g => g.Codigo.ToLower() == codigoUN.ToLower() && g.Id != ItemSelecionado.Id);

            if (existe)
            {
                MensagemHelper.Alerta("Já existe um cadastro com este código.");
                txtCodigoUN.Focus();
                return false;
            }
            return true;
        }

        private void AtualizarObjetoUN()
        {
            if (ItemSelecionado == null)
                ItemSelecionado = new TributacaoUnidadeMedida();

            ItemSelecionado.Codigo = txtCodigoUN.Text.Trim();
            ItemSelecionado.Descricao = txtDescricao.Text.Trim();
            ItemSelecionado.TipoUso = (TributacaoTipoUsoUnidadeMedida)cmbTipoUso.SelectedValue;
            ItemSelecionado.Ativo = ckAtivo.Checked;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AtualizarObjetoUN();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.TributacoesUnidadesMedida.Add(ItemSelecionado);
                    break;

                case TipoOperacao.Edicao:
                    _context.Entry(ItemSelecionado).State = EntityState.Modified;
                    break;

            }
            _context.SaveChanges();
        }

        private void TributacaoUNMedidaCadastroForm_Shown(object sender, EventArgs e)
        {
            txtCodigoUN.Focus();
        }
    }
}
