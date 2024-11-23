using System;
using System.Threading;

namespace RoupaBox.Core.Helpers
{
    public enum TipoMensagem
    {
        Erro,
        Aviso,
        Sucesso,
        Sistema
    }
    internal class Exibir
    {
        public void Mensagem(string mensagem, TipoMensagem tipoMensagem)
        {
            // Salva a posição inicial do cursor
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;

            // Define as cores dependendo do tipo de mensagem
            ConsoleColor corFundo;
            ConsoleColor corTexto;

            // Mapeia o tipo de mensagem para cores
            switch (tipoMensagem)
            {
                case TipoMensagem.Erro:
                    corFundo = ConsoleColor.Red;
                    corTexto = ConsoleColor.White;
                    break;
                case TipoMensagem.Aviso:
                    corFundo = ConsoleColor.Yellow;
                    corTexto = ConsoleColor.Black;
                    break;
                case TipoMensagem.Sucesso:
                    corFundo = ConsoleColor.Green;
                    corTexto = ConsoleColor.White;
                    break;
                case TipoMensagem.Sistema:
                    corFundo = ConsoleColor.Blue;
                    corTexto = ConsoleColor.Black;
                    break;
                default:
                    corFundo = ConsoleColor.Gray;
                    corTexto = ConsoleColor.Black;
                    break;
            }

            // Exibe a mensagem com contagem regressiva
            for (int i = 2; i > 0; i--)
            {
                // Move o cursor para a posição inicial
                Console.SetCursorPosition(cursorLeft, cursorTop);

                // Sobrescreve a mensagem com a contagem
                Console.Write("\n  ");
                Console.BackgroundColor = corFundo; // Define a cor de fundo
                Console.ForegroundColor = corTexto; // Define a cor do texto
                Console.Write($" {tipoMensagem.ToString().ToUpper()} "); // Exibe o tipo da mensagem
                Console.ResetColor(); // Restaura as cores padrão
                Console.Write("  ");

                Console.ForegroundColor = corFundo; // Mantém a cor do texto
                Console.WriteLine($"{mensagem} ({i}s)");
                Console.ResetColor();
                Thread.Sleep(1000);
            }

            // Após a contagem, limpa a mensagem
            Console.SetCursorPosition(cursorLeft, cursorTop);
            Console.Write(new string(' ', mensagem.Length + 8)); 
            Console.SetCursorPosition(cursorLeft, cursorTop); 
        }
    }
}
