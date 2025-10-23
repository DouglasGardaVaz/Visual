namespace Dados.View.PessoaFormulario
{
    partial class PessoaForm
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
            pnlCabecalho = new Panel();
            tableLayoutCabecalho = new TableLayoutPanel();
            lblDescricao = new Label();
            menuPrincipal = new MenuStrip();
            relatórioToolStripMenuItem = new ToolStripMenuItem();
            vendasParaOClienteToolStripMenuItem = new ToolStripMenuItem();
            itensVendidosToolStripMenuItem = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            pnlRodape = new Panel();
            tbLayoutFiltro = new TableLayoutPanel();
            txtBusca = new TextBox();
            tbLayoutAcoes = new TableLayoutPanel();
            btnCadastrar = new Button();
            btnAlterar = new Button();
            btnExcluir = new Button();
            pnlConteudo = new Panel();
            gridConteudo = new DataGridView();
            pnlCabecalho.SuspendLayout();
            tableLayoutCabecalho.SuspendLayout();
            menuPrincipal.SuspendLayout();
            pnlRodape.SuspendLayout();
            tbLayoutFiltro.SuspendLayout();
            tbLayoutAcoes.SuspendLayout();
            pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridConteudo).BeginInit();
            SuspendLayout();
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.AllowDrop = true;
            pnlCabecalho.Controls.Add(tableLayoutCabecalho);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(874, 65);
            pnlCabecalho.TabIndex = 3;
            // 
            // tableLayoutCabecalho
            // 
            tableLayoutCabecalho.ColumnCount = 3;
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutCabecalho.Controls.Add(lblDescricao, 1, 0);
            tableLayoutCabecalho.Controls.Add(menuPrincipal, 0, 0);
            tableLayoutCabecalho.Dock = DockStyle.Fill;
            tableLayoutCabecalho.Location = new Point(0, 0);
            tableLayoutCabecalho.Name = "tableLayoutCabecalho";
            tableLayoutCabecalho.RowCount = 1;
            tableLayoutCabecalho.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutCabecalho.Size = new Size(874, 65);
            tableLayoutCabecalho.TabIndex = 0;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Dock = DockStyle.Fill;
            lblDescricao.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblDescricao.Location = new Point(177, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(518, 65);
            lblDescricao.TabIndex = 0;
            lblDescricao.Text = "DOUGLAS GARDA VAZ";
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuPrincipal
            // 
            menuPrincipal.BackColor = Color.Transparent;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { relatórioToolStripMenuItem, sairToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(174, 24);
            menuPrincipal.TabIndex = 1;
            // 
            // relatórioToolStripMenuItem
            // 
            relatórioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { vendasParaOClienteToolStripMenuItem, itensVendidosToolStripMenuItem });
            relatórioToolStripMenuItem.Name = "relatórioToolStripMenuItem";
            relatórioToolStripMenuItem.Size = new Size(71, 20);
            relatórioToolStripMenuItem.Text = "&Relatórios";
            // 
            // vendasParaOClienteToolStripMenuItem
            // 
            vendasParaOClienteToolStripMenuItem.Name = "vendasParaOClienteToolStripMenuItem";
            vendasParaOClienteToolStripMenuItem.Size = new Size(185, 22);
            vendasParaOClienteToolStripMenuItem.Text = "Vendas para o cliente";
            // 
            // itensVendidosToolStripMenuItem
            // 
            itensVendidosToolStripMenuItem.Name = "itensVendidosToolStripMenuItem";
            itensVendidosToolStripMenuItem.Size = new Size(185, 22);
            itensVendidosToolStripMenuItem.Text = "Itens vendidos";
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(38, 20);
            sairToolStripMenuItem.Text = "&Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(tbLayoutFiltro);
            pnlRodape.Controls.Add(tbLayoutAcoes);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 397);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(874, 129);
            pnlRodape.TabIndex = 4;
            // 
            // tbLayoutFiltro
            // 
            tbLayoutFiltro.ColumnCount = 3;
            tbLayoutFiltro.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.2222214F));
            tbLayoutFiltro.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.5555573F));
            tbLayoutFiltro.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.2222214F));
            tbLayoutFiltro.Controls.Add(txtBusca, 1, 0);
            tbLayoutFiltro.Dock = DockStyle.Fill;
            tbLayoutFiltro.Location = new Point(0, 58);
            tbLayoutFiltro.Name = "tbLayoutFiltro";
            tbLayoutFiltro.RowCount = 1;
            tbLayoutFiltro.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbLayoutFiltro.Size = new Size(874, 71);
            tbLayoutFiltro.TabIndex = 8;
            // 
            // txtBusca
            // 
            txtBusca.BackColor = Color.White;
            txtBusca.BorderStyle = BorderStyle.None;
            txtBusca.CharacterCasing = CharacterCasing.Upper;
            txtBusca.Dock = DockStyle.Fill;
            txtBusca.Font = new Font("Arial", 30F);
            txtBusca.ForeColor = Color.FromArgb(80, 80, 80);
            txtBusca.Location = new Point(197, 0);
            txtBusca.Margin = new Padding(3, 0, 3, 3);
            txtBusca.MaxLength = 100;
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(479, 46);
            txtBusca.TabIndex = 0;
            txtBusca.TextAlign = HorizontalAlignment.Center;
            txtBusca.KeyDown += txtBusca_KeyDown;
            // 
            // tbLayoutAcoes
            // 
            tbLayoutAcoes.ColumnCount = 5;
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutAcoes.Controls.Add(btnCadastrar, 3, 0);
            tbLayoutAcoes.Controls.Add(btnAlterar, 2, 0);
            tbLayoutAcoes.Controls.Add(btnExcluir, 1, 0);
            tbLayoutAcoes.Dock = DockStyle.Top;
            tbLayoutAcoes.Location = new Point(0, 0);
            tbLayoutAcoes.Margin = new Padding(3, 10, 3, 3);
            tbLayoutAcoes.Name = "tbLayoutAcoes";
            tbLayoutAcoes.RowCount = 1;
            tbLayoutAcoes.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tbLayoutAcoes.Size = new Size(874, 58);
            tbLayoutAcoes.TabIndex = 7;
            // 
            // btnCadastrar
            // 
            btnCadastrar.BackColor = Color.White;
            btnCadastrar.Dock = DockStyle.Top;
            btnCadastrar.FlatAppearance.BorderColor = Color.Gray;
            btnCadastrar.FlatAppearance.BorderSize = 0;
            btnCadastrar.FlatStyle = FlatStyle.Flat;
            btnCadastrar.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnCadastrar.ForeColor = Color.FromArgb(80, 80, 80);
            btnCadastrar.Location = new Point(508, 10);
            btnCadastrar.Margin = new Padding(3, 10, 3, 3);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(130, 35);
            btnCadastrar.TabIndex = 5;
            btnCadastrar.Text = "&Cadastrar | F6";
            btnCadastrar.UseVisualStyleBackColor = false;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.BackColor = Color.White;
            btnAlterar.Dock = DockStyle.Top;
            btnAlterar.FlatAppearance.BorderSize = 0;
            btnAlterar.FlatStyle = FlatStyle.Flat;
            btnAlterar.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnAlterar.ForeColor = Color.FromArgb(80, 80, 80);
            btnAlterar.Location = new Point(372, 10);
            btnAlterar.Margin = new Padding(3, 10, 3, 3);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(130, 35);
            btnAlterar.TabIndex = 4;
            btnAlterar.Text = "&Alterar | F5";
            btnAlterar.UseVisualStyleBackColor = false;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.White;
            btnExcluir.Dock = DockStyle.Top;
            btnExcluir.FlatAppearance.BorderSize = 0;
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnExcluir.ForeColor = Color.FromArgb(80, 80, 80);
            btnExcluir.Location = new Point(236, 10);
            btnExcluir.Margin = new Padding(3, 10, 3, 3);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(130, 35);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "&Excluir | F4";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(gridConteudo);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 65);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(10, 1, 10, 1);
            pnlConteudo.Size = new Size(874, 332);
            pnlConteudo.TabIndex = 5;
            // 
            // gridConteudo
            // 
            gridConteudo.AllowUserToOrderColumns = true;
            gridConteudo.BackgroundColor = Color.WhiteSmoke;
            gridConteudo.BorderStyle = BorderStyle.None;
            gridConteudo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridConteudo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridConteudo.Dock = DockStyle.Fill;
            gridConteudo.Location = new Point(10, 1);
            gridConteudo.Margin = new Padding(10);
            gridConteudo.Name = "gridConteudo";
            gridConteudo.ReadOnly = true;
            gridConteudo.Size = new Size(854, 330);
            gridConteudo.TabIndex = 0;
            gridConteudo.ColumnHeaderMouseClick += gridConteudo_ColumnHeaderMouseClick;
            gridConteudo.Scroll += gridConteudo_Scroll;
            gridConteudo.SelectionChanged += gridConteudo_SelectionChanged;
            // 
            // PessoaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 225, 230);
            ClientSize = new Size(874, 526);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
            Controls.Add(pnlRodape);
            Font = new Font("Arial", 9F);
            ForeColor = Color.FromArgb(60, 60, 60);
            KeyPreview = true;
            MainMenuStrip = menuPrincipal;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "PessoaForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerencial clientes - GARSTEN - 2025";
            FormClosing += PessoaForm_FormClosing;
            Load += PessoaForm_Load;
            Shown += PessoaForm_Shown;
            KeyDown += PessoaForm_KeyDown;
            pnlCabecalho.ResumeLayout(false);
            tableLayoutCabecalho.ResumeLayout(false);
            tableLayoutCabecalho.PerformLayout();
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            pnlRodape.ResumeLayout(false);
            tbLayoutFiltro.ResumeLayout(false);
            tbLayoutFiltro.PerformLayout();
            tbLayoutAcoes.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridConteudo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCabecalho;
        private Panel pnlRodape;
        private Panel pnlConteudo;
        private DataGridView gridConteudo;
        private TableLayoutPanel tbLayoutAcoes;
        private Button btnCadastrar;
        private Button btnAlterar;
        private Button btnExcluir;
        private TableLayoutPanel tbLayoutFiltro;
        private TextBox txtBusca;
        private TableLayoutPanel tableLayoutCabecalho;
        private Label lblDescricao;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem relatórioToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private ToolStripMenuItem vendasParaOClienteToolStripMenuItem;
        private ToolStripMenuItem itensVendidosToolStripMenuItem;
    }
}