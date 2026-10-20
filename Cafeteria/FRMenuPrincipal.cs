using System;
using System.Drawing;
using System.Windows.Forms;
using Cafeteria.Servicos;

namespace Cafeteria
{
    public class FrmMenuPrincipal : Form
    {
        private ServicoVendas servicoVendas;
        private ServicoProdutos servicoProdutos;

        public FrmMenuPrincipal(ServicoVendas servicoVendas, ServicoProdutos servicoProdutos)
        {
            this.servicoVendas = servicoVendas;
            this.servicoProdutos = servicoProdutos;

            // Configurações da janela
            Text = "Cafeteria Dev - Menu Principal";
            Size = new Size(500, 530);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(40, 40, 40);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "Cafeteria Dev";
            lblTitulo.Font = new Font("Arial", 24, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Size = new Size(460, 60);
            lblTitulo.Location = new Point(10, 30);

            // Botão Nova Venda
            Button btnNovaVenda = new Button();
            btnNovaVenda.Text = "Nova Venda";
            btnNovaVenda.Size = new Size(250, 50);
            btnNovaVenda.Location = new Point(115, 130);
            btnNovaVenda.BackColor = Color.SaddleBrown;
            btnNovaVenda.ForeColor = Color.White;
            btnNovaVenda.Font = new Font("Arial", 12);
            btnNovaVenda.FlatStyle = FlatStyle.Flat;
            btnNovaVenda.FlatAppearance.BorderSize = 0;
            btnNovaVenda.Cursor = Cursors.Hand;

            // Botão Relatório de Vendas
            Button btnRelatorioVendas = new Button();
            btnRelatorioVendas.Text = "Relatório de Vendas";
            btnRelatorioVendas.Size = new Size(250, 50);
            btnRelatorioVendas.Location = new Point(115, 200);
            btnRelatorioVendas.BackColor = Color.SaddleBrown;
            btnRelatorioVendas.ForeColor = Color.White;
            btnRelatorioVendas.Font = new Font("Arial", 12);
            btnRelatorioVendas.FlatStyle = FlatStyle.Flat;
            btnRelatorioVendas.FlatAppearance.BorderSize = 0;
            btnRelatorioVendas.Cursor = Cursors.Hand;

            // Botão Cardápio
            Button btnCardapio = new Button();
            btnCardapio.Text = "Cardápio";
            btnCardapio.Size = new Size(250, 50);
            btnCardapio.Location = new Point(115, 270);
            btnCardapio.BackColor = Color.SaddleBrown;
            btnCardapio.ForeColor = Color.White;
            btnCardapio.Font = new Font("Arial", 12);
            btnCardapio.FlatStyle = FlatStyle.Flat;
            btnCardapio.FlatAppearance.BorderSize = 0;
            btnCardapio.Cursor = Cursors.Hand;

            // Botão Sair
            Button btnSair = new Button();
            btnSair.Text = "Sair";
            btnSair.Size = new Size(250, 50);
            btnSair.Location = new Point(115, 340);
            btnSair.BackColor = Color.DarkRed;
            btnSair.ForeColor = Color.White;
            btnSair.Font = new Font("Arial", 12);
            btnSair.FlatStyle = FlatStyle.Flat;
            btnSair.FlatAppearance.BorderSize = 0;
            btnSair.Cursor = Cursors.Hand;

            // Evento: Nova Venda
            btnNovaVenda.Click += (sender, e) =>
            {
                FrmVenda telaVenda = new FrmVenda(servicoVendas, servicoProdutos);
                telaVenda.ConfigurarInterface();
                telaVenda.ShowDialog(this);
            };

            // Evento: Relatório de Vendas
            btnRelatorioVendas.Click += (sender, e) =>
            {
                FrmRelatorioVendas telaRelatorio = new FrmRelatorioVendas(servicoVendas);
                telaRelatorio.ConfigurarInterface();
                telaRelatorio.ShowDialog(this);
            };

            // Evento: Cardápio
            btnCardapio.Click += (sender, e) =>
            {
                using (FrmCardapio telaCardapio = new FrmCardapio())
                {
                    telaCardapio.ShowDialog(this);
                }
            };

            // Evento: Sair
            btnSair.Click += (sender, e) =>
            {
                Close();
            };

            // Adiciona os controles à janela
            Controls.Add(lblTitulo);
            Controls.Add(btnNovaVenda);
            Controls.Add(btnRelatorioVendas);
            Controls.Add(btnCardapio);
            Controls.Add(btnSair);
        }
    }
}
