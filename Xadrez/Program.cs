
using Xadrez;
using PecasXadrez;
using Xadrez.Tabuleiro;
using Xadrez.PecasXadrez;

Posicao p = new Posicao(0, 0);

Console.WriteLine($"Linha: {p.linha}, Coluna: {p.coluna}");

Tabuleiro tab = new Tabuleiro(8, 8);


PosicaoXadrez posXadrez = new PosicaoXadrez('a', 1);

Console.WriteLine(posXadrez.toPosicao());

Console.WriteLine(posXadrez);

Tela.ImprimirTabuleiro(tab);

