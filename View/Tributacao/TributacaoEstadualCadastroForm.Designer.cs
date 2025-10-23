namespace Dados.View.TributacaoEstadualCadastroFormulario
{
    partial class TributacaoEstadualCadastroForm
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
            toolTipHint = new ToolTip(components);
            label7 = new Label();
            txtAliquotaICMS = new TextBox();
            btnConfirmar = new Button();
            tableLayoutRodape = new TableLayoutPanel();
            btnCancelar = new Button();
            lblDocumento = new Label();
            cmbCSTCSOSN = new ComboBox();
            txtDescricao = new TextBox();
            label1 = new Label();
            pnlConteudo = new Panel();
            txtDescricaoCFOP = new TextBox();
            pbBuscaCFOP = new PictureBox();
            txtCFOP = new TextBox();
            label20 = new Label();
            tableLayoutRodape.SuspendLayout();
            pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBuscaCFOP).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(346, 74);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 21;
            label7.Text = "% ICMS";
            // 
            // txtAliquotaICMS
            // 
            txtAliquotaICMS.Location = new Point(346, 92);
            txtAliquotaICMS.Name = "txtAliquotaICMS";
            txtAliquotaICMS.Size = new Size(47, 23);
            txtAliquotaICMS.TabIndex = 6;
            txtAliquotaICMS.Tag = "valor2";
            txtAliquotaICMS.Text = "0,00";
            txtAliquotaICMS.TextAlign = HorizontalAlignment.Right;
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
            btnConfirmar.Location = new Point(291, 3);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(114, 39);
            btnConfirmar.TabIndex = 0;
            btnConfirmar.Text = "&Confirmar | F6";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
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
            tableLayoutRodape.Location = new Point(0, 212);
            tableLayoutRodape.Margin = new Padding(10);
            tableLayoutRodape.Name = "tableLayoutRodape";
            tableLayoutRodape.RowCount = 1;
            tableLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutRodape.Size = new Size(408, 45);
            tableLayoutRodape.TabIndex = 3;
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
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(13, 74);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(70, 15);
            lblDocumento.TabIndex = 9;
            lblDocumento.Text = "CST/CSOSN";
            // 
            // cmbCSTCSOSN
            // 
            cmbCSTCSOSN.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCSTCSOSN.FormattingEnabled = true;
            cmbCSTCSOSN.Location = new Point(13, 92);
            cmbCSTCSOSN.Name = "cmbCSTCSOSN";
            cmbCSTCSOSN.Size = new Size(327, 23);
            cmbCSTCSOSN.TabIndex = 1;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(13, 43);
            txtDescricao.MaxLength = 100;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(380, 23);
            txtDescricao.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 3;
            label1.Text = "Descrição";
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(txtDescricaoCFOP);
            pnlConteudo.Controls.Add(pbBuscaCFOP);
            pnlConteudo.Controls.Add(txtCFOP);
            pnlConteudo.Controls.Add(label20);
            pnlConteudo.Controls.Add(label7);
            pnlConteudo.Controls.Add(txtAliquotaICMS);
            pnlConteudo.Controls.Add(lblDocumento);
            pnlConteudo.Controls.Add(cmbCSTCSOSN);
            pnlConteudo.Controls.Add(txtDescricao);
            pnlConteudo.Controls.Add(label1);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(408, 257);
            pnlConteudo.TabIndex = 2;
            // 
            // txtDescricaoCFOP
            // 
            txtDescricaoCFOP.Location = new Point(106, 142);
            txtDescricaoCFOP.MaxLength = 100;
            txtDescricaoCFOP.Multiline = true;
            txtDescricaoCFOP.Name = "txtDescricaoCFOP";
            txtDescricaoCFOP.ReadOnly = true;
            txtDescricaoCFOP.Size = new Size(287, 57);
            txtDescricaoCFOP.TabIndex = 25;
            txtDescricaoCFOP.Tag = "";
            // 
            // pbBuscaCFOP
            // 
            pbBuscaCFOP.Cursor = Cursors.Hand;
            pbBuscaCFOP.Image = Properties.Resources.lupapeq;
            pbBuscaCFOP.Location = new Point(76, 142);
            pbBuscaCFOP.Name = "pbBuscaCFOP";
            pbBuscaCFOP.Size = new Size(24, 24);
            pbBuscaCFOP.SizeMode = PictureBoxSizeMode.AutoSize;
            pbBuscaCFOP.TabIndex = 24;
            pbBuscaCFOP.TabStop = false;
            pbBuscaCFOP.Click += pbBuscaCFOP_Click;
            // 
            // txtCFOP
            // 
            txtCFOP.Location = new Point(12, 142);
            txtCFOP.MaxLength = 4;
            txtCFOP.Name = "txtCFOP";
            txtCFOP.Size = new Size(58, 23);
            txtCFOP.TabIndex = 23;
            txtCFOP.Tag = "numero";
            txtCFOP.TextAlign = HorizontalAlignment.Right;
            txtCFOP.KeyUp += txtCFOP_KeyUp;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(12, 123);
            label20.Name = "label20";
            label20.Size = new Size(37, 15);
            label20.TabIndex = 22;
            label20.Text = "CFOP";
            // 
            // TributacaoEstadualCadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 257);
            Controls.Add(tableLayoutRodape);
            Controls.Add(pnlConteudo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TributacaoEstadualCadastroForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tributação Estadual";
            Load += TributacaoEstadualCadastroForm_Load;
            KeyDown += TributacaoEstadualCadastroForm_KeyDown;
            tableLayoutRodape.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            pnlConteudo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBuscaCFOP).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ToolTip toolTipHint;
        private Label label7;
        private TextBox txtAliquotaICMS;
        private Button btnConfirmar;
        private TableLayoutPanel tableLayoutRodape;
        private Button btnCancelar;
        private Label lblDocumento;
        private ComboBox cmbCSTCSOSN;
        private TextBox txtDescricao;
        private Label label1;
        private Panel pnlConteudo;
        private PictureBox pbBuscaCFOP;
        private TextBox txtCFOP;
        private Label label20;
        private TextBox txtDescricaoCFOP;
    }
}