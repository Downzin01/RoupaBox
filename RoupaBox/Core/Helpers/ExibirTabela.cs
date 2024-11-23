using RoupaBox.UI.Layout;
using System;

namespace RoupaBox.Core.Helpers
{
    internal class ExibirTabela
    {
        /// <summary>
        /// Exibe os dados de um cliente formatados em uma tabela.
        /// </summary>
        public void CadastroCliente(
            long CPFCliente,
            string NomeCliente,
            int IdadeCliente,
            string SexoCliente,
            string TelefoneCliente,
            string EmailCliente,
            string EnderecoCliente,
            int NumeroCliente,
            string ComplementoCliente,
            string BairroCliente,
            string CidadeCliente,
            string EstadoCliente,
            int CEPCliente
        )
        {
            // Instancia o cabeçalho e configura as cores do console.
            Cabecalho cabecalho = new Cabecalho();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            cabecalho.CadastroSucesso();

            string linhaHorizontal = new string('-', 60);

            // Imprime a tabela de cabeçalho.
            Console.WriteLine(linhaHorizontal);
            Console.WriteLine("| {0,-20} | {1,-35} |", "Título", "Dados Cadastrados");
            Console.WriteLine(linhaHorizontal);

            // Exibe cada linha com os dados do cliente formatados.
            ExibirLinha("CPF", CPFCliente.ToString(@"000\.000\.000\-00"));
            ExibirLinha("Nome do Cliente", NomeCliente);
            ExibirLinha("Idade", IdadeCliente + " Anos");
            ExibirLinha("Sexo", SexoCliente);
            ExibirLinha("Telefone", FormatTelefone(TelefoneCliente));
            ExibirLinha("Email", EmailCliente);
            ExibirLinha("Endereço", EnderecoCliente);
            ExibirLinha("Número", NumeroCliente.ToString());
            ExibirLinha("Complemento", ComplementoCliente);
            ExibirLinha("Bairro", BairroCliente);
            ExibirLinha("Cidade", CidadeCliente);
            ExibirLinha("Estado", EstadoCliente);
            ExibirLinha("CEP", CEPCliente.ToString(@"00000\-000"));

            Console.WriteLine(linhaHorizontal);
            Console.ResetColor();
        }

        /// <summary>
        /// Lista os dados de um cliente em formato de tabela.
        /// </summary>
        public void ListaCliente(
            long CPFCliente,
            string NomeCliente,
            int IdadeCliente,
            string SexoCliente,
            string TelefoneCliente,
            string EmailCliente,
            string EnderecoCliente,
            int NumeroCliente,
            string ComplementoCliente,
            string BairroCliente,
            string CidadeCliente,
            string EstadoCliente,
            int CEPCliente
        )
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            string linhaHorizontal = new string('-', 60);

            Console.WriteLine(linhaHorizontal);
            Console.WriteLine("| {0,-20} | {1,-35} |", "Título", "Dados Cadastrados");
            Console.WriteLine(linhaHorizontal);

            ExibirLinha("CPF", CPFCliente.ToString(@"000\.000\.000\-00"));
            ExibirLinha("Nome do Cliente", NomeCliente);
            ExibirLinha("Idade", IdadeCliente + " Anos");
            ExibirLinha("Sexo", SexoCliente);
            ExibirLinha("Telefone", FormatTelefone(TelefoneCliente));
            ExibirLinha("Email", EmailCliente);
            ExibirLinha("Endereço", EnderecoCliente);
            ExibirLinha("Número", NumeroCliente.ToString());
            ExibirLinha("Complemento", ComplementoCliente);
            ExibirLinha("Bairro", BairroCliente);
            ExibirLinha("Cidade", CidadeCliente);
            ExibirLinha("Estado", EstadoCliente);
            ExibirLinha("CEP", CEPCliente.ToString(@"00000\-000"));

            Console.WriteLine(linhaHorizontal);
            Console.ResetColor();
        }

        /// <summary>
        /// Exibe os dados de um produto formatados em uma tabela.
        /// </summary>
        public void CadastroProduto(
            string DescricaoProduto,
            string MarcaProduto,
            string TamanhoProduto,
            string CorProduto,
            string CategoriaProduto,
            double ValorProduto,
            double PesoProduto
        )
        {
            Cabecalho cabecalho = new Cabecalho();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            cabecalho.CadastroSucesso();

            string linhaHorizontal = new string('-', 60);

            Console.WriteLine(linhaHorizontal);
            Console.WriteLine("| {0,-20} | {1,-35} |", "Título", "Dados Cadastrados");
            Console.WriteLine(linhaHorizontal);

            ExibirLinha("Descrição", DescricaoProduto);
            ExibirLinha("Marca", MarcaProduto);
            ExibirLinha("Tamanho", TamanhoProduto);
            ExibirLinha("Cor", CorProduto);
            ExibirLinha("Categoria", CategoriaProduto);
            ExibirLinha("Valor", ValorProduto.ToString(@"00\,00"));
            ExibirLinha("Peso", PesoProduto.ToString(@"00\,00"));

            Console.WriteLine(linhaHorizontal);
            Console.ResetColor();
        }

        /// <summary>
        /// Lista os dados de um produto em formato de tabela.
        /// </summary>
        public void ListaProduto(
            string DescricaoProduto,
            string MarcaProduto,
            string TamanhoProduto,
            string CorProduto,
            string CategoriaProduto,
            double ValorProduto,
            double PesoProduto
        )
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;

            string linhaHorizontal = new string('-', 60);

            Console.WriteLine(linhaHorizontal);
            Console.WriteLine("| {0,-20} | {1,-35} |", "Título", "Dados Cadastrados");
            Console.WriteLine(linhaHorizontal);

            ExibirLinha("Descrição", DescricaoProduto);
            ExibirLinha("Marca", MarcaProduto);
            ExibirLinha("Tamanho", TamanhoProduto);
            ExibirLinha("Cor", CorProduto);
            ExibirLinha("Categoria", CategoriaProduto);
            ExibirLinha("Valor", ValorProduto.ToString(@"00\,00"));
            ExibirLinha("Peso", PesoProduto.ToString(@"00\,00"));

            Console.WriteLine(linhaHorizontal);
            Console.ResetColor();
        }

        /// <summary>
        /// Exibe uma linha formatada na tabela, quebrando dados longos em várias linhas.
        /// </summary>
        private void ExibirLinha(string titulo, string dado)
        {
            int larguraMaxima = 35; // Define o limite de caracteres por linha.

            if (dado.Length > larguraMaxima)
            {
                // Quebra os dados em várias linhas, se necessário.
                Console.WriteLine("| {0,-20} | {1,-35} |", titulo, dado.Substring(0, larguraMaxima));
                dado = dado.Substring(larguraMaxima);

                while (dado.Length > larguraMaxima)
                {
                    Console.WriteLine("| {0,-20} | {1,-35} |", "", dado.Substring(0, larguraMaxima));
                    dado = dado.Substring(larguraMaxima);
                }

                if (dado.Length > 0)
                {
                    Console.WriteLine("| {0,-20} | {1,-35} |", "", dado);
                }
            }
            else
            {
                Console.WriteLine("| {0,-20} | {1,-35} |", titulo, dado);
            }
        }

        /// <summary>
        /// Formata o número de telefone com base no comprimento.
        /// </summary>
        private string FormatTelefone(string telefone)
        {
            if (telefone.Length == 10)
                return string.Format("({0}) {1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 4), telefone.Substring(6));
            if (telefone.Length == 11)
                return string.Format("({0}) {1}-{2}", telefone.Substring(0, 2), telefone.Substring(2, 5), telefone.Substring(7));
            return telefone; // Retorna o telefone sem formatação, se inválido.
        }
    }
}
