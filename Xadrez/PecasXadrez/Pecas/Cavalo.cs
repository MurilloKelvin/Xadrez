using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Tabuleiro;

namespace Xadrez.PecasXadrez.Pecas
{
public class Cavalo : Peca
    {
        public Cavalo(Xadrez.Tabuleiro.Tabuleiro tab, Cor cor) : base (tab, cor)
        { 

        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.Linhas, tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            int direcao = cor == Cor.Branca ? -1 : 1; // brancas sobem, pretas descem

            // acima direita
            pos.definirValores(posicao.linha - 2 * direcao, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;


            // acima esquerda
            pos.definirValores(posicao.linha - 2 * direcao, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;
            

            // pra direita acima
            pos.definirValores(posicao.linha - 1 + direcao, posicao.coluna + 2);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // pra esquerda acima
            pos.definirValores(posicao.linha - 1 + direcao, posicao.coluna - 2);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;


            // abaixo direita
            pos.definirValores(posicao.linha + 2 * direcao, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // abaixo esquerda
            pos.definirValores(posicao.linha + 2 * direcao, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // pra direita abaixo
            pos.definirValores(posicao.linha +1 + direcao, posicao.coluna + 2);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;

            // pra esquerda abaixo
            pos.definirValores(posicao.linha + 1 + direcao, posicao.coluna - 2);
            if (tab.posicaoValida(pos) && podeMover(pos))
                mat[pos.linha, pos.coluna] = true;



            return mat;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
