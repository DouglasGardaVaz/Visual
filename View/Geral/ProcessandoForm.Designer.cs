namespace Visual.View.Geral.ProcessamentoFormulario
{
    partial class ProcessandoForm
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
            lblMensagem = new Label();
            pbImgLoading = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbImgLoading).BeginInit();
            SuspendLayout();
            // 
            // lblMensagem
            // 
            lblMensagem.Font = new Font("Arial", 18F, FontStyle.Bold);
            lblMensagem.Location = new Point(3, 15);
            lblMensagem.Name = "lblMensagem";
            lblMensagem.Size = new Size(311, 43);
            lblMensagem.TabIndex = 0;
            lblMensagem.Text = "Aguarde...";
            lblMensagem.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbImgLoading
            // 
            pbImgLoading.ErrorImage = null;
            pbImgLoading.Image = Visual.Properties.Resources.loading;
            pbImgLoading.Location = new Point(53, 69);
            pbImgLoading.Name = "pbImgLoading";
            pbImgLoading.Size = new Size(207, 138);
            pbImgLoading.SizeMode = PictureBoxSizeMode.Zoom;
            pbImgLoading.TabIndex = 1;
            pbImgLoading.TabStop = false;
            // 
            // ProcessandoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 224);
            Controls.Add(pbImgLoading);
            Controls.Add(lblMensagem);
            Font = new Font("Arial", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProcessandoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Aguarde...";
            Load += ProcessandoForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbImgLoading).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblMensagem;
        private PictureBox pbImgLoading;
    }
}