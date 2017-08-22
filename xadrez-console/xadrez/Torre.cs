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
    }
}
