using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5_var13
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            MaximumSize = Size;
            MinimumSize = Size; 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
