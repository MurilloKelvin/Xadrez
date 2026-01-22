using Xadrez.Tabuleiro;

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
    }
}
