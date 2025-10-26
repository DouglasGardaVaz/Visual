using System.Reflection;

namespace Visual.Helpers.Grid
{
    public static class DataGridViewSortHelper
    {
        private static string? ultimaColunaOrdenada;
        private static bool ordemCrescente = true;

        public static void OrdenarPorColuna(this DataGridView grid, string nomeColuna)
        {
            if (grid.DataSource is not IEnumerable<object> listaOriginal || string.IsNullOrWhiteSpace(nomeColuna))
                return;

            var tipoItem = listaOriginal.FirstOrDefault()?.GetType();
            if (tipoItem == null) return;

            var prop = tipoItem.GetProperty(nomeColuna, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (prop == null) return;

            if (ultimaColunaOrdenada == nomeColuna)
                ordemCrescente = !ordemCrescente;
            else
                ordemCrescente = true;

            ultimaColunaOrdenada = nomeColuna;

            var novaLista = ordemCrescente
                ? listaOriginal.OrderBy(x => prop.GetValue(x, null)).ToList()
                : listaOriginal.OrderByDescending(x => prop.GetValue(x, null)).ToList();

            grid.DataSource = novaLista;
        }
    }
}
