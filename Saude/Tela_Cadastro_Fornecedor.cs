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
    public partial class Tela_Cadastro_Fornecedor : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();

        //Realiza os comandos do MySQL
        private MySqlCommand objCmd = new MySqlCommand();

        //Ler os comandos do MySQL
        private MySqlDataReader objFunc;
        public Tela_Cadastro_Fornecedor()
        {
            InitializeComponent();
        }
        public String Codigo1;

        private void button1_Click(object sender, EventArgs e)
        {
            String Codigo, Nome, CNPJ, Telefone, Celular, Rua, Cep, Bairro, Cidade, Estado, Email;
            Codigo = Txt_Codigo.Text;
            Nome = Txt_Nome.Text;
            CNPJ = MK_CNPJ.Text;
            Telefone = MK_Telefone.Text;
            Celular = MK_Celular.Text;
            Rua = Txt_Rua.Text;
            Cep = MK_Cep.Text;
            Bairro = Txt_Bairro.Text;
            Cidade = Txt_Cidade.Text;
            Estado = CB_Estado.Text;
            Email = Txt_Email.Text;

            try
            {

                //Verificar se ja possuem alguem com este codigo no banco
                String strSql = "Select * from tblFornecedor Where codForne = " + Txt_Codigo.Text;

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

                    strSql = "Insert Into tblFornecedor (codForne, Forne_Nome, Forne_Cnpj, Forne_Telefone, Forne_Celular, Forne_Rua, Forne_Cep,Forne_Bairro, Forne_Cidade, Forne_Estado, Forne_Email) Values (";

                    strSql += Txt_Codigo.Text + ",";
                    strSql += "'" + Txt_Nome.Text + "',";
                    strSql += "'" + MK_CNPJ.Text + "',";
                    strSql += "'" + MK_Telefone.Text + "',";
                    strSql += "'" + MK_Celular.Text + "',";
                    strSql += "'" + Txt_Rua.Text + "',";
                    strSql += "'" + MK_Cep.Text + "',";
                    strSql += "'" + Txt_Bairro.Text + "',";
                    strSql += "'" + Txt_Cidade.Text + "',";
                    strSql += "'" + CB_Estado.Text + "',";
                    strSql += "'" + Txt_Email.Text + "')";

                    if ((Codigo == "") || (Nome == "") || (CNPJ == "") || (Telefone == "") || (Celular == "") || (Rua == "") || (Cep == "") || (Bairro == "") || (Cidade == "") || (Estado == "") || (Email == ""))
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
                        objCmd.CommandText = "Select codCli from tblClientes order by codCli desc";
                        String Codigo1 = objCmd.ExecuteScalar().ToString();

                        if (System.IO.File.Exists(Application.StartupPath + @"\config.dat"))
                        {
                            System.IO.StreamReader leitura = new System.IO.StreamReader(Application.StartupPath + @"\config.dat");
                            String caminho = leitura.ReadLine();
                            System.IO.File.Copy(picfoto.ImageLocation, caminho + @"\" + Codigo1 + ".jpg");
                            leitura.Close();
                        }
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

        private void Tela_Cadastro_Fornecedor_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Btn_Alterar_Click(object sender, EventArgs e)
        {
             try
            {
                String StrSql;

                  StrSql = "Update tblFornecedor set Forne_Nome = '" + Txt_Nome.Text + "',";
                    StrSql += "Forne_Cnpj = '" + MK_CNPJ.Text+"' ,";
                    StrSql += "Forne_Telefone = '" + MK_CNPJ.Text + "' ,";
                    StrSql += "Forne_Celular = '" + MK_Celular.Text + "' ,";
                    StrSql += "Forne_Rua = '" + Txt_Rua.Text + "' ,";
                    StrSql += "Forne_Cep = '" + MK_Cep.Text + "' ,";
                    StrSql += "Forne_Bairro = '" + Txt_Bairro.Text + "' ,";
                    StrSql += "Forne_Cidade = '" + Txt_Cidade.Text + "' ,";
                    StrSql += "Forne_Estado = '" + CB_Estado.Text + "' ,";
                    StrSql += "Forne_Email = '" + Txt_Email.Text + "' ";
                    StrSql += "where codForne =" + Codigo1 + ";";

                  objCmd.Connection = objCnx;
                      
                        objCmd.CommandText = StrSql;
                      
                        objCmd.ExecuteNonQuery();
                        if (System.IO.File.Exists(Application.StartupPath + @"\config.dat"))
                        {
                            System.IO.StreamReader Leitura = new System.IO.StreamReader(Application.StartupPath + @"\config.dat");
                            String caminho = Leitura.ReadLine();
                            if (!picfoto.ImageLocation.Equals(caminho + @"\" + Codigo1 + ".jpg"))
                                System.IO.File.Copy(picfoto.ImageLocation, caminho + @"\" + Codigo1 + ".jpg", true);


                        }
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "jpeg|*.jpg";
            open.ShowDialog();
            picfoto.ImageLocation = open.FileName;
        }
    }
}
