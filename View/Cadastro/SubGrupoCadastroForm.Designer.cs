namespace Visual.View.Cadastro.SubgrupoCadastroFormulario
{
    partial class SubGrupoCadastroForm
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
            pnlConteudo = new Panel();
            gbSubGrupo = new GroupBox();
            pbBuscaGrupo = new PictureBox();
            txtGrupo = new TextBox();
            label14 = new Label();
            ckAtivo = new CheckBox();
            txtDescricao = new TextBox();
            label1 = new Label();
            btnCancelar = new Button();
            toolTipHint = new ToolTip(components);
            tableLayoutRodape = new TableLayoutPanel();
            pnlConteudo.SuspendLayout();
            gbSubGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBuscaGrupo).BeginInit();
            tableLayoutRodape.SuspendLayout();
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
            btnConfirmar.Location = new Point(294, 3);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(114, 39);
            btnConfirmar.TabIndex = 0;
            btnConfirmar.Text = "&Confirmar | F6";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(gbSubGrupo);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(411, 152);
            pnlConteudo.TabIndex = 6;
            // 
            // gbSubGrupo
            // 
            gbSubGrupo.Controls.Add(pbBuscaGrupo);
            gbSubGrupo.Controls.Add(txtGrupo);
            gbSubGrupo.Controls.Add(label14);
            gbSubGrupo.Controls.Add(ckAtivo);
            gbSubGrupo.Controls.Add(txtDescricao);
            gbSubGrupo.Controls.Add(label1);
            gbSubGrupo.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbSubGrupo.Location = new Point(11, 9);
            gbSubGrupo.Name = "gbSubGrupo";
            gbSubGrupo.Size = new Size(386, 128);
            gbSubGrupo.TabIndex = 14;
            gbSubGrupo.TabStop = false;
            gbSubGrupo.Text = "Subgrupo:";
            // 
            // pbBuscaGrupo
            // 
            pbBuscaGrupo.Cursor = Cursors.Hand;
            pbBuscaGrupo.Image = Visual.Properties.Resources.lupapeq;
            pbBuscaGrupo.Location = new Point(321, 81);
            pbBuscaGrupo.Name = "pbBuscaGrupo";
            pbBuscaGrupo.Size = new Size(24, 24);
            pbBuscaGrupo.SizeMode = PictureBoxSizeMode.AutoSize;
            pbBuscaGrupo.TabIndex = 24;
            pbBuscaGrupo.TabStop = false;
            pbBuscaGrupo.Click += pbBuscaGrupo_Click;
            // 
            // txtGrupo
            // 
            txtGrupo.Enabled = false;
            txtGrupo.Font = new Font("Arial", 9F);
            txtGrupo.Location = new Point(6, 84);
            txtGrupo.MaxLength = 8;
            txtGrupo.Name = "txtGrupo";
            txtGrupo.ReadOnly = true;
            txtGrupo.Size = new Size(309, 21);
            txtGrupo.TabIndex = 23;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 9F);
            label14.Location = new Point(6, 65);
            label14.Name = "label14";
            label14.Size = new Size(41, 15);
            label14.TabIndex = 22;
            label14.Text = "Grupo";
            // 
            // ckAtivo
            // 
            ckAtivo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckAtivo.AutoSize = true;
            ckAtivo.Font = new Font("Arial", 9F);
            ckAtivo.Location = new Point(329, 15);
            ckAtivo.Name = "ckAtivo";
            ckAtivo.Size = new Size(51, 19);
            ckAtivo.TabIndex = 0;
            ckAtivo.Text = "Ativo";
            ckAtivo.UseVisualStyleBackColor = true;
            // 
            // txtDescricao
            // 
            txtDescricao.Font = new Font("Arial", 9F);
            txtDescricao.Location = new Point(6, 37);
            txtDescricao.MaxLength = 100;
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(309, 21);
            txtDescricao.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 7;
            label1.Text = "Nome";
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
            tableLayoutRodape.Location = new Point(0, 152);
            tableLayoutRodape.Margin = new Padding(10);
            tableLayoutRodape.Name = "tableLayoutRodape";
            tableLayoutRodape.RowCount = 1;
            tableLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutRodape.Size = new Size(411, 45);
            tableLayoutRodape.TabIndex = 7;
            // 
            // SubGrupoCadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 197);
            Controls.Add(pnlConteudo);
            Controls.Add(tableLayoutRodape);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SubGrupoCadastroForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerencial - Subgrupo";
            Load += SubGrupoCadastroForm_Load;
            Shown += SubGrupoCadastroForm_Shown;
            KeyDown += SubGrupoCadastroForm_KeyDown;
            pnlConteudo.ResumeLayout(false);
            gbSubGrupo.ResumeLayout(false);
            gbSubGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBuscaGrupo).EndInit();
            tableLayoutRodape.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnConfirmar;
        private Panel pnlConteudo;
        private GroupBox gbSubGrupo;
        private CheckBox ckAtivo;
        private TextBox txtDescricao;
        private Label label1;
        private Button btnCancelar;
        private ToolTip toolTipHint;
        private TableLayoutPanel tableLayoutRodape;
        private PictureBox pbBuscaGrupo;
        private TextBox txtGrupo;
        private Label label14;
    }
}