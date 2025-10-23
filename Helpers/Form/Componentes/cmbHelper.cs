namespace Dados.Helpers.Form.Componentes
{
    public static class cmbHelper   
    {
        /// <summary>
        /// Seleciona no ComboBox o item cujo texto corresponde exatamente ao nome salvo (case-insensitive).
        /// </summary>
        public static void SelecionarItemPorTexto(ComboBox comboBox, string textoSalvo)
        {
            if (string.IsNullOrWhiteSpace(textoSalvo) || comboBox.Items.Count == 0)
                return;

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i].ToString().Equals(textoSalvo, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }

            // Se não encontrou, tenta selecionar o primeiro (opcional)
            // comboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Retorna o texto completo do item selecionado, mesmo que o ComboBox esteja cortando visualmente.
        /// </summary>
        public static string ObterTextoCompletoSelecionado(ComboBox comboBox)
        {
            return comboBox.SelectedItem?.ToString() ?? string.Empty;
        }
    }
}
