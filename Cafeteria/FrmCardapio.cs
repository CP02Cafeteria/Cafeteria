using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Cafeteria
{
    public partial class FrmCardapio : Form
    {
        private FlowLayoutPanel painelProdutos;
        private ListBox listaPedido;
        private Label lblTotal;

        private decimal total = 0;

        private readonly Dictionary<string, decimal> produtos = new()
        {
            { "Espresso", 5.00m },
            { "Café com leite", 7.00m },
            { "Cappuccino", 9.00m },
            { "Chocolate quente", 10.00m },
            { "Croissant", 8.00m },
            { "Pão de queijo", 5.00m },
            { "Bolo de chocolate", 10.00m },
            { "Torta de limão", 12.00m }
        };

        public FrmCardapio()
        {
            InitializeComponent();
            MontarCardapio();
        }

        private void MontarCardapio()
        {
            Text = "Cardápio - Cafeteria Sr. Agnello";
            Size = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 232, 212);

            Label titulo = new Label
            {
                Text = "Cafeteria Sr. Agnello",
                Font = new Font("Georgia", 24, FontStyle.Bold),
                ForeColor = Color.SaddleBrown,
                Dock = DockStyle.Top,
                Height = 70,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label subtitulo = new Label
            {
                Text = "Nosso cardápio",
                Font = new Font("Arial", 13),
                ForeColor = Color.SaddleBrown,
                Dock = DockStyle.Top,
                Height = 35,
                TextAlign = ContentAlignment.MiddleCenter
            };

            painelProdutos = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(15),
                BackColor = Color.FromArgb(245, 232, 212)
            };

            Panel painelLateral = new Panel
            {
                Dock = DockStyle.Right,
                Width = 300,
                Padding = new Padding(12),
                BackColor = Color.FromArgb(255, 248, 235)
            };

            Label tituloPedido = new Label
            {
                Text = "Seu pedido",
                Font = new Font("Georgia", 16, FontStyle.Bold),
                ForeColor = Color.SaddleBrown,
                Dock = DockStyle.Top,
                Height = 45,
                TextAlign = ContentAlignment.MiddleCenter
            };

            listaPedido = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Arial", 10),
                IntegralHeight = false
            };

            lblTotal = new Label
            {
                Text = "Total: R$ 0,00",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.SaddleBrown,
                Dock = DockStyle.Bottom,
                Height = 45,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btnLimpar = new Button
            {
                Text = "Limpar pedido",
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.Chocolate,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnLimpar.Click += (s, e) =>
            {
                listaPedido.Items.Clear();
                total = 0;
                AtualizarTotal();
            };

            painelLateral.Controls.Add(listaPedido);
            painelLateral.Controls.Add(tituloPedido);
            painelLateral.Controls.Add(lblTotal);
            painelLateral.Controls.Add(btnLimpar);

            foreach (var produto in produtos)
            {
                Panel card = new Panel
                {
                    Size = new Size(195, 125),
                    BackColor = Color.White,
                    Margin = new Padding(8)
                };

                Label nome = new Label
                {
                    Text = produto.Key,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    ForeColor = Color.SaddleBrown,
                    Location = new Point(10, 15),
                    Size = new Size(175, 30),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label preco = new Label
                {
                    Text = produto.Value.ToString("C2"),
                    Font = new Font("Arial", 12),
                    ForeColor = Color.DarkGreen,
                    Location = new Point(10, 48),
                    Size = new Size(175, 25),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Button adicionar = new Button
                {
                    Text = "Adicionar",
                    Location = new Point(35, 80),
                    Size = new Size(125, 32),
                    BackColor = Color.Chocolate,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                string nomeProduto = produto.Key;
                decimal valorProduto = produto.Value;

                adicionar.Click += (s, e) =>
                {
                    listaPedido.Items.Add(
                        $"{nomeProduto} - {valorProduto:C2}");

                    total += valorProduto;
                    AtualizarTotal();
                };

                card.Controls.Add(nome);
                card.Controls.Add(preco);
                card.Controls.Add(adicionar);

                painelProdutos.Controls.Add(card);
            }

            Controls.Add(painelProdutos);
            Controls.Add(painelLateral);
            Controls.Add(subtitulo);
            Controls.Add(titulo);
        }

        private void AtualizarTotal()
        {
            lblTotal.Text = $"Total: {total:C2}";
        }
    }
}