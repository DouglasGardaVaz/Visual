using Dados.Helpers.Utils;

namespace Dados.Helpers.Form.Helper
{
    public static class FormHelper
    {
        public static void AplicarFormatacaoMonetaria(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox tb && tb.Tag is string tag)
                {
                    if (tag.Equals("valor2", StringComparison.OrdinalIgnoreCase))
                    {
                        tb.FormatarCampoMonetario(2);
                        tb.KeyPress += Tb_KeyPressMonetario;
                    }
                    else if (tag.Equals("valor4", StringComparison.OrdinalIgnoreCase))
                    {
                        tb.FormatarCampoMonetario(4);
                        tb.KeyPress += Tb_KeyPressMonetario;
                    }
                    else if (tag.Equals("numero", StringComparison.OrdinalIgnoreCase))
                    {
                        tb.KeyPress += Tb_KeyPressNumerico;
                    }
                }

                if (ctrl.HasChildren)
                    AplicarFormatacaoMonetaria(ctrl);
            }
        }

        public static void Tb_KeyPressMonetario(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            var tb = sender as TextBox;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (tb.Text.Contains('.') || tb.Text.Contains(',')))
            {
                e.Handled = true;
            }
        }

        private static void Tb_KeyPressNumerico(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// Aplica maximização respeitando a área de trabalho (sem cobrir a barra de tarefas).
        /// Ideal para PDV ou aplicações de tela cheia controlada.
        /// </summary>
        /// <param name="form">Formulário a ser ajustado.</param>
        public static void AplicarMaximizacaoSegura(System.Windows.Forms.Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.MinimizeBox = true;
            form.ControlBox = true;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.WindowState = FormWindowState.Maximized;
        }

        public static void AplicarTelaCheiaComTaskbar(System.Windows.Forms.Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.ControlBox = false; // Remove todos os botões do sistema
            form.StartPosition = FormStartPosition.Manual;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            // Obtém a área de trabalho disponível (sem barra de tarefas)
            Rectangle workingArea = Screen.FromControl(form).WorkingArea;

            form.Bounds = workingArea;
        }
    }
}
