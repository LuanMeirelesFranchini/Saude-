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
    public partial class Listar_Produto : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();

        //Realiza os comandos do MySQL
        private MySqlCommand objCmd = new MySqlCommand();

        //Ler os comandos do MySQL
        private MySqlDataReader objFunc;
        public Listar_Produto()
        {
            InitializeComponent();
        }

        private void Listar_Produto_Load(object sender, EventArgs e)
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

        private void Btn_Prduto_Click(object sender, EventArgs e)
        {
            try
            {
                //Adaptar informação e trazer os resultados da tabela
                MySqlDataAdapter da = new MySqlDataAdapter("Select * from tblProduto", objCnx);

                //Reconhecer tabela
                DataSet ds = new DataSet();

                //Jogar as informações na tabela
                da.Fill(ds, "tblProduto");

                //Preencher a tabela do C# com as informações do MySQL
                db_Produto.DataSource = ds.Tables["tblProduto"];

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);

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

            Tela_Cadastro_Produto alter = new Tela_Cadastro_Produto();

            alter.Codigo1 = db_Produto.SelectedCells[0].Value.ToString();
            alter.Txt_Codigo.Text = db_Produto.SelectedCells[0].Value.ToString();
            alter.Txt_Produto.Text = db_Produto.SelectedCells[1].Value.ToString();
            alter.Txt_Preco.Text = db_Produto.SelectedCells[2].Value.ToString();
            alter.MK_Data.Text = db_Produto.SelectedCells[3].Value.ToString();
            




            alter.Btn_Cadastro.Visible = false;
            alter.Btn_Alterar.Visible = true;

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
                    String Codigo = db_Produto.SelectedCells[0].Value.ToString();

                    // Vai Apagar so a linha que for selecionada //
                    MySqlCommand Cmd = new MySqlCommand("delete from tblProduto where Cod_Produto=" + Codigo, objCnx);

                    Cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados Apagados com Sucesso !!!");


                    // Vai Atualizar a tabela no Banco de Dados -> Worckbench //
                    Btn_Prduto_Click(sender, e);


                }
            }
            catch (Exception ERRO)
            {
                MessageBox.Show(ERRO.Message);
            }
        }

        private void db_Produto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void db_Produto_Layout(object sender, LayoutEventArgs e)
        {

        }
    }
}
