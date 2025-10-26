namespace Visual.View.Tributacao.NCMSelecaoFormulario
{
    partial class TributacaoNCMForm
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
            toolTipHint = new ToolTip(components);
            tbLayoutRodape = new TableLayoutPanel();
            txtBusca = new TextBox();
            btnSelecionar = new Button();
            btnCancelar = new Button();
            pnlConteudo = new Panel();
            tbLayoutOperacoes = new TableLayoutPanel();
            btnAdicionarNCM = new Button();
            btnAlterarNCM = new Button();
            btnExcluirNCM = new Button();
            gridConteudo = new DataGridView();
            tbLayoutCabecalho = new TableLayoutPanel();
            lblDescricao = new Label();
            pnlCabecalho = new Panel();
            pnlRodape = new Panel();
            tbLayoutRodape.SuspendLayout();
            pnlConteudo.SuspendLayout();
            tbLayoutOperacoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridConteudo).BeginInit();
            tbLayoutCabecalho.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlRodape.SuspendLayout();
            SuspendLayout();
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
            tbLayoutRodape.Size = new Size(686, 45);
            tbLayoutRodape.TabIndex = 0;
            // 
            // txtBusca
            // 
            txtBusca.BackColor = Color.White;
            txtBusca.BorderStyle = BorderStyle.None;
            txtBusca.CharacterCasing = CharacterCasing.Upper;
            txtBusca.Dock = DockStyle.Fill;
            txtBusca.Font = new Font("Arial", 30F);
            txtBusca.ForeColor = Color.FromArgb(80, 80, 80);
            txtBusca.Location = new Point(218, 0);
            txtBusca.Margin = new Padding(3, 0, 3, 3);
            txtBusca.MaxLength = 100;
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(249, 46);
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
            btnSelecionar.Location = new Point(558, 3);
            btnSelecionar.Name = "btnSelecionar";
            btnSelecionar.Size = new Size(125, 39);
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
            pnlConteudo.Controls.Add(tbLayoutOperacoes);
            pnlConteudo.Controls.Add(gridConteudo);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 50);
            pnlConteudo.Margin = new Padding(0);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(10, 10, 10, 3);
            pnlConteudo.Size = new Size(686, 353);
            pnlConteudo.TabIndex = 7;
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
            tbLayoutOperacoes.Controls.Add(btnAdicionarNCM, 3, 0);
            tbLayoutOperacoes.Controls.Add(btnAlterarNCM, 2, 0);
            tbLayoutOperacoes.Controls.Add(btnExcluirNCM, 1, 0);
            tbLayoutOperacoes.Dock = DockStyle.Bottom;
            tbLayoutOperacoes.Location = new Point(10, 309);
            tbLayoutOperacoes.Margin = new Padding(10);
            tbLayoutOperacoes.Name = "tbLayoutOperacoes";
            tbLayoutOperacoes.RowCount = 1;
            tbLayoutOperacoes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutOperacoes.Size = new Size(666, 41);
            tbLayoutOperacoes.TabIndex = 4;
            // 
            // btnAdicionarNCM
            // 
            btnAdicionarNCM.Dock = DockStyle.Fill;
            btnAdicionarNCM.FlatStyle = FlatStyle.Flat;
            btnAdicionarNCM.Font = new Font("Arial", 10F);
            btnAdicionarNCM.Location = new Point(394, 3);
            btnAdicionarNCM.Name = "btnAdicionarNCM";
            btnAdicionarNCM.Size = new Size(110, 35);
            btnAdicionarNCM.TabIndex = 0;
            btnAdicionarNCM.Text = "Adicionar";
            btnAdicionarNCM.UseVisualStyleBackColor = true;
            btnAdicionarNCM.Click += btnAdicionarNCM_Click;
            // 
            // btnAlterarNCM
            // 
            btnAlterarNCM.Dock = DockStyle.Fill;
            btnAlterarNCM.FlatStyle = FlatStyle.Flat;
            btnAlterarNCM.Font = new Font("Arial", 10F);
            btnAlterarNCM.Location = new Point(278, 3);
            btnAlterarNCM.Name = "btnAlterarNCM";
            btnAlterarNCM.Size = new Size(110, 35);
            btnAlterarNCM.TabIndex = 1;
            btnAlterarNCM.Text = "Alterar";
            btnAlterarNCM.UseVisualStyleBackColor = true;
            btnAlterarNCM.Click += btnAlterarNCM_Click;
            // 
            // btnExcluirNCM
            // 
            btnExcluirNCM.Dock = DockStyle.Fill;
            btnExcluirNCM.FlatStyle = FlatStyle.Flat;
            btnExcluirNCM.Font = new Font("Arial", 10F);
            btnExcluirNCM.Location = new Point(162, 3);
            btnExcluirNCM.Name = "btnExcluirNCM";
            btnExcluirNCM.Size = new Size(110, 35);
            btnExcluirNCM.TabIndex = 2;
            btnExcluirNCM.Text = "Excluir";
            btnExcluirNCM.UseVisualStyleBackColor = true;
            btnExcluirNCM.Click += btnExcluirNCM_Click;
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
            gridConteudo.Margin = new Padding(0);
            gridConteudo.Name = "gridConteudo";
            gridConteudo.ReadOnly = true;
            gridConteudo.ScrollBars = ScrollBars.None;
            gridConteudo.Size = new Size(666, 340);
            gridConteudo.TabIndex = 1;
            gridConteudo.CellDoubleClick += gridConteudo_CellDoubleClick;
            gridConteudo.Scroll += gridConteudo_Scroll;
            gridConteudo.SelectionChanged += gridConteudo_SelectionChanged;
            // 
            // tbLayoutCabecalho
            // 
            tbLayoutCabecalho.ColumnCount = 3;
            tbLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.142857F));
            tbLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.71429F));
            tbLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.142857F));
            tbLayoutCabecalho.Controls.Add(lblDescricao, 1, 0);
            tbLayoutCabecalho.Dock = DockStyle.Top;
            tbLayoutCabecalho.Location = new Point(0, 0);
            tbLayoutCabecalho.Name = "tbLayoutCabecalho";
            tbLayoutCabecalho.RowCount = 1;
            tbLayoutCabecalho.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutCabecalho.Size = new Size(686, 36);
            tbLayoutCabecalho.TabIndex = 8;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Dock = DockStyle.Fill;
            lblDescricao.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblDescricao.Location = new Point(51, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(581, 36);
            lblDescricao.TabIndex = 0;
            lblDescricao.Text = " ";
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Controls.Add(tbLayoutCabecalho);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(686, 50);
            pnlCabecalho.TabIndex = 2;
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(tbLayoutRodape);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 403);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(686, 55);
            pnlRodape.TabIndex = 2;
            // 
            // TributacaoNCMForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 458);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
            Controls.Add(pnlRodape);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TributacaoNCMForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tributação NCM";
            FormClosing += TributacaoNCMSelecaoForm_FormClosing;
            Load += TributacaoNCMSelecaoForm_Load;
            Shown += TributacaoNCMForm_Shown;
            KeyDown += TributacaoNCMSelecaoForm_KeyDown;
            tbLayoutRodape.ResumeLayout(false);
            tbLayoutRodape.PerformLayout();
            pnlConteudo.ResumeLayout(false);
            tbLayoutOperacoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridConteudo).EndInit();
            tbLayoutCabecalho.ResumeLayout(false);
            tbLayoutCabecalho.PerformLayout();
            pnlCabecalho.ResumeLayout(false);
            pnlRodape.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ToolTip toolTipHint;
        private TableLayoutPanel tbLayoutRodape;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private TableLayoutPanel tbLayoutCabecalho;
        private Label lblDescricao;
        private DataGridView gridConteudo;
        private TextBox txtBusca;
        private Button btnSelecionar;
        private Panel pnlCabecalho;
        private Panel pnlRodape;
        private TableLayoutPanel tbLayoutOperacoes;
        private Button btnAdicionarNCM;
        private Button btnAlterarNCM;
        private Button btnExcluirNCM;
    }
}