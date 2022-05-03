using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);
                tab.ColocarPeca(new Rei(Cor.Preata, tab), new Posicao(0, 0));
                tab.ColocarPeca(new Rainha(Cor.Branca, tab), new Posicao(5, 2));
                tab.ColocarPeca(new Bispo(Cor.Branca, tab), new Posicao(2, 6));
                tab.ColocarPeca(new Peao(Cor.Preata, tab), new Posicao(0, 1));
                Tela.ImprimirTaboleiro(tab);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
