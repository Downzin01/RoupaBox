using RoupaBox.Features.Menu;
using System;
using System.Collections.Generic;

namespace RoupaBox.UI.Menus
{
    internal class MenuPrincipal
    {
        public void ExibirMenu(RegistarProduto produto, RegistrarCliente cliente)
        {
            while (true)
            {
                List<RegistarProduto> listaProduto = new List<RegistarProduto>();
                List<RegistrarCliente> listaCliente = new List<RegistrarCliente>();

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
                        cliente.Registrar();

                        break;
                    case 2:
                        Console.Clear();
                        cliente.ExibirListaClientes();
                        break;
                    case 3:
                        Console.Clear();
                        produto.Registrar();

                        break;
                    case 4:
                        Console.Clear();
                        produto.ExibirListaProdutos();

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
