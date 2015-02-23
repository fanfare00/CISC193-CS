namespace SocketExample
{
    partial class Form1
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
            this.boxIP = new System.Windows.Forms.TextBox();
            this.boxPort = new System.Windows.Forms.TextBox();
            this.buttonClient = new System.Windows.Forms.Button();
            this.buttonHost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.boxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // boxIP
            // 
            this.boxIP.Location = new System.Drawing.Point(194, 36);
            this.boxIP.Name = "boxIP";
            this.boxIP.Size = new System.Drawing.Size(100, 20);
            this.boxIP.TabIndex = 0;
            this.boxIP.Text = "IP";
            // 
            // boxPort
            // 
            this.boxPort.Location = new System.Drawing.Point(194, 62);
            this.boxPort.Name = "boxPort";
            this.boxPort.Size = new System.Drawing.Size(100, 20);
            this.boxPort.TabIndex = 1;
            this.boxPort.Text = "Port";
            // 
            // buttonClient
            // 
            this.buttonClient.Location = new System.Drawing.Point(278, 262);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(75, 23);
            this.buttonClient.TabIndex = 3;
            this.buttonClient.Text = "Client";
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // buttonHost
            // 
            this.buttonHost.Location = new System.Drawing.Point(136, 262);
            this.buttonHost.Name = "buttonHost";
            this.buttonHost.Size = new System.Drawing.Size(75, 23);
            this.buttonHost.TabIndex = 4;
            this.buttonHost.Text = "Host";
            this.buttonHost.UseVisualStyleBackColor = true;
            this.buttonHost.Click += new System.EventHandler(this.buttonHost_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "The other user\'s says:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "blank";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(207, 304);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 7;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // boxName
            // 
            this.boxName.Location = new System.Drawing.Point(136, 200);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(208, 20);
            this.boxName.TabIndex = 8;
            this.boxName.Text = "My Name is ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 339);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonHost);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.boxPort);
            this.Controls.Add(this.boxIP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxIP;
        private System.Windows.Forms.TextBox boxPort;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.Button buttonHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox boxName;
    }
}

