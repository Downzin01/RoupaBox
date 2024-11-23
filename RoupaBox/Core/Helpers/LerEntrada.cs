using RoupaBox.UI.Layout;
using System;

namespace RoupaBox.Core.Helpers
{
    internal class LerEntrada
    {
        public T Validada<T>(string mensagem, Func<T, bool> validador, string mensagemErro)
        {
            while (true)
            {
                Exibir exibir = new Exibir();
                Cabecalho cabecalho = new Cabecalho();

                Console.Clear();
                cabecalho.CadastroCliente();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(mensagem);

                Console.ForegroundColor = ConsoleColor.White;
                string entrada = Console.ReadLine()?.Trim();

                if (typeof(T) == typeof(double))
                {
                    entrada = entrada?.Replace(',', '.'); // Substitui vírgula por ponto
                }

                try
                {
                    // Converte a entrada para o tipo especificado
                    var dado = (T)Convert.ChangeType(entrada, typeof(T));

                    // Aplica a validação
                    if (validador(dado))
                        return dado;
                }
                catch
                {
                    // Ignora erros de conversão
                }

                exibir.Mensagem(mensagemErro, TipoMensagem.Erro);
            }
        }

        public int Numerica(string mensagem, string mensagemErro)
        {
            Cabecalho cabecalho = new Cabecalho();
            Exibir exibir = new Exibir();

            while (true)
            {
                Console.Clear();
                cabecalho.CadastroCliente();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(mensagem);

                Console.ForegroundColor = ConsoleColor.White;
                // Tenta converter a entrada para um número
                string entrada = Console.ReadLine()?.Trim();

                try
                {
                    if (int.TryParse(entrada, out int numero))
                    {
                        return numero;
                    }
                }
                catch
                {

                }

                // Exibe a mensagem de erro para entradas inválidas
                exibir.Mensagem(mensagemErro, TipoMensagem.Erro);
            }
        }

        public string SelecionarOpcao(string mensagem, string[] opcoes)
        {
            int indiceSelecionado = 0;

            while (true)
            {
                Cabecalho cabecalho = new Cabecalho();

                Console.Clear();
                cabecalho.CadastroCliente();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(mensagem);

                // Exibe as opções
                for (int i = 0; i < opcoes.Length; i++)
                {
                    if (i == indiceSelecionado)
                    {
                        // Realça a opção selecionada
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"» {opcoes[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.WriteLine($"  {opcoes[i]}");
                    }
                }

                // Aguarda a entrada do usuário
                var tecla = Console.ReadKey(true).Key;

                switch (tecla)
                {
                    case ConsoleKey.UpArrow:
                        indiceSelecionado = (indiceSelecionado == 0) ? opcoes.Length - 1 : indiceSelecionado - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        indiceSelecionado = (indiceSelecionado == opcoes.Length - 1) ? 0 : indiceSelecionado + 1;
                        break;

                    case ConsoleKey.Enter:
                        return opcoes[indiceSelecionado];
                }
            }
        }
    }
}
