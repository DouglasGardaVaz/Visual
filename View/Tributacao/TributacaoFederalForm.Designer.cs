namespace Dados.View.TributacaoFederalFormulario
{
    partial class TributacaoFederalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gridConteudo = new DataGridView();
            toolTipHint = new ToolTip(components);
            tbLayoutRodape = new TableLayoutPanel();
            txtBusca = new TextBox();
            btnSelecionar = new Button();
            btnCancelar = new Button();
            pnlConteudo = new Panel();
            tbLayoutOperacoes = new TableLayoutPanel();
            btnAdicionarTributacao = new Button();
            btnAlterarTributacao = new Button();
            btnExcluirTributacao = new Button();
            tableLayoutCabecalho = new TableLayoutPanel();
            lblDescricao = new Label();
            pnlRodape = new Panel();
            pnlCabecalho = new Panel();
            ((System.ComponentModel.ISupportInitialize)gridConteudo).BeginInit();
            tbLayoutRodape.SuspendLayout();
            pnlConteudo.SuspendLayout();
            tbLayoutOperacoes.SuspendLayout();
            tableLayoutCabecalho.SuspendLayout();
            pnlRodape.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            SuspendLayout();
            // 
            // gridConteudo
            // 
            gridConteudo.AllowUserToAddRows = false;
            gridConteudo.AllowUserToDeleteRows = false;
            gridConteudo.AllowUserToOrderColumns = true;
            gridConteudo.BackgroundColor = Color.WhiteSmoke;
            gridConteudo.BorderStyle = BorderStyle.None;
            gridConteudo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridConteudo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridConteudo.Dock = DockStyle.Fill;
            gridConteudo.Location = new Point(10, 10);
            gridConteudo.Margin = new Padding(10);
            gridConteudo.Name = "gridConteudo";
            gridConteudo.ReadOnly = true;
            gridConteudo.ScrollBars = ScrollBars.Vertical;
            gridConteudo.Size = new Size(740, 422);
            gridConteudo.TabIndex = 1;
            gridConteudo.CellMouseDoubleClick += gridConteudo_CellMouseDoubleClick;
            gridConteudo.SelectionChanged += gridConteudo_SelectionChanged;
            // 
            // tbLayoutRodape
            // 
            tbLayoutRodape.ColumnCount = 5;
            tbLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tbLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutRodape.Controls.Add(txtBusca, 2, 0);
            tbLayoutRodape.Controls.Add(btnSelecionar, 4, 0);
            tbLayoutRodape.Controls.Add(btnCancelar, 0, 0);
            tbLayoutRodape.Dock = DockStyle.Bottom;
            tbLayoutRodape.Location = new Point(0, 10);
            tbLayoutRodape.Margin = new Padding(10);
            tbLayoutRodape.Name = "tbLayoutRodape";
            tbLayoutRodape.RowCount = 1;
            tbLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutRodape.Size = new Size(760, 45);
            tbLayoutRodape.TabIndex = 9;
            // 
            // txtBusca
            // 
            txtBusca.BackColor = Color.White;
            txtBusca.BorderStyle = BorderStyle.None;
            txtBusca.CharacterCasing = CharacterCasing.Upper;
            txtBusca.Dock = DockStyle.Fill;
            txtBusca.Font = new Font("Arial", 30F);
            txtBusca.ForeColor = Color.FromArgb(80, 80, 80);
            txtBusca.Location = new Point(233, 0);
            txtBusca.Margin = new Padding(3, 0, 3, 3);
            txtBusca.MaxLength = 100;
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(294, 46);
            txtBusca.TabIndex = 4;
            txtBusca.Tag = "PERSONALIZADO";
            txtBusca.TextAlign = HorizontalAlignment.Center;
            txtBusca.KeyDown += txtBusca_KeyDown;
            // 
            // btnSelecionar
            // 
            btnSelecionar.BackColor = Color.White;
            btnSelecionar.DialogResult = DialogResult.OK;
            btnSelecionar.Dock = DockStyle.Fill;
            btnSelecionar.FlatAppearance.BorderColor = Color.Gray;
            btnSelecionar.FlatAppearance.BorderSize = 0;
            btnSelecionar.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnSelecionar.FlatStyle = FlatStyle.Flat;
            btnSelecionar.Font = new Font("Arial", 11F);
            btnSelecionar.ForeColor = Color.FromArgb(80, 80, 80);
            btnSelecionar.Location = new Point(633, 3);
            btnSelecionar.Name = "btnSelecionar";
            btnSelecionar.Size = new Size(124, 39);
            btnSelecionar.TabIndex = 2;
            btnSelecionar.Text = "&Selecionar | F6";
            btnSelecionar.UseVisualStyleBackColor = false;
            btnSelecionar.Click += btnSelecionar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.FlatAppearance.BorderColor = Color.Gray;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial", 11F);
            btnCancelar.Location = new Point(3, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(124, 39);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "C&ancelar | F4";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(gridConteudo);
            pnlConteudo.Controls.Add(tbLayoutOperacoes);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 43);
            pnlConteudo.Margin = new Padding(0);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(10, 10, 10, 3);
            pnlConteudo.Size = new Size(760, 476);
            pnlConteudo.TabIndex = 10;
            // 
            // tbLayoutOperacoes
            // 
            tbLayoutOperacoes.ColumnCount = 5;
            tbLayoutOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbLayoutOperacoes.Controls.Add(btnAdicionarTributacao, 3, 0);
            tbLayoutOperacoes.Controls.Add(btnAlterarTributacao, 2, 0);
            tbLayoutOperacoes.Controls.Add(btnExcluirTributacao, 1, 0);
            tbLayoutOperacoes.Dock = DockStyle.Bottom;
            tbLayoutOperacoes.Location = new Point(10, 432);
            tbLayoutOperacoes.Margin = new Padding(10);
            tbLayoutOperacoes.Name = "tbLayoutOperacoes";
            tbLayoutOperacoes.RowCount = 1;
            tbLayoutOperacoes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutOperacoes.Size = new Size(740, 41);
            tbLayoutOperacoes.TabIndex = 2;
            // 
            // btnAdicionarTributacao
            // 
            btnAdicionarTributacao.Dock = DockStyle.Fill;
            btnAdicionarTributacao.FlatStyle = FlatStyle.Flat;
            btnAdicionarTributacao.Font = new Font("Arial", 10F);
            btnAdicionarTributacao.Location = new Point(431, 3);
            btnAdicionarTributacao.Name = "btnAdicionarTributacao";
            btnAdicionarTributacao.Size = new Size(110, 35);
            btnAdicionarTributacao.TabIndex = 0;
            btnAdicionarTributacao.Text = "Adicionar";
            btnAdicionarTributacao.UseVisualStyleBackColor = true;
            btnAdicionarTributacao.Click += btnAdicionarTributacao_Click;
            // 
            // btnAlterarTributacao
            // 
            btnAlterarTributacao.Dock = DockStyle.Fill;
            btnAlterarTributacao.FlatStyle = FlatStyle.Flat;
            btnAlterarTributacao.Font = new Font("Arial", 10F);
            btnAlterarTributacao.Location = new Point(315, 3);
            btnAlterarTributacao.Name = "btnAlterarTributacao";
            btnAlterarTributacao.Size = new Size(110, 35);
            btnAlterarTributacao.TabIndex = 1;
            btnAlterarTributacao.Text = "Alterar";
            btnAlterarTributacao.UseVisualStyleBackColor = true;
            btnAlterarTributacao.Click += btnAlterarTributacao_Click;
            // 
            // btnExcluirTributacao
            // 
            btnExcluirTributacao.Dock = DockStyle.Fill;
            btnExcluirTributacao.FlatStyle = FlatStyle.Flat;
            btnExcluirTributacao.Font = new Font("Arial", 10F);
            btnExcluirTributacao.Location = new Point(199, 3);
            btnExcluirTributacao.Name = "btnExcluirTributacao";
            btnExcluirTributacao.Size = new Size(110, 35);
            btnExcluirTributacao.TabIndex = 2;
            btnExcluirTributacao.Text = "Excluir";
            btnExcluirTributacao.UseVisualStyleBackColor = true;
            btnExcluirTributacao.Click += btnExcluirTributacao_Click;
            // 
            // tableLayoutCabecalho
            // 
            tableLayoutCabecalho.ColumnCount = 3;
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutCabecalho.Controls.Add(lblDescricao, 1, 0);
            tableLayoutCabecalho.Dock = DockStyle.Top;
            tableLayoutCabecalho.Location = new Point(0, 0);
            tableLayoutCabecalho.Name = "tableLayoutCabecalho";
            tableLayoutCabecalho.RowCount = 1;
            tableLayoutCabecalho.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutCabecalho.Size = new Size(760, 45);
            tableLayoutCabecalho.TabIndex = 11;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Dock = DockStyle.Fill;
            lblDescricao.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblDescricao.Location = new Point(155, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(450, 45);
            lblDescricao.TabIndex = 0;
            lblDescricao.Text = " ";
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(tbLayoutRodape);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 519);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(760, 55);
            pnlRodape.TabIndex = 12;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Controls.Add(tableLayoutCabecalho);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(760, 43);
            pnlCabecalho.TabIndex = 13;
            // 
            // TributacaoFederalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 574);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
            Controls.Add(pnlRodape);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TributacaoFederalForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Gerencial - Tributações federais";
            FormClosing += TributacaoFederalForm_FormClosing;
            Load += TributacaoFederalForm_Load;
            Shown += TributacaoFederalForm_Shown;
            KeyDown += TributacaoFederalForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gridConteudo).EndInit();
            tbLayoutRodape.ResumeLayout(false);
            tbLayoutRodape.PerformLayout();
            pnlConteudo.ResumeLayout(false);
            tbLayoutOperacoes.ResumeLayout(false);
            tableLayoutCabecalho.ResumeLayout(false);
            tableLayoutCabecalho.PerformLayout();
            pnlRodape.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridConteudo;
        private ToolTip toolTipHint;
        private TableLayoutPanel tbLayoutRodape;
        private TextBox txtBusca;
        private Button btnSelecionar;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private TableLayoutPanel tableLayoutCabecalho;
        private Label lblDescricao;
        private TableLayoutPanel tbLayoutOperacoes;
        private Button btnAdicionarTributacao;
        private Button btnAlterarTributacao;
        private Button btnExcluirTributacao;
        private Panel pnlRodape;
        private Panel pnlCabecalho;
    }
}