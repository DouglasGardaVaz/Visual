namespace Dados.View.PessoaCadastroFormulario
{
    partial class PessoaCadastroForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlConteudo = new Panel();
            tbControlModulos = new TabControl();
            tbCadastro = new TabPage();
            cmbTipoPessoa = new ComboBox();
            pnlCadastroJuridica = new Panel();
            label13 = new Label();
            mskCNPJ = new MaskedTextBox();
            label17 = new Label();
            txtFantasia = new TextBox();
            label18 = new Label();
            txtRazaoSocial = new TextBox();
            ckAtivoJuridica = new CheckBox();
            pnlCadastroFisica = new Panel();
            label10 = new Label();
            mskCPF = new MaskedTextBox();
            ckAtivoFisica = new CheckBox();
            label8 = new Label();
            cmbEstadoCivil = new ComboBox();
            label7 = new Label();
            cmbSexo = new ComboBox();
            label6 = new Label();
            dtDataNascimento = new DateTimePicker();
            label1 = new Label();
            txtNomeCompleto = new TextBox();
            tbDocumento = new TabPage();
            pnlDocumento = new Panel();
            gridDocumento = new DataGridView();
            tbLayoutDocumentoOperacoes = new TableLayoutPanel();
            btnAdicionarDocumento = new Button();
            btnAlterarDocumento = new Button();
            btnExcluirDocumento = new Button();
            tbContato = new TabPage();
            pnlContato = new Panel();
            gridContato = new DataGridView();
            tbLayoutContatoOperacoes = new TableLayoutPanel();
            btnAdicionarContato = new Button();
            btnAlterarContato = new Button();
            btnExcluirContato = new Button();
            tbEndereco = new TabPage();
            pnlEndereco = new Panel();
            gridEndereco = new DataGridView();
            tbLayoutEnderecoOperacoes = new TableLayoutPanel();
            btnAdicionarEndereco = new Button();
            btnAlterarEndereco = new Button();
            btnExcluirEndereco = new Button();
            tbAdicional = new TabPage();
            pnlAdicionalFisica = new Panel();
            label12 = new Label();
            label11 = new Label();
            txtObservacoes = new TextBox();
            lblFiliacao = new Label();
            label9 = new Label();
            txtRendaMensal = new TextBox();
            label4 = new Label();
            txtProfissao = new TextBox();
            label5 = new Label();
            txtLocalTrabalho = new TextBox();
            label3 = new Label();
            txtNomePai = new TextBox();
            label2 = new Label();
            txtNomeMae = new TextBox();
            tbLayoutSelecaoModulos = new TableLayoutPanel();
            btnAdicional = new Button();
            btnEndereco = new Button();
            btnContato = new Button();
            btnDocumento = new Button();
            btnCadastro = new Button();
            btnGravar = new Button();
            tbLayoutAcoes = new TableLayoutPanel();
            btnCancelar = new Button();
            pnlRodape = new Panel();
            lblDescricao = new Label();
            tbLayoutCabecalho = new TableLayoutPanel();
            pnlCabecalho = new Panel();
            pnlConteudo.SuspendLayout();
            tbControlModulos.SuspendLayout();
            tbCadastro.SuspendLayout();
            pnlCadastroJuridica.SuspendLayout();
            pnlCadastroFisica.SuspendLayout();
            tbDocumento.SuspendLayout();
            pnlDocumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDocumento).BeginInit();
            tbLayoutDocumentoOperacoes.SuspendLayout();
            tbContato.SuspendLayout();
            pnlContato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridContato).BeginInit();
            tbLayoutContatoOperacoes.SuspendLayout();
            tbEndereco.SuspendLayout();
            pnlEndereco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridEndereco).BeginInit();
            tbLayoutEnderecoOperacoes.SuspendLayout();
            tbAdicional.SuspendLayout();
            pnlAdicionalFisica.SuspendLayout();
            tbLayoutSelecaoModulos.SuspendLayout();
            tbLayoutAcoes.SuspendLayout();
            pnlRodape.SuspendLayout();
            tbLayoutCabecalho.SuspendLayout();
            pnlCabecalho.SuspendLayout();
            SuspendLayout();
            // 
            // pnlConteudo
            // 
            pnlConteudo.BackColor = Color.White;
            pnlConteudo.Controls.Add(tbControlModulos);
            pnlConteudo.Controls.Add(tbLayoutSelecaoModulos);
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Location = new Point(0, 32);
            pnlConteudo.Name = "pnlConteudo";
            pnlConteudo.Size = new Size(739, 378);
            pnlConteudo.TabIndex = 8;
            // 
            // tbControlModulos
            // 
            tbControlModulos.Controls.Add(tbCadastro);
            tbControlModulos.Controls.Add(tbDocumento);
            tbControlModulos.Controls.Add(tbContato);
            tbControlModulos.Controls.Add(tbEndereco);
            tbControlModulos.Controls.Add(tbAdicional);
            tbControlModulos.Dock = DockStyle.Fill;
            tbControlModulos.ItemSize = new Size(1, 1);
            tbControlModulos.Location = new Point(0, 0);
            tbControlModulos.Margin = new Padding(0);
            tbControlModulos.Name = "tbControlModulos";
            tbControlModulos.Padding = new Point(3, 3);
            tbControlModulos.SelectedIndex = 0;
            tbControlModulos.Size = new Size(739, 327);
            tbControlModulos.TabIndex = 1;
            // 
            // tbCadastro
            // 
            tbCadastro.Controls.Add(cmbTipoPessoa);
            tbCadastro.Controls.Add(pnlCadastroJuridica);
            tbCadastro.Controls.Add(pnlCadastroFisica);
            tbCadastro.Location = new Point(4, 5);
            tbCadastro.Name = "tbCadastro";
            tbCadastro.Padding = new Padding(3);
            tbCadastro.Size = new Size(731, 318);
            tbCadastro.TabIndex = 0;
            tbCadastro.UseVisualStyleBackColor = true;
            // 
            // cmbTipoPessoa
            // 
            cmbTipoPessoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoPessoa.FormattingEnabled = true;
            cmbTipoPessoa.Location = new Point(8, 6);
            cmbTipoPessoa.Name = "cmbTipoPessoa";
            cmbTipoPessoa.Size = new Size(170, 23);
            cmbTipoPessoa.TabIndex = 1;
            cmbTipoPessoa.SelectedIndexChanged += cmbTipoPessoa_SelectedIndexChanged;
            // 
            // pnlCadastroJuridica
            // 
            pnlCadastroJuridica.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCadastroJuridica.Controls.Add(label13);
            pnlCadastroJuridica.Controls.Add(mskCNPJ);
            pnlCadastroJuridica.Controls.Add(label17);
            pnlCadastroJuridica.Controls.Add(txtFantasia);
            pnlCadastroJuridica.Controls.Add(label18);
            pnlCadastroJuridica.Controls.Add(txtRazaoSocial);
            pnlCadastroJuridica.Controls.Add(ckAtivoJuridica);
            pnlCadastroJuridica.Location = new Point(3, 35);
            pnlCadastroJuridica.Name = "pnlCadastroJuridica";
            pnlCadastroJuridica.Size = new Size(722, 289);
            pnlCadastroJuridica.TabIndex = 19;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 9F);
            label13.Location = new Point(20, 128);
            label13.Name = "label13";
            label13.Size = new Size(39, 15);
            label13.TabIndex = 22;
            label13.Text = "CNPJ";
            // 
            // mskCNPJ
            // 
            mskCNPJ.Font = new Font("Arial", 11F);
            mskCNPJ.Location = new Point(20, 147);
            mskCNPJ.Mask = "00.000.000/0000-00";
            mskCNPJ.Name = "mskCNPJ";
            mskCNPJ.Size = new Size(143, 24);
            mskCNPJ.TabIndex = 2;
            mskCNPJ.Tag = "CNPJ";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 9F);
            label17.Location = new Point(20, 75);
            label17.Name = "label17";
            label17.Size = new Size(55, 15);
            label17.TabIndex = 8;
            label17.Text = "Fantasia";
            // 
            // txtFantasia
            // 
            txtFantasia.Font = new Font("Arial", 11F);
            txtFantasia.Location = new Point(20, 95);
            txtFantasia.MaxLength = 150;
            txtFantasia.Name = "txtFantasia";
            txtFantasia.Size = new Size(423, 24);
            txtFantasia.TabIndex = 1;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Arial", 9F);
            label18.Location = new Point(20, 21);
            label18.Name = "label18";
            label18.Size = new Size(78, 15);
            label18.TabIndex = 6;
            label18.Text = "Razão social";
            // 
            // txtRazaoSocial
            // 
            txtRazaoSocial.Font = new Font("Arial", 11F);
            txtRazaoSocial.Location = new Point(20, 43);
            txtRazaoSocial.MaxLength = 150;
            txtRazaoSocial.Name = "txtRazaoSocial";
            txtRazaoSocial.Size = new Size(423, 24);
            txtRazaoSocial.TabIndex = 0;
            // 
            // ckAtivoJuridica
            // 
            ckAtivoJuridica.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckAtivoJuridica.AutoSize = true;
            ckAtivoJuridica.Font = new Font("Arial", 11F);
            ckAtivoJuridica.Location = new Point(658, 7);
            ckAtivoJuridica.Name = "ckAtivoJuridica";
            ckAtivoJuridica.Size = new Size(58, 21);
            ckAtivoJuridica.TabIndex = 4;
            ckAtivoJuridica.Text = "Ativo";
            ckAtivoJuridica.UseVisualStyleBackColor = true;
            // 
            // pnlCadastroFisica
            // 
            pnlCadastroFisica.Controls.Add(label10);
            pnlCadastroFisica.Controls.Add(mskCPF);
            pnlCadastroFisica.Controls.Add(ckAtivoFisica);
            pnlCadastroFisica.Controls.Add(label8);
            pnlCadastroFisica.Controls.Add(cmbEstadoCivil);
            pnlCadastroFisica.Controls.Add(label7);
            pnlCadastroFisica.Controls.Add(cmbSexo);
            pnlCadastroFisica.Controls.Add(label6);
            pnlCadastroFisica.Controls.Add(dtDataNascimento);
            pnlCadastroFisica.Controls.Add(label1);
            pnlCadastroFisica.Controls.Add(txtNomeCompleto);
            pnlCadastroFisica.Location = new Point(3, 35);
            pnlCadastroFisica.Name = "pnlCadastroFisica";
            pnlCadastroFisica.Size = new Size(722, 289);
            pnlCadastroFisica.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 9F);
            label10.Location = new Point(20, 75);
            label10.Name = "label10";
            label10.Size = new Size(31, 15);
            label10.TabIndex = 20;
            label10.Text = "CPF";
            // 
            // mskCPF
            // 
            mskCPF.Font = new Font("Arial", 11F);
            mskCPF.Location = new Point(20, 94);
            mskCPF.Mask = "000.000.000-00";
            mskCPF.Name = "mskCPF";
            mskCPF.Size = new Size(118, 24);
            mskCPF.TabIndex = 1;
            mskCPF.Tag = "CPF";
            mskCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            // 
            // ckAtivoFisica
            // 
            ckAtivoFisica.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckAtivoFisica.AutoSize = true;
            ckAtivoFisica.Font = new Font("Arial", 11F);
            ckAtivoFisica.Location = new Point(658, 7);
            ckAtivoFisica.Name = "ckAtivoFisica";
            ckAtivoFisica.Size = new Size(58, 21);
            ckAtivoFisica.TabIndex = 18;
            ckAtivoFisica.Text = "Ativo";
            ckAtivoFisica.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9F);
            label8.Location = new Point(176, 172);
            label8.Name = "label8";
            label8.Size = new Size(69, 15);
            label8.TabIndex = 15;
            label8.Text = "Estado civil";
            // 
            // cmbEstadoCivil
            // 
            cmbEstadoCivil.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoCivil.FlatStyle = FlatStyle.Flat;
            cmbEstadoCivil.FormattingEnabled = true;
            cmbEstadoCivil.Location = new Point(176, 191);
            cmbEstadoCivil.Name = "cmbEstadoCivil";
            cmbEstadoCivil.Size = new Size(152, 23);
            cmbEstadoCivil.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9F);
            label7.Location = new Point(20, 172);
            label7.Name = "label7";
            label7.Size = new Size(34, 15);
            label7.TabIndex = 13;
            label7.Text = "Sexo";
            // 
            // cmbSexo
            // 
            cmbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSexo.FlatStyle = FlatStyle.Flat;
            cmbSexo.FormattingEnabled = true;
            cmbSexo.Location = new Point(20, 191);
            cmbSexo.Name = "cmbSexo";
            cmbSexo.Size = new Size(143, 23);
            cmbSexo.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9F);
            label6.Location = new Point(20, 124);
            label6.Name = "label6";
            label6.Size = new Size(118, 15);
            label6.TabIndex = 11;
            label6.Text = "Data de nascimento";
            // 
            // dtDataNascimento
            // 
            dtDataNascimento.Format = DateTimePickerFormat.Short;
            dtDataNascimento.Location = new Point(20, 145);
            dtDataNascimento.Name = "dtDataNascimento";
            dtDataNascimento.Size = new Size(133, 21);
            dtDataNascimento.TabIndex = 2;
            dtDataNascimento.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F);
            label1.Location = new Point(20, 21);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome completo";
            // 
            // txtNomeCompleto
            // 
            txtNomeCompleto.Font = new Font("Arial", 11F);
            txtNomeCompleto.Location = new Point(20, 42);
            txtNomeCompleto.MaxLength = 150;
            txtNomeCompleto.Name = "txtNomeCompleto";
            txtNomeCompleto.Size = new Size(423, 24);
            txtNomeCompleto.TabIndex = 0;
            // 
            // tbDocumento
            // 
            tbDocumento.Controls.Add(pnlDocumento);
            tbDocumento.Location = new Point(4, 5);
            tbDocumento.Name = "tbDocumento";
            tbDocumento.Padding = new Padding(3);
            tbDocumento.Size = new Size(731, 318);
            tbDocumento.TabIndex = 1;
            tbDocumento.UseVisualStyleBackColor = true;
            // 
            // pnlDocumento
            // 
            pnlDocumento.Controls.Add(gridDocumento);
            pnlDocumento.Controls.Add(tbLayoutDocumentoOperacoes);
            pnlDocumento.Dock = DockStyle.Fill;
            pnlDocumento.Location = new Point(3, 3);
            pnlDocumento.Name = "pnlDocumento";
            pnlDocumento.Size = new Size(725, 312);
            pnlDocumento.TabIndex = 0;
            // 
            // gridDocumento
            // 
            gridDocumento.BackgroundColor = Color.WhiteSmoke;
            gridDocumento.BorderStyle = BorderStyle.None;
            gridDocumento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridDocumento.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Arial", 11F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            gridDocumento.DefaultCellStyle = dataGridViewCellStyle1;
            gridDocumento.Dock = DockStyle.Fill;
            gridDocumento.EditMode = DataGridViewEditMode.EditOnEnter;
            gridDocumento.Location = new Point(0, 0);
            gridDocumento.Margin = new Padding(10);
            gridDocumento.Name = "gridDocumento";
            gridDocumento.ReadOnly = true;
            gridDocumento.Size = new Size(725, 271);
            gridDocumento.TabIndex = 1;
            // 
            // tbLayoutDocumentoOperacoes
            // 
            tbLayoutDocumentoOperacoes.ColumnCount = 5;
            tbLayoutDocumentoOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutDocumentoOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutDocumentoOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutDocumentoOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutDocumentoOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutDocumentoOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbLayoutDocumentoOperacoes.Controls.Add(btnAdicionarDocumento, 3, 0);
            tbLayoutDocumentoOperacoes.Controls.Add(btnAlterarDocumento, 2, 0);
            tbLayoutDocumentoOperacoes.Controls.Add(btnExcluirDocumento, 1, 0);
            tbLayoutDocumentoOperacoes.Dock = DockStyle.Bottom;
            tbLayoutDocumentoOperacoes.Location = new Point(0, 271);
            tbLayoutDocumentoOperacoes.Margin = new Padding(10);
            tbLayoutDocumentoOperacoes.Name = "tbLayoutDocumentoOperacoes";
            tbLayoutDocumentoOperacoes.RowCount = 1;
            tbLayoutDocumentoOperacoes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutDocumentoOperacoes.Size = new Size(725, 41);
            tbLayoutDocumentoOperacoes.TabIndex = 0;
            // 
            // btnAdicionarDocumento
            // 
            btnAdicionarDocumento.Dock = DockStyle.Fill;
            btnAdicionarDocumento.FlatStyle = FlatStyle.Flat;
            btnAdicionarDocumento.Font = new Font("Arial", 10F);
            btnAdicionarDocumento.Location = new Point(423, 3);
            btnAdicionarDocumento.Name = "btnAdicionarDocumento";
            btnAdicionarDocumento.Size = new Size(110, 35);
            btnAdicionarDocumento.TabIndex = 0;
            btnAdicionarDocumento.Text = "Adicionar";
            btnAdicionarDocumento.UseVisualStyleBackColor = true;
            btnAdicionarDocumento.Click += btnAdicionar_Click;
            // 
            // btnAlterarDocumento
            // 
            btnAlterarDocumento.Dock = DockStyle.Fill;
            btnAlterarDocumento.FlatStyle = FlatStyle.Flat;
            btnAlterarDocumento.Font = new Font("Arial", 10F);
            btnAlterarDocumento.Location = new Point(307, 3);
            btnAlterarDocumento.Name = "btnAlterarDocumento";
            btnAlterarDocumento.Size = new Size(110, 35);
            btnAlterarDocumento.TabIndex = 1;
            btnAlterarDocumento.Text = "Alterar";
            btnAlterarDocumento.UseVisualStyleBackColor = true;
            btnAlterarDocumento.Click += btnAlterar_Click;
            // 
            // btnExcluirDocumento
            // 
            btnExcluirDocumento.Dock = DockStyle.Fill;
            btnExcluirDocumento.FlatStyle = FlatStyle.Flat;
            btnExcluirDocumento.Font = new Font("Arial", 10F);
            btnExcluirDocumento.Location = new Point(191, 3);
            btnExcluirDocumento.Name = "btnExcluirDocumento";
            btnExcluirDocumento.Size = new Size(110, 35);
            btnExcluirDocumento.TabIndex = 2;
            btnExcluirDocumento.Text = "Excluir";
            btnExcluirDocumento.UseVisualStyleBackColor = true;
            btnExcluirDocumento.Click += btnExcluir_Click;
            // 
            // tbContato
            // 
            tbContato.Controls.Add(pnlContato);
            tbContato.Location = new Point(4, 5);
            tbContato.Name = "tbContato";
            tbContato.Padding = new Padding(3);
            tbContato.Size = new Size(731, 318);
            tbContato.TabIndex = 2;
            tbContato.UseVisualStyleBackColor = true;
            // 
            // pnlContato
            // 
            pnlContato.Controls.Add(gridContato);
            pnlContato.Controls.Add(tbLayoutContatoOperacoes);
            pnlContato.Dock = DockStyle.Fill;
            pnlContato.Location = new Point(3, 3);
            pnlContato.Name = "pnlContato";
            pnlContato.Size = new Size(725, 312);
            pnlContato.TabIndex = 1;
            // 
            // gridContato
            // 
            gridContato.BackgroundColor = Color.WhiteSmoke;
            gridContato.BorderStyle = BorderStyle.None;
            gridContato.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridContato.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial", 11F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridContato.DefaultCellStyle = dataGridViewCellStyle2;
            gridContato.Dock = DockStyle.Fill;
            gridContato.EditMode = DataGridViewEditMode.EditOnEnter;
            gridContato.Location = new Point(0, 0);
            gridContato.Margin = new Padding(10);
            gridContato.Name = "gridContato";
            gridContato.ReadOnly = true;
            gridContato.Size = new Size(725, 271);
            gridContato.TabIndex = 1;
            // 
            // tbLayoutContatoOperacoes
            // 
            tbLayoutContatoOperacoes.ColumnCount = 5;
            tbLayoutContatoOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutContatoOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutContatoOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutContatoOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutContatoOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutContatoOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbLayoutContatoOperacoes.Controls.Add(btnAdicionarContato, 3, 0);
            tbLayoutContatoOperacoes.Controls.Add(btnAlterarContato, 2, 0);
            tbLayoutContatoOperacoes.Controls.Add(btnExcluirContato, 1, 0);
            tbLayoutContatoOperacoes.Dock = DockStyle.Bottom;
            tbLayoutContatoOperacoes.Location = new Point(0, 271);
            tbLayoutContatoOperacoes.Margin = new Padding(10);
            tbLayoutContatoOperacoes.Name = "tbLayoutContatoOperacoes";
            tbLayoutContatoOperacoes.RowCount = 1;
            tbLayoutContatoOperacoes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutContatoOperacoes.Size = new Size(725, 41);
            tbLayoutContatoOperacoes.TabIndex = 0;
            // 
            // btnAdicionarContato
            // 
            btnAdicionarContato.Dock = DockStyle.Fill;
            btnAdicionarContato.FlatStyle = FlatStyle.Flat;
            btnAdicionarContato.Font = new Font("Arial", 10F);
            btnAdicionarContato.Location = new Point(423, 3);
            btnAdicionarContato.Name = "btnAdicionarContato";
            btnAdicionarContato.Size = new Size(110, 35);
            btnAdicionarContato.TabIndex = 0;
            btnAdicionarContato.Text = "Adicionar";
            btnAdicionarContato.UseVisualStyleBackColor = true;
            btnAdicionarContato.Click += btnAdicionarContato_Click;
            // 
            // btnAlterarContato
            // 
            btnAlterarContato.Dock = DockStyle.Fill;
            btnAlterarContato.FlatStyle = FlatStyle.Flat;
            btnAlterarContato.Font = new Font("Arial", 10F);
            btnAlterarContato.Location = new Point(307, 3);
            btnAlterarContato.Name = "btnAlterarContato";
            btnAlterarContato.Size = new Size(110, 35);
            btnAlterarContato.TabIndex = 1;
            btnAlterarContato.Text = "Alterar";
            btnAlterarContato.UseVisualStyleBackColor = true;
            btnAlterarContato.Click += btnAlterarContato_Click;
            // 
            // btnExcluirContato
            // 
            btnExcluirContato.Dock = DockStyle.Fill;
            btnExcluirContato.FlatStyle = FlatStyle.Flat;
            btnExcluirContato.Font = new Font("Arial", 10F);
            btnExcluirContato.Location = new Point(191, 3);
            btnExcluirContato.Name = "btnExcluirContato";
            btnExcluirContato.Size = new Size(110, 35);
            btnExcluirContato.TabIndex = 2;
            btnExcluirContato.Text = "Excluir";
            btnExcluirContato.UseVisualStyleBackColor = true;
            btnExcluirContato.Click += btnExcluirContato_Click;
            // 
            // tbEndereco
            // 
            tbEndereco.Controls.Add(pnlEndereco);
            tbEndereco.Location = new Point(4, 5);
            tbEndereco.Name = "tbEndereco";
            tbEndereco.Padding = new Padding(3);
            tbEndereco.Size = new Size(731, 318);
            tbEndereco.TabIndex = 3;
            tbEndereco.UseVisualStyleBackColor = true;
            // 
            // pnlEndereco
            // 
            pnlEndereco.Controls.Add(gridEndereco);
            pnlEndereco.Controls.Add(tbLayoutEnderecoOperacoes);
            pnlEndereco.Dock = DockStyle.Fill;
            pnlEndereco.Location = new Point(3, 3);
            pnlEndereco.Name = "pnlEndereco";
            pnlEndereco.Size = new Size(725, 312);
            pnlEndereco.TabIndex = 2;
            // 
            // gridEndereco
            // 
            gridEndereco.BackgroundColor = Color.WhiteSmoke;
            gridEndereco.BorderStyle = BorderStyle.None;
            gridEndereco.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridEndereco.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Arial", 11F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(60, 60, 60);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            gridEndereco.DefaultCellStyle = dataGridViewCellStyle3;
            gridEndereco.Dock = DockStyle.Fill;
            gridEndereco.EditMode = DataGridViewEditMode.EditOnEnter;
            gridEndereco.Location = new Point(0, 0);
            gridEndereco.Margin = new Padding(10);
            gridEndereco.Name = "gridEndereco";
            gridEndereco.ReadOnly = true;
            gridEndereco.Size = new Size(725, 271);
            gridEndereco.TabIndex = 1;
            // 
            // tbLayoutEnderecoOperacoes
            // 
            tbLayoutEnderecoOperacoes.ColumnCount = 5;
            tbLayoutEnderecoOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutEnderecoOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutEnderecoOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutEnderecoOperacoes.ColumnStyles.Add(new ColumnStyle());
            tbLayoutEnderecoOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbLayoutEnderecoOperacoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbLayoutEnderecoOperacoes.Controls.Add(btnAdicionarEndereco, 3, 0);
            tbLayoutEnderecoOperacoes.Controls.Add(btnAlterarEndereco, 2, 0);
            tbLayoutEnderecoOperacoes.Controls.Add(btnExcluirEndereco, 1, 0);
            tbLayoutEnderecoOperacoes.Dock = DockStyle.Bottom;
            tbLayoutEnderecoOperacoes.Location = new Point(0, 271);
            tbLayoutEnderecoOperacoes.Margin = new Padding(10);
            tbLayoutEnderecoOperacoes.Name = "tbLayoutEnderecoOperacoes";
            tbLayoutEnderecoOperacoes.RowCount = 1;
            tbLayoutEnderecoOperacoes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutEnderecoOperacoes.Size = new Size(725, 41);
            tbLayoutEnderecoOperacoes.TabIndex = 0;
            // 
            // btnAdicionarEndereco
            // 
            btnAdicionarEndereco.Dock = DockStyle.Fill;
            btnAdicionarEndereco.FlatStyle = FlatStyle.Flat;
            btnAdicionarEndereco.Font = new Font("Arial", 10F);
            btnAdicionarEndereco.Location = new Point(423, 3);
            btnAdicionarEndereco.Name = "btnAdicionarEndereco";
            btnAdicionarEndereco.Size = new Size(110, 35);
            btnAdicionarEndereco.TabIndex = 0;
            btnAdicionarEndereco.Text = "Adicionar";
            btnAdicionarEndereco.UseVisualStyleBackColor = true;
            btnAdicionarEndereco.Click += btnAdicionarEndereco_Click;
            // 
            // btnAlterarEndereco
            // 
            btnAlterarEndereco.Dock = DockStyle.Fill;
            btnAlterarEndereco.FlatStyle = FlatStyle.Flat;
            btnAlterarEndereco.Font = new Font("Arial", 10F);
            btnAlterarEndereco.Location = new Point(307, 3);
            btnAlterarEndereco.Name = "btnAlterarEndereco";
            btnAlterarEndereco.Size = new Size(110, 35);
            btnAlterarEndereco.TabIndex = 1;
            btnAlterarEndereco.Text = "Alterar";
            btnAlterarEndereco.UseVisualStyleBackColor = true;
            btnAlterarEndereco.Click += btnAlterarEndereco_Click;
            // 
            // btnExcluirEndereco
            // 
            btnExcluirEndereco.Dock = DockStyle.Fill;
            btnExcluirEndereco.FlatStyle = FlatStyle.Flat;
            btnExcluirEndereco.Font = new Font("Arial", 10F);
            btnExcluirEndereco.Location = new Point(191, 3);
            btnExcluirEndereco.Name = "btnExcluirEndereco";
            btnExcluirEndereco.Size = new Size(110, 35);
            btnExcluirEndereco.TabIndex = 2;
            btnExcluirEndereco.Text = "Excluir";
            btnExcluirEndereco.UseVisualStyleBackColor = true;
            btnExcluirEndereco.Click += btnExcluirEndereco_Click;
            // 
            // tbAdicional
            // 
            tbAdicional.Controls.Add(pnlAdicionalFisica);
            tbAdicional.Location = new Point(4, 5);
            tbAdicional.Name = "tbAdicional";
            tbAdicional.Size = new Size(731, 318);
            tbAdicional.TabIndex = 4;
            tbAdicional.UseVisualStyleBackColor = true;
            // 
            // pnlAdicionalFisica
            // 
            pnlAdicionalFisica.Controls.Add(label12);
            pnlAdicionalFisica.Controls.Add(label11);
            pnlAdicionalFisica.Controls.Add(txtObservacoes);
            pnlAdicionalFisica.Controls.Add(lblFiliacao);
            pnlAdicionalFisica.Controls.Add(label9);
            pnlAdicionalFisica.Controls.Add(txtRendaMensal);
            pnlAdicionalFisica.Controls.Add(label4);
            pnlAdicionalFisica.Controls.Add(txtProfissao);
            pnlAdicionalFisica.Controls.Add(label5);
            pnlAdicionalFisica.Controls.Add(txtLocalTrabalho);
            pnlAdicionalFisica.Controls.Add(label3);
            pnlAdicionalFisica.Controls.Add(txtNomePai);
            pnlAdicionalFisica.Controls.Add(label2);
            pnlAdicionalFisica.Controls.Add(txtNomeMae);
            pnlAdicionalFisica.Dock = DockStyle.Fill;
            pnlAdicionalFisica.Location = new Point(0, 0);
            pnlAdicionalFisica.Name = "pnlAdicionalFisica";
            pnlAdicionalFisica.Size = new Size(731, 318);
            pnlAdicionalFisica.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 9F, FontStyle.Bold);
            label12.Location = new Point(4, 9);
            label12.Name = "label12";
            label12.Size = new Size(62, 15);
            label12.TabIndex = 31;
            label12.Text = "Adicional:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 9F, FontStyle.Bold);
            label11.Location = new Point(3, 185);
            label11.Name = "label11";
            label11.Size = new Size(86, 15);
            label11.TabIndex = 30;
            label11.Text = "Observações:";
            // 
            // txtObservacoes
            // 
            txtObservacoes.Font = new Font("Arial", 11F);
            txtObservacoes.Location = new Point(17, 206);
            txtObservacoes.Multiline = true;
            txtObservacoes.Name = "txtObservacoes";
            txtObservacoes.Size = new Size(330, 104);
            txtObservacoes.TabIndex = 29;
            // 
            // lblFiliacao
            // 
            lblFiliacao.AutoSize = true;
            lblFiliacao.Font = new Font("Arial", 9F, FontStyle.Bold);
            lblFiliacao.Location = new Point(4, 122);
            lblFiliacao.Name = "lblFiliacao";
            lblFiliacao.Size = new Size(53, 15);
            lblFiliacao.TabIndex = 28;
            lblFiliacao.Text = "Filiação:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9F);
            label9.Location = new Point(266, 76);
            label9.Name = "label9";
            label9.Size = new Size(47, 15);
            label9.TabIndex = 27;
            label9.Tag = "";
            label9.Text = "Renda ";
            // 
            // txtRendaMensal
            // 
            txtRendaMensal.Font = new Font("Arial", 11F);
            txtRendaMensal.Location = new Point(266, 95);
            txtRendaMensal.MaxLength = 150;
            txtRendaMensal.Name = "txtRendaMensal";
            txtRendaMensal.Size = new Size(82, 24);
            txtRendaMensal.TabIndex = 26;
            txtRendaMensal.Tag = "valor2";
            txtRendaMensal.Text = "0,00";
            txtRendaMensal.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9F);
            label4.Location = new Point(17, 28);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 25;
            label4.Text = "Profissão";
            // 
            // txtProfissao
            // 
            txtProfissao.Font = new Font("Arial", 11F);
            txtProfissao.Location = new Point(17, 48);
            txtProfissao.MaxLength = 150;
            txtProfissao.Name = "txtProfissao";
            txtProfissao.Size = new Size(330, 24);
            txtProfissao.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9F);
            label5.Location = new Point(17, 75);
            label5.Name = "label5";
            label5.Size = new Size(102, 15);
            label5.TabIndex = 23;
            label5.Tag = "";
            label5.Text = "Local de trabalho";
            // 
            // txtLocalTrabalho
            // 
            txtLocalTrabalho.Font = new Font("Arial", 11F);
            txtLocalTrabalho.Location = new Point(17, 95);
            txtLocalTrabalho.MaxLength = 150;
            txtLocalTrabalho.Name = "txtLocalTrabalho";
            txtLocalTrabalho.Size = new Size(243, 24);
            txtLocalTrabalho.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F);
            label3.Location = new Point(17, 140);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 21;
            label3.Text = "Nome do pai";
            // 
            // txtNomePai
            // 
            txtNomePai.Font = new Font("Arial", 11F);
            txtNomePai.Location = new Point(17, 158);
            txtNomePai.MaxLength = 150;
            txtNomePai.Name = "txtNomePai";
            txtNomePai.Size = new Size(162, 24);
            txtNomePai.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F);
            label2.Location = new Point(185, 140);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 19;
            label2.Text = "Nome da mãe";
            // 
            // txtNomeMae
            // 
            txtNomeMae.Font = new Font("Arial", 11F);
            txtNomeMae.Location = new Point(185, 159);
            txtNomeMae.MaxLength = 150;
            txtNomeMae.Name = "txtNomeMae";
            txtNomeMae.Size = new Size(162, 24);
            txtNomeMae.TabIndex = 18;
            // 
            // tbLayoutSelecaoModulos
            // 
            tbLayoutSelecaoModulos.ColumnCount = 5;
            tbLayoutSelecaoModulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayoutSelecaoModulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayoutSelecaoModulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayoutSelecaoModulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayoutSelecaoModulos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayoutSelecaoModulos.Controls.Add(btnAdicional, 4, 0);
            tbLayoutSelecaoModulos.Controls.Add(btnEndereco, 2, 0);
            tbLayoutSelecaoModulos.Controls.Add(btnContato, 1, 0);
            tbLayoutSelecaoModulos.Controls.Add(btnDocumento, 3, 0);
            tbLayoutSelecaoModulos.Controls.Add(btnCadastro, 0, 0);
            tbLayoutSelecaoModulos.Dock = DockStyle.Bottom;
            tbLayoutSelecaoModulos.Location = new Point(0, 327);
            tbLayoutSelecaoModulos.Name = "tbLayoutSelecaoModulos";
            tbLayoutSelecaoModulos.RowCount = 1;
            tbLayoutSelecaoModulos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutSelecaoModulos.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tbLayoutSelecaoModulos.Size = new Size(739, 51);
            tbLayoutSelecaoModulos.TabIndex = 0;
            // 
            // btnAdicional
            // 
            btnAdicional.Dock = DockStyle.Fill;
            btnAdicional.FlatAppearance.BorderSize = 0;
            btnAdicional.FlatStyle = FlatStyle.Flat;
            btnAdicional.Font = new Font("Arial", 11F);
            btnAdicional.Location = new Point(591, 3);
            btnAdicional.Name = "btnAdicional";
            btnAdicional.Size = new Size(145, 45);
            btnAdicional.TabIndex = 4;
            btnAdicional.Text = "Adicional";
            btnAdicional.UseVisualStyleBackColor = true;
            btnAdicional.Click += btnAdicional_Click;
            // 
            // btnEndereco
            // 
            btnEndereco.Dock = DockStyle.Fill;
            btnEndereco.FlatAppearance.BorderSize = 0;
            btnEndereco.FlatStyle = FlatStyle.Flat;
            btnEndereco.Font = new Font("Arial", 11F);
            btnEndereco.Location = new Point(297, 3);
            btnEndereco.Name = "btnEndereco";
            btnEndereco.Size = new Size(141, 45);
            btnEndereco.TabIndex = 3;
            btnEndereco.Text = "Endereço";
            btnEndereco.UseVisualStyleBackColor = true;
            btnEndereco.Click += btnEndereco_Click;
            // 
            // btnContato
            // 
            btnContato.Dock = DockStyle.Fill;
            btnContato.FlatAppearance.BorderSize = 0;
            btnContato.FlatStyle = FlatStyle.Flat;
            btnContato.Font = new Font("Arial", 11F);
            btnContato.Location = new Point(150, 3);
            btnContato.Name = "btnContato";
            btnContato.Size = new Size(141, 45);
            btnContato.TabIndex = 2;
            btnContato.Text = "Contato";
            btnContato.UseVisualStyleBackColor = true;
            btnContato.Click += btnContato_Click;
            // 
            // btnDocumento
            // 
            btnDocumento.Dock = DockStyle.Fill;
            btnDocumento.FlatAppearance.BorderSize = 0;
            btnDocumento.FlatStyle = FlatStyle.Flat;
            btnDocumento.Font = new Font("Arial", 11F);
            btnDocumento.Location = new Point(444, 3);
            btnDocumento.Name = "btnDocumento";
            btnDocumento.Size = new Size(141, 45);
            btnDocumento.TabIndex = 1;
            btnDocumento.Text = "Documento";
            btnDocumento.UseVisualStyleBackColor = true;
            btnDocumento.Click += btnDocumento_Click;
            // 
            // btnCadastro
            // 
            btnCadastro.Dock = DockStyle.Fill;
            btnCadastro.FlatAppearance.BorderSize = 0;
            btnCadastro.FlatStyle = FlatStyle.Flat;
            btnCadastro.Font = new Font("Arial", 11F);
            btnCadastro.Location = new Point(3, 3);
            btnCadastro.Name = "btnCadastro";
            btnCadastro.Size = new Size(141, 45);
            btnCadastro.TabIndex = 0;
            btnCadastro.Text = "Cadastro";
            btnCadastro.UseVisualStyleBackColor = true;
            btnCadastro.Click += btnCadastro_Click;
            // 
            // btnGravar
            // 
            btnGravar.BackColor = Color.White;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Dock = DockStyle.Top;
            btnGravar.FlatAppearance.BorderColor = Color.Gray;
            btnGravar.FlatAppearance.BorderSize = 0;
            btnGravar.FlatAppearance.MouseDownBackColor = Color.Gray;
            btnGravar.FlatStyle = FlatStyle.Flat;
            btnGravar.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnGravar.ForeColor = Color.FromArgb(80, 80, 80);
            btnGravar.Location = new Point(601, 10);
            btnGravar.Margin = new Padding(3, 10, 3, 3);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(135, 35);
            btnGravar.TabIndex = 5;
            btnGravar.Text = "&Gravar - F6";
            btnGravar.UseVisualStyleBackColor = false;
            btnGravar.Click += btnGravar_Click;
            // 
            // tbLayoutAcoes
            // 
            tbLayoutAcoes.ColumnCount = 5;
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333359F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tbLayoutAcoes.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tbLayoutAcoes.Controls.Add(btnGravar, 5, 0);
            tbLayoutAcoes.Controls.Add(btnCancelar, 0, 0);
            tbLayoutAcoes.Dock = DockStyle.Bottom;
            tbLayoutAcoes.Location = new Point(0, 4);
            tbLayoutAcoes.Margin = new Padding(3, 10, 3, 3);
            tbLayoutAcoes.Name = "tbLayoutAcoes";
            tbLayoutAcoes.RowCount = 1;
            tbLayoutAcoes.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tbLayoutAcoes.Size = new Size(739, 58);
            tbLayoutAcoes.TabIndex = 7;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Dock = DockStyle.Top;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.FromArgb(80, 80, 80);
            btnCancelar.Location = new Point(3, 10);
            btnCancelar.Margin = new Padding(3, 10, 3, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(134, 35);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "&Cancelar - F4";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlRodape
            // 
            pnlRodape.Controls.Add(tbLayoutAcoes);
            pnlRodape.Dock = DockStyle.Bottom;
            pnlRodape.Location = new Point(0, 410);
            pnlRodape.Name = "pnlRodape";
            pnlRodape.Size = new Size(739, 62);
            pnlRodape.TabIndex = 7;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Dock = DockStyle.Fill;
            lblDescricao.Font = new Font("Arial", 15F, FontStyle.Bold);
            lblDescricao.Location = new Point(150, 0);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(437, 32);
            lblDescricao.TabIndex = 0;
            lblDescricao.Text = "DOUGLAS GARDA VAZ";
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbLayoutCabecalho
            // 
            tbLayoutCabecalho.ColumnCount = 3;
            tbLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tbLayoutCabecalho.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayoutCabecalho.Controls.Add(lblDescricao, 1, 0);
            tbLayoutCabecalho.Dock = DockStyle.Fill;
            tbLayoutCabecalho.Location = new Point(0, 0);
            tbLayoutCabecalho.Name = "tbLayoutCabecalho";
            tbLayoutCabecalho.RowCount = 1;
            tbLayoutCabecalho.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tbLayoutCabecalho.Size = new Size(739, 32);
            tbLayoutCabecalho.TabIndex = 0;
            // 
            // pnlCabecalho
            // 
            pnlCabecalho.AllowDrop = true;
            pnlCabecalho.Controls.Add(tbLayoutCabecalho);
            pnlCabecalho.Dock = DockStyle.Top;
            pnlCabecalho.Location = new Point(0, 0);
            pnlCabecalho.Name = "pnlCabecalho";
            pnlCabecalho.Size = new Size(739, 32);
            pnlCabecalho.TabIndex = 6;
            // 
            // PessoaCadastroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(220, 225, 230);
            ClientSize = new Size(739, 472);
            Controls.Add(pnlConteudo);
            Controls.Add(pnlRodape);
            Controls.Add(pnlCabecalho);
            Font = new Font("Arial", 9F);
            ForeColor = Color.FromArgb(60, 60, 60);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PessoaCadastroForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += PessoaCadastroForm_FormClosing;
            Load += PessoaCadastroForm_Load;
            Shown += PessoaCadastroForm_Shown;
            KeyDown += PessoaCadastroForm_KeyDown;
            pnlConteudo.ResumeLayout(false);
            tbControlModulos.ResumeLayout(false);
            tbCadastro.ResumeLayout(false);
            pnlCadastroJuridica.ResumeLayout(false);
            pnlCadastroJuridica.PerformLayout();
            pnlCadastroFisica.ResumeLayout(false);
            pnlCadastroFisica.PerformLayout();
            tbDocumento.ResumeLayout(false);
            pnlDocumento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridDocumento).EndInit();
            tbLayoutDocumentoOperacoes.ResumeLayout(false);
            tbContato.ResumeLayout(false);
            pnlContato.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridContato).EndInit();
            tbLayoutContatoOperacoes.ResumeLayout(false);
            tbEndereco.ResumeLayout(false);
            pnlEndereco.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridEndereco).EndInit();
            tbLayoutEnderecoOperacoes.ResumeLayout(false);
            tbAdicional.ResumeLayout(false);
            pnlAdicionalFisica.ResumeLayout(false);
            pnlAdicionalFisica.PerformLayout();
            tbLayoutSelecaoModulos.ResumeLayout(false);
            tbLayoutAcoes.ResumeLayout(false);
            pnlRodape.ResumeLayout(false);
            tbLayoutCabecalho.ResumeLayout(false);
            tbLayoutCabecalho.PerformLayout();
            pnlCabecalho.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlConteudo;
        private Button btnGravar;
        private TableLayoutPanel tbLayoutAcoes;
        private Button btnCancelar;
        private Panel pnlRodape;
        private Label lblDescricao;
        private TableLayoutPanel tbLayoutCabecalho;
        private Panel pnlCabecalho;
        private TableLayoutPanel tbLayoutSelecaoModulos;
        private Button btnAdicional;
        private Button btnEndereco;
        private Button btnContato;
        private Button btnDocumento;
        private Button btnCadastro;
        private TabControl tbControlModulos;
        private TabPage tbCadastro;
        private TabPage tbDocumento;
        private TabPage tbContato;
        private TabPage tbEndereco;
        private TabPage tbAdicional;
        private Panel pnlCadastroFisica;
        private TextBox txtNomeCompleto;
        private Label label1;
        private Label label6;
        private DateTimePicker dtDataNascimento;
        private Label label7;
        private ComboBox cmbSexo;
        private Label label8;
        private ComboBox cmbEstadoCivil;
        private ComboBox cmbTipoPessoa;
        private CheckBox ckAtivoFisica;
        private Panel pnlCadastroJuridica;
        private Label label17;
        private TextBox txtFantasia;
        private Label label18;
        private TextBox txtRazaoSocial;
        private CheckBox ckAtivoJuridica;
        private Panel pnlDocumento;
        private TableLayoutPanel tbLayoutDocumentoOperacoes;
        private Button btnAlterarDocumento;
        private Button btnExcluirDocumento;
        private Button btnAdicionarDocumento;
        private DataGridView gridDocumento;
        private Panel pnlContato;
        private DataGridView gridContato;
        private TableLayoutPanel tbLayoutContatoOperacoes;
        private Button btnAdicionarContato;
        private Button btnAlterarContato;
        private Button btnExcluirContato;
        private Panel pnlEndereco;
        private DataGridView gridEndereco;
        private TableLayoutPanel tbLayoutEnderecoOperacoes;
        private Button btnAdicionarEndereco;
        private Button btnAlterarEndereco;
        private Button btnExcluirEndereco;
        private Panel pnlAdicionalFisica;
        private Label label9;
        private TextBox txtRendaMensal;
        private Label label4;
        private TextBox txtProfissao;
        private Label label5;
        private TextBox txtLocalTrabalho;
        private Label label3;
        private TextBox txtNomePai;
        private Label label2;
        private TextBox txtNomeMae;
        private Label lblFiliacao;
        private Label label10;
        private MaskedTextBox mskCPF;
        private Label label11;
        private TextBox txtObservacoes;
        private Label label12;
        private Label label13;
        private MaskedTextBox mskCNPJ;
    }
}