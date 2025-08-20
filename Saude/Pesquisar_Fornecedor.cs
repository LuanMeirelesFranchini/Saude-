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
    public partial class Pesquisar_Fornecedor : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();

        //Realiza os comandos do MySQL
        private MySqlCommand objCmd = new MySqlCommand();

        //Ler os comandos do MySQL
        private MySqlDataReader objFunc;
        public Pesquisar_Fornecedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Adaptar informação e trazer os resultados da tabela
                MySqlDataAdapter da = new MySqlDataAdapter("Select * from tblFornecedor where Forne_Nome like '%" + Txt_Fornecedor.Text + "%';", objCnx);

                //Reconhecer tabela
                DataSet ds = new DataSet();

                //Jogar as informações na tabela
                da.Fill(ds, "tblFornecedor");

                //Preencher a tabela do C# com as informações do MySQL
                dgListarFornecedor.DataSource = ds.Tables["tblFornecedor"];

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);

            }
        }

        private void Pesquisar_Fornecedor_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dgListarFornecedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Txt_Fornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
