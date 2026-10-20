namespace Cafeteria.Modelos
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime DataVenda { get; set; }
        public List<ItemVenda> Itens { get; set; }
        public decimal ValorTotal => Itens.Sum(item => item.ValorTotal);

        public Venda(int id)
        {
            Id = id;
            DataVenda = DateTime.Now;
            Itens = new List<ItemVenda>();
        }

        public void AdicionarItem(ItemVenda item)
        {
            Itens.Add(item);
        }

        public void RemoverItem(ItemVenda item)
        {
            Itens.Remove(item);
        }

        public override string ToString()
        {
            return $"Venda #{Id} - {DataVenda:dd/MM/yyyy HH:mm:ss} - R$ {ValorTotal:F2}";
        }
    }
}
