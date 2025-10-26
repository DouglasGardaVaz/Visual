using Dados.Model.Saida.NotaFiscalModel;
using Visual.Helpers.Form;

namespace Visual.View.Saida.PDV.InutilizacaoDFeFormulario
{
    public partial class InutilizacaoDFeForm : Form
    {
        public string justificativa;
        public int ano;
        public int serie;
        public int numeroInicial;
        public int numeroFinal;

        public NotaFiscal? _notaFiscalSelecionada;
        public InutilizacaoDFeForm()
        {
            InitializeComponent();
        }
        private bool ValidarPreenchimento()
        {

            if (_notaFiscalSelecionada == null)
            {
                if (!int.TryParse(txtAno.Text, out int ano) || ano < 0 || ano > 99)
                {
                    MensagemHelper.Alerta("O campo Ano deve ser um número válido entre 00 e 99.");
                    txtAno.Focus();
                    return false;
                }
                if (!int.TryParse(txtSerie.Text, out int serie) || serie < 0)
                {
                    MensagemHelper.Alerta("O campo Série deve ser um número válido.");
                    txtSerie.Focus();
                    return false;
                }
                if (!int.TryParse(txtNumeroInicial.Text, out int numeroInicial) || numeroInicial < 0)
                {
                    MensagemHelper.Alerta("O campo Número Inicial deve ser um número válido.");
                    txtNumeroInicial.Focus();
                    return false;
                }
                if (!int.TryParse(txtNumeroFinal.Text, out int numeroFinal) || numeroFinal < numeroInicial)
                {
                    MensagemHelper.Alerta("O campo Número Final deve ser um número válido e maior ou igual ao Número Inicial.");
                    txtNumeroFinal.Focus();
                    return false;
                }
            }

            justificativa = txtDescricao.Text?.Trim();
            if (string.IsNullOrWhiteSpace(justificativa))
            {
                MensagemHelper.Alerta("A justificativa não pode estar em branco.");
                txtDescricao.Focus();
                return false;
            }
            if (justificativa.Length < 15)
            {
                MensagemHelper.Alerta("A justificativa deve conter no mínimo 15 caracteres.");
                txtDescricao.Focus();
                return false;
            }

            if (justificativa.Length > 255)
            {
                MensagemHelper.Alerta("A justificativa não pode ultrapassar 255 caracteres.");
                txtDescricao.Focus();
                return false;
            }

            return true;
        }
        
        private void AlimentarVariaveis()
        {
            if (_notaFiscalSelecionada == null)
            {
                ano = int.Parse(txtAno.Text);
                serie = int.Parse(txtSerie.Text);
                numeroInicial = int.Parse(txtNumeroInicial.Text);
                numeroFinal = int.Parse(txtNumeroFinal.Text);
            }
            else
            {
                ano = _notaFiscalSelecionada.DataHoraEmissao?.Year % 100 ?? DateTime.Now.Year % 100;
                serie = _notaFiscalSelecionada.Serie;
                numeroInicial = _notaFiscalSelecionada.Numero;
                numeroFinal = _notaFiscalSelecionada.Numero;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarPreenchimento())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            AlimentarVariaveis();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InutilizacaoDFeForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btnCancelar.PerformClick();
                    break;

                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;

                case Keys.F6:
                    btnConfirmar.Focus();
                    btnConfirmar.PerformClick();
                    break;

            }
        }

        private void InutilizacaoDFeForm_Shown(object sender, EventArgs e)
        {
            if (_notaFiscalSelecionada == null)
                txtAno.Focus();
            else
                txtDescricao.Focus();
        }

        private void PreencherCampos()
        {
            if (_notaFiscalSelecionada != null)
            {
                txtAno.Text = (_notaFiscalSelecionada.DataHoraEmissao?.Year % 100 ?? DateTime.Now.Year % 100).ToString();
                txtSerie.Text = _notaFiscalSelecionada.Serie.ToString() ?? "1";
                txtNumeroInicial.Text = _notaFiscalSelecionada.Numero.ToString() ?? "1";
                txtNumeroFinal.Text = _notaFiscalSelecionada.Numero.ToString() ?? "1";
                lblOperacao.Text = $"Inutilização para a NFC-e {_notaFiscalSelecionada.Numero.ToString().PadLeft(5, '0')}";
            }
            else
            {
                txtAno.Enabled = true;
                txtSerie.Enabled = true;
                txtNumeroInicial.Enabled = true;
                txtNumeroFinal.Enabled = true;
            }
            
        }

        private void AjustarLayout()
        {
            FormHelper.AplicarFormatacaoMonetaria(this);
        }
        private void InutilizacaoDFeForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            PreencherCampos();
        }
    }
}
