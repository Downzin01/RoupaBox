using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoupaBox.Core.Helpers
{
    internal class ValidadorCPF
    {
        public bool ValidarCPF(string valorCPF)
        {
            valorCPF = new string(valorCPF.Where(char.IsDigit).ToArray());

            if (valorCPF.Length != 11) return false;

            if(valorCPF.Distinct().Count() == 1 ) return false;

            // Calcula o primeiro dígito verificador
            int[] multiplicadoresPrimeiro = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(valorCPF[i].ToString()) * multiplicadoresPrimeiro[i];
            }
            int resto = soma % 11;
            int primeiroDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            int[] multiplicadoresSegundo = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(valorCPF[i].ToString()) * multiplicadoresSegundo[i];
            }
            resto = soma % 11;
            int segundoDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos verificadores estão corretos
            return valorCPF[9].ToString() == primeiroDigitoVerificador.ToString() &&
                   valorCPF[10].ToString() == segundoDigitoVerificador.ToString();
        }
    }
}
