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
    public partial class Consultar_Usuario_Cadastrados : Form
    {
        private MySqlCommand ObjCmd = new MySqlCommand();
        private MySqlConnection ObjCnx = new MySqlConnection();
       
        
        public Consultar_Usuario_Cadastrados()
        {
            InitializeComponent();
        }

        private void Consultar_Usuario_Cadastrados_Load(object sender, EventArgs e)
        {
            try
            {
                ObjCnx.ConnectionString = "Server=localhost;Database=Saude;User=root;Pwd=Blaster!@#;";
                // ObjCnx.ConnectionString = "Server=localhost;Database=Saude;User=root;Pwd=123;";


                ObjCnx.Open();
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Adaptar Informação
                MySqlDataAdapter da = new MySqlDataAdapter("Select * from tblFunc",ObjCnx);
                
                // Reconhcer tabela //
                DataSet ds = new DataSet();

                // Jogar informações na Tabela //
                da.Fill(ds, "tblFunc");

                // Preencher a tabela do C# com informações do MySql // 
                dgResultado.DataSource = ds.Tables["tblFunc"];

            }
            catch(Exception Erro)
            {
                MessageBox.Show(Erro.Message);
            }
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Não esquecer de clicar na tabela procurar nas propriedades context menu//
            // Procurar nas propriedades da tabela select mode full rows -> Linha Inteira //
            // Não esquece de deixaar caixas de texto com Propriedades publicas //
            // Select cells são as colunas da Tabela //
            // Codigo declarado no inicio do Form //

            Tela_Cadastro_Administrador alter = new Tela_Cadastro_Administrador();

            alter.Codigo1 = dgResultado.SelectedCells[0].Value.ToString();
            alter.Txt_Codigo.Text = dgResultado.SelectedCells[0].Value.ToString();
            alter.Txt_Nome.Text = dgResultado.SelectedCells[1].Value.ToString();
            alter.Txt_Senha.Text = dgResultado.SelectedCells[2].Value.ToString();

            alter.Btn_Cadastrar.Visible = false;
            alter.Btn_Alterar.Visible = true;
            alter.Txt_Codigo.Enabled = false;
            alter.ShowDialog();

        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var Result = MessageBox.Show(this, "Você Tem Certeza Que Deseja Excluir Essa Informação !!!","Confirmação",MessageBoxButtons.YesNo);
                if (Result == DialogResult.Yes)
                {
                    String Codigo = dgResultado.SelectedCells[0].Value.ToString();
                    
                    // Vai Apagar so a linha que for selecionada //
                    MySqlCommand Cmd = new MySqlCommand("delete from tblFunc where Cod_Func="+Codigo,ObjCnx);

                    Cmd.ExecuteNonQuery();

                    MessageBox.Show("Dados Apagados com Sucesso !!!");

                 
                    // Vai Atualizar a tabela no Banco de Dados -> Worckbench //
                    button1_Click(sender, e);


                }
            }
            catch(Exception ERRO)
            {
                MessageBox.Show(ERRO.Message);
            }
        }

    }
}
