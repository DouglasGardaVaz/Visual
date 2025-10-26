using Visual.Helpers.Form;

namespace Visual.View.Geral.ProcessamentoFormulario
{
    public partial class ProcessandoForm : Form
    {
        public ProcessandoForm(string mensagem)
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this, isPDV: true);
            lblMensagem.Text = mensagem;
        }

        private void ProcessandoForm_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            lblMensagem.Font = new Font("Arial", 18, FontStyle.Bold);
        }
    }
}
