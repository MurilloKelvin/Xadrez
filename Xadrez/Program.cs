using Xadrez.Tabuleiro;

Posicao p = new Posicao(3, 4);

Console.WriteLine($"Linha: {p.linha}, Coluna: {p.coluna}");

Tabuleiro tab = new Tabuleiro(8, 8);

Tela.ImprimirTabuleiro(tab);