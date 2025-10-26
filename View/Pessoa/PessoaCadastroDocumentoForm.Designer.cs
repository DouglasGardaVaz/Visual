namespace Visual.View.PessoaCadastroDocumentoFormulario
{
    partial class PessoaCadastroDocumentoForm
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
            mskDocumento = new MaskedTextBox();
            label1 = new Label();
            lblDocumento = new Label();
            cmbTipoDocumento = new ComboBox();
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
            tableLayoutPanel1.Location = new Point(0, 133);
            tableLayoutPanel1.Margin = new Padding(10);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(327, 45);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            btnConfirmar.DialogResult = DialogResult.OK;
            btnConfirmar.Dock = DockStyle.Fill;
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Arial", 11F);
            btnConfirmar.Location = new Point(234, 3);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(90, 39);
            btnConfirmar.TabIndex = 2;
            btnConfirmar.Text = "&Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial", 11F);
            btnCancelar.Location = new Point(3, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 39);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "C&ancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(mskDocumento);
            pnlConteudo.Controls.Add(label1);
            pnlConteudo.Controls.Add(lblDocumento);
            pnlConteudo.Controls.Add(cmbTipoDocumento);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(327, 133);
            pnlConteudo.TabIndex = 1;
            // 
            // mskDocumento
            // 
            mskDocumento.Location = new Point(12, 94);
            mskDocumento.Name = "mskDocumento";
            mskDocumento.Size = new Size(303, 23);
            mskDocumento.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(79, 16);
            label1.TabIndex = 3;
            label1.Text = "Documento";
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(12, 19);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(128, 16);
            lblDocumento.TabIndex = 1;
            lblDocumento.Text = "Tipo do documento";
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Location = new Point(12, 38);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(303, 24);
            cmbTipoDocumento.TabIndex = 0;
            cmbTipoDocumento.SelectedIndexChanged += cmbTipoDocumento_SelectedIndexChanged;
            // 
            // PessoaCadastroDocumentoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 225, 230);
            ClientSize = new Size(327, 178);
            Controls.Add(pnlConteudo);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Arial", 10F);
            ForeColor = Color.FromArgb(60, 60, 60);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PessoaCadastroDocumentoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tipo de documento";
            Load += PessoaCadastroDocumentoForm_Load;
            Shown += PessoaCadastroDocumentoForm_Shown;
            KeyDown += PessoaCadastroDocumentoForm_KeyDown;
            tableLayoutPanel1.ResumeLayout(false);
            pnlConteudo.ResumeLayout(false);
            pnlConteudo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlConteudo;
        private ComboBox cmbTipoDocumento;
        private Label label1;
        private Label lblDocumento;
        private ToolTip toolTipHint;
        private MaskedTextBox mskDocumento;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}