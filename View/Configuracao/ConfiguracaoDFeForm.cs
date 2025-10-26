using System.Security.Cryptography.X509Certificates;
using Dados.Data;
using Dados.Enums.Saida;
using Dados.Enums.Saida.NotaFiscalEnums;
using Dados.Helpers.Utils;
using Dados.Model.Configuracao.Parametros.Saida.PDV;
using GerencialDFe.Enums.Configs;
using Visual.Helpers.Form;
using Visual.Helpers.Form.Componentes;
using Visual.Helpers.Utils;

namespace Visual.View.Configuracao.ConfiguracaoDFeFormulario
{
    public partial class ConfiguracaoDFeForm : Form
    {
        private readonly DataContext _context = new();
        public ConfiguracaoDFeForm()
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AlimentarComponentes()
        {
            //EMISSÃO
            cmbAmbienteNFCe.PreencherComboBox<AmbienteEmissao>(usarKeyValue: true);
            cmbTipoEmissaoNFCe.PreencherComboBox<TipoEmissao>(usarKeyValue: true);

            //IMPRESSÃO
            cmbLayoutQRCode.PreencherComboBox<LayoutQRCode>(usarKeyValue: true);
            cmbImpressaoItemVendaContingenciaNFCe.PreencherComboBox<ImpressaoItemVendaContingencia>(usarKeyValue: true);
            cmbImpressaoItemVendaNormalNFCe.PreencherComboBox<ImpressaoItemVenda>(usarKeyValue: true);
            cmbModoImpressaoNFCe.PreencherComboBox<ModoImpressao>(usarKeyValue: true);
            ImpressoraHelper.PreencherImpressoras(cmbImpressoraPadraoNFCe);
        }

        private void CarregarSequenciaNFCe()
        {
            var sequenciaService = new SequenciaDocumentoService(_context);
            var serie = txtSerieNFCe.Text;

            var ambiente = AmbienteDocumento.Homologacao;
            int numeroPreview = sequenciaService.ObterNumeroAtualDocumento(
                TipoDocumento.NFCe,
                ModeloDocumento.NFCe,
                serie,
                ambiente
            );
            txtSequenciaNFCeHomologacao.Text = numeroPreview.ToString();

            ambiente = AmbienteDocumento.Producao;
            numeroPreview = sequenciaService.ObterNumeroAtualDocumento(
                TipoDocumento.NFCe,
                ModeloDocumento.NFCe,
                serie,
                ambiente
            );
            txtSequenciaNFCeProducao.Text = numeroPreview.ToString();
        }

        private void SalvarSequenciaNFCe()
        {
            var sequenciaService = new SequenciaDocumentoService(_context);
            var serie = txtSerieNFCe.Text;
            if (int.TryParse(txtSequenciaNFCeHomologacao.Text, out int numeroHomologacao))
            {
                sequenciaService.DefinirNumeroDocumento(
                    TipoDocumento.NFCe,
                    ModeloDocumento.NFCe,
                    serie,
                    AmbienteDocumento.Homologacao,
                    numeroHomologacao
                );
            }
            if (int.TryParse(txtSequenciaNFCeProducao.Text, out int numeroProducao))
            {
                sequenciaService.DefinirNumeroDocumento(
                    TipoDocumento.NFCe,
                    ModeloDocumento.NFCe,
                    serie,
                    AmbienteDocumento.Producao,
                    numeroProducao
                );
            }
        }

        private void CarregarConfiguracoes()
        {
            //EMISSÃO
            txtCertificadoNFCe.Text = ParametrosPDV.Certificado;
            txtSerieNFCe.Text = ParametrosPDV.Serie;
            txtIDNFCe.Text = ParametrosPDV.IDToken;
            txtTokenNFCe.Text = ParametrosPDV.Token;
            cmbAmbienteNFCe.SelectedValue = (int)ParametrosPDV.Ambiente;
            cmbTipoEmissaoNFCe.SelectedValue = (int)ParametrosPDV.TipoEmissao;
            CarregarSequenciaNFCe();

            //ARQUIVOS
            txtCaminhoSalvarXMLNFCe.Text = ParametrosPDV.CaminhoXML;
            txtCaminhoSalvarPDFNFCe.Text = ParametrosPDV.CaminhoPDF;
            txtCaminhoSchemasNFCe.Text = ParametrosPDV.CaminhoSchemas;
            cbSalvarXMLServicosNFCe.Checked = ParametrosPDV.SalvarXMLServico;

            //IMPRESSÃO            
            txtNumeroCopiasContingenciaNFCe.Text = ParametrosPDV.NumeroCopiasContingencia.ToString();
            txtNumeroCopiasNormalNFCe.Text = ParametrosPDV.NumeroCopias.ToString();
            cmbHelper.SelecionarItemPorTexto(cmbImpressoraPadraoNFCe, ParametrosPDV.ImpressoraPadrao);
            txtMargemDireitaNFCe.Text = ParametrosPDV.MargemDireita.ToString();
            txtMargemEsquerdaNFCe.Text = ParametrosPDV.MargemEsquerda.ToString();
            cmbLayoutQRCode.SelectedValue = (int)ParametrosPDV.LayoutQRCode;
            cmbImpressaoItemVendaContingenciaNFCe.SelectedValue = (int)ParametrosPDV.ImpressaoItemVendaContingencia;
            cmbImpressaoItemVendaNormalNFCe.SelectedValue = (int)ParametrosPDV.ImpressaoItemVenda;
            cmbModoImpressaoNFCe.SelectedValue = (int)ParametrosPDV.ModoImpressao;
            txtCaminhoLogotipoNFCe.Text = ParametrosPDV.Logotipo;
        }

        private void SalvarConfiguracoes()
        {
            //EMISSÃO
            ParametrosPDV.Certificado = txtCertificadoNFCe.Text;
            var modelo = CertificadoHelper.ObterModeloCertificado(ParametrosPDV.Certificado);
            ParametrosPDV.ModeloCertificado = (int)modelo;

            ParametrosPDV.IDToken = txtIDNFCe.Text;
            ParametrosPDV.Token = txtTokenNFCe.Text;
            ParametrosPDV.Serie = txtSerieNFCe.Text;
            ParametrosPDV.Ambiente = (int)(AmbienteEmissao)cmbAmbienteNFCe.SelectedValue;
            ParametrosPDV.TipoEmissao = (int)(TipoEmissao)cmbTipoEmissaoNFCe.SelectedValue;

            SalvarSequenciaNFCe();

            //ARQUIVOS
            ParametrosPDV.CaminhoXML = txtCaminhoSalvarXMLNFCe.Text;
            ParametrosPDV.CaminhoPDF = txtCaminhoSalvarPDFNFCe.Text;
            ParametrosPDV.CaminhoSchemas = txtCaminhoSchemasNFCe.Text;
            ParametrosPDV.SalvarXMLServico = cbSalvarXMLServicosNFCe.Checked;

            //IMPRESSÃO
            ParametrosPDV.ImpressoraPadrao = cmbHelper.ObterTextoCompletoSelecionado(cmbImpressoraPadraoNFCe);
            ParametrosPDV.NumeroCopias = int.TryParse(txtNumeroCopiasNormalNFCe.Text, out int valor2) ? valor2 : 1;
            ParametrosPDV.NumeroCopiasContingencia = int.TryParse(txtNumeroCopiasContingenciaNFCe.Text, out int valor3) ? valor3 : 1;
            ParametrosPDV.MargemDireita = float.TryParse(txtMargemDireitaNFCe.Text, out float valor4) ? valor4 : 0;
            ParametrosPDV.MargemEsquerda = float.TryParse(txtMargemEsquerdaNFCe.Text, out float valor5) ? valor5 : 0;
            ParametrosPDV.LayoutQRCode = (int)(LayoutQRCode)cmbLayoutQRCode.SelectedValue;
            ParametrosPDV.ImpressaoItemVendaContingencia = (int)(ImpressaoItemVendaContingencia)cmbImpressaoItemVendaContingenciaNFCe.SelectedValue;
            ParametrosPDV.ImpressaoItemVenda = (int)(ImpressaoItemVenda)cmbImpressaoItemVendaNormalNFCe.SelectedValue;
            ParametrosPDV.ModoImpressao = (int)(ModoImpressao)cmbModoImpressaoNFCe.SelectedValue;
            ParametrosPDV.Logotipo = txtCaminhoLogotipoNFCe.Text;

        }
        private void ConfiguracaoDFeForm_Load(object sender, EventArgs e)
        {
            AlimentarComponentes();
            CarregarConfiguracoes();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if (!ValidarPreenchimentoConfiguracoes())
            {
                DialogResult = DialogResult.None;
                return;
            }

            SalvarConfiguracoes();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnGravar_KeyDown(object sender, KeyEventArgs e)
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void gbImpressaoNFCe_Enter(object sender, EventArgs e)
        {

        }

        private void pbBuscaCertificadoNFCe_Click(object sender, EventArgs e)
        {
            string serial = CertificadoHelper.SelecionarCertificadoValido(out X509Certificate2 cert);

            if (!string.IsNullOrEmpty(serial))
            {
                txtCertificadoNFCe.Text = serial;
            }

        }

        private void btnCaminhoXMLNFCe_Click(object sender, EventArgs e)
        {
            FolderHelper.SelecionarPasta(txtCaminhoSalvarXMLNFCe, "Selecione a pasta onde os XMLs serão salvos");
        }

        private void btnCaminhoSchemasNFCe_Click(object sender, EventArgs e)
        {
            FolderHelper.SelecionarPasta(txtCaminhoSchemasNFCe, "Selecione a pasta de schemas");
        }

        private void btnCaminhoLogoTipoNFCe_Click(object sender, EventArgs e)
        {
            FolderHelper.SelecionarImagem(txtCaminhoLogotipoNFCe, "Selecione o logotipo da NFC-e");
        }

        private void cmbAmbienteNFCe_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSequenciaNFCeHomologacao.Visible = (AmbienteDocumento)cmbAmbienteNFCe.SelectedValue == AmbienteDocumento.Homologacao;
            txtSequenciaNFCeProducao.Visible = (AmbienteDocumento)cmbAmbienteNFCe.SelectedValue == AmbienteDocumento.Producao;
        }

        private bool ValidarPreenchimentoConfiguracoes()
        {
            if (string.IsNullOrWhiteSpace(txtCertificadoNFCe.Text))
            {
                MensagemHelper.Alerta("Selecione um certificado digital.");
                txtCertificadoNFCe.Focus();
                return false;
            }

            if (cmbAmbienteNFCe.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione o ambiente de emissão.");
                cmbAmbienteNFCe.Focus();
                return false;
            }

            if (cmbTipoEmissaoNFCe.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione o tipo de emissão.");
                cmbTipoEmissaoNFCe.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSerieNFCe.Text))
            {
                MensagemHelper.Alerta("O campo Série é obrigatório.");
                txtSerieNFCe.Focus();
                return false;
            }

            var ambiente = (AmbienteDocumento)cmbAmbienteNFCe.SelectedValue;

            if (ambiente == AmbienteDocumento.Homologacao && string.IsNullOrWhiteSpace(txtSequenciaNFCeHomologacao.Text))
            {
                MensagemHelper.Alerta("Informe a sequência da NFC-e em homologação.");
                txtSequenciaNFCeHomologacao.Focus();
                return false;
            }

            if (ambiente == AmbienteDocumento.Producao && string.IsNullOrWhiteSpace(txtSequenciaNFCeProducao.Text))
            {
                MensagemHelper.Alerta("Informe a sequência da NFC-e em produção.");
                txtSequenciaNFCeProducao.Focus();
                return false;
            }

            if (!int.TryParse(txtSequenciaNFCeHomologacao.Text, out _) && ambiente == AmbienteDocumento.Homologacao)
            {
                MensagemHelper.Alerta("Informe uma sequência válida (número inteiro) para homologação.");
                txtSequenciaNFCeHomologacao.Focus();
                return false;
            }

            if (!int.TryParse(txtSequenciaNFCeProducao.Text, out _) && ambiente == AmbienteDocumento.Producao)
            {
                MensagemHelper.Alerta("Informe uma sequência válida (número inteiro) para produção.");
                txtSequenciaNFCeProducao.Focus();
                return false;
            }

            return true;
        }

        private void btnCaminhoPDFNFCe_Click(object sender, EventArgs e)
        {
            FolderHelper.SelecionarPasta(txtCaminhoSalvarPDFNFCe, "Selecione a pasta onde os PDF's serão salvos");
        }
    }
}
