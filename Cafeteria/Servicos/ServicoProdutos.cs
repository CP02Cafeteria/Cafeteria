using Cafeteria.Modelos;

namespace Cafeteria.Servicos
{
    public class ServicoProdutos
    {
        private List<Produto> produtos;

        public ServicoProdutos()
        {
            produtos = new List<Produto>();
            InicializarProdutos();
        }

        private void InicializarProdutos()
        {
            produtos.Add(new Produto(1, "Café Preto", "Café coado tradicional", 3.50m));
            produtos.Add(new Produto(2, "Café com Leite", "Café com leite quente", 4.50m));
            produtos.Add(new Produto(3, "Cappuccino", "Espresso com leite vaporizado e canela", 7.00m));
            produtos.Add(new Produto(4, "Expresso", "Café expresso forte", 4.00m));
            produtos.Add(new Produto(5, "Mocha", "Espresso com chocolate e leite", 7.50m));
            produtos.Add(new Produto(6, "Café Gelado", "Café refrescante gelado", 5.50m));
            produtos.Add(new Produto(7, "Café Macchiato", "Espresso marcado com leite quente", 5.00m));
            produtos.Add(new Produto(8, "Café Americano", "Expresso com água quente", 4.50m));
        }

        public List<Produto> ObterTodos()
        {
            return produtos;
        }

        public Produto ObterPorId(int id)
        {
            return produtos.FirstOrDefault(p => p.Id == id);
        }

        public void AdicionarProduto(Produto produto)
        {
            if (!produtos.Any(p => p.Id == produto.Id))
            {
                produtos.Add(produto);
            }
        }

        public void RemoverProduto(int id)
        {
            var produto = ObterPorId(id);
            if (produto != null)
            {
                produtos.Remove(produto);
            }
        }
    }
}
