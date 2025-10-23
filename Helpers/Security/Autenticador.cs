using Dados.Constantes;
using Dados.Enums.Security;
using Dados.Constantes.Mensagens.Global;
using Dados.Helpers.Security;
using Dados.View.Geral.Seguranca;
namespace Dados.Helpers.Security
{
    public static class Autenticador
    {
        public static bool ValidarAdministrador(System.Windows.Forms.Form formPai)
            => ValidarNivelUsuario(formPai, NivelUsuario.Administrador, TipoAutenticacao.ValidacaoNivelUsuario);

        public static bool ValidarNivelUsuario(System.Windows.Forms.Form formPai, 
            NivelUsuario nivelEsperado, TipoAutenticacao tipo)
        {
            var usuarioAtual = SessaoUsuario.UsuarioAtual;

            if (usuarioAtual?.Nivel.HasValue == true)
            {
                var nivelAtual = (NivelUsuario)usuarioAtual.Nivel.Value;

                if (nivelAtual == nivelEsperado)
                    return true;
            }

            using var form = new LoginForm
            {
                NivelAutorizado = nivelEsperado,
                TipoAutenticacao = tipo
            };

            var result = form.ShowDialog(formPai);
            return result == DialogResult.OK;
        }

        // 1. Autenticação padrão na abertura do sistema
        public static bool AutenticarUsuario(System.Windows.Forms.Form formPai)
            => AutenticarUsuario(formPai, TipoAutenticacao.AberturaSistema, exigirLogin: true, fecharFormSeCancelar: true);

        // 2. Autenticação com controle sobre fechar o formulário
        public static bool AutenticarUsuario(System.Windows.Forms.Form formPai, bool fecharFormSeCancelar)
            => AutenticarUsuario(formPai, TipoAutenticacao.AberturaSistema, exigirLogin: true, fecharFormSeCancelar: fecharFormSeCancelar);

        // 3. Troca de usuário (sem fechar o form por padrão)
        public static bool TrocarUsuario(System.Windows.Forms.Form formPai, bool fecharFormSeCancelar = false)
            => AutenticarUsuario(formPai, TipoAutenticacao.TrocaUsuario, exigirLogin: true, fecharFormSeCancelar: fecharFormSeCancelar);

        // 4. Método principal de autenticação
        public static bool AutenticarUsuario(System.Windows.Forms.Form formPai, TipoAutenticacao tipo, bool exigirLogin, bool fecharFormSeCancelar)
        {
            bool loginRealizado = false;

            do
            {
                using var form = new LoginForm();
                form.TipoAutenticacao = tipo;

                var result = form.ShowDialog(formPai);

                if (result == DialogResult.OK)
                {
                    loginRealizado = true;
                }
                else
                {
                    if (!exigirLogin)
                        return false;

                    bool devePerguntarFechar = (tipo == TipoAutenticacao.AberturaSistema) || fecharFormSeCancelar;

                    if (!devePerguntarFechar)
                        return false;

                    var confirmar = MessageBox.Show(MensagensComuns.ConfirmarFecharLogin, AppInfo.NomeSistema,
                                                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (confirmar == DialogResult.Yes)
                    {
                        if (fecharFormSeCancelar)
                            formPai.Close();

                        return false;
                    }

                    // Usuário escolheu "Não", volta ao login
                }

            } while (!loginRealizado);

            return true;
        }
    }
}
