namespace Dados.View.Tributacao.UNMedidaCadastroFormulario
{
    partial class TributacaoUNMedidaCadastroForm
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
            btnConfirmar = new Button();
            btnCancelar = new Button();
            toolTipHint = new ToolTip(components);
            tableLayoutRodape = new TableLayoutPanel();
            pnlConteudo = new Panel();
            gbUN = new GroupBox();
            label3 = new Label();
            cmbTipoUso = new ComboBox();
            ckAtivo = new CheckBox();
            txtCodigoUN = new TextBox();
            label2 = new Label();
            txtDescricao = new TextBox();
            label1 = new Label();
            tableLayoutRodape.SuspendLayout();
            pnlConteudo.SuspendLayout();
            gbUN.SuspendLayout();
            SuspendLayout();
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
            btnConfirmar.Location = new Point(268, 3);
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
            // tableLayoutRodape
            // 
            tableLayoutRodape.ColumnCount = 3;
            tableLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutRodape.Controls.Add(btnConfirmar, 2, 0);
            tableLayoutRodape.Controls.Add(btnCancelar, 0, 0);
            tableLayoutRodape.Dock = DockStyle.Bottom;
            tableLayoutRodape.Location = new Point(0, 155);
            tableLayoutRodape.Margin = new Padding(10);
            tableLayoutRodape.Name = "tableLayoutRodape";
            tableLayoutRodape.RowCount = 1;
            tableLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutRodape.Size = new Size(385, 45);
            tableLayoutRodape.TabIndex = 3;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(gbUN);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(385, 200);
            pnlConteudo.TabIndex = 2;
            // 
            // gbUN
            // 
            gbUN.Controls.Add(label3);
            gbUN.Controls.Add(cmbTipoUso);
            gbUN.Controls.Add(ckAtivo);
            gbUN.Controls.Add(txtCodigoUN);
            gbUN.Controls.Add(label2);
            gbUN.Controls.Add(txtDescricao);
            gbUN.Controls.Add(label1);
            gbUN.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbUN.Location = new Point(11, 9);
            gbUN.Name = "gbUN";
            gbUN.Size = new Size(362, 130);
            gbUN.TabIndex = 14;
            gbUN.TabStop = false;
            gbUN.Text = "Unidade de medida:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F);
            label3.Location = new Point(11, 69);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 13;
            label3.Text = "Tipo de uso";
            // 
            // cmbTipoUso
            // 
            cmbTipoUso.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoUso.Font = new Font("Arial", 9F);
            cmbTipoUso.FormattingEnabled = true;
            cmbTipoUso.Location = new Point(11, 87);
            cmbTipoUso.Name = "cmbTipoUso";
            cmbTipoUso.Size = new Size(202, 23);
            cmbTipoUso.TabIndex = 12;
            // 
            // ckAtivo
            // 
            ckAtivo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckAtivo.AutoSize = true;
            ckAtivo.Font = new Font("Arial", 9F);
            ckAtivo.Location = new Point(307, 11);
            ckAtivo.Name = "ckAtivo";
            ckAtivo.Size = new Size(51, 19);
            ckAtivo.TabIndex = 0;
            ckAtivo.Text = "Ativo";
            ckAtivo.UseVisualStyleBackColor = true;
            // 
            // txtCodigoUN
            // 
            txtCodigoUN.Font = new Font("Arial", 9F);
            txtCodigoUN.Location = new Point(11, 39);
            txtCodigoUN.MaxLength = 100;
            txtCodigoUN.Name = "txtCodigoUN";
            txtCodigoUN.Size = new Size(62, 21);
            txtCodigoUN.TabIndex = 1;
            txtCodigoUN.Tag = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F);
            label2.Location = new Point(11, 21);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 8;
            label2.Text = "Código";
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Arial", 9F);
            txtDescricao.Location = new Point(80, 39);
            txtDescricao.MaxLength = 100;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(202, 21);
            txtDescricao.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F);
            label1.Location = new Point(79, 21);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 7;
            label1.Text = "Descrição";
            // 
            // TributacaoUNMedidaCadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 200);
            Controls.Add(tableLayoutRodape);
            Controls.Add(pnlConteudo);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TributacaoUNMedidaCadastroForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tributação - Unidade de medida";
            Load += TributacaoUNMedidaCadastroForm_Load;
            Shown += TributacaoUNMedidaCadastroForm_Shown;
            KeyDown += TributacaoUNMedidaCadastroForm_KeyDown;
            tableLayoutRodape.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            gbUN.ResumeLayout(false);
            gbUN.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnConfirmar;
        private Button btnCancelar;
        private ToolTip toolTipHint;
        private TableLayoutPanel tableLayoutRodape;
        private Panel pnlConteudo;
        private GroupBox gbUN;
        private CheckBox ckAtivo;
        private TextBox txtCodigoUN;
        private Label label2;
        private TextBox txtDescricao;
        private Label label1;
        private Label label3;
        private ComboBox cmbTipoUso;
    }
}