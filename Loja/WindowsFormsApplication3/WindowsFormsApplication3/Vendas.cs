﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Vendas : Form
    {
        public Vendas()
        {
            InitializeComponent();
        }

        private void vendasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.vendasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dsLoja);

        }

        private void Vendas_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dsLoja.Produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosTableAdapter.Fill(this.dsLoja.Produtos);
            // TODO: esta linha de código carrega dados na tabela 'dsLoja.Vendas_Produto'. Você pode movê-la ou removê-la conforme necessário.
            this.vendas_ProdutoTableAdapter.Fill(this.dsLoja.Vendas_Produto);
            // TODO: esta linha de código carrega dados na tabela 'dsLoja.Clientes'. Você pode movê-la ou removê-la conforme necessário.
            this.clientesTableAdapter.Fill(this.dsLoja.Clientes);
            // TODO: esta linha de código carrega dados na tabela 'dsLoja.Vendas'. Você pode movê-la ou removê-la conforme necessário.
            this.vendasTableAdapter.Fill(this.dsLoja.Vendas);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            Hide();
        }

        private void vendas_ProdutoDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            vendas_ProdutoDataGridView.Rows[vendas_ProdutoDataGridView.RowCount - 1].Cells["preco"].Value = "0,00";
            vendas_ProdutoDataGridView.Rows[vendas_ProdutoDataGridView.RowCount - 1].Cells["quantidade"].Value = "0";
            vendas_ProdutoDataGridView.Rows[vendas_ProdutoDataGridView.RowCount - 1].Cells["precoTotal"].Value = "0,00";
        }

        private void vendas_ProdutoDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            decimal total = 0;
            for (int i = 0; i < vendas_ProdutoDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = vendas_ProdutoDataGridView.Rows[i];
                string valueA = row.Cells["preco"].Value.ToString();
                string valueB = row.Cells["quantidade"].Value.ToString();
                decimal valorA, valorB;
                if (decimal.TryParse(valueA, out valorA) && decimal.TryParse(valueB, out valorB))
                {
                    row.Cells["precoTotal"].Value = (valorA * valorB).ToString("0.00");
                    total += valorA * valorB;
                    totalTextBox.Text = total.ToString("0.00");
                }


            }
        }
    }
}
