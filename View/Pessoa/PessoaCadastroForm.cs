using System.Data;
using Dados.Constantes;
using Dados.Data;
using Dados.Enums;
using Dados.Enums.Pessoa;
using Dados.Helpers.Geral.HelpersGeralDocumentos;
using Dados.Helpers.Utils;
using Dados.Model.Configuracao.Parametros.Pessoa;
using Dados.Model.PessoaDocumentoModel;
using Dados.Model.PessoaEnderecoModel;
using Dados.Model.PessoaJuridicaModel;
using Dados.ViewModel.Pessoa;
using Microsoft.EntityFrameworkCore;
using Visual.Constantes.Mensagens.Global;
using Visual.Helpers.Form;
using Visual.Helpers.Grid;
using Visual.Helpers.Validador.DocumentoValidator;
using Visual.View.Pessoa.CadastroEnderecoFormulario;
using Visual.View.PessoaCadastroContatoFormulario;
using Visual.View.PessoaCadastroDocumentoFormulario;

namespace Visual.View.Pessoa.PessoaCadastroFormulario
{
    public partial class PessoaCadastroForm : Form
    {
        public TipoOperacao Operacao { get; set; }
        public Dados.Model.PessoaModel.Pessoa itemSelecionado { get; set; }

        private readonly DataContext _context;

        public PessoaCadastroForm(DataContext context)
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
            _context = context;
        }

        private void AjustarComponentes()
        {
            AtualizarDescricaoLabel();
        }
        private void AjustarLayoutTipoPessoa()
        {
            cmbTipoPessoa.Enabled = Operacao == TipoOperacao.Inclusao;

            if (cmbTipoPessoa.SelectedValue is int tipoValor && Enum.IsDefined(typeof(TipoPessoa), tipoValor))
            {
                var tipo = (TipoPessoa)tipoValor;

                pnlCadastroFisica.Visible = tipo == TipoPessoa.Fisica;
                btnAdicional.Visible = tipo == TipoPessoa.Fisica;
                pnlCadastroJuridica.Visible = tipo == TipoPessoa.Juridica;
            }
        }
        private void AtualizarDescricaoLabel()
        {
            if (itemSelecionado == null)
            {
                lblDescricao.Text = "Sem pessoa selecionada";
                return;
            }

            if (itemSelecionado.Tipo == TipoPessoa.Fisica && itemSelecionado.PessoaFisica != null)
            {
                lblDescricao.Text = itemSelecionado.PessoaFisica.NomeCompleto;
            }
            else if (itemSelecionado.Tipo == TipoPessoa.Juridica && itemSelecionado.PessoaJuridica != null)
            {
                lblDescricao.Text = itemSelecionado.PessoaJuridica.NomeFantasia;
            }
        }

        private void InicializarNovaPessoa()
        {
            itemSelecionado = new Dados.Model.PessoaModel.Pessoa
            {
                Tipo = TipoPessoa.Fisica,
                Ativo = true,
                PessoaFisica = new PessoaFisica
                {
                    NomeCompleto = string.Empty,
                    NomeMae = string.Empty,
                    NomePai = string.Empty,
                    LocalTrabalho = string.Empty,
                    Profissao = string.Empty,
                    EstadoCivil = EstadoCivil.Solteiro,
                    Sexo = Sexo.Masculino,
                    RendaMensal = 0,
                    DataNascimento = new DateOnly(2000, 1, 1)
                },
                Enderecos = new List<PessoaEndereco>(),
                Documentos = new List<PessoaDocumento>(),
                Contatos = new List<PessoaContato>()
            };
        }

        private void PessoaCadastroForm_KeyDown(object sender, KeyEventArgs e)
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
        private bool ValidarCamposCadastro()
        {

            int tipoSelecionado = cmbTipoPessoa.SelectedValue is int v ? v : (int)itemSelecionado.Tipo;
            switch ((TipoPessoa)tipoSelecionado)
            {
                case TipoPessoa.Fisica:
                    if (string.IsNullOrWhiteSpace(txtNomeCompleto.Text))
                    {
                        MensagemHelper.Alerta("O campo nome completo é obrigatório. Por favor, preencha-o.");
                        MostrarApenasTab(tbCadastro);
                        txtNomeCompleto.Focus();
                        return false;
                    }

                    string docCPF = DocumentoHelper.ObterCpfFormatado(mskCPF);
                    if (string.IsNullOrWhiteSpace(docCPF))
                    {
                        MensagemHelper.Alerta("O campo CPF é obrigatório. Por favor, preencha-o.");
                        MostrarApenasTab(tbCadastro);
                        mskCPF.Focus();
                        return false;
                    }
                    if (!DocumentoValidator.ValidarCPF(docCPF))
                    {
                        MensagemHelper.Alerta("O CPF informado é inválido.");
                        MostrarApenasTab(tbCadastro);
                        mskCPF.Focus();
                        return false;
                    }

                    if (dtDataNascimento.Value.Date > DateTime.Today)
                    {
                        MensagemHelper.Alerta("O campo data de nascimento não pode ser futura.");
                        MostrarApenasTab(tbCadastro);
                        dtDataNascimento.Focus();
                        return false;
                    }
                    break;
                case TipoPessoa.Juridica:

                    if (string.IsNullOrWhiteSpace(txtRazaoSocial.Text))
                    {
                        MensagemHelper.Alerta("O campo razão social é obrigatório. Por favor, preencha-o.");
                        MostrarApenasTab(tbCadastro);
                        txtRazaoSocial.Focus();
                        return false;
                    }

                    if (string.IsNullOrWhiteSpace(txtFantasia.Text))
                    {
                        MensagemHelper.Alerta("O campo nome fantasia é obrigatório. Por favor, preencha-o.");
                        MostrarApenasTab(tbCadastro);
                        txtFantasia.Focus();
                        return false;
                    }

                    string docCNPJ = DocumentoHelper.ObterCnpjFormatado(mskCNPJ);
                    if (string.IsNullOrWhiteSpace(docCNPJ))
                    {
                        MensagemHelper.Alerta("O campo documento é obrigatório. Por favor, preencha-o.");
                        MostrarApenasTab(tbCadastro);
                        mskCNPJ.Focus();
                        return false;
                    }

                    if (!DocumentoValidator.ValidarCNPJ(docCNPJ))
                    {
                        MensagemHelper.Alerta("O CNPJ informado é inválido.");
                        MostrarApenasTab(tbCadastro);
                        mskCNPJ.Focus();
                        return false;
                    }

                    break;

                default:
                    break;

            }

            if ((Operacao == TipoOperacao.Inclusao) && (ParametrosPessoa.DocumentoUnicoObrigatorio))
            {
                string doc = ((TipoPessoa)tipoSelecionado) == TipoPessoa.Fisica
                    ? DocumentoHelper.ObterCpfFormatado(mskCPF)
                    : DocumentoHelper.ObterCnpjFormatado(mskCNPJ);

                if (!string.IsNullOrWhiteSpace(doc))
                {
                    bool existe = _context.Set<PessoaDocumento>()
                        .AsNoTracking()
                        .Any(d => d.Documento == doc && d.PessoaId != itemSelecionado.Id);

                    if (existe)
                    {
                        MensagemHelper.Alerta("Documento já cadastrado para outra pessoa.");
                        MostrarApenasTab(tbCadastro);
                        return false;
                    }
                }
            }

            if (!ParametrosPessoa.PermitirSalvarSemEndereco &&
                (itemSelecionado.Enderecos == null || !itemSelecionado.Enderecos.Any()))
            {
                MensagemHelper.Alerta("Inclua ao menos um endereço.");
                MostrarApenasTab(tbEndereco);
                return false;
            }
            if (!ParametrosPessoa.PermitirSalvarSemContato &&
                (itemSelecionado.Contatos == null || !itemSelecionado.Contatos.Any()))
            {
                MensagemHelper.Alerta("Inclua ao menos um contato.");
                MostrarApenasTab(tbContato);
                return false;
            }

            return true;
        }
        private void AtualizarObjetoPessoa()
        {

            if (cmbTipoPessoa.SelectedValue is int tipoValor && Enum.IsDefined(typeof(TipoPessoa), tipoValor))
            {
                itemSelecionado.Tipo = (TipoPessoa)tipoValor;
            }
            itemSelecionado.TipoCadastro = TipoCadastroPessoa.Cliente;

            switch (itemSelecionado.Tipo)
            {
                case TipoPessoa.Fisica:
                    itemSelecionado.PessoaFisica ??= new PessoaFisica();

                    itemSelecionado.PessoaFisica.NomeCompleto = txtNomeCompleto.Text;
                    itemSelecionado.PessoaFisica.DataNascimento = DateOnly.FromDateTime(dtDataNascimento.Value);
                    itemSelecionado.PessoaFisica.NomeMae = txtNomeMae.Text;
                    itemSelecionado.PessoaFisica.NomePai = txtNomePai.Text;
                    itemSelecionado.PessoaFisica.LocalTrabalho = txtLocalTrabalho.Text;
                    itemSelecionado.PessoaFisica.Profissao = txtProfissao.Text;
                    itemSelecionado.PessoaFisica.RendaMensal = decimal.TryParse(txtRendaMensal.Text, out var renda) ? renda : 0;
                    itemSelecionado.PessoaFisica.EstadoCivil = (EstadoCivil)(int)cmbEstadoCivil.SelectedValue;
                    itemSelecionado.PessoaFisica.Sexo = (Sexo)(int)cmbSexo.SelectedValue;
                    itemSelecionado.Ativo = ckAtivoFisica.Checked;

                    break;
                case TipoPessoa.Juridica:

                    itemSelecionado.PessoaJuridica ??= new PessoaJuridica();

                    itemSelecionado.PessoaJuridica.RazaoSocial = txtRazaoSocial.Text;
                    itemSelecionado.PessoaJuridica.NomeFantasia = txtFantasia.Text;
                    itemSelecionado.Ativo = ckAtivoJuridica.Checked;
                    break;

                default:
                    break;
            }

            string docCPF = DocumentoHelper.ObterCpfFormatado(mskCPF);
            string docCNPJ = DocumentoHelper.ObterCnpjFormatado(mskCNPJ);


            var docTipo = itemSelecionado.Tipo == TipoPessoa.Fisica
                ? TipoDocumentoPessoa.CPF
                : TipoDocumentoPessoa.CNPJ;

            var docExistente = itemSelecionado.Documentos
                .FirstOrDefault(d => d.TipoDocumentoPessoa == docTipo);

            if (docExistente != null)
            {
                docExistente.Documento = itemSelecionado.Tipo == TipoPessoa.Fisica ? docCPF : docCNPJ;
            }
            else
            {
                itemSelecionado.Documentos.Add(new PessoaDocumento
                {
                    TipoDocumentoPessoa = docTipo,
                    Documento = itemSelecionado.Tipo == TipoPessoa.Fisica ? docCPF : docCNPJ
                });
            }

            var adicionalExistente = _context.Set<PessoaAdicional>().FirstOrDefault(a => a.PessoaId == itemSelecionado.Id);

            if (adicionalExistente != null)
            {
                adicionalExistente.Observacao = txtObservacoes.Text;
            }
            else if (!string.IsNullOrWhiteSpace(txtObservacoes.Text))
            {
                itemSelecionado.Adicionais = new PessoaAdicional
                {
                    Observacao = txtObservacoes.Text,
                    PessoaId = itemSelecionado.Id
                };
            }

        }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AtualizarObjetoPessoa();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.Pessoas.Add(itemSelecionado);
                    break;
                case TipoOperacao.Edicao:
                    break;

                default:
                    break;
            }
            _context.SaveChanges();
        }

        private void PessoaCadastroForm_Load(object sender, EventArgs e)
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                InicializarNovaPessoa();
            }

            cmbTipoPessoa.PreencherComboBox<TipoPessoa>(usarKeyValue: true);
            cmbSexo.PreencherComboBox<Sexo>(usarKeyValue: true);
            cmbEstadoCivil.PreencherComboBox<EstadoCivil>(usarKeyValue: true);

            if (Operacao == TipoOperacao.Inclusao)
            {
                cmbTipoPessoa.SelectedValue = (int)ParametrosPessoa.TipoPessoaPadrao;
                cmbSexo.SelectedValue = (int)ParametrosPessoa.SexoPadrao;
                cmbEstadoCivil.SelectedValue = (int)ParametrosPessoa.EstadoCivilPadrao;
            }

            CarregarCamposCadastro();
            CarregarDocumentos();
            GridSettingsHelper.RestaurarConfiguracao(gridDocumento, "CadastroPessoaDocumento");
            EstiloGridHelper.AplicarEstiloModerno(gridDocumento);
            CarregarDocumentoCPFCNPJ();
            CarregarContatos();
            GridSettingsHelper.RestaurarConfiguracao(gridContato, "CadastroPessoaContato");
            EstiloGridHelper.AplicarEstiloModerno(gridContato);
            CarregarEnderecos();
            GridSettingsHelper.RestaurarConfiguracao(gridEndereco, "CadastroPessoaEndereco");
            EstiloGridHelper.AplicarEstiloModerno(gridEndereco);
            CarregarAdicionais();
            AjustarLayoutComponentes();
        }

        private void PessoaCadastroForm_Shown(object sender, EventArgs e)
        {
            AjustarComponentes();
        }

        private void MostrarApenasTab(TabPage tabParaMostrar)
        {
            tbControlModulos.SelectedTab = tabParaMostrar;
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbCadastro);
        }

        private void btnDocumento_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbDocumento);
        }

        private void btnContato_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbContato);
        }

        private void btnEndereco_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbEndereco);
        }

        private void btnAdicional_Click(object sender, EventArgs e)
        {
            MostrarApenasTab(tbAdicional);
        }

        private void AjustarLayoutComponentes()
        {
            switch (Operacao)
            {
                case TipoOperacao.Inclusao:

                    break;
                case TipoOperacao.Edicao:
                    pnlCadastroFisica.Dock = DockStyle.Fill;
                    pnlCadastroJuridica.Dock = DockStyle.Fill;
                    cmbTipoPessoa.Visible = false;
                    break;

                default:
                    break;
            }
        }

        private void CarregarCamposCadastro()
        {
            if (itemSelecionado == null)
            {
                return;
            }

            cmbTipoPessoa.SelectedValue = (int)itemSelecionado.Tipo;
            AjustarLayoutTipoPessoa();

            switch (itemSelecionado.Tipo)
            {
                case TipoPessoa.Fisica:
                    if (itemSelecionado.PessoaFisica != null)
                    {
                        txtNomeCompleto.Text = itemSelecionado.PessoaFisica.NomeCompleto;
                        dtDataNascimento.Text = itemSelecionado.PessoaFisica.DataNascimento?.ToString("dd/MM/yyyy");
                        txtNomeMae.Text = itemSelecionado.PessoaFisica.NomeMae;
                        txtNomePai.Text = itemSelecionado.PessoaFisica.NomePai;
                        txtLocalTrabalho.Text = itemSelecionado.PessoaFisica.LocalTrabalho;
                        txtProfissao.Text = itemSelecionado.PessoaFisica.Profissao;
                        txtRendaMensal.Text = itemSelecionado.PessoaFisica.RendaMensal.ToString("N2");
                        cmbSexo.SelectedValue = (int)itemSelecionado.PessoaFisica.Sexo;
                        cmbEstadoCivil.SelectedValue = (int)itemSelecionado.PessoaFisica.EstadoCivil;
                        ckAtivoFisica.Checked = itemSelecionado.Ativo;
                    }
                    break;
                case TipoPessoa.Juridica:
                    if (itemSelecionado.PessoaJuridica != null)
                    {
                        txtRazaoSocial.Text = itemSelecionado.PessoaJuridica.RazaoSocial;
                        txtFantasia.Text = itemSelecionado.PessoaJuridica.NomeFantasia;
                        ckAtivoJuridica.Checked = itemSelecionado.Ativo;
                    }
                    break;

                default:
                    break;
            }


        }

        private void cmbTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            AjustarLayoutTipoPessoa();
        }

        private void CarregarDocumentos()
        {
            if (itemSelecionado?.Documentos == null)
            {
                gridDocumento.DataSource = null;
                return;
            }

            gridDocumento.DataSource = itemSelecionado.Documentos
                .Where(d => d.TipoDocumentoPessoa != TipoDocumentoPessoa.CPF &&
                            d.TipoDocumentoPessoa != TipoDocumentoPessoa.CNPJ)
                .MapearFormatado<PessoaDocumento, PessoaDocumentoViewModel>()
                .ToList();

            gridDocumento.ClearSelection();
        }

        private void CarregarDocumentoCPFCNPJ()
        {
            if (itemSelecionado?.Documentos == null)
            {
                mskCPF.Text = string.Empty;
                return;
            }

            int tipoSelecionado = cmbTipoPessoa.SelectedValue is int v ? v : (int)itemSelecionado.Tipo;
            switch ((TipoPessoa)tipoSelecionado)
            {
                case TipoPessoa.Fisica:
                    var docCPF = itemSelecionado.Documentos.FirstOrDefault(d => d.TipoDocumentoPessoa == TipoDocumentoPessoa.CPF);
                    mskCPF.Text = docCPF?.Documento ?? string.Empty;
                    break;
                case TipoPessoa.Juridica:
                    var docCNPJ = itemSelecionado.Documentos.FirstOrDefault(d => d.TipoDocumentoPessoa == TipoDocumentoPessoa.CNPJ);
                    mskCNPJ.Text = docCNPJ?.Documento ?? string.Empty;
                    break;

                default:
                    break;
            }
        }


        private void CarregarContatos()
        {
            if (itemSelecionado?.Documentos == null)
            {
                gridContato.DataSource = null;
                return;
            }

            gridContato.DataSource = itemSelecionado.Contatos
                .MapearFormatado<PessoaContato, PessoaContatoViewModel>()
                .ToList();

            gridContato.ClearSelection();
        }

        private void CarregarEnderecos()
        {
            if (itemSelecionado?.Enderecos == null)
            {
                gridEndereco.DataSource = null;
                return;
            }

            gridEndereco.DataSource = itemSelecionado.Enderecos
                .MapearFormatado<PessoaEndereco, PessoaEnderecoViewModel>()
                .ToList();

            gridEndereco.ClearSelection();
        }

        private void CarregarAdicionais()
        {
            if (itemSelecionado == null || itemSelecionado.Id == 0)
                return;

            var adicional = _context.Set<PessoaAdicional>()
                .AsNoTracking()
                .FirstOrDefault(a => a.PessoaId == itemSelecionado.Id);

            txtObservacoes.Text = adicional?.Observacao ?? string.Empty;
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int tipoPessoa = cmbTipoPessoa.SelectedValue is int v ? v : (int)itemSelecionado.Tipo;
            var fmCadastroDocumento = new PessoaCadastroDocumentoForm
            {
                Operacao = TipoOperacao.Inclusao,
                TipoPessoaDaEntidade = (TipoPessoa)tipoPessoa,
                DocumentosExistentes = itemSelecionado.Documentos.ToList()
            };

            if (fmCadastroDocumento.ShowDialog() == DialogResult.OK)
            {
                var novo = fmCadastroDocumento.DocumentoPreenchido;
                itemSelecionado.Documentos.Add(novo);
                CarregarDocumentos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gridDocumento.CurrentRow == null)
            {
                MessageBox.Show(MensagensComuns.SelecioneParaExcluir, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show(MensagensComuns.ConfirmarExclusao, AppInfo.NomeSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmar != DialogResult.Yes)
            { return; }

            var indice = gridDocumento.CurrentRow.Index;

            var documentos = itemSelecionado.Documentos.ToList();
            documentos.RemoveAt(indice);
            itemSelecionado.Documentos = documentos;

            CarregarDocumentos();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (gridDocumento.CurrentRow == null)
            {
                MessageBox.Show(MensagensComuns.SelecioneParaAlterar, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var indice = gridDocumento.CurrentRow.Index;
            var documentoAtual = itemSelecionado.Documentos.ElementAt(indice);

            var fmCadastroDocumento = new PessoaCadastroDocumentoForm
            {
                Operacao = TipoOperacao.Edicao,
                DocumentoPreenchido = documentoAtual
            };

            if (fmCadastroDocumento.ShowDialog() == DialogResult.OK)
            {
                CarregarDocumentos();
            }
        }

        private void btnAdicionarContato_Click(object sender, EventArgs e)
        {
            var fmCadastroContato = new PessoaCadastroContatoForm
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (fmCadastroContato.ShowDialog() == DialogResult.OK)
            {
                var novo = fmCadastroContato.ContatoPreenchido;
                itemSelecionado.Contatos.Add(novo);
                CarregarContatos();
            }
        }

        private void btnExcluirContato_Click(object sender, EventArgs e)
        {
            if (gridContato.CurrentRow == null)
            {
                MessageBox.Show(MensagensComuns.SelecioneParaExcluir, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show(MensagensComuns.ConfirmarExclusao, AppInfo.NomeSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmar != DialogResult.Yes)
            { return; }

            var indice = gridContato.CurrentRow.Index;

            var contatos = itemSelecionado.Contatos.ToList();
            contatos.RemoveAt(indice);
            itemSelecionado.Contatos = contatos;

            CarregarContatos();
        }

        private void btnAlterarContato_Click(object sender, EventArgs e)
        {
            if (gridContato.CurrentRow == null)
            {
                MessageBox.Show(MensagensComuns.SelecioneParaAlterar, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var indice = gridContato.CurrentRow.Index;
            var contatoAtual = itemSelecionado.Contatos.ElementAt(indice);

            var fmCadastroContato = new PessoaCadastroContatoForm
            {
                Operacao = TipoOperacao.Edicao,
                ContatoPreenchido = contatoAtual
            };

            if (fmCadastroContato.ShowDialog() == DialogResult.OK)
            {
                CarregarContatos();
            }
        }

        private void btnAdicionarEndereco_Click(object sender, EventArgs e)
        {
            var fmCadastroEndereco = new PessoaCadastroEnderecoForm
            {
                Operacao = TipoOperacao.Inclusao
            };

            if (fmCadastroEndereco.ShowDialog() == DialogResult.OK)
            {
                var novo = fmCadastroEndereco.EnderecoPreenchido;
                itemSelecionado.Enderecos.Add(novo);
                CarregarEnderecos();
            }
        }

        private void btnAlterarEndereco_Click(object sender, EventArgs e)
        {
            if (gridEndereco.CurrentRow == null)
            {
                MessageBox.Show(MensagensComuns.SelecioneParaAlterar, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var indice = gridEndereco.CurrentRow.Index;
            var enderecoAtual = itemSelecionado.Enderecos.ElementAt(indice);

            var fmCadastroEndereco = new PessoaCadastroEnderecoForm
            {
                Operacao = TipoOperacao.Edicao,
                EnderecoPreenchido = enderecoAtual
            };

            if (fmCadastroEndereco.ShowDialog() == DialogResult.OK)
            {
                CarregarEnderecos();
            }
        }

        private void btnExcluirEndereco_Click(object sender, EventArgs e)
        {
            if (gridEndereco.CurrentRow == null)
            {
                MessageBox.Show(MensagensComuns.SelecioneParaExcluir, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show(MensagensComuns.ConfirmarExclusao, AppInfo.NomeSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmar != DialogResult.Yes)
            { return; }

            var indice = gridEndereco.CurrentRow.Index;

            var enderecos = itemSelecionado.Enderecos.ToList();
            enderecos.RemoveAt(indice);
            itemSelecionado.Enderecos = enderecos;

            CarregarEnderecos();
        }

        private void PessoaCadastroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSettingsHelper.SalvarConfiguracao(gridContato, "CadastroPessoaContato");
            GridSettingsHelper.SalvarConfiguracao(gridDocumento, "CadastroPessoaDocumento");
            GridSettingsHelper.SalvarConfiguracao(gridEndereco, "CadastroPessoaEndereco");
        }

    }
}
