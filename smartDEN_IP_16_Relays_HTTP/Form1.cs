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
        public int lastActiveRelayId = 7;

        private bool hotKeyLock = false;

        public Form1()
        {
            InitializeComponent();
            
            var timer = new Timer();
            timer.Interval = 3000;
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
                relay101.Text = iniFile.IniReadValue("Buttons", "Relay101");
                relay102.Text = iniFile.IniReadValue("Buttons", "Relay102");
                relay103.Text = iniFile.IniReadValue("Buttons", "Relay103");
                relay104.Text = iniFile.IniReadValue("Buttons", "Relay104");
                relay105.Text = iniFile.IniReadValue("Buttons", "Relay105");
                relay106.Text = iniFile.IniReadValue("Buttons", "Relay106");
                relay107.Text = iniFile.IniReadValue("Buttons", "Relay107");
                relay108.Text = iniFile.IniReadValue("Buttons", "Relay108");

            }

            // Set the Hotkey triggerer the F9 key 
            // Expected an integer value for F9: 0x78, but you can convert the Keys.KEY to its int value
            // See: https://msdn.microsoft.com/en-us/library/windows/desktop/dd375731(v=vs.85).aspx
            int FirstHotKeyKey = (int)Keys.F9;
            // Register the "F9" hotkey
            Boolean F9Registered = RegisterHotKey(
                this.Handle, 1, 0x0000, FirstHotKeyKey
            );

            // Repeat the same process but with F10
            Boolean F10Registered = RegisterHotKey(
                this.Handle, 2, 0x0000, (int)Keys.F10
            );

            bool ComaRegistered = RegisterHotKey(
                this.Handle, 5, 0x0000, (int)Keys.Oemcomma
            );

            bool DotRegistered = RegisterHotKey(
                this.Handle, 6, 0x0000, (int)Keys.OemPeriod
            );

            bool SemicolonRegistered = RegisterHotKey(
                this.Handle, 7, 0x0000, (int)Keys.OemSemicolon
            );
            
            bool ApostropheRegistered = RegisterHotKey(
                this.Handle, 8, 0x0000, (int)Keys.OemQuotes
            );
            bool TildeRegistered = RegisterHotKey(
                this.Handle, 9, 0x0000, (int)Keys.Oemtilde
            );


            // Verify if both hotkeys were succesfully registered, if not, show message in the console
            if (!F9Registered)
            {
                Console.WriteLine("Global Hotkey F9 couldn't be registered !");
            }

            if (!F10Registered)
            {
                Console.WriteLine("Global Hotkey F10 couldn't be registered !");
            }
            
            if (!ComaRegistered)
            {
                Console.WriteLine("Global Hotkey , couldn't be registered !");
            }

            if (!DotRegistered)
            {
                Console.WriteLine("Global Hotkey . couldn't be registered !");
            }

            if (!SemicolonRegistered)
            {
                Console.WriteLine("Global Hotkey ; couldn't be registered !");
            }

            if (!ApostropheRegistered)
            {
                Console.WriteLine("Global Hotkey ' couldn't be registered !");
            }

            if (!TildeRegistered)
            {
                Console.WriteLine("Global Hotkey ` couldn't be registered !");
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
                // MessageBox.Show(string.Format("Hotkey #{0} pressed", id));

                hotKeyLock = true;
                // Handle what will happen once a respective hotkey is pressed                
                switch (id)
                {
                    case 1:                        
                        updateStates(GetStateRequest("&Relay6=0"));                        
                        break;
                    case 2:                        
                        updateStates(GetStateRequest("&Relay6=1"));
                        break;
                    case 3:
                        lastActiveRelayId += 1;
                        lastActiveRelayId = (((lastActiveRelayId % 8) + 8) % 8);
                        lastActiveRelayId += 8;
                        disableOtherHalf(lastActiveRelayId + 1);
                        updateStates(GetStateRequest("&Relay" + (lastActiveRelayId + 1) + "=1"));
                        break;
                    case 4:
                        lastActiveRelayId -= 1;
                        lastActiveRelayId = (((lastActiveRelayId % 8) + 8) % 8);
                        lastActiveRelayId += 8;
                        disableOtherHalf(lastActiveRelayId + 1);
                        updateStates(GetStateRequest("&Relay" + (lastActiveRelayId + 1) + "=1"));
                        break;
                    case 5:
                        updateStates(GetStateRequest("&Relay1=" + Convert.ToInt32(!relay1.Checked).ToString()));
                        break;
                    case 6:
                        updateStates(GetStateRequest("&Relay2=" + Convert.ToInt32(!relay2.Checked).ToString()));
                        break;
                    case 7:
                        updateStates(GetStateRequest("&Relay3=" + Convert.ToInt32(!relay3.Checked).ToString()));
                        break;
                    case 8:
                    case 9:
                        updateStates(GetStateRequest("&Relay4=1"));
                        updateStates(GetStateRequest("&Relay1=1"));
                        updateStates(GetStateRequest("&Relay2=1"));
                        updateStates(GetStateRequest("&Relay3=1"));                        
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
            statusBox.BackColor = Color.Red;
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
                        if (i < 9)
                        {
                            var mirrorRelay = (CheckBox)this.Controls.Find("relay" + (i + 100), true)[0];
                            mirrorRelay.BackColor = SystemColors.ControlLight;
                        }
                    }
                    else
                    {
                        currentRelay.BackColor = SystemColors.ControlLight;
                        if (i < 9)
                        {
                            var mirrorRelay = (CheckBox)this.Controls.Find("relay" + (i + 100), true)[0];
                            mirrorRelay.BackColor = Color.Chartreuse;
                        }
                    }
                }
                userClick = true;
            }
        }

        public void disableOtherHalf(int clickedRelayId)
        {
            for (int i = 9; i < 17; i++)
            {
                if (i == clickedRelayId)
                    continue;

                CheckBox currentRelay = (CheckBox)this.Controls.Find("relay" + i, true)[0];
                if (currentRelay.Checked)
                {
                    GetStateRequest("&Relay" + i + "=0");
                }
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
                if (relay4.Checked)
                {
                    updateStates(GetStateRequest("&Relay1=1"));
                    updateStates(GetStateRequest("&Relay2=1"));
                    updateStates(GetStateRequest("&Relay3=1"));
                }
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
                updateStates(GetStateRequest("&Relay8=" + Convert.ToInt32(relay8.Checked).ToString()));
        }

        private void relay9_CheckedChanged(object sender, EventArgs e)
        {

            if (userClick == true)
            {
                if (relay9.Checked)
                    disableOtherHalf(9);
                updateStates(GetStateRequest("&Relay9=" + Convert.ToInt32(relay9.Checked).ToString()));
            }
        }

        private void relay10_CheckedChanged(object sender, EventArgs e)
        {

            if (userClick == true)
            {
                if (relay10.Checked)
                    disableOtherHalf(10);
                updateStates(GetStateRequest("&Relay10=" + Convert.ToInt32(relay10.Checked).ToString()));
            }
        }

        private void relay11_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                if (relay11.Checked)
                    disableOtherHalf(11);
                updateStates(GetStateRequest("&Relay11=" + Convert.ToInt32(relay11.Checked).ToString()));
            }
        }

        private void relay12_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                if (relay12.Checked)
                    disableOtherHalf(12);
                updateStates(GetStateRequest("&Relay12=" + Convert.ToInt32(relay12.Checked).ToString()));
            }
        }

        private void relay13_CheckedChanged(object sender, EventArgs e)
        {

            if (userClick == true)
            {
                if (relay13.Checked)
                    disableOtherHalf(13);
                updateStates(GetStateRequest("&Relay13=" + Convert.ToInt32(relay13.Checked).ToString()));
            }
        }

        private void relay14_CheckedChanged(object sender, EventArgs e)
        {

            if (userClick == true)
            {
                if (relay14.Checked)
                    disableOtherHalf(14);
                updateStates(GetStateRequest("&Relay14=" + Convert.ToInt32(relay14.Checked).ToString()));
            }
        }

        private void relay15_CheckedChanged(object sender, EventArgs e)
        {

            if (userClick == true)
            {
                if (relay15.Checked)
                    disableOtherHalf(15);
                updateStates(GetStateRequest("&Relay15=" + Convert.ToInt32(relay15.Checked).ToString()));
            }
        }

        private void relay16_CheckedChanged(object sender, EventArgs e)
        {

            if (userClick == true)
            {
                if (relay16.Checked)
                    disableOtherHalf(16);
                updateStates(GetStateRequest("&Relay16=" + Convert.ToInt32(relay16.Checked).ToString()));
            }
        }

        private void relay106_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay6=" + Convert.ToInt32(!relay6.Checked).ToString()));
        }

        private void relay12_CheckedChanged_1(object sender, EventArgs e)
        {
            if (userClick == true)
            {
                if (relay12.Checked)
                    disableOtherHalf(12);
                updateStates(GetStateRequest("&Relay12=" + Convert.ToInt32(relay12.Checked).ToString()));
            }
        }

        private void relay101_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay1=" + Convert.ToInt32(!relay1.Checked).ToString()));
        }

        private void relay102_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay2=" + Convert.ToInt32(!relay2.Checked).ToString()));
        }

        private void relay103_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay3=" + Convert.ToInt32(!relay3.Checked).ToString()));
        }

        private void relay104_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay4=" + Convert.ToInt32(!relay4.Checked).ToString()));
        }

        private void relay105_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay5=" + Convert.ToInt32(!relay5.Checked).ToString()));
        }

        private void relay107_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay7=" + Convert.ToInt32(!relay7.Checked).ToString()));
        }

        private void relay108_CheckedChanged(object sender, EventArgs e)
        {
            if (userClick == true)
                updateStates(GetStateRequest("&Relay8=" + Convert.ToInt32(!relay8.Checked).ToString()));
        }
    }
}
