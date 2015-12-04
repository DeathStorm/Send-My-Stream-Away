using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendScreenAway
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            WebBrowser webBrowser = new WebBrowser(Convert.ToInt32(tbWidth.Text), Convert.ToInt32(tbHeight.Text), tbURL.Text);
            this.Close();                                 
            webBrowser.Show();
            
            //this.Hide();
            
            
        }


        private void tbURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            { 
                btnStart_Click(null,null);
            }
        }



    }
}
