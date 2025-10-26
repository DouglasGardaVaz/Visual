namespace Visual.View.Tributacao.FederalCadastroFormulario
{
    partial class TributacaoFederalCadastroForm
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
            pnlConteudo = new Panel();
            label7 = new Label();
            txtAliquotaCOFINS = new TextBox();
            label6 = new Label();
            txtAliquotaPIS = new TextBox();
            label5 = new Label();
            txtAliquotaIPI = new TextBox();
            label4 = new Label();
            cmbOrigem = new ComboBox();
            label3 = new Label();
            cmbCOFINS = new ComboBox();
            label2 = new Label();
            cmbPIS = new ComboBox();
            lblDocumento = new Label();
            cmbIPI = new ComboBox();
            txtDescricao = new TextBox();
            label1 = new Label();
            toolTipHint = new ToolTip(components);
            tableLayoutRodape.SuspendLayout();
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
            tableLayoutRodape.Location = new Point(0, 295);
            tableLayoutRodape.Margin = new Padding(10);
            tableLayoutRodape.Name = "tableLayoutRodape";
            tableLayoutRodape.RowCount = 1;
            tableLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutRodape.Size = new Size(416, 45);
            tableLayoutRodape.TabIndex = 1;
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
            btnConfirmar.Location = new Point(299, 3);
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
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(label7);
            pnlConteudo.Controls.Add(txtAliquotaCOFINS);
            pnlConteudo.Controls.Add(label6);
            pnlConteudo.Controls.Add(txtAliquotaPIS);
            pnlConteudo.Controls.Add(label5);
            pnlConteudo.Controls.Add(txtAliquotaIPI);
            pnlConteudo.Controls.Add(label4);
            pnlConteudo.Controls.Add(cmbOrigem);
            pnlConteudo.Controls.Add(label3);
            pnlConteudo.Controls.Add(cmbCOFINS);
            pnlConteudo.Controls.Add(label2);
            pnlConteudo.Controls.Add(cmbPIS);
            pnlConteudo.Controls.Add(lblDocumento);
            pnlConteudo.Controls.Add(cmbIPI);
            pnlConteudo.Controls.Add(txtDescricao);
            pnlConteudo.Controls.Add(label1);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(416, 340);
            pnlConteudo.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(346, 171);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 21;
            label7.Text = "% COFINS";
            // 
            // txtAliquotaCOFINS
            // 
            txtAliquotaCOFINS.Location = new Point(346, 189);
            txtAliquotaCOFINS.Name = "txtAliquotaCOFINS";
            txtAliquotaCOFINS.Size = new Size(47, 23);
            txtAliquotaCOFINS.TabIndex = 6;
            txtAliquotaCOFINS.Tag = "valor2";
            txtAliquotaCOFINS.Text = "0,00";
            txtAliquotaCOFINS.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(346, 120);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 19;
            label6.Text = "% PIS";
            // 
            // txtAliquotaPIS
            // 
            txtAliquotaPIS.Location = new Point(346, 138);
            txtAliquotaPIS.Name = "txtAliquotaPIS";
            txtAliquotaPIS.Size = new Size(47, 23);
            txtAliquotaPIS.TabIndex = 4;
            txtAliquotaPIS.Tag = "valor2";
            txtAliquotaPIS.Text = "0,00";
            txtAliquotaPIS.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(346, 74);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 17;
            label5.Text = "% IPI";
            // 
            // txtAliquotaIPI
            // 
            txtAliquotaIPI.Location = new Point(346, 92);
            txtAliquotaIPI.Name = "txtAliquotaIPI";
            txtAliquotaIPI.Size = new Size(47, 23);
            txtAliquotaIPI.TabIndex = 2;
            txtAliquotaIPI.Tag = "valor2";
            txtAliquotaIPI.Text = "0,00";
            txtAliquotaIPI.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 221);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 15;
            label4.Text = "Origem";
            // 
            // cmbOrigem
            // 
            cmbOrigem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOrigem.FormattingEnabled = true;
            cmbOrigem.Location = new Point(13, 239);
            cmbOrigem.Name = "cmbOrigem";
            cmbOrigem.Size = new Size(327, 23);
            cmbOrigem.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 171);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 13;
            label3.Text = "COFINS";
            // 
            // cmbCOFINS
            // 
            cmbCOFINS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCOFINS.FormattingEnabled = true;
            cmbCOFINS.Location = new Point(13, 189);
            cmbCOFINS.Name = "cmbCOFINS";
            cmbCOFINS.Size = new Size(327, 23);
            cmbCOFINS.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 120);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 11;
            label2.Text = "PIS";
            // 
            // cmbPIS
            // 
            cmbPIS.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPIS.FormattingEnabled = true;
            cmbPIS.Location = new Point(12, 138);
            cmbPIS.Name = "cmbPIS";
            cmbPIS.Size = new Size(328, 23);
            cmbPIS.TabIndex = 3;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(13, 74);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(20, 15);
            lblDocumento.TabIndex = 9;
            lblDocumento.Text = "IPI";
            // 
            // cmbIPI
            // 
            cmbIPI.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIPI.FormattingEnabled = true;
            cmbIPI.Location = new Point(13, 92);
            cmbIPI.Name = "cmbIPI";
            cmbIPI.Size = new Size(327, 23);
            cmbIPI.TabIndex = 1;
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(13, 43);
            txtDescricao.MaxLength = 100;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(327, 23);
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
            // TributacaoFederalCadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 340);
            Controls.Add(tableLayoutRodape);
            Controls.Add(pnlConteudo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TributacaoFederalCadastroForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro tributação federal";
            Load += TributacaoFederalCadastroForm_Load;
            Shown += TributacaoFederalCadastroForm_Shown;
            KeyDown += TributacaoFederalCadastroForm_KeyDown;
            tableLayoutRodape.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            pnlConteudo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutRodape;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private TextBox txtDescricao;
        private Label label1;
        private ToolTip toolTipHint;
        private Label label6;
        private TextBox txtAliquotaPIS;
        private Label label5;
        private TextBox txtAliquotaIPI;
        private Label label4;
        private ComboBox cmbOrigem;
        private Label label3;
        private ComboBox cmbCOFINS;
        private Label label2;
        private ComboBox cmbPIS;
        private Label lblDocumento;
        private ComboBox cmbIPI;
        private Label label7;
        private TextBox txtAliquotaCOFINS;
    }
}