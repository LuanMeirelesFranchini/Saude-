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
    public partial class TelaGerencial : Form
    {
        public TelaGerencial()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaAdministrador TelaA = new TelaAdministrador();
            TelaA.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tela_Login_Usuario Tela4 = new Tela_Login_Usuario();
            Tela4.Show();
        }
    }
}
