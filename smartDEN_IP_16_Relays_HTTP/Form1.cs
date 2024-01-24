using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;

namespace smartDEN_IP_16_Relays_HTTP
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        public bool userClick = false;
        public bool isConnected = false;        
        private bool hotKeyLock = false;

        public Form1()
        {
            InitializeComponent();
            
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            if (File.Exists("./settings.ini"))
            {
                var iniFile = new INIFile("./settings.ini");

                ipTextBox.Text = iniFile.IniReadValue("Network", "IP");
                portTextBox.Text = iniFile.IniReadValue("Network", "Port");
                passwordTextBox.Text = iniFile.IniReadValue("Network", "Password");

                relay1.Text = iniFile.IniReadValue("Buttons", "Relay1");
                relay2.Text = iniFile.IniReadValue("Buttons", "Relay2");
                relay3.Text = iniFile.IniReadValue("Buttons", "Relay3");
                relay4.Text = iniFile.IniReadValue("Buttons", "Relay4");
                relay5.Text = iniFile.IniReadValue("Buttons", "Relay5");
                relay6.Text = iniFile.IniReadValue("Buttons", "Relay6");                
                relay7.Text = iniFile.IniReadValue("Buttons", "Relay7");
                relay8.Text = iniFile.IniReadValue("Buttons", "Relay8");
                relay9.Text = iniFile.IniReadValue("Buttons", "Relay9");
                relay10.Text = iniFile.IniReadValue("Buttons", "Relay10");
                relay11.Text = iniFile.IniReadValue("Buttons", "Relay11");
                relay12.Text = iniFile.IniReadValue("Buttons", "Relay12");
                relay13.Text = iniFile.IniReadValue("Buttons", "Relay13");
                relay14.Text = iniFile.IniReadValue("Buttons", "Relay14");
                relay15.Text = iniFile.IniReadValue("Buttons", "Relay15");
                relay16.Text = iniFile.IniReadValue("Buttons", "Relay16");
                checkBox1.Text = iniFile.IniReadValue("Buttons", "A1");
                checkBox2.Text = iniFile.IniReadValue("Buttons", "A2");
                checkBox3.Text = iniFile.IniReadValue("Buttons", "A3");
            }

            // Set the Hotkey triggerer the F9 key 
            // Expected an integer value for F9: 0x78, but you can convert the Keys.KEY to its int value
            // See: https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
            
            
            if(!RegisterHotKey(this.Handle, 1, 0x0000, (int)Keys.NumPad1)){
                Console.WriteLine("Global Hotkey '1' couldn't be registered !");
            }

            if (!RegisterHotKey(this.Handle, 2, 0x0000, (int)Keys.NumPad2))
            {
                Console.WriteLine("Global Hotkey '2' couldn't be registered !");
            }

            if (!RegisterHotKey(this.Handle, 3, 0x0000, (int)Keys.NumPad3))
            {
                Console.WriteLine("Global Hotkey '3' couldn't be registered !");
            }

            if (!RegisterHotKey(this.Handle, 4, 0x0000, (int)Keys.NumPad4))
            {
                Console.WriteLine("Global Hotkey '4' couldn't be registered !");
            }

            if (!RegisterHotKey(this.Handle, 5, 0x0000, (int)Keys.NumPad5))
            {
                Console.WriteLine("Global Hotkey '5' couldn't be registered !");
            }

            if (!RegisterHotKey(this.Handle, 7, 0x0000, (int)Keys.NumPad7))
            {
                Console.WriteLine("Global Hotkey '7' couldn't be registered !");
            }

            if (!RegisterHotKey(this.Handle, 8, 0x0000, (int)Keys.NumPad8))
            {
                Console.WriteLine("Global Hotkey '8' couldn't be registered !");
            }

            if (!RegisterHotKey(this.Handle, 9, 0x0000, (int)Keys.NumPad9))
            {
                Console.WriteLine("Global Hotkey '9' couldn't be registered !");
            }
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            refreshButton.PerformClick();
        }

        protected override void WndProc(ref Message m)
        {
            // Catch when a HotKey is pressed !
            if (m.Msg == 0x0312 && isConnected && !hotKeyLock)
            {
                int id = m.WParam.ToInt32();
                //MessageBox.Show(string.Format("Hotkey #{0} pressed", id));

                hotKeyLock = true;
                // Handle what will happen once a respective hotkey is pressed                
                switch (id)
                {
                    case 1:
                        relay13.Checked = !relay13.Checked;
                        break;
                    case 2:
                        relay14.Checked = !relay14.Checked;
                        break;
                    case 3:
                        relay15.Checked = !relay15.Checked;
                        break;
                    case 4:
                        relay16.Checked = !relay16.Checked;
                        break;
                    case 5:
                        relay8.Checked = !relay8.Checked;                        
                        break;
                    case 7:
                        updateStates(GetStateRequest("&Relay1=0&Relay2=0&Relay3=1&Relay4=1"));
                        break;
                    case 8:
                        updateStates(GetStateRequest("&Relay1=0&Relay2=1&Relay3=0&Relay4=1"));
                        break;
                    case 9:
                        updateStates(GetStateRequest("&Relay1=1&Relay2=0&Relay3=0&Relay4=1"));
                        break;
                }
                hotKeyLock = false;
            }

            base.WndProc(ref m);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            string result = GetStateRequest("");
            if (result != "NULL")
            {
                int wrongPassIndex = result.IndexOf("<LoginKey>");
                int alreadyLoggedIndex = result.IndexOf("Already Logged");
                int currentStateIndex = result.IndexOf("<CurrentState>");
                if (wrongPassIndex >= 0)
                {
                    refreshButton.Text = "Connect";
                    isConnected = false;
                    statusLabel.Text = "Wrong password. Try again.";
                    statusBox.BackColor = Color.Red;
                    relaysGroupBox.Enabled = false;
                }
                else if (alreadyLoggedIndex >= 0)
                {
                    refreshButton.Text = "Connect";
                    isConnected = false;
                    statusLabel.Text = "Administrator is already logged in.";
                    statusBox.BackColor = Color.Red;
                    relaysGroupBox.Enabled = false;
                }
                else if (currentStateIndex >= 0)
                {
                    updateStates(result);
                    relaysGroupBox.Enabled = true;
                }
                else
                {
                    relaysGroupBox.Enabled = false;
                    refreshButton.Text = "Connect";
                    isConnected = false;
                    statusLabel.Text = "Failed to get data.";
                    statusBox.BackColor = Color.Red;
                }
            }
            else
            {
                relaysGroupBox.Enabled = false;
            }
        }

        public string GetStateRequest(string parameter)
        {
            //statusLabel.Text = "Connecting...";
            //statusBox.BackColor = Color.Red;
            //relaysGroupBox.Enabled = false;
            Application.DoEvents();
            string url = "http://" + ipTextBox.Text + ":" + portTextBox.Text + "/current_state.xml?pw=" + passwordTextBox.Text + parameter;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 3000;
            request.Proxy = null;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                string responseFromServer = "";
                responseFromServer = reader.ReadToEnd();
                refreshButton.Text = "Refresh";
                isConnected = true;
                //statusLabel.Text = "States updated successfully.";
                statusBox.BackColor = Color.Green;
                response.Close();
                request.Abort();
                if ("http://" + ipTextBox.Text + ":" + portTextBox.Text + "/login_info.xml" == response.ResponseUri.ToString())
                    return "Already Logged";
                relaysGroupBox.Enabled = true;
                statusLabel.Text = "";
                return responseFromServer;
            }
            catch (Exception)
            {
                relaysGroupBox.Enabled = false;
                refreshButton.Text = "Connect";
                statusLabel.Text = "Failed to connect.";
                statusBox.BackColor = Color.Red;
                request.Abort();
                return "NULL";
            }
        }

        public void updateStates(string data)
        {
            if (data.IndexOf("<CurrentState>") >= 0)
            {
                userClick = false;
                int startIndex = 0;
                int endIndex = 0;
                string thisInput;
                string state = "<State>";                

                for (int i = 1; i < 17; i++)
                {
                    CheckBox currentRelay = (CheckBox)this.Controls.Find("relay" + i, true)[0];
                    thisInput = string.Format("<Relay{0}>\r\n  <Name>", i.ToString());

                    startIndex = data.IndexOf(thisInput) + thisInput.Length;
                    endIndex = data.IndexOf("</", startIndex);
                    //currentRelay.Text = data.Substring(startIndex, endIndex - startIndex);

                    startIndex = data.IndexOf(state, endIndex) + state.Length;
                    endIndex = data.IndexOf("</", startIndex);
                    currentRelay.Checked = Convert.ToBoolean(Int32.Parse(data.Substring(startIndex, endIndex - startIndex)));
                    if (currentRelay.Checked)
                    {
                        currentRelay.BackColor = Color.Chartreuse;                        
                    }
                    else
                    {
                        currentRelay.BackColor = SystemColors.ControlLight;                        
                    }
                }

                if (!relay1.Checked && !relay2.Checked && relay3.Checked && relay4.Checked)
                {
                    checkBox1.BackColor = Color.Chartreuse;
                }
                else
                {
                    checkBox1.BackColor = SystemColors.ControlLight;
                }

                if (!relay1.Checked && relay2.Checked && !relay3.Checked && relay4.Checked)
                {
                    checkBox2.BackColor = Color.Chartreuse;
                }
                else
                {
                    checkBox2.BackColor = SystemColors.ControlLight;
                }

                if (relay1.Checked && !relay2.Checked && !relay3.Checked && relay4.Checked)
                {
                    checkBox3.BackColor = Color.Chartreuse;
                }
                else
                {
                    checkBox3.BackColor = SystemColors.ControlLight;
                }

                userClick = true;
            }
        }

        private void relay1_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay1=" + Convert.ToInt32(relay1.Checked).ToString()));
        }

        private void relay2_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay2=" + Convert.ToInt32(relay2.Checked).ToString()));
        }

        private void relay3_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay3=" + Convert.ToInt32(relay3.Checked).ToString()));
        }

        private void relay4_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                updateStates(GetStateRequest("&Relay4=" + Convert.ToInt32(relay4.Checked).ToString()));
            }
        }

        private void relay5_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay5=" + Convert.ToInt32(relay5.Checked).ToString()));
        }

        private void relay6_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay6=" + Convert.ToInt32(relay6.Checked).ToString()));
        }

        private void relay7_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay7=" + Convert.ToInt32(relay7.Checked).ToString()));
        }

        private void relay8_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                if (relay8.Checked)
                {
                    updateStates(GetStateRequest("&Relay8=1&Relay14=0&Relay15=0&Relay16=0&Relay13=0"));
                }
                else
                {
                    updateStates(GetStateRequest("&Relay8=0"));                    
                }
            }
        }

        private void relay9_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {                
                updateStates(GetStateRequest("&Relay9=" + Convert.ToInt32(relay9.Checked).ToString()));
            }
        }

        private void relay10_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                updateStates(GetStateRequest("&Relay10=" + Convert.ToInt32(relay10.Checked).ToString()));
            }
        }

        private void relay11_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                updateStates(GetStateRequest("&Relay11=" + Convert.ToInt32(relay11.Checked).ToString()));
            }
        }

        private void relay12_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                updateStates(GetStateRequest("&Relay12=" + Convert.ToInt32(relay12.Checked).ToString()));
            }
        }

        private void relay13_CheckedChanged(object sender, EventArgs e)
        {

            if (userClick == true)
            {
                if (relay13.Checked)
                {
                    updateStates(GetStateRequest("&Relay13=1&Relay14=0&Relay15=0&Relay16=0&Relay8=0"));
                }
                else
                {
                    updateStates(GetStateRequest("&Relay13=0"));
                }
            }
        }

        private void relay14_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                if (relay14.Checked)
                {
                    updateStates(GetStateRequest("&Relay14=1&Relay13=0&Relay15=0&Relay16=0&Relay8=0"));
                }
                else
                {
                    updateStates(GetStateRequest("&Relay14=0"));
                }
            }
        }

        private void relay15_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                if (relay15.Checked)
                {
                    updateStates(GetStateRequest("&Relay15=1&Relay14=0&Relay13=0&Relay16=0&Relay8=0"));
                }
                else
                {
                    updateStates(GetStateRequest("&Relay15=0"));
                }
            }
        }

        private void relay16_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                if (relay16.Checked)
                {
                    updateStates(GetStateRequest("&Relay16=1&Relay14=0&Relay13=0&Relay15=0&Relay8=0"));
                }
                else
                {
                    updateStates(GetStateRequest("&Relay16=0"));
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            updateStates(GetStateRequest("&Relay1=0&Relay2=0&Relay3=1&Relay4=1"));
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            updateStates(GetStateRequest("&Relay1=0&Relay2=1&Relay3=0&Relay4=1"));
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            updateStates(GetStateRequest("&Relay1=1&Relay2=0&Relay3=0&Relay4=1"));
        }
    }
}
