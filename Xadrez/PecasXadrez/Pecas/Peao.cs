using Xadrez.Tabuleiro;

namespace Xadrez.PecasXadrez.Pecas
{
    public class Peao : Peca
    {
        public Peao(Xadrez.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "P";
        }
    }
}