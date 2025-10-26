namespace Visual.Helpers.Form.Imagens
{
    public static class ImagemHelper
    {
        /// <summary>
        /// Tenta carregar uma imagem e retorná-la como array de bytes.
        /// </summary>
        /// <param name="caminhoImagem">Caminho completo da imagem.</param>
        /// <returns>Byte array da imagem ou null se falhar.</returns>
        public static byte[] ObterImagemComoBytes(string caminhoImagem)
        {
            if (string.IsNullOrWhiteSpace(caminhoImagem) || !File.Exists(caminhoImagem))
                return null;

            try
            {
                using (var imagem = Image.FromFile(caminhoImagem))
                using (var ms = new MemoryStream())
                {
                    imagem.Save(ms, imagem.RawFormat);
                    return ms.ToArray();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Exibe uma imagem no PictureBox a partir de um caminho.
        /// </summary>
        /// <param name="pictureBox">Componente PictureBox</param>
        /// <param name="caminhoImagem">Caminho da imagem</param>
        public static void ExibirImagem(PictureBox pictureBox, string caminhoImagem)
        {
            if (pictureBox == null || string.IsNullOrWhiteSpace(caminhoImagem))
                return;

            try
            {
                if (File.Exists(caminhoImagem))
                {
                    // Importante: clonar a imagem para liberar o arquivo
                    using (var imgTemp = Image.FromFile(caminhoImagem))
                    {
                        pictureBox.Image = new Bitmap(imgTemp);
                    }
                }
                else
                {
                    pictureBox.Image = null;
                }
            }
            catch
            {
                pictureBox.Image = null;
            }
        }
    }
}
