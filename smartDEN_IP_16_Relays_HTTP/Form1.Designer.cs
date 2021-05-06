namespace smartDEN_IP_16_Relays_HTTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.relay12 = new System.Windows.Forms.CheckBox();
            this.relay107 = new System.Windows.Forms.CheckBox();
            this.relay108 = new System.Windows.Forms.CheckBox();
            this.relay105 = new System.Windows.Forms.CheckBox();
            this.relay104 = new System.Windows.Forms.CheckBox();
            this.relay103 = new System.Windows.Forms.CheckBox();
            this.relay102 = new System.Windows.Forms.CheckBox();
            this.relay101 = new System.Windows.Forms.CheckBox();
            this.relay106 = new System.Windows.Forms.CheckBox();
            this.relay5 = new System.Windows.Forms.CheckBox();
            this.relay6 = new System.Windows.Forms.CheckBox();
            this.relay7 = new System.Windows.Forms.CheckBox();
            this.relay8 = new System.Windows.Forms.CheckBox();
            this.relay11 = new System.Windows.Forms.CheckBox();
            this.relay13 = new System.Windows.Forms.CheckBox();
            this.relay14 = new System.Windows.Forms.CheckBox();
            this.relay15 = new System.Windows.Forms.CheckBox();
            this.relay16 = new System.Windows.Forms.CheckBox();
            this.relay10 = new System.Windows.Forms.CheckBox();
            this.relay9 = new System.Windows.Forms.CheckBox();
            this.relay4 = new System.Windows.Forms.CheckBox();
            this.relay3 = new System.Windows.Forms.CheckBox();
            this.relay2 = new System.Windows.Forms.CheckBox();
            this.relay1 = new System.Windows.Forms.CheckBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.Label();
            this.relaysGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.relaysGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.refreshButton);
            this.groupBox1.Controls.Add(this.passwordTextBox);
            this.groupBox1.Controls.Add(this.portTextBox);
            this.groupBox1.Controls.Add(this.ipTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 251);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(22, 92);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(249, 25);
            this.refreshButton.TabIndex = 6;
            this.refreshButton.Text = "Connect";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(128, 65);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.ReadOnly = true;
            this.passwordTextBox.Size = new System.Drawing.Size(144, 20);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.Text = "admin";
            this.passwordTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(128, 43);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.ReadOnly = true;
            this.portTextBox.Size = new System.Drawing.Size(144, 20);
            this.portTextBox.TabIndex = 4;
            this.portTextBox.Text = "80";
            this.portTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(128, 21);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.ReadOnly = true;
            this.ipTextBox.Size = new System.Drawing.Size(144, 20);
            this.ipTextBox.TabIndex = 3;
            this.ipTextBox.Text = "192.168.1.28";
            this.ipTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // relay12
            // 
            this.relay12.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay12.AutoSize = true;
            this.relay12.Location = new System.Drawing.Point(154, 88);
            this.relay12.Name = "relay12";
            this.relay12.Size = new System.Drawing.Size(59, 23);
            this.relay12.TabIndex = 24;
            this.relay12.Text = "Relay 12";
            this.relay12.UseVisualStyleBackColor = true;
            this.relay12.CheckedChanged += new System.EventHandler(this.relay12_CheckedChanged_1);
            // 
            // relay107
            // 
            this.relay107.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay107.AutoSize = true;
            this.relay107.Location = new System.Drawing.Point(6, 158);
            this.relay107.Name = "relay107";
            this.relay107.Size = new System.Drawing.Size(65, 23);
            this.relay107.TabIndex = 23;
            this.relay107.Text = "Relay 107";
            this.relay107.UseVisualStyleBackColor = true;
            this.relay107.CheckedChanged += new System.EventHandler(this.relay107_CheckedChanged);
            // 
            // relay108
            // 
            this.relay108.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay108.AutoSize = true;
            this.relay108.Location = new System.Drawing.Point(6, 183);
            this.relay108.Name = "relay108";
            this.relay108.Size = new System.Drawing.Size(65, 23);
            this.relay108.TabIndex = 22;
            this.relay108.Text = "Relay 108";
            this.relay108.UseVisualStyleBackColor = true;
            this.relay108.CheckedChanged += new System.EventHandler(this.relay108_CheckedChanged);
            // 
            // relay105
            // 
            this.relay105.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay105.AutoSize = true;
            this.relay105.Location = new System.Drawing.Point(6, 111);
            this.relay105.Name = "relay105";
            this.relay105.Size = new System.Drawing.Size(65, 23);
            this.relay105.TabIndex = 21;
            this.relay105.Text = "Relay 105";
            this.relay105.UseVisualStyleBackColor = true;
            this.relay105.CheckedChanged += new System.EventHandler(this.relay105_CheckedChanged);
            // 
            // relay104
            // 
            this.relay104.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay104.AutoSize = true;
            this.relay104.Location = new System.Drawing.Point(6, 88);
            this.relay104.Name = "relay104";
            this.relay104.Size = new System.Drawing.Size(65, 23);
            this.relay104.TabIndex = 20;
            this.relay104.Text = "Relay 104";
            this.relay104.UseVisualStyleBackColor = true;
            this.relay104.CheckedChanged += new System.EventHandler(this.relay104_CheckedChanged);
            // 
            // relay103
            // 
            this.relay103.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay103.AutoSize = true;
            this.relay103.Location = new System.Drawing.Point(6, 65);
            this.relay103.Name = "relay103";
            this.relay103.Size = new System.Drawing.Size(65, 23);
            this.relay103.TabIndex = 19;
            this.relay103.Text = "Relay 103";
            this.relay103.UseVisualStyleBackColor = true;
            this.relay103.CheckedChanged += new System.EventHandler(this.relay103_CheckedChanged);
            // 
            // relay102
            // 
            this.relay102.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay102.AutoSize = true;
            this.relay102.Location = new System.Drawing.Point(6, 42);
            this.relay102.Name = "relay102";
            this.relay102.Size = new System.Drawing.Size(65, 23);
            this.relay102.TabIndex = 18;
            this.relay102.Text = "Relay 102";
            this.relay102.UseVisualStyleBackColor = true;
            this.relay102.CheckedChanged += new System.EventHandler(this.relay102_CheckedChanged);
            // 
            // relay101
            // 
            this.relay101.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay101.AutoSize = true;
            this.relay101.Location = new System.Drawing.Point(6, 19);
            this.relay101.Name = "relay101";
            this.relay101.Size = new System.Drawing.Size(65, 23);
            this.relay101.TabIndex = 17;
            this.relay101.Text = "Relay 101";
            this.relay101.UseVisualStyleBackColor = true;
            this.relay101.CheckedChanged += new System.EventHandler(this.relay101_CheckedChanged);
            // 
            // relay106
            // 
            this.relay106.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay106.AutoSize = true;
            this.relay106.Location = new System.Drawing.Point(6, 135);
            this.relay106.Name = "relay106";
            this.relay106.Size = new System.Drawing.Size(65, 23);
            this.relay106.TabIndex = 16;
            this.relay106.Text = "Relay 106";
            this.relay106.UseVisualStyleBackColor = true;
            this.relay106.CheckedChanged += new System.EventHandler(this.relay106_CheckedChanged);
            // 
            // relay5
            // 
            this.relay5.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay5.AutoSize = true;
            this.relay5.Location = new System.Drawing.Point(80, 111);
            this.relay5.Name = "relay5";
            this.relay5.Size = new System.Drawing.Size(53, 23);
            this.relay5.TabIndex = 15;
            this.relay5.Text = "Relay 5";
            this.relay5.UseVisualStyleBackColor = true;
            this.relay5.CheckedChanged += new System.EventHandler(this.relay5_CheckedChanged);
            // 
            // relay6
            // 
            this.relay6.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay6.AutoSize = true;
            this.relay6.Location = new System.Drawing.Point(80, 135);
            this.relay6.Name = "relay6";
            this.relay6.Size = new System.Drawing.Size(53, 23);
            this.relay6.TabIndex = 14;
            this.relay6.Text = "Relay 6";
            this.relay6.UseVisualStyleBackColor = true;
            this.relay6.CheckedChanged += new System.EventHandler(this.relay6_CheckedChanged);
            // 
            // relay7
            // 
            this.relay7.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay7.AutoSize = true;
            this.relay7.Location = new System.Drawing.Point(80, 158);
            this.relay7.Name = "relay7";
            this.relay7.Size = new System.Drawing.Size(53, 23);
            this.relay7.TabIndex = 13;
            this.relay7.Text = "Relay 7";
            this.relay7.UseVisualStyleBackColor = true;
            this.relay7.CheckedChanged += new System.EventHandler(this.relay7_CheckedChanged);
            // 
            // relay8
            // 
            this.relay8.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay8.AutoSize = true;
            this.relay8.Location = new System.Drawing.Point(80, 183);
            this.relay8.Name = "relay8";
            this.relay8.Size = new System.Drawing.Size(53, 23);
            this.relay8.TabIndex = 12;
            this.relay8.Text = "Relay 8";
            this.relay8.UseVisualStyleBackColor = true;
            this.relay8.CheckedChanged += new System.EventHandler(this.relay8_CheckedChanged);
            // 
            // relay11
            // 
            this.relay11.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay11.AutoSize = true;
            this.relay11.Location = new System.Drawing.Point(154, 65);
            this.relay11.Name = "relay11";
            this.relay11.Size = new System.Drawing.Size(59, 23);
            this.relay11.TabIndex = 11;
            this.relay11.Text = "Relay 11";
            this.relay11.UseVisualStyleBackColor = true;
            this.relay11.CheckedChanged += new System.EventHandler(this.relay11_CheckedChanged);
            // 
            // relay13
            // 
            this.relay13.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay13.AutoSize = true;
            this.relay13.Location = new System.Drawing.Point(154, 111);
            this.relay13.Name = "relay13";
            this.relay13.Size = new System.Drawing.Size(59, 23);
            this.relay13.TabIndex = 9;
            this.relay13.Text = "Relay 13";
            this.relay13.UseVisualStyleBackColor = true;
            this.relay13.CheckedChanged += new System.EventHandler(this.relay13_CheckedChanged);
            // 
            // relay14
            // 
            this.relay14.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay14.AutoSize = true;
            this.relay14.Location = new System.Drawing.Point(154, 135);
            this.relay14.Name = "relay14";
            this.relay14.Size = new System.Drawing.Size(59, 23);
            this.relay14.TabIndex = 8;
            this.relay14.Text = "Relay 14";
            this.relay14.UseVisualStyleBackColor = true;
            this.relay14.CheckedChanged += new System.EventHandler(this.relay14_CheckedChanged);
            // 
            // relay15
            // 
            this.relay15.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay15.AutoSize = true;
            this.relay15.Location = new System.Drawing.Point(154, 158);
            this.relay15.Name = "relay15";
            this.relay15.Size = new System.Drawing.Size(59, 23);
            this.relay15.TabIndex = 7;
            this.relay15.Text = "Relay 15";
            this.relay15.UseVisualStyleBackColor = true;
            this.relay15.CheckedChanged += new System.EventHandler(this.relay15_CheckedChanged);
            // 
            // relay16
            // 
            this.relay16.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay16.AutoSize = true;
            this.relay16.Location = new System.Drawing.Point(154, 183);
            this.relay16.Name = "relay16";
            this.relay16.Size = new System.Drawing.Size(59, 23);
            this.relay16.TabIndex = 6;
            this.relay16.Text = "Relay 16";
            this.relay16.UseVisualStyleBackColor = true;
            this.relay16.CheckedChanged += new System.EventHandler(this.relay16_CheckedChanged);
            // 
            // relay10
            // 
            this.relay10.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay10.AutoSize = true;
            this.relay10.Location = new System.Drawing.Point(154, 42);
            this.relay10.Name = "relay10";
            this.relay10.Size = new System.Drawing.Size(59, 23);
            this.relay10.TabIndex = 5;
            this.relay10.Text = "Relay 10";
            this.relay10.UseVisualStyleBackColor = true;
            this.relay10.CheckedChanged += new System.EventHandler(this.relay10_CheckedChanged);
            // 
            // relay9
            // 
            this.relay9.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay9.AutoSize = true;
            this.relay9.Location = new System.Drawing.Point(154, 19);
            this.relay9.Name = "relay9";
            this.relay9.Size = new System.Drawing.Size(59, 23);
            this.relay9.TabIndex = 4;
            this.relay9.Text = "Relay 09";
            this.relay9.UseVisualStyleBackColor = true;
            this.relay9.CheckedChanged += new System.EventHandler(this.relay9_CheckedChanged);
            // 
            // relay4
            // 
            this.relay4.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay4.AutoSize = true;
            this.relay4.Location = new System.Drawing.Point(80, 88);
            this.relay4.Name = "relay4";
            this.relay4.Size = new System.Drawing.Size(53, 23);
            this.relay4.TabIndex = 3;
            this.relay4.Text = "Relay 4";
            this.relay4.UseVisualStyleBackColor = true;
            this.relay4.CheckedChanged += new System.EventHandler(this.relay4_CheckedChanged);
            // 
            // relay3
            // 
            this.relay3.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay3.AutoSize = true;
            this.relay3.Location = new System.Drawing.Point(80, 65);
            this.relay3.Name = "relay3";
            this.relay3.Size = new System.Drawing.Size(53, 23);
            this.relay3.TabIndex = 2;
            this.relay3.Text = "Relay 3";
            this.relay3.UseVisualStyleBackColor = true;
            this.relay3.CheckedChanged += new System.EventHandler(this.relay3_CheckedChanged);
            // 
            // relay2
            // 
            this.relay2.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay2.AutoSize = true;
            this.relay2.Location = new System.Drawing.Point(80, 42);
            this.relay2.Name = "relay2";
            this.relay2.Size = new System.Drawing.Size(53, 23);
            this.relay2.TabIndex = 1;
            this.relay2.Text = "Relay 2";
            this.relay2.UseVisualStyleBackColor = true;
            this.relay2.CheckedChanged += new System.EventHandler(this.relay2_CheckedChanged);
            // 
            // relay1
            // 
            this.relay1.Appearance = System.Windows.Forms.Appearance.Button;
            this.relay1.AutoSize = true;
            this.relay1.Location = new System.Drawing.Point(80, 19);
            this.relay1.Name = "relay1";
            this.relay1.Size = new System.Drawing.Size(53, 23);
            this.relay1.TabIndex = 0;
            this.relay1.Text = "Relay 1";
            this.relay1.UseVisualStyleBackColor = true;
            this.relay1.CheckedChanged += new System.EventHandler(this.relay1_CheckedChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.Location = new System.Drawing.Point(26, 218);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(145, 16);
            this.statusLabel.TabIndex = 2;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(168, 221);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(55, 13);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.Text = "v06.05.21";
            // 
            // statusBox
            // 
            this.statusBox.AutoSize = true;
            this.statusBox.BackColor = System.Drawing.Color.Red;
            this.statusBox.Location = new System.Drawing.Point(7, 221);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(13, 13);
            this.statusBox.TabIndex = 4;
            this.statusBox.Text = "  ";
            // 
            // relaysGroupBox
            // 
            this.relaysGroupBox.Controls.Add(this.relay12);
            this.relaysGroupBox.Controls.Add(this.relay107);
            this.relaysGroupBox.Controls.Add(this.relay108);
            this.relaysGroupBox.Controls.Add(this.relay105);
            this.relaysGroupBox.Controls.Add(this.relay104);
            this.relaysGroupBox.Controls.Add(this.relay103);
            this.relaysGroupBox.Controls.Add(this.relay102);
            this.relaysGroupBox.Controls.Add(this.relay101);
            this.relaysGroupBox.Controls.Add(this.relay106);
            this.relaysGroupBox.Controls.Add(this.relay5);
            this.relaysGroupBox.Controls.Add(this.relay6);
            this.relaysGroupBox.Controls.Add(this.relay7);
            this.relaysGroupBox.Controls.Add(this.relay8);
            this.relaysGroupBox.Controls.Add(this.relay11);
            this.relaysGroupBox.Controls.Add(this.relay13);
            this.relaysGroupBox.Controls.Add(this.relay14);
            this.relaysGroupBox.Controls.Add(this.relay15);
            this.relaysGroupBox.Controls.Add(this.relay16);
            this.relaysGroupBox.Controls.Add(this.relay10);
            this.relaysGroupBox.Controls.Add(this.relay9);
            this.relaysGroupBox.Controls.Add(this.relay4);
            this.relaysGroupBox.Controls.Add(this.relay3);
            this.relaysGroupBox.Controls.Add(this.relay2);
            this.relaysGroupBox.Controls.Add(this.relay1);
            this.relaysGroupBox.Enabled = false;
            this.relaysGroupBox.Location = new System.Drawing.Point(4, 1);
            this.relaysGroupBox.Name = "relaysGroupBox";
            this.relaysGroupBox.Size = new System.Drawing.Size(219, 217);
            this.relaysGroupBox.TabIndex = 1;
            this.relaysGroupBox.TabStop = false;
            this.relaysGroupBox.Text = "Relays";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 243);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.relaysGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SmartDEN IP 16 Relays";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.relaysGroupBox.ResumeLayout(false);
            this.relaysGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox relay5;
        private System.Windows.Forms.CheckBox relay6;
        private System.Windows.Forms.CheckBox relay7;
        private System.Windows.Forms.CheckBox relay8;
        private System.Windows.Forms.CheckBox relay11;
        private System.Windows.Forms.CheckBox relay13;
        private System.Windows.Forms.CheckBox relay14;
        private System.Windows.Forms.CheckBox relay15;
        private System.Windows.Forms.CheckBox relay16;
        private System.Windows.Forms.CheckBox relay10;
        private System.Windows.Forms.CheckBox relay9;
        private System.Windows.Forms.CheckBox relay4;
        private System.Windows.Forms.CheckBox relay3;
        private System.Windows.Forms.CheckBox relay2;
        private System.Windows.Forms.CheckBox relay1;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.CheckBox relay106;
        private System.Windows.Forms.CheckBox relay107;
        private System.Windows.Forms.CheckBox relay108;
        private System.Windows.Forms.CheckBox relay105;
        private System.Windows.Forms.CheckBox relay104;
        private System.Windows.Forms.CheckBox relay103;
        private System.Windows.Forms.CheckBox relay102;
        private System.Windows.Forms.CheckBox relay101;
        private System.Windows.Forms.CheckBox relay12;
        private System.Windows.Forms.Label statusBox;
        private System.Windows.Forms.GroupBox relaysGroupBox;
    }
}

