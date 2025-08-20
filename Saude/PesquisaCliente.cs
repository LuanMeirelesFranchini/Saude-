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
    public partial class PesquisaCliente : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();

        //Realiza os comandos do MySQL
        private MySqlCommand objCmd = new MySqlCommand();

        //Ler os comandos do MySQL
        private MySqlDataReader objFunc;
        public PesquisaCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Adaptar informação e trazer os resultados da tabela
                MySqlDataAdapter da = new MySqlDataAdapter("Select * from tblClientes where cli_nome like '%" + Txt_Cliente.Text + "%';", objCnx);

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

        private void PesquisaCliente_Load(object sender, EventArgs e)
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
    }
}
