using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dados.Helpers.Form;

namespace Dados.View.Geral
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
