namespace Dados.View.Saida.PDV
{
    partial class GerenciamentoDFeForm
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtFinal = new DateTimePicker();
            dtInicial = new DateTimePicker();
            cmbStatus = new ComboBox();
            gbFiltroPeriodo = new GroupBox();
            cmbData = new ComboBox();
            cmbSituacao = new ComboBox();
            lblDescricao = new Label();
            tableLayoutCabecalho = new TableLayoutPanel();
            menuPrincipal = new MenuStrip();
            relatórioToolStripMenuItem = new ToolStripMenuItem();
            vendasParaOClienteToolStripMenuItem = new ToolStripMenuItem();
            itensVendidosToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            sairToolStripMenuItem = new ToolStripMenuItem();
            operaçõesToolStripMenuItem = new ToolStripMenuItem();
            toolStripInutilizacaoManual = new ToolStripMenuItem();
            lblTotalPendentes = new Label();
            lblTotalCanceladas = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTotalEmitidas = new Label();
            pnlConteudo = new Panel();
            gridConteudo = new DataGridView();
            strNumero = new DataGridViewTextBoxColumn();
            DataHoraEmissao = new DataGridViewTextBoxColumn();
            Cliente = new DataGridViewTextBoxColumn();
            strStatus = new DataGridViewTextBoxColumn();
            strSituacao = new DataGridViewTextBoxColumn();
            ValorTotal = new DataGridViewTextBoxColumn();
            cmsGrid = new ContextMenuStrip(components);
            consultarSituacaoToolStripMenuItem = new ToolStripMenuItem();
            cancelarToolStripMenuItem = new ToolStripMenuItem();
            transmitirToolStripMenuItem = new ToolStripMenuItem();
            pnlTotais = new Panel();
            tbLayoutFiltro = new TableLayoutPanel();
            txtBusca = new TextBox();
            tbLayoutAcoes = new TableLayoutPanel();
            btnDetalhe = new Button();
            btnTransmitir = new Button();
            btnReabrir = new Button();
            btnCancelar = new Button();
            btnInutilizar = new Button();
            pnlFiltro = new Panel();
            pnlCabecalho = new Panel();
            pnlRodape = new Panel();
            gbFiltroPeriodo.SuspendLayout();
            tableLayoutCabecalho.SuspendLayout();
            menuPrincipal.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridConteudo).BeginInit();
            cmsGrid.SuspendLayout();
            pnlTotais.SuspendLayout();
            tbLayoutFiltro.SuspendLayout();
            tbLayoutAcoes.SuspendLayout();
            pnlFiltro.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            pnlRodape.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(159, 4);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 14;
            label3.Text = "Situação";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(454, 4);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 13;
            label2.Text = "Período";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(542, 28);
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
            dtFinal.Location = new Point(558, 22);
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
            dtInicial.Location = new Point(454, 22);
            dtInicial.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            dtInicial.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtInicial.Name = "dtInicial";
            dtInicial.Size = new Size(84, 21);
            dtInicial.TabIndex = 10;
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = SystemColors.Window;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FlatStyle = FlatStyle.Flat;
            cmbStatus.Font = new Font("Arial", 9F);
            cmbStatus.ForeColor = Color.FromArgb(60, 60, 60);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(9, 20);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(141, 23);
            cmbStatus.TabIndex = 2;
            // 
            // gbFiltroPeriodo
            // 
            gbFiltroPeriodo.Controls.Add(cmbData);
            gbFiltroPeriodo.Controls.Add(label3);
            gbFiltroPeriodo.Controls.Add(label2);
            gbFiltroPeriodo.Controls.Add(label1);
            gbFiltroPeriodo.Controls.Add(dtFinal);
            gbFiltroPeriodo.Controls.Add(dtInicial);
            gbFiltroPeriodo.Controls.Add(cmbSituacao);
            gbFiltroPeriodo.Controls.Add(cmbStatus);
            gbFiltroPeriodo.Dock = DockStyle.Fill;
            gbFiltroPeriodo.FlatStyle = FlatStyle.Flat;
            gbFiltroPeriodo.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbFiltroPeriodo.ForeColor = Color.FromArgb(80, 80, 80);
            gbFiltroPeriodo.Location = new Point(0, 0);
            gbFiltroPeriodo.Name = "gbFiltroPeriodo";
            gbFiltroPeriodo.Size = new Size(970, 51);
            gbFiltroPeriodo.TabIndex = 8;
            gbFiltroPeriodo.TabStop = false;
            gbFiltroPeriodo.Text = "Filtros";
            // 
            // cmbData
            // 
            cmbData.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbData.FlatStyle = FlatStyle.Flat;
            cmbData.Font = new Font("Arial", 9F);
            cmbData.ForeColor = Color.FromArgb(60, 60, 60);
            cmbData.FormattingEnabled = true;
            cmbData.Location = new Point(306, 20);
            cmbData.Name = "cmbData";
            cmbData.Size = new Size(141, 23);
            cmbData.TabIndex = 15;
            // 
            // cmbSituacao
            // 
            cmbSituacao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSituacao.FlatStyle = FlatStyle.Flat;
            cmbSituacao.Font = new Font("Arial", 9F);
            cmbSituacao.ForeColor = Color.FromArgb(60, 60, 60);
            cmbSituacao.FormattingEnabled = true;
            cmbSituacao.Location = new Point(159, 20);
            cmbSituacao.Name = "cmbSituacao";
            cmbSituacao.Size = new Size(141, 23);
            cmbSituacao.TabIndex = 8;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Dock = DockStyle.Fill;
            lblDescricao.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblDescricao.ForeColor = Color.FromArgb(80, 80, 80);
            lblDescricao.Location = new Point(326, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(479, 39);
            lblDescricao.TabIndex = 0;
            lblDescricao.Text = "Nota fiscal Nº 1234";
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutCabecalho
            // 
            tableLayoutCabecalho.ColumnCount = 3;
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutCabecalho.Controls.Add(lblDescricao, 1, 0);
            tableLayoutCabecalho.Controls.Add(menuPrincipal, 0, 0);
            tableLayoutCabecalho.Dock = DockStyle.Fill;
            tableLayoutCabecalho.Location = new Point(0, 0);
            tableLayoutCabecalho.Name = "tableLayoutCabecalho";
            tableLayoutCabecalho.RowCount = 1;
            tableLayoutCabecalho.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutCabecalho.Size = new Size(970, 39);
            tableLayoutCabecalho.TabIndex = 0;
            // 
            // menuPrincipal
            // 
            menuPrincipal.BackColor = Color.Transparent;
            menuPrincipal.Items.AddRange(new ToolStripItem[] { relatórioToolStripMenuItem, toolStripMenuItem1, sairToolStripMenuItem, operaçõesToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(323, 24);
            menuPrincipal.TabIndex = 1;
            menuPrincipal.ItemClicked += menuPrincipal_ItemClicked;
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
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(51, 20);
            toolStripMenuItem1.Text = "Status";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // sairToolStripMenuItem
            // 
            sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            sairToolStripMenuItem.Size = new Size(38, 20);
            sairToolStripMenuItem.Text = "&Sair";
            // 
            // operaçõesToolStripMenuItem
            // 
            operaçõesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripInutilizacaoManual });
            operaçõesToolStripMenuItem.Name = "operaçõesToolStripMenuItem";
            operaçõesToolStripMenuItem.Size = new Size(75, 20);
            operaçõesToolStripMenuItem.Text = "&Operações";
            // 
            // toolStripInutilizacaoManual
            // 
            toolStripInutilizacaoManual.Name = "toolStripInutilizacaoManual";
            toolStripInutilizacaoManual.Size = new Size(177, 22);
            toolStripInutilizacaoManual.Text = "&Inutilização manual";
            toolStripInutilizacaoManual.Click += toolStripInutilizacaoManual_Click;
            // 
            // lblTotalPendentes
            // 
            lblTotalPendentes.AutoSize = true;
            lblTotalPendentes.Dock = DockStyle.Fill;
            lblTotalPendentes.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTotalPendentes.Location = new Point(809, 0);
            lblTotalPendentes.Name = "lblTotalPendentes";
            lblTotalPendentes.Size = new Size(158, 25);
            lblTotalPendentes.TabIndex = 11;
            lblTotalPendentes.Text = "TotalPendentes";
            lblTotalPendentes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalCanceladas
            // 
            lblTotalCanceladas.AutoSize = true;
            lblTotalCanceladas.Dock = DockStyle.Fill;
            lblTotalCanceladas.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTotalCanceladas.Location = new Point(648, 0);
            lblTotalCanceladas.Name = "lblTotalCanceladas";
            lblTotalCanceladas.Size = new Size(155, 25);
            lblTotalCanceladas.TabIndex = 9;
            lblTotalCanceladas.Text = "TotalCanceladas";
            lblTotalCanceladas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0333767F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.0333767F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.688921F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6221619F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6221619F));
            tableLayoutPanel1.Controls.Add(lblTotalEmitidas, 2, 0);
            tableLayoutPanel1.Controls.Add(lblTotalPendentes, 4, 0);
            tableLayoutPanel1.Controls.Add(lblTotalCanceladas, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(970, 25);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // lblTotalEmitidas
            // 
            lblTotalEmitidas.AutoSize = true;
            lblTotalEmitidas.Dock = DockStyle.Fill;
            lblTotalEmitidas.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblTotalEmitidas.Location = new Point(487, 0);
            lblTotalEmitidas.Name = "lblTotalEmitidas";
            lblTotalEmitidas.Size = new Size(155, 25);
            lblTotalEmitidas.TabIndex = 12;
            lblTotalEmitidas.Text = "TotalEmitidas";
            lblTotalEmitidas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(gridConteudo);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 39);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(10, 1, 10, 1);
            pnlConteudo.Size = new Size(970, 376);
            pnlConteudo.TabIndex = 16;
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
            gridConteudo.Columns.AddRange(new DataGridViewColumn[] { strNumero, DataHoraEmissao, Cliente, strStatus, strSituacao, ValorTotal });
            gridConteudo.ContextMenuStrip = cmsGrid;
            gridConteudo.Dock = DockStyle.Fill;
            gridConteudo.EditMode = DataGridViewEditMode.EditOnEnter;
            gridConteudo.Location = new Point(10, 1);
            gridConteudo.Margin = new Padding(10);
            gridConteudo.Name = "gridConteudo";
            gridConteudo.ReadOnly = true;
            gridConteudo.Size = new Size(950, 374);
            gridConteudo.TabIndex = 0;
            gridConteudo.ColumnHeaderMouseClick += gridConteudo_ColumnHeaderMouseClick;
            gridConteudo.RowPrePaint += gridConteudo_RowPrePaint;
            gridConteudo.SelectionChanged += gridConteudo_SelectionChanged;
            // 
            // strNumero
            // 
            strNumero.DataPropertyName = "strNumero";
            strNumero.HeaderText = "Número";
            strNumero.Name = "strNumero";
            strNumero.ReadOnly = true;
            // 
            // DataHoraEmissao
            // 
            DataHoraEmissao.DataPropertyName = "DataHoraEmissao";
            DataHoraEmissao.HeaderText = "Data e hora emissão";
            DataHoraEmissao.Name = "DataHoraEmissao";
            DataHoraEmissao.ReadOnly = true;
            // 
            // Cliente
            // 
            Cliente.DataPropertyName = "Cliente";
            Cliente.HeaderText = "Cliente";
            Cliente.Name = "Cliente";
            Cliente.ReadOnly = true;
            // 
            // strStatus
            // 
            strStatus.DataPropertyName = "strStatus";
            strStatus.HeaderText = "Status";
            strStatus.Name = "strStatus";
            strStatus.ReadOnly = true;
            // 
            // strSituacao
            // 
            strSituacao.DataPropertyName = "strSituacao";
            strSituacao.HeaderText = "Situação";
            strSituacao.Name = "strSituacao";
            strSituacao.ReadOnly = true;
            // 
            // ValorTotal
            // 
            ValorTotal.DataPropertyName = "ValorTotal";
            ValorTotal.HeaderText = "Valor total";
            ValorTotal.Name = "ValorTotal";
            ValorTotal.ReadOnly = true;
            // 
            // cmsGrid
            // 
            cmsGrid.Items.AddRange(new ToolStripItem[] { consultarSituacaoToolStripMenuItem, cancelarToolStripMenuItem, transmitirToolStripMenuItem });
            cmsGrid.Name = "cmsGrid";
            cmsGrid.Size = new Size(173, 70);
            // 
            // consultarSituacaoToolStripMenuItem
            // 
            consultarSituacaoToolStripMenuItem.Name = "consultarSituacaoToolStripMenuItem";
            consultarSituacaoToolStripMenuItem.Size = new Size(172, 22);
            consultarSituacaoToolStripMenuItem.Text = "Consultar &situação";
            consultarSituacaoToolStripMenuItem.Click += consultarSituacaoToolStripMenuItem_Click;
            // 
            // cancelarToolStripMenuItem
            // 
            cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
            cancelarToolStripMenuItem.Size = new Size(172, 22);
            cancelarToolStripMenuItem.Text = "&Cancelar";
            cancelarToolStripMenuItem.Click += btnCancelar_Click;
            // 
            // transmitirToolStripMenuItem
            // 
            transmitirToolStripMenuItem.Name = "transmitirToolStripMenuItem";
            transmitirToolStripMenuItem.Size = new Size(172, 22);
            transmitirToolStripMenuItem.Text = "&Transmitir";
            transmitirToolStripMenuItem.Click += btnTransmitir_Click;
            // 
            // pnlTotais
            // 
            pnlTotais.Controls.Add(tableLayoutPanel1);
            pnlTotais.Dock = DockStyle.Bottom;
            pnlTotais.Location = new Point(0, 415);
            pnlTotais.Margin = new Padding(10);
            pnlTotais.Name = "pnlTotais";
            pnlTotais.Size = new Size(970, 25);
            pnlTotais.TabIndex = 13;
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
            tbLayoutFiltro.Size = new Size(970, 71);
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
            txtBusca.Location = new Point(218, 0);
            txtBusca.Margin = new Padding(3, 0, 3, 3);
            txtBusca.MaxLength = 100;
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(532, 46);
            txtBusca.TabIndex = 0;
            txtBusca.TextAlign = HorizontalAlignment.Center;
            txtBusca.KeyDown += txtBusca_KeyDown;
            // 
            // tbLayoutAcoes
            // 
            tbLayoutAcoes.ColumnCount = 8;
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutAcoes.Controls.Add(btnDetalhe, 1, 0);
            tbLayoutAcoes.Controls.Add(btnTransmitir, 6, 0);
            tbLayoutAcoes.Controls.Add(btnReabrir, 4, 0);
            tbLayoutAcoes.Controls.Add(btnCancelar, 3, 0);
            tbLayoutAcoes.Controls.Add(btnInutilizar, 2, 0);
            tbLayoutAcoes.Dock = DockStyle.Top;
            tbLayoutAcoes.Location = new Point(0, 0);
            tbLayoutAcoes.Margin = new Padding(3, 10, 3, 3);
            tbLayoutAcoes.Name = "tbLayoutAcoes";
            tbLayoutAcoes.RowCount = 1;
            tbLayoutAcoes.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tbLayoutAcoes.Size = new Size(970, 58);
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
            btnDetalhe.Location = new Point(86, 10);
            btnDetalhe.Margin = new Padding(3, 10, 3, 3);
            btnDetalhe.Name = "btnDetalhe";
            btnDetalhe.Size = new Size(130, 35);
            btnDetalhe.TabIndex = 7;
            btnDetalhe.Text = "&Detalhes... | F2";
            btnDetalhe.UseVisualStyleBackColor = false;
            // 
            // btnTransmitir
            // 
            btnTransmitir.BackColor = Color.White;
            btnTransmitir.Dock = DockStyle.Top;
            btnTransmitir.FlatAppearance.BorderColor = Color.Gray;
            btnTransmitir.FlatAppearance.BorderSize = 0;
            btnTransmitir.FlatStyle = FlatStyle.Flat;
            btnTransmitir.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnTransmitir.ForeColor = Color.FromArgb(80, 80, 80);
            btnTransmitir.Location = new Point(760, 10);
            btnTransmitir.Margin = new Padding(3, 10, 3, 3);
            btnTransmitir.Name = "btnTransmitir";
            btnTransmitir.Size = new Size(124, 35);
            btnTransmitir.TabIndex = 6;
            btnTransmitir.Text = "&Transmitir | F8";
            btnTransmitir.UseVisualStyleBackColor = false;
            btnTransmitir.Click += btnTransmitir_Click;
            // 
            // btnReabrir
            // 
            btnReabrir.BackColor = Color.White;
            btnReabrir.Dock = DockStyle.Top;
            btnReabrir.FlatAppearance.BorderColor = Color.Gray;
            btnReabrir.FlatAppearance.BorderSize = 0;
            btnReabrir.FlatStyle = FlatStyle.Flat;
            btnReabrir.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnReabrir.ForeColor = Color.FromArgb(80, 80, 80);
            btnReabrir.Location = new Point(494, 10);
            btnReabrir.Margin = new Padding(3, 10, 3, 3);
            btnReabrir.Name = "btnReabrir";
            btnReabrir.Size = new Size(130, 35);
            btnReabrir.TabIndex = 5;
            btnReabrir.Text = "&Reabrir | F6";
            btnReabrir.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.Dock = DockStyle.Top;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(80, 80, 80);
            btnCancelar.Location = new Point(358, 10);
            btnCancelar.Margin = new Padding(3, 10, 3, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 35);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "&Cancelar | F5";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnInutilizar
            // 
            btnInutilizar.BackColor = Color.White;
            btnInutilizar.Dock = DockStyle.Top;
            btnInutilizar.FlatAppearance.BorderSize = 0;
            btnInutilizar.FlatStyle = FlatStyle.Flat;
            btnInutilizar.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnInutilizar.ForeColor = Color.FromArgb(80, 80, 80);
            btnInutilizar.Location = new Point(222, 10);
            btnInutilizar.Margin = new Padding(3, 10, 3, 3);
            btnInutilizar.Name = "btnInutilizar";
            btnInutilizar.Size = new Size(130, 35);
            btnInutilizar.TabIndex = 3;
            btnInutilizar.Text = "&Inutilizar | F4";
            btnInutilizar.UseVisualStyleBackColor = false;
            btnInutilizar.Click += btnInutilizar_Click;
            // 
            // pnlFiltro
            // 
            pnlFiltro.Controls.Add(gbFiltroPeriodo);
            pnlFiltro.Dock = DockStyle.Bottom;
            pnlFiltro.Location = new Point(0, 440);
            pnlFiltro.Margin = new Padding(10);
            pnlFiltro.Name = "pnlFiltro";
            pnlFiltro.Size = new Size(970, 51);
            pnlFiltro.TabIndex = 17;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.AllowDrop = true;
            pnlCabecalho.Controls.Add(tableLayoutCabecalho);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(970, 39);
            pnlCabecalho.TabIndex = 14;
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(tbLayoutFiltro);
            pnlRodape.Controls.Add(tbLayoutAcoes);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 491);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(970, 129);
            pnlRodape.TabIndex = 15;
            // 
            // GerenciamentoDFeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 620);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlTotais);
            Controls.Add(pnlFiltro);
            Controls.Add(pnlCabecalho);
            Controls.Add(pnlRodape);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GerenciamentoDFeForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Gerenciamento DF-e";
            FormClosing += GerenciamentoDFeForm_FormClosing;
            Load += GerenciamentoDFeForm_Load;
            KeyDown += GerenciamentoDFeForm_KeyDown;
            gbFiltroPeriodo.ResumeLayout(false);
            gbFiltroPeriodo.PerformLayout();
            tableLayoutCabecalho.ResumeLayout(false);
            tableLayoutCabecalho.PerformLayout();
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlConteudo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridConteudo).EndInit();
            cmsGrid.ResumeLayout(false);
            pnlTotais.ResumeLayout(false);
            tbLayoutFiltro.ResumeLayout(false);
            tbLayoutFiltro.PerformLayout();
            tbLayoutAcoes.ResumeLayout(false);
            pnlFiltro.ResumeLayout(false);
            pnlCabecalho.ResumeLayout(false);
            pnlRodape.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtFinal;
        private DateTimePicker dtInicial;
        private ComboBox cmbStatus;
        private GroupBox gbFiltroPeriodo;
        private ComboBox cmbSituacao;
        private Label lblDescricao;
        private TableLayoutPanel tableLayoutCabecalho;
        private MenuStrip menuPrincipal;
        private ToolStripMenuItem relatórioToolStripMenuItem;
        private ToolStripMenuItem vendasParaOClienteToolStripMenuItem;
        private ToolStripMenuItem itensVendidosToolStripMenuItem;
        private ToolStripMenuItem sairToolStripMenuItem;
        private Label lblTotalPendentes;
        private Label lblTotalCanceladas;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlConteudo;
        private DataGridView gridConteudo;
        private Panel pnlTotais;
        private TableLayoutPanel tbLayoutFiltro;
        private TextBox txtBusca;
        private TableLayoutPanel tbLayoutAcoes;
        private Button btnDetalhe;
        private Button btnTransmitir;
        private Button btnReabrir;
        private Button btnCancelar;
        private Button btnInutilizar;
        private Panel pnlFiltro;
        private Panel pnlCabecalho;
        private Panel pnlRodape;
        private DataGridViewTextBoxColumn strNumero;
        private DataGridViewTextBoxColumn DataHoraEmissao;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn strStatus;
        private DataGridViewTextBoxColumn strSituacao;
        private DataGridViewTextBoxColumn ValorTotal;
        private ComboBox cmbData;
        private ToolStripMenuItem toolStripMenuItem1;
        private ContextMenuStrip cmsGrid;
        private ToolStripMenuItem consultarSituacaoToolStripMenuItem;
        private ToolStripMenuItem cancelarToolStripMenuItem;
        private ToolStripMenuItem transmitirToolStripMenuItem;
        private ToolStripMenuItem operaçõesToolStripMenuItem;
        private ToolStripMenuItem toolStripInutilizacaoManual;
        private Label lblTotalEmitidas;
    }
}