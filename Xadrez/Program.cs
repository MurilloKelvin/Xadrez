
using Xadrez;
using PecasXadrez;
using Xadrez.Tabuleiro;

Posicao p = new Posicao(0, 0);

Console.WriteLine($"Linha: {p.linha}, Coluna: {p.coluna}");

Tabuleiro tab = new Tabuleiro(8, 8);


try
{
    tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
    tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 4));
    tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 12));

}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}

// Tela.ImprimirTabuleiro(tab);
