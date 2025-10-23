namespace Dados.View.TributacaoNCMCadastroFormulario
{
    partial class TributacaoNCMCadastroForm
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
            pnlConteudo = new Panel();
            gbNCM = new GroupBox();
            ckAtivo = new CheckBox();
            txtNCM = new TextBox();
            label2 = new Label();
            txtDescricao = new TextBox();
            label1 = new Label();
            gbNCMValores = new GroupBox();
            label10 = new Label();
            dtFimVigencia = new DateTimePicker();
            label9 = new Label();
            dtInicioVigencia = new DateTimePicker();
            label8 = new Label();
            cmbUF = new ComboBox();
            txtEXIPI = new TextBox();
            label7 = new Label();
            txtAliquotaICMS = new TextBox();
            label5 = new Label();
            txtAliquotaCOFINS = new TextBox();
            label6 = new Label();
            txtAliquotaPIS = new TextBox();
            label4 = new Label();
            txtAliquotaIPI = new TextBox();
            label3 = new Label();
            toolTipHint = new ToolTip(components);
            btnConfirmar = new Button();
            tableLayoutRodape = new TableLayoutPanel();
            btnCancelar = new Button();
            pnlConteudo.SuspendLayout();
            gbNCM.SuspendLayout();
            gbNCMValores.SuspendLayout();
            tableLayoutRodape.SuspendLayout();
            SuspendLayout();
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(gbNCM);
            pnlConteudo.Controls.Add(gbNCMValores);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(497, 315);
            pnlConteudo.TabIndex = 0;
            // 
            // gbNCM
            // 
            gbNCM.Controls.Add(ckAtivo);
            gbNCM.Controls.Add(txtNCM);
            gbNCM.Controls.Add(label2);
            gbNCM.Controls.Add(txtDescricao);
            gbNCM.Controls.Add(label1);
            gbNCM.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbNCM.Location = new Point(11, 9);
            gbNCM.Name = "gbNCM";
            gbNCM.Size = new Size(476, 114);
            gbNCM.TabIndex = 0;
            gbNCM.TabStop = false;
            gbNCM.Text = "NCM:";
            // 
            // ckAtivo
            // 
            ckAtivo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckAtivo.AutoSize = true;
            ckAtivo.Font = new Font("Arial", 9F);
            ckAtivo.Location = new Point(419, 16);
            ckAtivo.Name = "ckAtivo";
            ckAtivo.Size = new Size(51, 19);
            ckAtivo.TabIndex = 13;
            ckAtivo.TabStop = false;
            ckAtivo.Text = "Ativo";
            ckAtivo.UseVisualStyleBackColor = true;
            // 
            // txtNCM
            // 
            txtNCM.Font = new Font("Arial", 9F);
            txtNCM.Location = new Point(6, 38);
            txtNCM.MaxLength = 100;
            txtNCM.Name = "txtNCM";
            txtNCM.Size = new Size(74, 21);
            txtNCM.TabIndex = 0;
            txtNCM.Tag = "numero";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F);
            label2.Location = new Point(6, 20);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 8;
            label2.Text = "Código";
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Arial", 9F);
            txtDescricao.Location = new Point(6, 82);
            txtDescricao.MaxLength = 100;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(454, 21);
            txtDescricao.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F);
            label1.Location = new Point(5, 64);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 7;
            label1.Text = "Descrição";
            // 
            // gbNCMValores
            // 
            gbNCMValores.Controls.Add(label10);
            gbNCMValores.Controls.Add(dtFimVigencia);
            gbNCMValores.Controls.Add(label9);
            gbNCMValores.Controls.Add(dtInicioVigencia);
            gbNCMValores.Controls.Add(label8);
            gbNCMValores.Controls.Add(cmbUF);
            gbNCMValores.Controls.Add(txtEXIPI);
            gbNCMValores.Controls.Add(label7);
            gbNCMValores.Controls.Add(txtAliquotaICMS);
            gbNCMValores.Controls.Add(label5);
            gbNCMValores.Controls.Add(txtAliquotaCOFINS);
            gbNCMValores.Controls.Add(label6);
            gbNCMValores.Controls.Add(txtAliquotaPIS);
            gbNCMValores.Controls.Add(label4);
            gbNCMValores.Controls.Add(txtAliquotaIPI);
            gbNCMValores.Controls.Add(label3);
            gbNCMValores.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbNCMValores.Location = new Point(11, 129);
            gbNCMValores.Name = "gbNCMValores";
            gbNCMValores.Size = new Size(476, 177);
            gbNCMValores.TabIndex = 1;
            gbNCMValores.TabStop = false;
            gbNCMValores.Text = "Detalhes:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 9F);
            label10.Location = new Point(114, 122);
            label10.Name = "label10";
            label10.Size = new Size(79, 15);
            label10.TabIndex = 20;
            label10.Text = "Fim vigência:";
            // 
            // dtFimVigencia
            // 
            dtFimVigencia.Font = new Font("Arial", 9F);
            dtFimVigencia.Format = DateTimePickerFormat.Short;
            dtFimVigencia.Location = new Point(114, 140);
            dtFimVigencia.Name = "dtFimVigencia";
            dtFimVigencia.Size = new Size(100, 21);
            dtFimVigencia.TabIndex = 9;
            dtFimVigencia.ValueChanged += dtFimVigencia_ValueChanged;
            dtFimVigencia.KeyDown += dtFimVigencia_KeyDown;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9F);
            label9.Location = new Point(8, 122);
            label9.Name = "label9";
            label9.Size = new Size(87, 15);
            label9.TabIndex = 18;
            label9.Text = "Início vigência:";
            // 
            // dtInicioVigencia
            // 
            dtInicioVigencia.Font = new Font("Arial", 9F);
            dtInicioVigencia.Format = DateTimePickerFormat.Short;
            dtInicioVigencia.Location = new Point(8, 140);
            dtInicioVigencia.Name = "dtInicioVigencia";
            dtInicioVigencia.Size = new Size(100, 21);
            dtInicioVigencia.TabIndex = 8;
            dtInicioVigencia.ValueChanged += dtInicioVigencia_ValueChanged;
            dtInicioVigencia.KeyDown += dtInicioVigencia_KeyDown;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9F);
            label8.Location = new Point(220, 119);
            label8.Name = "label8";
            label8.Size = new Size(23, 15);
            label8.TabIndex = 16;
            label8.Text = "UF";
            label8.Visible = false;
            // 
            // cmbUF
            // 
            cmbUF.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUF.Font = new Font("Arial", 9F);
            cmbUF.FormattingEnabled = true;
            cmbUF.Location = new Point(220, 138);
            cmbUF.Name = "cmbUF";
            cmbUF.Size = new Size(56, 23);
            cmbUF.TabIndex = 2;
            cmbUF.Visible = false;
            // 
            // txtEXIPI
            // 
            txtEXIPI.Font = new Font("Arial", 9F);
            txtEXIPI.Location = new Point(70, 47);
            txtEXIPI.MaxLength = 100;
            txtEXIPI.Name = "txtEXIPI";
            txtEXIPI.Size = new Size(41, 21);
            txtEXIPI.TabIndex = 4;
            txtEXIPI.Tag = "numero";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9F);
            label7.Location = new Point(69, 27);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 14;
            label7.Text = "EX IPI:";
            // 
            // txtAliquotaICMS
            // 
            txtAliquotaICMS.Font = new Font("Arial", 9F);
            txtAliquotaICMS.Location = new Point(8, 95);
            txtAliquotaICMS.MaxLength = 100;
            txtAliquotaICMS.Name = "txtAliquotaICMS";
            txtAliquotaICMS.Size = new Size(56, 21);
            txtAliquotaICMS.TabIndex = 7;
            txtAliquotaICMS.Tag = "valor2";
            txtAliquotaICMS.Text = "0,00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9F);
            label5.Location = new Point(7, 75);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 12;
            label5.Text = "Alíq. ICMS:";
            // 
            // txtAliquotaCOFINS
            // 
            txtAliquotaCOFINS.Font = new Font("Arial", 9F);
            txtAliquotaCOFINS.Location = new Point(182, 47);
            txtAliquotaCOFINS.MaxLength = 100;
            txtAliquotaCOFINS.Name = "txtAliquotaCOFINS";
            txtAliquotaCOFINS.Size = new Size(56, 21);
            txtAliquotaCOFINS.TabIndex = 6;
            txtAliquotaCOFINS.Tag = "valor2";
            txtAliquotaCOFINS.Text = "0,00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9F);
            label6.Location = new Point(181, 27);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 10;
            label6.Text = "Alíq. COFINS:";
            // 
            // txtAliquotaPIS
            // 
            txtAliquotaPIS.Font = new Font("Arial", 9F);
            txtAliquotaPIS.Location = new Point(118, 47);
            txtAliquotaPIS.MaxLength = 100;
            txtAliquotaPIS.Name = "txtAliquotaPIS";
            txtAliquotaPIS.Size = new Size(56, 21);
            txtAliquotaPIS.TabIndex = 5;
            txtAliquotaPIS.Tag = "valor2";
            txtAliquotaPIS.Text = "0,00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9F);
            label4.Location = new Point(117, 27);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 8;
            label4.Text = "Alíq. PIS:";
            // 
            // txtAliquotaIPI
            // 
            txtAliquotaIPI.Font = new Font("Arial", 9F);
            txtAliquotaIPI.Location = new Point(8, 47);
            txtAliquotaIPI.MaxLength = 100;
            txtAliquotaIPI.Name = "txtAliquotaIPI";
            txtAliquotaIPI.Size = new Size(56, 21);
            txtAliquotaIPI.TabIndex = 3;
            txtAliquotaIPI.Tag = "valor2";
            txtAliquotaIPI.Text = "0,00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F);
            label3.Location = new Point(7, 27);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 6;
            label3.Text = "Alíq. IPI:";
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
            btnConfirmar.Location = new Point(380, 3);
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
            tableLayoutRodape.Location = new Point(0, 315);
            tableLayoutRodape.Margin = new Padding(10);
            tableLayoutRodape.Name = "tableLayoutRodape";
            tableLayoutRodape.RowCount = 1;
            tableLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutRodape.Size = new Size(497, 45);
            tableLayoutRodape.TabIndex = 1;
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
            // TributacaoNCMCadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 360);
            Controls.Add(pnlConteudo);
            Controls.Add(tableLayoutRodape);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TributacaoNCMCadastroForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tributação NCM";
            Load += TributacaoNCMCadastroForm_Load;
            Shown += TributacaoNCMCadastroForm_Shown;
            KeyDown += TributacaoNCMCadastroForm_KeyDown;
            pnlConteudo.ResumeLayout(false);
            gbNCM.ResumeLayout(false);
            gbNCM.PerformLayout();
            gbNCMValores.ResumeLayout(false);
            gbNCMValores.PerformLayout();
            tableLayoutRodape.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlConteudo;
        private ToolTip toolTipHint;
        private Button btnConfirmar;
        private TableLayoutPanel tableLayoutRodape;
        private Button btnCancelar;
        private GroupBox gbNCMValores;
        private TextBox txtEXIPI;
        private Label label7;
        private TextBox txtAliquotaICMS;
        private Label label5;
        private TextBox txtAliquotaCOFINS;
        private Label label6;
        private TextBox txtAliquotaPIS;
        private Label label4;
        private TextBox txtAliquotaIPI;
        private Label label3;
        private Label label10;
        private DateTimePicker dtFimVigencia;
        private Label label9;
        private DateTimePicker dtInicioVigencia;
        private Label label8;
        private ComboBox cmbUF;
        private GroupBox gbNCM;
        private CheckBox ckAtivo;
        private TextBox txtNCM;
        private Label label2;
        private TextBox txtDescricao;
        private Label label1;
    }
}