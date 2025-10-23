using Dados.Enums.Saida.DAV.Condicional;
using Dados.Helpers.Utils;

namespace Dados.Helpers.Combobox.Saida.DAV.Condicional
{
    public static class FiltroCondicionalHelper
    {
        public static void PreencherCampoData(ComboBox cmbCampo)
        {
            cmbCampo.Items.Clear();            
            cmbCampo.Items.Add("Data de emissão");
            cmbCampo.Items.Add("Data de devolução");
            cmbCampo.SelectedIndex = 0;
        }
        public static void PreencherSituacoes(ComboBox cmbSituacao)
        {
            var listaSituacoes = new List<SituacaoItem>
            {
                new SituacaoItem { Value = null, Text = "Todas" }
            };

            foreach (SituacaoDAVCondicional situacao in Enum.GetValues(typeof(SituacaoDAVCondicional)))
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

        public class SituacaoItem
        {
            public SituacaoDAVCondicional? Value { get; set; }
            public string Text { get; set; }
        }
    }
}
