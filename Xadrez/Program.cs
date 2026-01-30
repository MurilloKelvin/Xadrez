
using Xadrez;
using Xadrez.PecasXadrez;
using Xadrez.Tabuleiro;

try
{
    partidaXadrez partida = new partidaXadrez();  // console travando por conta das peças que nao foram implementadas e ficam com o movimentoPossiveis em todo o tabuleiro ********************************

    while (!partida.terminada)
    {
        try
        {
            Console.Clear();
            Tela.ImprimirPartida(partida); // imprime o estado atual da partida


            Console.Write("Digite a posiçao de origem: ");
            Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

            partida.validarPosicaoDeOrigem(origem);

            bool[,] posicoesPossiveis = partida.tab.Peca(origem).movimentosPossiveis(); // matriz de movimentos possíveis visiveis no tabuleiro


            Console.Clear();
            Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis); // imprime o tabuleiro com os movimentos possíveis destacados


            Console.Write("Digite a posiçao de destino: ");
            Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDeDestino(origem, destino); // valida a posiçao de destino

            partida.realizaJogada(origem, destino); // realiza a jogada

        }
        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("Aperte qualquer tecla pra continuar");
            Console.ReadKey();
        }



    }
}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}



