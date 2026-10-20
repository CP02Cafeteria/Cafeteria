using Cafeteria.Modelos;

namespace Cafeteria.Servicos
{
    public class ServicoVendas
    {
        private List<Venda> vendas;
        private int proximoIdVenda = 1;

        public ServicoVendas()
        {
            vendas = new List<Venda>();
        }

        public Venda CriarVenda()
        {
            var venda = new Venda(proximoIdVenda);
            proximoIdVenda++;
            return venda;
        }

        public void SalvarVenda(Venda venda)
        {
            if (venda.Itens.Count > 0)
            {
                vendas.Add(venda);
            }
        }

        public List<Venda> ObterTodas()
        {
            return vendas;
        }

        public List<Venda> ObterVendasPorData(DateTime data)
        {
            return vendas.Where(v => v.DataVenda.Date == data.Date).ToList();
        }

        public Venda ObterPorId(int id)
        {
            return vendas.FirstOrDefault(v => v.Id == id);
        }

        public decimal ObterTotalVendas()
        {
            return vendas.Sum(v => v.ValorTotal);
        }

        public int ObterQuantidadeVendas()
        {
            return vendas.Count;
        }
    }
}
