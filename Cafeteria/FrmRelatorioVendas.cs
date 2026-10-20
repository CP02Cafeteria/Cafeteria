using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Cafeteria.Modelos;
using Cafeteria.Servicos;

namespace Cafeteria
{
    public partial class FrmRelatorioVendas : Form
    {
        private ServicoVendas servicoVendas;

        public FrmRelatorioVendas(ServicoVendas servicoVendas)
        {
            InitializeComponent();
            this.servicoVendas = servicoVendas;
        }

        public void ConfigurarInterface()
        {
            this.Text = "Relatório de Vendas";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Label Título
            Label lblTitulo = new Label();
            lblTitulo.Text = "Relatório de Vendas";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(300, 30);

            // Label Resumo
            Label lblResumo = new Label();
            lblResumo.Name = "lblResumo";
            lblResumo.Font = new Font("Arial", 10);
            lblResumo.ForeColor = Color.White;
            lblResumo.Location = new Point(20, 60);
            lblResumo.Size = new Size(600, 40);
            AtualizarResumo(lblResumo);

            // DataGridView Vendas
            DataGridView dgvVendas = new DataGridView();
            dgvVendas.Name = "dgvVendas";
            dgvVendas.Location = new Point(20, 110);
            dgvVendas.Size = new Size(960, 350);
            dgvVendas.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvVendas.ForeColor = Color.White;
            dgvVendas.GridColor = Color.Black;

            DataGridViewCellStyle estiloVendas = new DataGridViewCellStyle();
            estiloVendas.BackColor = Color.FromArgb(40, 40, 40);
            estiloVendas.ForeColor = Color.White;
            dgvVendas.DefaultCellStyle = estiloVendas;

            dgvVendas.ColumnHeadersDefaultCellStyle.BackColor = Color.SaddleBrown;
            dgvVendas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVendas.ColumnHeadersHeight = 25;
            dgvVendas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvVendas.AllowUserToAddRows = false;
            dgvVendas.AllowUserToDeleteRows = false;
            dgvVendas.ReadOnly = true;
            dgvVendas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVendas.RowTemplate.Height = 25;

            dgvVendas.Columns.Add("ID", "ID Venda");
            dgvVendas.Columns.Add("DataVenda", "Data/Hora");
            dgvVendas.Columns.Add("Quantidade", "Qtd Itens");
            dgvVendas.Columns.Add("ValorTotal", "Valor Total");

            CarregarVendas(dgvVendas);

            // Botão Detalhes
            Button btnDetalhes = new Button();
            btnDetalhes.Text = "Ver Detalhes";
            btnDetalhes.Location = new Point(20, 480);
            btnDetalhes.Size = new Size(120, 35);
            btnDetalhes.BackColor = Color.SaddleBrown;
            btnDetalhes.ForeColor = Color.White;
            btnDetalhes.FlatStyle = FlatStyle.Flat;
            btnDetalhes.Cursor = Cursors.Hand;
            btnDetalhes.Click += (sender, e) => VerDetalhes(dgvVendas);

            // Botão Atualizar
            Button btnAtualizar = new Button();
            btnAtualizar.Text = "Atualizar";
            btnAtualizar.Location = new Point(150, 480);
            btnAtualizar.Size = new Size(120, 35);
            btnAtualizar.BackColor = Color.SaddleBrown;
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Cursor = Cursors.Hand;
            btnAtualizar.Click += (sender, e) => 
            {
                dgvVendas.Rows.Clear();
                CarregarVendas(dgvVendas);
                AtualizarResumo(lblResumo);
            };

            // Botão Fechar
            Button btnFechar = new Button();
            btnFechar.Text = "Fechar";
            btnFechar.Location = new Point(860, 480);
            btnFechar.Size = new Size(120, 35);
            btnFechar.BackColor = Color.DarkRed;
            btnFechar.ForeColor = Color.White;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.Click += (sender, e) => this.Close();

            // Adicionar controles ao formulário
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblResumo);
            this.Controls.Add(dgvVendas);
            this.Controls.Add(btnDetalhes);
            this.Controls.Add(btnAtualizar);
            this.Controls.Add(btnFechar);
        }

        private void CarregarVendas(DataGridView dgv)
        {
            var vendas = servicoVendas.ObterTodas();

            if (vendas.Count == 0)
            {
                MessageBox.Show("Nenhuma venda registrada.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var venda in vendas)
            {
                dgv.Rows.Add(venda.Id, venda.DataVenda.ToString("dd/MM/yyyy HH:mm:ss"),
                    venda.Itens.Count, $"R$ {venda.ValorTotal:F2}");
            }
        }

        private void AtualizarResumo(Label lblResumo)
        {
            int totalVendas = servicoVendas.ObterQuantidadeVendas();
            decimal totalRecebido = servicoVendas.ObterTotalVendas();

            lblResumo.Text = $"Total de Vendas: {totalVendas} | Valor Total Recebido: R$ {totalRecebido:F2}";
        }

        private void VerDetalhes(DataGridView dgvVendas)
        {
            if (dgvVendas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma venda para visualizar os detalhes.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idVenda = Convert.ToInt32(dgvVendas.SelectedRows[0].Cells[0].Value);
            var venda = servicoVendas.ObterPorId(idVenda);

            if (venda == null)
            {
                MessageBox.Show("Venda não encontrada.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MostrarDetalhesVenda(venda);
        }

        private void MostrarDetalhesVenda(Venda venda)
        {
            Form frmDetalhes = new Form();
            frmDetalhes.Text = $"Detalhes da Venda #{venda.Id}";
            frmDetalhes.Size = new Size(700, 500);
            frmDetalhes.StartPosition = FormStartPosition.CenterScreen;
            frmDetalhes.BackColor = Color.FromArgb(40, 40, 40);
            frmDetalhes.FormBorderStyle = FormBorderStyle.FixedSingle;
            frmDetalhes.MaximizeBox = false;

            // Label Informações da Venda
            Label lblInfo = new Label();
            lblInfo.Text = $"Venda #{venda.Id} - {venda.DataVenda:dd/MM/yyyy HH:mm:ss}\nTotal: R$ {venda.ValorTotal:F2}";
            lblInfo.Font = new Font("Arial", 11, FontStyle.Bold);
            lblInfo.ForeColor = Color.White;
            lblInfo.Location = new Point(20, 20);
            lblInfo.Size = new Size(650, 50);

            // DataGridView Itens
            DataGridView dgvItens = new DataGridView();
            dgvItens.Location = new Point(20, 80);
            dgvItens.Size = new Size(650, 320);
            dgvItens.BackgroundColor = Color.FromArgb(40, 40, 40);
            dgvItens.ForeColor = Color.White;
            dgvItens.GridColor = Color.Black;

            DataGridViewCellStyle estiloItens = new DataGridViewCellStyle();
            estiloItens.BackColor = Color.FromArgb(40, 40, 40);
            estiloItens.ForeColor = Color.White;
            dgvItens.DefaultCellStyle = estiloItens;

            dgvItens.ColumnHeadersDefaultCellStyle.BackColor = Color.SaddleBrown;
            dgvItens.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvItens.ColumnHeadersHeight = 25;
            dgvItens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvItens.AllowUserToAddRows = false;
            dgvItens.ReadOnly = true;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.RowTemplate.Height = 25;

            dgvItens.Columns.Add("Produto", "Produto");
            dgvItens.Columns.Add("Quantidade", "Qtd");
            dgvItens.Columns.Add("ValorUnitario", "Preço Unitário");
            dgvItens.Columns.Add("ValorTotal", "Total");

            foreach (var item in venda.Itens)
            {
                dgvItens.Rows.Add(item.Produto.Nome, item.Quantidade,
                    $"R$ {item.ValorUnitario:F2}", $"R$ {item.ValorTotal:F2}");
            }

            // Botão Fechar
            Button btnFechar = new Button();
            btnFechar.Text = "Fechar";
            btnFechar.Location = new Point(570, 420);
            btnFechar.Size = new Size(100, 35);
            btnFechar.BackColor = Color.DarkRed;
            btnFechar.ForeColor = Color.White;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.Click += (sender, e) => frmDetalhes.Close();

            frmDetalhes.Controls.Add(lblInfo);
            frmDetalhes.Controls.Add(dgvItens);
            frmDetalhes.Controls.Add(btnFechar);

            frmDetalhes.ShowDialog();
        }
    }
}
