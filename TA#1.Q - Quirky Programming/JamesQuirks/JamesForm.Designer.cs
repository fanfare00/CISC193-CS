namespace JamesQuirks
{
    partial class quirkyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.buttonElapsedTime = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelPersonName = new System.Windows.Forms.Label();
            this.labelAllQuirks = new System.Windows.Forms.Label();
            this.pictureBoxAllQuirks = new System.Windows.Forms.PictureBox();
            this.buttonQuirk2 = new System.Windows.Forms.Button();
            this.buttonQuirk1 = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.labelQuirkHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.timerElapsed = new System.Windows.Forms.Timer(this.components);
            this.labelElapsed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllQuirks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.BackColor = System.Drawing.Color.Transparent;
            this.labelWelcome.Font = new System.Drawing.Font("Minion Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(21, 9);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(97, 18);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "James McCarthy";
            // 
            // labelDateTime
            // 
            this.labelDateTime.BackColor = System.Drawing.Color.Transparent;
            this.labelDateTime.Font = new System.Drawing.Font("Minion Pro", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateTime.Location = new System.Drawing.Point(691, 1);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(93, 50);
            this.labelDateTime.TabIndex = 1;
            this.labelDateTime.Text = "12/01/1990";
            this.labelDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonElapsedTime
            // 
            this.buttonElapsedTime.FlatAppearance.BorderSize = 0;
            this.buttonElapsedTime.Font = new System.Drawing.Font("Minion Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonElapsedTime.Location = new System.Drawing.Point(86, 416);
            this.buttonElapsedTime.Name = "buttonElapsedTime";
            this.buttonElapsedTime.Size = new System.Drawing.Size(113, 28);
            this.buttonElapsedTime.TabIndex = 2;
            this.buttonElapsedTime.Text = "Elapsed Time";
            this.buttonElapsedTime.UseVisualStyleBackColor = true;
            this.buttonElapsedTime.Click += new System.EventHandler(this.buttonElapsedTime_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(336, 510);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(113, 34);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelPersonName
            // 
            this.labelPersonName.BackColor = System.Drawing.Color.Transparent;
            this.labelPersonName.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPersonName.Location = new System.Drawing.Point(86, 77);
            this.labelPersonName.Name = "labelPersonName";
            this.labelPersonName.Size = new System.Drawing.Size(113, 34);
            this.labelPersonName.TabIndex = 12;
            this.labelPersonName.Text = "James";
            this.labelPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAllQuirks
            // 
            this.labelAllQuirks.BackColor = System.Drawing.Color.Transparent;
            this.labelAllQuirks.Font = new System.Drawing.Font("Franklin Gothic Book", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllQuirks.Location = new System.Drawing.Point(267, 397);
            this.labelAllQuirks.Name = "labelAllQuirks";
            this.labelAllQuirks.Size = new System.Drawing.Size(460, 80);
            this.labelAllQuirks.TabIndex = 13;
            this.labelAllQuirks.Text = "Quirks Go Here";
            // 
            // pictureBoxAllQuirks
            // 
            this.pictureBoxAllQuirks.Location = new System.Drawing.Point(271, 114);
            this.pictureBoxAllQuirks.Name = "pictureBoxAllQuirks";
            this.pictureBoxAllQuirks.Size = new System.Drawing.Size(456, 280);
            this.pictureBoxAllQuirks.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAllQuirks.TabIndex = 14;
            this.pictureBoxAllQuirks.TabStop = false;
            // 
            // buttonQuirk2
            // 
            this.buttonQuirk2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuirk2.Location = new System.Drawing.Point(77, 326);
            this.buttonQuirk2.Name = "buttonQuirk2";
            this.buttonQuirk2.Size = new System.Drawing.Size(135, 45);
            this.buttonQuirk2.TabIndex = 15;
            this.buttonQuirk2.Text = "Quirk #2";
            this.buttonQuirk2.UseVisualStyleBackColor = true;
            this.buttonQuirk2.Click += new System.EventHandler(this.buttonQuirk2_Click);
            // 
            // buttonQuirk1
            // 
            this.buttonQuirk1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuirk1.Location = new System.Drawing.Point(77, 275);
            this.buttonQuirk1.Name = "buttonQuirk1";
            this.buttonQuirk1.Size = new System.Drawing.Size(135, 45);
            this.buttonQuirk1.TabIndex = 16;
            this.buttonQuirk1.Text = "Quirk #1";
            this.buttonQuirk1.UseVisualStyleBackColor = true;
            this.buttonQuirk1.Click += new System.EventHandler(this.buttonQuirk1_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.SystemColors.Control;
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonNext.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonNext.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.Font = new System.Drawing.Font("Minion Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNext.Location = new System.Drawing.Point(153, 232);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 17;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Font = new System.Drawing.Font("Minion Pro", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrevious.Location = new System.Drawing.Point(60, 232);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevious.TabIndex = 18;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.button4_Click);
            // 
            // labelQuirkHeader
            // 
            this.labelQuirkHeader.AutoSize = true;
            this.labelQuirkHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelQuirkHeader.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuirkHeader.Location = new System.Drawing.Point(442, 87);
            this.labelQuirkHeader.Name = "labelQuirkHeader";
            this.labelQuirkHeader.Size = new System.Drawing.Size(131, 24);
            this.labelQuirkHeader.TabIndex = 19;
            this.labelQuirkHeader.Text = "James\'s Quirk #1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "GUI Quirky Program";
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(86, 114);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(113, 103);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 21;
            this.pictureBoxProfile.TabStop = false;
            // 
            // timerElapsed
            // 
            this.timerElapsed.Enabled = true;
            this.timerElapsed.Interval = 1000;
            this.timerElapsed.Tick += new System.EventHandler(this.timerElapsed_Tick);
            // 
            // labelElapsed
            // 
            this.labelElapsed.BackColor = System.Drawing.Color.Transparent;
            this.labelElapsed.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelElapsed.ForeColor = System.Drawing.Color.Maroon;
            this.labelElapsed.Location = new System.Drawing.Point(93, 447);
            this.labelElapsed.Name = "labelElapsed";
            this.labelElapsed.Size = new System.Drawing.Size(100, 23);
            this.labelElapsed.TabIndex = 22;
            this.labelElapsed.Text = "00:00:00";
            this.labelElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelElapsed.Visible = false;
            // 
            // quirkyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JamesQuirks.Properties.Resources.p1_bkg;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.labelElapsed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelQuirkHeader);
            this.Controls.Add(this.labelPersonName);
            this.Controls.Add(this.buttonElapsedTime);
            this.Controls.Add(this.labelDateTime);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelAllQuirks);
            this.Controls.Add(this.pictureBoxAllQuirks);
            this.Controls.Add(this.buttonQuirk2);
            this.Controls.Add(this.buttonQuirk1);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.pictureBoxProfile);
            this.Controls.Add(this.buttonPrevious);
            this.Name = "quirkyForm";
            this.Text = "James\' GUI Quirky Program";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllQuirks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Button buttonElapsedTime;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelPersonName;
        private System.Windows.Forms.Label labelAllQuirks;
        private System.Windows.Forms.PictureBox pictureBoxAllQuirks;
        private System.Windows.Forms.Button buttonQuirk2;
        private System.Windows.Forms.Button buttonQuirk1;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Label labelQuirkHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Timer timerElapsed;
        private System.Windows.Forms.Label labelElapsed;
    }
}

