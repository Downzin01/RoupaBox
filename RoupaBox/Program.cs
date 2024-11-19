using RoupaBox.Features.Menu;
using RoupaBox.UI.Layout;
using RoupaBox.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoupaBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cabecalho cabecalho = new Cabecalho();
            //MenuPrincipal menu = new MenuPrincipal();

            //Produtos varPro = new Produtos();

            //cabecalho.ExibirCabecalho();
            //menu.ExibirMenu(varPro);

            Cabecalho cabecalho = new Cabecalho();
            MenuPrincipal menu = new MenuPrincipal();

            RegistarProduto produto = new RegistarProduto();

            cabecalho.ExibirCabecalho();
            menu.ExibirMenu(produto);

        }
    }
}
