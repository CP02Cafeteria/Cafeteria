using System;
using System.Windows.Forms;
using Cafeteria.Servicos;

namespace Cafeteria
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Criar instâncias dos serviços (Singleton para compartilhar dados)
            var servicoProdutos = new ServicoProdutos();
            var servicoVendas = new ServicoVendas();

            // Executar aplicação passando os serviços
            Application.Run(new FrmMenuPrincipal(servicoVendas, servicoProdutos));
        }
    }
}