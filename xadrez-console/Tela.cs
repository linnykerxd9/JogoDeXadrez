using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void ImprimirTaboleiro(Tabuleiro tab)
        {
           for (int linha = 0; linha < tab.Linhas; linha++)
           {
                Console.Write(8 - linha + " ");
                for (int coluna = 0; coluna < tab.Colunas; coluna++)
                {
                    if(tab.peca(linha,coluna) != null)
                    {
                        ImprimirPeca(tab.peca(linha,coluna));
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
         public static void ImprimirPeca(Peca peca)
        {
            if(peca.Cor == Cor.Branca)
            {
                Console.WriteLine(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;

            }
        }
    }
}
