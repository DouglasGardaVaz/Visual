namespace Visual.View.Pessoa.CadastroEnderecoFormulario
{
    partial class PessoaCadastroEnderecoForm
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
            cmbTipoEndereco = new ComboBox();
            label6 = new Label();
            txtBairro = new TextBox();
            label5 = new Label();
            txtComplemento = new TextBox();
            label4 = new Label();
            txtNumero = new TextBox();
            label2 = new Label();
            txtLogradouro = new TextBox();
            label3 = new Label();
            cmbUF = new ComboBox();
            mskCEP = new MaskedTextBox();
            label1 = new Label();
            lblCidade = new Label();
            cmbCidade = new ComboBox();
            toolTipHint = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            pnlConteudo.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(btnConfirmar, 2, 0);
            tableLayoutPanel1.Controls.Add(btnCancelar, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 302);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(376, 45);
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
            btnConfirmar.Location = new Point(283, 3);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(90, 39);
            btnConfirmar.TabIndex = 7;
            btnConfirmar.Text = "&Confirmar";
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
            btnCancelar.Size = new Size(75, 39);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "C&ancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(cmbTipoEndereco);
            pnlConteudo.Controls.Add(label6);
            pnlConteudo.Controls.Add(txtBairro);
            pnlConteudo.Controls.Add(label5);
            pnlConteudo.Controls.Add(txtComplemento);
            pnlConteudo.Controls.Add(label4);
            pnlConteudo.Controls.Add(txtNumero);
            pnlConteudo.Controls.Add(label2);
            pnlConteudo.Controls.Add(txtLogradouro);
            pnlConteudo.Controls.Add(label3);
            pnlConteudo.Controls.Add(cmbUF);
            pnlConteudo.Controls.Add(mskCEP);
            pnlConteudo.Controls.Add(label1);
            pnlConteudo.Controls.Add(lblCidade);
            pnlConteudo.Controls.Add(cmbCidade);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(376, 347);
            pnlConteudo.TabIndex = 5;
            // 
            // cmbTipoEndereco
            // 
            cmbTipoEndereco.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoEndereco.FormattingEnabled = true;
            cmbTipoEndereco.Location = new Point(12, 16);
            cmbTipoEndereco.Name = "cmbTipoEndereco";
            cmbTipoEndereco.Size = new Size(170, 23);
            cmbTipoEndereco.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 201);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 17;
            label6.Text = "Bairro";
            // 
            // txtBairro
            // 
            txtBairro.Location = new Point(12, 219);
            txtBairro.Name = "txtBairro";
            txtBairro.Size = new Size(350, 23);
            txtBairro.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 245);
            label5.Name = "label5";
            label5.Size = new Size(84, 15);
            label5.TabIndex = 15;
            label5.Text = "Complemento";
            // 
            // txtComplemento
            // 
            txtComplemento.Location = new Point(12, 263);
            txtComplemento.Name = "txtComplemento";
            txtComplemento.Size = new Size(350, 23);
            txtComplemento.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(306, 151);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 13;
            label4.Text = "Nº";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(306, 169);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(56, 23);
            txtNumero.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 151);
            label2.Name = "label2";
            label2.Size = new Size(27, 15);
            label2.TabIndex = 11;
            label2.Text = "Rua";
            // 
            // txtLogradouro
            // 
            txtLogradouro.Location = new Point(12, 169);
            txtLogradouro.Name = "txtLogradouro";
            txtLogradouro.Size = new Size(285, 23);
            txtLogradouro.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(306, 50);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 9;
            label3.Text = "UF";
            // 
            // cmbUF
            // 
            cmbUF.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUF.FormattingEnabled = true;
            cmbUF.Location = new Point(306, 69);
            cmbUF.Name = "cmbUF";
            cmbUF.Size = new Size(56, 23);
            cmbUF.TabIndex = 1;
            cmbUF.SelectedIndexChanged += cmbUF_SelectedIndexChanged;
            // 
            // mskCEP
            // 
            mskCEP.Location = new Point(12, 119);
            mskCEP.Name = "mskCEP";
            mskCEP.Size = new Size(102, 23);
            mskCEP.TabIndex = 2;
            mskCEP.KeyDown += mskCEP_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 101);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 3;
            label1.Text = "CEP";
            // 
            // lblCidade
            // 
            lblCidade.AutoSize = true;
            lblCidade.Location = new Point(12, 50);
            lblCidade.Name = "lblCidade";
            lblCidade.Size = new Size(44, 15);
            lblCidade.TabIndex = 1;
            lblCidade.Text = "Cidade";
            // 
            // cmbCidade
            // 
            cmbCidade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCidade.FormattingEnabled = true;
            cmbCidade.Location = new Point(12, 69);
            cmbCidade.Name = "cmbCidade";
            cmbCidade.Size = new Size(285, 23);
            cmbCidade.TabIndex = 0;
            // 
            // PessoaCadastroEnderecoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 347);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlConteudo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PessoaCadastroEnderecoForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro endereço";
            Load += PessoaCadastroEnderecoForm_Load;
            Shown += PessoaCadastroEnderecoForm_Shown;
            KeyDown += PessoaCadastroEnderecoForm_KeyDown;
            tableLayoutPanel1.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            pnlConteudo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private Label label3;
        private ComboBox cmbUF;
        private MaskedTextBox mskCEP;
        private Label label1;
        private Label lblCidade;
        private ComboBox cmbCidade;
        private ToolTip toolTipHint;
        private Label label2;
        private TextBox txtLogradouro;
        private Label label5;
        private TextBox txtComplemento;
        private Label label4;
        private TextBox txtNumero;
        private Label label6;
        private TextBox txtBairro;
        private Label label7;
        private ComboBox cmbTipoEndereco;
    }
}