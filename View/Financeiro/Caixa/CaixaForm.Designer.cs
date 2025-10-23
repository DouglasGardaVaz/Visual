namespace Dados.View.Financeiro.CaixaFormulario
{
    partial class CaixaForm
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
            pnlRodape = new Panel();
            tbLayoutFiltro = new TableLayoutPanel();
            txtBusca = new TextBox();
            tbLayoutAcoes = new TableLayoutPanel();
            btnDetalhe = new Button();
            btnCadastrar = new Button();
            btnAlterar = new Button();
            sairToolStripMenuItem = new ToolStripMenuItem();
            menuPrincipal = new MenuStrip();
            relatórioToolStripMenuItem = new ToolStripMenuItem();
            vendasParaOClienteToolStripMenuItem = new ToolStripMenuItem();
            itensVendidosToolStripMenuItem = new ToolStripMenuItem();
            pnlConteudo = new Panel();
            gridConteudo = new DataGridView();
            pnlTotais = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTotalEntrada = new Label();
            lblTotal = new Label();
            lblTotalSaida = new Label();
            pnlCabecalho = new Panel();
            tableLayoutCabecalho = new TableLayoutPanel();
            lblDescricao = new Label();
            pnlFiltro = new Panel();
            gbFiltroPeriodo = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            dtFinal = new DateTimePicker();
            dtInicial = new DateTimePicker();
            cmbTipoMovimentacao = new ComboBox();
            pnlRodape.SuspendLayout();
            tbLayoutFiltro.SuspendLayout();
            tbLayoutAcoes.SuspendLayout();
            menuPrincipal.SuspendLayout();
            pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridConteudo).BeginInit();
            pnlTotais.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            tableLayoutCabecalho.SuspendLayout();
            pnlFiltro.SuspendLayout();
            gbFiltroPeriodo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(tbLayoutFiltro);
            pnlRodape.Controls.Add(tbLayoutAcoes);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 405);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(902, 129);
            pnlRodape.TabIndex = 10;
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
            tbLayoutFiltro.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tbLayoutFiltro.Size = new Size(902, 71);
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
            txtBusca.Location = new Point(203, 0);
            txtBusca.Margin = new Padding(3, 0, 3, 3);
            txtBusca.MaxLength = 100;
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(495, 46);
            txtBusca.TabIndex = 0;
            txtBusca.TextAlign = HorizontalAlignment.Center;
            txtBusca.KeyDown += txtBusca_KeyDown;
            // 
            // tbLayoutAcoes
            // 
            tbLayoutAcoes.ColumnCount = 7;
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbLayoutAcoes.Controls.Add(btnDetalhe, 1, 0);
            tbLayoutAcoes.Controls.Add(btnCadastrar, 3, 0);
            tbLayoutAcoes.Controls.Add(btnAlterar, 2, 0);
            tbLayoutAcoes.Dock = DockStyle.Top;
            tbLayoutAcoes.Location = new Point(0, 0);
            tbLayoutAcoes.Margin = new Padding(3, 10, 3, 3);
            tbLayoutAcoes.Name = "tbLayoutAcoes";
            tbLayoutAcoes.RowCount = 1;
            tbLayoutAcoes.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tbLayoutAcoes.Size = new Size(902, 58);
            tbLayoutAcoes.TabIndex = 7;
            // 
            // btnDetalhe
            // 
            btnDetalhe.BackColor = Color.White;
            btnDetalhe.Dock = DockStyle.Top;
            btnDetalhe.FlatAppearance.BorderColor = Color.Gray;
            btnDetalhe.FlatAppearance.BorderSize = 0;
            btnDetalhe.FlatStyle = FlatStyle.Flat;
            btnDetalhe.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnDetalhe.ForeColor = Color.FromArgb(80, 80, 80);
            btnDetalhe.Location = new Point(120, 10);
            btnDetalhe.Margin = new Padding(3, 10, 3, 3);
            btnDetalhe.Name = "btnDetalhe";
            btnDetalhe.Size = new Size(130, 35);
            btnDetalhe.TabIndex = 7;
            btnDetalhe.Text = "&Detalhes...";
            btnDetalhe.UseVisualStyleBackColor = false;
            btnDetalhe.Click += btnDetalhe_Click;
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
            btnCadastrar.Location = new Point(392, 10);
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
            btnAlterar.Location = new Point(256, 10);
            btnAlterar.Margin = new Padding(3, 10, 3, 3);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(130, 35);
            btnAlterar.TabIndex = 4;
            btnAlterar.Text = "&Alterar | F5";
            btnAlterar.UseVisualStyleBackColor = false;
            btnAlterar.Click += btnAlterar_Click;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(38, 20);
            sairToolStripMenuItem.Text = "&Sair";
            sairToolStripMenuItem.Click += sairToolStripMenuItem_Click;
            // 
            // menuPrincipal
            // 
            menuPrincipal.BackColor = Color.Transparent;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { relatórioToolStripMenuItem, sairToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(180, 24);
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
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(gridConteudo);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 39);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(10, 1, 10, 1);
            pnlConteudo.Size = new Size(902, 290);
            pnlConteudo.TabIndex = 11;
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
            gridConteudo.EditMode = DataGridViewEditMode.EditOnEnter;
            gridConteudo.Location = new Point(10, 1);
            gridConteudo.Margin = new Padding(10);
            gridConteudo.Name = "gridConteudo";
            gridConteudo.ReadOnly = true;
            gridConteudo.Size = new Size(882, 288);
            gridConteudo.TabIndex = 0;
            gridConteudo.RowPrePaint += gridConteudo_RowPrePaint;
            gridConteudo.SelectionChanged += gridConteudo_SelectionChanged;
            // 
            // pnlTotais
            // 
            pnlTotais.Controls.Add(tableLayoutPanel1);
            pnlTotais.Dock = DockStyle.Bottom;
            pnlTotais.Location = new Point(0, 329);
            pnlTotais.Margin = new Padding(10);
            pnlTotais.Name = "pnlTotais";
            pnlTotais.Size = new Size(902, 25);
            pnlTotais.TabIndex = 1;
            pnlTotais.Paint += pnlTotais_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0333767F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0333767F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.688921F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6221619F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6221619F));
            tableLayoutPanel1.Controls.Add(lblTotalEntrada, 2, 0);
            tableLayoutPanel1.Controls.Add(lblTotal, 4, 0);
            tableLayoutPanel1.Controls.Add(lblTotalSaida, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(902, 25);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // lblTotalEntrada
            // 
            lblTotalEntrada.AutoSize = true;
            lblTotalEntrada.Dock = DockStyle.Fill;
            lblTotalEntrada.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTotalEntrada.Location = new Point(453, 0);
            lblTotalEntrada.Name = "lblTotalEntrada";
            lblTotalEntrada.Size = new Size(144, 25);
            lblTotalEntrada.TabIndex = 12;
            lblTotalEntrada.Text = "0,00";
            lblTotalEntrada.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTotal.Location = new Point(752, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(147, 25);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "0,00";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalSaida
            // 
            lblTotalSaida.AutoSize = true;
            lblTotalSaida.Dock = DockStyle.Fill;
            lblTotalSaida.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTotalSaida.Location = new Point(603, 0);
            lblTotalSaida.Name = "lblTotalSaida";
            lblTotalSaida.Size = new Size(143, 25);
            lblTotalSaida.TabIndex = 10;
            lblTotalSaida.Text = "0,00";
            lblTotalSaida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.AllowDrop = true;
            pnlCabecalho.Controls.Add(tableLayoutCabecalho);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(902, 39);
            pnlCabecalho.TabIndex = 9;
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
            tableLayoutCabecalho.Size = new Size(902, 39);
            tableLayoutCabecalho.TabIndex = 0;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Dock = DockStyle.Fill;
            lblDescricao.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblDescricao.Location = new Point(183, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(535, 39);
            lblDescricao.TabIndex = 0;
            lblDescricao.Text = "PARCELA X";
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFiltro
            // 
            pnlFiltro.Controls.Add(gbFiltroPeriodo);
            pnlFiltro.Dock = DockStyle.Bottom;
            pnlFiltro.Location = new Point(0, 354);
            pnlFiltro.Margin = new Padding(10);
            pnlFiltro.Name = "pnlFiltro";
            pnlFiltro.Size = new Size(902, 51);
            pnlFiltro.TabIndex = 12;
            // 
            // gbFiltroPeriodo
            // 
            gbFiltroPeriodo.Controls.Add(label2);
            gbFiltroPeriodo.Controls.Add(label1);
            gbFiltroPeriodo.Controls.Add(dtFinal);
            gbFiltroPeriodo.Controls.Add(dtInicial);
            gbFiltroPeriodo.Controls.Add(cmbTipoMovimentacao);
            gbFiltroPeriodo.Dock = DockStyle.Fill;
            gbFiltroPeriodo.FlatStyle = FlatStyle.Flat;
            gbFiltroPeriodo.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbFiltroPeriodo.Location = new Point(0, 0);
            gbFiltroPeriodo.Name = "gbFiltroPeriodo";
            gbFiltroPeriodo.Size = new Size(902, 51);
            gbFiltroPeriodo.TabIndex = 8;
            gbFiltroPeriodo.TabStop = false;
            gbFiltroPeriodo.Text = "Filtros";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(162, 4);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 13;
            label2.Text = "Período";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(250, 28);
            label1.Name = "label1";
            label1.Size = new Size(14, 15);
            label1.TabIndex = 12;
            label1.Text = "a";
            // 
            // dtFinal
            // 
            dtFinal.CalendarForeColor = Color.FromArgb(60, 60, 60);
            dtFinal.CalendarTitleForeColor = Color.FromArgb(60, 60, 60);
            dtFinal.CalendarTrailingForeColor = Color.FromArgb(60, 60, 60);
            dtFinal.Font = new Font("Arial", 9F);
            dtFinal.Format = DateTimePickerFormat.Short;
            dtFinal.Location = new Point(266, 22);
            dtFinal.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            dtFinal.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtFinal.Name = "dtFinal";
            dtFinal.Size = new Size(84, 21);
            dtFinal.TabIndex = 11;
            // 
            // dtInicial
            // 
            dtInicial.CalendarForeColor = Color.FromArgb(220, 225, 230);
            dtInicial.CalendarTitleForeColor = Color.FromArgb(60, 60, 60);
            dtInicial.CalendarTrailingForeColor = Color.FromArgb(60, 60, 60);
            dtInicial.Font = new Font("Arial", 9F);
            dtInicial.Format = DateTimePickerFormat.Short;
            dtInicial.Location = new Point(162, 22);
            dtInicial.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            dtInicial.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtInicial.Name = "dtInicial";
            dtInicial.Size = new Size(84, 21);
            dtInicial.TabIndex = 10;
            // 
            // cmbTipoMovimentacao
            // 
            cmbTipoMovimentacao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoMovimentacao.FlatStyle = FlatStyle.Flat;
            cmbTipoMovimentacao.Font = new Font("Arial", 9F);
            cmbTipoMovimentacao.ForeColor = Color.FromArgb(60, 60, 60);
            cmbTipoMovimentacao.FormattingEnabled = true;
            cmbTipoMovimentacao.Location = new Point(12, 20);
            cmbTipoMovimentacao.Name = "cmbTipoMovimentacao";
            cmbTipoMovimentacao.Size = new Size(141, 23);
            cmbTipoMovimentacao.TabIndex = 8;
            // 
            // CaixaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 225, 230);
            ClientSize = new Size(902, 534);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlTotais);
            Controls.Add(pnlFiltro);
            Controls.Add(pnlCabecalho);
            Controls.Add(pnlRodape);
            Font = new Font("Arial", 9F);
            ForeColor = Color.FromArgb(60, 60, 60);
            KeyPreview = true;
            MainMenuStrip = menuPrincipal;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "CaixaForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerencial caixa - GARSTEN - 2025";
            FormClosing += CaixaForm_FormClosing;
            Load += CaixaForm_Load;
            KeyDown += CaixaForm_KeyDown;
            pnlRodape.ResumeLayout(false);
            tbLayoutFiltro.ResumeLayout(false);
            tbLayoutFiltro.PerformLayout();
            tbLayoutAcoes.ResumeLayout(false);
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            pnlConteudo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridConteudo).EndInit();
            pnlTotais.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlCabecalho.ResumeLayout(false);
            tableLayoutCabecalho.ResumeLayout(false);
            tableLayoutCabecalho.PerformLayout();
            pnlFiltro.ResumeLayout(false);
            gbFiltroPeriodo.ResumeLayout(false);
            gbFiltroPeriodo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRodape;
        private TableLayoutPanel tbLayoutFiltro;
        private TextBox txtBusca;
        private TableLayoutPanel tbLayoutAcoes;
        private Button btnAlterar;
        private Button btnCancelar;
        private ToolStripMenuItem sairToolStripMenuItem;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem relatórioToolStripMenuItem;
        private ToolStripMenuItem vendasParaOClienteToolStripMenuItem;
        private ToolStripMenuItem itensVendidosToolStripMenuItem;
        private Panel pnlConteudo;
        private DataGridView gridConteudo;
        private Panel pnlCabecalho;
        private TableLayoutPanel tableLayoutCabecalho;
        private Button btnDetalhe;
        private Button btnQuitar;
        private Panel pnlTotais;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTotalaReceber;
        private Label lblTotalRecebido;
        private Label lblTotalSaida;
        private Label lblDescricao;
        private Panel pnlFiltro;
        private GroupBox gbFiltroPeriodo;
        private ComboBox cmbTipoMovimentacao;
        private Label label2;
        private Label label1;
        private DateTimePicker dtFinal;
        private DateTimePicker dtInicial;
        private Button btnCadastrar;
        private Label lblTotalEntrada;
        private Label lblTotal;
    }
}