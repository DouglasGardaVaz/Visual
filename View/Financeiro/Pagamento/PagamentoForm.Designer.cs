namespace Visual.View.Financeiro.PagamentoFormulario
{
    partial class PagamentoForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlRodape = new Panel();
            tbLayoutAcoes = new TableLayoutPanel();
            btnVendedor = new Button();
            btnFinalizar = new Button();
            btnCancelar = new Button();
            pnlConteudo = new Panel();
            pnlValores = new Panel();
            gbValores = new GroupBox();
            lblValorTroco = new Label();
            lblValorPago = new Label();
            lblValorTotal = new Label();
            lblTituloValorTroco = new Label();
            lblTituloValorPago = new Label();
            lblTituloValorTotal = new Label();
            groupBox1 = new GroupBox();
            lblAcrescimoPercentual = new Label();
            txtValorAcrescimoPercentual = new TextBox();
            lblAcrescimo = new Label();
            txtValorAcrescimo = new TextBox();
            gbDesconto = new GroupBox();
            lblDescontoPercentual = new Label();
            txtValorDescontoPercentual = new TextBox();
            lblDesconto = new Label();
            txtValorDesconto = new TextBox();
            pnlEspecies = new Panel();
            gbMeioPagamento = new GroupBox();
            gridPagamento = new DataGridView();
            Especie = new DataGridViewTextBoxColumn();
            Valor = new DataGridViewTextBoxColumn();
            pnlCabecalho = new Panel();
            gbConsumidor = new GroupBox();
            label6 = new Label();
            txtDocumentoConsumidor = new TextBox();
            pbBuscaPessoa = new PictureBox();
            txtConsumidor = new TextBox();
            label9 = new Label();
            pnlRodape.SuspendLayout();
            tbLayoutAcoes.SuspendLayout();
            pnlConteudo.SuspendLayout();
            pnlValores.SuspendLayout();
            gbValores.SuspendLayout();
            groupBox1.SuspendLayout();
            gbDesconto.SuspendLayout();
            pnlEspecies.SuspendLayout();
            gbMeioPagamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridPagamento).BeginInit();
            pnlCabecalho.SuspendLayout();
            gbConsumidor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBuscaPessoa).BeginInit();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(tbLayoutAcoes);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 391);
            pnlRodape.Margin = new Padding(0);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(810, 47);
            pnlRodape.TabIndex = 15;
            // 
            // tbLayoutAcoes
            // 
            tbLayoutAcoes.ColumnCount = 5;
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tbLayoutAcoes.Controls.Add(btnVendedor, 1, 0);
            tbLayoutAcoes.Controls.Add(btnFinalizar, 4, 0);
            tbLayoutAcoes.Controls.Add(btnCancelar, 0, 0);
            tbLayoutAcoes.Dock = DockStyle.Bottom;
            tbLayoutAcoes.Location = new Point(0, 0);
            tbLayoutAcoes.Margin = new Padding(0);
            tbLayoutAcoes.Name = "tbLayoutAcoes";
            tbLayoutAcoes.RowCount = 1;
            tbLayoutAcoes.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tbLayoutAcoes.Size = new Size(810, 47);
            tbLayoutAcoes.TabIndex = 7;
            // 
            // btnVendedor
            // 
            btnVendedor.BackColor = Color.White;
            btnVendedor.FlatAppearance.BorderSize = 0;
            btnVendedor.FlatStyle = FlatStyle.Flat;
            btnVendedor.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnVendedor.ForeColor = Color.FromArgb(80, 80, 80);
            btnVendedor.Location = new Point(130, 0);
            btnVendedor.Margin = new Padding(0);
            btnVendedor.Name = "btnVendedor";
            btnVendedor.Size = new Size(130, 47);
            btnVendedor.TabIndex = 14;
            btnVendedor.Text = "&Vendedor | V";
            btnVendedor.UseVisualStyleBackColor = false;
            // 
            // btnFinalizar
            // 
            btnFinalizar.BackColor = Color.White;
            btnFinalizar.FlatAppearance.BorderColor = Color.Gray;
            btnFinalizar.FlatAppearance.BorderSize = 0;
            btnFinalizar.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnFinalizar.FlatStyle = FlatStyle.Flat;
            btnFinalizar.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnFinalizar.ForeColor = Color.FromArgb(80, 80, 80);
            btnFinalizar.Location = new Point(650, 0);
            btnFinalizar.Margin = new Padding(0);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(160, 47);
            btnFinalizar.TabIndex = 13;
            btnFinalizar.Text = "&Finalizar | F6";
            btnFinalizar.UseVisualStyleBackColor = false;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial", 11F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(80, 80, 80);
            btnCancelar.Location = new Point(0, 0);
            btnCancelar.Margin = new Padding(0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 47);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "&Cancelar | F4";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.BackColor = Color.White;
            pnlConteudo.Controls.Add(pnlValores);
            pnlConteudo.Controls.Add(pnlEspecies);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 68);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(5);
            pnlConteudo.Size = new Size(810, 323);
            pnlConteudo.TabIndex = 16;
            // 
            // pnlValores
            // 
            pnlValores.Controls.Add(gbValores);
            pnlValores.Controls.Add(groupBox1);
            pnlValores.Controls.Add(gbDesconto);
            pnlValores.Dock = DockStyle.Right;
            pnlValores.Location = new Point(381, 5);
            pnlValores.Name = "pnlValores";
            pnlValores.Size = new Size(424, 313);
            pnlValores.TabIndex = 1;
            // 
            // gbValores
            // 
            gbValores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gbValores.Controls.Add(lblValorTroco);
            gbValores.Controls.Add(lblValorPago);
            gbValores.Controls.Add(lblValorTotal);
            gbValores.Controls.Add(lblTituloValorTroco);
            gbValores.Controls.Add(lblTituloValorPago);
            gbValores.Controls.Add(lblTituloValorTotal);
            gbValores.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbValores.ForeColor = Color.FromArgb(80, 80, 80);
            gbValores.Location = new Point(7, 10);
            gbValores.Name = "gbValores";
            gbValores.Size = new Size(410, 204);
            gbValores.TabIndex = 3;
            gbValores.TabStop = false;
            gbValores.Text = "Valores";
            // 
            // lblValorTroco
            // 
            lblValorTroco.Font = new Font("Arial", 26F, FontStyle.Bold);
            lblValorTroco.ForeColor = Color.FromArgb(255, 128, 0);
            lblValorTroco.Location = new Point(200, 144);
            lblValorTroco.Name = "lblValorTroco";
            lblValorTroco.Size = new Size(210, 47);
            lblValorTroco.TabIndex = 5;
            lblValorTroco.Text = "0,00";
            lblValorTroco.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblValorPago
            // 
            lblValorPago.Font = new Font("Arial", 28F, FontStyle.Bold);
            lblValorPago.ForeColor = Color.FromArgb(0, 192, 0);
            lblValorPago.Location = new Point(135, 81);
            lblValorPago.Name = "lblValorPago";
            lblValorPago.Size = new Size(269, 47);
            lblValorPago.TabIndex = 4;
            lblValorPago.Text = "0,00";
            lblValorPago.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblValorTotal
            // 
            lblValorTotal.Font = new Font("Arial", 28F, FontStyle.Bold);
            lblValorTotal.ForeColor = Color.Blue;
            lblValorTotal.Location = new Point(129, 25);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(275, 47);
            lblValorTotal.TabIndex = 3;
            lblValorTotal.Text = "0,00";
            lblValorTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloValorTroco
            // 
            lblTituloValorTroco.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTituloValorTroco.ForeColor = Color.FromArgb(255, 128, 0);
            lblTituloValorTroco.Location = new Point(6, 156);
            lblTituloValorTroco.Name = "lblTituloValorTroco";
            lblTituloValorTroco.Size = new Size(204, 35);
            lblTituloValorTroco.TabIndex = 2;
            lblTituloValorTroco.Text = "Valor faltante R$";
            // 
            // lblTituloValorPago
            // 
            lblTituloValorPago.AutoSize = true;
            lblTituloValorPago.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTituloValorPago.ForeColor = Color.FromArgb(0, 192, 0);
            lblTituloValorPago.Location = new Point(11, 91);
            lblTituloValorPago.Name = "lblTituloValorPago";
            lblTituloValorPago.Size = new Size(109, 29);
            lblTituloValorPago.TabIndex = 1;
            lblTituloValorPago.Text = "Pago R$";
            // 
            // lblTituloValorTotal
            // 
            lblTituloValorTotal.AutoSize = true;
            lblTituloValorTotal.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblTituloValorTotal.ForeColor = Color.Blue;
            lblTituloValorTotal.Location = new Point(11, 35);
            lblTituloValorTotal.Name = "lblTituloValorTotal";
            lblTituloValorTotal.Size = new Size(106, 29);
            lblTituloValorTotal.TabIndex = 0;
            lblTituloValorTotal.Text = "Total R$";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox1.Controls.Add(lblAcrescimoPercentual);
            groupBox1.Controls.Add(txtValorAcrescimoPercentual);
            groupBox1.Controls.Add(lblAcrescimo);
            groupBox1.Controls.Add(txtValorAcrescimo);
            groupBox1.Font = new Font("Arial", 9F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(80, 80, 80);
            groupBox1.Location = new Point(217, 226);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 78);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Acréscimo | Ctrl + A";
            // 
            // lblAcrescimoPercentual
            // 
            lblAcrescimoPercentual.AutoSize = true;
            lblAcrescimoPercentual.Location = new Point(102, 23);
            lblAcrescimoPercentual.Name = "lblAcrescimoPercentual";
            lblAcrescimoPercentual.Size = new Size(16, 15);
            lblAcrescimoPercentual.TabIndex = 32;
            lblAcrescimoPercentual.Text = "%";
            // 
            // txtValorAcrescimoPercentual
            // 
            txtValorAcrescimoPercentual.ForeColor = Color.Black;
            txtValorAcrescimoPercentual.Location = new Point(102, 41);
            txtValorAcrescimoPercentual.Name = "txtValorAcrescimoPercentual";
            txtValorAcrescimoPercentual.Size = new Size(74, 21);
            txtValorAcrescimoPercentual.TabIndex = 31;
            txtValorAcrescimoPercentual.Tag = "valor2";
            txtValorAcrescimoPercentual.Text = "0,00";
            txtValorAcrescimoPercentual.TextAlign = HorizontalAlignment.Right;
            // 
            // lblAcrescimo
            // 
            lblAcrescimo.AutoSize = true;
            lblAcrescimo.Location = new Point(7, 23);
            lblAcrescimo.Name = "lblAcrescimo";
            lblAcrescimo.Size = new Size(22, 15);
            lblAcrescimo.TabIndex = 30;
            lblAcrescimo.Text = "R$";
            // 
            // txtValorAcrescimo
            // 
            txtValorAcrescimo.ForeColor = Color.Black;
            txtValorAcrescimo.Location = new Point(7, 41);
            txtValorAcrescimo.Name = "txtValorAcrescimo";
            txtValorAcrescimo.Size = new Size(74, 21);
            txtValorAcrescimo.TabIndex = 29;
            txtValorAcrescimo.Tag = "valor2";
            txtValorAcrescimo.Text = "0,00";
            txtValorAcrescimo.TextAlign = HorizontalAlignment.Right;
            // 
            // gbDesconto
            // 
            gbDesconto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            gbDesconto.Controls.Add(lblDescontoPercentual);
            gbDesconto.Controls.Add(txtValorDescontoPercentual);
            gbDesconto.Controls.Add(lblDesconto);
            gbDesconto.Controls.Add(txtValorDesconto);
            gbDesconto.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbDesconto.ForeColor = Color.FromArgb(80, 80, 80);
            gbDesconto.Location = new Point(7, 226);
            gbDesconto.Name = "gbDesconto";
            gbDesconto.Size = new Size(200, 78);
            gbDesconto.TabIndex = 1;
            gbDesconto.TabStop = false;
            gbDesconto.Text = "Desconto | Ctrl + D";
            // 
            // lblDescontoPercentual
            // 
            lblDescontoPercentual.AutoSize = true;
            lblDescontoPercentual.Location = new Point(104, 23);
            lblDescontoPercentual.Name = "lblDescontoPercentual";
            lblDescontoPercentual.Size = new Size(16, 15);
            lblDescontoPercentual.TabIndex = 32;
            lblDescontoPercentual.Text = "%";
            // 
            // txtValorDescontoPercentual
            // 
            txtValorDescontoPercentual.ForeColor = Color.Black;
            txtValorDescontoPercentual.Location = new Point(102, 41);
            txtValorDescontoPercentual.Name = "txtValorDescontoPercentual";
            txtValorDescontoPercentual.Size = new Size(74, 21);
            txtValorDescontoPercentual.TabIndex = 31;
            txtValorDescontoPercentual.Tag = "valor2";
            txtValorDescontoPercentual.Text = "0,00";
            txtValorDescontoPercentual.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDesconto
            // 
            lblDesconto.AutoSize = true;
            lblDesconto.Location = new Point(7, 23);
            lblDesconto.Name = "lblDesconto";
            lblDesconto.Size = new Size(22, 15);
            lblDesconto.TabIndex = 30;
            lblDesconto.Text = "R$";
            // 
            // txtValorDesconto
            // 
            txtValorDesconto.ForeColor = Color.Black;
            txtValorDesconto.Location = new Point(7, 41);
            txtValorDesconto.Name = "txtValorDesconto";
            txtValorDesconto.Size = new Size(74, 21);
            txtValorDesconto.TabIndex = 29;
            txtValorDesconto.Tag = "valor2";
            txtValorDesconto.Text = "0,00";
            txtValorDesconto.TextAlign = HorizontalAlignment.Right;
            // 
            // pnlEspecies
            // 
            pnlEspecies.Controls.Add(gbMeioPagamento);
            pnlEspecies.Dock = DockStyle.Left;
            pnlEspecies.Location = new Point(5, 5);
            pnlEspecies.Name = "pnlEspecies";
            pnlEspecies.Size = new Size(370, 313);
            pnlEspecies.TabIndex = 0;
            // 
            // gbMeioPagamento
            // 
            gbMeioPagamento.Controls.Add(gridPagamento);
            gbMeioPagamento.Dock = DockStyle.Fill;
            gbMeioPagamento.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbMeioPagamento.ForeColor = Color.FromArgb(80, 80, 80);
            gbMeioPagamento.Location = new Point(0, 0);
            gbMeioPagamento.Name = "gbMeioPagamento";
            gbMeioPagamento.Size = new Size(370, 313);
            gbMeioPagamento.TabIndex = 11;
            gbMeioPagamento.TabStop = false;
            gbMeioPagamento.Text = "Meio de pagamento";
            // 
            // gridPagamento
            // 
            gridPagamento.AllowUserToAddRows = false;
            gridPagamento.AllowUserToDeleteRows = false;
            gridPagamento.AllowUserToOrderColumns = true;
            gridPagamento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gridPagamento.BackgroundColor = Color.WhiteSmoke;
            gridPagamento.BorderStyle = BorderStyle.None;
            gridPagamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridPagamento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridPagamento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPagamento.Columns.AddRange(new DataGridViewColumn[] { Especie, Valor });
            gridPagamento.EditMode = DataGridViewEditMode.EditOnEnter;
            gridPagamento.Location = new Point(7, 27);
            gridPagamento.Margin = new Padding(10);
            gridPagamento.Name = "gridPagamento";
            gridPagamento.ReadOnly = true;
            gridPagamento.ScrollBars = ScrollBars.Vertical;
            gridPagamento.Size = new Size(354, 277);
            gridPagamento.TabIndex = 11;
            // 
            // Especie
            // 
            Especie.DataPropertyName = "Descricao";
            Especie.HeaderText = "Espécie";
            Especie.Name = "Especie";
            Especie.ReadOnly = true;
            Especie.Width = 170;
            // 
            // Valor
            // 
            Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0,00";
            Valor.DefaultCellStyle = dataGridViewCellStyle2;
            Valor.HeaderText = "Valor";
            Valor.Name = "Valor";
            Valor.ReadOnly = true;
            Valor.Width = 120;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.Controls.Add(gbConsumidor);
            pnlCabecalho.Controls.Add(label9);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(810, 68);
            pnlCabecalho.TabIndex = 17;
            // 
            // gbConsumidor
            // 
            gbConsumidor.Controls.Add(label6);
            gbConsumidor.Controls.Add(txtDocumentoConsumidor);
            gbConsumidor.Controls.Add(pbBuscaPessoa);
            gbConsumidor.Controls.Add(txtConsumidor);
            gbConsumidor.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbConsumidor.Location = new Point(5, 7);
            gbConsumidor.Name = "gbConsumidor";
            gbConsumidor.Size = new Size(486, 52);
            gbConsumidor.TabIndex = 43;
            gbConsumidor.TabStop = false;
            gbConsumidor.Text = "Consumidor | Ctrl + C";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(249, 26);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 46;
            label6.Text = "CPF/CNPJ";
            // 
            // txtDocumentoConsumidor
            // 
            txtDocumentoConsumidor.BackColor = SystemColors.Window;
            txtDocumentoConsumidor.Font = new Font("Arial", 9F);
            txtDocumentoConsumidor.Location = new Point(325, 20);
            txtDocumentoConsumidor.MaxLength = 8;
            txtDocumentoConsumidor.Name = "txtDocumentoConsumidor";
            txtDocumentoConsumidor.Size = new Size(146, 21);
            txtDocumentoConsumidor.TabIndex = 45;
            // 
            // pbBuscaPessoa
            // 
            pbBuscaPessoa.Cursor = Cursors.Hand;
            pbBuscaPessoa.Image = Visual.Properties.Resources.lupapeq;
            pbBuscaPessoa.Location = new Point(9, 17);
            pbBuscaPessoa.Name = "pbBuscaPessoa";
            pbBuscaPessoa.Size = new Size(24, 24);
            pbBuscaPessoa.SizeMode = PictureBoxSizeMode.AutoSize;
            pbBuscaPessoa.TabIndex = 44;
            pbBuscaPessoa.TabStop = false;
            pbBuscaPessoa.Click += pbBuscaPessoa_Click;
            // 
            // txtConsumidor
            // 
            txtConsumidor.BackColor = SystemColors.Window;
            txtConsumidor.Font = new Font("Arial", 9F);
            txtConsumidor.Location = new Point(39, 20);
            txtConsumidor.MaxLength = 8;
            txtConsumidor.Name = "txtConsumidor";
            txtConsumidor.Size = new Size(204, 21);
            txtConsumidor.TabIndex = 43;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9F, FontStyle.Bold);
            label9.Location = new Point(12, 7);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 41;
            // 
            // PagamentoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 438);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlCabecalho);
            Controls.Add(pnlRodape);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PagamentoForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pagamento";
            FormClosing += PagamentoForm_FormClosing;
            Load += PagamentoForm_Load;
            Shown += PagamentoForm_Shown;
            KeyDown += PagamentoForm_KeyDown;
            pnlRodape.ResumeLayout(false);
            tbLayoutAcoes.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            pnlValores.ResumeLayout(false);
            gbValores.ResumeLayout(false);
            gbValores.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gbDesconto.ResumeLayout(false);
            gbDesconto.PerformLayout();
            pnlEspecies.ResumeLayout(false);
            gbMeioPagamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridPagamento).EndInit();
            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();
            gbConsumidor.ResumeLayout(false);
            gbConsumidor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBuscaPessoa).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRodape;
        private TableLayoutPanel tbLayoutAcoes;
        private Button btnFinalizar;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private Panel pnlCabecalho;
        private Panel pnlValores;
        private Panel pnlEspecies;
        private GroupBox gbDesconto;
        private Label lblDesconto;
        private TextBox txtValorDesconto;
        private GroupBox groupBox1;
        private Label lblAcrescimoPercentual;
        private TextBox txtValorAcrescimoPercentual;
        private Label lblAcrescimo;
        private TextBox txtValorAcrescimo;
        private Label lblDescontoPercentual;
        private TextBox txtValorDescontoPercentual;
        private GroupBox gbValores;
        private Label lblTituloValorTotal;
        private Label lblValorTotal;
        private Label lblTituloValorTroco;
        private Label lblTituloValorPago;
        private Label lblValorPago;
        private Label lblValorTroco;
        private GroupBox gbMeioPagamento;
        private DataGridView gridPagamento;
        private GroupBox gbConsumidor;
        private PictureBox pbBuscaPessoa;
        private TextBox txtConsumidor;
        private Label label9;
        private Button btnVendedor;
        private Label label6;
        private TextBox txtDocumentoConsumidor;
        private DataGridViewTextBoxColumn Especie;
        private DataGridViewTextBoxColumn Valor;
    }
}