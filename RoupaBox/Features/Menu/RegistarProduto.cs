using RoupaBox.Features.Cadastro;
using RoupaBox.UI.Layout;
using RoupaBox.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoupaBox.Features.Menu
{
    internal class RegistarProduto
    {
        List<CadastroProduto> listaProdutos = new List<CadastroProduto>();

        public CadastroProduto Registrar()
        {
            Console.Clear();
            Console.WriteLine("\nDigite a descrição do Produto:");
            string descPro = Console.ReadLine();

            var Produto = new CadastroProduto(descPro);

            Console.WriteLine("\nDigite a marca do Produto:");
            string marcaPro = Console.ReadLine();
            Produto.MarcaProduto = marcaPro;

            Console.WriteLine("\nDigite o tamanho(P M G GG XGG) do Produto:");
            string tamanhoProduto = Console.ReadLine();
            Produto.TamanhoProduto = tamanhoProduto;

            Console.WriteLine("\nDigite a cor do Produto:");
            string corProduto = Console.ReadLine();
            Produto.CorProduto = corProduto;

            Console.WriteLine("\nDigite a categoria do Produto:");
            string categoriaProduto = Console.ReadLine();
            Produto.CategoriaProduto = categoriaProduto;

            Console.WriteLine("\nDigite o valor do Produto:");
            double valorProduto = double.Parse(Console.ReadLine());
            Produto.ValorPorduto = valorProduto;

            Console.WriteLine("\nDigite o peso do Produto:");
            double pesoProduto = double.Parse(Console.ReadLine());
            Produto.PesoProduto = pesoProduto;

            listaProdutos.Add(Produto);

            Console.WriteLine($"O Produto foi Cadastrado!");

            foreach (var produto in listaProdutos)
            {
                Console.WriteLine($"Descrição: {produto.DescricaoProduto}\nValor: {produto.ValorPorduto}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();

            Cabecalho cabecalho = new Cabecalho();
            cabecalho.ExibirCabecalho();

            RegistarProduto variavelProduto = new RegistarProduto();
            MenuPrincipal menu = new MenuPrincipal();

            return Produto;
        }
    }
}
