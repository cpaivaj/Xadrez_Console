using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            // impressao do tabuleiro com as pecas
            for (int i=0; i<tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j=0; j<tab.colunas; j++)
                {
                    // verifica se tem peca pra imprimir, se nao tiver, imprime so tracos
                    if(tab.Peca(i,j)==null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor; // armazena a cor atual
                Console.ForegroundColor = ConsoleColor.Yellow; // muda a cor para amarelo
                Console.Write(peca);  // imprime a peca na cor amarela
                Console.ForegroundColor = aux; // volta pra cor original
            }
        }
    }
}
