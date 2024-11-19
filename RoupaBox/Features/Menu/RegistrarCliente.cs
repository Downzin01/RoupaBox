using RoupaBox.Features.Cadastro;
using RoupaBox.UI.Layout;
using RoupaBox.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoupaBox.Features.Menu
{
    internal class RegistrarCliente
    {
        List<CadastroCliente> listaClientes = new List<CadastroCliente>();

        public CadastroCliente registrar()
        {
            CabecalhoCadastroCliente cabecalhoCadastro = new CabecalhoCadastroCliente();
            ValidadorCPF validadorCPF = new ValidadorCPF();
            ValidadorTelefone validadorTelefone = new ValidadorTelefone();
            ValidadorEmail validadorEmail = new ValidadorEmail();

            while (true)
            {
                cabecalhoCadastro.Cabecalho();

                Console.ForegroundColor = ConsoleColor.Blue;
                // Inserir Nome Cliente
                Console.WriteLine("\n» Digite o nome do cliente:");
                string nomeCliente = Console.ReadLine();
                Console.Clear();

                // Inserir CPF Cliente
                string cpfClienteValidacao = LerEntradaValidada(
                    "\n» Digite o CPF do cliente:",
                    validadorCPF.ValidarCPF,
                    "CPF inválido! Por favor, digite um CPF válido."
                );
                string cpfCliente = cpfClienteValidacao;

                // Inserir Número de Telefone Cliente
                string telefoneClienteValidacao = LerEntradaValidada(
                    "\n» Digite o número de telefone do cliente:",
                    validadorTelefone.ValidarTelefone,
                    "Telefone inválido! Por favor, digite um número válido."
                );

                string telefoneCliente = telefoneClienteValidacao;

                // Inserir Idade do Cliente
                int idadeCliente = LerEntradaNumerica("\n» Digite a idade do cliente:");

                string emailCliente = LerEntradaValidada(
                    "\n» Digite o e-mail do cliente:",
                    validadorEmail.ValidarEmail,
                    "Email inválido! Por favor, digite um email válido"
                    );

                Console.WriteLine("\n» Digite o sexo do cliente:");
                string sexoCliente = Console.ReadLine();

                Console.WriteLine("\n» Digite a rua do cliente:");
                string ruaCliente = Console.ReadLine();

                Console.WriteLine("\n» Digite o complemento do endereço do cliente:");
                string complementoCliente = Console.ReadLine();

                int numeroCliente = LerEntradaNumerica("\n» Digite o número da casa do cliente:");

                Console.WriteLine("\n» Digite o bairro do cliente:");
                string bairroCliente = Console.ReadLine();

                Console.WriteLine("\n» Digite a cidade do cliente:");
                string cidadeCliente = Console.ReadLine();

                Console.WriteLine("\n» Digite o estado do cliente:");
                string estadoCliente = Console.ReadLine();

                int cepCliente = LerEntradaNumerica("\n» Digite o CEP do endereço do cliente:");

                Thread.Sleep(2000);
                Console.Clear();

                Cabecalho cabecalho = new Cabecalho();
                //MenuPrincipal menu = new MenuPrincipal();

                cabecalho.ExibirCabecalho();
                //menu.ExibirMenu();
            }
        }
        private string LerEntradaValidada(string mensagem, Func<string, bool> validador, string mensagemErro)
        {
            CabecalhoCadastroCliente cabecalhoCadastro = new CabecalhoCadastroCliente();

            string entrada;
            while (true)
            {
                Console.Clear();
                cabecalhoCadastro.Cabecalho();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(mensagem);

                entrada = Console.ReadLine();

                if (validador(entrada))
                    return entrada;

                cabecalhoCadastro.Cabecalho();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(mensagemErro);
                Thread.Sleep(2000);
            }
        }

        private int LerEntradaNumerica(string mensagem)
        {
            CabecalhoCadastroCliente cabecalhoCadastro = new CabecalhoCadastroCliente();

            while (true)
            {
                Console.Clear();
                cabecalhoCadastro.Cabecalho();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(mensagem);
                if (int.TryParse(Console.ReadLine(), out int numero))
                    return numero;

                cabecalhoCadastro.Cabecalho();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Entrada inválida! Por favor, digite um número válido.");
                Thread.Sleep(2000);
            }
        }
    }
}
