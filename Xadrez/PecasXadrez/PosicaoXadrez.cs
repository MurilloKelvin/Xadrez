using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Tabuleiro;

namespace Xadrez.PecasXadrez
{
    class PosicaoXadrez
    {

        public  int coluna { get; set; }
        public  int linha { get; set; }

        public PosicaoXadrez(int coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }



        public void definirPosicao(int linha, int coluna )
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        public Posicao toPosicao()
        {
                       return new Posicao(8 - linha, coluna - 'a'); // converte a posicao do xadrez para a posicao do tabuleiro 
        }


        public override string ToString()
        {
            return "" + coluna + linha;
        }

    }
}
