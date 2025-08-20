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
    public partial class TelaCadastroCliente : Form
    {
        private MySqlConnection objCnx = new MySqlConnection();

        //Realiza os comandos do MySQL
        private MySqlCommand objCmd = new MySqlCommand();

        //Ler os comandos do MySQL
        private MySqlDataReader objFunc;
        public TelaCadastroCliente()
        {
            InitializeComponent();
        }
        public String Codigo1;
        private void TelaCadastroCliente_Load(object sender, EventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Codigo, Nome, Cpf, Rg, Telefone, Celular, Rua, Cep, Bairro, Cidade, Estado, Email, Sexo;
            Codigo = Txt_Codigo.Text;
            Nome = Txt_Nome.Text;
            Cpf = MK_Cpf.Text;
            Rg = Mk_Rg.Text;
            Telefone = MK_Telefone.Text;
            Celular = MK_Celular.Text;
            Rua = Txt_Rua.Text;
            Cep = MK_Cep.Text;
            Bairro = Txt_Bairro.Text;
            Cidade = Txt_Cidade.Text;
            Estado = CB_Estado.Text;
            Email = Txt_Email.Text;
            Sexo = CB_Sexo.Text;

            try
            {

                //Verificar se ja possuem alguem com este codigo no banco
                String strSql = "Select * from tblClientes Where codCli = " + Txt_Codigo.Text;

                //Verificar se o banco esta conectado
                objCmd.Connection = objCnx;

                //Verificar o comando de texto
                objCmd.CommandText = strSql;

                //Executa o comando do MySQL
                objFunc = objCmd.ExecuteReader();


                //Usar a propriedade HasRows para determinar se o comando usado para criar o DataReader retornou linhas ou não
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

                    strSql = "Insert Into tblClientes (codCli,cli_nome,cli_cpf,cli_rg,cli_telefone,cli_celular,cli_rua,cli_cep,cli_bairro,cli_cidade,cli_estado,cli_email,cli_sexo) Values (";

                    strSql += Txt_Codigo.Text + ",";
                    strSql += "'" + Txt_Nome.Text + "',";
                    strSql += "'" + MK_Cpf.Text + "',";
                    strSql += "'" + Mk_Rg.Text + "',";
                    strSql += "'" + MK_Telefone.Text + "',";
                    strSql += "'" + MK_Celular.Text + "',";
                    strSql += "'" + Txt_Rua.Text + "',";
                    strSql += "'" + MK_Cep.Text + "',";
                    strSql += "'" + Txt_Bairro.Text + "',";
                    strSql += "'" + Txt_Cidade.Text + "',";
                    strSql += "'" + CB_Estado.Text + "',";
                    strSql += "'" + Txt_Email.Text + "',";
                    strSql += "'" + CB_Sexo.Text + "')";

                    //Campos não podem estar em branco
                    if ((Codigo == "") || (Nome == "") || (Cpf == "") || (Rg == "") || (Telefone == "") || (Celular == "") || (Rua == "") || (Cep == "") || (Bairro == "") || (Cidade == "") || (Estado == "") || (Email == "") || (Sexo == ""))
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
                                System.IO.StreamReader leitura = new System.IO.StreamReader(Application.StartupPath+@"\config.dat");
                                String caminho = leitura.ReadLine();
                                System.IO.File.Copy(Arquivo.ImageLocation, caminho + @"\" + Codigo1+".jpg");
                                    leitura.Close();
                            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Btn_Alterar_Click(object sender, EventArgs e)
        {
            try
            {
                String StrSql;

                StrSql = "Update tblClientes set cli_Nome = '" + Txt_Nome.Text + "',";
                StrSql += "cli_cpf = '" + MK_Cpf.Text +"',";
                StrSql += "cli_telefone = '" + Mk_Rg.Text + "',";
                StrSql += "cli_celular = '" + MK_Celular.Text + "',";
                StrSql += "cli_rua = '" + Txt_Rua.Text + "',";
                StrSql += "cli_cep = '" + MK_Cep.Text + "',";
                StrSql += "cli_bairro = '" + Txt_Bairro.Text + "',";
                StrSql += "cli_cidade = '" + Txt_Cidade.Text + "',";
                StrSql += "cli_estado = '" + CB_Estado.Text + "',";
                StrSql += "cli_email = '" + Txt_Email.Text + "',";
                StrSql += "cli_sexo = '" + CB_Sexo.Text + "' ";
                StrSql += "where codCli =" + Codigo1 + ";";

                objCmd.Connection = objCnx;

                objCmd.CommandText = StrSql;

                objCmd.ExecuteNonQuery();
                if(System.IO.File.Exists(Application.StartupPath+@"\config.dat"))
                {
                    System.IO.StreamReader Leitura = new System.IO.StreamReader(Application.StartupPath+@"\config.dat");
                    String caminho = Leitura.ReadLine();
                    if(!Arquivo.ImageLocation.Equals(caminho+@"\"+ Codigo1+".jpg"))
                    System.IO.File.Copy(Arquivo.ImageLocation, caminho +@"\" +Codigo1+ ".jpg",true);

                    
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
            Arquivo.ImageLocation = open.FileName;
        }

        private void Arquivo_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Txt_Nome.Clear();
            MK_Cpf.Clear();
            Mk_Rg.Clear();
            MK_Telefone.Clear();
            MK_Celular.Clear();
            Txt_Rua.Clear();
            MK_Cep.Clear();
            Txt_Bairro.Clear();
            Txt_Cidade.Clear();
            Txt_Email.Clear();
            Arquivo.Image = null;
        }
    }
}
