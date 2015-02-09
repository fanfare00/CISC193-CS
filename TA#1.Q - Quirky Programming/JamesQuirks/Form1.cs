using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamesQuirks
{
    public partial class quirkyForm : Form
    {
        public quirkyForm()
        {
            InitializeComponent();
            
    
        }

        private void buttonJamesQuirk1_Click(object sender, EventArgs e)
        {
            labelHeaderAllQuirks.Text = "James' Quirk #1";

            labelAllQuirks.Text = "James' favorite type of food is seafood. He enjoys cooking \n"+
                                  "seafood himself  or eating out. His favorite dish is oysters \n"+
                                  "on the halfshell, but he likes pretty much everything and \n"+
                                  "is always excited to try new things.";
        }

        private void buttonJamesQuirk2_Click(object sender, EventArgs e)
        {
            labelHeaderAllQuirks.Text = "James' Quirk #2";

            labelAllQuirks.Text = "James owns a pet dog. His dog's name is Andy, he's five years \n" + 
                                   "old and he is a   black Labrador retriever. Hames takes his dog \n" +
                                   "to Ocean dog beach every weekend to enjoy some fun in the sun.";
        }

        private void buttonQuentinQuirk1_Click(object sender, EventArgs e)
        {

        }


    }
}
