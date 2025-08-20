using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saude
{
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void cadastroClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCadastroCliente CCliente = new TelaCadastroCliente();
            CCliente.ShowDialog();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ajuda Ajuda = new Ajuda();
            Ajuda.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime Data;
            int Hora;

            toolStripStatusLabel2.Text = DateTime.Now.ToString("dd/mmmm/yyyy");

            toolStripStatusLabel3.Text = DateTime.Now.ToString("HH:mm:ss");

            Data = Convert.ToDateTime(toolStripStatusLabel2.Text);

            Hora = Data.Hour;

            if ((Hora >= 1) && (Hora <= 12))
            {
                toolStripStatusLabel4.Text = "Bom - Dia  Familia";
            }
            else if ((Hora >= 13) && (Hora <= 17))
            {
                toolStripStatusLabel4.Text = "Bom - Tarde  Familia";
            }
            else 
            {
                toolStripStatusLabel4.Text = "Boa - Noite  Familia";
            }
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Windows\System32\calc.exe");
        }

        private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Windows\System32\notepad.exe");
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre SOBRE = new Sobre();
            SOBRE.ShowDialog();
        }

        private void cadastrarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela_Cadastro_Produto Produto = new Tela_Cadastro_Produto();
            Produto.ShowDialog();
        }

        private void pesquisaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PesquisaCliente PesquisaCli = new PesquisaCliente();
            PesquisaCli.ShowDialog();
        }

        private void listarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarCliente ListarCli = new ListarCliente();
            ListarCli.ShowDialog();
        }

        private void alterarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cadastroForncecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tela_Cadastro_Fornecedor CadastroFornecedor = new Tela_Cadastro_Fornecedor();
            CadastroFornecedor.ShowDialog();
        }

        private void pesquisaFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pesquisar_Fornecedor Pesquisafor = new Pesquisar_Fornecedor();
            Pesquisafor.ShowDialog();
        }

        private void listarFornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar_Fornecedor ListarFor = new Listar_Fornecedor();
            ListarFor.ShowDialog();
        }

        private void alterarFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pesquisarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pesquisar_Produto PesquisarProd = new Pesquisar_Produto();
            PesquisarProd.ShowDialog();
        }

        private void listarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar_Produto ListarProd = new Listar_Produto();
            ListarProd.ShowDialog();
        }

        private void alterarExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void sairToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sairToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Site Site = new Site();
            Site.ShowDialog();
        }

        private void manualDoSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\Users\luan.m.franchini\Downloads\Vida-20250818T161008Z-1-001\Vida\Vida\Saude\Manual\Manual.pdf");
        }

        private void relatoriosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formulario_Relatorio_Clientes Form = new Formulario_Relatorio_Clientes();
            Form.ShowDialog();
        }

        private void relatorioFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro_Fornecedor Form = new Registro_Fornecedor();
            Form.ShowDialog();
        }

        private void relatoriosDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorio_Produto Form = new Relatorio_Produto();
            Form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaCadastroCliente CCliente = new TelaCadastroCliente();
            CCliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tela_Cadastro_Fornecedor CadastroFornecedor = new Tela_Cadastro_Fornecedor();
            CadastroFornecedor.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Site Site = new Site();
            Site.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tela_Cadastro_Produto Remedio = new Tela_Cadastro_Produto();
            Remedio.ShowDialog();
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
