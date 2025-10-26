using Dados.Enums;
using Dados.Enums.Pessoa;
using Dados.Helpers.Mascara.RetornarMascara;
using Dados.Helpers.Utils;
using Dados.Model.PessoaEnderecoModel;
using Visual.Helpers.Form;
using Visual.Helpers.Validar.CadastroContatoUtil;

namespace Visual.View.PessoaCadastroContatoFormulario
{
    public partial class PessoaCadastroContatoForm : Form
    {
        public TipoOperacao Operacao { get; set; }
        public PessoaContato ContatoPreenchido { get; set; }
        public PessoaCadastroContatoForm()
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
        }


        private void AjustarFormularioParaOperacao()
        {
            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    Text = "Cadastro de Contato";
                    break;
                case TipoOperacao.Edicao:
                    cmbTipoContato.SelectedValue = (int)ContatoPreenchido.TipoContato;
                    mskContato.Text = ContatoPreenchido.Contato;
                    txtObservacao.Text = ContatoPreenchido.Observacao;
                    Text = "Alteração de Contato";
                    cmbTipoContato.Enabled = false;
                    break;
            }
            cmbTipoContato_SelectedIndexChanged(null, null);
        }

        private void PessoaCadastroContatoForm_Load(object sender, EventArgs e)
        {
            toolTipHint.SetToolTip(btnCancelar, "F4 - Para cancelar o cadastro.");
            toolTipHint.SetToolTip(btnConfirmar, "F6 - Para confirmar o cadastro.");

            cmbTipoContato.PreencherComboBox<TipoContatoPessoa>(usarKeyValue: true);

            AjustarFormularioParaOperacao();
        }

        private void PessoaCadastroContatoForm_KeyDown(object sender, KeyEventArgs e)
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
            if (cmbTipoContato.SelectedValue == null)
            {
                MensagemHelper.Alerta("Informe o tipo de contato.");
                cmbTipoContato.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(mskContato.Text))
            {
                MensagemHelper.Alerta("O campo contato é obrigatório. Por favor, preencha-o.");
                mskContato.Focus();
                return false;
            }

            var tipoContato = (TipoContatoPessoa)(int)cmbTipoContato.SelectedValue;
            var contato = mskContato.Text.Trim();

            switch (tipoContato)
            {
                case TipoContatoPessoa.Email:
                    if (!EmailValidador.ValidarEmail(contato))
                    {
                        MensagemHelper.Alerta("O e-mail informado não é válido.");
                        mskContato.Focus();
                        return false;
                    }
                    break;

                case TipoContatoPessoa.Celular:
                    if (!CelularValidador.ValidarCelular(contato))
                    {
                        MensagemHelper.Alerta("O número de celular informado não é válido.");
                        mskContato.Focus();
                        return false;
                    }
                    break;

                case TipoContatoPessoa.Telefone:
                    if (contato.Length < 10)
                    {
                        MensagemHelper.Alerta("O número de telefone fixo informado não é válido.");
                        mskContato.Focus();
                        return false;
                    }
                    break;

                case TipoContatoPessoa.WhatsApp:
                    if (!CelularValidador.ValidarCelular(contato))
                    {
                        MensagemHelper.Alerta("O número de WhatsApp informado não é válido.");
                        mskContato.Focus();
                        return false;
                    }
                    break;

                case TipoContatoPessoa.Outro:
                    break;
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

            if (Operacao != TipoOperacao.Edicao || ContatoPreenchido == null)
            {
                ContatoPreenchido = new PessoaContato();
            }

            ContatoPreenchido.TipoContato = (TipoContatoPessoa)(int)cmbTipoContato.SelectedValue;
            ContatoPreenchido.Contato = mskContato.Text.Trim();
            ContatoPreenchido.Observacao = txtObservacao.Text.Trim();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmbTipoContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            MascaraHelper.AplicarMascaraTipoContato(mskContato, (TipoContatoPessoa)(int)cmbTipoContato.SelectedValue);
        }

        private void PessoaCadastroContatoForm_Shown(object sender, EventArgs e)
        {
            mskContato.Focus();
        }
    }
}
