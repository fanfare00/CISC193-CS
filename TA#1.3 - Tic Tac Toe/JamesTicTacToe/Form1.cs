﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Media;
using System.Runtime.InteropServices;

using System.Reflection;
using System.IO;

namespace JamesTicTacToe
{
    public partial class JamesForm : Form
    {

        SoundPlayer jamesSoundPlayer = new SoundPlayer();
        public bool hostSelected = false;

        private SocketManagement con;// object for connecting

        public bool networkGame = false;
        public bool isHost = false;
        public bool isMyTurn = true;
        public bool canStart = false;


        public bool isWinner = false;

        private int[][] board = { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };// 0=netral, 1=server, 2=clint
        private Image[] mapping = { null, Properties.Resources.icon_diffuse, Properties.Resources.icon_bomb };

        private bool haveWinner = false;

        Stopwatch clock = new Stopwatch();

        private int scoreT = 0;
        private int scoreCT = 0;



        public JamesForm()
        {
            InitializeComponent();

       
            jamesMediaPlayer.URL = @"Resources\CSGOMenuTheme.wav";
            jamesMediaPlayer.settings.volume = 10;
            jamesMediaPlayer.settings.setMode("loop", true);
        

            buttonScoreT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            buttonScoreCT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            buttonClock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            buttonScoreT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            buttonScoreCT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            buttonClock.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        private enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }



        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        } 

    ////////////////////////////////////////////////////////////////////////////
    ///     SELECTION LABEL HIGHLIGHTING
    ///

        //https://msdn.microsoft.com/en-us/library/dd553231.aspx
        private void label_Highlight(object sender, EventArgs e)
        {
            Label highlightedLabel = sender as Label;

            if (highlightedLabel != null)
            {
                if (highlightedLabel.ForeColor == Color.Black)
                {
                    return;
                }

                highlightedLabel.ForeColor = Color.Black;
                highlightedLabel.Image = Properties.Resources.label_back_6;

                try
                {


                    soundEffectPlayer1.URL =  @"Resources\sound_rollover.wav";
                    jamesMediaPlayer.settings.volume = 10;


                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void label_Unhighlight(object sender, EventArgs e)
        {
            Label unhighlightedLabel = sender as Label;

            if (unhighlightedLabel != null)
            {
                if (unhighlightedLabel.ForeColor == Color.Gainsboro)
                {
                    return;
                }

                unhighlightedLabel.ForeColor = Color.Gainsboro;
                unhighlightedLabel.Image = null;
            }
        }
    ///
    /// END SELECTION LABEL HIGHLIGHTING
    ////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////
    ///  MAIN MENU SELECTIONS
    ///




    ///
    /// END SELECTION LABEL HIGHLIGHTING
    ////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////
    /// 
    ///  GAME
    ///

        private void startGame()
        {
            jamesMediaPlayer.URL = @"Resources\CSGOGameTheme.wav";
            soundEffectPlayer2.URL = @"Resources\sound_ready.wav";

            //if (networkGame)
            //{
            //    isMyTurn = isHost;
            //}


            timerClock.Start();
            clock.Start();


            if (networkGame)
            {
                checkTurn();
            }
            else
            {
                isHost = false;
                isMyTurn = true;
            }



            panelMainMenu.Hide();
            panelNetworkSetup.Hide();

            panelGameBoard.Show();
            panelLeftPlayerCT.Show();
            panelRightPlayerT.Show();
            panelScoreTime.Show();

            this.BackgroundImage = Properties.Resources.form_back_alt_2;


            pictureBoxPortraitRightT.Image = Properties.Resources.portrait_terrorist_alt_3;
            pictureBoxLogoRightT.Image = Properties.Resources.icon_terrorist_alt;
            labelTeamRight.ForeColor = Color.Gray;
            labelPlayerNameRight.ForeColor = Color.Gray;
        }

        private void testDraw()
        {
            int testDraw = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {

                    if (board[i][k] != 0)
                    {
                        testDraw += 1;
                    }
                }
            }

            if (testDraw == 9)
            {
                haveWinner = true;
                timerNextRound.Start();
                clock.Restart();
                buttonClock.ForeColor = Color.Red;

                panelRoundWinner.Show();

                soundEffectPlayer1.URL = @"Resources\sound_draw.wav";

                pictureBoxWinningTeam.Image = null;
                labelRoundWinner.Text = "Round Draw";


            }
        }

        private void resetBoard()
        {
            
            
            g00.Image = mapping[board[0][0]];
            g01.Image = mapping[board[0][1]];
            g02.Image = mapping[board[0][2]];
            g10.Image = mapping[board[1][0]];
            g11.Image = mapping[board[1][1]];
            g12.Image = mapping[board[1][2]];
            g20.Image = mapping[board[2][0]];
            g21.Image = mapping[board[2][1]];
            g22.Image = mapping[board[2][2]];

 
        }

        private void SetEnabled(bool value)
        {
            


            g00.Enabled = value;
            g01.Enabled = value;
            g02.Enabled = value;
            g10.Enabled = value;
            g11.Enabled = value;
            g12.Enabled = value;
            g20.Enabled = value;
            g21.Enabled = value;
            g22.Enabled = value;
        }

        ////////////////////////////////////////////////////////////////////////
        ///   MAIN GAME BOARD LOGIC
        ////////////////////////////////////////////////////////////////////////
        private void checkBoardState()
        {
            if (!this.InvokeRequired)
            {
                // VERTICAL WIN CHECK
                if (board[0][0] != 0 && board[0][1] != 0 && board[0][1] != 0 && board[0][0] == board[0][1] && board[0][1] == board[0][2] && board[0][0] == board[0][2])
                {
                    // VERTICAL ROW 0 CHECK
                    haveWinner = true;
                    if ((isHost && board[0][0] == 1) || (!isHost && board[0][0] == 2))
                    {
                        isWinner = true;
                    }


                }
                else if (board[1][0] != 0 && board[1][1] != 0 && board[1][1] != 0 && board[1][0] == board[1][1] && board[1][1] == board[1][2] && board[1][0] == board[1][2])
                {
                    // VERTICAL ROW 1 CHECK
                    haveWinner = true;
                    if ((isHost && board[1][0] == 1) || (!isHost && board[1][0] == 2))
                    {
                        isWinner = true;
                    }


                }
                else if (board[2][0] != 0 && board[2][1] != 0 && board[2][1] != 0 && board[2][0] == board[2][1] && board[2][1] == board[2][2] && board[2][0] == board[2][2])
                {
                    // VERTICAL ROW 2 CHECK
                    haveWinner = true;
                    if ((isHost && board[2][0] == 1) || (!isHost && board[2][0] == 2))
                    {
                        isWinner = true;
                    }


                }
                // HORIZONTAL WIN CHECK
                else if (board[0][0] != 0 && board[1][0] != 0 && board[2][0] != 0 && board[0][0] == board[1][0] && board[1][0] == board[2][0] && board[0][0] == board[2][0])
                {
                    // HORIZONTAL ROW 0 CHECK
                    haveWinner = true;
                    if ((isHost && board[0][0] == 1) || (!isHost && board[0][0] == 2))
                    {
                        isWinner = true;
                    }


                }
                else if (board[0][1] != 0 && board[1][1] != 0 && board[2][1] != 0 && board[0][1] == board[1][1] && board[1][1] == board[2][1] && board[0][1] == board[2][1])
                {
                    // HORIZONTAL ROW 1 CHECK
                    haveWinner = true;
                    if ((isHost && board[0][1] == 1) || (!isHost && board[0][1] == 2))
                    {
                        isWinner = true;
                    }


                }
                else if (board[0][2] != 0 && board[1][2] != 0 && board[2][2] != 0 && board[0][2] == board[1][2] && board[1][2] == board[2][2] && board[0][2] == board[2][2])
                {
                    // HORIZONTAL ROW 2 CHECK
                    haveWinner = true;
                    if ((isHost && board[0][2] == 1) || (!isHost && board[0][2] == 2))
                    {
                        isWinner = true;
                    }


                }
                // DIAGONAL WIN CHECK
                else if (board[0][0] != 0 && board[1][1] != 0 && board[2][2] != 0 && board[0][0] == board[1][1] && board[1][1] == board[2][2] && board[0][0] == board[2][2])
                {
                    // DIAGONAL LEFT-RIGHT CHECK
                    haveWinner = true;
                    if ((isHost && board[0][0] == 1) || (!isHost && board[0][0] == 2))
                    {
                        isWinner = true;
                    }

                }
                else if (board[0][2] != 0 && board[1][1] != 0 && board[2][0] != 0 && board[2][0] == board[1][1] && board[1][1] == board[0][2] && board[2][0] == board[0][2])
                {
                    // DIAGONAL RIGHT-LEFT CHECK
                    haveWinner = true;
                    if ((isHost && board[1][1] == 1) || (!isHost && board[1][1] == 2))
                    {
                        isWinner = true;
                    }
                }

                testDraw();

                if (haveWinner)
                {
                    timerNextRound.Start();
                    clock.Restart();
                    buttonClock.ForeColor = Color.Red;


                    if (networkGame)
                    {
                        //if the winner is CT, display CT won message on both apps, if they are T display the T won message

                        if (isWinner)
                        {
                            if (isHost)
                            {
                                // if isWinner = true and user is host(CT), display CT won message
                                resultCounterTerrorists();
                            }
                            else
                            {
                                // if isWinner = true and user is client(T), display T won message
                                resultTerrorists();
                            }
                        }
                        else
                        {
                            // if isWinner = false and user is host(CT), display T won message
                            if (isHost)
                            {
                                resultTerrorists();
                            }
                            // if isWinner = false and user is client(T), display CT won message
                            else
                            {
                                resultCounterTerrorists();
                            }
                        }
                    }
                    else
                    {
                        if ((isWinner) && (isHost))
                        {
                            resultCounterTerrorists();
                            swapPlayerHighlight();
                            

                        }
                        else if (isWinner)
                        {
                            resultTerrorists();
                            swapPlayerHighlight();
                            
                        }
                    }

                    panelRoundWinner.Show();
                    buttonScoreT.Text = scoreT.ToString();
                    buttonScoreCT.Text = scoreCT.ToString();

                }
            }
            else
            {
                this.Invoke((MethodInvoker)delegate { checkBoardState();});
            }
        }

        private void resultTerrorists()
        {
            soundEffectPlayer1.settings.volume = 20;
            soundEffectPlayer1.URL = @"Resources\sound_TWin.wav";

            scoreT += 1;
            labelRoundWinner.Text = "Terrorists Win";
            pictureBoxWinningTeam.Image = Properties.Resources.icon_terrorist;

        }
        private void resultCounterTerrorists()
        {
            soundEffectPlayer1.settings.volume = 20;
            soundEffectPlayer1.URL = @"Resources\sound_CTWin.wav";

            scoreCT += 1;
            labelRoundWinner.Text = "Counter-Terrorists Win";
            pictureBoxWinningTeam.Image = Properties.Resources.icon_CT_1;
        }

        ////////////////////////////////////////////////////////////////////////
        /// END GAME BOARD LOGIC
        ////////////////////////////////////////////////////////////////////////

        private void setBoardBasedOnBoxName(string code)
        {
            // 0=netral, 1=server, 2=clint
            char[] realCodeInChar = code.Substring(1).ToCharArray();
            board[Int32.Parse("" + realCodeInChar[0])][Int32.Parse("" + realCodeInChar[1])] = isHost ? 1 : 2;
        }


        ///GAME BOX CLICKED
        private void gameBox_Click(object sender, MouseEventArgs e)
        {
            //soundEffectPlayer2.URL = @"sound_click_5.wav";
           // soundEffectPlayer2.settings.volume = 5;
           

            PictureBox clickedBox = sender as PictureBox;   

            if ((isMyTurn) && (!haveWinner))
            {
                if ((clickedBox.Image == null))
                {
                    if (networkGame)
                    {


                        setBoardBasedOnBoxName(((PictureBox)sender).Name);
                        
                        con.sendBoard(board);
                        isMyTurn = false;
                        checkBoardState();
                        swapPlayerHighlight();
                        checkTurn();
                    }
                    else
                    {
                        if (isHost)
                        {
                           // soundEffectPlayer2.URL = @"sound_TClick.wav";
                        }
                        else
                        {
                            //soundEffectPlayer1.URL = @"sound_CTClick.wav";
                        }

                        swapPlayerHighlight();
                        isHost = !isHost;

                        setBoardBasedOnBoxName(((PictureBox)sender).Name);
                        checkBoardState();
                        
                        
                        resetBoard();
                    }
                }
            }
        }

        private void highlightCT()
        {
            pictureBoxPortraitRightT.Image = Properties.Resources.portrait_terrorist_alt_3;
            pictureBoxLogoRightT.Image = Properties.Resources.icon_terrorist_alt;
            labelTeamRight.ForeColor = Color.Gray;
            labelPlayerNameRight.ForeColor = Color.Gray;

            pictureBoxPortraitLeftCT.Image = Properties.Resources.portrait_CT_3;
            pictureBoxLogoLeftCT.Image = Properties.Resources.icon_CT_1;
            labelTeamLeft.ForeColor = Color.LightSkyBlue;
            labelPlayerNameLeft.ForeColor = Color.Gainsboro;


        }

        private void highlightT()
        {
            pictureBoxPortraitLeftCT.Image = Properties.Resources.portrait_CT_alt_3;
            pictureBoxLogoLeftCT.Image = Properties.Resources.icon_CT_alt_1;
            labelTeamLeft.ForeColor = Color.Gray;
            labelPlayerNameLeft.ForeColor = Color.Gray;

            pictureBoxPortraitRightT.Image = Properties.Resources.portrait_terrorist_3;
            pictureBoxLogoRightT.Image = Properties.Resources.icon_terrorist;
            labelTeamRight.ForeColor = Color.Khaki;
            labelPlayerNameRight.ForeColor = Color.Gainsboro;


        }

        private void swapPlayerHighlight()
        {
            if (haveWinner && networkGame)
            {
                return;
            }

            //if host(CT) clicks box, set CT to grey and T to normal on both apps
            //if client(T) clicks box, set T to grey and CT to normal on both apps

            //
                if (isHost)
                {
                    if (isMyTurn)
                    {
                        if (!haveWinner)
                        {
                            soundEffectPlayer1.settings.volume = 40;
                            soundEffectPlayer1.URL = @"Resources\sound_TClick.wav";
                        }

                        highlightCT();
                    }
                    else
                    {
                        if (!haveWinner)
                        {
                            soundEffectPlayer2.settings.volume = 40;
                            soundEffectPlayer2.URL = @"Resources\sound_CTClick.wav";
                        }
                        highlightT();

                    }
                }
                else
                {
                    if (isMyTurn)
                    {
                        if (!haveWinner)
                        {
                            soundEffectPlayer2.settings.volume = 40;
                            soundEffectPlayer2.URL = @"Resources\sound_CTClick.wav";
                        }
                        highlightT();
                    }
                    else
                    {
                        if (!haveWinner)
                        {
                            soundEffectPlayer1.settings.volume = 40;
                            soundEffectPlayer1.URL = @"Resources\sound_TClick.wav";
                        }
                        highlightCT();
                    }
                }          
        }

        private void endGame()
        {
            scoreCT = 0;
            scoreT = 0;
            buttonScoreCT.Text = scoreCT.ToString();
            buttonScoreT.Text = scoreT.ToString();

            jamesMediaPlayer.URL = AppDomain.CurrentDomain.BaseDirectory + @"Resources\CSGOMenuTheme.wav";

            labelSelectBack.Visible = false;
            labelSelectNetwork.Visible = false;
            labelSelectShared.Visible = false;

            labelSelectPlay.Visible = true;
            labelSelectCredits.Visible = true;
            labelSelectExit.Visible = true;
            labelSelectOptions.Visible = true;


            panelMainMenu.Show();
            //panelNetworkSetup.Show();

            panelGameBoard.Hide();
            panelLeftPlayerCT.Hide();
            panelRightPlayerT.Hide();
            panelScoreTime.Hide();

            this.BackgroundImage = Properties.Resources.form_back_1;
        }

        private void timerNextRound_Tick(object sender, EventArgs e)
        {

            timerNextRound.Stop();
            panelRoundWinner.Hide();

            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    board[i][k] = 0;
                }

            }

            if (networkGame)
            {
                isMyTurn = isWinner;
                haveWinner = false;
                checkTurn();
            }
            else
            {
                swapPlayerHighlight();
                isHost = !isHost;
                
            }

            isWinner = false;
            haveWinner = false;

            clock.Restart();
            resetBoard();

            if (scoreCT == 9)
            {
                DialogResult dialogResult = MessageBox.Show("Counter-Terrorists have won 9 rounds, claiming victory over the Terrorists.\nPlay again?", "Counter-Terrorist Victory", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    scoreCT = 0;
                    scoreT = 0;
                }
                else
                {
                    endGame();
                }
            }
            else if (scoreT == 9)
            {
                DialogResult dialogResult = MessageBox.Show("Terrorists have won 9 rounds, claiming victory over the Counter-Terrorists.\nPlay again?", "Terrorist Victory", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    scoreCT = 0;
                    scoreT = 0;
                }
                else
                {
                    endGame();
                }
            }
            
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = clock.Elapsed;

            if (haveWinner == false)
            {
                buttonClock.ForeColor = Color.Gainsboro;
                string elapsed = String.Format("{0}:{1:00}", ts.Minutes, ts.Seconds);
                buttonClock.Text = elapsed;
            }
            else
            {
                buttonClock.ForeColor = Color.Red;
                string elapsed = String.Format("{0}:{1:00}", ts.Minutes, 5 - ts.Seconds);
                buttonClock.Text = elapsed;
            }

        }

        private void keyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit?", "Exit to main menu?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    
                    timerNextRound.Stop();
                    panelRoundWinner.Hide();

                    for (int i = 0; i < 3; i++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            board[i][k] = 0;
                        }

                    }

                    isWinner = false;
                    haveWinner = false;

                    clock.Stop();
                    resetBoard();
                    endGame();
                }
                else
                {
                    return;
                }
            }
        }

    ///
    /// END GAME
    ////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////
    /// 
    ///  NETWORK SETUP MENU
    ///

        private void pictureButton_Enter(object sender, EventArgs e)
        {
            PictureBox boxEntered = sender as PictureBox;

            Padding p = new Padding(2,2,2,2);

            

            boxEntered.Padding = p;
            boxEntered.Refresh();

            if (canStart == false)
            {
                soundEffectPlayer2.URL = @"Resources\sound_rollover.wav";
            }

        }

        private void pictureButton_Leave(object sender, EventArgs e)
        {
           
            PictureBox boxEntered = sender as PictureBox;

            Padding p = new Padding(10, 10, 10, 10);

            if (canStart == false)
            {
                
                boxEntered.Padding = p;
                boxEntered.Refresh();
            }

        }

        private void labelSelectGo_Enter(object sender, EventArgs e)
        {
            if (canStart)
            {
                soundEffectPlayer1.URL = @"Resources\sound_rollover.wav";
                labelSelectGo.Image = Properties.Resources.button_back_green_alt_2;
            }
        }

        private void labelSelectGo_Leave(object sender, EventArgs e)
        {
            if (canStart)
            {
                labelSelectGo.Image = Properties.Resources.button_back_green_2;
            }
        }

        private void pictureButtonCT_Click(object sender, EventArgs e)
        {
            soundEffectPlayer2.URL = @"Resources\sound_click_5.wav";

            canStart = true;
            labelSelectGo.Image = Properties.Resources.button_back_green_2;

            Padding p = new Padding(10, 10, 10, 10);
            pictureButtonT.Padding = p;
            pictureButtonT.Refresh();

            pictureButtonCT.Image = Properties.Resources.icon_CT_1;
            labelNetworkNameCT.ForeColor = Color.LightSkyBlue;

            pictureButtonT.Image = Properties.Resources.icon_terrorist_alt;
            labelNetworkNameT.ForeColor = Color.Gray;

            isHost = true;
            isMyTurn = true;
        }

        private void pictureButtonT_Click(object sender, EventArgs e)
        {
            soundEffectPlayer2.URL = @"Resources\sound_click_5.wav";

            canStart = true;
            labelSelectGo.Image = Properties.Resources.button_back_green_2;

            Padding p = new Padding(10, 10, 10, 10);
            pictureButtonCT.Padding = p;
            pictureButtonCT.Refresh();

            pictureButtonT.Image = Properties.Resources.icon_terrorist;
            labelNetworkNameT.ForeColor = Color.Khaki;

            pictureButtonCT.Image = Properties.Resources.icon_CT_alt_1;
            labelNetworkNameCT.ForeColor = Color.Gray;

            isHost = false;
            isMyTurn = false;
        }
    ///
    /// END NETWORK SETUP MENU
    ////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////
    /// NETWORK CONNECTION
    ///
        private void labelSelectGo_Click(object sender, EventArgs e)
        {
            if (canStart)
            {
                if (checkIPandPort(textBoxIP.Text, textBoxPort.Text))
                {

                    
                    networkGame = true;
                    if (isHost)
                    {
                        ConnectAsServer(textBoxIP.Text, Int32.Parse(textBoxPort.Text));
                    }
                    else
                    {
                        ConnectAsClient(textBoxIP.Text, Int32.Parse(textBoxPort.Text));
                    }
                }
                else
                {
                    MessageBox.Show("Invalid IP Address/Port");
                }
            }
        }

        private bool checkIPandPort(string ip, string port)
        {
            //Check the ip and port is in valid format
            if (Regex.IsMatch(ip, @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$") && Regex.IsMatch(port, "^[0-9]{1,6}$"))
            {
                string[] temp = ip.Split('.');
                foreach (string q in temp)
                {
                    try
                    {
                        if (Int32.Parse(q) > 255) return false;
                    }
                    catch (Exception) { return false; }
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
                startGame();
            }
        }
        private void ConnectAsClient(string ip, int port)
        {
            con = new SocketManagement(ip, port);
            if (con.StartAsClient())
            {
                startGame();
            }
        }

        //triggered on opponents click
        private void GetDataFromOthers()
        {
            Task.Factory.StartNew(() =>
            {
                board = con.getBoard();
                isMyTurn = true;
                checkBoardState();
                swapPlayerHighlight();
                checkTurn();
                
            });
        }

        private void checkTurn()
        {
            if (!this.InvokeRequired)
            {
                if (isMyTurn && !haveWinner)
                {
                    SetEnabled(true);

                }
                else
                {
                    SetEnabled(false);


     
                    GetDataFromOthers();
                }
                resetBoard();
                //swapPlayerHighlight();
            }
            else
            {
                this.Invoke((MethodInvoker)delegate { checkTurn(); });
            }
        }



        private void labelSelectGeneral_Click(object sender, EventArgs e)
        {

            soundEffectPlayer2.URL = @"Resources\sound_click_5.wav";
            //soundEffectPlayer1.settings.volume = 10;
            
 

            if (sender == labelSelectPlay)
            {

                panelHelp.Hide();
                panelCredits.Hide();

                labelSelectPlay.Visible = false;
                labelSelectCredits.Visible = false;
                labelSelectExit.Visible = false;
                labelSelectOptions.Visible = false;

                labelSelectNetwork.Visible = true;
                labelSelectShared.Visible = true;
                labelSelectBack.Visible = true;
            }

            if (sender == labelSelectBack)
            {
                labelSelectPlay.Visible = true;
                labelSelectCredits.Visible = true;
                labelSelectExit.Visible = true;
                labelSelectOptions.Visible = true;

                labelSelectNetwork.Visible = false;
                labelSelectShared.Visible = false;
                labelSelectBack.Visible = false;

                panelNetworkSetup.Hide();
                panelHelp.Hide();
                panelCredits.Hide();
            }

            if (sender == labelSelectShared)
            {
                networkGame = false;
                startGame();
            }

            if (sender == labelSelectCredits)
            {
                panelHelp.Hide();
                panelCredits.Show();
                labelSelectExit.Visible = false;
                labelSelectBack.Visible = true;
            }

            if (sender == labelSelectOptions)
            {
                panelCredits.Hide();
                panelHelp.Show();
                labelSelectExit.Visible = false;
                labelSelectBack.Visible = true;
            }

            if (sender ==  labelSelectNetwork)
            {
                panelNetworkSetup.Show();
                panelNetworkSetup.BringToFront();
            }

            if (sender == labelSelectExit)
            {
                Close();
            }
        }



    ///
    /// END NETWORK SETUP MENU
    ////////////////////////////////////////////////////////////////////////////

    }
}
