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
        private HashSet<Peca> pecasNoTabuleiro; // conjunto de peças no tabuleiro
        private HashSet<Peca> Capturadas;


        public partidaXadrez()
        {
            tab = new Tabuleiro.Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;

           pecasNoTabuleiro = new HashSet<Peca>(); // conjunto de peças no tabuleiro
           Capturadas = new HashSet<Peca>(); // conjunto de peças capturadas

            colocarPecas();
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) // retorna as peças capturadas de uma cor específica
        {
            HashSet<Peca> aux = new HashSet<Peca>(); // conjunto auxiliar
            foreach (Peca p in Capturadas) // percorre as peças capturadas
            {
                if (p.cor == cor) // se a cor da peça for igual a cor passada no parametro 
                {
                    aux.Add(p); // adiciona a peça ao conjunto auxiliar sem modificar o conjunto original "Capturadas"
                }
            }
            return aux; // retorna o conjunto auxiliar para fim de exibição
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) // retorna as peças em jogo de uma cor específica
        {
            HashSet<Peca> aux = new HashSet<Peca>(); // conjunto auxiliar
            foreach (Peca p in pecasNoTabuleiro) // percorre as peças no tabuleiro
            {
                if (p.cor == cor) // se a cor da peça for igual a cor passada no parametro 
                {
                    aux.Add(p); // adiciona a peça ao conjunto auxiliar sem modificar o conjunto original "pecasNoTabuleiro"
                }
            }
            aux.ExceptWith(pecasCapturadas(cor)); // remove as peças capturadas da mesma cor do conjunto auxiliar
            return aux; // retorna o conjunto auxiliar para fim de exibição sem as peças capturadas
        }


        public void colocarNovaPeca(char coluna, int linha, Peca peca) // metodo auxiliar para colocar peças no tabuleiro 
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecasNoTabuleiro.Add(peca);
        }

        private void colocarPecas() // PosicaoXadrez → sempre 1–8 metodo pra colocar as peças na posição inicial
        {
            // peças principais pretas linha 1
            colocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            colocarNovaPeca('b', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('c', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('d', 8, new Dama(tab, Cor.Preta));
            colocarNovaPeca('e', 8, new Rei(tab, Cor.Preta));
            colocarNovaPeca('f', 8, new Bispo(tab, Cor.Preta));
            colocarNovaPeca('g', 8, new Cavalo(tab, Cor.Preta));
            colocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));

            // peões pretos linha 2
            for (char c = 'a'; c <= 'h'; c++)
            {
                colocarNovaPeca(c, 7, new Peao(tab, Cor.Preta));
            }

            // peças principais brancas linha 7
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Dama(tab, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(tab, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(tab, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(tab, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));

            // peões brancos linha 6

            for (char c = 'a'; c <= 'h'; c++)
            {
                colocarNovaPeca(c, 2, new Peao(tab, Cor.Branca));
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

            if(!(pecaCapturada == null))
            {
                pecasNoTabuleiro.Remove(pecaCapturada);
                Capturadas.Add(pecaCapturada);
            }
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

