using tabuleiro;

namespace xadrez
{
    class Torre : Peca // Heranca (Rei eh uma peca)
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) // base repassa os valores para o construtor da classe mae (Peca)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p == null || p.cor != this.cor; // se a casa esta vazia ou se a peca que esta la eh de outra cor
        }

        public override bool[,] MovimentosPossiveis() // override pq precisa sobrescrever o metodo da superclasse
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) // enquanto tiver casa livre e sem inimigo, pode mover
            {
                mat[pos.linha, pos.coluna] = true;
                // se tiver uma peca de cor diferente para o loop
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            // abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) // enquanto tiver casa livre e sem inimigo, pode mover
            {
                mat[pos.linha, pos.coluna] = true;
                // se tiver uma peca de cor diferente para o loop
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            // direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) // enquanto tiver casa livre e sem inimigo, pode mover
            {
                mat[pos.linha, pos.coluna] = true;
                // se tiver uma peca de cor diferente para o loop
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            // esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            while (tab.PosicaoValida(pos) && PodeMover(pos)) // enquanto tiver casa livre e sem inimigo, pode mover
            {
                mat[pos.linha, pos.coluna] = true;
                // se tiver uma peca de cor diferente para o loop
                if (tab.Peca(pos) != null && tab.Peca(pos).cor != this.cor)
                {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            // retorna a matriz de movimentos possiveis
            return mat;
        }
    }
}
