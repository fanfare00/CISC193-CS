using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SocketExample
{
    public partial class Form1 : Form
    {
        private SocketManagement con;
        string data;
        bool isHost;

        public Form1()
        {
            InitializeComponent();
        }

        private bool checkIPandPort(string ip, string port)
        {
            //Check the ip and port is in valid format with regular expressions
            if (Regex.IsMatch(ip, @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$") && Regex.IsMatch(port, "^[0-9]{1,6}$"))
            {
                //split input string into seperate parts at every '.'
                string[] temp = ip.Split('.');

                //loop through each piece of input string
                foreach (string q in temp)
                {
                    //ip entered cant have numbers higher than 255, ex: 360.0.2.12 would be invalid
                    if (Int32.Parse(q) > 255)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private void ConnectAsServer(string ip, int port)
        {
            con = new SocketManagement(ip, port);
            if (con.StartAsServer())
            {
                swapData();
            }
        }
        private void ConnectAsClient(string ip, int port)
        {
            con = new SocketManagement(ip, port);
            if (con.StartAsClient())
            {
                swapData();
            }
        }

        //data has to be sent/recieved over a network stream
        //the stream needs to run on a seperate thread from the program

        
        private void GetDataFromOthers()
        {
            //starts a new thread and runs the specified code on that thread
            Task.Factory.StartNew(() =>
            {
                data = con.getData();
                swapData();
            });
        }

        //this function gets the data from the stream and sets it to be the text of label2
        private void swapData()
        {
            //if we try to change the text of label1 from an outside thread, it will give us an error

            //if the thread sending the request is also running the form, go ahead and change the label
            if (!this.InvokeRequired)
            {
                 con.sendData(boxName.Text);

                 GetDataFromOthers();
                 label2.Text = data;
            }
            else
            {
                //if the request is coming from a different thread, use MethodInvoker to call the function
                //on the same thread that owns the control
                this.Invoke((MethodInvoker)delegate { swapData(); });
            }
            
        }

        private void buttonHost_Click(object sender, EventArgs e)
        {
            isHost = true;
        }

        private void buttonClient_Click(object sender, EventArgs e)
        {
            isHost = false;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (checkIPandPort(boxIP.Text, boxPort.Text))
            {
                if (isHost)
                {
                    ConnectAsServer(boxIP.Text, Int32.Parse(boxPort.Text));
                }
                else
                {
                    ConnectAsClient(boxIP.Text, Int32.Parse(boxPort.Text));
                }
            }
        }
    }




}
