using Xadrez.Tabuleiro;

namespace PecasXadrez
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) // chama o construtor da classe base Peca
        {

        }

        // sobrescreve o método ToString para retornar "R" representando o rei
        public override string ToString()
        {
            return "R";
        }
    }
}
