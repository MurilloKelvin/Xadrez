using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez.Tabuleiro
{
    // classe que representa uma posição no tabuleiro
    public class Posicao
    {
        public int linha { get; set; }
        public int coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        // sobrescreve o método ToString para exibir a posição no formato "linha, coluna"
        public override string ToString() 
        {
            return linha + ", " + coluna;
        }
    }
}
