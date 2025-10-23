using Dados.Data;
using Dados.Enums;
using Dados.Enums.Estoque;
using Dados.Enums.Pessoa;
using Dados.Helpers.Utils;
using Dados.Model.Configuracao.Parametros.Estoque;
using Dados.Model.Estoque;
using Dados.Model.Tributacao;
using Dados.ViewModel.Estoque;
using Microsoft.EntityFrameworkCore;
using Dados.Constantes.Mensagens.Estoque;
using Dados.Constantes.Mensagens.Global;
using Dados.Helpers.Form;
using Dados.Helpers.Geral;
using Dados.Helpers.Grid;
using Dados.View.Cadastro.GrupoFormulario;
using Dados.View.Cadastro.MarcaFormulario;
using Dados.View.Cadastro.SubgrupoFormulario;
using Dados.View.EstoqueCadastroGradeFormulario;
using Dados.View.PessoaSelecaoFormulario;
using Dados.View.Tributacao.UnidadeMedidaFormulario;
using Dados.View.TributacaoEstadualFormulario;
using Dados.View.TributacaoFederalFormulario;
using Dados.View.TributacaoNCMSelecaoFormulario;

namespace GerencialLoja.View.EstoqueCadastroFormulario
{
    public partial class EstoqueCadastroForm : Form
    {
        private readonly DataContext _context;
        private List<(EstoqueItemGrade Grade, decimal Qtde)> _ajustesPendentes = new();
        public TipoOperacao Operacao { get; set; }
        public EstoqueItem itemSelecionado { get; set; }
        public EstoqueCadastroForm(DataContext context)
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
            _context = context;
        }

        private void MostrarApenasTab(TabPage tabParaMostrar)
        {
            tbControlModulos.SelectedTab = tabParaMostrar;
        }

        private bool ValidarCamposCadastro()
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("O campo descrição é obrigatório.");
                MostrarApenasTab(tbCadastro);
                txtDescricao.Focus();
                return false;
            }

            // Unidade de medida obrigatória
            if (cmbUN.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione uma unidade de medida.");
                MostrarApenasTab(tbTributacao);
                cmbUN.Focus();
                return false;
            }

            // Aplicação do produto obrigatória
            if (cmbAplicacaoProduto.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione a aplicação do produto.");
                MostrarApenasTab(tbTributacao);
                cmbAplicacaoProduto.Focus();
                return false;
            }

            // Preço de custo obrigatório e numérico
            if (!decimal.TryParse(txtPrecoCusto.Text, out var precoCusto) || precoCusto < 0)
            {
                MensagemHelper.Alerta("Informe um preço de custo válido.");
                MostrarApenasTab(tbClassificacao);
                txtPrecoCusto.Focus();
                return false;
            }

            // Margem de lucro (opcional, mas deve ser numérica se preenchida)
            if (!string.IsNullOrWhiteSpace(txtMargemLucro.Text) &&
                !decimal.TryParse(txtMargemLucro.Text, out var _))
            {
                MensagemHelper.Alerta("A margem de lucro deve ser um valor numérico.");
                MostrarApenasTab(tbClassificacao);
                txtMargemLucro.Focus();
                return false;
            }

            // Preço de venda obrigatório e numérico
            if (!decimal.TryParse(txtPrecoVenda.Text, out var precoVenda) || precoVenda < 0)
            {
                MensagemHelper.Alerta("Informe um preço de venda válido.");
                MostrarApenasTab(tbClassificacao);
                txtPrecoVenda.Focus();
                return false;
            }

            // Tipo de cadastro obrigatório
            if (cmbTipoCadastroEstoque.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione um tipo de cadastro.");
                MostrarApenasTab(tbCadastro);
                cmbTipoCadastroEstoque.Focus();
                return false;
            }

            if (!ParametrosEstoque.PermitirSalvarSemTributacao && cmbTributacaoFederal.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione a tributação federal.");
                MostrarApenasTab(tbTributacao);
                cmbTributacaoFederal.Focus();
                return false;
            }

            // Tributação Estadual obrigatória (se NÃO permitir salvar sem tributação)
            if (!ParametrosEstoque.PermitirSalvarSemTributacao && cmbTributacaoEstadual.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione a tributação estadual.");
                MostrarApenasTab(tbTributacao);
                cmbTributacaoEstadual.Focus();
                return false;
            }

            // NCM obrigatório (se NÃO permitir salvar sem NCM)
            if (!ParametrosEstoque.PermitirSalvarSemNCM && string.IsNullOrWhiteSpace(txtNCM.Text))
            {
                MensagemHelper.Alerta("Informe o código NCM.");
                MostrarApenasTab(tbTributacao);
                txtNCM.Focus();
                return false;
            }

            return true;
        }

        private void AtualizarObjetoEstoque()
        {
            itemSelecionado.Nome = txtDescricao.Text.Trim();
            itemSelecionado.CodigoBarras = string.IsNullOrWhiteSpace(txtCodigoBarra.Text) ? null : txtCodigoBarra.Text.Trim();
            itemSelecionado.Referencia = txtReferencia.Text.Trim();

            itemSelecionado.TipoCadastroItem = (TipoCadastroItemEstoque)(int)cmbTipoCadastroEstoque.SelectedValue;
            itemSelecionado.TipoItem = TipoItemEstoque.Produto;
            itemSelecionado.Ativo = ckAtivo.Checked;

            itemSelecionado.Tributacao ??= new EstoqueItemTributacao
            {
                EstoqueItem = itemSelecionado
            };

            itemSelecionado.Tributacao.TributacaoEstadualId = cmbTributacaoEstadual.SelectedValue as int?;
            itemSelecionado.Tributacao.TributacaoFederalId = cmbTributacaoFederal.SelectedValue as int?;
            itemSelecionado.Tributacao.TributacaoAplicacaoId = (int)cmbAplicacaoProduto.SelectedValue;
            itemSelecionado.Tributacao.UnidadeMedidaId = cmbUN.SelectedValue as int?;

            var codigoNCM = txtNCM.Text.Trim();
            var ncm = _context.TributacoesNCM.FirstOrDefault(n => n.Codigo == codigoNCM);
            itemSelecionado.Tributacao.TributacaoNCMId = ncm?.Id;

            itemSelecionado.Tributacao.Ativo = true;


            decimal precoCusto = decimal.TryParse(txtPrecoCusto.Text, out var custo) ? custo : 0;
            decimal precoVenda = decimal.TryParse(txtPrecoVenda.Text, out var venda) ? venda : 0;
            decimal? margemLucro = decimal.TryParse(txtMargemLucro.Text, out var margem) ? margem : null;

            itemSelecionado.Valores ??= new EstoqueItemValores();
            itemSelecionado.Valores.PrecoCusto = precoCusto;
            itemSelecionado.Valores.PrecoVenda = precoVenda;
            itemSelecionado.Valores.MargemLucroPercentual = margemLucro;
            itemSelecionado.Valores.Ativo = true;

            itemSelecionado.Adicional ??= new EstoqueItemAdicional
            {
                EstoqueItem = itemSelecionado
            };

            itemSelecionado.Adicional.Adicional1 = txtAdicional1.Text.Trim();
            itemSelecionado.Adicional.Adicional2 = txtAdicional2.Text.Trim();
            itemSelecionado.Adicional.Adicional3 = txtAdicional3.Text.Trim();
            itemSelecionado.Adicional.Adicional4 = txtAdicional4.Text.Trim();
            itemSelecionado.Adicional.Adicional5 = txtAdicional5.Text.Trim();
            itemSelecionado.Adicional.Observacao = txtObservacao.Text.Trim();

        }
        private void GerarAjustesDeEstoque()
        {
            if (cmbTipoCadastroEstoque.SelectedItem is KeyValuePair<int, string> item)
            {
                var tipoSelecionado = (TipoCadastroItemEstoque)item.Key;

                switch (tipoSelecionado)
                {
                    case TipoCadastroItemEstoque.Normal:
                        decimal qtdeEstoqueDigitada = decimal.TryParse(txtQtdeAtual.Text, out var qtde) ? qtde : 0;
                        var qtdeTotal = itemSelecionado.Qtde.Sum(q => q.QtdeDisponivel);
                        if (qtdeTotal != qtdeEstoqueDigitada)
                        {
                            _context.Add(new EstoqueItemAjusteManual
                            {
                                EstoqueItemId = itemSelecionado.Id,
                                EstoqueItemGradeId = null,
                                NovaQuantidade = qtdeEstoqueDigitada
                            });
                        }
                        break;

                    case TipoCadastroItemEstoque.Grade:
                        foreach (var ajuste in _ajustesPendentes)
                        {
                            _context.Add(new EstoqueItemAjusteManual
                            {
                                EstoqueItemId = itemSelecionado.Id,
                                EstoqueItemGradeId = ajuste.Grade.Id,
                                NovaQuantidade = ajuste.Qtde
                            });
                        }
                        break;
                }
            }

            _context.SaveChanges();
            _ajustesPendentes.Clear();
        }

        private void PersistirItemEGrades()
        {
            try
            {
                if (Operacao == TipoOperacao.Inclusao)
                {
                    _context.EstoqueItens.Add(itemSelecionado);
                }

                var gradesExistentes = _context.EstoqueItensGrades
                    .Where(g => g.EstoqueItemId == itemSelecionado.Id)
                    .ToList();

                var gradesRemovidas = gradesExistentes
                    .Where(g => !itemSelecionado.Grades.Any(ng => ng.Id == g.Id))
                    .ToList();

                if (gradesRemovidas.Any())
                    _context.EstoqueItensGrades.RemoveRange(gradesRemovidas);

                var novasGrades = itemSelecionado.Grades.Where(g => g.Id == 0).ToList();
                if (novasGrades.Any())
                {
                    foreach (var grade in novasGrades)
                        grade.EstoqueItemId = itemSelecionado.Id;

                    _context.EstoqueItensGrades.AddRange(novasGrades);
                }

                _context.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                var innerMsg = dbEx.InnerException?.Message ?? dbEx.Message;
                MensagemHelper.Alerta($"Erro ao salvar grades ou item: {innerMsg}");
            }
            catch (Exception ex)
            {
                MensagemHelper.Alerta($"Erro inesperado ao persistir dados: {ex.Message}");
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AtualizarObjetoEstoque();           

            PersistirItemEGrades();

            GerarAjustesDeEstoque();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbCadastro);
        }

        private void btnContato_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbClassificacao);
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbEstoque);
        }

        private void btnTributacao_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbTributacao);
        }

        private void btnAdicional_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbAdicional);
        }

        private void tbControlModulos_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void CarregarUnidadesMedida()
        {
            cmbUN.PreencherComboComDbSet<TributacaoUnidadeMedida>(_context, u => $"{u.Codigo} - {u.Descricao}", u => u.Id);
        }

        private void CarregarComboFederal()
        {
            cmbTributacaoFederal.PreencherComboComDbSet<TributacaoFederal>(_context, x => x.Nome, x => x.Id);
        }

        private void CarregarComboEstadual()
        {
            cmbTributacaoEstadual.PreencherComboComDbSet<TributacaoEstadual>(_context, x => x.Nome, x => x.Id);
        }

        private void InicializarNovoEstoque()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                // Resolve NCM padrão (se configurado)
                int? ncmIdPadrao = null;
                if (!string.IsNullOrWhiteSpace(ParametrosEstoque.NcmPadrao))
                {
                    ncmIdPadrao = _context.TributacoesNCM
                        .AsNoTracking()
                        .Where(n => n.Codigo == ParametrosEstoque.NcmPadrao)
                        .Select(n => (int?)n.Id)
                        .FirstOrDefault();
                }

                itemSelecionado = new EstoqueItem
                {
                    Nome = string.Empty,
                    CodigoBarras = null,
                    TipoCadastroItem = ParametrosEstoque.TipoCadastroPadrao,
                    TipoItem = TipoItemEstoque.Produto,
                    Ativo = ParametrosEstoque.AtivoPadrao,
                    Referencia = string.Empty,

                    Qtde = new List<EstoqueItemQtde> { new EstoqueItemQtde() },

                    Tributacao = new EstoqueItemTributacao
                    {
                        TributacaoEstadualId = ParametrosEstoque.TributacaoEstadualPadraoId > 0 ? ParametrosEstoque.TributacaoEstadualPadraoId : null,
                        TributacaoFederalId = ParametrosEstoque.TributacaoFederalPadraoId > 0 ? ParametrosEstoque.TributacaoFederalPadraoId : null,
                        TributacaoAplicacaoId = ParametrosEstoque.AplicacaoProdutoPadraoId,
                        UnidadeMedidaId = ParametrosEstoque.UNPadraoId,
                        TributacaoNCMId = ncmIdPadrao,
                        Ativo = true
                    },

                    Valores = new EstoqueItemValores
                    {
                        PrecoCusto = ParametrosEstoque.PrecoCustoPadrao,
                        PrecoVenda = ParametrosEstoque.PrecoVendaPadrao,
                        MargemLucroPercentual = ParametrosEstoque.MargemLucroPadrao,
                        Ativo = true
                    },

                    Classificacao = new EstoqueItemClassificacao(),
                    Adicional = new EstoqueItemAdicional()
                };

                // Gerar código de barras automático (com prefixo, se houver)
                if (ParametrosEstoque.GerarCodigoBarrasAuto && string.IsNullOrWhiteSpace(itemSelecionado.CodigoBarras))
                {
                    var cod = CodigoBarrasHelper.GerarCodigoBarras();
                    if (!string.IsNullOrWhiteSpace(ParametrosEstoque.CodigoBarrasPrefixo))
                        cod = ParametrosEstoque.CodigoBarrasPrefixo + cod;

                    itemSelecionado.CodigoBarras = cod;
                }
            }
        }


        private void CarregarCamposCadastro()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                cmbTipoCadastroEstoque.SelectedValue = (int)ParametrosEstoque.TipoCadastroPadrao;
                cmbUN.SelectedValue = ParametrosEstoque.UNPadraoId;
                cmbAplicacaoProduto.SelectedValue = ParametrosEstoque.AplicacaoProdutoPadraoId;

                // Esses só se existirem no combo (IDs válidos e ativos)
                if (ParametrosEstoque.TributacaoFederalPadraoId > 0)
                    cmbTributacaoFederal.SelectedValue = ParametrosEstoque.TributacaoFederalPadraoId;

                if (ParametrosEstoque.TributacaoEstadualPadraoId > 0)
                    cmbTributacaoEstadual.SelectedValue = ParametrosEstoque.TributacaoEstadualPadraoId;

                if (!string.IsNullOrWhiteSpace(ParametrosEstoque.NcmPadrao))
                    txtNCM.Text = ParametrosEstoque.NcmPadrao;

                ckAtivo.Checked = ParametrosEstoque.AtivoPadrao;

                // Preços/margem padrão
                txtPrecoCusto.Text = ParametrosEstoque.PrecoCustoPadrao.ToString("N4");
                txtMargemLucro.Text = ParametrosEstoque.MargemLucroPadrao.ToString("N2");
                txtPrecoVenda.Text = ParametrosEstoque.PrecoVendaPadrao.ToString("N4");

                // Se configurado, recalcular automaticamente
                if (ParametrosEstoque.CalcularPrecoVendaAuto &&
                    decimal.TryParse(txtPrecoCusto.Text, out var pc) &&
                    decimal.TryParse(txtMargemLucro.Text, out var mg))
                {
                    var pv = pc * (1 + (mg / 100m));
                    txtPrecoVenda.Text = pv.ToString("N4");
                }
                else if (ParametrosEstoque.RecalcularMargemAuto &&
                         decimal.TryParse(txtPrecoCusto.Text, out var pc2) &&
                         decimal.TryParse(txtPrecoVenda.Text, out var pv2) &&
                         pc2 > 0)
                {
                    var mg2 = ((pv2 / pc2) - 1m) * 100m;
                    txtMargemLucro.Text = mg2.ToString("N2");
                }

                // Popular campo visual com o código de barras, se gerado
                if (!string.IsNullOrWhiteSpace(itemSelecionado?.CodigoBarras))
                    txtCodigoBarra.Text = itemSelecionado.CodigoBarras;
            }

            if (itemSelecionado == null)
            {
                return;
            }
            txtDescricao.Text = itemSelecionado.Nome;
            lblDescricao.Text = itemSelecionado.Nome;
            txtCodigoBarra.Text = itemSelecionado.CodigoBarras;
            txtReferencia.Text = itemSelecionado.Referencia;
            ckAtivo.Checked = itemSelecionado.Ativo;
            cmbUN.SelectedValue = itemSelecionado.Tributacao?.UnidadeMedidaId ?? 1;
            cmbTipoCadastroEstoque.SelectedValue = (int)itemSelecionado.TipoCadastroItem;

        }

        private void CarregarCamposTributacao()
        {
            var tributacao = itemSelecionado?.Tributacao;
            if (tributacao == null)
                return;

            cmbTributacaoEstadual.SelectedValue = (int)(tributacao.TributacaoEstadualId ?? 1);
            cmbTributacaoFederal.SelectedValue = (int)(tributacao.TributacaoFederalId ?? 1);
            cmbAplicacaoProduto.SelectedValue = (int)(tributacao.TributacaoAplicacaoId ?? 1);

            if (tributacao.TributacaoNCMId.HasValue)
            {
                var ncm = _context.TributacoesNCM.FirstOrDefault(n => n.Id == tributacao.TributacaoNCMId);
                txtNCM.Text = ncm?.Codigo ?? string.Empty;
            }
        }
        
        private void CarregarQtde()
        {
            if (itemSelecionado?.Qtde == null || itemSelecionado.Qtde.Count == 0)
            {
                txtQtdeAtual.Text = "0.00";
                return;
            }
            var qtdeTotal = itemSelecionado.Qtde.Sum(q => q.QtdeDisponivel);
            txtQtdeAtual.Text = qtdeTotal.ToString("N2");
        }
        private void CarregarGrade(bool inclusao = false)
        {
            if (itemSelecionado?.Grades == null)
                return;

            _context.ChangeTracker.Clear();

            var qtdePorGradePersistida = _context.EstoqueItemQtde
                .Where(q => q.EstoqueItemId == itemSelecionado.Id && q.EstoqueItemGradeId != null)
                .ToDictionary(q => q.EstoqueItemGradeId!.Value, q => q.QtdeDisponivel);

            var viewModels = itemSelecionado.Grades
                .Select(grade =>
                {
                    var vm = new EstoqueItemGradeViewModel();
                    vm.PreencherCom(grade);

                    // Verifica se há um ajuste pendente para esta grade
                    var ajustePendente = _ajustesPendentes.FirstOrDefault(a => a.Grade.Id == grade.Id);

                    if (ajustePendente != default)
                    {
                        vm.QtdeDisponivel = ajustePendente.Qtde;
                    }
                    else
                    {
                        vm.QtdeDisponivel = qtdePorGradePersistida.TryGetValue(grade.Id, out var qtde) ? qtde : 0;
                    }

                    return vm;
                })
                .OrderBy(g => g.Cor)
                .ThenBy(g => g.Tamanho)
                .ToList();

            gridGrade.DataSource = viewModels;

            if (inclusao)
            {
                gridGrade.SelecionarUltimaLinha();
            }

            var totalGrades = viewModels.Sum(g => g.QtdeDisponivel);
            lblQtdeGrade.Text = $"Qtde atual: {totalGrades:N2}";
        }

        private void CarregarCamposValores()
        {
            if (itemSelecionado?.Valores == null)
                return;

            txtPrecoCusto.Text = itemSelecionado.Valores.PrecoCusto.ToString("N4");
            txtPrecoVenda.Text = itemSelecionado.Valores.PrecoVenda.ToString("N4");
            txtMargemLucro.Text = itemSelecionado.Valores.MargemLucroPercentual?.ToString("N2") ?? string.Empty;
        }

        private void CarregarCamposAdicionais()
        {
            if (itemSelecionado?.Adicional != null)
            {
                txtAdicional1.Text = itemSelecionado.Adicional.Adicional1;
                txtAdicional2.Text = itemSelecionado.Adicional.Adicional2;
                txtAdicional3.Text = itemSelecionado.Adicional.Adicional3;
                txtAdicional4.Text = itemSelecionado.Adicional.Adicional4;
                txtAdicional5.Text = itemSelecionado.Adicional.Adicional5;
                txtObservacao.Text = itemSelecionado.Adicional.Observacao;
            }
        }

        private void CarregarComboTipoCadastro()
        {
            cmbTipoCadastroEstoque.PreencherComboBox<TipoCadastroItemEstoque>(usarKeyValue: true);
        }

        private void CarregarComboTributacaoAplicacao()
        {
            cmbAplicacaoProduto.PreencherComboComDbSet<TributacaoAplicacao>(_context, x => $"{x.Codigo} - {x.Descricao}", x => x.Id);
        }

        private string ObterNomeFornecedor(int fornecedorId)
        {
            var fornecedor = _context.Pessoas
                .Include(p => p.PessoaFisica)
                .Include(p => p.PessoaJuridica)
                .FirstOrDefault(p => p.Id == fornecedorId);

            if (fornecedor == null)
                return "";

            return fornecedor.Tipo switch
            {
                TipoPessoa.Fisica => fornecedor.PessoaFisica?.NomeCompleto ?? "",
                TipoPessoa.Juridica => fornecedor.PessoaJuridica?.RazaoSocial ?? "",
                _ => ""
            };
        }

        private void CarregarCamposClassificacao()
        {
            if (itemSelecionado?.Classificacao == null)
                return;

            var classificacao = itemSelecionado.Classificacao;

            if (classificacao.GrupoId.HasValue)
            {
                var grupo = _context.Grupos.FirstOrDefault(p => p.Id == classificacao.GrupoId.Value);
                txtGrupo.Text = grupo?.Nome ?? "";
            }

            if (classificacao.SubgrupoId.HasValue)
            {
                var subgrupo = _context.Subgrupos.FirstOrDefault(p => p.Id == classificacao.SubgrupoId.Value);
                txtSubGrupo.Text = subgrupo?.Nome ?? "";
            }

            if (classificacao.MarcaId.HasValue)
            {
                var marca = _context.Marcas.FirstOrDefault(p => p.Id == classificacao.MarcaId.Value);
                txtMarca.Text = marca?.Nome ?? "";
            }

            if (classificacao.FornecedorId.HasValue)
            {
                txtFornecedor.Text = ObterNomeFornecedor(classificacao.FornecedorId.Value);
            }
        }
        private void CalcularPrecoVenda()
        {
            if (decimal.TryParse(txtPrecoCusto.Text, out decimal precoCusto) &&
                decimal.TryParse(txtMargemLucro.Text, out decimal margem))
            {
                var precoVenda = precoCusto * (1 + (margem / 100));
                txtPrecoVenda.Text = precoVenda.ToString("N4");
            }
        }
        private void RecalcularMargem()
        {
            if (decimal.TryParse(txtPrecoCusto.Text, out decimal precoCusto) &&
                decimal.TryParse(txtPrecoVenda.Text, out decimal precoVenda) &&
                precoCusto > 0)
            {
                var margem = ((precoVenda / precoCusto) - 1) * 100;
                txtMargemLucro.Text = margem.ToString("N2");
            }
        }
        private void TxtPrecoCusto_Leave_CalculaMargem(object sender, EventArgs e)
        {
            RecalcularMargem();
        }

        private void TxtMargem_Leave_CalculaPrecoVenda(object sender, EventArgs e)
        {
            CalcularPrecoVenda();
        }

        private void TxtPrecoVenda_Leave_CalculaMargem(object sender, EventArgs e)
        {
            RecalcularMargem();
        }

        private void AjustarLayout()
        {
            tbControlEstoque.OcultarAbas();
            cmbTipoCadastroEstoque.Enabled = Operacao == TipoOperacao.Inclusao;

            lblDescricao.Font = new Font(lblDescricao.Font.FontFamily, 15, FontStyle.Regular);
            lblQtdeGrade.Font = new Font(lblQtdeGrade.Font.FontFamily, 11, FontStyle.Bold);            

            //Calcular margem e preço venda
            txtPrecoCusto.Leave += TxtPrecoCusto_Leave_CalculaMargem;
            txtMargemLucro.Leave += TxtMargem_Leave_CalculaPrecoVenda;
            txtPrecoVenda.Leave += TxtPrecoVenda_Leave_CalculaMargem;

            //Hints
            ttHint.SetToolTip(txtCodigoBarra, "Pressione F3 para gerar código de barras.");
            ttHint.SetToolTip(pbCodigoBarras, "Gerar código de barras.");
            ttHint.SetToolTip(btnCadastrarUNMedida, "Gerenciar unidades de medidas.");
            ttHint.SetToolTip(txtNCM, "Pressione F3 para localizar.");
            ttHint.SetToolTip(pbBuscaGrupo, "Localizar grupos.");
            ttHint.SetToolTip(pbBuscaMarca, "Localizar marcas.");
            ttHint.SetToolTip(pbBuscaFornecedor, "Localizar fornecedores.");
            ttHint.SetToolTip(btnCadastrarTributacaoFederal, "Gerenciar tributações.");
            ttHint.SetToolTip(btnCadastroTributacaoEstadual, "Gerenciar tributações.");
        }

        private void EstoqueCadastroForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            InicializarNovoEstoque();
            CarregarUnidadesMedida();
            CarregarComboTipoCadastro();
            CarregarComboTributacaoAplicacao();
            CarregarComboFederal();
            CarregarComboEstadual();
            CarregarCamposCadastro();
            CarregarGrade();
            CarregarQtde();
            EstiloGridHelper.AplicarEstiloModerno(gridGrade);
            GridSettingsHelper.RestaurarConfiguracao(gridGrade, "CadastroEstoqueGrade");
            CarregarCamposTributacao();
            CarregarCamposValores();
            CarregarCamposClassificacao();
            CarregarCamposAdicionais();
        }

        private void EstoqueCadastroForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;

                case Keys.F6:
                    btnGravar.PerformClick();
                    break;
            }
        }

        private void pbBuscaNCM_Click(object sender, EventArgs e)
        {
            var formSelecaoNCM = new TributacaoNCMForm(_context);

            if (formSelecaoNCM.ShowDialog() == DialogResult.OK)
            {
                var ncmSelecionado = formSelecaoNCM.ItemSelecionado;
                txtNCM.Text = ncmSelecionado.Codigo;
            }
        }

        private void btnAdicionarGrade_Click(object sender, EventArgs e)
        {
            var formCadastroGrade = new EstoqueCadastroGradeForm(_context)
            {
                itemSelecionado = itemSelecionado,
                Operacao = TipoOperacao.Inclusao
            };

            if (formCadastroGrade.ShowDialog() == DialogResult.OK)
            {
                var grade = formCadastroGrade.NovaGrade;
                itemSelecionado.Grades.Add(grade); 

                if (formCadastroGrade.QuantidadeDigitada is decimal qtde)
                    _ajustesPendentes.Add((grade, qtde));

                CarregarGrade(inclusao:true);
            }
        }

        private void AtualizarAjusteSeNecessario(EstoqueItemGrade grade, decimal novaQtde)
        {
            var qtdeExistente = _context.EstoqueItemQtde
                .AsNoTracking()
                .FirstOrDefault(q => q.EstoqueItemGradeId == grade.Id)?
                .QtdeDisponivel ?? 0;

            if (qtdeExistente != novaQtde)
            {
                _ajustesPendentes.RemoveAll(a => a.Grade.Id == grade.Id);
                _ajustesPendentes.Add((grade, novaQtde));
            }
        }


        private void btnAlterarGrade_Click(object sender, EventArgs e)
        {
            if (gridGrade.CurrentRow == null || gridGrade.CurrentRow.DataBoundItem is not EstoqueItemGradeViewModel gradeSelecionadaVM)
            {
                MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                return;
            }

            var gradeSelecionadaOriginal = itemSelecionado.Grades.FirstOrDefault(g => g.Id == gradeSelecionadaVM.Id);
            if (gradeSelecionadaOriginal == null)
            {
                MensagemHelper.Alerta("Não foi possível localizar a grade selecionada.");
                return;
            }

            var formCadastroGrade = new EstoqueCadastroGradeForm(_context)
            {
                itemSelecionado = itemSelecionado,
                GradeSelecionada = gradeSelecionadaOriginal,
                Operacao = TipoOperacao.Edicao
            };

            if (formCadastroGrade.ShowDialog() == DialogResult.OK)
            {
                if (formCadastroGrade.QuantidadeDigitada is decimal novaQtde)
                    AtualizarAjusteSeNecessario(gradeSelecionadaOriginal, novaQtde);

                int id = gradeSelecionadaOriginal.Id;
                int colIndex = gridGrade.CurrentCell?.ColumnIndex ?? 0;

                CarregarGrade();

                GridSelectionHelper.RestaurarCelulaPorId(gridGrade, id, colIndex);
            }
        }

        private void EstoqueCadastroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridGrade, "CadastroEstoqueGrade");
        }

        private void pbCodigoBarras_Click(object sender, EventArgs e)
        {
            txtCodigoBarra.Text = CodigoBarrasHelper.GerarCodigoBarras();
        }

        private bool PodeExcluirGrade(EstoqueItemGrade grade)
        {

            if (_context.EstoqueItensMovimentacoes
                .Any(m => m.EstoqueItemGradeId == grade.Id &&
                          m.Origem != OrigemMovimentacaoEstoque.AjusteManual))
            {
                return false;
            }

            if (_context.NotaFiscalItemGrades.Any(n => n.EstoqueItemGradeId == grade.Id))
            {
                return false;
            }

            if (_context.DAVCondicionalItemGrades.Any(n => n.GradeId == grade.Id))
            {
                return false;
            }

            return true;
        }

        private void btnExcluirGrade_Click(object sender, EventArgs e)
        {
            if (gridGrade.CurrentRow == null || gridGrade.CurrentRow.DataBoundItem is not EstoqueItemGradeViewModel gradeSelecionadaVM)
            {
                MensagemHelper.Alerta(MensagensComuns.NenhumRegistroSelecionado);
                return;
            }

            var gradeParaExcluir = itemSelecionado.Grades.FirstOrDefault(g => g.Id == gradeSelecionadaVM.Id);

            if (gradeParaExcluir == null)
            {
                MensagemHelper.Alerta(MensagensEstoque.EstoqueGradeNaoLocalizada);
                return;
            }

            if (!PodeExcluirGrade(gradeParaExcluir))
            {
                MensagemHelper.Alerta(MensagensEstoque.EstoqueGradePossuiMovimentacoes);
                return;
            }

            if (MensagemHelper.Confirmar(MensagensComuns.ConfirmarExclusao) != DialogResult.Yes)
            {
                return;
            }

            _ajustesPendentes.RemoveAll(a => a.Grade.Id == gradeParaExcluir.Id);

            //var qtdeAssociadas = _context.EstoqueItemQtde
            //    .Where(q => q.EstoqueItemGradeId == gradeParaExcluir.Id)
            //    .ToList();

            //if (qtdeAssociadas.Any())
            //{
            //    _context.EstoqueItemQtde.RemoveRange(qtdeAssociadas);
            //}

            //var qtdeAjustes = _context.EstoqueItensAjustesManuais
            //    .Where(q => q.EstoqueItemGradeId == gradeParaExcluir.Id)
            //    .ToList();

            //if (qtdeAjustes.Any())
            //{
            //    _context.EstoqueItensAjustesManuais.RemoveRange(qtdeAjustes);
            //}

            //var gradeMovimentacoes = _context.EstoqueItensMovimentacoes
            //    .Where(q => q.EstoqueItemGradeId == gradeParaExcluir.Id)
            //    .ToList();

            //if (gradeMovimentacoes.Any())
            //{
            //    _context.EstoqueItensMovimentacoes.RemoveRange(gradeMovimentacoes);
            //}

            itemSelecionado.Grades.Remove(gradeParaExcluir);
            CarregarGrade();
        }

        private void EstoqueCadastroForm_Shown(object sender, EventArgs e)
        {
            MostrarApenasTab(tbCadastro);
        }

        private void btnCadastrarTributacaoFederal_Click(object sender, EventArgs e)
        {
            var formTributacaoFederal = new TributacaoFederalForm(_context);

            if (formTributacaoFederal.ShowDialog() == DialogResult.OK)
            {
                CarregarComboFederal();
                cmbTributacaoFederal.SelectedValue = formTributacaoFederal.ItemSelecionado.Id;
            }
        }

        private void btnCadastroTributacaoEstadual_Click(object sender, EventArgs e)
        {
            var formTributacaoEstadual = new TributacaoEstadualForm(_context);

            if (formTributacaoEstadual.ShowDialog() == DialogResult.OK)
            {
                CarregarComboEstadual();
                cmbTributacaoEstadual.SelectedValue = formTributacaoEstadual.ItemSelecionado.Id;
            }
        }

        private void pbBuscaGrupo_Click(object sender, EventArgs e)
        {
            var formGrupo = new GrupoForm(_context);

            if (formGrupo.ShowDialog() == DialogResult.OK)
            {
                txtGrupo.Text = formGrupo.ItemSelecionado.Nome;
                itemSelecionado.Classificacao.GrupoId = formGrupo.ItemSelecionado.Id;
            }
            else
            {
                itemSelecionado.Classificacao.GrupoId = null;
                txtGrupo.Text = string.Empty;
            }
        }

        private void pbBuscaMarca_Click(object sender, EventArgs e)
        {
            var formMarca = new MarcaForm(_context);

            if (formMarca.ShowDialog() == DialogResult.OK)
            {
                txtMarca.Text = formMarca.ItemSelecionado.Nome;
                itemSelecionado.Classificacao.MarcaId = formMarca.ItemSelecionado.Id;
            }
            else
            {
                itemSelecionado.Classificacao.MarcaId = null;
                txtMarca.Text = string.Empty;
            }
        }

        private void pbBuscaFornecedor_Click(object sender, EventArgs e)
        {
            var formSelecaoFornecedor = new PessoaSelecaoForm(_context);

            if (formSelecaoFornecedor.ShowDialog() == DialogResult.OK)
            {
                var fornecedorSelecionado = formSelecaoFornecedor.ItemSelecionado;
                itemSelecionado.Classificacao.FornecedorId = fornecedorSelecionado.Id;
                txtFornecedor.Text = ObterNomeFornecedor(fornecedorSelecionado.Id);
            }
            else
            {
                itemSelecionado.Classificacao.FornecedorId = null;
                txtFornecedor.Text = string.Empty;
            }
        }

        private void btnCadastrarUNMedida_Click(object sender, EventArgs e)
        {
            var formTributacaoUNMedida = new TributacaoUNMedidaForm(_context);

            if (formTributacaoUNMedida.ShowDialog() == DialogResult.OK)
            {
                CarregarUnidadesMedida();
                cmbUN.SelectedValue = formTributacaoUNMedida.ItemSelecionado.Id;
            }
        }

        private void txtCodigoBarra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                pbCodigoBarras_Click(sender, e);
            }

        }

        private void cmbTipoCadastroEstoque_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoCadastroEstoque.SelectedItem is KeyValuePair<int, string> item)
            {
                var tipoSelecionado = (TipoCadastroItemEstoque)item.Key;

                switch (tipoSelecionado)
                {
                    case TipoCadastroItemEstoque.Normal:
                        tbControlEstoque.SelectedTab = tbEstoqueNormal;
                        break;

                    case TipoCadastroItemEstoque.Grade:
                        tbControlEstoque.SelectedTab = tbEstoqueGrade;
                        break;

                    default:
                        break;
                }
            }

        }

        private void pbBuscaSubgrupo_Click(object sender, EventArgs e)
        {
            var formSubGrupo = new SubGrupoForm(_context);

            if (formSubGrupo.ShowDialog() == DialogResult.OK)
            {
                txtSubGrupo.Text = formSubGrupo.ItemSelecionado.Nome;
                itemSelecionado.Classificacao.SubgrupoId = formSubGrupo.ItemSelecionado.Id;
                txtGrupo.Text = formSubGrupo.ItemSelecionado.Grupo?.Nome ?? string.Empty;
                itemSelecionado.Classificacao.GrupoId = formSubGrupo.ItemSelecionado.Grupo?.Id;
            }
            else
            {
                itemSelecionado.Classificacao.SubgrupoId = null;
                txtSubGrupo.Text = string.Empty;
                itemSelecionado.Classificacao.GrupoId = null;
                txtGrupo.Text = string.Empty;
            }
        }
    }
}
