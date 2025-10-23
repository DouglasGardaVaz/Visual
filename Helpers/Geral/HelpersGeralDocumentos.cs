namespace Dados.Helpers.Geral.HelpersGeralDocumentos
{
    public static class DocumentoHelper
    {
        public static string ObterCpfFormatado(MaskedTextBox msk)
        {
            return ObterDocumentoFormatado(msk);
        }

        public static string ObterCnpjFormatado(MaskedTextBox msk)
        {
            return ObterDocumentoFormatado(msk);
        }

        private static string ObterDocumentoFormatado(MaskedTextBox msk)
        {
            var originalFormat = msk.TextMaskFormat;
            msk.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;

            // Corrige vírgulas indesejadas em ambientes com cultura pt-BR
            string documento = msk.Text.Replace(",", ".");

            msk.TextMaskFormat = originalFormat;
            return documento;
        }
    }

}
