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
    public partial class Site : Form
    {
        public Site()
        {
            InitializeComponent();
            webBrowser1.Navigate(new Uri("https://www.google.com.br/?gws_rd=cr&ei=mogbWdrKOYKkwgSYx7DgAQ"));
        }

        private void Site_Load(object sender, EventArgs e)
        {
            
        }
    }
}
