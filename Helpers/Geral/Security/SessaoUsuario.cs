using Dados.Model.Configuracao;

namespace Dados.Helpers.Security
{
    public static class SessaoUsuario
    {
        public static long? UsuarioId { get; set; }
        public static Usuario? UsuarioAtual { get; set; }
        public static string NomeMaquina { get; set; } = Environment.MachineName;
        public static DateTime DataLogin { get; set; }

        public static bool EstaLogado => UsuarioId.HasValue;

        public static void IniciarSessao(Usuario usuario)
        {
            UsuarioId = usuario.Id;
            UsuarioAtual = usuario;
            DataLogin = DateTime.Now;
            NomeMaquina = Environment.MachineName;
        }

        public static void Limpar()
        {
            UsuarioId = null;
            UsuarioAtual = null;
            NomeMaquina = string.Empty;
            DataLogin = DateTime.MinValue;
        }
    }
}
