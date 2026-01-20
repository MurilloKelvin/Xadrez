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
    }
}
