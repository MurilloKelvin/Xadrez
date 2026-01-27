
using Xadrez;
using Xadrez.PecasXadrez;
using Xadrez.Tabuleiro;

try
{
    partidaXadrez partida = new partidaXadrez();
    
    while (!partida.terminada)
    {
        Console.Clear();
        Tela.ImprimirTabuleiro(partida.tab);


        Console.WriteLine("Digite a posiçao de origem: ");
        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

        bool[,] posicoesPossiveis = partida.tab.Peca(origem).movimentosPossiveis(); // matriz de movimentos possíveis visiveis no tabuleiro


        Console.Clear();
        Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);


        Console.WriteLine("Digite a posiçao de destino: ");
        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
        partida.executarMovimento(origem, destino);

    }



}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}



