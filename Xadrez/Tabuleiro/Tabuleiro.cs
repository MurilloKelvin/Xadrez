using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Tabuleiro
{
    // classe que representa o tabuleiro do jogo
    public class Tabuleiro(int linhas, int colunas)
    {
        public int Linhas { get; set; } = linhas;
        public int Colunas { get; set; } = colunas;
        private Peca[,] pecas = new Peca[linhas, colunas];

        public Peca Peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }


        public Peca Peca(Posicao pos) // sobrecarga do metodo Peca para receber uma posicao

        {
            return pecas[pos.linha, pos.coluna];
        }

        public void colocarPeca(Peca p, Posicao pos) // metodo para colocar uma peca no tabuleiro
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;

        }


        public bool existePeca(Posicao pos) // metodo para verificar se existe uma peca na posicao
        {
            validarPosicao(pos);
            return Peca(pos) != null;
        }

        public bool posicaoValida(Posicao pos) // metodo para verificar se a posicao e valida
        {
            if (pos.linha < 0 || pos.linha >= Linhas || pos.coluna < 0 || pos.coluna >= Colunas) // >= porque o array começa em 0 entao 00 ate 77
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos) // metodo para validar a posicao
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }


        }
    }
}
