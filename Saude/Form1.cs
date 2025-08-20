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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 4;
            }
            else
            {
                timer1.Enabled = false;
                this.Visible = false;
                TelaGerencial Tela = new TelaGerencial();
                Tela.Show();
                
            }
            if((progressBar1.Value>=1) && (progressBar1.Value<=20))
            {
                label1.Text = "Carregando Formulario......";
                label2.Text = progressBar1.Value + "%";
            }
            if ((progressBar1.Value >= 21) && (progressBar1.Value <= 40))
            {
                label1.Text = "Carregando Banco de Dados......";
                label2.Text = progressBar1.Value + "%";
            }
            if ((progressBar1.Value >= 41) && (progressBar1.Value <= 60))
            {
                label1.Text = "Carregando Ferramentas......";
                label2.Text = progressBar1.Value + "%";
            }
            if ((progressBar1.Value >= 61) && (progressBar1.Value <= 80))
            {
                label1.Text = "Carregamento Quase Completo......";
                label2.Text = progressBar1.Value + "%";
            }
            if ((progressBar1.Value >= 81) && (progressBar1.Value <= 100))
            {
                label1.Text = "Carregamento Completo......";
                label2.Text = progressBar1.Value + "%";
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
