namespace Dados.View.Financeiro.PagarReplicarParcelaFormulario
{
    partial class PagarReplicarParcelaForm
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
            tbRodape = new TableLayoutPanel();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            pnlConteudo = new Panel();
            gridConteudo = new DataGridView();
            pnlCabecalho = new Panel();
            cmbTipoGeracao = new ComboBox();
            nudDia = new NumericUpDown();
            label5 = new Label();
            dtProximaParcela = new DateTimePicker();
            label4 = new Label();
            dtInicial = new DateTimePicker();
            label1 = new Label();
            nudParcelas = new NumericUpDown();
            tbRodape.SuspendLayout();
            pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridConteudo).BeginInit();
            pnlCabecalho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudParcelas).BeginInit();
            SuspendLayout();
            // 
            // tbRodape
            // 
            tbRodape.ColumnCount = 3;
            tbRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbRodape.Controls.Add(btnConfirmar, 2, 0);
            tbRodape.Controls.Add(btnCancelar, 0, 0);
            tbRodape.Dock = DockStyle.Bottom;
            tbRodape.Location = new Point(0, 342);
            tbRodape.Margin = new Padding(10);
            tbRodape.Name = "tbRodape";
            tbRodape.RowCount = 1;
            tbRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbRodape.Size = new Size(349, 45);
            tbRodape.TabIndex = 4;
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
            btnConfirmar.ForeColor = Color.FromArgb(60, 60, 60);
            btnConfirmar.Location = new Point(222, 3);
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
            btnCancelar.ForeColor = Color.FromArgb(60, 60, 60);
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
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 140);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(10, 10, 0, 10);
            pnlConteudo.Size = new Size(349, 202);
            pnlConteudo.TabIndex = 5;
            // 
            // gridConteudo
            // 
            gridConteudo.BackgroundColor = Color.WhiteSmoke;
            gridConteudo.BorderStyle = BorderStyle.None;
            gridConteudo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            gridConteudo.DefaultCellStyle = dataGridViewCellStyle1;
            gridConteudo.Dock = DockStyle.Fill;
            gridConteudo.Location = new Point(10, 10);
            gridConteudo.Margin = new Padding(10);
            gridConteudo.Name = "gridConteudo";
            gridConteudo.Size = new Size(339, 182);
            gridConteudo.TabIndex = 2;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.AllowDrop = true;
            pnlCabecalho.Controls.Add(cmbTipoGeracao);
            pnlCabecalho.Controls.Add(nudDia);
            pnlCabecalho.Controls.Add(label5);
            pnlCabecalho.Controls.Add(dtProximaParcela);
            pnlCabecalho.Controls.Add(label4);
            pnlCabecalho.Controls.Add(dtInicial);
            pnlCabecalho.Controls.Add(label1);
            pnlCabecalho.Controls.Add(nudParcelas);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(349, 140);
            pnlCabecalho.TabIndex = 7;
            // 
            // cmbTipoGeracao
            // 
            cmbTipoGeracao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoGeracao.FlatStyle = FlatStyle.Flat;
            cmbTipoGeracao.FormattingEnabled = true;
            cmbTipoGeracao.Location = new Point(8, 103);
            cmbTipoGeracao.Name = "cmbTipoGeracao";
            cmbTipoGeracao.Size = new Size(136, 23);
            cmbTipoGeracao.TabIndex = 20;
            // 
            // nudDia
            // 
            nudDia.Location = new Point(154, 104);
            nudDia.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            nudDia.Name = "nudDia";
            nudDia.Size = new Size(46, 21);
            nudDia.TabIndex = 19;
            nudDia.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 58);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 17;
            label5.Text = "Próxima parcela";
            // 
            // dtProximaParcela
            // 
            dtProximaParcela.Format = DateTimePickerFormat.Short;
            dtProximaParcela.Location = new Point(8, 76);
            dtProximaParcela.Name = "dtProximaParcela";
            dtProximaParcela.Size = new Size(102, 21);
            dtProximaParcela.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(8, 12);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 15;
            label4.Text = "Data da 1ª parcela";
            // 
            // dtInicial
            // 
            dtInicial.Enabled = false;
            dtInicial.Format = DateTimePickerFormat.Short;
            dtInicial.Location = new Point(8, 30);
            dtInicial.Name = "dtInicial";
            dtInicial.Size = new Size(102, 21);
            dtInicial.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(116, 58);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 9;
            label1.Text = "Qtde parcelas";
            // 
            // nudParcelas
            // 
            nudParcelas.Location = new Point(116, 76);
            nudParcelas.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudParcelas.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            nudParcelas.Name = "nudParcelas";
            nudParcelas.Size = new Size(46, 21);
            nudParcelas.TabIndex = 8;
            nudParcelas.TextAlign = HorizontalAlignment.Right;
            nudParcelas.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // PagarReplicarParcelaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 387);
            Controls.Add(pnlConteudo);
            Controls.Add(tbRodape);
            Controls.Add(pnlCabecalho);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PagarReplicarParcelaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Replicar parcela";
            Load += PagarReplicarParcelaForm_Load;
            tbRodape.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridConteudo).EndInit();
            pnlCabecalho.ResumeLayout(false);
            pnlCabecalho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudParcelas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbRodape;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private DataGridView gridConteudo;
        private Panel pnlCabecalho;
        private Label label1;
        private NumericUpDown nudParcelas;
        private Label label4;
        private DateTimePicker dtInicial;
        private Label label5;
        private DateTimePicker dtProximaParcela;
        private NumericUpDown nudDia;
        private ComboBox cmbTipoGeracao;
    }
}