using FSharp.Compiler.Text;
using Xadrez.Tabuleiro;
using Xadrez.PecasXadrez;

namespace Xadrez.PecasXadrez.Pecas
{
    public class Rei : Peca
    {

        private partidaXadrez partida;
        public Rei(Xadrez.Tabuleiro.Tabuleiro tab,partidaXadrez partida, Cor cor) : base(tab, cor) // chama o construtor da classe base Peca
        {
            this.partida = partida;
        }

        // sobrescreve o método ToString para retornar "R" representando o rei
        public override string ToString()
        {
            return "R";
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            mat[pos.linha, pos.coluna] = true;
    

            // direita cima
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            mat[pos.linha, pos.coluna] = true;


            // direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            mat[pos.linha, pos.coluna] = true;

            // direita baixo
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            mat[pos.linha, pos.coluna] = true;

            // abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            mat[pos.linha, pos.coluna] = true;

            // esquerda baixo
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            mat[pos.linha, pos.coluna] = true;

            // esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            mat[pos.linha, pos.coluna] = true;

            // esquerda cima
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            mat[pos.linha, pos.coluna] = true;


            // #jogada especial roque
            if (qteMovimentos ==0 && !partida.xeque)
            {
                // #jogada especial roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3); // torre lado rei
                if (testeTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1); // +1 pra esquerda do rei
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2); // +2 pra esquerda do rei
                    if (tab.Peca(p1) == null && tab.Peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

            }
            // #jogada especial roque grande
            if (qteMovimentos ==0 && !partida.xeque)
            {
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4); // 4 posiçoes pra esquerda tem q estar a torre preta
                if (testeTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1); // -1 pra esquerda do rei
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2); // -2 pra esquerda do rei
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3); // -3 pra esquerda do rei
                    if (tab.Peca(p1) == null && tab.Peca(p2) == null && tab.Peca(p3) == null)
                    { 

                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }


            return mat;
        }


    }
}
