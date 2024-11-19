using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoupaBox.Core.Helpers
{
    internal class ValidadorTelefone
    {
        public bool ValidarTelefone (string telefone)
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
