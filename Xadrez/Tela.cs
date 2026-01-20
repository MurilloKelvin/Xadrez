using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.Write(tab.Peca(i, j) + " "); // imprime a peça
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("  a b c d e f g h"); // imprime as letras das colunas
    }
}
