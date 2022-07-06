using System;
using tabuleiro;
using xadrez_console.Xadrez;

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
                        ImprimirPeca(tab.Peca(linha,coluna));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void ImprimirTaboleiro(Tabuleiro tab, bool[,] movimentosPossiveis)
        {
            ConsoleColor fundoOriginal =  Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int linha = 0; linha < tab.Linhas; linha++)
            {
                Console.Write(8 - linha + " ");
                for (int coluna = 0; coluna < tab.Colunas; coluna++)
                {
                    if (movimentosPossiveis[linha, coluna])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                        ImprimirPeca(tab.Peca(linha, coluna));
                }
                Console.BackgroundColor = fundoOriginal;
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }


        internal static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {

            if(peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if(peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
