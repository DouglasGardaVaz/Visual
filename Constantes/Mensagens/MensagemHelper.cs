using Dados.Constantes;

public static class MensagemHelper
{
    public static void Info(string mensagem) =>
        MessageBox.Show(mensagem, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);

    public static void Erro(string mensagem) =>
        MessageBox.Show(mensagem, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Error);

    public static void Alerta(string mensagem) =>
        MessageBox.Show(mensagem, AppInfo.NomeSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public static DialogResult Confirmar(string mensagem) =>
        MessageBox.Show(mensagem, AppInfo.NomeSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
}
