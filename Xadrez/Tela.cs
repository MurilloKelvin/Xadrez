using Xadrez.PecasXadrez;
using Xadrez.Tabuleiro;
class Tela
{

    public static void ImprimirPartida(partidaXadrez partida)
    {
        ImprimirTabuleiro(partida.tab);
        Console.WriteLine();
        ImprimirPecasCapturadas(partida);
        Console.WriteLine();
        Console.WriteLine("Turno: " + partida.turno);
        Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
    }

    public static void ImprimirPecasCapturadas(partidaXadrez partida) // metodo para imprimir as peças capturadas
    {
        Console.WriteLine("Peças capturadas: ");
        Console.Write("Brancas: ");
        ImprimirConjunto(partida.pecasCapturadas(Cor.Branca)); // imprime as brancas
        Console.WriteLine();

        Console.Write("Pretas: ");
        ConsoleColor aux = Console.ForegroundColor; 
        Console.ForegroundColor = ConsoleColor.Yellow; //deixa o fundo amarelo para as peças pretas
        ImprimirConjunto(partida.pecasCapturadas(Cor.Preta)); // imprime as pretas

        Console.ForegroundColor = aux; // volta a cor original

        Console.WriteLine();
    }

    public static void ImprimirConjunto(HashSet<Peca> conjunto) // metodo para imprimir um conjunto de peças
    {
        Console.Write("[ ");
        foreach (Peca x in conjunto) // percorre o conjunto
        {
            Console.Write(x + " "); // imprime a peça
        }
        Console.Write("]");
    }



    // classe de impressão do tabuleiro no console e leitura de posições (sobrecarga)
    public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
    {

        ConsoleColor fundoDefault = Console.BackgroundColor;
        ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

        for (int i = 0; i < tab.Linhas; i++) // percorre as linhas
        {
            Console.BackgroundColor = fundoDefault;
            Console.Write(8 - i + " "); // imprime o número da linha
            for (int j = 0; j < tab.Colunas; j++) // percorre as colunas
            {
                if (posicoesPossiveis[i, j])
                {
                    Console.BackgroundColor = fundoAlterado;
                }
                else
                {
                    Console.BackgroundColor = fundoDefault;
                }
                ImprimirPeca(tab.Peca(i, j)); // imprime a peça
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h"); // imprime as letras das colunas
    }

    // imprime o tabuleiro padrao
    public static void ImprimirTabuleiro(Tabuleiro tab)
    {
        for (int i = 0; i < tab.Linhas; i++) // percorre as linhas
        {
            Console.Write(8 - i + " "); // imprime o número da linha
            for (int j = 0; j < tab.Colunas; j++) // percorre as colunas
            {
                ImprimirPeca(tab.Peca(i, j)); // imprime a peça
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
        if (peca == null)
        {
            Console.Write("-"); // se não houver peça, imprime um traço
        }
        else
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
        Console.Write(" "); // espaço entre as peças
    }
}
