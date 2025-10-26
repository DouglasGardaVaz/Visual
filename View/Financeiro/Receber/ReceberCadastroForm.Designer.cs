namespace Visual.View.Financeiro.ReceberCadastroFormulario
{
    partial class ReceberCadastroForm
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
            tbLayoutAcoes = new TableLayoutPanel();
            btnGravar = new Button();
            btnCancelar = new Button();
            pnlConteudo = new Panel();
            tbReceber = new TabControl();
            tbCadastro = new TabPage();
            gbClassificacaoFinanceira = new GroupBox();
            label8 = new Label();
            cmbEspecie = new ComboBox();
            label7 = new Label();
            cmbPlanoConta = new ComboBox();
            label17 = new Label();
            cmbCentroCusto = new ComboBox();
            gbParcela = new GroupBox();
            lblValorPago = new Label();
            txtValorPago = new TextBox();
            dtRecebimento = new DateTimePicker();
            lblPagamento = new Label();
            label6 = new Label();
            dtVencimento = new DateTimePicker();
            label3 = new Label();
            txtQtdeParcela = new TextBox();
            label2 = new Label();
            txtValor = new TextBox();
            label1 = new Label();
            txtNumeroParcela = new TextBox();
            gbInformacoesGerais = new GroupBox();
            pbBuscaPessoa = new PictureBox();
            txtCliente = new TextBox();
            label9 = new Label();
            label4 = new Label();
            label21 = new Label();
            txtDocumento = new TextBox();
            txtDescricao = new TextBox();
            tbAdicional = new TabPage();
            gbObservacao = new GroupBox();
            txtObservacao = new TextBox();
            pnlRodape.SuspendLayout();
            tbLayoutAcoes.SuspendLayout();
            pnlConteudo.SuspendLayout();
            tbReceber.SuspendLayout();
            tbCadastro.SuspendLayout();
            gbClassificacaoFinanceira.SuspendLayout();
            gbParcela.SuspendLayout();
            gbInformacoesGerais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBuscaPessoa).BeginInit();
            tbAdicional.SuspendLayout();
            gbObservacao.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(tbLayoutAcoes);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 447);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(482, 62);
            pnlRodape.TabIndex = 13;
            // 
            // tbLayoutAcoes
            // 
            tbLayoutAcoes.ColumnCount = 5;
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbLayoutAcoes.Controls.Add(btnGravar, 5, 0);
            tbLayoutAcoes.Controls.Add(btnCancelar, 0, 0);
            tbLayoutAcoes.Dock = DockStyle.Bottom;
            tbLayoutAcoes.Location = new Point(0, 4);
            tbLayoutAcoes.Margin = new Padding(3, 10, 3, 3);
            tbLayoutAcoes.Name = "tbLayoutAcoes";
            tbLayoutAcoes.RowCount = 1;
            tbLayoutAcoes.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tbLayoutAcoes.Size = new Size(482, 58);
            tbLayoutAcoes.TabIndex = 7;
            // 
            // btnGravar
            // 
            btnGravar.BackColor = Color.White;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Dock = DockStyle.Top;
            btnGravar.FlatAppearance.BorderColor = Color.Gray;
            btnGravar.FlatAppearance.BorderSize = 0;
            btnGravar.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnGravar.FlatStyle = FlatStyle.Flat;
            btnGravar.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnGravar.ForeColor = Color.FromArgb(80, 80, 80);
            btnGravar.Location = new Point(354, 10);
            btnGravar.Margin = new Padding(3, 10, 3, 3);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(125, 35);
            btnGravar.TabIndex = 13;
            btnGravar.Text = "&Gravar | F6";
            btnGravar.UseVisualStyleBackColor = false;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Dock = DockStyle.Top;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(80, 80, 80);
            btnCancelar.Location = new Point(3, 10);
            btnCancelar.Margin = new Padding(3, 10, 3, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(124, 35);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "&Cancelar | F4";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlConteudo
            // 
            pnlConteudo.BackColor = Color.White;
            pnlConteudo.Controls.Add(tbReceber);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(482, 509);
            pnlConteudo.TabIndex = 14;
            // 
            // tbReceber
            // 
            tbReceber.Controls.Add(tbCadastro);
            tbReceber.Controls.Add(tbAdicional);
            tbReceber.Dock = DockStyle.Fill;
            tbReceber.Location = new Point(0, 0);
            tbReceber.Name = "tbReceber";
            tbReceber.SelectedIndex = 0;
            tbReceber.Size = new Size(482, 509);
            tbReceber.TabIndex = 39;
            // 
            // tbCadastro
            // 
            tbCadastro.Controls.Add(gbClassificacaoFinanceira);
            tbCadastro.Controls.Add(gbParcela);
            tbCadastro.Controls.Add(gbInformacoesGerais);
            tbCadastro.Location = new Point(4, 24);
            tbCadastro.Name = "tbCadastro";
            tbCadastro.Padding = new Padding(3);
            tbCadastro.Size = new Size(474, 481);
            tbCadastro.TabIndex = 0;
            tbCadastro.Text = "Cadastro";
            tbCadastro.UseVisualStyleBackColor = true;
            // 
            // gbClassificacaoFinanceira
            // 
            gbClassificacaoFinanceira.Controls.Add(label8);
            gbClassificacaoFinanceira.Controls.Add(cmbEspecie);
            gbClassificacaoFinanceira.Controls.Add(label7);
            gbClassificacaoFinanceira.Controls.Add(cmbPlanoConta);
            gbClassificacaoFinanceira.Controls.Add(label17);
            gbClassificacaoFinanceira.Controls.Add(cmbCentroCusto);
            gbClassificacaoFinanceira.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbClassificacaoFinanceira.Location = new Point(6, 146);
            gbClassificacaoFinanceira.Name = "gbClassificacaoFinanceira";
            gbClassificacaoFinanceira.Size = new Size(452, 126);
            gbClassificacaoFinanceira.TabIndex = 4;
            gbClassificacaoFinanceira.TabStop = false;
            gbClassificacaoFinanceira.Text = "Classificações";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 69);
            label8.Name = "label8";
            label8.Size = new Size(52, 15);
            label8.TabIndex = 34;
            label8.Text = "Espécie";
            // 
            // cmbEspecie
            // 
            cmbEspecie.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecie.FlatStyle = FlatStyle.Flat;
            cmbEspecie.FormattingEnabled = true;
            cmbEspecie.Location = new Point(19, 87);
            cmbEspecie.Name = "cmbEspecie";
            cmbEspecie.Size = new Size(206, 23);
            cmbEspecie.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(231, 23);
            label7.Name = "label7";
            label7.Size = new Size(91, 15);
            label7.TabIndex = 32;
            label7.Text = "Plano de conta";
            // 
            // cmbPlanoConta
            // 
            cmbPlanoConta.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlanoConta.FlatStyle = FlatStyle.Flat;
            cmbPlanoConta.FormattingEnabled = true;
            cmbPlanoConta.Location = new Point(231, 41);
            cmbPlanoConta.Name = "cmbPlanoConta";
            cmbPlanoConta.Size = new Size(206, 23);
            cmbPlanoConta.TabIndex = 6;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(19, 23);
            label17.Name = "label17";
            label17.Size = new Size(97, 15);
            label17.TabIndex = 30;
            label17.Text = "Centro de custo";
            // 
            // cmbCentroCusto
            // 
            cmbCentroCusto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCentroCusto.FlatStyle = FlatStyle.Flat;
            cmbCentroCusto.FormattingEnabled = true;
            cmbCentroCusto.Location = new Point(19, 41);
            cmbCentroCusto.Name = "cmbCentroCusto";
            cmbCentroCusto.Size = new Size(206, 23);
            cmbCentroCusto.TabIndex = 5;
            // 
            // gbParcela
            // 
            gbParcela.Controls.Add(lblValorPago);
            gbParcela.Controls.Add(txtValorPago);
            gbParcela.Controls.Add(dtRecebimento);
            gbParcela.Controls.Add(lblPagamento);
            gbParcela.Controls.Add(label6);
            gbParcela.Controls.Add(dtVencimento);
            gbParcela.Controls.Add(label3);
            gbParcela.Controls.Add(txtQtdeParcela);
            gbParcela.Controls.Add(label2);
            gbParcela.Controls.Add(txtValor);
            gbParcela.Controls.Add(label1);
            gbParcela.Controls.Add(txtNumeroParcela);
            gbParcela.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbParcela.Location = new Point(6, 278);
            gbParcela.Name = "gbParcela";
            gbParcela.Size = new Size(452, 136);
            gbParcela.TabIndex = 8;
            gbParcela.TabStop = false;
            gbParcela.Text = "Parcela";
            // 
            // lblValorPago
            // 
            lblValorPago.AutoSize = true;
            lblValorPago.Location = new Point(365, 84);
            lblValorPago.Name = "lblValorPago";
            lblValorPago.Size = new Size(89, 15);
            lblValorPago.TabIndex = 38;
            lblValorPago.Text = "Valor recebido";
            lblValorPago.Visible = false;
            // 
            // txtValorPago
            // 
            txtValorPago.Location = new Point(365, 102);
            txtValorPago.Name = "txtValorPago";
            txtValorPago.Size = new Size(74, 21);
            txtValorPago.TabIndex = 37;
            txtValorPago.Tag = "valor2";
            txtValorPago.Text = "0,00";
            txtValorPago.TextAlign = HorizontalAlignment.Right;
            txtValorPago.Visible = false;
            // 
            // dtRecebimento
            // 
            dtRecebimento.Format = DateTimePickerFormat.Short;
            dtRecebimento.Location = new Point(260, 102);
            dtRecebimento.Name = "dtRecebimento";
            dtRecebimento.Size = new Size(99, 21);
            dtRecebimento.TabIndex = 35;
            dtRecebimento.Visible = false;
            // 
            // lblPagamento
            // 
            lblPagamento.AutoSize = true;
            lblPagamento.Location = new Point(260, 84);
            lblPagamento.Name = "lblPagamento";
            lblPagamento.Size = new Size(82, 15);
            lblPagamento.TabIndex = 36;
            lblPagamento.Text = "Recebimento";
            lblPagamento.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(120, 30);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 30;
            label6.Text = "Nº parcela";
            // 
            // dtVencimento
            // 
            dtVencimento.Format = DateTimePickerFormat.Short;
            dtVencimento.Location = new Point(15, 46);
            dtVencimento.Name = "dtVencimento";
            dtVencimento.Size = new Size(99, 21);
            dtVencimento.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(190, 30);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 29;
            label3.Text = "Qtde parcela";
            // 
            // txtQtdeParcela
            // 
            txtQtdeParcela.Location = new Point(190, 48);
            txtQtdeParcela.MaxLength = 2;
            txtQtdeParcela.Name = "txtQtdeParcela";
            txtQtdeParcela.Size = new Size(62, 21);
            txtQtdeParcela.TabIndex = 11;
            txtQtdeParcela.Tag = "numero";
            txtQtdeParcela.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 84);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 28;
            label2.Text = "Valor";
            // 
            // txtValor
            // 
            txtValor.Location = new Point(15, 102);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(74, 21);
            txtValor.TabIndex = 12;
            txtValor.Tag = "valor2";
            txtValor.Text = "0,00";
            txtValor.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 27);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 27;
            label1.Text = "Vencimento";
            // 
            // txtNumeroParcela
            // 
            txtNumeroParcela.Location = new Point(120, 48);
            txtNumeroParcela.MaxLength = 2;
            txtNumeroParcela.Name = "txtNumeroParcela";
            txtNumeroParcela.Size = new Size(62, 21);
            txtNumeroParcela.TabIndex = 10;
            txtNumeroParcela.Tag = "numero";
            txtNumeroParcela.TextAlign = HorizontalAlignment.Right;
            // 
            // gbInformacoesGerais
            // 
            gbInformacoesGerais.Controls.Add(pbBuscaPessoa);
            gbInformacoesGerais.Controls.Add(txtCliente);
            gbInformacoesGerais.Controls.Add(label9);
            gbInformacoesGerais.Controls.Add(label4);
            gbInformacoesGerais.Controls.Add(label21);
            gbInformacoesGerais.Controls.Add(txtDocumento);
            gbInformacoesGerais.Controls.Add(txtDescricao);
            gbInformacoesGerais.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbInformacoesGerais.Location = new Point(6, 6);
            gbInformacoesGerais.Name = "gbInformacoesGerais";
            gbInformacoesGerais.Size = new Size(452, 134);
            gbInformacoesGerais.TabIndex = 0;
            gbInformacoesGerais.TabStop = false;
            gbInformacoesGerais.Text = "Informações gerais";
            // 
            // pbBuscaPessoa
            // 
            pbBuscaPessoa.Cursor = Cursors.Hand;            
            pbBuscaPessoa.Location = new Point(415, 98);
            pbBuscaPessoa.Name = "pbBuscaPessoa";
            pbBuscaPessoa.Size = new Size(24, 24);
            pbBuscaPessoa.SizeMode = PictureBoxSizeMode.AutoSize;
            pbBuscaPessoa.TabIndex = 39;
            pbBuscaPessoa.TabStop = false;
            pbBuscaPessoa.Click += pbBuscaPessoa_Click;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(233, 99);
            txtCliente.MaxLength = 8;
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(176, 21);
            txtCliente.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(233, 81);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 37;
            label9.Text = "Cliente";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 30);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 36;
            label4.Text = "Descrição";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(15, 81);
            label21.Name = "label21";
            label21.Size = new Size(72, 15);
            label21.TabIndex = 35;
            label21.Text = "Documento";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(15, 99);
            txtDocumento.MaxLength = 50;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(212, 21);
            txtDocumento.TabIndex = 2;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(15, 48);
            txtDescricao.MaxLength = 200;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(424, 21);
            txtDescricao.TabIndex = 1;
            // 
            // tbAdicional
            // 
            tbAdicional.Controls.Add(gbObservacao);
            tbAdicional.Location = new Point(4, 24);
            tbAdicional.Name = "tbAdicional";
            tbAdicional.Padding = new Padding(3);
            tbAdicional.Size = new Size(474, 481);
            tbAdicional.TabIndex = 1;
            tbAdicional.Text = "Adicional";
            tbAdicional.UseVisualStyleBackColor = true;
            // 
            // gbObservacao
            // 
            gbObservacao.Controls.Add(txtObservacao);
            gbObservacao.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbObservacao.Location = new Point(6, 6);
            gbObservacao.Name = "gbObservacao";
            gbObservacao.Size = new Size(452, 246);
            gbObservacao.TabIndex = 39;
            gbObservacao.TabStop = false;
            gbObservacao.Text = "Observações";
            // 
            // txtObservacao
            // 
            txtObservacao.Location = new Point(13, 20);
            txtObservacao.Multiline = true;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(423, 209);
            txtObservacao.TabIndex = 1;
            // 
            // ReceberCadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 509);
            Controls.Add(pnlRodape);
            Controls.Add(pnlConteudo);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReceberCadastroForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro receber";
            Load += ReceberCadastroForm_Load;
            Shown += ReceberCadastroForm_Shown;
            KeyDown += ReceberCadastroForm_KeyDown;
            pnlRodape.ResumeLayout(false);
            tbLayoutAcoes.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            tbReceber.ResumeLayout(false);
            tbCadastro.ResumeLayout(false);
            gbClassificacaoFinanceira.ResumeLayout(false);
            gbClassificacaoFinanceira.PerformLayout();
            gbParcela.ResumeLayout(false);
            gbParcela.PerformLayout();
            gbInformacoesGerais.ResumeLayout(false);
            gbInformacoesGerais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBuscaPessoa).EndInit();
            tbAdicional.ResumeLayout(false);
            gbObservacao.ResumeLayout(false);
            gbObservacao.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlRodape;
        private TableLayoutPanel tbLayoutAcoes;
        private Button btnGravar;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private TabControl tbReceber;
        private TabPage tbCadastro;
        private TabPage tbAdicional;
        private GroupBox gbClassificacaoFinanceira;
        private Label label8;
        private ComboBox cmbEspecie;
        private Label label7;
        private ComboBox cmbPlanoConta;
        private Label label17;
        private ComboBox cmbCentroCusto;
        private GroupBox gbParcela;
        private Label lblValorPago;
        private TextBox txtValorPago;
        private DateTimePicker dtRecebimento;
        private Label lblPagamento;
        private Label label6;
        private DateTimePicker dtVencimento;
        private Label label3;
        private TextBox txtQtdeParcela;
        private Label label2;
        private TextBox txtValor;
        private Label label1;
        private TextBox txtNumeroParcela;
        private GroupBox gbInformacoesGerais;
        private PictureBox pbBuscaPessoa;
        private TextBox txtCliente;
        private Label label9;
        private Label label4;
        private Label label21;
        private TextBox txtDocumento;
        private TextBox txtDescricao;
        private GroupBox gbObservacao;
        private TextBox txtObservacao;
    }
}