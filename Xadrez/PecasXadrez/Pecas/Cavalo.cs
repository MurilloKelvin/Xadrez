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

        public override string ToString()
        {
            return "C";
        }
    }
}
