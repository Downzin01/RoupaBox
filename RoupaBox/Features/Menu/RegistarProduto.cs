using RoupaBox.Core.Helpers;
using RoupaBox.Features.Cadastro;
using RoupaBox.UI.Layout;
using RoupaBox.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RoupaBox.Features.Menu
{
    internal class RegistarProduto
    {
        List<CadastroProduto> listaProdutos = new List<CadastroProduto>();

        public CadastroProduto Registrar()
        {
            Cabecalho cabecalho = new Cabecalho();
            MenuPrincipal menu = new MenuPrincipal();
            RegistrarCliente variavelCliente = new RegistrarCliente();
            LerEntrada lerEntrada = new LerEntrada();
            Validador validar = new Validador();
            ExibirTabela exibirTabela = new ExibirTabela();
            Exibir exibir = new Exibir();

            while (true)
            {
                string descricaoProduto = lerEntrada.Validada<string>(
                    "\n» Digite a descrição do produto:",
                    validar.SomenteLetras,
                    "O descrição não pode conter somente números ou caracteres especiais. Tente novamente!"
                );

                string marcaProduto = lerEntrada.Validada<string>(
                    "\n» Digite a marca do produto:",
                    entrada => !string.IsNullOrWhiteSpace(entrada) && entrada.Any(char.IsLetter),
                    "Entrada inválida! Por favor, digite algo válido."
                );

                string tamanhoProduto = lerEntrada.SelecionarOpcao(
                    "\n» Selecione o tamanho do produto:",
                    new string[] { "P", "M", "G", "GG", "XGG" }
                );

                string corProduto = lerEntrada.Validada<string>(
                    "\n» Digite a cor do produto:",
                    validar.SomenteLetras,
                    "O nome não pode conter números ou caracteres especiais. Tente novamente!"
                );

                string categoriaProduto = lerEntrada.Validada<string>(
                    "\n» Digite a categoria do produto:",
                    validar.SomenteLetras,
                    "O nome não pode conter números ou caracteres especiais. Tente novamente!"
                );

                double valorProduto = lerEntrada.Validada<double>(
                    "\n» Digite o valor do produto:",
                    entrada => { return entrada > 0; },
                    "Entrada inválida! Por favor, digite algo válido."
                );

                double pesoProduto = lerEntrada.Validada<double>(
                    "\n» Digite o peso do produto:",
                    entrada => { return entrada > 0; },
                    "Entrada inválida! Por favor, digite algo válido."
                );

                var Produto = new CadastroProduto(descricaoProduto)
                {
                    MarcaProduto = marcaProduto,
                    TamanhoProduto = tamanhoProduto,
                    CorProduto = corProduto,
                    CategoriaProduto = categoriaProduto,
                    ValorPorduto = valorProduto,
                    PesoProduto = pesoProduto,
                };

                Console.Clear();

                exibirTabela.CadastroProduto(
                    descricaoProduto,
                    marcaProduto,
                    tamanhoProduto,
                    corProduto,
                    categoriaProduto,
                    valorProduto,
                    pesoProduto
                );

                listaProdutos.Add(Produto);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nDeseja registrar outro cliente? (S/N)");

                Console.ForegroundColor = ConsoleColor.White;
                string resposta = Console.ReadLine()?.Trim().ToLower();
                Console.ResetColor();

                if (resposta == "s")
                {
                    Registrar();
                    return Produto; // Retorna o produto registrado
                }
                else
                {
                    exibir.Mensagem("Retornando ao menu...", TipoMensagem.Sistema);
                    Thread.Sleep(2000);
                    Console.Clear();

                    cabecalho.Principal();
                    menu.ExibirMenu(this, variavelCliente);

                    return Produto; // Retorna o produto registrado
                }
            }
        }

        public void ExibirListaProdutos()
        {
            // Instanciações de objetos auxiliares necessários para exibição
            Cabecalho cabecalho = new Cabecalho();
            MenuPrincipal menu = new MenuPrincipal();
            RegistrarCliente variavelCliente = new RegistrarCliente();
            ExibirTabela exibirTabela = new ExibirTabela();
            Exibir exibir = new Exibir();

            // Verifica se a lista de clientes está vazia
            if (listaProdutos.Count == 0)
            {
                Console.Clear();
                exibir.Mensagem("Nenhum cliente cadastrado.", TipoMensagem.Aviso); // Mensagem de aviso
                Console.Clear();
                exibir.Mensagem("Retornando ao menu...", TipoMensagem.Sistema); // Mensagem de retorno ao menu
                Console.Clear();

                // Exibe o cabeçalho e retorna ao menu principal
                cabecalho.Principal();
                menu.ExibirMenu(this, variavelCliente);
            }
            else
            {
                // Configura as cores do console para exibição
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Black;

                // Exibição do cabeçalho visual do sistema
                cabecalho.ListaProdutos();

                // Itera sobre a lista de clientes e exibe suas informações
                foreach (var produto in listaProdutos)
                {
                    exibirTabela.ListaProduto(
                        produto.DescricaoProduto,
                        produto.MarcaProduto,
                        produto.TamanhoProduto,
                        produto.CorProduto,
                        produto.CategoriaProduto,
                        produto.ValorPorduto,
                        produto.PesoProduto
                    );
                }

                // Instrução ao usuário para retornar ao menu
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n» Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
                Console.ResetColor();

                // Mensagem de retorno ao menu
                exibir.Mensagem("Retornando ao menu...", TipoMensagem.Sistema);
                Console.Clear();

                // Exibe o cabeçalho e retorna ao menu principal
                cabecalho.Principal();
                menu.ExibirMenu(this, variavelCliente);
            }
        }
    }
}
