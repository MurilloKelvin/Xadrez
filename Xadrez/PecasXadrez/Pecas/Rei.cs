using FSharp.Compiler.Text;
using Xadrez.Tabuleiro;
using Xadrez.PecasXadrez;

namespace Xadrez.PecasXadrez.Pecas
{
    public class Rei : Peca
    {
        public Rei(Xadrez.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor) // chama o construtor da classe base Peca
        {

        }

        // sobrescreve o método ToString para retornar "R" representando o rei
        public override string ToString()
        {
            return "R";
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

            return mat;
        }


    }
}
