using Dados.Data;
using Dados.Enums.Security;
using Dados.Model.Configuracao;
using Dados.Helpers.Form;
using Dados.Helpers.Security;

namespace Dados.View.Geral.Seguranca
{
    public partial class LoginForm : Form
    {
        private readonly DataContext _context;
        public NivelUsuario? NivelAutorizado { get; set; } = null;
        public TipoAutenticacao TipoAutenticacao { get; set; } = TipoAutenticacao.UsuarioNaoDefinido;

        public LoginForm()
        {
            InitializeComponent();
            EstiloGlobal.AplicarEstilo(this);
            _context = new DataContext();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidandoNivelUsuario()
        {
            return NivelAutorizado.HasValue;
        }
        private bool UsuarioPossuiNivelAdequado(Usuario usuario)
        {
            lblMensagemErro.Text = "";

            if (ValidandoNivelUsuario() && usuario.Nivel.HasValue)
            {
                if ((NivelUsuario)usuario.Nivel != NivelAutorizado.Value)
                {
                    lblMensagemErro.Text = $"Este recurso requer permissão de {NivelAutorizado.Value}.";
                    return false;
                }
            }
            
            return true;    
        }

        private void AplicarSessaoUsuario(Usuario usuario)
        {
            if (TipoAutenticacao == TipoAutenticacao.AberturaSistema ||
                TipoAutenticacao == TipoAutenticacao.TrocaUsuario)
            {
                SessaoUsuario.IniciarSessao(usuario);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(login))
            {
                lblMensagemErro.Text = "Preencha o seu usuário.";
                txtLogin.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrEmpty(senha))
            {
                lblMensagemErro.Text = "Preencha a sua senha.";               
                txtSenha.Focus();
                DialogResult = DialogResult.None;
                return;
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Login == login && u.Ativo);
            if (usuario == null)
            {
                lblMensagemErro.Text = "Usuário não encontrado!";
                DialogResult = DialogResult.None;
                txtLogin.Focus();
                return;
            }

            if (!UsuarioPossuiNivelAdequado(usuario))
            {
                DialogResult = DialogResult.None;
                txtLogin.Focus();
                return;
            }

            if (!CriptografiaHelper.VerificarSenha(senha, usuario.Password))
            {
                lblMensagemErro.Text = "Senha incorreta!";
                DialogResult = DialogResult.None;
                txtSenha.Focus();
                return;
            }

            AplicarSessaoUsuario(usuario);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;

                case Keys.F4:
                    btnCancelar.PerformClick();
                    break;

                case Keys.F6:
                    btnConfirmar.PerformClick();
                    break;

            }
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {
            txtLogin.Focus();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _context?.Dispose();
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();

            if (string.IsNullOrWhiteSpace(login))
            {
                lblMensagemErro.Text = "";
                return;
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.Login == login && u.Ativo);

            if (usuario == null)
            {
                lblMensagemErro.Text = "Login inexistente!";
            }
            else
            {
                if (ValidandoNivelUsuario())
                {
                    UsuarioPossuiNivelAdequado(usuario);
                }
                else
                {
                    lblMensagemErro.Text = "";
                }                    
            }
        }
        private void AjustarLayout()
        {
            lblDescricao.Font = new Font(lblDescricao.Font.FontFamily, 11, FontStyle.Bold);

            lblMensagemErro.Font = new Font(lblMensagemErro.Font.FontFamily, 11, FontStyle.Bold);
            lblMensagemErro.ForeColor = Color.Red;

            lblLogin.Font = new Font(lblLogin.Font.FontFamily, 11, FontStyle.Regular);

            txtLogin.Font = new Font(txtLogin.Font.FontFamily, 11, FontStyle.Bold);
            txtLogin.CharacterCasing = CharacterCasing.Normal;

            lblSenha.Font = new Font(lblSenha.Font.FontFamily, 11, FontStyle.Regular);
            txtSenha.Font = new Font(txtSenha.Font.FontFamily, 11, FontStyle.Bold);            
            txtSenha.PasswordChar = '*';

        }

        private string ObterNomeNivel(NivelUsuario nivel)
        {
            return nivel switch
            {
                NivelUsuario.Administrador => "Administrador(a)",
                NivelUsuario.Gerente => "Gerente",
                NivelUsuario.Vendedor => "Vendedor(a)",
                NivelUsuario.Caixa => "Caixa",
                _ => "usuário autorizado"
            };
        }

        private void AtualizarDescricaoNivelAutorizado()
        {
            if (NivelAutorizado.HasValue)
            {
                string nomeNivel = ObterNomeNivel(NivelAutorizado.Value);

                lblDescricao.Text = $"Por gentileza, entre com o login de {nomeNivel} para continuar...";
                this.Text = $"Autenticação de {nomeNivel}"; 
            }
            else
            {
                lblDescricao.Text = "Informe o seu login para continuar...";
                this.Text = "Autenticação"; 
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            AjustarLayout();
            AtualizarDescricaoNivelAutorizado();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                btnConfirmar.PerformClick();
            }
        }
    }
}
