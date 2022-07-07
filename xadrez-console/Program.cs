using System;
using tabuleiro;
using Xadrez;
using xadrez_console.Xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PartidaDeXadrez partida = new PartidaDeXadrez();
            while (!partida.Terminada)
            {
                try
                {
                    Console.Clear();
                    Tela.ImprimirPartida(partida);
                    
                    Console.Write("Origem :");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ValidarPosicaoOrigem(origem);
                    bool[,] movimentosPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTaboleiro(partida.Tab, movimentosPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino :");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    partida.ValidarPosicaoDestino(origem,destino);
                    partida.RealizaJogada(origem, destino);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }

            }
        }
    }
}
