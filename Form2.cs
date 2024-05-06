using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kanboard_alt_v2
{
    public partial class Form2 : Form
    {


        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void ChangeTaskDetails(string getTitle, string getDescription)
        {
            textBox1.Text = getTitle;
            textBox2.Text = getDescription;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form f1 = new Form1();
            f1.StartPosition = FormStartPosition.Manual;
            f1.Location = Location;
            f1.Size = Size;
            f1.Show();
            Close();
        }
    }
}
