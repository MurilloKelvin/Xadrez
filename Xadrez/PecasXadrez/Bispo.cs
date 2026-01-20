using Xadrez.Tabuleiro;

namespace PecasXadrez
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
          
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
