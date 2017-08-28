using tabuleiro;

namespace xadrez
{
    class Rei : Peca // Heranca (Rei eh uma peca)
    {
        private PartidaDeXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor) // base repassa os valores para o construtor da classe mae (Peca)
        {
            this.partida = partida;
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

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = tab.Peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis() // override pq precisa sobrescrever o metodo da superclasse
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // diagonal superior direita
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // diagonal direita inferior
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // diagonal inferior esquerda
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // diagonal esquerda superior
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            // verifica se pode mover e se eh valido
            if (tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            // # JogadaEspecial - Roque
            // se o rei ainda nao se moveu e nao esta em xeque, pode fazer a jogada de roque
            if (qteMovimentos == 0 && !partida.xeque)
            {
                // # Jogada especial - Roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3); // posT1 eh a posicao da torre
                // se a torre esta elegivel para o roque
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    // se as casas esiverem livres
                    if (tab.Peca(p1) == null && tab.Peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                // # Jogada especial - Roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4); // posT2 eh a posicao da torre
                // se a torre esta elegivel para o roque
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    // se as casas estiverem livres
                    if (tab.Peca(p1) == null && tab.Peca(p2) == null && tab.Peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }


            // retorna a matriz de movimentos possiveis
            return mat;
        }
    }
}
