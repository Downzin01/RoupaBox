using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoupaBox.Features.Cadastro
{
    internal class CadastroCliente
    {
        public CadastroCliente(string cliente)
        {
            CPFcliente = cliente;
        }
        public string CPFcliente { get; set; }
        public string NomeCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public int IdadeCliente { get; set; }
        public string EmailCliente { get; set; }
        public string SexoCliente { get; set; }
        public string EnderecoCliente { get; set; }
        public string ComplementoCliente { get; set; }
        public int NumeroCLiente { get; set; }
        public string BairroCliente { get; set; }
        public string CidadeCliente { get; set; }
        public string EstadoCliente { get; set; }
        public int CepCliente { get; set; }
    }
 }
    
