using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    // Movimentacao
                    Console.WriteLine();
                    Console.Write("Origem: "); // qual a peca
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();

                    // pega as posicoes possiveis da peca de origem que foi selecionada
                    bool[,] posicoesPossiveis = partida.tab.Peca(origem).MovimentosPossiveis();

                    // imprime tabuleiro com as posicoes de movimentacao possiveis marcadas
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: "); // pra onde vai
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }

                Tela.ImprimirTabuleiro(partida.tab);
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
