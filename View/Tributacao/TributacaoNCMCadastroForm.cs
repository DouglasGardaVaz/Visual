using Dados.Data;
using Dados.Enums;
using Dados.Helpers.Geral.HelpersGeralComponentes;
using Dados.Helpers.Localizacao;
using Dados.Model.Tributacao;
using Microsoft.EntityFrameworkCore;
using Visual.Helpers.Form;

namespace Visual.View.Tributacao.NCMCadastroFormulario
{
    public partial class TributacaoNCMCadastroForm : Form
    {
        private readonly DataContext _context;
        public TipoOperacao Operacao { get; set; }
        public TributacaoNCM ItemSelecionado { get; set; }
        public TributacaoNCMCadastroForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);
            txtNCM.MaxLength = 8;
            txtEXIPI.MaxLength = 3;
            var ufs = ListaUF.ObterUF();
            cmbUF.DataSource = ufs;
            cmbUF.DisplayMember = "Sigla";
            cmbUF.ValueMember = "Sigla";
            cmbUF.SelectedIndex = 0;

        }
        private void InicializarNovoNCM()
        {
            if (Operacao == TipoOperacao.Inclusao)
            {
                ItemSelecionado = new TributacaoNCM();
            }
        }
        private void CarregarCampos()
        {
            if (ItemSelecionado == null)
                return;

            txtDescricao.Text = ItemSelecionado.Descricao;
            txtNCM.Text = ItemSelecionado.Codigo;
            ckAtivo.Checked = ItemSelecionado.Ativo;

            var valor = ItemSelecionado.Valores?.FirstOrDefault(v => v.TributacaoNCMId == ItemSelecionado.Id);

            if (valor != null)
            {
                HelpersGeralComp.DefinirComboBoxIndex(cmbUF, valor.Uf);
                txtEXIPI.Text = valor.ExIpi ?? "";

                txtAliquotaIPI.Text = valor.AliquotaIpi?.ToString("N2") ?? "0,00";
                txtAliquotaPIS.Text = valor.AliquotaPis?.ToString("N2") ?? "0,00";
                txtAliquotaCOFINS.Text = valor.AliquotaCofins?.ToString("N2") ?? "0,00";
                txtAliquotaICMS.Text = valor.AliquotaIcms?.ToString("N2") ?? "0,00";

                if (valor.InicioVigencia.HasValue)
                {
                    dtInicioVigencia.Format = DateTimePickerFormat.Short;
                    dtInicioVigencia.Value = valor.InicioVigencia.Value;
                }
                else
                {
                    dtInicioVigencia.Format = DateTimePickerFormat.Custom;
                    dtInicioVigencia.CustomFormat = " ";
                }

                if (valor.FimVigencia.HasValue)
                {
                    dtFimVigencia.Format = DateTimePickerFormat.Short;
                    dtFimVigencia.Value = valor.FimVigencia.Value;
                }
                else
                {
                    dtFimVigencia.Format = DateTimePickerFormat.Custom;
                    dtFimVigencia.CustomFormat = " ";
                }

            }
            else
            {
                dtInicioVigencia.Format = DateTimePickerFormat.Custom;
                dtInicioVigencia.CustomFormat = " ";
                dtFimVigencia.Format = DateTimePickerFormat.Custom;
                dtFimVigencia.CustomFormat = " ";
            }
        }

        private void TributacaoNCMCadastroForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            InicializarNovoNCM();
            CarregarCampos();
        }

        private void TributacaoNCMCadastroForm_KeyDown(object sender, KeyEventArgs e)
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

        private bool ValidarCamposCadastro()
        {
            if (string.IsNullOrWhiteSpace(txtNCM.Text))
            {
                MensagemHelper.Alerta("Informe o NCM da tributação.");
                txtNCM.Focus();
                return false;
            }

            var ncm = txtNCM.Text.Trim();

            if (ncm.Length < 8)
            {
                MensagemHelper.Alerta("O NCM deve conter 8 dígitos.");
                txtNCM.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MensagemHelper.Alerta("Informe a descrição do NCM.");
                txtDescricao.Focus();
                return false;
            }
          
            //if (cmbUF.SelectedValue == null || cmbUF.SelectedValue.ToString()?.Length != 2)
            //{
            //    MensagemHelper.Alerta("Selecione uma UF válida.");
            //    cmbUF.Focus();
            //    return false;
            //}

            if (!decimal.TryParse(txtAliquotaIPI.Text, out _))
            {
                MensagemHelper.Alerta("Informe uma alíquota válida para IPI.");
                txtAliquotaIPI.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAliquotaPIS.Text, out _))
            {
                MensagemHelper.Alerta("Informe uma alíquota válida para PIS.");
                txtAliquotaPIS.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAliquotaCOFINS.Text, out _))
            {
                MensagemHelper.Alerta("Informe uma alíquota válida para COFINS.");
                txtAliquotaCOFINS.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAliquotaICMS.Text, out _))
            {
                MensagemHelper.Alerta("Informe uma alíquota válida para ICMS.");
                txtAliquotaICMS.Focus();
                return false;
            }

            if (dtFimVigencia.Format != DateTimePickerFormat.Custom &&
                dtInicioVigencia.Format == DateTimePickerFormat.Custom)
            {
                MensagemHelper.Alerta("Informe a data de início da vigência.");
                dtInicioVigencia.Focus();
                return false;
            }

            return true;
        }



        private void AtualizarObjetoNCM()
        {
            if (ItemSelecionado == null)
                ItemSelecionado = new TributacaoNCM();

            ItemSelecionado.Codigo = txtNCM.Text.Trim();
            ItemSelecionado.Descricao = txtDescricao.Text.Trim();
            ItemSelecionado.Ativo = ckAtivo.Checked;

            if (ItemSelecionado.Valores == null)
                ItemSelecionado.Valores = new List<TributacaoNCMValores>();

            var valor = ItemSelecionado.Valores.FirstOrDefault(v => v.TributacaoNCMId == ItemSelecionado.Id);

            if (valor == null)
            {
                valor = new TributacaoNCMValores();
                ItemSelecionado.Valores.Add(valor);
            }

            valor.Uf = cmbUF.SelectedValue?.ToString()?.Length == 2 ? cmbUF.SelectedValue.ToString() : null;
            valor.ExIpi = string.IsNullOrWhiteSpace(txtEXIPI.Text) ? null : txtEXIPI.Text.Trim();

            decimal valorDecimal;

            valor.AliquotaIpi = decimal.TryParse(txtAliquotaIPI.Text, out valorDecimal) ? valorDecimal : (decimal?)null;
            valor.AliquotaPis = decimal.TryParse(txtAliquotaPIS.Text, out valorDecimal) ? valorDecimal : (decimal?)null;
            valor.AliquotaCofins = decimal.TryParse(txtAliquotaCOFINS.Text, out valorDecimal) ? valorDecimal : (decimal?)null;
            valor.AliquotaIcms = decimal.TryParse(txtAliquotaICMS.Text, out valorDecimal) ? valorDecimal : (decimal?)null;

            valor.InicioVigencia = dtInicioVigencia.Format == DateTimePickerFormat.Custom
                ? null
                : DateTime.SpecifyKind(dtInicioVigencia.Value, DateTimeKind.Utc);

            valor.FimVigencia = dtFimVigencia.Format == DateTimePickerFormat.Custom
                ? null
                : DateTime.SpecifyKind(dtFimVigencia.Value, DateTimeKind.Utc);


            valor.Ativo = ItemSelecionado.Ativo;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposCadastro())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AtualizarObjetoNCM();

            switch (Operacao)
            {
                case TipoOperacao.Inclusao:
                    _context.TributacoesNCM.Add(ItemSelecionado);
                    break;

                case TipoOperacao.Edicao:
                    _context.Entry(ItemSelecionado).State = EntityState.Modified;

                    foreach (var valor in ItemSelecionado.Valores)
                    {
                        if (valor.Id == 0)
                        {
                            _context.Entry(valor).State = EntityState.Added;
                        }
                        else
                        {
                            _context.Entry(valor).State = EntityState.Modified;
                        }
                    }
                    break;

            }
            _context.SaveChanges();
        }

        private void TributacaoNCMCadastroForm_Shown(object sender, EventArgs e)
        {
            txtNCM.Focus();
        }

        private void dtInicioVigencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                dtInicioVigencia.Format = DateTimePickerFormat.Custom;
                dtInicioVigencia.CustomFormat = " ";
            }
        }

        private void dtFimVigencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                dtFimVigencia.Format = DateTimePickerFormat.Custom;
                dtFimVigencia.CustomFormat = " ";
            }
        }

        private void dtInicioVigencia_ValueChanged(object sender, EventArgs e)
        {
            dtInicioVigencia.Format = DateTimePickerFormat.Short;
        }

        private void dtFimVigencia_ValueChanged(object sender, EventArgs e)
        {
            dtFimVigencia.Format = DateTimePickerFormat.Short;
        }
    }
}
