namespace Dados.View.Geral.Seguranca
{
    partial class LoginForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            pnlConteudo = new Panel();
            pnlLoginCabecalho = new Panel();
            lblDescricao = new Label();
            pnlLogin = new Panel();
            lblMensagemErro = new Label();
            lblSenha = new Label();
            txtSenha = new TextBox();
            lblLogin = new Label();
            txtLogin = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            pnlConteudo.SuspendLayout();
            pnlLoginCabecalho.SuspendLayout();
            pnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 149F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 149F));
            tableLayoutPanel1.Controls.Add(btnConfirmar, 2, 0);
            tableLayoutPanel1.Controls.Add(btnCancelar, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 214);
            tableLayoutPanel1.Margin = new Padding(11);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(320, 51);
            tableLayoutPanel1.TabIndex = 1;
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
            btnConfirmar.Font = new Font("Arial", 10F);
            btnConfirmar.ForeColor = Color.FromArgb(80, 80, 80);
            btnConfirmar.Location = new Point(174, 3);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(143, 45);
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
            btnCancelar.Font = new Font("Arial", 10F);
            btnCancelar.Location = new Point(3, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(143, 45);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "C&ancelar | F4";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(pnlLoginCabecalho);
            pnlConteudo.Controls.Add(pnlLogin);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 11);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(320, 265);
            pnlConteudo.TabIndex = 7;
            // 
            // pnlLoginCabecalho
            // 
            pnlLoginCabecalho.Controls.Add(lblDescricao);
            pnlLoginCabecalho.Dock = DockStyle.Top;
            pnlLoginCabecalho.Location = new Point(0, 0);
            pnlLoginCabecalho.Name = "pnlLoginCabecalho";
            pnlLoginCabecalho.Size = new Size(320, 60);
            pnlLoginCabecalho.TabIndex = 1;
            // 
            // lblDescricao
            // 
            lblDescricao.Dock = DockStyle.Fill;
            lblDescricao.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblDescricao.Location = new Point(0, 0);
            lblDescricao.Margin = new Padding(3);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Padding = new Padding(3);
            lblDescricao.Size = new Size(320, 60);
            lblDescricao.TabIndex = 2;
            lblDescricao.Text = "Informe o seu login para continuar...";
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(lblMensagemErro);
            pnlLogin.Controls.Add(lblSenha);
            pnlLogin.Controls.Add(txtSenha);
            pnlLogin.Controls.Add(lblLogin);
            pnlLogin.Controls.Add(txtLogin);
            pnlLogin.Dock = DockStyle.Fill;
            pnlLogin.Location = new Point(0, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(320, 265);
            pnlLogin.TabIndex = 0;
            // 
            // lblMensagemErro
            // 
            lblMensagemErro.Font = new Font("Arial", 11F, FontStyle.Bold);
            lblMensagemErro.ForeColor = Color.Red;
            lblMensagemErro.Location = new Point(0, 171);
            lblMensagemErro.Name = "lblMensagemErro";
            lblMensagemErro.Size = new Size(317, 43);
            lblMensagemErro.TabIndex = 4;
            lblMensagemErro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Location = new Point(54, 122);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(50, 17);
            lblSenha.TabIndex = 3;
            lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            txtSenha.Font = new Font("Arial", 11F);
            txtSenha.Location = new Point(54, 142);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(207, 24);
            txtSenha.TabIndex = 1;
            txtSenha.Tag = "PERSONALIZADO";
            txtSenha.KeyDown += txtSenha_KeyDown;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(54, 72);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(58, 17);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Usuário";
            // 
            // txtLogin
            // 
            txtLogin.CharacterCasing = CharacterCasing.Upper;
            txtLogin.Font = new Font("Arial", 11F);
            txtLogin.Location = new Point(54, 92);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(207, 24);
            txtLogin.TabIndex = 0;
            txtLogin.Tag = "";
            txtLogin.Leave += txtLogin_Leave;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 265);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlConteudo);
            Font = new Font("Arial", 11F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosed += LoginForm_FormClosed;
            Load += LoginForm_Load;
            Shown += LoginForm_Shown;
            KeyDown += LoginForm_KeyDown;
            tableLayoutPanel1.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            pnlLoginCabecalho.ResumeLayout(false);
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolTip toolTipHint;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnConfirmar;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private Panel pnlLogin;
        private Panel pnlLoginCabecalho;
        private Label lblDescricao;
        private Label lblSenha;
        private TextBox txtSenha;
        private Label lblLogin;
        private TextBox txtLogin;
        private Label lblMensagemErro;
    }
}