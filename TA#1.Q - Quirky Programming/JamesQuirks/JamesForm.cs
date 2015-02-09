using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace JamesQuirks
{

    public partial class quirkyForm : Form
    {
        public class Person
        {
           public String  name;
           public String  quirk1;
           public String  quirk2;
           public Image   image1;
           public Image   image2;
           public Image   profileImage = Properties.Resources.question_mark;
        }

        Person[] quirkyPeople = new Person[6];
        Stopwatch watch = new Stopwatch();
        int quirkPos;

        public quirkyForm()
        {
            InitializeComponent();

            watch.Start();
            quirkPos = 0;

            quirkyPeople[0] = new Person();
            quirkyPeople[0].name = "James";
            quirkyPeople[0].quirk1 = Properties.Resources.JamesQuirk1;
            quirkyPeople[0].quirk2 = Properties.Resources.JamesQuirk2;
            quirkyPeople[0].image1 = Properties.Resources.JamesQuirk1_jpg;
            quirkyPeople[0].image2 = Properties.Resources.JamesQuirk2_jpg;
            quirkyPeople[0].profileImage = Properties.Resources.JamesProfile_jpg;

            quirkyPeople[1] = new Person();
            quirkyPeople[1].name = "Kevin";
            quirkyPeople[1].quirk1 = Properties.Resources.KevinQuirk1;
            quirkyPeople[1].quirk2 = Properties.Resources.KevinQuirk2;
            quirkyPeople[1].image1 = Properties.Resources.KevinQuirk1_jpg;
            quirkyPeople[1].image2 = Properties.Resources.KevinQuirk2_jpg;

            quirkyPeople[2] = new Person();
            quirkyPeople[2].name = "John";
            quirkyPeople[2].quirk1 = Properties.Resources.JohnQuirk1;
            quirkyPeople[2].quirk2 = Properties.Resources.JohnQuirk2;
            quirkyPeople[2].image1 = Properties.Resources.JohnQuirk1_jpg;
            quirkyPeople[2].image2 = Properties.Resources.JohnQuirk2_jpg;

            quirkyPeople[3] = new Person();
            quirkyPeople[3].name = "Quentin";
            quirkyPeople[3].quirk1 = Properties.Resources.QuentinQuirk1;
            quirkyPeople[3].quirk2 = Properties.Resources.QuentinQuirk2;
            quirkyPeople[3].image1 = Properties.Resources.QuentinQuirk1_jpg;
            quirkyPeople[3].image2 = Properties.Resources.QuentinQuirk2_jpg;

            quirkyPeople[4] = new Person();
            quirkyPeople[4].name = "Eddie";
            quirkyPeople[4].quirk1 = Properties.Resources.EddieQuirk1;
            quirkyPeople[4].quirk2 = Properties.Resources.EddieQuirk2;
            quirkyPeople[4].image1 = Properties.Resources.EddieQuirk1_jpg;
            quirkyPeople[4].image2 = Properties.Resources.EddieQuirk2_jpg;

            quirkyPeople[5] = new Person();
            quirkyPeople[5].name = "Jim";
            quirkyPeople[5].quirk1 = Properties.Resources.JimQuirk1;
            quirkyPeople[5].quirk2 = Properties.Resources.JimQuirk2;
            quirkyPeople[5].image1 = Properties.Resources.JimQuirk1_jpg;
            quirkyPeople[5].image2 = Properties.Resources.JimQuirk2_jpg;

            labelQuirkHeader.Text = this.quirkyPeople[quirkPos].name + "'s Quirk #1";
            labelAllQuirks.Text = this.quirkyPeople[quirkPos].quirk1;
            pictureBoxAllQuirks.Image = this.quirkyPeople[quirkPos].image1;
            pictureBoxProfile.Image = this.quirkyPeople[quirkPos].profileImage;
            labelDateTime.Text = DateTime.Now.ToShortDateString() + "\n" + 
                                 DateTime.Now.ToShortTimeString();

            
        }


        private void button4_Click(object sender, EventArgs e)
        {
            quirkPos -= 1;
            if (quirkPos < 0)
            {
                quirkPos = 5;
            }
            labelPersonName.Text = this.quirkyPeople[quirkPos].name;

            labelQuirkHeader.Text = this.quirkyPeople[quirkPos].name + "'s Quirk #1";
            labelAllQuirks.Text = this.quirkyPeople[quirkPos].quirk1;
            pictureBoxAllQuirks.Image = this.quirkyPeople[quirkPos].image1;
            pictureBoxProfile.Image = this.quirkyPeople[quirkPos].profileImage;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            quirkPos += 1;
            if (quirkPos >= this.quirkyPeople.Length)
            {
                quirkPos = 0;
            }
            labelPersonName.Text = this.quirkyPeople[quirkPos].name;

            labelQuirkHeader.Text = this.quirkyPeople[quirkPos].name + "'s Quirk #1";
            labelAllQuirks.Text = this.quirkyPeople[quirkPos].quirk1;
            pictureBoxAllQuirks.Image = this.quirkyPeople[quirkPos].image1;
            pictureBoxProfile.Image = this.quirkyPeople[quirkPos].profileImage;
        }

        private void buttonQuirk1_Click(object sender, EventArgs e)
        {
            labelQuirkHeader.Text = this.quirkyPeople[quirkPos].name + "'s Quirk #1";
            labelAllQuirks.Text = this.quirkyPeople[quirkPos].quirk1;
            pictureBoxAllQuirks.Image = this.quirkyPeople[quirkPos].image1;
            pictureBoxProfile.Image = this.quirkyPeople[quirkPos].profileImage;
        }

        private void buttonQuirk2_Click(object sender, EventArgs e)
        {
            labelQuirkHeader.Text = this.quirkyPeople[quirkPos].name + "'s Quirk #2";
            labelAllQuirks.Text = this.quirkyPeople[quirkPos].quirk2;
            pictureBoxAllQuirks.Image = this.quirkyPeople[quirkPos].image2;
            pictureBoxProfile.Image = this.quirkyPeople[quirkPos].profileImage;
        }

        private void buttonElapsedTime_Click(object sender, EventArgs e)
        {
            TimeSpan ts = watch.Elapsed;
            string elapsed = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

            labelElapsed.Text = elapsed;
            labelElapsed.Visible = true;
        }

        private void timerElapsed_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = watch.Elapsed;
            string elapsed = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

            labelElapsed.Text = elapsed;

            labelDateTime.Text = DateTime.Now.ToShortDateString() + "\n" +
                     DateTime.Now.ToShortTimeString();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                     String.Format("{0, -25}\t:\t{1, -10}", "Programmer", "James McCarthy\n") +
                     String.Format("{0, -25}\t:\t{1, -10}", "Assignment #", "TA #1.1Q \n") +
                     String.Format("{0, -25}\t:\t{1, -10}", "Assignment Name", "Quirky Programming\n") +
                     String.Format("{0, -25}\t\t:\t{1, -10}", "Course #", "CISC 193 - C#\n") +
                     String.Format("{0, -25}\t:\t{1, -10}", "Meeting Time", "MW 9:35-12:45\n") +
                     String.Format("{0, -25}\t\t:\t{1, -10}", "Instructor", "Professor Forman\n") +
                     String.Format("{0, -25}\t\t:\t{1, -10}", "Hours", "4        \n") +
                     String.Format("{0, -25}\t\t:\t{1, -10}", "Difficulty", "2        \n") +
                     String.Format("{0, -25}\t:\t{1, -10}", "Program Name", "JamesQuirks\n\n") 

                    
            ,"ID Information");

            MessageBox.Show(
                    "Credits: \n\n" + "Thank you to http://www.csharp-examples.net/align-string-with-spaces/ \n" +
                    "for helping me align text in message boxes.\n\nAlso, thank you to the " +
                    "Microsoft Developer Network for helping me transition from C++ to C#", "Credits");

            MessageBox.Show("Quirky Image Sources: \n\n" + 
                "kingpupdogwalkers.com/images/nyc_dog_walker.jpg" + "\n" +
                "levelprism.com/wp-content/uploads/2014/08/beans.jpg" + "\n" +
                "encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcROIx" + "\n" +
                "c2.staticflickr.com/4/3181/2744286366_907cb88050.jpg" + "\n" +
                "stewart21.weebly.com/uploads/3/9/0/1/39017849/4329333_orig.jpg" + "\n" +
                "www.forms-surfaces.com/sites/default/files/imagecache/images/5.5.3" + "\n" +
                "undayfashions.com/wp-content/uploads/2012/08/Tie-Scarf-Men-Trends.jpg" + "\n" +
                "frogforum.net/attachments/african-bullfrogs/40889d1350833168-live-shrimp" + "\n" +
                "fsuworldmusiconline.wdfiles.com/local--resized-images/didjeridu/medium.jpg" + "\n" +
                "forms-surfaces.com/sites/default/files/imagecache/gal-reg-2x/images/5.5.3" + "\n" +
                "upload.wikimedia.org/wikipedia/commons/a/a6/Black_lab.JPG" + "\n" +
                "farm1.static.flickr.com/78/182331812_10bbc4e911.jpg" + "\n" +
                "images.medicaldaily.com/sites/medicaldaily.com/styles/public/2014/01" + "\n\n" +

                "Misc Sources: \n\n" +
                "backgroundwallpaper.co/wp-content/uploads/2013/10/twitter.jpg" + "\n" +
                "clker.com/cliparts/5/9/4/c/12198090531909861341man%20silhouette.png", "Media");

            MessageBox.Show(
                "1 : Display the names, 2 quirks, and graphics for two aditional people\n\n" + 
                "1 : Expand on previous star by adding an aditional 2.\n\n" + 
                "1 : Advanced features: Classes, resource file, string operators\n\n" + 
                "1 : Re-use the same two labels for task 3E\n\n" + 
                "1 : Add a button for displaying the elapsed time\n\n" + 
                "TOTAL STARS: 5",
                "STARS");


            Close();
           
            
        }


    }
}
