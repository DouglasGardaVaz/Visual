using Dados.Helpers.Utils;
using Dados.Enums.Saida.NotaFiscalEnums;

namespace Visual.Helpers.Saida.Nota_fiscal
{
    public static class FiltroNotaFiscalHelper
    {
        public class FiltroItem<TEnum> where TEnum : struct, Enum
        {
            public TEnum? Value { get; set; }
            public string Text { get; set; }
        }

        public static void PreencherStatus(ComboBox cmbStatus)
        {
            var lista = new List<FiltroItem<StatusNotaFiscal>>
            {
                new FiltroItem<StatusNotaFiscal> { Value = null, Text = "Todos" }
            };

            foreach (StatusNotaFiscal status in Enum.GetValues(typeof(StatusNotaFiscal)))
            {
                lista.Add(new FiltroItem<StatusNotaFiscal>
                {
                    Value = status,
                    Text = status.GetDescricao()
                });
            }

            cmbStatus.DataSource = lista;
            cmbStatus.DisplayMember = "Text";
            cmbStatus.ValueMember = "Value";
            cmbStatus.SelectedIndex = 0;
        }

        public static void PreencherSituacoes(ComboBox cmbSituacao)
        {
            var lista = new List<FiltroItem<SituacaoNotaFiscal>>
            {
                new FiltroItem<SituacaoNotaFiscal> { Value = null, Text = "Todas" }
            };

            foreach (SituacaoNotaFiscal situacao in Enum.GetValues(typeof(SituacaoNotaFiscal)))
            {
                lista.Add(new FiltroItem<SituacaoNotaFiscal>
                {
                    Value = situacao,
                    Text = situacao.GetDescricao()
                });
            }

            cmbSituacao.DataSource = lista;
            cmbSituacao.DisplayMember = "Text";
            cmbSituacao.ValueMember = "Value";
            cmbSituacao.SelectedIndex = 0;
        }

        public static void PreencherCampoData(ComboBox cmbCampo)
        {
            cmbCampo.Items.Clear();
            cmbCampo.Items.Add("Data de emissão");
            cmbCampo.Items.Add("Data de cadastro");
            cmbCampo.SelectedIndex = 0;
        }
    }
}
