namespace Dados.View.PessoaCadastroContatoFormulario
{
    partial class PessoaCadastroContatoForm
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
            mskContato = new MaskedTextBox();
            label2 = new Label();
            txtObservacao = new TextBox();
            label1 = new Label();
            lblTipoContato = new Label();
            cmbTipoContato = new ComboBox();
            toolTipHint = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            pnlConteudo.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.Controls.Add(btnConfirmar, 2, 0);
            tableLayoutPanel1.Controls.Add(btnCancelar, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 263);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(333, 45);
            tableLayoutPanel1.TabIndex = 2;
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
            btnConfirmar.Location = new Point(216, 3);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(114, 39);
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
            btnCancelar.Size = new Size(114, 39);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "C&ancelar | F4";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(mskContato);
            pnlConteudo.Controls.Add(label2);
            pnlConteudo.Controls.Add(txtObservacao);
            pnlConteudo.Controls.Add(label1);
            pnlConteudo.Controls.Add(lblTipoContato);
            pnlConteudo.Controls.Add(cmbTipoContato);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(333, 308);
            pnlConteudo.TabIndex = 3;
            // 
            // mskContato
            // 
            mskContato.Location = new Point(12, 93);
            mskContato.Name = "mskContato";
            mskContato.Size = new Size(303, 21);
            mskContato.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 131);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 6;
            label2.Text = "Observações";
            // 
            // txtObservacao
            // 
            txtObservacao.Location = new Point(12, 154);
            txtObservacao.Multiline = true;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(303, 95);
            txtObservacao.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 3;
            label1.Text = "Contato";
            // 
            // lblTipoContato
            // 
            lblTipoContato.AutoSize = true;
            lblTipoContato.Location = new Point(12, 19);
            lblTipoContato.Name = "lblTipoContato";
            lblTipoContato.Size = new Size(91, 15);
            lblTipoContato.TabIndex = 1;
            lblTipoContato.Text = "Tipo do contato";
            // 
            // cmbTipoContato
            // 
            cmbTipoContato.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoContato.FormattingEnabled = true;
            cmbTipoContato.Location = new Point(12, 38);
            cmbTipoContato.Name = "cmbTipoContato";
            cmbTipoContato.Size = new Size(303, 23);
            cmbTipoContato.TabIndex = 0;
            cmbTipoContato.SelectedIndexChanged += cmbTipoContato_SelectedIndexChanged;
            // 
            // PessoaCadastroContatoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 225, 230);
            ClientSize = new Size(333, 308);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlConteudo);
            Font = new Font("Arial", 9F);
            ForeColor = Color.FromArgb(60, 60, 60);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PessoaCadastroContatoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro contato";
            Load += PessoaCadastroContatoForm_Load;
            Shown += PessoaCadastroContatoForm_Shown;
            KeyDown += PessoaCadastroContatoForm_KeyDown;
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
        private Label label1;
        private Label lblTipoContato;
        private ComboBox cmbTipoContato;
        private ToolTip toolTipHint;
        private Label label2;
        private TextBox txtObservacao;
        private MaskedTextBox mskContato;
    }
}