namespace Dados.Helpers.Geral.HelpersGeralComponentes
{
    public static class HelpersGeralComp
    {
        public static void DefinirComboBoxIndex(ComboBox comboBox, string valorSelecionado)
        {
            // Verifica se o ComboBox possui itens
            if (comboBox.Items.Count > 0)
            {
                // Tenta encontrar o índice exato do valor na lista do ComboBox
                int index = comboBox.FindStringExact(valorSelecionado);

                if (index != -1)
                {
                    // Se o valor foi encontrado, seleciona o índice correspondente
                    comboBox.SelectedIndex = index;
                }
                else
                {
                    // Se o valor não foi encontrado, definimos o Text diretamente
                    comboBox.Text = valorSelecionado;
                    comboBox.SelectedIndex = -1; // Desmarcar a seleção se o valor não existir
                }
            }
        }
    }
}
