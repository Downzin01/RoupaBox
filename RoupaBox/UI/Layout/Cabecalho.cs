﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoupaBox.UI.Layout
{
    internal class Cabecalho
    {
        public void ExibirCabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=========================================================================================");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Autor: Downzin");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=========================================================================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
██████╗░░█████╗░██╗░░░██╗██████╗░░█████╗░██████╗░░█████╗░██╗░░██╗
██╔══██╗██╔══██╗██║░░░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚██╗██╔╝
██████╔╝██║░░██║██║░░░██║██████╔╝███████║██████╦╝██║░░██║░╚███╔╝░
██╔══██╗██║░░██║██║░░░██║██╔═══╝░██╔══██║██╔══██╗██║░░██║░██╔██╗░
██║░░██║╚█████╔╝╚██████╔╝██║░░░░░██║░░██║██████╦╝╚█████╔╝██╔╝╚██╗
╚═╝░░╚═╝░╚════╝░░╚═════╝░╚═╝░░░░░╚═╝░░╚═╝╚═════╝░░╚════╝░╚═╝░░╚═╝");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=========================================================================================\n");
            Console.ResetColor();
        }
    }
}