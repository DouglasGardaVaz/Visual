using Dados.Data;
using Dados.Enums;
using Dados.Model.Estoque;
using Microsoft.EntityFrameworkCore;
using Dados.Helpers.Form;
using Dados.Helpers.Geral;

namespace Dados.View.EstoqueCadastroGradeFormulario
{
    public partial class EstoqueCadastroGradeForm : Form
    {
        private readonly DataContext _context;
        public EstoqueItemGrade NovaGrade { get; private set; }
        public decimal? QuantidadeDigitada { get; private set; }

        public TipoOperacao Operacao { get; set; }
        public EstoqueItemGrade GradeSelecionada { get; set; }
        public EstoqueItem itemSelecionado { get; set; }

        public EstoqueCadastroGradeForm(DataContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void AjustarLayout()
        {
            EstiloGlobal.AplicarEstilo(this);

            txtTamanho.MaxLength = 20;
            txtCor.MaxLength = 50;
            txtCodigoBarra.MaxLength = 20;
            txtQtde.MaxLength = 5;
        }
        private void EstoqueCadastroGradeForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            CarregarCamposGrade();
        }

        private void CarregarCamposGrade()
        {
            if (Operacao == TipoOperacao.Edicao && GradeSelecionada != null)
            {
                txtCor.Text = GradeSelecionada.Cor;
                txtTamanho.Text = GradeSelecionada.Tamanho;
                txtCodigoBarra.Text = GradeSelecionada.CodigoBarras;

                var qtdeGrade = _context.EstoqueItemQtde
                    .AsNoTracking()
                    .FirstOrDefault(q => q.EstoqueItemGradeId == GradeSelecionada.Id);

                txtQtde.Text = qtdeGrade?.QtdeDisponivel.ToString("0.##") ?? "0";

            }
        }

        private bool ValidarCamposGrade()
        {
            var cor = txtCor.Text.Trim();
            var tamanho = txtTamanho.Text.Trim();
            var qtdeTexto = txtQtde.Text.Trim();

            if (string.IsNullOrWhiteSpace(cor))
            {
                MensagemHelper.Alerta("Informe a cor da grade.");
                txtCor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tamanho))
            {
                MensagemHelper.Alerta("Informe o tamanho da grade.");
                txtTamanho.Focus();
                return false;
            }

            bool duplicado = itemSelecionado.Grades.Any(g =>
                string.Equals(g.Cor?.Trim(), cor, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(g.Tamanho?.Trim(), tamanho, StringComparison.OrdinalIgnoreCase) &&
                (Operacao != TipoOperacao.Edicao || g.Id != GradeSelecionada?.Id));

            if (duplicado)
            {
                MensagemHelper.Alerta("Já existe uma grade com essa cor e tamanho para o item selecionado.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(qtdeTexto) || !decimal.TryParse(qtdeTexto, out var qtde) || qtde < 0)
            {
                MensagemHelper.Alerta("Informe uma quantidade válida (número maior ou igual a 0).");
                txtQtde.Focus();
                return false;
            }

            return true;
        }

        private void AtualizarObjetoGrade()
        {
            var cor = txtCor.Text.Trim();
            var tamanho = txtTamanho.Text.Trim();
            var codigoBarras = txtCodigoBarra.Text.Trim();
            var qtdeTexto = txtQtde.Text.Trim();

            if (!decimal.TryParse(qtdeTexto, out var novaQuantidade))
                novaQuantidade = 0;

            QuantidadeDigitada = novaQuantidade;

            if (Operacao == TipoOperacao.Edicao)
            {
                GradeSelecionada.Cor = cor;
                GradeSelecionada.Tamanho = tamanho;
                GradeSelecionada.CodigoBarras = codigoBarras;
            }
            else
            {
                NovaGrade = new EstoqueItemGrade
                {
                    EstoqueItemId = itemSelecionado.Id,
                    Cor = cor,
                    Tamanho = tamanho,
                    CodigoBarras = codigoBarras
                };
               
            }           
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposGrade())
            {
                DialogResult = DialogResult.None;
                return;
            }

            AtualizarObjetoGrade();           
        }

        private void pbCodigoBarras_Click(object sender, EventArgs e)
        {
            txtCodigoBarra.Text = CodigoBarrasHelper.GerarCodigoBarras();
        }

        private void EstoqueCadastroGradeForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F6:
                    btnGravar.PerformClick();
                    break;
                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;
            }
        }
    }
}
