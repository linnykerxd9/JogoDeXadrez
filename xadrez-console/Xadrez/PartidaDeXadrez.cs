using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using tabuleiro.Exceptions;
using xadrez_console.Xadrez;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tab { get;private set; }
        public bool Terminada { get; private set; }
        public int Turno { get;private set; }
        public Cor JogadorAtual { get; private set; }
        private HashSet<Peca> pecas { get; set; } = new HashSet<Peca>();
        private HashSet<Peca> capturadas { get; set; } = new HashSet<Peca>();
        public bool Xeque { get; set; }
        public PartidaDeXadrez()
        {
            this.Tab = new Tabuleiro(8, 8);
            this.Turno = 1;
            this.JogadorAtual = Cor.Branca;
            this.Terminada = false;
            this.Xeque = false;
            ColocarPecas();
        }
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                desfazMovimento(origem,destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em cheque");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            Turno++;
            MudaJogador();
        }

        private void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca peca = Tab.RetirarPeca(destino);
            peca.DecrementarQntdMovimentos();


            Tab.ColocarPeca(peca, origem);

            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }

        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = Tab.RetirarPeca(origem);
            peca.IncrementarQntdMovimento();

            Peca pecaCapturada = Tab.RetirarPeca(destino);

            Tab.ColocarPeca(peca, destino);

            if (pecaCapturada != null)
                capturadas.Add(pecaCapturada);

            return pecaCapturada;
        }
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if (x.Cor == cor)
                    aux.Add(x);
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                    aux.Add(x);
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }
        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");

            if(Tab.Peca(pos).Cor != JogadorAtual)
                throw new TabuleiroException("A peça de origem escolhida não é sua");

            if(!Tab.Peca(pos).ExisteMovimentosPossiveis())
                throw new TabuleiroException("Esta peça não tem movimentos possíveis");


        }

        public void ValidarPosicaoDestino(Posicao origem,Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
                throw new TabuleiroException("Posição de destino inválida");

        }
        public bool EstaEmXeque(Cor cor)
        {
            Peca rei = Rei(cor);
            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna])
                    return true;
            }
            return false;
        }

        public void ColocarNovaPeca(Peca peca, char coluna, int linha)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna,linha).ToPosicao());
            pecas.Add(peca);
        }
        private void ColocarPecas()
        {
           ColocarNovaPeca(new Torre(Cor.Branca, Tab), 'c', 1);
           ColocarNovaPeca(new Torre(Cor.Branca, Tab), 'c', 2);
           ColocarNovaPeca(new Torre(Cor.Branca, Tab), 'd', 2);
           ColocarNovaPeca(new Torre(Cor.Branca, Tab), 'e', 2);
           ColocarNovaPeca(new Torre(Cor.Branca, Tab), 'e', 1);
           ColocarNovaPeca(new Rei(Cor.Branca, Tab), 'd', 1);

           ColocarNovaPeca(new Torre(Cor.Preta, Tab), 'c', 7);
           ColocarNovaPeca(new Torre(Cor.Preta, Tab), 'c', 8);
           ColocarNovaPeca(new Torre(Cor.Preta, Tab), 'd', 7);
           ColocarNovaPeca(new Torre(Cor.Preta, Tab), 'e', 7);
           ColocarNovaPeca(new Torre(Cor.Preta, Tab), 'e', 8);
           ColocarNovaPeca(new Rei(Cor.Preta, Tab), 'd', 8);
        }

        private Cor Adversaria(Cor cor)
        {
            return cor == Cor.Branca ? Cor.Preta : Cor.Branca;
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }
       
    }
}
