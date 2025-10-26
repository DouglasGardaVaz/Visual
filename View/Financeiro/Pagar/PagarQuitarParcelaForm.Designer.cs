namespace Visual.View.Financeiro.PagarQuitarParcelaFormulario
{
    partial class PagarQuitarParcelaForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            pnlConteudo = new Panel();
            gbDestino = new GroupBox();
            rbBanco = new RadioButton();
            rbCentroCusto = new RadioButton();
            cmbDestino = new ComboBox();
            gbParcela = new GroupBox();
            label6 = new Label();
            txtValoraSerPago = new TextBox();
            label5 = new Label();
            txtValorOriginal = new TextBox();
            lblTotal = new Label();
            label4 = new Label();
            txtValorDesconto = new TextBox();
            label3 = new Label();
            txtValorAcrescimo = new TextBox();
            dtPagamento = new DateTimePicker();
            lblPagamento = new Label();
            dtVencimento = new DateTimePicker();
            label2 = new Label();
            txtValorPago = new TextBox();
            label1 = new Label();
            gbClassificacaoFinanceira = new GroupBox();
            label8 = new Label();
            cmbEspecie = new ComboBox();
            label7 = new Label();
            cmbPlanoConta = new ComboBox();
            toolTipHint = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            pnlConteudo.SuspendLayout();
            gbDestino.SuspendLayout();
            gbParcela.SuspendLayout();
            gbClassificacaoFinanceira.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tableLayoutPanel1.Controls.Add(btnConfirmar, 2, 0);
            tableLayoutPanel1.Controls.Add(btnCancelar, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 381);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(479, 45);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.White;
            btnConfirmar.DialogResult = DialogResult.OK;
            btnConfirmar.Dock = DockStyle.Fill;
            btnConfirmar.FlatAppearance.BorderColor = Color.Gray;
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Arial", 11F);
            btnConfirmar.ForeColor = Color.FromArgb(80, 80, 80);
            btnConfirmar.Location = new Point(352, 3);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(124, 39);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "&Confirmar | F6";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
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
            pnlConteudo.Controls.Add(gbDestino);
            pnlConteudo.Controls.Add(gbParcela);
            pnlConteudo.Controls.Add(gbClassificacaoFinanceira);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(479, 426);
            pnlConteudo.TabIndex = 5;
            // 
            // gbDestino
            // 
            gbDestino.Controls.Add(rbBanco);
            gbDestino.Controls.Add(rbCentroCusto);
            gbDestino.Controls.Add(cmbDestino);
            gbDestino.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbDestino.Location = new Point(13, 12);
            gbDestino.Name = "gbDestino";
            gbDestino.Size = new Size(451, 86);
            gbDestino.TabIndex = 10;
            gbDestino.TabStop = false;
            gbDestino.Text = "Destino";
            // 
            // rbBanco
            // 
            rbBanco.AutoSize = true;
            rbBanco.FlatStyle = FlatStyle.Flat;
            rbBanco.Location = new Point(134, 20);
            rbBanco.Name = "rbBanco";
            rbBanco.Size = new Size(60, 19);
            rbBanco.TabIndex = 33;
            rbBanco.Text = "Banco";
            rbBanco.UseVisualStyleBackColor = true;
            rbBanco.CheckedChanged += rbBanco_CheckedChanged;
            // 
            // rbCentroCusto
            // 
            rbCentroCusto.AutoSize = true;
            rbCentroCusto.Checked = true;
            rbCentroCusto.FlatStyle = FlatStyle.Flat;
            rbCentroCusto.Location = new Point(14, 20);
            rbCentroCusto.Name = "rbCentroCusto";
            rbCentroCusto.Size = new Size(114, 19);
            rbCentroCusto.TabIndex = 6;
            rbCentroCusto.TabStop = true;
            rbCentroCusto.Text = "Centro de custo";
            rbCentroCusto.UseVisualStyleBackColor = true;
            rbCentroCusto.CheckedChanged += rbCentroCusto_CheckedChanged;
            // 
            // cmbDestino
            // 
            cmbDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDestino.FlatStyle = FlatStyle.Flat;
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(14, 48);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(206, 23);
            cmbDestino.TabIndex = 31;
            // 
            // gbParcela
            // 
            gbParcela.Controls.Add(label6);
            gbParcela.Controls.Add(txtValoraSerPago);
            gbParcela.Controls.Add(label5);
            gbParcela.Controls.Add(txtValorOriginal);
            gbParcela.Controls.Add(lblTotal);
            gbParcela.Controls.Add(label4);
            gbParcela.Controls.Add(txtValorDesconto);
            gbParcela.Controls.Add(label3);
            gbParcela.Controls.Add(txtValorAcrescimo);
            gbParcela.Controls.Add(dtPagamento);
            gbParcela.Controls.Add(lblPagamento);
            gbParcela.Controls.Add(dtVencimento);
            gbParcela.Controls.Add(label2);
            gbParcela.Controls.Add(txtValorPago);
            gbParcela.Controls.Add(label1);
            gbParcela.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbParcela.Location = new Point(13, 190);
            gbParcela.Name = "gbParcela";
            gbParcela.Size = new Size(452, 182);
            gbParcela.TabIndex = 9;
            gbParcela.TabStop = false;
            gbParcela.Text = "Parcela";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(201, 28);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 45;
            label6.Text = "Valor a ser pago";
            // 
            // txtValoraSerPago
            // 
            txtValoraSerPago.Enabled = false;
            txtValoraSerPago.Location = new Point(201, 46);
            txtValoraSerPago.Name = "txtValoraSerPago";
            txtValoraSerPago.Size = new Size(74, 21);
            txtValoraSerPago.TabIndex = 44;
            txtValoraSerPago.Tag = "valor2";
            txtValoraSerPago.Text = "0,00";
            txtValoraSerPago.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(121, 28);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 43;
            label5.Text = "Valor original";
            // 
            // txtValorOriginal
            // 
            txtValorOriginal.Enabled = false;
            txtValorOriginal.Location = new Point(121, 46);
            txtValorOriginal.Name = "txtValorOriginal";
            txtValorOriginal.Size = new Size(74, 21);
            txtValorOriginal.TabIndex = 42;
            txtValorOriginal.Tag = "valor2";
            txtValorOriginal.Text = "0,00";
            txtValorOriginal.TextAlign = HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(151, 151);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(295, 24);
            lblTotal.TabIndex = 41;
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(201, 82);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 40;
            label4.Text = "Desconto";
            // 
            // txtValorDesconto
            // 
            txtValorDesconto.Location = new Point(201, 100);
            txtValorDesconto.Name = "txtValorDesconto";
            txtValorDesconto.Size = new Size(74, 21);
            txtValorDesconto.TabIndex = 39;
            txtValorDesconto.Tag = "valor2";
            txtValorDesconto.Text = "0,00";
            txtValorDesconto.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(121, 82);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 38;
            label3.Text = "Acréscimo";
            // 
            // txtValorAcrescimo
            // 
            txtValorAcrescimo.Location = new Point(121, 100);
            txtValorAcrescimo.Name = "txtValorAcrescimo";
            txtValorAcrescimo.Size = new Size(74, 21);
            txtValorAcrescimo.TabIndex = 37;
            txtValorAcrescimo.Tag = "valor2";
            txtValorAcrescimo.Text = "0,00";
            txtValorAcrescimo.TextAlign = HorizontalAlignment.Right;
            // 
            // dtPagamento
            // 
            dtPagamento.Font = new Font("Arial", 9F);
            dtPagamento.Format = DateTimePickerFormat.Short;
            dtPagamento.Location = new Point(15, 100);
            dtPagamento.Name = "dtPagamento";
            dtPagamento.Size = new Size(99, 21);
            dtPagamento.TabIndex = 35;
            // 
            // lblPagamento
            // 
            lblPagamento.AutoSize = true;
            lblPagamento.Location = new Point(15, 77);
            lblPagamento.Name = "lblPagamento";
            lblPagamento.Size = new Size(72, 15);
            lblPagamento.TabIndex = 36;
            lblPagamento.Text = "Pagamento";
            // 
            // dtVencimento
            // 
            dtVencimento.Enabled = false;
            dtVencimento.Font = new Font("Arial", 9F);
            dtVencimento.Format = DateTimePickerFormat.Short;
            dtVencimento.Location = new Point(15, 46);
            dtVencimento.Name = "dtVencimento";
            dtVencimento.Size = new Size(99, 21);
            dtVencimento.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 125);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 28;
            label2.Text = "Valor pago";
            // 
            // txtValorPago
            // 
            txtValorPago.Font = new Font("Arial", 16F, FontStyle.Bold);
            txtValorPago.Location = new Point(15, 143);
            txtValorPago.Name = "txtValorPago";
            txtValorPago.Size = new Size(99, 32);
            txtValorPago.TabIndex = 12;
            txtValorPago.Tag = "valor2";
            txtValorPago.Text = "0,00";
            txtValorPago.TextAlign = HorizontalAlignment.Right;
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
            // gbClassificacaoFinanceira
            // 
            gbClassificacaoFinanceira.Controls.Add(label8);
            gbClassificacaoFinanceira.Controls.Add(cmbEspecie);
            gbClassificacaoFinanceira.Controls.Add(label7);
            gbClassificacaoFinanceira.Controls.Add(cmbPlanoConta);
            gbClassificacaoFinanceira.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbClassificacaoFinanceira.Location = new Point(12, 104);
            gbClassificacaoFinanceira.Name = "gbClassificacaoFinanceira";
            gbClassificacaoFinanceira.Size = new Size(452, 80);
            gbClassificacaoFinanceira.TabIndex = 5;
            gbClassificacaoFinanceira.TabStop = false;
            gbClassificacaoFinanceira.Text = "Classificações";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 23);
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
            cmbEspecie.Location = new Point(15, 41);
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
            // PagarQuitarParcelaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 426);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlConteudo);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PagarQuitarParcelaForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quitar parcela";
            Load += PagarQuitarParcelaForm_Load;
            KeyDown += PagarQuitarParcelaForm_KeyDown;
            tableLayoutPanel1.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            gbDestino.ResumeLayout(false);
            gbDestino.PerformLayout();
            gbParcela.ResumeLayout(false);
            gbParcela.PerformLayout();
            gbClassificacaoFinanceira.ResumeLayout(false);
            gbClassificacaoFinanceira.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private ToolTip toolTipHint;
        private GroupBox gbClassificacaoFinanceira;
        private Label label8;
        private ComboBox cmbEspecie;
        private Label label7;
        private ComboBox cmbPlanoConta;
        private GroupBox gbParcela;
        private Label lblValorPago;
        private DateTimePicker dtPagamento;
        private Label lblPagamento;
        private DateTimePicker dtVencimento;
        private Label label2;
        private TextBox txtValorPago;
        private Label label1;
        private GroupBox gbDestino;
        private ComboBox cmbDestino;
        private Label label4;
        private TextBox txtValorDesconto;
        private Label label3;
        private TextBox txtValorAcrescimo;
        private RadioButton rbCentroCusto;
        private RadioButton rbBanco;
        private Label label5;
        private TextBox txtValorOriginal;
        private Label lblTotal;
        private Label label6;
        private TextBox txtValoraSerPago;
    }
}