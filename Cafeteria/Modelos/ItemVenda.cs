namespace Cafeteria.Modelos
{
    public class ItemVenda
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal => Quantidade * ValorUnitario;

        public ItemVenda(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
            ValorUnitario = produto.Preco;
        }

        public override string ToString()
        {
            return $"{Produto.Nome} x{Quantidade} = R$ {ValorTotal:F2}";
        }
    }
}
