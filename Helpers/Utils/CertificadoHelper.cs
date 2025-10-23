using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using GerencialDFe.Enums.Configs;

namespace Dados.Helpers.Utils
{
    public static class CertificadoHelper
    {
        public static string SelecionarCertificadoValido(out X509Certificate2 certificadoSelecionado)
        {
            certificadoSelecionado = null;

            try
            {
                using (X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
                {
                    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                    X509Certificate2Collection certificados = store.Certificates;

                    if (certificados.Count == 0)
                    {
                        MessageBox.Show("Nenhum certificado digital foi encontrado.");
                        return null;
                    }

                    X509Certificate2Collection selecionado = X509Certificate2UI.SelectFromCollection(
                        certificados,
                        "Selecionar Certificado",
                        "Escolha o certificado digital a ser utilizado:",
                        X509SelectionFlag.SingleSelection
                    );

                    if (selecionado.Count == 0)
                        return null;

                    X509Certificate2 cert = selecionado[0];

                    if (DateTime.Now > cert.NotAfter)
                    {
                        MessageBox.Show($"O certificado selecionado está vencido desde {cert.NotAfter:dd/MM/yyyy}.");
                        return null;
                    }

                    certificadoSelecionado = cert;
                    return cert.SerialNumber;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar certificado: " + ex.Message);
                return null;
            }
        }

        public static ModeloCertificado ObterModeloCertificado(string serial)
        {
            try
            {
                using (var store = new X509Store(StoreName.My, StoreLocation.CurrentUser))
                {
                    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                    var certificados = store.Certificates
                        .Find(X509FindType.FindBySerialNumber, serial, validOnly: false);

                    if (certificados.Count == 0)
                        throw new Exception("Certificado não encontrado no repositório.");

                    var certificado = certificados[0];

                    if (certificado.HasPrivateKey)
                    {
                        var rsa = certificado.PrivateKey as RSACryptoServiceProvider;

                        if (rsa != null)
                        {
                            string providerName = rsa.CspKeyContainerInfo.ProviderName.ToUpper();

                            if (providerName.Contains("SAFE") ||
                                providerName.Contains("TOKEN") ||
                                providerName.Contains("SMARTCARD"))
                            {
                                return ModeloCertificado.A3;
                            }
                        }
                    }

                    return ModeloCertificado.A1Repositorio;
                }
            }
            catch
            {
                return ModeloCertificado.A1Repositorio; 
            }
        }


    }
}
