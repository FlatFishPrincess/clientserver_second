using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class HelloWorldFormOther : Form
    {
        public HelloWorldFormOther() // name property. if change the form name, this will be too
        {
            InitializeComponent();
            this.Text = "Hello World";
            outputLb.Text = "1000";
            clickBtn.Click += ClickBtn_Click;
            againBtn.Click += AgainBtn_Click;
        }
        
        private void ClickBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click Me Clicked");
        }

        private void AgainBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click Me Again Clicked");
        }
    }
}
