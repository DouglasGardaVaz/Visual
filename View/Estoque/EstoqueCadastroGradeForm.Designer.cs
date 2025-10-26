namespace Visual.View.Estoque.CadastroGradeFormulario
{
    partial class EstoqueCadastroGradeForm
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
            tbRodape = new TableLayoutPanel();
            btnGravar = new Button();
            btnCancelar = new Button();
            pnlConteudo = new Panel();
            cmbTamanho = new ComboBox();
            cmbCor = new ComboBox();
            label9 = new Label();
            txtQtde = new TextBox();
            pbCodigoBarras = new PictureBox();
            label3 = new Label();
            txtCodigoBarra = new TextBox();
            label17 = new Label();
            txtTamanho = new TextBox();
            label18 = new Label();
            txtCor = new TextBox();
            tbRodape.SuspendLayout();
            pnlConteudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCodigoBarras).BeginInit();
            SuspendLayout();
            // 
            // tbRodape
            // 
            tbRodape.ColumnCount = 3;
            tbRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbRodape.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tbRodape.Controls.Add(btnGravar, 2, 0);
            tbRodape.Controls.Add(btnCancelar, 0, 0);
            tbRodape.Dock = DockStyle.Bottom;
            tbRodape.Location = new Point(0, 252);
            tbRodape.Margin = new Padding(10);
            tbRodape.Name = "tbRodape";
            tbRodape.RowCount = 1;
            tbRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbRodape.Size = new Size(373, 45);
            tbRodape.TabIndex = 8;
            // 
            // btnGravar
            // 
            btnGravar.BackColor = Color.White;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Dock = DockStyle.Fill;
            btnGravar.FlatAppearance.BorderColor = Color.Gray;
            btnGravar.FlatAppearance.BorderSize = 0;
            btnGravar.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnGravar.FlatStyle = FlatStyle.Flat;
            btnGravar.Font = new Font("Arial", 11F);
            btnGravar.ForeColor = Color.FromArgb(60, 60, 60);
            btnGravar.Location = new Point(246, 3);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(124, 39);
            btnGravar.TabIndex = 2;
            btnGravar.Text = "&Gravar | F6";
            btnGravar.UseVisualStyleBackColor = false;
            btnGravar.Click += btnGravar_Click;
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
            btnCancelar.ForeColor = Color.FromArgb(60, 60, 60);
            btnCancelar.Location = new Point(3, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(124, 39);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "C&ancelar | F4";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(cmbTamanho);
            pnlConteudo.Controls.Add(cmbCor);
            pnlConteudo.Controls.Add(label9);
            pnlConteudo.Controls.Add(txtQtde);
            pnlConteudo.Controls.Add(pbCodigoBarras);
            pnlConteudo.Controls.Add(label3);
            pnlConteudo.Controls.Add(txtCodigoBarra);
            pnlConteudo.Controls.Add(label17);
            pnlConteudo.Controls.Add(txtTamanho);
            pnlConteudo.Controls.Add(label18);
            pnlConteudo.Controls.Add(txtCor);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Padding = new Padding(10, 10, 0, 10);
            pnlConteudo.Size = new Size(373, 297);
            pnlConteudo.TabIndex = 9;
            // 
            // cmbTamanho
            // 
            cmbTamanho.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTamanho.FormattingEnabled = true;
            cmbTamanho.Location = new Point(223, 101);
            cmbTamanho.Name = "cmbTamanho";
            cmbTamanho.Size = new Size(121, 23);
            cmbTamanho.TabIndex = 31;
            // 
            // cmbCor
            // 
            cmbCor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCor.FormattingEnabled = true;
            cmbCor.Location = new Point(223, 48);
            cmbCor.Name = "cmbCor";
            cmbCor.Size = new Size(121, 23);
            cmbCor.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9F);
            label9.Location = new Point(13, 186);
            label9.Name = "label9";
            label9.Size = new Size(71, 15);
            label9.TabIndex = 29;
            label9.Tag = "";
            label9.Text = "Quantidade";
            // 
            // txtQtde
            // 
            txtQtde.Font = new Font("Arial", 11F);
            txtQtde.Location = new Point(13, 205);
            txtQtde.MaxLength = 5;
            txtQtde.Name = "txtQtde";
            txtQtde.Size = new Size(82, 24);
            txtQtde.TabIndex = 28;
            txtQtde.Tag = "numero";
            txtQtde.Text = "0";
            txtQtde.TextAlign = HorizontalAlignment.Right;
            // 
            // pbCodigoBarras
            // 
            pbCodigoBarras.Cursor = Cursors.Hand;
            pbCodigoBarras.Image = Visual.Properties.Resources.barcode;
            pbCodigoBarras.Location = new Point(132, 153);
            pbCodigoBarras.Name = "pbCodigoBarras";
            pbCodigoBarras.Size = new Size(24, 24);
            pbCodigoBarras.SizeMode = PictureBoxSizeMode.AutoSize;
            pbCodigoBarras.TabIndex = 15;
            pbCodigoBarras.TabStop = false;
            pbCodigoBarras.Click += pbCodigoBarras_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 139);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 14;
            label3.Text = "Código de barras";
            // 
            // txtCodigoBarra
            // 
            txtCodigoBarra.Location = new Point(13, 156);
            txtCodigoBarra.MaxLength = 20;
            txtCodigoBarra.Name = "txtCodigoBarra";
            txtCodigoBarra.Size = new Size(113, 21);
            txtCodigoBarra.TabIndex = 13;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 9F);
            label17.Location = new Point(13, 79);
            label17.Name = "label17";
            label17.Size = new Size(59, 15);
            label17.TabIndex = 12;
            label17.Text = "Tamanho";
            // 
            // txtTamanho
            // 
            txtTamanho.Font = new Font("Arial", 11F);
            txtTamanho.Location = new Point(13, 99);
            txtTamanho.MaxLength = 50;
            txtTamanho.Name = "txtTamanho";
            txtTamanho.Size = new Size(204, 24);
            txtTamanho.TabIndex = 10;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Arial", 9F);
            label18.Location = new Point(13, 25);
            label18.Name = "label18";
            label18.Size = new Size(27, 15);
            label18.TabIndex = 11;
            label18.Text = "Cor";
            // 
            // txtCor
            // 
            txtCor.Font = new Font("Arial", 11F);
            txtCor.Location = new Point(13, 47);
            txtCor.MaxLength = 50;
            txtCor.Name = "txtCor";
            txtCor.Size = new Size(204, 24);
            txtCor.TabIndex = 9;
            // 
            // EstoqueCadastroGradeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 297);
            Controls.Add(tbRodape);
            Controls.Add(pnlConteudo);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EstoqueCadastroGradeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de grade";
            Load += EstoqueCadastroGradeForm_Load;
            KeyDown += EstoqueCadastroGradeForm_KeyDown;
            tbRodape.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            pnlConteudo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCodigoBarras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tbRodape;
        private Button btnGravar;
        private Button btnCancelar;
        private Panel pnlConteudo;
        private Label label17;
        private TextBox txtTamanho;
        private Label label18;
        private TextBox txtCor;
        private PictureBox pbCodigoBarras;
        private Label label3;
        private TextBox txtCodigoBarra;
        private Label label9;
        private TextBox txtQtde;
        private ComboBox cmbTamanho;
        private ComboBox cmbCor;
    }
}