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
    public partial class Tela_Cadastro_Produto : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();

        //Realiza os comandos do MySQL
        private MySqlCommand objCmd = new MySqlCommand();

        //Ler os comandos do MySQL
        private MySqlDataReader objFunc;
        public Tela_Cadastro_Produto()
        {
            InitializeComponent();
        }
        public String Codigo1;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Codigo, Nome, Preco, Data;
            Codigo = Txt_Codigo.Text;
            Nome = Txt_Produto.Text;
            Preco = Txt_Preco.Text;
            Data = MK_Data.Text;

            try
            {

                //Verificar se ja possuem alguem com este codigo no banco
                String strSql = "Select * from tblProduto Where Cod_Produto = " + Txt_Codigo.Text;

                //Verificar se o banco esta conectado
                objCmd.Connection = objCnx;

                //Verificar o comando de texto
                objCmd.CommandText = strSql;

                //Executa o comando do MySQL
                objFunc = objCmd.ExecuteReader();

                if (objFunc.HasRows)
                {

                    MessageBox.Show("Código Existente!", "Codigo existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

             //Se não existir codigo cadastrado, deixar conexão aberta e cadastrar usuario
                else
                {

                    if (!objFunc.IsClosed)
                    {

                        objFunc.Close();
                    }
                    strSql = "Insert Into tblProduto (Cod_Produto, Pro_Nome, Pro_Preco, Pro_Date) Values (";

                    strSql += Txt_Codigo.Text + ",";
                    strSql += "'" + Txt_Produto.Text + "',";
                    strSql += "'" + Txt_Preco.Text + "',";
                    strSql += "'" + MK_Data.Text + "')";


                    if ((Codigo == "") || (Nome == "") || (Nome == "") || (Preco == "") || (Data == ""))
                    {

                        MessageBox.Show("Por Favor, preencha os campos em branco!");
                    }

                    else
                    {

                        //Coenxão com o banco
                        objCmd.Connection = objCnx;

                        //Verificar comando MySQL -> Insert
                        objCmd.CommandText = strSql;

                        //Executar o Insert
                        objCmd.ExecuteNonQuery();

                        //Mensagem de cadastro realizado
                        MessageBox.Show("Registro concluido com sucesso!", "Saude ++", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Opção de sim ou não
                        DialogResult confirm = MessageBox.Show("Deseja continuar ?", "Escolha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                        if (confirm.ToString().ToUpper() == "YES")
                        {

                            TelaCadastroCliente continuar = new TelaCadastroCliente();
                            continuar.ShowDialog();
                        }

                        else
                        {

                            Menu_Principal continuar = new Menu_Principal();
                            continuar.ShowDialog();
                        }

                    }

                }

            }
            catch (Exception Erro)
            {

                MessageBox.Show("Erro ==> " + Erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tela_Cadastro_Produto_Load(object sender, EventArgs e)
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

        private void Btn_Alterar_Click(object sender, EventArgs e)
        {
            try
            {
                String StrSql;

                StrSql = "Update tblProduto set Pro_Nome = '" + Txt_Produto.Text + "',";
                StrSql += "Pro_Preco = '" + Txt_Preco.Text + "' ,";
                StrSql += "Pro_Date = '" + MK_Data.Text + "' ";
                StrSql += "where Cod_Produto =" + Codigo1 + ";";

                objCmd.Connection = objCnx;

                objCmd.CommandText = StrSql;

                objCmd.ExecuteNonQuery();
                MessageBox.Show(" Registro Alterado com Sucesso !!! ", " Editar Informações ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult Confirm = MessageBox.Show("Deseja Continuar ?", "Escolha", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                if (Confirm.ToString().ToUpper() == "YES")
                {
                    Tela_Cadastro_Administrador Continuar = new Tela_Cadastro_Administrador();
                    Continuar.ShowDialog();
                }
                else
                {
                    TelaGerencial Continuar = new TelaGerencial();
                    Continuar.ShowDialog();

                }
            }

            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
