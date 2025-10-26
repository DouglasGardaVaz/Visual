using System.Data;
using Dados.Data;
using Dados.Data.Repositories;
using Dados.Enums.Saida.NotaFiscalEnums;
using Dados.Model.Saida.GerenciamentoNotaFiscalView;
using Dados.Model.Saida.NotaFiscalModel;
using Dados.Services.Saida.NotaFiscal;
using Dados.Services.Saida.NotaFiscal.NFCe;
using Dados.ViewModel.Saida.NotaFiscal.ViewModel;
using DFe.Utils;
using GerencialDFe.Config;
using GerencialDFe.Services;
using GerencialDFe.Services.NFCe;
using Microsoft.EntityFrameworkCore;
using NFe.Servicos;
using NFe.Utils.NFe;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.Helpers.Saida.Nota_fiscal;
using Visual.View.Saida.PDV.CancelamentoDFeFormulario;
using Visual.View.Saida.PDV.InutilizacaoDFeFormulario;

namespace Visual.View.Saida.PDV.GerenciamentoDFeFormulario
{
    public partial class GerenciamentoDFeForm : Form
    {
        private NotaFiscal? _notaFiscalAtual;

        private readonly DataContext _context = new();
        private readonly GenericRepository<ViewNotaFiscalGerenciamento> repo;

        public GerenciamentoDFeForm()
        {
            InitializeComponent();
            repo = new GenericRepository<ViewNotaFiscalGerenciamento>(_context);
        }

        private void AtualizarDescricaoComSelecionado()
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is DFeGerenciamentoViewModel selecionado)
            {
                lblDescricao.Text = $"Nota Nº {selecionado.Numero}";

                if (selecionado.Cliente != null)
                    lblDescricao.Text += $" - {selecionado.Cliente}";
            }                
            else
                lblDescricao.Text = string.Empty;
        }


        private void Filtrar(bool buscaCompleta = false)
        {
            try
            {

                var textoBusca = txtBusca.Text?.Trim();
                var dataInicio = dtInicial.Value.Date;
                var dataFim = dtFinal.Value.Date;
                var campoSelecionado = cmbData.SelectedItem as string;
                var statusSelecionado = cmbStatus.SelectedValue as StatusNotaFiscal?;
                var situacaoSelecionada = cmbSituacao.SelectedValue as SituacaoNotaFiscal?;

                // Começa com a query base
                var query = repo.GetAll(noTracking: true);

                // 🔹 Filtro por texto
                if (!string.IsNullOrEmpty(textoBusca))
                {
                    query = query.Where(n =>
                        (n.Cliente != null && n.Cliente.Contains(textoBusca, StringComparison.OrdinalIgnoreCase)) ||
                        (n.ClienteDocumento != null && n.ClienteDocumento.Contains(textoBusca, StringComparison.OrdinalIgnoreCase)));
                }

                // 🔹 Filtro por período (campo data)
                if (campoSelecionado == "Data de emissão")
                {
                    query = query.Where(n =>
                        n.DataHoraEmissao.HasValue &&
                        n.DataHoraEmissao.Value.Date >= dataInicio &&
                        n.DataHoraEmissao.Value.Date <= dataFim);
                }
                else if (campoSelecionado == "Data de cadastro")
                {
                    query = query.Where(n =>
                        n.DataHoraCadastro.HasValue &&
                        n.DataHoraCadastro.Value.Date >= dataInicio &&
                        n.DataHoraCadastro.Value.Date <= dataFim);
                }

                // 🔹 Filtro por status
                if (statusSelecionado.HasValue)
                {
                    query = query.Where(n => n.Status == statusSelecionado.Value);
                }

                // 🔹 Filtro por situação
                if (situacaoSelecionada.HasValue)
                {
                    query = query.Where(n => n.Situacao == situacaoSelecionada.Value);
                }

                // 🔹 Executa a query e preenche ViewModels
                var itens = query
                    .ToList()
                    .Select(n =>
                    {
                        var vm = new DFeGerenciamentoViewModel();
                        vm.PreencherCom(n);
                        return vm;
                    }).OrderByDescending(n => n.Numero)
                    .ToList();

                gridConteudo.DataSource = itens;
                AtualizarTotaisNotas();
            }
            catch (Exception ex)
            {
                MensagemHelper.Erro($"Erro ao filtrar notas: {ex.Message}");
            }
        }




        private void AjustesPersonalizadosColunas()
        {
            var colunasFormatar = new[] { "ValorTotal", "strNumero", "strSituacao", "strStatus" };

            foreach (var nomeColuna in colunasFormatar)
            {
                var coluna = gridConteudo.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.DataPropertyName == nomeColuna);

                if (coluna != null)
                {
                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }
        private void AjustesGrid()
        {
            EstiloGridHelper.AplicarEstiloModerno(gridConteudo);
            AjustesPersonalizadosColunas();
            GridSettingsHelper.RestaurarConfiguracao(gridConteudo, "GridNotasFiscais");
        }

        private void AjustarComponentes()
        {
            //EstiloGlobal.AplicarEstilo(this);
            FiltroNotaFiscalHelper.PreencherStatus(cmbStatus);
            FiltroNotaFiscalHelper.PreencherSituacoes(cmbSituacao);
            FiltroNotaFiscalHelper.PreencherCampoData(cmbData);
            FormSettingsHelper.RestaurarConfiguracao(this, "FormNotasFiscais");
        }

        private void GerenciamentoDFeForm_Load(object sender, EventArgs e)
        {
            AjustarComponentes();
            AjustesGrid();
            Filtrar();
        }

        private void GerenciamentoDFeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridConteudo, "GridNotasFiscais");
            FormSettingsHelper.SalvarConfiguracao(this, "FormNotasFiscais");
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Filtrar();
            }
        }

        private void AtualizarTotaisNotas()
        {
            if (gridConteudo.DataSource is not List<DFeGerenciamentoViewModel> lista) return;

            decimal totalCanceladas = lista
                .Where(x => x.Status == StatusNotaFiscal.Cancelada)
                .Sum(x => x.ValorTotal);

            decimal totalEmitidas = lista
                .Where(x => x.Status == StatusNotaFiscal.Autorizada)
                .Sum(x => x.ValorTotal);

            decimal totalPendentes = lista
                .Where(x => x.Status == StatusNotaFiscal.NaoEnviada)
                .Sum(x => x.ValorTotal);

            lblTotalCanceladas.Text = $"Canceladas: {totalCanceladas:C2}";
            lblTotalEmitidas.Text = $"Emitidas: {totalEmitidas:C2}";
            lblTotalPendentes.Text = $"Pendentes: {totalPendentes:C2}";

            lblTotalEmitidas.ForeColor = Color.Green;
            lblTotalCanceladas.ForeColor = Color.Gray;
            lblTotalPendentes.ForeColor = Color.Black;
        }


        private void gridConteudo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (gridConteudo.Rows[e.RowIndex].DataBoundItem is DFeGerenciamentoViewModel item)
            {
                var row = gridConteudo.Rows[e.RowIndex];
                var status = item.Status;
                var situacao = item.Situacao;

                // Cores combinadas por Status e Situação
                if (status == StatusNotaFiscal.NaoEnviada && situacao == SituacaoNotaFiscal.Pendente)
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                }
                else if (status == StatusNotaFiscal.Autorizada && situacao == SituacaoNotaFiscal.Concluida)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
                else if (status == StatusNotaFiscal.Autorizada && situacao == SituacaoNotaFiscal.Pendente)
                {
                    row.DefaultCellStyle.BackColor = Color.YellowGreen;
                }
                else if (status == StatusNotaFiscal.Cancelada)
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (status == StatusNotaFiscal.Inutilizada)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSlateGray;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (status == StatusNotaFiscal.Denegada)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (status == StatusNotaFiscal.Rejeitada)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    // Fallback visual (default)
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void gridConteudo_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarDescricaoComSelecionado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow == null)
            {
                MensagemHelper.Alerta("Selecione uma nota para cancelar.");
                return;
            }

            if (gridConteudo.CurrentRow?.DataBoundItem is DFeGerenciamentoViewModel selecionado)
            {
                _notaFiscalAtual = _context.NotaFiscal.FirstOrDefault(n => n.Id == selecionado.Id);

                if (_notaFiscalAtual == null)
                {
                    MensagemHelper.Alerta("Nota fiscal não encontrada no banco de dados.");
                    return;
                }

                if (_notaFiscalAtual.Status == StatusNotaFiscal.Cancelada)
                {
                    MensagemHelper.Alerta("Essa nota já foi cancelada.");
                    return;
                }

                if (_notaFiscalAtual.Status != StatusNotaFiscal.Autorizada)
                {
                    MensagemHelper.Alerta("Somente notas autorizadas podem ser canceladas.");
                    return;
                }

                if (MensagemHelper.Confirmar("Deseja realmente cancelar essa nota?") != DialogResult.Yes)
                    return;

                string justificativa = "";

                var formCancelamento = new CancelamentoDFeForm();
                if (formCancelamento.ShowDialog() == DialogResult.OK)
                {
                    justificativa = formCancelamento.justificativa;
                }
                else
                {
                    return;
                }

                bool sucesso = false;
                var mensagem = "";

                EsperaHelper.ExecutarComEspera("Cancelando NFC-e...", () =>
                {
                    var cancelarNFCe = new NFCeOperacoes(_context, _notaFiscalAtual);
                    sucesso = cancelarNFCe.Cancelar(_notaFiscalAtual, justificativa, out mensagem);
                });

                if (sucesso)
                {
                    MensagemHelper.Info(mensagem);
                    Filtrar();
                }
                else
                    MensagemHelper.Erro(mensagem);
            }
        }

        private void GerenciamentoDFeForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F2:
                    btnDetalhe.PerformClick();
                    break;
                case Keys.F3:
                    txtBusca.Focus();
                    break;
                case Keys.F4:
                    btnInutilizar.PerformClick();
                    break;
                case Keys.F5:
                    btnCancelar.PerformClick();
                    break;
                case Keys.F6:
                    btnReabrir.PerformClick();
                    break;
                case Keys.F8:
                    btnTransmitir.PerformClick();
                    break;
            }
        }

        private void btnInutilizar_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is not DFeGerenciamentoViewModel selecionado)
            {
                MensagemHelper.Alerta("Selecione uma nota para inutilizar.");
                return;
            }

            _notaFiscalAtual = _context.NotaFiscal.FirstOrDefault(n => n.Id == selecionado.Id);

            if (_notaFiscalAtual == null)
            {
                MensagemHelper.Alerta("Nota fiscal não encontrada.");
                return;
            }

            if (_notaFiscalAtual.Status == StatusNotaFiscal.Inutilizada)
            {
                MensagemHelper.Alerta("Nota já se encontra inutilizada.");
                return;
            }

            if (_notaFiscalAtual.Status == StatusNotaFiscal.Autorizada)
            {
                MensagemHelper.Alerta("Nota autorizada não pode ser inutilizada.");
                return;
            }

            if (_notaFiscalAtual.Status == StatusNotaFiscal.Cancelada)
            {
                MensagemHelper.Alerta("Nota já cancelada não pode ser inutilizada.");
                return;
            }

            if (MensagemHelper.Confirmar($"Deseja inutilizar a nota nº {_notaFiscalAtual.Numero} da série {_notaFiscalAtual.Serie}?") != DialogResult.Yes)
                return;

            string justificativa = "";

            var formInutilizacao = new InutilizacaoDFeForm();
            formInutilizacao._notaFiscalSelecionada = _notaFiscalAtual;
            if (formInutilizacao.ShowDialog() == DialogResult.OK)
            {
                justificativa = formInutilizacao.justificativa;
            }
            else
            {
                return;
            }

            int ano = _notaFiscalAtual.DataHoraEmissao?.Year % 100 ?? DateTime.Now.Year % 100;
            int serie = _notaFiscalAtual.Serie;
            int numeroInicial = _notaFiscalAtual.Numero;
            int numeroFinal = _notaFiscalAtual.Numero;
            var mensagem = "";
            bool sucesso = false;

            EsperaHelper.ExecutarComEspera("Inutilizando NFC-e...", () =>
            {
                var operacoes = new NFCeOperacoes(_context, _notaFiscalAtual);
                sucesso = operacoes.Inutilizar(ano, serie, numeroInicial, numeroFinal, justificativa, out mensagem);
            });

            if (sucesso)
            {
                MensagemHelper.Info(mensagem);
                Filtrar();
            }
            else
                MensagemHelper.Erro(mensagem);

        }

        private void btnTransmitir_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is not DFeGerenciamentoViewModel selecionado)
            {
                MensagemHelper.Alerta("Selecione uma nota para transmitir.");
                return;
            }

            _notaFiscalAtual = _context.NotaFiscal
                .Include(n => n.Itens).ThenInclude(i => i.Valores)
                .Include(n => n.Destinatario)
                .Include(n => n.Pagamentos)
                .Include(n => n.InformacoesAdicionais)
                .Include(n => n.Origens)
                .FirstOrDefault(n => n.Id == selecionado.Id);

            if (_notaFiscalAtual == null)
            {
                MensagemHelper.Alerta("Nota fiscal não encontrada no banco de dados.");
                return;
            }

            if (_notaFiscalAtual.Status == StatusNotaFiscal.Autorizada || _notaFiscalAtual.Status == StatusNotaFiscal.Cancelada)
            {
                MensagemHelper.Alerta("Nota autorizada, impossível prosseguir!");
                return;
            }

            if (_notaFiscalAtual.Status == StatusNotaFiscal.Inutilizada)
            {
                MensagemHelper.Alerta("Nota inutilizada, impossível prosseguir!");
                return;
            }

            EsperaHelper.ExecutarComEspera("Transmitindo NFC-e...", () =>
            {
                try
                {
                    new NFCeVendaService(_context).AplicarRateioDescontoAcrescimo(_notaFiscalAtual.Id);

                    var transmissor = new NFCeTransmissaoService(_context, _notaFiscalAtual);

                    transmissor.AjustesAntesEmissao();

                    var gerador = new NFCeGeradorXML(_context);
                    string xml = gerador.Gerar(_notaFiscalAtual.Id);
                    string pathXml = Path.Combine(Path.GetTempPath(), $"NFCe_{Guid.NewGuid():N}.xml");
                    File.WriteAllText(pathXml, xml);

                    var nfe = new NFe.Classes.NFe().CarregarDeArquivoXml(pathXml);
                    var emissor = new EmissorNFe(DFeConfigGlobal.Instancia.Configuracoes);

                    var retorno = emissor.Emitir(nfe, numeroLote: 1);

                    if (retorno != null)
                    {
                        transmissor.SalvarRetornoNotaFiscal(retorno);

                        if (retorno.Sucesso)
                        {
                            transmissor.ProcessarSucessoTransmissao(retorno);
                        }
                        else
                        {
                            var statusService = new NotaFiscalStatusService(_context);
                            statusService.DefinirComoRejeitada(_notaFiscalAtual.Id);

                            string erroXml = FuncoesXml.ClasseParaXmlString(nfe);
                            string nomeArquivo = $"NFCe_{retorno?.ChaveAcesso ?? "Erro"}_Erro.xml";
                            string caminhoErro = Path.Combine(DFeConfigGlobal.Instancia.Configuracoes.CfgServico.DiretorioSalvarXml, nomeArquivo);

                            File.WriteAllText(caminhoErro, erroXml);

                            MensagemHelper.Erro($"Erro na transmissão da NF-e:\n\nMensagem SEFAZ: {retorno?.MensagemSefaz ?? "Erro desconhecido"}\nChave: {retorno?.ChaveAcesso ?? "Sem chave"}");
                        }
                    }
                    else
                    {
                        MensagemHelper.Erro("Erro: retorno da SEFAZ está nulo.");
                    }
                }
                catch (Exception ex)
                {
                    MensagemHelper.Erro($"Erro durante a transmissão da nota: {ex.Message}");
                }
            });

            Filtrar();
        }

        private void menuPrincipal_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var config = DFeConfigGlobal.Instancia.Configuracoes;
                using var servico = new ServicosNFe(config.CfgServico);
                var retorno = servico.NfeStatusServico();

                MensagemHelper.Info($"Status: {retorno.Retorno.cStat} - {retorno.Retorno.xMotivo}");
            }
            catch (Exception ex)
            {
                MensagemHelper.Erro($"Erro: {ex.Message}");
            }
        }

        private void consultarSituacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridConteudo.CurrentRow?.DataBoundItem is not DFeGerenciamentoViewModel selecionado)
            {
                MensagemHelper.Alerta("Selecione uma nota para consultar.");
                return;
            }

            var nota = _context.NotaFiscal.FirstOrDefault(n => n.Id == selecionado.Id);

            if (nota == null)
            {
                MensagemHelper.Alerta("Nota não encontrada.");
                return;
            }

            var notaAutorizacao = _context.NotaFiscalAutorizacao.FirstOrDefault(n => n.IdNotaFiscal == selecionado.Id);

            if (nota == null || string.IsNullOrWhiteSpace(notaAutorizacao.Chave))
            {
                MensagemHelper.Alerta("A nota não possui chave de acesso para consulta, tente transmitir.");
                return;
            }

            var servico = new NFCeOperacoes(_context, nota);
            var retorno = servico.ConsultarSituacaoNota(out string mensagem);
            MensagemHelper.Info(mensagem);
        }

        private void toolStripInutilizacaoManual_Click(object sender, EventArgs e)
        {
            int ano = 0;
            int serie = 0;
            int numeroInicial = 0;
            int numeroFinal = 0;
            var mensagem = "";
            bool sucesso = false;
            string justificativa = "";

            var formInutilizacao = new InutilizacaoDFeForm();
            if (formInutilizacao.ShowDialog() == DialogResult.OK)
            {
                justificativa = formInutilizacao.justificativa;
                ano = formInutilizacao.ano;
                serie = formInutilizacao.serie;
                numeroInicial = formInutilizacao.numeroInicial;
                numeroFinal = formInutilizacao.numeroFinal;
            }
            else
            {
                return;
            }

            EsperaHelper.ExecutarComEspera("Inutilizando NFC-e...", () =>
            {
                var operacoes = new NFCeOperacoes(_context, null);
                sucesso = operacoes.Inutilizar(ano, serie, numeroInicial, numeroFinal, justificativa, out mensagem);
            });

            if (sucesso)
                MensagemHelper.Info(mensagem);
            else
                MensagemHelper.Erro(mensagem);
        }

        private void gridConteudo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var nomeColuna = gridConteudo.Columns[e.ColumnIndex].DataPropertyName;
            if (!string.IsNullOrWhiteSpace(nomeColuna))
            {
                gridConteudo.OrdenarPorColuna(nomeColuna);
            }
        }
    }
}
