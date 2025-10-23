namespace Dados.View.Saida.InutilizacaoDFeFormulario
{
    partial class InutilizacaoDFeForm
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
            txtDescricao = new TextBox();
            tableLayoutRodape = new TableLayoutPanel();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            tbNFCe = new TabPage();
            gbInutilizacaoNFCe = new GroupBox();
            label5 = new Label();
            txtNumeroFinal = new TextBox();
            label4 = new Label();
            txtNumeroInicial = new TextBox();
            label3 = new Label();
            txtSerie = new TextBox();
            label2 = new Label();
            txtAno = new TextBox();
            label1 = new Label();
            lblOperacao = new Label();
            groupBox1 = new GroupBox();
            tbNFe = new TabPage();
            tbGeral = new TabControl();
            pnlConteudo = new Panel();
            toolTipHint = new ToolTip(components);
            tableLayoutRodape.SuspendLayout();
            tbNFCe.SuspendLayout();
            gbInutilizacaoNFCe.SuspendLayout();
            tbNFe.SuspendLayout();
            tbGeral.SuspendLayout();
            pnlConteudo.SuspendLayout();
            SuspendLayout();
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Arial", 12F, FontStyle.Bold);
            txtDescricao.ForeColor = Color.FromArgb(80, 80, 80);
            txtDescricao.Location = new Point(6, 132);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(418, 94);
            txtDescricao.TabIndex = 31;
            // 
            // tableLayoutRodape
            // 
            tableLayoutRodape.ColumnCount = 3;
            tableLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutRodape.Controls.Add(btnConfirmar, 2, 0);
            tableLayoutRodape.Controls.Add(btnCancelar, 0, 0);
            tableLayoutRodape.Dock = DockStyle.Bottom;
            tableLayoutRodape.Location = new Point(0, 240);
            tableLayoutRodape.Margin = new Padding(10);
            tableLayoutRodape.Name = "tableLayoutRodape";
            tableLayoutRodape.RowCount = 1;
            tableLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutRodape.Size = new Size(450, 45);
            tableLayoutRodape.TabIndex = 11;
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
            btnConfirmar.Location = new Point(333, 3);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(114, 39);
            btnConfirmar.TabIndex = 0;
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
            btnCancelar.Size = new Size(114, 39);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "C&ancelar | F4";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // tbNFCe
            // 
            tbNFCe.Controls.Add(gbInutilizacaoNFCe);
            tbNFCe.Location = new Point(4, 5);
            tbNFCe.Name = "tbNFCe";
            tbNFCe.Padding = new Padding(3);
            tbNFCe.Size = new Size(442, 276);
            tbNFCe.TabIndex = 0;
            tbNFCe.UseVisualStyleBackColor = true;
            // 
            // gbInutilizacaoNFCe
            // 
            gbInutilizacaoNFCe.Controls.Add(label5);
            gbInutilizacaoNFCe.Controls.Add(txtNumeroFinal);
            gbInutilizacaoNFCe.Controls.Add(label4);
            gbInutilizacaoNFCe.Controls.Add(txtNumeroInicial);
            gbInutilizacaoNFCe.Controls.Add(label3);
            gbInutilizacaoNFCe.Controls.Add(txtSerie);
            gbInutilizacaoNFCe.Controls.Add(label2);
            gbInutilizacaoNFCe.Controls.Add(txtAno);
            gbInutilizacaoNFCe.Controls.Add(label1);
            gbInutilizacaoNFCe.Controls.Add(txtDescricao);
            gbInutilizacaoNFCe.Controls.Add(lblOperacao);
            gbInutilizacaoNFCe.Dock = DockStyle.Fill;
            gbInutilizacaoNFCe.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbInutilizacaoNFCe.ForeColor = Color.FromArgb(80, 80, 80);
            gbInutilizacaoNFCe.Location = new Point(3, 3);
            gbInutilizacaoNFCe.Name = "gbInutilizacaoNFCe";
            gbInutilizacaoNFCe.Size = new Size(436, 270);
            gbInutilizacaoNFCe.TabIndex = 4;
            gbInutilizacaoNFCe.TabStop = false;
            // 
            // label5
            // 
            label5.Font = new Font("Arial", 11F, FontStyle.Bold);
            label5.Location = new Point(324, 56);
            label5.Name = "label5";
            label5.Size = new Size(100, 22);
            label5.TabIndex = 40;
            label5.Text = "Nº final";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNumeroFinal
            // 
            txtNumeroFinal.Enabled = false;
            txtNumeroFinal.ForeColor = Color.FromArgb(80, 80, 80);
            txtNumeroFinal.Location = new Point(324, 80);
            txtNumeroFinal.MaxLength = 5;
            txtNumeroFinal.Name = "txtNumeroFinal";
            txtNumeroFinal.Size = new Size(100, 21);
            txtNumeroFinal.TabIndex = 39;
            txtNumeroFinal.Tag = "numero";
            txtNumeroFinal.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.Font = new Font("Arial", 11F, FontStyle.Bold);
            label4.Location = new Point(218, 56);
            label4.Name = "label4";
            label4.Size = new Size(100, 22);
            label4.TabIndex = 38;
            label4.Text = "Nº inicial";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNumeroInicial
            // 
            txtNumeroInicial.Enabled = false;
            txtNumeroInicial.ForeColor = Color.FromArgb(80, 80, 80);
            txtNumeroInicial.Location = new Point(218, 80);
            txtNumeroInicial.MaxLength = 5;
            txtNumeroInicial.Name = "txtNumeroInicial";
            txtNumeroInicial.Size = new Size(100, 21);
            txtNumeroInicial.TabIndex = 37;
            txtNumeroInicial.Tag = "numero";
            txtNumeroInicial.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.Font = new Font("Arial", 11F, FontStyle.Bold);
            label3.Location = new Point(112, 56);
            label3.Name = "label3";
            label3.Size = new Size(100, 22);
            label3.TabIndex = 36;
            label3.Text = "Série";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtSerie
            // 
            txtSerie.Enabled = false;
            txtSerie.ForeColor = Color.FromArgb(80, 80, 80);
            txtSerie.Location = new Point(112, 80);
            txtSerie.MaxLength = 1;
            txtSerie.Name = "txtSerie";
            txtSerie.Size = new Size(100, 21);
            txtSerie.TabIndex = 35;
            txtSerie.Tag = "numero";
            txtSerie.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.Font = new Font("Arial", 11F, FontStyle.Bold);
            label2.Location = new Point(6, 56);
            label2.Name = "label2";
            label2.Size = new Size(100, 22);
            label2.TabIndex = 34;
            label2.Text = "Ano";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtAno
            // 
            txtAno.Enabled = false;
            txtAno.ForeColor = Color.FromArgb(80, 80, 80);
            txtAno.Location = new Point(6, 80);
            txtAno.MaxLength = 2;
            txtAno.Name = "txtAno";
            txtAno.Size = new Size(100, 21);
            txtAno.TabIndex = 33;
            txtAno.Tag = "numero";
            txtAno.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.Font = new Font("Arial", 11F, FontStyle.Bold);
            label1.Location = new Point(6, 107);
            label1.Name = "label1";
            label1.Size = new Size(431, 22);
            label1.TabIndex = 32;
            label1.Text = "Motivo";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblOperacao
            // 
            lblOperacao.Dock = DockStyle.Top;
            lblOperacao.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblOperacao.Location = new Point(3, 17);
            lblOperacao.Name = "lblOperacao";
            lblOperacao.Size = new Size(430, 22);
            lblOperacao.TabIndex = 30;
            lblOperacao.Text = "Inutilização";
            lblOperacao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Arial", 9F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(80, 80, 80);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(436, 270);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // tbNFe
            // 
            tbNFe.Controls.Add(groupBox1);
            tbNFe.Location = new Point(4, 5);
            tbNFe.Name = "tbNFe";
            tbNFe.Padding = new Padding(3);
            tbNFe.Size = new Size(442, 276);
            tbNFe.TabIndex = 1;
            tbNFe.UseVisualStyleBackColor = true;
            // 
            // tbGeral
            // 
            tbGeral.Controls.Add(tbNFCe);
            tbGeral.Controls.Add(tbNFe);
            tbGeral.Dock = DockStyle.Fill;
            tbGeral.ItemSize = new Size(1, 1);
            tbGeral.Location = new Point(0, 0);
            tbGeral.Name = "tbGeral";
            tbGeral.SelectedIndex = 0;
            tbGeral.Size = new Size(450, 285);
            tbGeral.TabIndex = 5;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(tbGeral);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(450, 285);
            pnlConteudo.TabIndex = 10;
            // 
            // InutilizacaoDFeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 285);
            Controls.Add(tableLayoutRodape);
            Controls.Add(pnlConteudo);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InutilizacaoDFeForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inutilização";
            Load += InutilizacaoDFeForm_Load;
            Shown += InutilizacaoDFeForm_Shown;
            KeyDown += InutilizacaoDFeForm_KeyDown;
            tableLayoutRodape.ResumeLayout(false);
            tbNFCe.ResumeLayout(false);
            gbInutilizacaoNFCe.ResumeLayout(false);
            gbInutilizacaoNFCe.PerformLayout();
            tbNFe.ResumeLayout(false);
            tbGeral.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public TextBox txtDescricao;
        private TableLayoutPanel tableLayoutRodape;
        private Button btnConfirmar;
        private Button btnCancelar;
        private TabPage tbNFCe;
        private GroupBox gbInutilizacaoNFCe;
        public Label label1;
        public Label lblOperacao;
        private GroupBox groupBox1;
        private TabPage tbNFe;
        private TabControl tbGeral;
        private Panel pnlConteudo;
        private ToolTip toolTipHint;
        public Label label5;
        private TextBox txtNumeroFinal;
        public Label label4;
        private TextBox txtNumeroInicial;
        public Label label3;
        private TextBox txtSerie;
        public Label label2;
        private TextBox txtAno;
    }
}