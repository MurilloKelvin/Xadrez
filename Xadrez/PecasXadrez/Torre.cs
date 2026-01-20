using Xadrez.Tabuleiro;

namespace PecasXadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) // chama o construtor da classe base Peca
        {

        }
        // sobrescreve o método ToString para retornar "T" representando a torre
        public override string ToString()
        {
            return "T";
        }
    }
}