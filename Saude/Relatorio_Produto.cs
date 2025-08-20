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
    public partial class Relatorio_Produto : Form
    {
        public Relatorio_Produto()
        {
            InitializeComponent();
        }

        private void Relatorio_Produto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saudeDataSet.tblproduto' table. You can move, or remove it, as needed.
            

            this.reportViewer1.RefreshReport();
        }
    }
}
