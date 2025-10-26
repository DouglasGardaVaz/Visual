using System.ComponentModel;
using Dados.Data;
using Dados.Enums.Financeiro.Pagar;
using Dados.Model.Financeiro.Pagar;
using Visual.Helpers.Form;

namespace Visual.View.Financeiro.PagarReplicarParcelaFormulario
{
    public partial class PagarReplicarParcelaForm : Form
    {
        private readonly DataContext _context;
        public FinanceiroPagar ParcelaBase { get; set; }

        public BindingList<FinanceiroPagar> ParcelasGeradas { get; private set; } = new();

        public PagarReplicarParcelaForm(DataContext context)
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
            _context = context;
        }

        private void WireUpEvents()
        {
            nudParcelas.ValueChanged += (_, _) => GerarParcelas();
            nudDia.ValueChanged += (_, _) => GerarParcelas();            
            dtProximaParcela.ValueChanged += (_, _) =>
            {
                if (cmbTipoGeracao.SelectedIndex == 1) 
                {
                    nudDia.Value = dtProximaParcela.Value.Day;
                }

                GerarParcelas();
            };

            gridConteudo.CellValidating += GridConteudo_CellValidating;
            gridConteudo.CellEndEdit += gridConteudo_CellEndEdit;
        }


        private void gridConteudo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var colName = gridConteudo.Columns[e.ColumnIndex].DataPropertyName;

            if (colName == "DataVencimento")
            {
                if (gridConteudo.Rows[e.RowIndex].DataBoundItem is FinanceiroPagar parcela)
                {
                    var cellValue = gridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (cellValue is DateTime dt && dt.Kind == DateTimeKind.Unspecified)
                    {
                        parcela.DataVencimento = DateTime.SpecifyKind(dt, DateTimeKind.Utc);
                    }
                }
            }
        }
        private void AtualizarTipoGeracao()
        {
            if (cmbTipoGeracao.SelectedIndex == 0) 
            {
                nudDia.Minimum = 1;
                nudDia.Maximum = 365;
                nudDia.Value = 30;
                nudDia.DecimalPlaces = 0;
                nudDia.Increment = 1;
            }
            else 
            {
                nudDia.Minimum = 1;
                nudDia.Maximum = 31;
                nudDia.Value = Math.Min(ParcelaBase.DataVencimento.Day, 31);
                nudDia.DecimalPlaces = 0;
                nudDia.Increment = 1;
            }

            GerarParcelas();
        }
        private void AlimentarTipoGeracao()
        {
            cmbTipoGeracao.Items.Clear();
            cmbTipoGeracao.Items.AddRange(new[] { "Intervalo de dias", "Dia fixo" });           
            cmbTipoGeracao.SelectedIndexChanged += (_, _) => AtualizarTipoGeracao();
            cmbTipoGeracao.SelectedIndex = 0;
        }

        private void AlimentarComponentes()
        {
            dtInicial.Value = ParcelaBase.DataVencimento.Date;
            nudParcelas.Value = ParcelaBase.QtdeParcelas;
            dtInicial.Value = ParcelaBase.DataVencimento;
            dtProximaParcela.Value = ParcelaBase.DataVencimento.AddDays(30);
            nudDia.Value = 30;
        }
        private void PagarReplicarParcelaForm_Load(object sender, EventArgs e)
        {
            if (ParcelaBase == null) 
                return;

            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);                       
            AlimentarTipoGeracao();
            AlimentarComponentes();
            WireUpEvents();
            GerarParcelas();
            ConfigurarGrid();
        }
        private void ConfigurarGrid()
        {
            gridConteudo.AutoGenerateColumns = false;
            gridConteudo.Columns.Clear();

            gridConteudo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NumeroParcela",
                HeaderText = "Parcela",
                ReadOnly = true,
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "D6",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            gridConteudo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataVencimento",
                HeaderText = "Vencimento",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { 
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            gridConteudo.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValorParcela",
                HeaderText = "Valor",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            
            gridConteudo.AllowUserToAddRows = false;
            gridConteudo.AllowUserToDeleteRows = false;
            gridConteudo.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        private void GerarParcelas()
        {
            if (ParcelaBase == null) return;

            ParcelasGeradas.Clear();

            int qtde = (int)nudParcelas.Value;
            if (qtde < 1) return;

            DateTime data = dtProximaParcela.Value;
            int valor = (int)nudDia.Value;

            for (int i = 1; i < qtde; i++)
            {
                DateTime vencimento;

                if (cmbTipoGeracao.SelectedIndex == 1) // Dia Fixo
                {
                    if (i == 1)
                    {
                        // Primeira da grid ajusta para o dia fixo no mesmo mês
                        vencimento = new DateTime(data.Year, data.Month, Math.Min(valor, DateTime.DaysInMonth(data.Year, data.Month)));
                    }
                    else
                    {
                        data = data.AddMonths(1);
                        vencimento = new DateTime(data.Year, data.Month, Math.Min(valor, DateTime.DaysInMonth(data.Year, data.Month)));
                    }
                }
                else // Intervalo em dias
                {
                    if (i == 1)
                    {
                        vencimento = data; // primeira da grid = data da próxima parcela
                    }
                    else
                    {
                        data = data.AddDays(valor);
                        vencimento = data;
                    }
                }

                var nova = new FinanceiroPagar
                {
                    PessoaId = ParcelaBase.PessoaId,
                    Descricao = ParcelaBase.Descricao,
                    Documento = $"{ParcelaBase.Documento} / {i + 1}",
                    ValorParcela = ParcelaBase.ValorParcela,
                    NumeroParcela = i + 1,
                    QtdeParcelas = qtde,
                    Situacao = SituacaoPagar.Aberta,
                    Origem = OrigemPagar.Pagar,
                    DataVencimento = DateTime.SpecifyKind(vencimento, DateTimeKind.Utc),
                    Detalhe = new FinanceiroPagarDetalheModel
                    {
                        CentroCustoId = ParcelaBase.Detalhe?.CentroCustoId,
                        PlanoContaId = ParcelaBase.Detalhe?.PlanoContaId,
                        EspecieId = ParcelaBase.Detalhe?.EspecieId,
                        Observacao = ParcelaBase.Detalhe?.Observacao
                    },
                    Valores = new FinanceiroPagarValores()
                };

                ParcelasGeradas.Add(nova);
            }

            gridConteudo.DataSource = null;
            gridConteudo.DataSource = ParcelasGeradas;
        }




        private void GridConteudo_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var colName = gridConteudo.Columns[e.ColumnIndex].DataPropertyName;

            if (colName == "DataVencimento" && !DateTime.TryParse(e.FormattedValue?.ToString(), out _))
            {
                MessageBox.Show("Data inválida.");
                e.Cancel = true;
            }

            if (colName == "ValorParcela" && !decimal.TryParse(e.FormattedValue?.ToString(), out _))
            {
                MessageBox.Show("Valor inválido.");
                e.Cancel = true;
            }
        }

        private bool ValidarReplicacao()
        {
            if (ParcelasGeradas.Count == 0)
            {
                MensagemHelper.Alerta("Nenhuma parcela gerada.");
                return false;
            }

            int esperadas = ParcelaBase.QtdeParcelas - 1;

            if (ParcelasGeradas.Count < esperadas)
            {
                if (MensagemHelper.Confirmar("Você informou menos parcelas do que o total previsto. Deseja continuar mesmo assim?")
                    != DialogResult.Yes) return false;
            }
            else if (ParcelasGeradas.Count > esperadas)
            {
                if (MensagemHelper.Confirmar("Você informou mais parcelas do que o total previsto. Deseja continuar mesmo assim?")
                    != DialogResult.Yes) return false;
            }
  
            return true;
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
                
            if (!ValidarReplicacao()) 
            {
                DialogResult = DialogResult.None;
                return;
            }
                
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PagarReplicarParcelaForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;
                case Keys.F6:
                    btnConfirmar.PerformClick();
                    break;
            }
        }
    }
}
