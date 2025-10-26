namespace Visual.Constantes.Mensagens.Financeiro
{
    public static class MensagensFinanceiro
    {
        // --- PAGAR ---
        public const string PagarNaoSelecionada = "Nenhuma conta foi selecionada para cancelamento.";
        public const string PagarNaoEncontrada = "Conta a pagar não encontrada no banco de dados.";
        public const string PagarJaPaga = "Não é possível cancelar uma parcela já paga.";
        public const string PagarConfirmarCancelamento = "Deseja realmente cancelar esta parcela?";
        public const string PagarCanceladaComSucesso = "Parcela cancelada com sucesso!";
        public const string PagarErroGerar = "Erro ao gerar contas a pagar.";
        public const string PagarSucessoGerar = "Contas a pagar geradas com sucesso!";
        public const string PagarDescricaoObrigatoria = "O campo descrição é obrigatório.";
        

        // --- RECEBER ---
        public const string ReceberNaoSelecionada = "Nenhuma conta foi selecionada para cancelamento.";
        public const string ReceberNaoEncontrada = "Conta a receber não encontrada no banco de dados.";
        public const string ReceberJaCancelada = "Esta conta já está cancelada.";
        public const string ReceberJaRecebida = "Não é possível cancelar uma conta já recebida.";
        public const string ReceberConfirmarCancelamento = "Deseja realmente cancelar esta conta?";
        public const string ReceberCanceladaComSucesso = "Conta cancelada com sucesso!";
        public const string ReceberErroGerar = "Erro ao gerar contas a receber.";
        public const string ReceberSucessoGerar = "Contas a receber geradas com sucesso!";
        public const string ReceberDescricaoObrigatoria = "O campo descrição é obrigatório.";

        public const string ParcelaCancelada = "Esta parcela já está cancelada.";
        public const string ParcelaQuitada = "Esta parcela já está quitada.";

    }
}
