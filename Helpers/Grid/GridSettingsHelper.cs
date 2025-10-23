using System.Text.Json;
using System.Windows.Forms;

namespace Dados.Helpers.Grid
{
    public static class GridSettingsHelper
    {
        private static readonly string PastaGrid = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Grid");
        public static void SalvarConfiguracao(DataGridView grid, string nomeGrid)
        {
            Directory.CreateDirectory(PastaGrid);
            var path = Path.Combine(PastaGrid, $"{nomeGrid}.json");

            var settings = grid.Columns
                .Cast<DataGridViewColumn>()
                .OrderBy(c => c.DisplayIndex)
                .Select(c => new GridColunaConfig
                {
                    Nome = c.Name,
                    Largura = c.Width,
                    DisplayIndex = c.DisplayIndex,
                    Order = grid.SortedColumn?.Name == c.Name ? grid.SortOrder.ToString() : null
                }).ToList();

            File.WriteAllText(path, JsonSerializer.Serialize(settings));
        }

        public static void RestaurarConfiguracao(DataGridView grid, string nomeGrid)
        {
            var path = Path.Combine(PastaGrid, $"{nomeGrid}.json");

            if (!File.Exists(path)) return;

            try
            {
                var json = File.ReadAllText(path);
                var settings = JsonSerializer.Deserialize<List<GridColunaConfig>>(json);

                if (settings == null) return;

                foreach (var config in settings)
                {
                    var coluna = grid.Columns[config.Nome];
                    if (coluna != null)
                    {
                        coluna.Width = config.Largura;
                        coluna.DisplayIndex = config.DisplayIndex;
                    }
                }

                // Aplicar ordenação se existir
                var colunaOrdenada = settings.FirstOrDefault(s => !string.IsNullOrEmpty(s.Order));
                if (colunaOrdenada != null)
                {
                    var coluna = grid.Columns[colunaOrdenada.Nome];
                    if (coluna != null)
                    {
                        grid.Sort(coluna, colunaOrdenada.Order == "Ascending"
                            ? System.ComponentModel.ListSortDirection.Ascending
                            : System.ComponentModel.ListSortDirection.Descending);
                    }
                }
            }
            catch (Exception)
            {               
            }
        }


        private class GridColunaConfig
        {
            public string Nome { get; set; }
            public int Largura { get; set; }
            public int DisplayIndex { get; set; }
            public string? Order { get; set; }
        }
    }
}
