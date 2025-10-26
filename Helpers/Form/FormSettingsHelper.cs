using System.Text.Json;
using System.Windows.Forms;

namespace Visual.Helpers.Form
{
    public static class FormSettingsHelper
    {
        private static readonly string PastaForm = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Form");

        public static void SalvarConfiguracao(System.Windows.Forms.Form form, string nome)
        {
            Directory.CreateDirectory(PastaForm);
            var path = Path.Combine(PastaForm, $"{nome}.json");

            var config = new FormConfig
            {
                Width = form.Width,
                Height = form.Height,
                Top = form.Top,
                Left = form.Left,
                WindowState = form.WindowState
            };

            File.WriteAllText(path, JsonSerializer.Serialize(config));
        }

        public static void RestaurarConfiguracao(System.Windows.Forms.Form form, string nome)
        {
            var path = Path.Combine(PastaForm, $"{nome}.json");
            if (!File.Exists(path)) return;

            try
            {
                var json = File.ReadAllText(path);
                var config = JsonSerializer.Deserialize<FormConfig>(json);

                if (config != null)
                {
                    form.StartPosition = FormStartPosition.Manual;
                    form.Width = config.Width;
                    form.Height = config.Height;
                    form.Top = config.Top;
                    form.Left = config.Left;
                    form.WindowState = config.WindowState;
                }
            }
            catch
            {                
            }
        }

        private class FormConfig
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int Top { get; set; }
            public int Left { get; set; }
            public FormWindowState WindowState { get; set; }
        }
    }
}
