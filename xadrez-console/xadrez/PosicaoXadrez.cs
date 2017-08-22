using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        public char coluna { get; set; }
        public int linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a'); // Retorna os valores de posicao na forma comum, na programacao eh de cima pra baixo (superior esquerada eh 0,0), na comum eh de baixo para cima (inferior direita eh 0,0)
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
