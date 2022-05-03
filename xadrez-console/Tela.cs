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
                for (int coluna = 0; coluna < tab.Colunas; coluna++)
                {
                    if(tab.peca(linha,coluna) != null)
                    {
                        Console.Write(tab.peca(linha, coluna) + " ");
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine();
            }
        }
            
    }
}
