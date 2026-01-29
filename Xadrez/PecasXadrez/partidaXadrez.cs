using Xadrez.Tabuleiro;
using Xadrez.PecasXadrez.Pecas;

namespace Xadrez.PecasXadrez
{
    class partidaXadrez
    {
        public Tabuleiro.Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
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

        public void realizaJogada(Posicao origem, Posicao destino) // realiza o movimento e troca o jogador ((SOBRECARGA DO EXEC MOVIMENTO))
        {
            executarMovimento(origem, destino); // move a peça
            turno++;
            TrocaLadoJogador(); // alterna entre os jogadores
        }

        private void TrocaLadoJogador() // alterna entre os jogadores
        {
            if (jogadorAtual == Cor.Branca) // vez do jogador branco
                jogadorAtual = Cor.Preta;
            else
                jogadorAtual = Cor.Branca; // vez do jogador preto

        }

        public void executarMovimento(Posicao origem, Posicao destino) // func auxiliar que executa o movimento -> realizarJogada
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void validarPosicaoDeOrigem(Posicao pos) // valida se a posição de origem é válida
        {
            if (tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida! press enter ");
            }
            if (jogadorAtual != tab.Peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua! press enter");
            }
            if (!tab.Peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida! press enter");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) // valida se a posição de destino é válida
        {
            if (!tab.Peca(origem).movimentosPossiveis()[destino.linha, destino.coluna])
            {
                throw new TabuleiroException("Posição de destino inválida! press enter");
            }

        }
    }
}

