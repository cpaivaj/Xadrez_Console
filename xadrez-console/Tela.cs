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
                for (int j=0; j<tab.colunas; j++)
                {
                    // verifica se tem peca pra imprimir, se nao tiver, imprime so tracos
                    if(tab.Peca(i,j)==null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.Peca(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
