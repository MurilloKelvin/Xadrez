using Xadrez.Tabuleiro;

namespace Xadrez.PecasXadrez.Pecas
{
    public class Peao : Peca
    {
        public Peao(Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            int direcao = cor == Cor.Branca ? -1 : 1; // brancas sobem, pretas descem

            // pra frente
            pos.definirValores(posicao.linha + direcao, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            //diagonal esquerda
            pos.definirValores(posicao.linha + direcao, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos) && tab.Peca(pos) != null) // se for diferente da cor do peao pode capturar
                mat[pos.linha, pos.coluna] = true;

            //diagonal direita
            pos.definirValores(posicao.linha + direcao, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos) && tab.Peca(pos) != null)
                mat[pos.linha, pos.coluna] = true;


            // primeira jogada
            pos.definirValores(posicao.linha + 2 * direcao, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos) && qteMovimentos == 0) 
                mat[pos.linha, pos.coluna] = true;


            return mat;

        }

        public override string ToString()
        {
            return "P";
        }
    }
}