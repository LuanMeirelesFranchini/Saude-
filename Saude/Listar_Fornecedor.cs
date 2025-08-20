using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Saude
{
    public partial class Listar_Fornecedor : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();

        //Realiza os comandos do MySQL
        private MySqlCommand objCmd = new MySqlCommand();

        //Ler os comandos do MySQL
        private MySqlDataReader objFunc;
        public Listar_Fornecedor()
        {
            InitializeComponent();
        }

        private void Btn_Fornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                //Adaptar informação e trazer os resultados da tabela
                MySqlDataAdapter da = new MySqlDataAdapter("Select * from tblFornecedor", objCnx);

                //Reconhecer tabela
                DataSet ds = new DataSet();

                //Jogar as informações na tabela
                da.Fill(ds, "tblFornecedor");

                //Preencher a tabela do C# com as informações do MySQL
                dg_ListarFornecedor.DataSource = ds.Tables["tblFornecedor"];

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);

            }
        }

        private void Listar_Fornecedor_Load(object sender, EventArgs e)
        {
            try
            {

                objCnx.ConnectionString = "Server=localhost;Database=Saude;User=root;Pwd=Blaster!@#;";

                objCnx.Open();
            }

            catch (Exception Erro)
            {

                MessageBox.Show("Erro ==> " + Erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Não esquecer de clicar na tabela procurar nas propriedades context menu//
            // Procurar nas propriedades da tabela select mode full rows -> Linha Inteira //
            // Não esquece de deixaar caixas de texto com Propriedades publicas //
            // Select cells são as colunas da Tabela //
            // Codigo declarado no inicio do Form //

            Tela_Cadastro_Fornecedor alter = new Tela_Cadastro_Fornecedor();

            alter.Codigo1 = dg_ListarFornecedor.SelectedCells[0].Value.ToString();
            alter.Txt_Codigo.Text = dg_ListarFornecedor.SelectedCells[0].Value.ToString();
            alter.Txt_Nome.Text = dg_ListarFornecedor.SelectedCells[1].Value.ToString();
            alter.MK_CNPJ.Text = dg_ListarFornecedor.SelectedCells[2].Value.ToString();
            alter.MK_Telefone.Text = dg_ListarFornecedor.SelectedCells[3].Value.ToString();
            alter.MK_Celular.Text = dg_ListarFornecedor.SelectedCells[4].Value.ToString();
            alter.Txt_Rua.Text = dg_ListarFornecedor.SelectedCells[5].Value.ToString();
            alter.MK_Cep.Text = dg_ListarFornecedor.SelectedCells[6].Value.ToString();
            alter.Txt_Bairro.Text = dg_ListarFornecedor.SelectedCells[7].Value.ToString();
            alter.Txt_Cidade.Text = dg_ListarFornecedor.SelectedCells[8].Value.ToString();
            alter.CB_Estado.Text = dg_ListarFornecedor.SelectedCells[9].Value.ToString();
            alter.Txt_Email.Text = dg_ListarFornecedor.SelectedCells[10].Value.ToString();
           



            alter.Btn_Cadastro.Visible = false;
            alter.Btn_Alterar.Visible = true;
            if (System.IO.File.Exists(Application.StartupPath + @"\config.dat"))
            {
                System.IO.StreamReader Leitura = new System.IO.StreamReader(Application.StartupPath + @"\config.dat");
                String caminho = Leitura.ReadLine();
                alter.picfoto.ImageLocation = caminho + @"\" + alter.Codigo1 + ".jpg";
            }
            alter.Txt_Codigo.Enabled = false;
            alter.ShowDialog();
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var Result = MessageBox.Show(this, "Você Tem Certeza Que Deseja Excluir Essa Informação !!!", "Confirmação", MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    String Codigo = dg_ListarFornecedor.SelectedCells[0].Value.ToString();

                    // Vai Apagar so a linha que for selecionada //
                    MySqlCommand Cmd = new MySqlCommand("delete from tblFornecedor where codForne=" + Codigo, objCnx);

                    Cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados Apagados com Sucesso !!!");


                    // Vai Atualizar a tabela no Banco de Dados -> Worckbench //
                    Btn_Fornecedor_Click(sender, e);


                }
            }
            catch (Exception ERRO)
            {
                MessageBox.Show(ERRO.Message);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void dg_ListarFornecedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
