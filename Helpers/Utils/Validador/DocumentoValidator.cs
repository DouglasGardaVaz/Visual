using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Helpers.Validador.DocumentoValidator
{
    public static class DocumentoValidator
    {
        // Valida o CPF
        public static bool ValidarCPF(string cpf)
        {
            // 1. Remover caracteres de pontuação do CPF (pontos e hífen)
            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            // 2. Verificar se o CPF tem 11 dígitos numéricos
            if (cpf.Length != 11)
                return false;

            // 3. Verificar se todos os dígitos são iguais (CPF inválido por convenção)
            bool todosIguais = true;
            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    todosIguais = false;
                    break;
                }
            }
            if (todosIguais)
                return false;

            // 4. Calcular o primeiro dígito verificador (DV1)
            int soma = 0;
            for (int i = 0, peso = 10; i < 9; i++, peso--)
            {
                soma += int.Parse(cpf[i].ToString()) * peso;
            }
            int resto = soma % 11;
            int dv1 = (resto < 2) ? 0 : 11 - resto;

            // 5. Calcular o segundo dígito verificador (DV2)
            soma = 0;
            for (int i = 0, peso = 11; i < 10; i++, peso--)
            {
                soma += int.Parse(cpf[i].ToString()) * peso;
            }
            resto = soma % 11;
            int dv2 = (resto < 2) ? 0 : 11 - resto;

            // 6. Verificar se DV1 e DV2 correspondem aos dígitos informados no CPF
            string dvCalculado = dv1.ToString() + dv2.ToString();
            return cpf.EndsWith(dvCalculado);
        }

        // Valida o CNPJ
        public static bool ValidarCNPJ(string cnpj)
        {
            // 1. Remover caracteres de pontuação do CNPJ (pontos, barra e hífen)
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            // 2. Verificar se o CNPJ tem 14 dígitos numéricos
            if (cnpj.Length != 14)
                return false;

            // 3. Verificar se todos os dígitos são iguais (CNPJ inválido por convenção)
            bool todosIguais = true;
            for (int i = 1; i < cnpj.Length; i++)
            {
                if (cnpj[i] != cnpj[0])
                {
                    todosIguais = false;
                    break;
                }
            }
            if (todosIguais)
                return false;

            // 4. Calcular o primeiro dígito verificador (DV1)
            int soma = 0;
            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < 12; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores1[i];
            }
            int resto = soma % 11;
            int dv1 = (resto < 2) ? 0 : 11 - resto;

            // 5. Calcular o segundo dígito verificador (DV2)
            soma = 0;
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(cnpj[i].ToString()) * multiplicadores2[i];
            }
            resto = soma % 11;
            int dv2 = (resto < 2) ? 0 : 11 - resto;

            // 6. Verificar se DV1 e DV2 correspondem aos dígitos informados no CNPJ
            string dvCalculado = dv1.ToString() + dv2.ToString();
            return cnpj.EndsWith(dvCalculado);
        }

    }
}

