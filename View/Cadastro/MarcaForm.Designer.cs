namespace Dados.View.Cadastro.MarcaFormulario
{
    partial class MarcaForm
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
            btnAdicionarGrupo = new Button();
            btnAlterarGrupo = new Button();
            btnExcluirGrupo = new Button();
            tableLayoutCabecalho = new TableLayoutPanel();
            lblDescricao = new Label();
            pnlCabecalho = new Panel();
            pnlRodape = new Panel();
            ((System.ComponentModel.ISupportInitialize)gridConteudo).BeginInit();
            tbLayoutRodape.SuspendLayout();
            pnlConteudo.SuspendLayout();
            tbLayoutOperacoes.SuspendLayout();
            tableLayoutCabecalho.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlRodape.SuspendLayout();
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
            gridConteudo.Dock = DockStyle.Top;
            gridConteudo.Location = new Point(10, 10);
            gridConteudo.Margin = new Padding(0);
            gridConteudo.Name = "gridConteudo";
            gridConteudo.ReadOnly = true;
            gridConteudo.ScrollBars = ScrollBars.None;
            gridConteudo.Size = new Size(726, 298);
            gridConteudo.TabIndex = 1;
            gridConteudo.CellDoubleClick += gridConteudo_CellDoubleClick;
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
            tbLayoutRodape.Size = new Size(746, 45);
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
            txtBusca.Location = new Point(230, 0);
            txtBusca.Margin = new Padding(3, 0, 3, 3);
            txtBusca.MaxLength = 100;
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(285, 46);
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
            btnSelecionar.Location = new Point(618, 3);
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
            pnlConteudo.Size = new Size(746, 362);
            pnlConteudo.TabIndex = 16;
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
            tbLayoutOperacoes.Controls.Add(btnAdicionarGrupo, 3, 0);
            tbLayoutOperacoes.Controls.Add(btnAlterarGrupo, 2, 0);
            tbLayoutOperacoes.Controls.Add(btnExcluirGrupo, 1, 0);
            tbLayoutOperacoes.Dock = DockStyle.Bottom;
            tbLayoutOperacoes.Location = new Point(10, 318);
            tbLayoutOperacoes.Margin = new Padding(10);
            tbLayoutOperacoes.Name = "tbLayoutOperacoes";
            tbLayoutOperacoes.RowCount = 1;
            tbLayoutOperacoes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutOperacoes.Size = new Size(726, 41);
            tbLayoutOperacoes.TabIndex = 3;
            // 
            // btnAdicionarGrupo
            // 
            btnAdicionarGrupo.Dock = DockStyle.Fill;
            btnAdicionarGrupo.FlatStyle = FlatStyle.Flat;
            btnAdicionarGrupo.Font = new Font("Arial", 10F);
            btnAdicionarGrupo.Location = new Point(424, 3);
            btnAdicionarGrupo.Name = "btnAdicionarGrupo";
            btnAdicionarGrupo.Size = new Size(110, 35);
            btnAdicionarGrupo.TabIndex = 0;
            btnAdicionarGrupo.Text = "Adicionar";
            btnAdicionarGrupo.UseVisualStyleBackColor = true;
            btnAdicionarGrupo.Click += btnAdicionarMarca_Click;
            // 
            // btnAlterarGrupo
            // 
            btnAlterarGrupo.Dock = DockStyle.Fill;
            btnAlterarGrupo.FlatStyle = FlatStyle.Flat;
            btnAlterarGrupo.Font = new Font("Arial", 10F);
            btnAlterarGrupo.Location = new Point(308, 3);
            btnAlterarGrupo.Name = "btnAlterarGrupo";
            btnAlterarGrupo.Size = new Size(110, 35);
            btnAlterarGrupo.TabIndex = 1;
            btnAlterarGrupo.Text = "Alterar";
            btnAlterarGrupo.UseVisualStyleBackColor = true;
            btnAlterarGrupo.Click += btnAlterarMarca_Click;
            // 
            // btnExcluirGrupo
            // 
            btnExcluirGrupo.Dock = DockStyle.Fill;
            btnExcluirGrupo.FlatStyle = FlatStyle.Flat;
            btnExcluirGrupo.Font = new Font("Arial", 10F);
            btnExcluirGrupo.Location = new Point(192, 3);
            btnExcluirGrupo.Name = "btnExcluirGrupo";
            btnExcluirGrupo.Size = new Size(110, 35);
            btnExcluirGrupo.TabIndex = 2;
            btnExcluirGrupo.Text = "Excluir";
            btnExcluirGrupo.UseVisualStyleBackColor = true;
            btnExcluirGrupo.Click += btnExcluirMarca_Click;
            // 
            // tableLayoutCabecalho
            // 
            tableLayoutCabecalho.ColumnCount = 3;
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.142857F));
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.71429F));
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 7.142857F));
            tableLayoutCabecalho.Controls.Add(lblDescricao, 1, 0);
            tableLayoutCabecalho.Dock = DockStyle.Top;
            tableLayoutCabecalho.Location = new Point(0, 0);
            tableLayoutCabecalho.Name = "tableLayoutCabecalho";
            tableLayoutCabecalho.RowCount = 1;
            tableLayoutCabecalho.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutCabecalho.Size = new Size(746, 45);
            tableLayoutCabecalho.TabIndex = 11;
            // 
            // lblDescricao
            // 
            lblDescricao.Dock = DockStyle.Fill;
            lblDescricao.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblDescricao.Location = new Point(56, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(633, 45);
            lblDescricao.TabIndex = 0;
            lblDescricao.Text = " ";
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Controls.Add(tableLayoutCabecalho);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(746, 50);
            pnlCabecalho.TabIndex = 14;
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(tbLayoutRodape);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 412);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(746, 55);
            pnlRodape.TabIndex = 15;
            // 
            // MarcaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 467);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
            Controls.Add(pnlRodape);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MarcaForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerencial - Marcas";
            FormClosing += MarcaForm_FormClosing;
            Load += MarcaForm_Load;
            Shown += MarcaForm_Shown;
            KeyDown += MarcaForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gridConteudo).EndInit();
            tbLayoutRodape.ResumeLayout(false);
            tbLayoutRodape.PerformLayout();
            pnlConteudo.ResumeLayout(false);
            tbLayoutOperacoes.ResumeLayout(false);
            tableLayoutCabecalho.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlRodape.ResumeLayout(false);
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
        private TableLayoutPanel tbLayoutOperacoes;
        private Button btnAdicionarGrupo;
        private Button btnAlterarGrupo;
        private Button btnExcluirGrupo;
        private TableLayoutPanel tableLayoutCabecalho;
        private Label lblDescricao;
        private Panel pnlCabecalho;
        private Panel pnlRodape;
    }
}