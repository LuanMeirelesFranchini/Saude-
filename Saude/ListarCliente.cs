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
    public partial class ListarCliente : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();

        //Realiza os comandos do MySQL
        private MySqlCommand objCmd = new MySqlCommand();

        //Ler os comandos do MySQL
        private MySqlDataReader objFunc;
        public ListarCliente()
        {
            InitializeComponent();
        }

        private void ListarCliente_Load(object sender, EventArgs e)
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

        private void Btn_Listar_Click(object sender, EventArgs e)
        {
            try
            {
                //Adaptar informação e trazer os resultados da tabela
                MySqlDataAdapter da = new MySqlDataAdapter("Select * from tblClientes", objCnx);

                //Reconhecer tabela
                DataSet ds = new DataSet();

                //Jogar as informações na tabela
                da.Fill(ds, "tblClientes");

                //Preencher a tabela do C# com as informações do MySQL
                dgListar.DataSource = ds.Tables["tblClientes"];

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

            TelaCadastroCliente alter = new TelaCadastroCliente();

            alter.Codigo1 = dgListar.SelectedCells[0].Value.ToString();
            alter.Txt_Codigo.Text = dgListar.SelectedCells[0].Value.ToString();
            alter.Txt_Nome.Text = dgListar.SelectedCells[1].Value.ToString();
            alter.MK_Cpf.Text = dgListar.SelectedCells[2].Value.ToString();
            alter.Mk_Rg.Text = dgListar.SelectedCells[3].Value.ToString();
            alter.MK_Telefone.Text = dgListar.SelectedCells[4].Value.ToString();
            alter.MK_Celular.Text = dgListar.SelectedCells[5].Value.ToString();
            alter.Txt_Rua.Text = dgListar.SelectedCells[6].Value.ToString();
            alter.MK_Cep.Text = dgListar.SelectedCells[7].Value.ToString();
            alter.Txt_Bairro.Text = dgListar.SelectedCells[8].Value.ToString();
            alter.Txt_Cidade.Text = dgListar.SelectedCells[9].Value.ToString();
            alter.CB_Estado.Text = dgListar.SelectedCells[10].Value.ToString();
            alter.Txt_Email.Text = dgListar.SelectedCells[11].Value.ToString();
            alter.CB_Sexo.Text = dgListar.SelectedCells[12].Value.ToString();
           


            alter.Btn_Cadastrar.Visible = false;
            alter.Btn_Alterar.Visible = true;
           if (System.IO.File.Exists(Application.StartupPath + @"\config.dat"))
            {
                System.IO.StreamReader Leitura = new System.IO.StreamReader(Application.StartupPath + @"\config.dat");
                    String caminho = Leitura.ReadLine();
               alter.Arquivo.ImageLocation = caminho +@"\"+alter.Codigo1+".jpg";
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
                    String Codigo = dgListar.SelectedCells[0].Value.ToString();

                    // Vai Apagar so a linha que for selecionada //
                    MySqlCommand Cmd = new MySqlCommand("delete from tblClientes where codCli=" + Codigo, objCnx);

                    Cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados Apagados com Sucesso !!!");


                    // Vai Atualizar a tabela no Banco de Dados -> Worckbench //
                    Btn_Listar_Click(sender, e);


                }
            }
            catch (Exception ERRO)
            {
                MessageBox.Show(ERRO.Message);
            }
        }
    }
}
