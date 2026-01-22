using Xadrez.PecasXadrez;
using Xadrez.Tabuleiro;
class Tela
{
    // classe de impressão do tabuleiro no console
    public static void ImprimirTabuleiro(Tabuleiro tab)
    {
        for (int i = 0; i < tab.Linhas; i++) // percorre as linhas
        {
            Console.Write(8 - i + " "); // imprime o número da linha
            for (int j = 0; j < tab.Colunas; j++) // percorre as colunas
            {
                if (tab.Peca(i, j) == null) // se não houver peça naquela posição 
                {
                    Console.Write("- ");
                }
                else
                {
                    ImprimirPeca(tab.Peca(i, j)); // imprime a peça
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h"); // imprime as letras das colunas
    }

    public static PosicaoXadrez LerPosicaoXadrez()
    {
        string s = Console.ReadLine();
        char coluna = s[0];
        int linha = int.Parse(s[1] + "");
        return new PosicaoXadrez(coluna, linha);
    }

    public static void ImprimirPeca(Peca peca)
    {
        if (peca.cor == Cor.Branca)
        {
            Console.Write(peca);
        }
        else
        {
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(peca);
            Console.ForegroundColor = aux;
        }
    }

}
