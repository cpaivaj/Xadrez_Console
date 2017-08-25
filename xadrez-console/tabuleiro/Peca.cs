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
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qteMovimentos = 0;
        }

        public void IncrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        public abstract bool[,] MovimentosPossiveis(); // metodo abstrato (nao possui implementacao nessa classe)
    }
}
