using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dados.View.Geral;

namespace Dados.Helpers.Form
{
    public static class EsperaHelper
    {
        public static void ExecutarComEspera(string mensagem, Action acao)
        {
            var espera = new ProcessandoForm(mensagem);

            espera.Shown += async (sender, args) =>
            {
                await Task.Delay(150); // ⏳ Dá tempo para o form renderizar

                await Task.Run(() =>
                {
                    try
                    {
                        acao();
                    }
                    catch (Exception ex)
                    {
                        espera.BeginInvoke(new Action(() =>
                        {
                            MessageBox.Show("Erro durante execução:\n" + ex.Message);
                        }));
                    }

                    espera.BeginInvoke(new Action(() => espera.Close()));
                });
            };

            espera.ShowDialog(); // Isso bloqueia até Close()
        }
    }
}
