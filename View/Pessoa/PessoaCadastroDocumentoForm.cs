using Dados.Enums;
using Dados.Enums.Pessoa;
using Dados.Helpers.Mascara.RetornarMascara;
using Dados.Helpers.Utils;
using Dados.Model.PessoaDocumentoModel;
using Visual.Helpers.Form;

namespace Visual.View.PessoaCadastroDocumentoFormulario
{
    public partial class PessoaCadastroDocumentoForm : Form
    {
        public TipoPessoa TipoPessoaDaEntidade { get; set; }
        public List<PessoaDocumento> DocumentosExistentes { get; set; } = new();
        public TipoOperacao Operacao { get; set; }
        public PessoaDocumento DocumentoPreenchido { get; set; }

        public PessoaCadastroDocumentoForm()
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
        }
        private void AjustarFormularioParaOperacao()
        {
            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    Text = "Cadastro de Documento";
                    break;
                case TipoOperacao.Edicao:
                    cmbTipoDocumento.SelectedValue = (int)DocumentoPreenchido.TipoDocumentoPessoa;
                    mskDocumento.Text = DocumentoPreenchido.Documento;
                    Text = "Alteração de Documento";
                    cmbTipoDocumento.Enabled = false;
                    break;
            }
            cmbTipoDocumento_SelectedIndexChanged(null, null);
        }

        private void PessoaCadastroDocumentoForm_Load(object sender, EventArgs e)
        {
            toolTipHint.SetToolTip(btnCancelar, "F4 - Para cancelar o cadastro.");
            toolTipHint.SetToolTip(btnConfirmar, "F6 - Para confirmar o cadastro.");

            cmbTipoDocumento.PreencherComboBox<TipoDocumentoPessoa>(usarKeyValue: true);

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    cmbTipoDocumento.FiltrarComboBoxDocumentoPorTipoPessoaEExistentes(TipoPessoaDaEntidade, DocumentosExistentes);
                    break;
                case TipoOperacao.Edicao:
                    break;
            }

            AjustarFormularioParaOperacao();
        }

        private void PessoaCadastroDocumentoForm_KeyDown(object sender, KeyEventArgs e)
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

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            MascaraHelper.AplicarMascaraTipoDocumento(mskDocumento, (TipoDocumentoPessoa)(int)cmbTipoDocumento.SelectedValue);
        }

        private bool ValidarCamposCadastro()
        {
            if (cmbTipoDocumento.SelectedValue == null)
            {
                MensagemHelper.Alerta("Informe o tipo de documento.");
                cmbTipoDocumento.Focus();
                return false;
            }

            string documento = mskDocumento.Text.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("/", "");

            if (string.IsNullOrWhiteSpace(documento))
            {
                MensagemHelper.Alerta("O campo documento é obrigatório. Por favor, preencha-o.");
                mskDocumento.Focus();
                return false;
            }
            return true;
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }

            if (Operacao != TipoOperacao.Edicao || DocumentoPreenchido == null)
            {
                DocumentoPreenchido = new PessoaDocumento();
            }

            DocumentoPreenchido.TipoDocumentoPessoa = (TipoDocumentoPessoa)(int)cmbTipoDocumento.SelectedValue;
            DocumentoPreenchido.Documento = mskDocumento.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PessoaCadastroDocumentoForm_Shown(object sender, EventArgs e)
        {
            mskDocumento.Focus();
        }
    }
}
