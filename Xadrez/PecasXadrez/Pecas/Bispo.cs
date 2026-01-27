using Xadrez.Tabuleiro;
namespace Xadrez.PecasXadrez.Pecas
{
    public class Bispo : Peca
    {
        public Bispo(Xadrez.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {
          
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // direita cima
            pos.definirValores(posicao.linha -1, posicao.coluna + 1);
            while (tab.posicaoValida(pos)  && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
            }

            // esquerda cima
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
            }

            // direita baixo
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
            }

            // esquerda baixo
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
