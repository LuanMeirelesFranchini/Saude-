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
    public partial class Tela_Login_Usuario : Form
    {
        private MySqlConnection ObjCnx = new MySqlConnection();

        private MySqlCommand ObjCmd = new MySqlCommand();

        private MySqlDataReader ObjFunc;

        public Tela_Login_Usuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string StrSql = " select * from tblFunc where Nome =  '" + Txt_Login.Text + "' and Senha = '" + Txt_Senha.Text + "'";
            
            ObjCmd.Connection = ObjCnx;
            
            ObjCmd.CommandText = StrSql;

            ObjFunc = ObjCmd.ExecuteReader();

            if (!ObjFunc.HasRows)
            {
                MessageBox.Show("Login ou Senha Invalidos !!!", "Login ou Senha Inavlidos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Visible = false;
                this.Hide();

                Tela_Login_Usuario Usuario = new Tela_Login_Usuario();
                Usuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Logado com Sucesso !!!", "Logado no Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Visible = false;
                this.Hide();
                Menu_Principal Menu = new Menu_Principal();
                Menu.ShowDialog();
            }

        }

        private void Tela_Login_Usuario_Load(object sender, EventArgs e)
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
    }
}
