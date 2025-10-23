public static class EstiloGridHelper
{
    public static void AplicarEstiloModerno(DataGridView grid, bool estiloPDV = false)
    {
        grid.ScrollBars = ScrollBars.None;
        // Cabeçalho
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45); // cinza escuro visível
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
        grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        // Células padrão
        grid.DefaultCellStyle.Font = new Font("Arial", estiloPDV ? 12 : 10);
        grid.DefaultCellStyle.BackColor = Color.White;
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 144, 255); // Azul destaque
        grid.DefaultCellStyle.SelectionForeColor = Color.White;
        grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        // Aparência geral
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
        grid.GridColor = Color.LightGray;
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        grid.RowHeadersVisible = false;
        grid.AllowUserToResizeRows = false;
        grid.AllowUserToResizeColumns = true;
        grid.AllowUserToOrderColumns = true;
        grid.DefaultCellStyle.Padding = new Padding(5, 2, 5, 2);

        // 🧠 Alinhamento inteligente baseado no tipo de dado da coluna
        foreach (DataGridViewColumn col in grid.Columns)
        {
            var type = col.ValueType;

            if (type == typeof(decimal) || type == typeof(double) || type == typeof(float) ||
                type == typeof(int) || type == typeof(long) || type == typeof(short))
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                col.DefaultCellStyle.Format = "N2"; // formato número com 2 casas
            }
            else if (type == typeof(DateTime))
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            else
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        // 🔁 Ativar rolagem com o mouse mesmo sem ScrollBar visível
        grid.MouseWheel -= Grid_MouseWheelCustom; // evita múltiplas assinaturas
        grid.MouseWheel += Grid_MouseWheelCustom;
    }
    private static void Grid_MouseWheelCustom(object sender, MouseEventArgs e)
    {
        if (sender is not DataGridView grid || grid.RowCount == 0)
            return;

        try
        {
            int currentIndex = grid.CurrentCell?.RowIndex ?? grid.FirstDisplayedScrollingRowIndex;
            int step = e.Delta > 0 ? -1 : 1;
            int newIndex = Math.Clamp(currentIndex + step, 0, grid.RowCount - 1);

            grid.FirstDisplayedScrollingRowIndex = newIndex;

            // Só muda o foco de célula, não seleciona linha inteira
            int currentColumn = grid.CurrentCell?.ColumnIndex ?? 0;
            grid.CurrentCell = grid.Rows[newIndex].Cells[currentColumn];
        }
        catch
        {
            // Ignora erros de rolagem fora do intervalo
        }
    }


}
