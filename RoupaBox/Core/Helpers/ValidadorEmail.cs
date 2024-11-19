using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoupaBox.Core.Helpers
{
    internal class ValidadorEmail
    {
        public bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string padrao = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, padrao);
        }
    }
}
