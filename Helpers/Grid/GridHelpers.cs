using System.Reflection;

namespace Visual.Helpers.Grid
{
    public static class GridEnterHelper
    {
        public static void HabilitarEnterParaSelecionar(DataGridView grid, Action acao)
        {
            grid.PreviewKeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && ((DataGridView)s).CurrentRow != null)
                {
                    e.IsInputKey = true;
                    acao();
                }
            };
        }
    }

    public static class GridSelectionHelper
    {
        public static void RestaurarCelulaPorId(DataGridView grid, object valorId, int? colunaIndex = null)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.DataBoundItem == null)
                    continue;

                var tipo = row.DataBoundItem.GetType();
                var prop = tipo.GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);

                if (prop == null)
                    continue;

                var valor = prop.GetValue(row.DataBoundItem);

                if (valor != null && valor.Equals(valorId))
                {
                    int colIndex = colunaIndex ?? grid.CurrentCell?.ColumnIndex ?? 0;

                    if (colIndex >= 0 && colIndex < row.Cells.Count)
                    {
                        grid.CurrentCell = row.Cells[colIndex];
                        return;
                    }
                }
            }
        }


    }
}
