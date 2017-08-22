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
    }
}
