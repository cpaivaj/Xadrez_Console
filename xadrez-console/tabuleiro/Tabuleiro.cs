namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        // Para controlar quais pecas serao exibidas
        public Peca Peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        // Coloca uma peca na posicao especificada
        public void ColocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p; // a posicao recebe a peca
            p.posicao = pos; // atualiza a posicao da peca p
        }
    }
}
