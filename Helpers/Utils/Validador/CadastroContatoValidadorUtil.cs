using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Helpers.Validar.CadastroContatoUtil
{
    public static class EmailValidador
    {
        public static bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

    public static class CelularValidador
    {
        public static bool ValidarCelular(string celular)
        {
            var celularNumeros = new string(celular.Where(char.IsDigit).ToArray());
            return celularNumeros.Length >= 10; 
        }
    }
}

