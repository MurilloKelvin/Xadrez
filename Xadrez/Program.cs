
using Xadrez;
using PecasXadrez;
using Xadrez.Tabuleiro;
using Xadrez.PecasXadrez;

Posicao p = new Posicao(0, 0);

Console.WriteLine($"Linha: {p.linha}, Coluna: {p.coluna}");

Tabuleiro tab = new Tabuleiro(8, 8);

tab.colocarPeca(new Rei (tab, Cor.Preta), new Posicao(0, 4));
tab.colocarPeca(new Torre (tab, Cor.Preta), new Posicao(0, 0));
tab.colocarPeca(new Torre (tab, Cor.Branca), new Posicao(0, 7));

PosicaoXadrez posXadrez = new PosicaoXadrez('b', 3);

Console.WriteLine(posXadrez.toPosicao());

Console.WriteLine(posXadrez);

Tela.ImprimirTabuleiro(tab);

