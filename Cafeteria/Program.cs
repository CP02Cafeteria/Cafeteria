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

            using (FrmSplash splash = new FrmSplash())
            {
                splash.ShowDialog();
            }

            var servicoProdutos = new ServicoProdutos();
            var servicoVendas = new ServicoVendas();

            Application.Run(
                new FrmMenuPrincipal(servicoVendas, servicoProdutos)
            );
        }
    }
}