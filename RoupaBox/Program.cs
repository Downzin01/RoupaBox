using RoupaBox.Features.Menu;
using RoupaBox.UI.Layout;
using RoupaBox.UI.Menus;

namespace RoupaBox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cabecalho cabecalho = new Cabecalho();
            MenuPrincipal menu = new MenuPrincipal();

            RegistrarCliente cliente = new RegistrarCliente();
            RegistarProduto produto = new RegistarProduto();

            cabecalho.Principal();
            menu.ExibirMenu(produto, cliente);
        }
    }
}
