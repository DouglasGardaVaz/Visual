using Dados.ViewModel;

namespace Visual.Helpers.Grid
{
    public static class GridViewExtensions
    {
        public static void AtualizarLinha<TEntidade, TViewModel>(this DataGridView grid, TEntidade entidadeAtualizada)
            where TViewModel : class, IViewModelFormatavel<TEntidade>
        {
            if (entidadeAtualizada == null || grid == null)
                return;

            var propriedadeId = typeof(TEntidade).GetProperty("Id");
            if (propriedadeId == null)
                return;

            var idAtualizado = (int)propriedadeId.GetValue(entidadeAtualizada)!;

            var viewModel = grid.Rows
                .Cast<DataGridViewRow>()
                .Select(r => r.DataBoundItem)
                .OfType<TViewModel>()
                .FirstOrDefault(vm =>
                {
                    var idVm = typeof(TViewModel).GetProperty("Id")?.GetValue(vm);
                    return idVm != null && (int)idVm == idAtualizado;
                });

            if (viewModel != null)
            {
                viewModel.PreencherCom(entidadeAtualizada);
                grid.Refresh();
            }
        }

        public static void SelecionarUltimaLinha(this DataGridView grid)
        {
            if (grid.Rows.Count == 0)
                return;

            int ultimaIndex = grid.Rows.Count - 1;
            var ultimaLinha = grid.Rows[ultimaIndex];

            if (ultimaLinha.Cells.Count == 0)
                return;

            try
            {
                grid.ClearSelection();
                grid.CurrentCell = ultimaLinha.Cells[0];
                grid.FirstDisplayedScrollingRowIndex = ultimaIndex;
            }
            catch
            {
               
            }
        }




    }
}
