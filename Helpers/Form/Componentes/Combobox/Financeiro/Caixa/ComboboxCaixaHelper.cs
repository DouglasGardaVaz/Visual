using Dados.Enums.Financeiro.Caixa;
using Dados.Helpers.Utils;

namespace Dados.Helpers.Combobox.Financeiro.Receber
{
    public static class FiltroCaixaHelper
    {
        public static void PreencherTipoMovimentacao(ComboBox cmbSituacao)
        {
            cmbSituacao.Items.Clear();
            cmbSituacao.Items.Add("Todos");
            cmbSituacao.Items.Add("Entrada");
            cmbSituacao.Items.Add("Saída");
            cmbSituacao.SelectedIndex = 0;
        }
    }

    public static class CaixaHelper
    {
        public class SituacaoItem
        {
            public TipoOperacaoCaixa? Value { get; set; }
            public string Text { get; set; }
        }

        public static void PreencherOperacoes(ComboBox cmbSituacao)
        {
            var listaSituacoes = new List<SituacaoItem>();

            foreach (TipoOperacaoCaixa situacao in Enum.GetValues(typeof(TipoOperacaoCaixa)))
            {
                listaSituacoes.Add(new SituacaoItem
                {
                    Value = situacao,
                    Text = situacao.GetDescricao()
                });
            }

            cmbSituacao.DataSource = listaSituacoes;
            cmbSituacao.DisplayMember = "Text";
            cmbSituacao.ValueMember = "Value";
            cmbSituacao.SelectedIndex = 0;
        }
    }

}
