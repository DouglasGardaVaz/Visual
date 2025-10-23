namespace Dados.Constantes.Mensagens.Global
{
    public static class MensagensComuns
    {
        //Gerencial
        public const string ConfirmarFecharLogin = "Você deseja realmente fechar o sistema?";

        // Ações gerais
        public const string ConfirmarExclusao = "Deseja realmente excluir este registro?";
        public const string ConfirmarAlteracao = "Deseja salvar as alterações?";
        public const string ConfirmarSaida = "Deseja realmente sair?";

        // Sucesso
        public const string SucessoInclusao = "Cadastro realizado com sucesso!";
        public const string SucessoAlteracao = "Alteração salva com sucesso!";
        public const string SucessoExclusao = "Registro excluído com sucesso!";
        public const string ErroExclusao = "Não é possível excluir o registro selecionado!";

        // Erros
        public const string ErroPadrao = "Ocorreu um erro inesperado.";
        public const string NenhumRegistroSelecionado = "Nenhum registro foi selecionado!";

        // Outros
        public const string AcessoNegado = "Você não tem permissão para realizar esta ação.";
        public const string OperacaoCancelada = "Operação cancelada pelo usuário.";

        // Validações específicas
        public const string SelecioneParaExcluir = "Nenhum registro selecionado para realizar a exclusão.";
        public const string SelecioneParaAlterar = "Nenhum registro selecionado para realizar a edição.";
    }
}
