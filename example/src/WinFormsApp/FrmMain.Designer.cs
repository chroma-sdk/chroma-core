namespace ChromaFormsApp
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlStatic = new System.Windows.Forms.Panel();
            this.cmdYellow = new System.Windows.Forms.Button();
            this.cmdBlue = new System.Windows.Forms.Button();
            this.cmdWhite = new System.Windows.Forms.Button();
            this.cmdRed = new System.Windows.Forms.Button();
            this.cmdGreen = new System.Windows.Forms.Button();
            this.lblColors = new System.Windows.Forms.Label();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdUnregister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.pnlStatic.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlStatic
            // 
            this.pnlStatic.BackColor = System.Drawing.Color.LightGray;
            this.pnlStatic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatic.Controls.Add(this.cmdYellow);
            this.pnlStatic.Controls.Add(this.cmdBlue);
            this.pnlStatic.Controls.Add(this.cmdWhite);
            this.pnlStatic.Controls.Add(this.cmdRed);
            this.pnlStatic.Controls.Add(this.cmdGreen);
            this.pnlStatic.Location = new System.Drawing.Point(0, 26);
            this.pnlStatic.Name = "pnlStatic";
            this.pnlStatic.Size = new System.Drawing.Size(419, 38);
            this.pnlStatic.TabIndex = 0;
            // 
            // cmdYellow
            // 
            this.cmdYellow.BackColor = System.Drawing.Color.Yellow;
            this.cmdYellow.ForeColor = System.Drawing.Color.Black;
            this.cmdYellow.Location = new System.Drawing.Point(331, 7);
            this.cmdYellow.Name = "cmdYellow";
            this.cmdYellow.Size = new System.Drawing.Size(75, 23);
            this.cmdYellow.TabIndex = 4;
            this.cmdYellow.Text = "Yellow";
            this.cmdYellow.UseVisualStyleBackColor = false;
            this.cmdYellow.Click += new System.EventHandler(this.SetColorCommand_Click);
            // 
            // cmdBlue
            // 
            this.cmdBlue.BackColor = System.Drawing.Color.Blue;
            this.cmdBlue.ForeColor = System.Drawing.Color.White;
            this.cmdBlue.Location = new System.Drawing.Point(248, 7);
            this.cmdBlue.Name = "cmdBlue";
            this.cmdBlue.Size = new System.Drawing.Size(75, 23);
            this.cmdBlue.TabIndex = 3;
            this.cmdBlue.Text = "Blue";
            this.cmdBlue.UseVisualStyleBackColor = false;
            this.cmdBlue.Click += new System.EventHandler(this.SetColorCommand_Click);
            // 
            // cmdWhite
            // 
            this.cmdWhite.BackColor = System.Drawing.Color.White;
            this.cmdWhite.Location = new System.Drawing.Point(167, 7);
            this.cmdWhite.Name = "cmdWhite";
            this.cmdWhite.Size = new System.Drawing.Size(75, 23);
            this.cmdWhite.TabIndex = 2;
            this.cmdWhite.Text = "White";
            this.cmdWhite.UseVisualStyleBackColor = false;
            this.cmdWhite.Click += new System.EventHandler(this.SetColorCommand_Click);
            // 
            // cmdRed
            // 
            this.cmdRed.BackColor = System.Drawing.Color.Red;
            this.cmdRed.ForeColor = System.Drawing.Color.White;
            this.cmdRed.Location = new System.Drawing.Point(86, 7);
            this.cmdRed.Name = "cmdRed";
            this.cmdRed.Size = new System.Drawing.Size(75, 23);
            this.cmdRed.TabIndex = 1;
            this.cmdRed.Text = "Red";
            this.cmdRed.UseVisualStyleBackColor = false;
            this.cmdRed.Click += new System.EventHandler(this.SetColorCommand_Click);
            // 
            // cmdGreen
            // 
            this.cmdGreen.BackColor = System.Drawing.Color.Green;
            this.cmdGreen.ForeColor = System.Drawing.Color.White;
            this.cmdGreen.Location = new System.Drawing.Point(5, 7);
            this.cmdGreen.Name = "cmdGreen";
            this.cmdGreen.Size = new System.Drawing.Size(75, 23);
            this.cmdGreen.TabIndex = 0;
            this.cmdGreen.Text = "Green";
            this.cmdGreen.UseVisualStyleBackColor = false;
            this.cmdGreen.Click += new System.EventHandler(this.SetColorCommand_Click);
            // 
            // lblColors
            // 
            this.lblColors.AutoSize = true;
            this.lblColors.Location = new System.Drawing.Point(0, 8);
            this.lblColors.Name = "lblColors";
            this.lblColors.Size = new System.Drawing.Size(55, 13);
            this.lblColors.TabIndex = 1;
            this.lblColors.Text = "Set Colors";
            // 
            // lstLog
            // 
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(0, 214);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(419, 93);
            this.lstLog.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmdUnregister);
            this.panel1.Location = new System.Drawing.Point(3, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 38);
            this.panel1.TabIndex = 3;
            // 
            // cmdUnregister
            // 
            this.cmdUnregister.BackColor = System.Drawing.Color.Black;
            this.cmdUnregister.ForeColor = System.Drawing.Color.White;
            this.cmdUnregister.Location = new System.Drawing.Point(3, 8);
            this.cmdUnregister.Name = "cmdUnregister";
            this.cmdUnregister.Size = new System.Drawing.Size(75, 23);
            this.cmdUnregister.TabIndex = 3;
            this.cmdUnregister.Text = "Unregister";
            this.cmdUnregister.UseVisualStyleBackColor = false;
            this.cmdUnregister.Click += new System.EventHandler(this.cmdUnregister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Set Devices";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 38);
            this.panel2.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Yellow;
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(329, 11);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Keypad";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.SetDeviceCommand_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(248, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Headset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SetDeviceCommand_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(167, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Mousepad";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.SetDeviceCommand_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Red;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(86, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Mouse";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.SetDeviceCommand_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Green;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(5, 11);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Keyboard";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.SetDeviceCommand_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 319);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.lblColors);
            this.Controls.Add(this.pnlStatic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chroma Forms App";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.pnlStatic.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlStatic;
        private System.Windows.Forms.Button cmdGreen;
        private System.Windows.Forms.Label lblColors;
        private System.Windows.Forms.Button cmdBlue;
        private System.Windows.Forms.Button cmdWhite;
        private System.Windows.Forms.Button cmdRed;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdUnregister;
        private System.Windows.Forms.Button cmdYellow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

