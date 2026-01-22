using Xadrez.Tabuleiro;

namespace Xadrez.PecasXadrez.Pecas
{
    public class Torre : Peca
    {
        public Torre(Xadrez.Tabuleiro.Tabuleiro tab, Cor cor) : base(tab, cor) // chama o construtor da classe base Peca
        {

        }
        // sobrescreve o método ToString para retornar "T" representando a torre
        public override string ToString()
        {
            return "T";
        }
    }
}