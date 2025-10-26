using System.Drawing.Printing;

namespace Visual.Helpers.Form
{
    public static class ImpressoraHelper
    {
        /// <summary>
        /// Preenche um ComboBox com todas as impressoras instaladas no sistema.
        /// </summary>
        /// <param name="comboBox">ComboBox a ser alimentado.</param>
        /// <param name="selecionarPadrao">Se true, seleciona a impressora padrão automaticamente.</param>
        public static void PreencherImpressoras(ComboBox comboBox, bool selecionarPadrao = true)
        {
            comboBox.Items.Clear();

            foreach (string impressora in PrinterSettings.InstalledPrinters)
            {
                comboBox.Items.Add(impressora);
            }

            if (selecionarPadrao)
            {
                string padrao = new PrinterSettings().PrinterName;

                if (comboBox.Items.Contains(padrao))
                {
                    comboBox.SelectedItem = padrao;
                }
            }
        }
    }
}
