namespace Dados.View.Saida.CancelamentoDFeFormulario
{
    public partial class CancelamentoDFeForm : Form
    {
        public string justificativa;
        public CancelamentoDFeForm()
        {
            InitializeComponent();
        }

        private bool ValidarPreenchimento()
        {
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarPreenchimento())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelamentoDFeForm_Shown(object sender, EventArgs e)
        {
            txtDescricao.Focus();
        }

        private void CancelamentoDFeForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}
