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
    public partial class Registro_Fornecedor : Form
    {
        public Registro_Fornecedor()
        {
            InitializeComponent();
        }

        private void Registro_Fornecedor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saudeDataSet.tblfornecedor' table. You can move, or remove it, as needed.


            this.reportViewer1.RefreshReport();
        }
    }
}
