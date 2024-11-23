using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RoupaBox.Core.Helpers
{
    internal class Validador
    {
        public bool CPF(long valorCPF)
        {
            string cpfString = valorCPF.ToString("D11"); // Garante 11 dígitos, preenchendo com zeros à esquerda se necessário.

            if (cpfString.Length != 11) return false;

            if (cpfString.Distinct().Count() == 1) return false;

            // Calcula o primeiro dígito verificador
            int[] multiplicadoresPrimeiro = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpfString[i].ToString()) * multiplicadoresPrimeiro[i];
            }
            int resto = soma % 11;
            int primeiroDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            int[] multiplicadoresSegundo = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpfString[i].ToString()) * multiplicadoresSegundo[i];
            }
            resto = soma % 11;
            int segundoDigitoVerificador = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos verificadores estão corretos
            return cpfString[9].ToString() == primeiroDigitoVerificador.ToString() &&
                   cpfString[10].ToString() == segundoDigitoVerificador.ToString();
        }

        public bool Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string padrao = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, padrao);
        }

        public bool SomenteLetras(string entrada)
        {
            return !string.IsNullOrWhiteSpace(entrada) && entrada.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public bool Telefone(string telefone)
        {
            telefone = Regex.Replace(telefone, @"[^\d]", "");

            if (telefone.Length == 10 || telefone.Length == 11)
            {
                string padrao = @"^(?:[1-9][0-9])(?:9?[0-9]{8})$";
                return Regex.IsMatch(telefone, padrao);
            }

            return false;
        }
    }
}
