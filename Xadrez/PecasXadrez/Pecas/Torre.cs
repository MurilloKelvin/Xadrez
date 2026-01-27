using Xadrez.Tabuleiro;

namespace Xadrez.PecasXadrez.Pecas
{
    public class Torre : Peca
    {
        public Torre(Xadrez.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor) // chama o construtor da classe base Peca
        {

        }

        // sobrescreve o método ToString para retornar "T" representando a torre
        public override string ToString()
        {
            return "T";
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor) // para se tiver uma peça adversaria e se pode capturar
                {
                    break;
                }
                pos.linha = pos.linha + 1; // continua subindo 
            }

            // baixo
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor) // para se tiver uma peça adversaria e se pode capturar
                {
                    break;
                }
                pos.linha = pos.linha - 1; // continua descendo
            }


            // direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1; // continua indo para direita
            }

            // esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1; // continua indo para esquerda
            }

            return mat;
        }


      
    }
}