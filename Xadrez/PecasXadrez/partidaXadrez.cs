using Xadrez.Tabuleiro;
using Xadrez.PecasXadrez.Pecas;

namespace Xadrez.PecasXadrez
{
    class partidaXadrez
    {
        public Tabuleiro.Tabuleiro tab { get; private set; }
        private readonly int turno;
        private readonly Cor jogadorAtual;
        public bool terminada { get; private set; }

        public partidaXadrez() 
        {
            tab = new Tabuleiro.Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            colocarPecas();
        }

        private void colocarPecas() // PosicaoXadrez → sempre 1–8
        {
            // peças principais pretas linha 1
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 8).toPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('b', 8).toPosicao());
            tab.colocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new Dama(tab, Cor.Preta), new PosicaoXadrez('d', 8).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new Bispo(tab, Cor.Preta), new PosicaoXadrez('f', 8).toPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Preta), new PosicaoXadrez('g', 8).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('h', 8).toPosicao());

            // peões pretos linha 2
            for (char c = 'a'; c <= 'h'; c++)
            {
                tab.colocarPeca(new Peao(tab, Cor.Preta),
                    new PosicaoXadrez(c, 7).toPosicao());
            }

            // peças principais brancas linha 7
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('a', 1).toPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('b', 1).toPosicao());
            tab.colocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new Dama(tab, Cor.Branca), new PosicaoXadrez('d', 1).toPosicao());
            tab.colocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new Bispo(tab, Cor.Branca), new PosicaoXadrez('f', 1).toPosicao());
            tab.colocarPeca(new Cavalo(tab, Cor.Branca), new PosicaoXadrez('g', 1).toPosicao());
            tab.colocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('h', 1).toPosicao());

            // peões brancos linha 6

            for (char c = 'a'; c <= 'h'; c++)
            {
                tab.colocarPeca(new Peao(tab, Cor.Branca),
                    new PosicaoXadrez(c, 2).toPosicao());
            }
        }

        public void executarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

    }
}

