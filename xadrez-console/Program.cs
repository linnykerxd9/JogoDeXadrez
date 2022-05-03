using System;
using tabuleiro;
using Xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Rei(Cor.Preata, tab),new Posicao(0,0));
            tab.ColocarPeca(new Rainha(Cor.Branca, tab),new Posicao(5,2));
            tab.ColocarPeca(new Bispo(Cor.Branca, tab),new Posicao(2,6));
            tab.ColocarPeca(new Peao(Cor.Preata, tab),new Posicao(1,0));

            Tela.ImprimirTaboleiro(tab);
            Console.ReadKey();
        }
    }
}
