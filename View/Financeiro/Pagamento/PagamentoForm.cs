using Dados.Data;
using Dados.Enums.Financeiro;
using Dados.Enums.Pessoa;
using Dados.Enums.Sistema;
using Dados.Helpers.Financeiro;
using Dados.Helpers.Form;
using Dados.Helpers.Form.Helper;
using Dados.Helpers.Grid;
using Dados.Model.Cadastro;
using Dados.Model.Saida.NotaFiscalValoresModel;
using Dados.Model.Saida.Pagamento;
using Dados.View.PessoaSelecaoFormulario;
using Dados.ViewModel.Cadastro;

namespace Dados.View.Financeiro.PagamentoFormulario
{
    public partial class PagamentoForm : Form
    {
        public int IdConsumidor { get; set; } = 1;
        public string NomeConsumidor { get; set; } = "CONSUMIDOR";
        public string DocumentoConsumidor { get; set; } = "";

        private decimal _totalBase = 0m;
        private ValorPercentBinding? _bindDesconto;
        private ValorPercentBinding? _bindAcrescimo;
        private readonly OrigemModuloSaida _origemModulo;
        private readonly int _origemId;
        private readonly DataContext _context;

        public PagamentoForm(DataContext context, OrigemModuloSaida origemModulo, int origemId)
        {
            InitializeComponent();
            _context = context;
            _origemModulo = origemModulo;
            _origemId = origemId;
        }

        private void AjustesGrid()
        {
            EstiloGridHelper.AplicarEstiloModerno(gridPagamento, estiloPDV: true);
            AjustesPersonalizadosGrid();
            GridSettingsHelper.RestaurarConfiguracao(gridPagamento, "PagamentoForm");
        }

        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);

            lblTituloValorTotal.Font = new Font(Font.FontFamily, 18, FontStyle.Bold);

            lblValorTotal.Font = new Font(Font.FontFamily, 28, FontStyle.Bold);

            lblTituloValorPago.Font = new Font(Font.FontFamily, 18, FontStyle.Bold);

            lblValorPago.Font = new Font(Font.FontFamily, 28, FontStyle.Bold);

            lblTituloValorTroco.Font = new Font(Font.FontFamily, 18, FontStyle.Bold);

            lblValorTroco.Font = new Font(Font.FontFamily, 26, FontStyle.Bold);


            var corTitulo = Color.FromArgb(107, 114, 128); // #6B7280 (cinza suave)
            lblTituloValorTotal.ForeColor = corTitulo;
            lblTituloValorPago.ForeColor = corTitulo;
            lblTituloValorTroco.ForeColor = corTitulo;

            lblValorTotal.ForeColor = Color.FromArgb(59, 130, 246);
            lblValorPago.ForeColor = Color.FromArgb(34, 197, 94);
            lblValorTroco.ForeColor = Color.FromArgb(251, 191, 36);

            btnCancelar.Font = new Font(Font.FontFamily, 11, FontStyle.Bold);
            btnFinalizar.Font = new Font(Font.FontFamily, 11, FontStyle.Bold);
            btnVendedor.Font = new Font(Font.FontFamily, 11, FontStyle.Bold);

            lblDescontoPercentual.Font = new Font(Font.FontFamily, 10, FontStyle.Regular);
            lblDesconto.Font = new Font(Font.FontFamily, 10, FontStyle.Regular);
            lblAcrescimoPercentual.Font = new Font(Font.FontFamily, 11, FontStyle.Regular);
            lblAcrescimo.Font = new Font(Font.FontFamily, 10, FontStyle.Regular);

            txtValorDesconto.Font = new Font(Font.FontFamily, 11);
            txtValorDescontoPercentual.Font = new Font(Font.FontFamily, 11);
            txtValorAcrescimo.Font = new Font(Font.FontFamily, 11);
            txtValorAcrescimoPercentual.Font = new Font(Font.FontFamily, 11);

            AjustesGrid();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TratarValorDigitadoNaCelula(object sender, DataGridViewCellParsingEventArgs e)
        {
            if (gridPagamento.Columns[e.ColumnIndex].DataPropertyName != "Valor")
                return;

            var txt = e.Value?.ToString()?.Trim() ?? string.Empty;
            var parsed = MoneyTextHelper.Parse(txt);


            if (parsed <= 0)
            {
                e.ParsingApplied = true;
                return;
            }

            if (gridPagamento.DataSource is List<EspeciePagamentoViewModel> lista)
            {
                var especieAtual = lista[e.RowIndex];
                var totalVenda = MoneyTextHelper.Parse(lblValorTotal.Text);

                // soma de todos os outros valores já lançados (exceto a linha atual)
                decimal somaOutros = lista
                    .Where((x, idx) => idx != e.RowIndex)
                    .Sum(x => x.Valor);

                // quanto ainda falta pagar
                var valorRestante = totalVenda - somaOutros;

                if (valorRestante == 0)
                {
                    e.Value = 0.00m;
                    e.ParsingApplied = true;

                    BeginInvoke(new Action(() =>
                    {
                        gridPagamento.CurrentCell = gridPagamento.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        gridPagamento.BeginEdit(true);
                    }));

                    return;
                }

                // valida se excedeu o valor restante e não permite troco
                if (parsed > valorRestante && especieAtual.TipoPagamento != TipoPagamento.Dinheiro)
                {
                    if (valorRestante > 0)
                    {
                        MensagemHelper.Alerta(
                                   $"A espécie '{especieAtual.Descricao}' não permite troco. " +
                                   $"O valor máximo permitido é R$ {valorRestante:N2}."
                               );
                    }

                    e.Value = 0.00m;
                    e.ParsingApplied = true;

                    // volta para a mesma célula para corrigir
                    BeginInvoke(new Action(() =>
                    {
                        gridPagamento.CurrentCell = gridPagamento.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        gridPagamento.BeginEdit(true);
                    }));

                    return;
                }
            }
            // Se passou nas validações, mantém o valor digitado
            e.Value = parsed;
            e.ParsingApplied = true;
        }

        private void ControlarEntradaDeTexto(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gridPagamento.CurrentCell?.OwningColumn?.DataPropertyName == "Valor" && e.Control is TextBox tb)
            {
                tb.KeyPress -= FormHelper.Tb_KeyPressMonetario;
                tb.KeyPress += FormHelper.Tb_KeyPressMonetario;
                tb.MaxLength = 10;
            }
        }

        private void AoFinalizarEdicaoValor(object sender, DataGridViewCellEventArgs e)
        {
            if (gridPagamento.Columns[e.ColumnIndex].DataPropertyName != "Valor")
                return;

            // Se foi marcado para resetar
            if (gridPagamento.Tag is { } tagObj)
            {
                var tag = (dynamic)tagObj;
                if (tag.Reset && tag.RowIndex == e.RowIndex && tag.ColumnIndex == e.ColumnIndex)
                {
                    gridPagamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0.00m;
                    gridPagamento.Tag = null;

                    // força refresh imediato do texto exibido
                    gridPagamento.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            }

            if (gridPagamento.DataSource is not List<EspeciePagamentoViewModel> lista)
                return;

            var valorCelula = gridPagamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (valorCelula == null || !decimal.TryParse(valorCelula.ToString(), out var valor) || valor < 0)
            {
                gridPagamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0.00m;
            }

            CalcularValores();
        }

        private void AjustesPersonalizadosGrid()
        {
            gridPagamento.EditMode = DataGridViewEditMode.EditOnEnter;
            gridPagamento.ReadOnly = false;

            var colunaDescricao = gridPagamento.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.DataPropertyName == "Descricao");

            if (colunaDescricao != null)
            {
                colunaDescricao.ReadOnly = true;
                colunaDescricao.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }

            var colunaValor = gridPagamento.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.DataPropertyName == "Valor");

            if (colunaValor != null)
            {
                colunaValor.DefaultCellStyle.Format = "N2";
                colunaValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colunaValor.ReadOnly = false;
            }

            gridPagamento.CellParsing += TratarValorDigitadoNaCelula;
            gridPagamento.EditingControlShowing += ControlarEntradaDeTexto;
            gridPagamento.CellEndEdit += AoFinalizarEdicaoValor;

        }

        private void CalcularValores()
        {
            if (gridPagamento.DataSource is not List<EspeciePagamentoViewModel> lista) return;

            decimal valorPago = lista.Sum(x => x.Valor);
            decimal valorTotal = MoneyTextHelper.Parse(lblValorTotal.Text);

            lblValorPago.Text = MoneyTextHelper.F2(valorPago);

            if (valorPago > valorTotal)
            {
                decimal troco = valorPago - valorTotal;
                lblTituloValorTroco.Text = "Troco R$";
                lblValorTroco.Text = troco.ToString("N2");
                lblValorTroco.ForeColor = Color.FromArgb(251, 191, 36);
            }
            else
            {
                decimal faltante = valorTotal - valorPago;
                lblTituloValorTroco.Text = "Valor faltante R$";
                lblValorTroco.Text = faltante.ToString("N2");
                lblValorTroco.ForeColor = faltante > 0
                            ? Color.FromArgb(248, 113, 113)
                            : Color.FromArgb(13, 148, 136);
            }

        }

        private void AtualizarTotalLiquido()
        {
            var desc = MoneyTextHelper.Parse(txtValorDesconto.Text);
            var acr = MoneyTextHelper.Parse(txtValorAcrescimo.Text);

            var totalLiquido = Math.Max(0m, _totalBase + acr - desc);
            lblValorTotal.Text = MoneyTextHelper.F2(totalLiquido);

            CalcularValores();
        }

        private void CarregarEspecies()
        {
            using var context = new DataContext();
            var especies = context.Set<Especie>()
                                  .Where(e => e.Ativo)
                                  .OrderBy(e => e.OrdemExibicao)
                                  .ToList();

            var lista = especies.Select(e => new EspeciePagamentoViewModel
            {
                Id = e.Id,
                Descricao = e.Descricao,
                Valor = 0m,
                TipoPagamento = e.TipoPagamento,
                ModalidadePagamento = e.ModalidadePagamento
            }).ToList();

            gridPagamento.DataSource = lista;
        }
        private void CarregarPessoa()
        {
            switch (_origemModulo)
            {
                case OrigemModuloSaida.NFCe:
                    {
                        var nota = _context.NotaFiscal
                            .FirstOrDefault(n => n.Id == _origemId);

                        var destinatario = nota?.Destinatario.FirstOrDefault();
                        if (destinatario != null)
                        {
                            IdConsumidor = destinatario.PessoaDestinatarioId;                            
                            txtConsumidor.Text = destinatario.Nome;
                            txtDocumentoConsumidor.Text = destinatario.Documento;
                            NomeConsumidor = destinatario.Nome;
                            DocumentoConsumidor = destinatario.Documento;
                        }
                        else
                        {
                            txtConsumidor.Text = NomeConsumidor;
                        }
                            break;
                    }

                default:
                    throw new NotImplementedException($"Origem '{_origemModulo}' ainda não tratada.");
            }
        }


        private bool VetaAjusteAcrescimoSeDescontoFicarInvalido(decimal subtotalParaAcrescimo, decimal novoAcrValor, decimal novoAcrPerc)
        {
            decimal R2(decimal v) => Math.Round(v, 2, MidpointRounding.AwayFromZero);

            // novo subtotal que servirá de base para o DESCONTO = base + acréscimo novo
            var novoSubtotalDesconto = Math.Max(0m, _totalBase + novoAcrValor);

            var descValorAtual = MoneyTextHelper.Parse(txtValorDesconto.Text);

            // NÃO permitir se o desconto atual zerar/ultrapassar o novo subtotal
            var ok = R2(descValorAtual) < R2(novoSubtotalDesconto);
            if (!ok) System.Media.SystemSounds.Beep.Play(); // feedback opcional
            return ok;
        }
        private void AjustarComponentesValores()
        {
            decimal R2(decimal v) => Math.Round(v, 2, MidpointRounding.AwayFromZero);

            // DESCONTO (mantém seus validadores usuais)
            _bindDesconto = ValorPercentBinding.Attach(
                txtValorDesconto,
                txtValorDescontoPercentual,
                getSubtotal: () => Math.Max(0m, _totalBase + MoneyTextHelper.Parse(txtValorAcrescimo.Text)),
                onChanged: AtualizarTotalLiquido,
                validateValue: (valor, subtotal) => R2(valor) < R2(subtotal), // não pode igual ou maior
                validatePercent: (perc, subtotal) => Math.Round(perc, 2, MidpointRounding.AwayFromZero) < 100m
            );

            // ACRÉSCIMO (usa "beforeApply" para vetar alteração que invalidaria o desconto)
            _bindAcrescimo = ValorPercentBinding.Attach(
                txtValorAcrescimo,
                txtValorAcrescimoPercentual,
                getSubtotal: () => Math.Max(0m, _totalBase - MoneyTextHelper.Parse(txtValorDesconto.Text)),
                onChanged: AtualizarTotalLiquido,
                beforeApply: VetaAjusteAcrescimoSeDescontoFicarInvalido
            );



        }
        private void PagamentoForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            CarregarPessoa();
            CarregarEspecies();

            _totalBase = ObterValorTotalOrigem();
            lblValorTotal.Text = MoneyTextHelper.F2(_totalBase);

            AtualizarTotalLiquido();
            AjustarComponentesValores();

        }

        private void FocarCampoValorNaGrid()
        {
            if (gridPagamento.Rows.Count > 0)
            {
                int rowIndex = 0;
                int colIndex = gridPagamento.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.HeaderText.Contains("Valor"))?.Index ?? -1;

                if (colIndex >= 0)
                {
                    gridPagamento.CurrentCell = gridPagamento.Rows[rowIndex].Cells[colIndex];
                    gridPagamento.BeginEdit(true);
                }
            }
        }

        private void PagamentoForm_Shown(object sender, EventArgs e)
        {
            CalcularValores();
            FocarCampoValorNaGrid();
        }

        private void PagamentoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bindDesconto?.Dispose();
            _bindAcrescimo?.Dispose();
            GridSettingsHelper.SalvarConfiguracao(gridPagamento, "PagamentoForm");
        }

        private decimal ObterValorTotalOrigem()
        {
            switch (_origemModulo)
            {
                case OrigemModuloSaida.NFCe:
                    return _context.NotaFiscal
                        .Where(n => n.Id == _origemId)
                        .Select(n => n.Itens
                            .Sum(i => (i.Valores.ValorTotalBruto ?? 0) - (i.Valores.ValorDesconto ?? 0))
                        )
                        .FirstOrDefault();

                //case OrigemModuloSaida.NFe:
                //    return _context.NotaFiscal
                //        .Where(n => n.Id == _origemId)
                //        .Select(n => n.Itens.Sum(i => i.Valores.ValorTotalBruto - i.Valores.ValorDesconto))
                //        .FirstOrDefault();

                //case OrigemModuloSaida.PedidoVenda:
                //    return _context.PedidosVenda
                //        .Where(p => p.Id == _origemId)
                //        .Select(p => p.TotalGeral)
                //        .FirstOrDefault();

                //case OrigemModuloSaida.Orcamento:
                //    return _context.Orcamentos
                //        .Where(o => o.Id == _origemId)
                //        .Select(o => o.TotalGeral)
                //        .FirstOrDefault();

                //case OrigemModuloSaida.Condicional:
                //    return _context.Condicionais
                //        .Where(c => c.Id == _origemId)
                //        .Select(c => c.TotalGeral)
                //        .FirstOrDefault();

                //case OrigemModuloSaida.Aluguel:
                //    return _context.Alugueis
                //        .Where(a => a.Id == _origemId)
                //        .Select(a => a.ValorTotal)
                //        .FirstOrDefault();

                default:
                    throw new NotImplementedException($"Origem '{_origemModulo}' ainda não tratada.");
            }
        }

        private SaidaPagamento CriarPagamento(EspeciePagamentoViewModel pag)
        {
            var valorPago = pag.Valor;
            if (valorPago <= 0)
                return null;

            var totalBase = MoneyTextHelper.Parse(lblValorTotal.Text);
            var totalPago = gridPagamento.DataSource is List<EspeciePagamentoViewModel> lista
                ? lista.Sum(x => x.Valor)
                : valorPago;

            decimal troco = totalPago - totalBase;

            // Troco só será subtraído do dinheiro
            decimal valorLiquido = pag.TipoPagamento == TipoPagamento.Dinheiro
                ? Math.Max(0, valorPago - troco)
                : valorPago;

            var entidade = new SaidaPagamento
            {
                OrigemModulo = _origemModulo,
                OrigemId = _origemId,
                EspecieId = pag.Id,
                ValorTotalPago = valorPago,
                ValorTotalLiquido = valorLiquido
            };

            if (pag.ModalidadePagamento is ModalidadePagamento.Parcelado
                or ModalidadePagamento.CreditoAVista
                or ModalidadePagamento.CreditoParcelado)
            {
                entidade.Parcelas = new List<SaidaPagamentoParcela>
        {
            new SaidaPagamentoParcela
            {
                NumeroParcela = 1,
                Valor = valorPago,
                DataVencimento = DateTime.SpecifyKind(DateTime.Today, DateTimeKind.Utc)
            }
        };
            }

            return entidade;
        }


        public List<SaidaPagamento> GerarEntidadePagamento()
        {
            if (gridPagamento.DataSource is not List<EspeciePagamentoViewModel> listaPagamentos)
                return null;

            var pagamentosValidos = listaPagamentos
                .Where(x => x.Valor > 0)
                .ToList();

            if (!pagamentosValidos.Any())
                return null;

            var listaEntidades = new List<SaidaPagamento>();

            var pagamentosOrdenados = pagamentosValidos
                .Where(p => p.TipoPagamento != TipoPagamento.Dinheiro)
                .Concat(pagamentosValidos.Where(p => p.TipoPagamento == TipoPagamento.Dinheiro));

            foreach (var pag in pagamentosOrdenados)
            {
                var entidade = CriarPagamento(pag);
                if (entidade != null)
                    listaEntidades.Add(entidade);
            }

            return listaEntidades;
        }
        private void SalvarTotaisDocumento()
        {
            if (_origemModulo is OrigemModuloSaida.NFCe or OrigemModuloSaida.NFe)
            {
                var valores = _context.NotaFiscalValores
                    .FirstOrDefault(v => v.NotaFiscalId == _origemId);

                if (valores == null)
                {
                    valores = new NotaFiscalValores
                    {
                        NotaFiscalId = _origemId,
                        ValorDesconto = MoneyTextHelper.Parse(txtValorDesconto.Text),
                        ValorOutros = MoneyTextHelper.Parse(txtValorAcrescimo.Text),
                        ValorTotal = MoneyTextHelper.Parse(lblValorTotal.Text),
                        DataHoraCadastro = DateTime.UtcNow
                    };

                    _context.NotaFiscalValores.Add(valores);
                }
                else
                {
                    valores.ValorDesconto = MoneyTextHelper.Parse(txtValorDesconto.Text);
                    valores.ValorOutros = MoneyTextHelper.Parse(txtValorAcrescimo.Text);
                    valores.ValorTotal = MoneyTextHelper.Parse(lblValorTotal.Text);
                }

                _context.SaveChanges();
            }
        }
        private void AlimentarVariaveis()
        {
            NomeConsumidor = txtConsumidor.Text.Trim();
            DocumentoConsumidor = txtDocumentoConsumidor.Text.Trim();

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (!ValidarValoresFinanceiros())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AlimentarVariaveis();

            SalvarTotaisDocumento();

            var entidadesPagamento = GerarEntidadePagamento();

            if (entidadesPagamento == null || entidadesPagamento.Count == 0)
            {
                MensagemHelper.Alerta("Não foi possível gerar os dados do pagamento.");
                return;
            }


            this.Tag = entidadesPagamento;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private bool ValidarValoresFinanceiros()
        {
            var totalBase = MoneyTextHelper.Parse(lblValorTotal.Text);

            if (gridPagamento.DataSource is not List<EspeciePagamentoViewModel> lista)
            {
                MensagemHelper.Alerta("Nenhuma forma de pagamento encontrada.");
                gridPagamento.Focus();
                return false;
            }

            var totalPago = lista.Sum(x => x.Valor);

            if (totalPago <= 0)
            {
                MensagemHelper.Alerta("Informe ao menos uma forma de pagamento com valor.");
                gridPagamento.Focus();
                return false;
            }

            if (totalPago < totalBase)
            {
                MensagemHelper.Alerta(
                    $"O valor pago (R$ {totalPago:N2}) é menor que o total necessário (R$ {totalBase:N2})."
                );
                gridPagamento.Focus();
                return false;
            }

            var troco = totalPago - totalBase;
            if (troco > 0)
            {
                var valorDinheiro = lista.Where(x => x.TipoPagamento == TipoPagamento.Dinheiro).Sum(x => x.Valor);

                if (valorDinheiro < troco)
                {
                    MensagemHelper.Alerta($"O troco (R$ {troco:N2}) não pode ser gerado com as espécies informadas.");
                    gridPagamento.Focus();
                    return false;
                }
            }


            return true;
        }

        private void PagamentoForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Consumidor (Ctrl + C)
            if (e.Control && e.KeyCode == Keys.C)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                txtConsumidor.Focus();
            }

            // Desconto (Ctrl + D)
            if (e.Control && e.KeyCode == Keys.D)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                txtValorDesconto.Focus();
            }

            // Acréscimo (Ctrl + A)
            if (e.Control && e.KeyCode == Keys.A)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                txtValorAcrescimo.Focus();
            }

            // Cancelar (F4)
            if (e.KeyCode == Keys.F4)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnCancelar.PerformClick();
            }

            // Selecionar vendedor (V)
            if (e.KeyCode == Keys.V)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnVendedor.PerformClick();
            }

            // Finalizar (F6)
            if (e.KeyCode == Keys.F6)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                btnFinalizar.PerformClick();
            }

            // ESC → Fechar tela
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                this.Close();
            }
        }

        private void pbBuscaPessoa_Click(object sender, EventArgs e)
        {
            var formSelecaoPessoa = new PessoaSelecaoForm(_context);

            if (formSelecaoPessoa.ShowDialog() == DialogResult.OK)
            {
                var pessoaSelecionada = formSelecaoPessoa.ItemSelecionado;
                if (pessoaSelecionada == null)
                    return;

                string CPFCNPJ = "";
                string Nome = "";

                switch (pessoaSelecionada.Tipo)
                {
                    case TipoPessoa.Fisica:
                        var docCpf = pessoaSelecionada.Documentos?
                            .FirstOrDefault(d => d.TipoDocumentoPessoa == TipoDocumentoPessoa.CPF);
                        CPFCNPJ = docCpf?.Documento ?? string.Empty;
                        Nome = pessoaSelecionada.PessoaFisica?.NomeCompleto?.Trim() ?? string.Empty;
                        break;

                    case TipoPessoa.Juridica:
                        var docCnpj = pessoaSelecionada.Documentos?
                            .FirstOrDefault(d => d.TipoDocumentoPessoa == TipoDocumentoPessoa.CNPJ);
                        CPFCNPJ = docCnpj?.Documento ?? string.Empty;
                        Nome = pessoaSelecionada.PessoaJuridica?.RazaoSocial?.Trim() ?? string.Empty;
                        break;
                }

                IdConsumidor = pessoaSelecionada.Id;
                txtConsumidor.Text = Nome;
                txtDocumentoConsumidor.Text = CPFCNPJ;
            }
        }

    }
}
