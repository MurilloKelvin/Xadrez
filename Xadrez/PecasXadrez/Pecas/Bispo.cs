using Xadrez.Tabuleiro;
namespace Xadrez.PecasXadrez.Pecas
{
    public class Bispo : Peca
    {
        public Bispo(Xadrez.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor)
        {
          
        }

        public override string ToString()
        {
            return "B";
        }
    }
}
