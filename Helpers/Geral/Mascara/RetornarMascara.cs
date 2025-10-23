using Dados.Enums.Pessoa;

namespace Dados.Helpers.Mascara.RetornarMascara
{
    public static class MascaraHelper
    {
        public static void AplicarMascaraTipoContato(MaskedTextBox maskedTextBox, TipoContatoPessoa tipoContato)
        {
            switch (tipoContato)
            {
                case TipoContatoPessoa.Email:
                    maskedTextBox.Mask = ""; // Máscara para e-mail (geralmente é mais flexível, pode usar regex para validação adicional)
                    break;
                case TipoContatoPessoa.Celular:
                    maskedTextBox.Mask = "(99) 99999-9999"; // Máscara para celular
                    break;
                case TipoContatoPessoa.Telefone:
                    maskedTextBox.Mask = "(99) 9999-9999"; // Máscara para telefone fixo
                    break;
                case TipoContatoPessoa.WhatsApp:
                    maskedTextBox.Mask = "(99) 99999-9999"; // Máscara para WhatsApp
                    break;
                case TipoContatoPessoa.Outro:
                    maskedTextBox.Mask = ""; // Máscara genérica para outros tipos
                    break;
                default:
                    maskedTextBox.Mask = ""; // Caso não tenha tipo de contato, nenhuma máscara
                    break;
            }
        }

        public static void AplicarMascaraTipoDocumento(MaskedTextBox maskedTextBox, TipoDocumentoPessoa tipoDocumento)
        {
            switch (tipoDocumento)
            {
                case TipoDocumentoPessoa.CPF:
                    maskedTextBox.Mask = "000.000.000-00"; // Máscara para CPF
                    break;
                case TipoDocumentoPessoa.CNPJ:
                    maskedTextBox.Mask = "00.000.000/0000-00"; // Máscara para CNPJ
                    break;
                case TipoDocumentoPessoa.RG:
                    maskedTextBox.Mask = ""; // Máscara para RG
                    break;
                case TipoDocumentoPessoa.CNH:
                    maskedTextBox.Mask = ""; // Máscara para CNH (somente números)
                    break;
                case TipoDocumentoPessoa.Passaporte:
                    maskedTextBox.Mask = ""; // Máscara para Passaporte (genérica)
                    break;
                case TipoDocumentoPessoa.CarteiraTrabalho:
                    maskedTextBox.Mask = ""; // Máscara para Carteira de Trabalho
                    break;
                case TipoDocumentoPessoa.TituloEleitor:
                    maskedTextBox.Mask = ""; // Máscara para Título de Eleitor
                    break;
                case TipoDocumentoPessoa.CertidaoNascimento:
                    maskedTextBox.Mask = ""; // Máscara para Certidão de Nascimento
                    break;
                case TipoDocumentoPessoa.CertidaoCasamento:
                    maskedTextBox.Mask = ""; // Máscara para Certidão de Casamento
                    break;
                case TipoDocumentoPessoa.InscricaoEstadual:
                    maskedTextBox.Mask = ""; // Máscara para Inscrição Estadual
                    break;
                case TipoDocumentoPessoa.InscricaoMunicipal:
                    maskedTextBox.Mask = ""; // Máscara para Inscrição Municipal
                    break;
                case TipoDocumentoPessoa.Outro:
                    maskedTextBox.Mask = ""; // Máscara para outro tipo de documento
                    break;
                default:
                    maskedTextBox.Mask = ""; // Caso não tenha tipo de documento, nenhuma máscara
                    break;
            }
        }

        // Implementação da formatação do CEP
        public static void AplicarMascaraCEP(MaskedTextBox maskedTextBox)
        {
            maskedTextBox.Mask = "00000-000"; // Máscara para CEP (formato brasileiro)
        }
    }
}
