using Xadrez.Tabuleiro;

namespace Xadrez.PecasXadrez.Pecas
{
    public class Dama : Peca
    {
        public Dama(Xadrez.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "D";
        }
    }
}
