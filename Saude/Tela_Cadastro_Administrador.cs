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
    public partial class Tela_Cadastro_Administrador : Form
    {
        // Conexão com MySql Verifica local de Instalação //
        // Login e Senha do MySql //
        private MySqlConnection ObjCnx = new MySqlConnection();

        // Realiza os Comandos do MySql //
        private MySqlCommand ObjCmd = new MySqlCommand();

        // Responsavel por ler os Comandos do MySql //
        private MySqlDataReader ObjFunc;

        public Tela_Cadastro_Administrador()
        {
            InitializeComponent();

        }
        public String Codigo1;

        private void Fechar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Tela_Cadastro_Administrador_Load(object sender, EventArgs e)
        {
            try
            {
                ObjCnx.ConnectionString = "Server=localhost;Database=Saude;User=root;Pwd=Blaster!@#;";

                ObjCnx.Open();
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            // Declarando os TextBox como variavel //
            String Codigo, Nome, Senha;

            Codigo = Txt_Codigo.Text;
            Nome = Txt_Nome.Text;
            Senha = Txt_Senha.Text;

            // Try = Serve para tratamento de erro //
            try
            {
                String StrSql = "Select * From tblFunc where Cod_Func = " + Txt_Codigo.Text;

                // Verificar se o Banco esta conectado //
                ObjCmd.Connection = ObjCnx;
                // Verificando o campo de texto Select //
                ObjCmd.CommandText = StrSql;
                // Executa o Comando do MySql//
                ObjFunc = ObjCmd.ExecuteReader();

                // Usar a propiedade HashRows e o Método Read() para determinar o Comando usado para Criar o DataReader retornou Linhas ou Colunas //
                if (ObjFunc.HasRows)
                {
                    MessageBox.Show(" Codigo Existente !!!", "Codigo Existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_Codigo.Focus();
                }
              
                else
                {
                    if (!ObjFunc.IsClosed) { ObjFunc.Close(); }
                    StrSql = "Insert Into tblFunc (Cod_Func,Nome,Senha) Values(";
                    StrSql += Txt_Codigo.Text + ",";
                    StrSql += "'" + Txt_Nome.Text + "',";
                    StrSql += "'" + Txt_Senha.Text + "')";

                  
                    if ((Codigo == "") || (Nome == "") || (Senha == ""))
                    {
                        MessageBox.Show("Por Favor", " Preencha os Campos em Branco!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                       
                        ObjCmd.Connection = ObjCnx;
                      
                        ObjCmd.CommandText = StrSql;
                      
                        ObjCmd.ExecuteNonQuery();


                        
                        MessageBox.Show("Registro Concluido com Sucesso", " Saúde ++", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                }

                if (!ObjFunc.IsClosed) { ObjFunc.Close(); }
            }

            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consultar_Usuario_Cadastrados Consulta = new Consultar_Usuario_Cadastrados();
            Consulta.Show();
        }

        private void Btn_Alterar_Click(object sender, EventArgs e)
        {

            try
            {
                String StrSql;
            /*
            String Codigo, Nome, Senha;

            Codigo = Txt_Codigo.Text;
            Nome = Txt_Nome.Text;
            Senha = Txt_Senha.Text;
            
            try
            {
                String StrSql = "Select * From tblFunc where Cod_Func = " + Txt_Codigo.Text;

               
                ObjCmd.Connection = ObjCnx;
              
                ObjCmd.CommandText = StrSql;
               
                ObjFunc = ObjCmd.ExecuteReader();

              
                if (ObjFunc.HasRows)
                {
                    MessageBox.Show(" Codigo Existente !!!", "Codigo Existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Txt_Codigo.Focus();
                }
                
                else
                {
                    if (!ObjFunc.IsClosed) { ObjFunc.Close(); } */
                    StrSql = "Update tblFunc set Nome = '" + Txt_Nome.Text + "',";
                    StrSql += "Senha = '" + Txt_Senha.Text+"'";
                    StrSql += "where Cod_Func =" + Codigo1 + ";";

                   
                   /* if ((Codigo == "") || (Nome == "") || (Senha == ""))
                    {
                        MessageBox.Show("Por Favor", " Preencha os Campos em Branco!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {*/
                       
                        ObjCmd.Connection = ObjCnx;
                      
                        ObjCmd.CommandText = StrSql;
                      
                        ObjCmd.ExecuteNonQuery();


                      
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

                   /* }

                }

                if (!ObjFunc.IsClosed) { ObjFunc.Close(); }*/
            }

            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }

}
        
