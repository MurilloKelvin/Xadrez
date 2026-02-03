using Xadrez.Tabuleiro;

namespace Xadrez.PecasXadrez.Pecas
{
    public class Peao : Peca
    {
        public Peao(Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            int direcao = cor == Cor.Branca ? -1 : 1;

            // frente 1 casa: precisa estar vazia
            pos.definirValores(posicao.linha + direcao, posicao.coluna);
            if (tab.posicaoValida(pos) && tab.Peca(pos) == null)
                mat[pos.linha, pos.coluna] = true;

            // frente 2 casas no primeiro movimento: ambas vazias
            Posicao intermediaria = new Posicao(posicao.linha + direcao, posicao.coluna); //garante q o peao nao pule uma peça
            pos.definirValores(posicao.linha + 2 * direcao, posicao.coluna);
            if (qteMovimentos == 0 &&
                tab.posicaoValida(intermediaria) && tab.Peca(intermediaria) == null && // verifica a casa intermediaria
                tab.posicaoValida(pos) && tab.Peca(pos) == null) // verifica a casa final
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // captura diagonal esquerda
            pos.definirValores(posicao.linha + direcao, posicao.coluna - 1);
            if (tab.posicaoValida(pos))
            {
                Peca alvo = tab.Peca(pos);
                if (alvo != null && alvo.cor != cor)
                    mat[pos.linha, pos.coluna] = true;
            }

            // captura diagonal direita
            pos.definirValores(posicao.linha + direcao, posicao.coluna + 1);
            if (tab.posicaoValida(pos))
            {
                Peca alvo = tab.Peca(pos);
                if (alvo != null && alvo.cor != cor)
                    mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }

        public override string ToString() => "P";
    }
}