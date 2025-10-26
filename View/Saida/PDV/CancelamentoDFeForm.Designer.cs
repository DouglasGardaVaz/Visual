namespace Visual.View.Saida.PDV.CancelamentoDFeFormulario
{
    partial class CancelamentoDFeForm
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
            tableLayoutRodape = new TableLayoutPanel();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            tbNFCe = new TabPage();
            gbDesconto = new GroupBox();
            txtDescricao = new TextBox();
            lblOperacao = new Label();
            groupBox1 = new GroupBox();
            tbNFe = new TabPage();
            tbGeral = new TabControl();
            pnlConteudo = new Panel();
            toolTipHint = new ToolTip(components);
            tableLayoutRodape.SuspendLayout();
            tbNFCe.SuspendLayout();
            gbDesconto.SuspendLayout();
            tbNFe.SuspendLayout();
            tbGeral.SuspendLayout();
            pnlConteudo.SuspendLayout();
            SuspendLayout();
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
            tableLayoutRodape.Location = new Point(0, 196);
            tableLayoutRodape.Margin = new Padding(10);
            tableLayoutRodape.Name = "tableLayoutRodape";
            tableLayoutRodape.RowCount = 1;
            tableLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutRodape.Size = new Size(395, 45);
            tableLayoutRodape.TabIndex = 9;
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
            btnConfirmar.Location = new Point(278, 3);
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
            tbNFCe.Controls.Add(gbDesconto);
            tbNFCe.Location = new Point(4, 5);
            tbNFCe.Name = "tbNFCe";
            tbNFCe.Padding = new Padding(3);
            tbNFCe.Size = new Size(387, 232);
            tbNFCe.TabIndex = 0;
            tbNFCe.UseVisualStyleBackColor = true;
            // 
            // gbDesconto
            // 
            gbDesconto.Controls.Add(txtDescricao);
            gbDesconto.Controls.Add(lblOperacao);
            gbDesconto.Dock = DockStyle.Fill;
            gbDesconto.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbDesconto.ForeColor = Color.FromArgb(80, 80, 80);
            gbDesconto.Location = new Point(3, 3);
            gbDesconto.Name = "gbDesconto";
            gbDesconto.Size = new Size(381, 226);
            gbDesconto.TabIndex = 4;
            gbDesconto.TabStop = false;
            // 
            // txtDescricao
            // 
            txtDescricao.Dock = DockStyle.Bottom;
            txtDescricao.Font = new Font("Arial", 12F, FontStyle.Bold);
            txtDescricao.ForeColor = Color.FromArgb(80, 80, 80);
            txtDescricao.Location = new Point(3, 55);
            txtDescricao.Multiline = true;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(375, 168);
            txtDescricao.TabIndex = 31;
            // 
            // lblOperacao
            // 
            lblOperacao.Dock = DockStyle.Top;
            lblOperacao.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblOperacao.Location = new Point(3, 17);
            lblOperacao.Name = "lblOperacao";
            lblOperacao.Size = new Size(375, 22);
            lblOperacao.TabIndex = 30;
            lblOperacao.Text = "Informe o motivo do cancelamento";
            lblOperacao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Arial", 9F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(80, 80, 80);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(381, 226);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // tbNFe
            // 
            tbNFe.Controls.Add(groupBox1);
            tbNFe.Location = new Point(4, 5);
            tbNFe.Name = "tbNFe";
            tbNFe.Padding = new Padding(3);
            tbNFe.Size = new Size(387, 232);
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
            tbGeral.Size = new Size(395, 241);
            tbGeral.TabIndex = 5;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(tbGeral);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(395, 241);
            pnlConteudo.TabIndex = 8;
            // 
            // CancelamentoDFeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 241);
            Controls.Add(tableLayoutRodape);
            Controls.Add(pnlConteudo);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CancelamentoDFeForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cancelamento";
            Shown += CancelamentoDFeForm_Shown;
            KeyDown += CancelamentoDFeForm_KeyDown;
            tableLayoutRodape.ResumeLayout(false);
            tbNFCe.ResumeLayout(false);
            gbDesconto.ResumeLayout(false);
            gbDesconto.PerformLayout();
            tbNFe.ResumeLayout(false);
            tbGeral.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutRodape;
        private Button btnConfirmar;
        private Button btnCancelar;
        private TabPage tbNFCe;
        private GroupBox gbDesconto;
        private GroupBox groupBox1;
        private TabPage tbNFe;
        private TabControl tbGeral;
        private Panel pnlConteudo;
        private ToolTip toolTipHint;
        public TextBox txtDescricao;
        public Label lblOperacao;
    }
}