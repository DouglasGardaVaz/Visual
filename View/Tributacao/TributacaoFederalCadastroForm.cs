using Dados.Data;
using Dados.Enums;
using Dados.Model.Tributacao;
using Microsoft.EntityFrameworkCore;
using Visual.Helpers.Form;

namespace Visual.View.Tributacao.FederalCadastroFormulario
{
    public partial class TributacaoFederalCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public TributacaoFederal ItemSelecionado { get; set; }
        public TributacaoFederalCadastroForm(DataContext context)
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
            _context = context;
        }
        private void InicializarNovaTributacao()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                ItemSelecionado = new TributacaoFederal();
            }
        }
        private void CarregarCombos()
        {
            cmbIPI.PreencherComboComDbSet<TributacaoIPI>(_context, x => $"{x.Codigo} - {x.Descricao}", x => x.Codigo);
            cmbPIS.PreencherComboComDbSet<TributacaoPIS>(_context, x => $"{x.Codigo} - {x.Descricao}", x => x.Codigo);
            cmbCOFINS.PreencherComboComDbSet<TributacaoCOFINS>(_context, x => $"{x.Codigo} - {x.Descricao}", x => x.Codigo);
            cmbOrigem.PreencherComboComDbSet<TributacaoOrigem>(_context, x => $"{x.Codigo} - {x.Descricao}", x => x.Codigo);
        }
        private void CarregarCampos()
        {
            if (ItemSelecionado == null)
            {
                return;
            }
            txtDescricao.Text = ItemSelecionado.Nome;
            cmbIPI.SelectedValue = ItemSelecionado.IpiCodigo ?? "";
            txtAliquotaIPI.Text = ItemSelecionado.IpiAliquota?.ToString("F2");
            cmbPIS.SelectedValue = ItemSelecionado.PisCodigo ?? ""; ;
            txtAliquotaPIS.Text = ItemSelecionado.PisAliquota?.ToString("F2");
            cmbCOFINS.SelectedValue = ItemSelecionado.CofinsCodigo ?? ""; ;
            txtAliquotaCOFINS.Text = ItemSelecionado.CofinsAliquota?.ToString("F2");
            cmbOrigem.SelectedValue = ItemSelecionado.Origem ?? 0;
        }
        private void AtualizarObjetoTributacao()
        {
            if (ItemSelecionado == null)
                ItemSelecionado = new TributacaoFederal();

            ItemSelecionado.Nome = txtDescricao.Text.Trim();
            ItemSelecionado.IpiCodigo = cmbIPI.SelectedValue?.ToString();
            ItemSelecionado.IpiAliquota = decimal.TryParse(txtAliquotaIPI.Text, out var aliqIpi) ? aliqIpi : 0;

            ItemSelecionado.PisCodigo = cmbPIS.SelectedValue?.ToString();
            ItemSelecionado.PisAliquota = decimal.TryParse(txtAliquotaPIS.Text, out var aliqPis) ? aliqPis : 0;

            ItemSelecionado.CofinsCodigo = cmbCOFINS.SelectedValue?.ToString();
            ItemSelecionado.CofinsAliquota = decimal.TryParse(txtAliquotaCOFINS.Text, out var aliqCofins) ? aliqCofins : 0;

            ItemSelecionado.Origem = (int)(cmbOrigem.SelectedValue ?? 0);
        }
        private bool ValidarCamposCadastro()
        {
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("Informe a descrição da tributação.");
                txtDescricao.Focus();
                return false;
            }

            if (cmbIPI.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione um código IPI.");
                cmbIPI.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAliquotaIPI.Text, out var _))
            {
                MensagemHelper.Alerta("Informe uma alíquota de IPI válida.");
                txtAliquotaIPI.Focus();
                return false;
            }

            if (cmbPIS.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione um código PIS.");
                cmbPIS.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAliquotaPIS.Text, out var _))
            {
                MensagemHelper.Alerta("Informe uma alíquota de PIS válida.");
                txtAliquotaPIS.Focus();
                return false;
            }

            if (cmbCOFINS.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione um código COFINS.");
                cmbCOFINS.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAliquotaCOFINS.Text, out var _))
            {
                MensagemHelper.Alerta("Informe uma alíquota de COFINS válida.");
                txtAliquotaCOFINS.Focus();
                return false;
            }

            if (cmbOrigem.SelectedItem == null)
            {
                MensagemHelper.Alerta("Selecione a origem do produto.");
                cmbOrigem.Focus();
                return false;
            }

            return true;
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AtualizarObjetoTributacao();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.TributacoesFederais.Add(ItemSelecionado);
                    break;

                case TipoOperacao.Edicao:
                    _context.Entry(ItemSelecionado).State = EntityState.Modified;
                    break;
            }

            _context.SaveChanges();
        }


        private void TributacaoFederalCadastroForm_Load(object sender, EventArgs e)
        {
            InicializarNovaTributacao();
            CarregarCombos();
            CarregarCampos();
        }

        private void TributacaoFederalCadastroForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F6:
                    btnConfirmar.PerformClick();
                    break;
                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;
            }
        }

        private void TributacaoFederalCadastroForm_Shown(object sender, EventArgs e)
        {
            txtDescricao.Focus();
        }
    }
}
