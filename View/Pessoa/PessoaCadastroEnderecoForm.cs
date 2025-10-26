using Dados.Enums;
using Dados.Enums.Cadastro;
using Dados.Helpers.Geral.HelpersGeralComponentes;
using Dados.Helpers.Localizacao;
using Dados.Helpers.Mascara.RetornarMascara;
using Dados.Helpers.Utils;
using Dados.Model.PessoaEnderecoModel;
using Visual.Helpers.Form;

namespace Visual.View.Pessoa.CadastroEnderecoFormulario
{
    public partial class PessoaCadastroEnderecoForm : Form
    {
        public TipoOperacao Operacao { get; set; }
        public PessoaEndereco EnderecoPreenchido { get; set; }
        public PessoaCadastroEnderecoForm()
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
        }

        private void AjustarFormularioParaOperacao()
        {
            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    Text = "Cadastro de Endereço";
                    break;
                case TipoOperacao.Edicao:
                    txtComplemento.Text = EnderecoPreenchido.Complemento;
                    txtLogradouro.Text = EnderecoPreenchido.Logradouro;
                    txtNumero.Text = EnderecoPreenchido.Numero;
                    txtBairro.Text = EnderecoPreenchido.Bairro;
                    mskCEP.Text = EnderecoPreenchido.Cep;
                    cmbUF.Text = EnderecoPreenchido.UF;
                    cmbCidade.Text = EnderecoPreenchido.Cidade;
                    Text = "Alteração de Endereço";
                    HelpersGeralComp.DefinirComboBoxIndex(cmbUF, EnderecoPreenchido.UF);
                    HelpersGeralComp.DefinirComboBoxIndex(cmbCidade, EnderecoPreenchido.Cidade);
                    cmbTipoEndereco.SelectedValue = EnderecoPreenchido.TipoEndereco;

                    break;
            }
            MascaraHelper.AplicarMascaraCEP(mskCEP);
        }
        private void PessoaCadastroEnderecoForm_Load(object sender, EventArgs e)
        {
            toolTipHint.SetToolTip(mskCEP, "Pressione F3 para consultar o CEP.");
            toolTipHint.SetToolTip(btnCancelar, "F4 - Para cancelar o cadastro.");
            toolTipHint.SetToolTip(btnConfirmar, "F6 - Para confirmar o cadastro.");
            UfHelper.CarregarUFs(cmbUF, ufSelecionada =>
            {
                CidadeHelper.CarregarCidadesPorUF(cmbCidade, ufSelecionada);
            });

            cmbTipoEndereco.PreencherComboBox<TipoEndereco>(usarKeyValue: true);
            AjustarFormularioParaOperacao();
        }

        private void cmbUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUF.SelectedItem != null)
            {
                string ufSelecionada = cmbUF.SelectedValue.ToString();
                CidadeHelper.CarregarCidadesPorUF(cmbCidade, ufSelecionada);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Operacao != TipoOperacao.Edicao || EnderecoPreenchido == null)
            {
                EnderecoPreenchido = new PessoaEndereco();
            }

            EnderecoPreenchido.Complemento = txtComplemento.Text.Trim();
            EnderecoPreenchido.Logradouro = txtLogradouro.Text.Trim();
            EnderecoPreenchido.Complemento = txtComplemento.Text.Trim();
            EnderecoPreenchido.Numero = txtNumero.Text;
            EnderecoPreenchido.Bairro = txtBairro.Text;
            EnderecoPreenchido.Cep = mskCEP.Text;
            EnderecoPreenchido.Cidade = cmbCidade.Text;
            EnderecoPreenchido.UF = cmbUF.Text;
            EnderecoPreenchido.CodigoMunicipioIBGE = cmbCidade.SelectedValue.ToString();
            EnderecoPreenchido.TipoEndereco = (int)cmbTipoEndereco.SelectedValue;
        }

        private void PreencherCampos(string logradouro, string bairro, string cidade, string uf, string complemento)
        {
            txtLogradouro.Text = logradouro;
            txtBairro.Text = bairro;
            HelpersGeralComp.DefinirComboBoxIndex(cmbUF, uf);
            HelpersGeralComp.DefinirComboBoxIndex(cmbCidade, cidade);
            if (!string.IsNullOrEmpty(complemento))
            {
                txtComplemento.Text = complemento;
            }
        }

        private async void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            await CepHelper.ConsultarCEP(sender, e, PreencherCampos);
        }

        private void PessoaCadastroEnderecoForm_KeyDown(object sender, KeyEventArgs e)
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

        private void PessoaCadastroEnderecoForm_Shown(object sender, EventArgs e)
        {
            mskCEP.Focus();
        }
    }
}
