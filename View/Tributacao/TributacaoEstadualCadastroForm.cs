using Dados.Data;
using Dados.Enums;
using Dados.Model.Tributacao;
using Microsoft.EntityFrameworkCore;
using Dados.Helpers.Form;
using Dados.View.TributacaoCFOPFormulario;

namespace Dados.View.TributacaoEstadualCadastroFormulario
{
    public partial class TributacaoEstadualCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public TributacaoEstadual ItemSelecionado { get; set; }
        public TributacaoEstadualCadastroForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void TributacaoEstadualCadastroForm_KeyDown(object sender, KeyEventArgs e)
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
        private void InicializarNovaTributacao()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                ItemSelecionado = new TributacaoEstadual();
            }
        }
        private void CarregarCombos()
        {
            cmbCSTCSOSN.PreencherComboComDbSet<TributacaoCSOSN>(_context, x => $"{x.Codigo} - {x.Descricao}", x => x.Codigo);
        }
        private void CarregarCampos()
        {
            if (ItemSelecionado == null)
            {
                return;
            }
            txtDescricao.Text = ItemSelecionado.Nome;
            txtAliquotaICMS.Text = ItemSelecionado.AliquotaICMS?.ToString("F2");
            cmbCSTCSOSN.SelectedValue = ItemSelecionado.CSOSNCodigo ?? "";

            var cfop = ObterCFOP(ItemSelecionado.CFOPCodigo);

            txtCFOP.Text = cfop != null ? cfop.Codigo : ItemSelecionado.CFOPCodigo ?? string.Empty;
            txtDescricaoCFOP.Text = cfop != null ? cfop.Descricao : string.Empty;
        }

        private TributacaoCFOP ObterCFOP(string CodigoCFOP)
        {
            return _context.Set<TributacaoCFOP>().FirstOrDefault(x => x.Codigo == CodigoCFOP);
        }
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            txtCFOP.MaxLength = 4;
            txtDescricaoCFOP.Enabled = false;
            txtDescricaoCFOP.CharacterCasing = CharacterCasing.Normal;
            txtDescricaoCFOP.Font = new Font("Arial", 10, FontStyle.Regular);
        }
        private void TributacaoEstadualCadastroForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            InicializarNovaTributacao();
            CarregarCombos();
            CarregarCampos();
        }
        private bool ValidarCamposCadastro()
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("Informe a descrição da tributação.");
                txtDescricao.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCFOP.Text))
            {
                MensagemHelper.Alerta("Informe o CFOP da tributação.");
                txtCFOP.Focus();
                return false;
            }
            var cfop = ObterCFOP(txtCFOP.Text);
            if (cfop == null)
            {
                MensagemHelper.Alerta("CFOP inválido.");
                txtCFOP.Focus();
                return false;
            }

            return true;
        }
        private void AtualizarObjetoTributacao()
        {
            if (ItemSelecionado == null)
                ItemSelecionado = new TributacaoEstadual();

            ItemSelecionado.Nome = txtDescricao.Text.Trim();
            ItemSelecionado.CSOSNCodigo = cmbCSTCSOSN.SelectedValue?.ToString();
            ItemSelecionado.AliquotaICMS = decimal.TryParse(txtAliquotaICMS.Text, out var aliqICMS) ? aliqICMS : 0;
            ItemSelecionado.CFOPCodigo = txtCFOP.Text.Trim();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AtualizarObjetoTributacao();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.TributacoesEstaduais.Add(ItemSelecionado);
                    break;

                case TipoOperacao.Edicao:
                    _context.Entry(ItemSelecionado).State = EntityState.Modified;
                    break;
            }

            _context.SaveChanges();
        }

        private void pbBuscaCFOP_Click(object sender, EventArgs e)
        {
            var formSelecaoCFOP = new TributacaoCFOPForm(_context);

            if (formSelecaoCFOP.ShowDialog() == DialogResult.OK)
            {
                var CFOPSelecionado = formSelecaoCFOP.ItemSelecionado;
                txtCFOP.Text = CFOPSelecionado.Codigo;
                txtDescricaoCFOP.Text = CFOPSelecionado.Descricao;
            }
        }

        private void txtCFOP_KeyUp(object sender, KeyEventArgs e)
        {
            string codigo = txtCFOP.Text.Trim();

            if (codigo.Length == 4)
            {
                var cfop = ObterCFOP(codigo);

                if (cfop != null)
                {
                    txtDescricaoCFOP.Text = cfop.Descricao;
                }
                else
                {
                    txtDescricaoCFOP.Text = string.Empty;
                }
            }
            else
            {
                txtDescricaoCFOP.Text = string.Empty;
            }
        }
    }
}
