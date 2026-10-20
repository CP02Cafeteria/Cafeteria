using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cafeteria.Modelos;
using Cafeteria.Servicos;

namespace Cafeteria
{
    public partial class FrmVenda : Form
    {
        private ServicoProdutos servicoProdutos;
        private ServicoVendas servicoVendas;
        private Venda vendaAtual;
        private List<ItemVenda> carrinhoAtual;

        public FrmVenda(ServicoVendas servicoVendas, ServicoProdutos servicoProdutos)
        {
            InitializeComponent();
            this.servicoVendas = servicoVendas;
            this.servicoProdutos = servicoProdutos;
            this.carrinhoAtual = new List<ItemVenda>();
            this.vendaAtual = null;
        }

        public void ConfigurarInterface()
        {
            this.Text = "Venda de Café";
            this.Size = new Size(1000, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Label Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "Nova Venda";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(200, 30);

            // Label Produtos
            Label lblProdutos = new Label();
            lblProdutos.Text = "Produtos Disponíveis";
            lblProdutos.Font = new Font("Arial", 10, FontStyle.Bold);
            lblProdutos.ForeColor = Color.White;
            lblProdutos.Location = new Point(20, 60);
            lblProdutos.Size = new Size(200, 20);

            // DataGridView Produtos
            DataGridView dgvProdutos = new DataGridView();
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Location = new Point(20, 85);
            dgvProdutos.Size = new Size(450, 250);
            dgvProdutos.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvProdutos.ForeColor = Color.White;
            dgvProdutos.GridColor = Color.Black;

            // Configurar estilo padrão das células
            DataGridViewCellStyle estiloConversa = new DataGridViewCellStyle();
            estiloConversa.BackColor = Color.FromArgb(40, 40, 40);
            estiloConversa.ForeColor = Color.White;
            dgvProdutos.DefaultCellStyle = estiloConversa;

            dgvProdutos.ColumnHeadersDefaultCellStyle.BackColor = Color.SaddleBrown;
            dgvProdutos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProdutos.ColumnHeadersHeight = 25;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.ReadOnly = true;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.RowTemplate.Height = 25;

            dgvProdutos.Columns.Add("Id", "ID");
            dgvProdutos.Columns.Add("Nome", "Produto");
            dgvProdutos.Columns.Add("Descricao", "Descrição");
            dgvProdutos.Columns.Add("Preco", "Preço");

            CarregarProdutos(dgvProdutos);

            // Label Quantidade
            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade:";
            lblQuantidade.Font = new Font("Arial", 10);
            lblQuantidade.ForeColor = Color.White;
            lblQuantidade.Location = new Point(20, 355);
            lblQuantidade.Size = new Size(100, 20);

            // NumericUpDown Quantidade
            NumericUpDown nudQuantidade = new NumericUpDown();
            nudQuantidade.Name = "nudQuantidade";
            nudQuantidade.Location = new Point(130, 355);
            nudQuantidade.Size = new Size(80, 30);
            nudQuantidade.Minimum = 1;
            nudQuantidade.Maximum = 100;
            nudQuantidade.Value = 1;

            // Botão Adicionar ao Carrinho
            Button btnAdicionarCarrinho = new Button();
            btnAdicionarCarrinho.Text = "Adicionar ao Carrinho";
            btnAdicionarCarrinho.Location = new Point(220, 355);
            btnAdicionarCarrinho.Size = new Size(150, 30);
            btnAdicionarCarrinho.BackColor = Color.SaddleBrown;
            btnAdicionarCarrinho.ForeColor = Color.White;
            btnAdicionarCarrinho.FlatStyle = FlatStyle.Flat;
            btnAdicionarCarrinho.Cursor = Cursors.Hand;
            btnAdicionarCarrinho.Click += (sender, e) => AdicionarAoCarrinho(dgvProdutos, nudQuantidade);

            // Label Carrinho
            Label lblCarrinho = new Label();
            lblCarrinho.Text = "Carrinho";
            lblCarrinho.Font = new Font("Arial", 10, FontStyle.Bold);
            lblCarrinho.ForeColor = Color.White;
            lblCarrinho.Location = new Point(510, 60);
            lblCarrinho.Size = new Size(100, 20);

            // DataGridView Carrinho
            DataGridView dgvCarrinho = new DataGridView();
            dgvCarrinho.Name = "dgvCarrinho";
            dgvCarrinho.Location = new Point(510, 85);
            dgvCarrinho.Size = new Size(460, 250);
            dgvCarrinho.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvCarrinho.ForeColor = Color.White;
            dgvCarrinho.GridColor = Color.Black;

            DataGridViewCellStyle estiloCarrinho = new DataGridViewCellStyle();
            estiloCarrinho.BackColor = Color.FromArgb(40, 40, 40);
            estiloCarrinho.ForeColor = Color.White;
            dgvCarrinho.DefaultCellStyle = estiloCarrinho;

            dgvCarrinho.ColumnHeadersDefaultCellStyle.BackColor = Color.SaddleBrown;
            dgvCarrinho.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCarrinho.ColumnHeadersHeight = 25;
            dgvCarrinho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCarrinho.AllowUserToAddRows = false;
            dgvCarrinho.ReadOnly = true;
            dgvCarrinho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrinho.RowTemplate.Height = 25;

            dgvCarrinho.Columns.Add("Produto", "Produto");
            dgvCarrinho.Columns.Add("Quantidade", "Qtd");
            dgvCarrinho.Columns.Add("ValorUnitario", "Preço Unitário");
            dgvCarrinho.Columns.Add("ValorTotal", "Total");

            // Botão Remover do Carrinho
            Button btnRemoverCarrinho = new Button();
            btnRemoverCarrinho.Text = "Remover";
            btnRemoverCarrinho.Location = new Point(510, 355);
            btnRemoverCarrinho.Size = new Size(100, 30);
            btnRemoverCarrinho.BackColor = Color.DarkRed;
            btnRemoverCarrinho.ForeColor = Color.White;
            btnRemoverCarrinho.FlatStyle = FlatStyle.Flat;
            btnRemoverCarrinho.Cursor = Cursors.Hand;
            btnRemoverCarrinho.Click += (sender, e) => RemoverDoCarrinho(dgvCarrinho);

            // Botão Limpar Carrinho
            Button btnLimparCarrinho = new Button();
            btnLimparCarrinho.Text = "Limpar";
            btnLimparCarrinho.Location = new Point(620, 355);
            btnLimparCarrinho.Size = new Size(100, 30);
            btnLimparCarrinho.BackColor = Color.DarkOrange;
            btnLimparCarrinho.ForeColor = Color.White;
            btnLimparCarrinho.FlatStyle = FlatStyle.Flat;
            btnLimparCarrinho.Cursor = Cursors.Hand;
            btnLimparCarrinho.Click += (sender, e) => LimparCarrinho(dgvCarrinho);

            // Label Total
            Label lblTotal = new Label();
            lblTotal.Text = "Total: R$ 0,00";
            lblTotal.Name = "lblTotal";
            lblTotal.Font = new Font("Arial", 12, FontStyle.Bold);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(510, 410);
            lblTotal.Size = new Size(250, 25);

            // Botão Finalizar Venda
            Button btnFinalizarVenda = new Button();
            btnFinalizarVenda.Text = "Finalizar Compra";
            btnFinalizarVenda.Location = new Point(650, 460);
            btnFinalizarVenda.Size = new Size(160, 40);
            btnFinalizarVenda.BackColor = Color.ForestGreen;
            btnFinalizarVenda.ForeColor = Color.White;
            btnFinalizarVenda.Font = new Font("Arial", 10, FontStyle.Bold);
            btnFinalizarVenda.FlatStyle = FlatStyle.Flat;
            btnFinalizarVenda.Cursor = Cursors.Hand;
            btnFinalizarVenda.Click += (sender, e) => FinalizarVenda(dgvCarrinho);

            // Botão Cancelar
            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(820, 460);
            btnCancelar.Size = new Size(150, 40);
            btnCancelar.BackColor = Color.DarkRed;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Font = new Font("Arial", 10, FontStyle.Bold);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Click += (sender, e) => this.Close();

            // Adicionar controles ao formulário
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblProdutos);
            this.Controls.Add(dgvProdutos);
            this.Controls.Add(lblQuantidade);
            this.Controls.Add(nudQuantidade);
            this.Controls.Add(btnAdicionarCarrinho);
            this.Controls.Add(lblCarrinho);
            this.Controls.Add(dgvCarrinho);
            this.Controls.Add(btnRemoverCarrinho);
            this.Controls.Add(btnLimparCarrinho);
            this.Controls.Add(lblTotal);
            this.Controls.Add(btnFinalizarVenda);
            this.Controls.Add(btnCancelar);
        }

        private void CarregarProdutos(DataGridView dgv)
        {
            var produtos = servicoProdutos.ObterTodos();
            foreach (var produto in produtos)
            {
                dgv.Rows.Add(produto.Id, produto.Nome, produto.Descricao, $"R$ {produto.Preco:F2}");
            }
        }

        private void AdicionarAoCarrinho(DataGridView dgvProdutos, NumericUpDown nudQuantidade)
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para adicionar ao carrinho.", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProduto = Convert.ToInt32(dgvProdutos.SelectedRows[0].Cells[0].Value);
            var produto = servicoProdutos.ObterPorId(idProduto);
            int quantidade = (int)nudQuantidade.Value;

            var item = new ItemVenda(produto, quantidade);
            carrinhoAtual.Add(item);

            AtualizarCarrinho();
            MessageBox.Show($"{quantidade}x {produto.Nome} adicionado ao carrinho.", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RemoverDoCarrinho(DataGridView dgvCarrinho)
        {
            if (dgvCarrinho.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um item para remover do carrinho.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int indice = dgvCarrinho.SelectedRows[0].Index;
            carrinhoAtual.RemoveAt(indice);
            AtualizarCarrinho();
        }

        private void LimparCarrinho(DataGridView dgvCarrinho)
        {
            if (carrinhoAtual.Count == 0)
            {
                MessageBox.Show("Carrinho já está vazio.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            carrinhoAtual.Clear();
            AtualizarCarrinho();
        }

        private void AtualizarCarrinho()
        {
            DataGridView dgvCarrinho = (DataGridView)this.Controls["dgvCarrinho"];
            dgvCarrinho.Rows.Clear();

            foreach (var item in carrinhoAtual)
            {
                dgvCarrinho.Rows.Add(item.Produto.Nome, item.Quantidade, 
                    $"R$ {item.ValorUnitario:F2}", $"R$ {item.ValorTotal:F2}");
            }

            decimal total = carrinhoAtual.Sum(item => item.ValorTotal);
            Label lblTotal = (Label)this.Controls["lblTotal"];
            lblTotal.Text = $"Total: R$ {total:F2}";
        }

        private void FinalizarVenda(DataGridView dgvCarrinho)
        {
            if (carrinhoAtual.Count == 0)
            {
                MessageBox.Show("Carrinho vazio. Adicione produtos antes de finalizar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            vendaAtual = servicoVendas.CriarVenda();
            foreach (var item in carrinhoAtual)
            {
                vendaAtual.AdicionarItem(item);
            }

            servicoVendas.SalvarVenda(vendaAtual);

            decimal total = vendaAtual.ValorTotal;
            DialogResult resultado = MessageBox.Show(
                $"Venda finalizada com sucesso!\n\nVenda #{vendaAtual.Id}\nTotal: R$ {total:F2}\n\nDeseja realizar outra compra?",
                "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resultado == DialogResult.Yes)
            {
                carrinhoAtual.Clear();
                AtualizarCarrinho();
                ((NumericUpDown)this.Controls.Find("nudQuantidade", false)[0]).Value = 1;
            }
            else
            {
                this.Close();
            }
        }
    }
}
