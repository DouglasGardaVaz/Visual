namespace Dados.View.Cadastro.GrupoCadastroFormulario
{
    partial class GrupoCadastroForm
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
            txtDescricao = new TextBox();
            label1 = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            toolTipHint = new ToolTip(components);
            tableLayoutRodape = new TableLayoutPanel();
            gbSubGrupos = new GroupBox();
            pnlConteudo.SuspendLayout();
            gbNCM.SuspendLayout();
            tableLayoutRodape.SuspendLayout();
            SuspendLayout();
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(gbSubGrupos);
            pnlConteudo.Controls.Add(gbNCM);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(493, 360);
            pnlConteudo.TabIndex = 0;
            // 
            // gbNCM
            // 
            gbNCM.Controls.Add(ckAtivo);
            gbNCM.Controls.Add(txtDescricao);
            gbNCM.Controls.Add(label1);
            gbNCM.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbNCM.Location = new Point(11, 9);
            gbNCM.Name = "gbNCM";
            gbNCM.Size = new Size(467, 74);
            gbNCM.TabIndex = 14;
            gbNCM.TabStop = false;
            gbNCM.Text = "Grupo:";
            // 
            // ckAtivo
            // 
            ckAtivo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckAtivo.AutoSize = true;
            ckAtivo.Font = new Font("Arial", 9F);
            ckAtivo.Location = new Point(410, 16);
            ckAtivo.Name = "ckAtivo";
            ckAtivo.Size = new Size(51, 19);
            ckAtivo.TabIndex = 0;
            ckAtivo.Text = "Ativo";
            ckAtivo.UseVisualStyleBackColor = true;
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Arial", 9F);
            txtDescricao.Location = new Point(6, 35);
            txtDescricao.MaxLength = 100;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(252, 21);
            txtDescricao.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F);
            label1.Location = new Point(6, 17);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 7;
            label1.Text = "Nome";
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
            btnConfirmar.Location = new Point(376, 3);
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
            tableLayoutRodape.Location = new Point(0, 360);
            tableLayoutRodape.Margin = new Padding(10);
            tableLayoutRodape.Name = "tableLayoutRodape";
            tableLayoutRodape.RowCount = 1;
            tableLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutRodape.Size = new Size(493, 45);
            tableLayoutRodape.TabIndex = 3;
            // 
            // gbSubGrupos
            // 
            gbSubGrupos.Font = new Font("Arial", 9F);
            gbSubGrupos.Location = new Point(11, 92);
            gbSubGrupos.Name = "gbSubGrupos";
            gbSubGrupos.Size = new Size(467, 251);
            gbSubGrupos.TabIndex = 15;
            gbSubGrupos.TabStop = false;
            gbSubGrupos.Text = "SubGrupos";
            // 
            // GrupoCadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 405);
            Controls.Add(pnlConteudo);
            Controls.Add(tableLayoutRodape);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GrupoCadastroForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Grupo";
            Load += GrupoCadastroForm_Load;
            Shown += GrupoCadastroForm_Shown;
            KeyDown += GrupoCadastroForm_KeyDown;
            pnlConteudo.ResumeLayout(false);
            gbNCM.ResumeLayout(false);
            gbNCM.PerformLayout();
            tableLayoutRodape.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlConteudo;
        private GroupBox gbNCM;
        private CheckBox ckAtivo;
        private TextBox txtDescricao;
        private Label label1;
        private Button btnConfirmar;
        private Button btnCancelar;
        private ToolTip toolTipHint;
        private TableLayoutPanel tableLayoutRodape;
        private GroupBox gbSubGrupos;
    }
}