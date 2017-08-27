namespace tabuleiro
{
    abstract class Peca // eh abstrata pq tem pelo menos um metodo abstrato
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            posicao = null;
            this.tab = tab;
            this.cor = cor;
            qteMovimentos = 0;
        }

        public void IncrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        public void DecrementarQteMovimentos()
        {
            qteMovimentos--;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i<tab.linhas; i++)
            {
                for (int j = 0; j<tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // verificacao se a peca pode ir para o destino escolhido
        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] MovimentosPossiveis(); // metodo abstrato (nao possui implementacao nessa classe)
    }
}
