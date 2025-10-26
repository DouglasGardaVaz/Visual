namespace Visual.View.Saida.PDV.DescontoAcrescimoItemFormulario
{
    partial class DescontoAcrescimoItemForm
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
            tbGeral = new TabControl();
            tbDesconto = new TabPage();
            gbDesconto = new GroupBox();
            label1 = new Label();
            txtValorTotalDesconto = new TextBox();
            lblDescontoPercentual = new Label();
            txtValorDescontoPercentual = new TextBox();
            lblDesconto = new Label();
            txtValorDesconto = new TextBox();
            tbAcrescimo = new TabPage();
            groupBox1 = new GroupBox();
            label2 = new Label();
            txtValorTotalAcrescimo = new TextBox();
            lblAcrescimoPercentual = new Label();
            txtValorAcrescimoPercentual = new TextBox();
            lblAcrescimo = new Label();
            txtValorAcrescimo = new TextBox();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            toolTipHint = new ToolTip(components);
            tableLayoutRodape = new TableLayoutPanel();
            pnlConteudo.SuspendLayout();
            tbGeral.SuspendLayout();
            tbDesconto.SuspendLayout();
            gbDesconto.SuspendLayout();
            tbAcrescimo.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutRodape.SuspendLayout();
            SuspendLayout();
            // 
            // pnlConteudo
            // 
            pnlConteudo.Controls.Add(tbGeral);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 0);
            pnlConteudo.Margin = new Padding(3, 3, 3, 10);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(299, 220);
            pnlConteudo.TabIndex = 6;
            // 
            // tbGeral
            // 
            tbGeral.Controls.Add(tbDesconto);
            tbGeral.Controls.Add(tbAcrescimo);
            tbGeral.Dock = DockStyle.Fill;
            tbGeral.ItemSize = new Size(1, 1);
            tbGeral.Location = new Point(0, 0);
            tbGeral.Name = "tbGeral";
            tbGeral.SelectedIndex = 0;
            tbGeral.Size = new Size(299, 220);
            tbGeral.TabIndex = 5;
            // 
            // tbDesconto
            // 
            tbDesconto.Controls.Add(gbDesconto);
            tbDesconto.Location = new Point(4, 5);
            tbDesconto.Name = "tbDesconto";
            tbDesconto.Padding = new Padding(3);
            tbDesconto.Size = new Size(291, 211);
            tbDesconto.TabIndex = 0;
            tbDesconto.UseVisualStyleBackColor = true;
            // 
            // gbDesconto
            // 
            gbDesconto.Controls.Add(label1);
            gbDesconto.Controls.Add(txtValorTotalDesconto);
            gbDesconto.Controls.Add(lblDescontoPercentual);
            gbDesconto.Controls.Add(txtValorDescontoPercentual);
            gbDesconto.Controls.Add(lblDesconto);
            gbDesconto.Controls.Add(txtValorDesconto);
            gbDesconto.Dock = DockStyle.Fill;
            gbDesconto.Font = new Font("Arial", 9F, FontStyle.Bold);
            gbDesconto.ForeColor = Color.FromArgb(80, 80, 80);
            gbDesconto.Location = new Point(3, 3);
            gbDesconto.Name = "gbDesconto";
            gbDesconto.Size = new Size(285, 205);
            gbDesconto.TabIndex = 4;
            gbDesconto.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 99);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 34;
            label1.Text = "Valor total";
            // 
            // txtValorTotalDesconto
            // 
            txtValorTotalDesconto.Enabled = false;
            txtValorTotalDesconto.ForeColor = Color.Black;
            txtValorTotalDesconto.Location = new Point(52, 117);
            txtValorTotalDesconto.Name = "txtValorTotalDesconto";
            txtValorTotalDesconto.Size = new Size(74, 21);
            txtValorTotalDesconto.TabIndex = 33;
            txtValorTotalDesconto.Tag = "valor2";
            txtValorTotalDesconto.Text = "0,00";
            txtValorTotalDesconto.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDescontoPercentual
            // 
            lblDescontoPercentual.AutoSize = true;
            lblDescontoPercentual.Location = new Point(147, 33);
            lblDescontoPercentual.Name = "lblDescontoPercentual";
            lblDescontoPercentual.Size = new Size(38, 15);
            lblDescontoPercentual.TabIndex = 32;
            lblDescontoPercentual.Text = "% | F8";
            // 
            // txtValorDescontoPercentual
            // 
            txtValorDescontoPercentual.ForeColor = Color.Black;
            txtValorDescontoPercentual.Location = new Point(147, 51);
            txtValorDescontoPercentual.Name = "txtValorDescontoPercentual";
            txtValorDescontoPercentual.Size = new Size(74, 21);
            txtValorDescontoPercentual.TabIndex = 31;
            txtValorDescontoPercentual.Tag = "valor2";
            txtValorDescontoPercentual.Text = "0,00";
            txtValorDescontoPercentual.TextAlign = HorizontalAlignment.Right;
            // 
            // lblDesconto
            // 
            lblDesconto.AutoSize = true;
            lblDesconto.Location = new Point(52, 33);
            lblDesconto.Name = "lblDesconto";
            lblDesconto.Size = new Size(44, 15);
            lblDesconto.TabIndex = 30;
            lblDesconto.Text = "R$ | F7";
            // 
            // txtValorDesconto
            // 
            txtValorDesconto.ForeColor = Color.Black;
            txtValorDesconto.Location = new Point(52, 51);
            txtValorDesconto.Name = "txtValorDesconto";
            txtValorDesconto.Size = new Size(74, 21);
            txtValorDesconto.TabIndex = 29;
            txtValorDesconto.Tag = "valor2";
            txtValorDesconto.Text = "0,00";
            txtValorDesconto.TextAlign = HorizontalAlignment.Right;
            // 
            // tbAcrescimo
            // 
            tbAcrescimo.Controls.Add(groupBox1);
            tbAcrescimo.Location = new Point(4, 5);
            tbAcrescimo.Name = "tbAcrescimo";
            tbAcrescimo.Padding = new Padding(3);
            tbAcrescimo.Size = new Size(291, 211);
            tbAcrescimo.TabIndex = 1;
            tbAcrescimo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtValorTotalAcrescimo);
            groupBox1.Controls.Add(lblAcrescimoPercentual);
            groupBox1.Controls.Add(txtValorAcrescimoPercentual);
            groupBox1.Controls.Add(lblAcrescimo);
            groupBox1.Controls.Add(txtValorAcrescimo);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Arial", 9F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(80, 80, 80);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(285, 205);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 99);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 36;
            label2.Text = "Valor total";
            // 
            // txtValorTotalAcrescimo
            // 
            txtValorTotalAcrescimo.Enabled = false;
            txtValorTotalAcrescimo.ForeColor = Color.Black;
            txtValorTotalAcrescimo.Location = new Point(52, 117);
            txtValorTotalAcrescimo.Name = "txtValorTotalAcrescimo";
            txtValorTotalAcrescimo.Size = new Size(74, 21);
            txtValorTotalAcrescimo.TabIndex = 35;
            txtValorTotalAcrescimo.Tag = "valor2";
            txtValorTotalAcrescimo.Text = "0,00";
            txtValorTotalAcrescimo.TextAlign = HorizontalAlignment.Right;
            // 
            // lblAcrescimoPercentual
            // 
            lblAcrescimoPercentual.AutoSize = true;
            lblAcrescimoPercentual.Location = new Point(147, 33);
            lblAcrescimoPercentual.Name = "lblAcrescimoPercentual";
            lblAcrescimoPercentual.Size = new Size(38, 15);
            lblAcrescimoPercentual.TabIndex = 32;
            lblAcrescimoPercentual.Text = "% | F8";
            // 
            // txtValorAcrescimoPercentual
            // 
            txtValorAcrescimoPercentual.ForeColor = Color.Black;
            txtValorAcrescimoPercentual.Location = new Point(147, 51);
            txtValorAcrescimoPercentual.Name = "txtValorAcrescimoPercentual";
            txtValorAcrescimoPercentual.Size = new Size(74, 21);
            txtValorAcrescimoPercentual.TabIndex = 31;
            txtValorAcrescimoPercentual.Tag = "valor2";
            txtValorAcrescimoPercentual.Text = "0,00";
            txtValorAcrescimoPercentual.TextAlign = HorizontalAlignment.Right;
            // 
            // lblAcrescimo
            // 
            lblAcrescimo.AutoSize = true;
            lblAcrescimo.Location = new Point(52, 33);
            lblAcrescimo.Name = "lblAcrescimo";
            lblAcrescimo.Size = new Size(44, 15);
            lblAcrescimo.TabIndex = 30;
            lblAcrescimo.Text = "R$ | F7";
            // 
            // txtValorAcrescimo
            // 
            txtValorAcrescimo.ForeColor = Color.Black;
            txtValorAcrescimo.Location = new Point(52, 51);
            txtValorAcrescimo.Name = "txtValorAcrescimo";
            txtValorAcrescimo.Size = new Size(74, 21);
            txtValorAcrescimo.TabIndex = 29;
            txtValorAcrescimo.Tag = "valor2";
            txtValorAcrescimo.Text = "0,00";
            txtValorAcrescimo.TextAlign = HorizontalAlignment.Right;
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
            btnConfirmar.Location = new Point(182, 3);
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
            btnCancelar.Click += btnCancelar_Click;
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
            tableLayoutRodape.Location = new Point(0, 220);
            tableLayoutRodape.Margin = new Padding(10);
            tableLayoutRodape.Name = "tableLayoutRodape";
            tableLayoutRodape.RowCount = 1;
            tableLayoutRodape.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutRodape.Size = new Size(299, 45);
            tableLayoutRodape.TabIndex = 7;
            // 
            // DescontoAcrescimoItemForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 265);
            Controls.Add(pnlConteudo);
            Controls.Add(tableLayoutRodape);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DescontoAcrescimoItemForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alteração de valores do item";
            Load += DescontoAcrescimoItemForm_Load;
            Shown += DescontoAcrescimoItemForm_Shown;
            KeyDown += DescontoAcrescimoItemForm_KeyDown;
            pnlConteudo.ResumeLayout(false);
            tbGeral.ResumeLayout(false);
            tbDesconto.ResumeLayout(false);
            gbDesconto.ResumeLayout(false);
            gbDesconto.PerformLayout();
            tbAcrescimo.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutRodape.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlConteudo;
        private Button btnConfirmar;
        private Button btnCancelar;
        private ToolTip toolTipHint;
        private TableLayoutPanel tableLayoutRodape;
        private TabControl tbGeral;
        private TabPage tbDesconto;
        private GroupBox gbDesconto;
        private Label lblDescontoPercentual;
        private TextBox txtValorDescontoPercentual;
        private Label lblDesconto;
        private TextBox txtValorDesconto;
        private TabPage tbAcrescimo;
        private GroupBox groupBox1;
        private Label lblAcrescimoPercentual;
        private TextBox txtValorAcrescimoPercentual;
        private Label lblAcrescimo;
        private TextBox txtValorAcrescimo;
        private Label label1;
        private TextBox txtValorTotalDesconto;
        private Label label2;
        private TextBox txtValorTotalAcrescimo;
    }
}