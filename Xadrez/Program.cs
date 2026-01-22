
using Xadrez;
using Xadrez.PecasXadrez;
using Xadrez.Tabuleiro;
using Xadrez.PecasXadrez;

try
{
    partidaXadrez partida = new partidaXadrez();
    
    while (!partida.terminada)
    {
        Console.Clear();
        Tela.ImprimirTabuleiro(partida.tab);


        Console.WriteLine("Digite a posiçao de origem: ");
        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
        Console.WriteLine("Digite a posiçao de destino: ");
        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
        partida.executarMovimento(origem, destino);

    }



}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}



