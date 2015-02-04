using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "C# Brightens my Day!";
            pictureBox1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Welcome to James' TA";
            pictureBox1.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Time\n\t To\n\t\t Go\n\t", "Bye From James");
            Close();
        }
    }
}
