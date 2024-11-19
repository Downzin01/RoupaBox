using RoupaBox.Features.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoupaBox.UI.Menus
{
    internal class MenuPrincipal
    {
        public void ExibirMenu(RegistarProduto produto)
        {
            while (true)
            {
                List<RegistarProduto> listaProduto = new List<RegistarProduto>();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("» Digite 0 para sair");
                Console.WriteLine("» Digite 1 para Cadastro de Clientes");
                Console.WriteLine("» Digite 2 para Listar Clientes");
                Console.WriteLine("» Digite 3 para Cadastro de Produtos");
                Console.WriteLine("» Digite 4 para Listar Produto\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n» Digite a opção escolhida:");

                int opcaoEscolhidaMenu = int.Parse(Console.ReadLine());

                switch (opcaoEscolhidaMenu)
                {
                    case 1:
                        Console.Clear();
                        CadastroCliente cadastroCliente = new CadastroCliente();
                        cadastroCliente.Cadastro();

                        break;
                    case 2:
                        Console.Clear();

                        break;
                    case 3:
                        Console.Clear();
                        produto.Registrar();

                        break;
                    case 4:
                        Console.Clear();

                        break;
                    case 5:
                        Console.Clear();

                        break;
                    case 6:
                        Console.Clear();

                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Encerrando o programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente.");
                        // ExibirMenu();
                        break;
                }
            }
        }
    }
}
