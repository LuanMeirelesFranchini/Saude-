using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saude
{
    public partial class TelaAdministrador : Form
    {
        public TelaAdministrador()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Txt_Login.Text == "user" && Txt_Senha.Text == "1234")
            {
                MessageBox.Show("Logado como Administrador !!!", "Administrador do Sistema !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                this.Hide();

                Tela_Cadastro_Administrador Tela3 = new Tela_Cadastro_Administrador();
                Tela3.Show();
            }
            else
            {
                MessageBox.Show("Login ou Senha Invalídos !!!", "Tente Novamente !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_Login.Clear();
                Txt_Senha.Clear();
                Txt_Login.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaGerencial Tela4 = new TelaGerencial();
            Tela4.Show();
        }

        private void TelaAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Txt_Login.Text == "user" && Txt_Senha.Text == "1234")
                {
                    MessageBox.Show("Logado como Administrador !!!", "Administrador do Sistema !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                    this.Hide();

                    Tela_Cadastro_Administrador Tela3 = new Tela_Cadastro_Administrador();
                    Tela3.Show();
                }
                else
                {
                    MessageBox.Show("Login ou Senha Invalídos !!!", "Tente Novamente !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Txt_Login.Clear();
                    Txt_Senha.Clear();
                    Txt_Login.Focus();
                }
            }
        }
    }
}
