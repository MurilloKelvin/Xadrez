
using Xadrez;
using PecasXadrez;
using Xadrez.Tabuleiro;
using Xadrez.PecasXadrez;

try
{
    partidaXadrez partida = new partidaXadrez();
    Tela.ImprimirTabuleiro(partida.tab);


}
catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}



