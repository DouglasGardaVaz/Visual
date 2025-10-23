using Dados.Enums.Financeiro.Pagar;
using Dados.Helpers.Utils;

namespace Dados.Helpers.Combobox.Financeiro.Pagar
{
    public static class FiltroPagarHelper
    {
        public static void PreencherCampoData(ComboBox cmbCampo)
        {
            cmbCampo.Items.Clear();
            cmbCampo.Items.Add("Data de vencimento");
            cmbCampo.Items.Add("Data de cadastro");
            cmbCampo.Items.Add("Data de pagamento");
            cmbCampo.SelectedIndex = 0;
        }

        public class SituacaoItem
        {
            public SituacaoPagar? Value { get; set; }
            public string Text { get; set; }
        }

        public static void PreencherSituacoes(ComboBox cmbSituacao)
        {
            var listaSituacoes = new List<SituacaoItem>
                {
                    new SituacaoItem { Value = null, Text = "Todas" }
                };

            foreach (SituacaoPagar situacao in Enum.GetValues(typeof(SituacaoPagar)))
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
