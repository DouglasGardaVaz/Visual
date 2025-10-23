using System.Windows.Forms;

namespace Dados.Helpers.Form
{
    public static class FolderHelper
    {
        // Já existente
        public static void SelecionarPasta(TextBox textBoxDestino, string descricao = "Selecione a pasta desejada:")
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = descricao;
                dialog.ShowNewFolderButton = true;

                if (!string.IsNullOrWhiteSpace(textBoxDestino.Text))
                {
                    try { dialog.SelectedPath = textBoxDestino.Text; } catch { }
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDestino.Text = dialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Abre um seletor de arquivos de imagem e define o caminho no TextBox informado.
        /// </summary>
        /// <param name="textBoxDestino">TextBox que receberá o caminho do arquivo de imagem.</param>
        /// <param name="titulo">Título opcional da janela de seleção.</param>
        public static void SelecionarImagem(TextBox textBoxDestino, string titulo = "Selecione uma imagem:")
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = titulo;
                dialog.Filter = "Imagens (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;

                if (!string.IsNullOrWhiteSpace(textBoxDestino.Text))
                {
                    try { dialog.FileName = textBoxDestino.Text; } catch { }
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxDestino.Text = dialog.FileName;
                }
            }
        }
    }
}
