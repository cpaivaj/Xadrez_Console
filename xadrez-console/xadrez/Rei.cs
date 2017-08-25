using tabuleiro;

namespace xadrez
{
    class Rei : Peca // Heranca (Rei eh uma peca)
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor) // base repassa os valores para o construtor da classe mae (Peca)
        {

        }

        public override string ToString()
        {
            return "R";
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
            pos.DefinirValores(pos.linha - 1, pos.coluna);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // diagonal superior direita
            pos.DefinirValores(pos.linha - 1, pos.coluna + 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // direita
            pos.DefinirValores(pos.linha, pos.coluna + 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // diagonal direita inferior
            pos.DefinirValores(pos.linha + 1, pos.coluna + 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // abaixo
            pos.DefinirValores(pos.linha + 1, pos.coluna);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // diagonal inferior esquerda
            pos.DefinirValores(pos.linha + 1, pos.coluna - 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // esquerda
            pos.DefinirValores(pos.linha, pos.coluna - 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // diagonal esquerda superior
            pos.DefinirValores(pos.linha - 1, pos.coluna - 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // retorna a matriz de movimentos possiveis
            return mat;
        }
    }
}
