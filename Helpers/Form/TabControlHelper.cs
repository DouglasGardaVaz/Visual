namespace Visual.Helpers.Form
{
    public static class TabControlHelper
    {
        /// <summary>
        /// Oculta visualmente as abas de um TabControl (estilo Flat)
        /// </summary>
        /// <param name="tabControl">TabControl alvo</param>
        public static void OcultarAbas(this TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }
    }
}
