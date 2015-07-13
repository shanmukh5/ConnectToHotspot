using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

namespace ConnectToHotspot
{
    public partial class Hotspot : Form
    {
        // status process
        Process p3 = new Process();

        // for password
        Process p4 = new Process();
        
        private void Start()
        {  
            Process p1 = new Process();
            p1.StartInfo.FileName = "netsh.exe";
            p1.StartInfo.Arguments = "wlan start hostednetwork";
            p1.StartInfo.UseShellExecute = false;
            p1.StartInfo.RedirectStandardOutput = true;
            p1.StartInfo.CreateNoWindow = true;
            p1.Start();
        }


        // stop process
        private void Stop()
        {    
            Process p2 = new Process();
            p2.StartInfo.FileName = "netsh.exe";
            p2.StartInfo.Arguments = "wlan stop hostednetwork";
            p2.StartInfo.UseShellExecute = false;
            p2.StartInfo.RedirectStandardOutput = true;
            p2.StartInfo.CreateNoWindow = true;
            p2.Start();
        }


        //sends show hostednetwork command
        private void status()
        {
            p3.StartInfo.FileName = "netsh.exe";
            p3.StartInfo.Arguments = "wlan show hostednetwork";
            p3.StartInfo.UseShellExecute = false;
            p3.StartInfo.RedirectStandardOutput = true;
            p3.StartInfo.CreateNoWindow = true;
            p3.Start();
            string outputStatus = p3.StandardOutput.ReadToEnd();
            string user = outputStatus.Split('"')[1];
            if (textBox1.Text != user)
            {
                textBox1.Text = user;
            }
            

          
            // Finding the state and updating
            if (outputStatus[83] == 'D')
            {
                changeButton.Text = "CREATE";
                statusLabel.Text = "NOT CREATED";
                statusLabel.ForeColor = Color.Blue;
                startButton.Enabled = false;
                label4.Text = "Create Hotspot by filling Username and Password";
                label5.Visible = false;
                clientsLabel.Text = "";
            }
            else
            {
                if (outputStatus.Split('\n')[11][29] == 'N')
                {
                    startButton.Text = "START";
                    statusLabel.Text = "OFF";
                    statusLabel.ForeColor = Color.Red;
                    label4.Text = "Hotspot is turned off";
                    label5.Visible = false;
                    clientsLabel.Text = "";
                }

                else
                {
                    startButton.Text = "STOP";
                    statusLabel.Text = "ON";
                    statusLabel.ForeColor = Color.Green;
                    label4.Text = "Hotspot is turned on";
                    clientsLabel.Text = outputStatus.Split('\n')[15][29].ToString();
                    label5.Visible = true;
                }
            }

            //call password()
            password();
        }
        
        
        // checking for password
        private void password()
        {
            p4.StartInfo.FileName = "netsh.exe";
            p4.StartInfo.Arguments = "wlan show hostednetwork setting=security";
            p4.StartInfo.UseShellExecute = false;
            p4.StartInfo.RedirectStandardOutput = true;
            p4.StartInfo.CreateNoWindow = true;
            p4.Start();
            string password_string = p4.StandardOutput.ReadToEnd();
            textBox2.Text = password_string.Split('\n')[6].Split(' ')[13].Trim();
        }
        
           
        // MAIN PROGRAM
        public Hotspot()
        {
            InitializeComponent();
            
            // checking initial status and updating accordingly
            status();
        }

        private void Hotspot_Load(object sender, EventArgs e)
        {
             /*if (!IsAdmin())
             {
                 this.RestartElevated();
             }*/
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "START")
            {
                Start();
                startButton.Text = "STOP";
                statusLabel.Text = "ON";
                statusLabel.ForeColor = Color.Green;
                label4.Text = "Hotspot is turned on";
            }
            else
            {
                Stop();
                startButton.Text = "START";
                statusLabel.Text = "OFF";
                statusLabel.ForeColor = Color.Red;
                label4.Text = "Hotspot is turned off";
                label5.Visible = false;
                clientsLabel.Text = "";
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {    
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                if (textBox2.Text.Length < 8)
                {
                    MessageBox.Show("Your password must be at least 8 characters.");
                }
                else
                {
                    if (startButton.Text == "STOP")
                    {
                        Stop();
                    }
                    Process p5 = new Process();
                    p5.StartInfo.FileName = "netsh.exe";
                    p5.StartInfo.Arguments = "wlan set hostednetwork mode=allow ssid=" + textBox1.Text + " key=" + textBox2.Text;
                    p5.StartInfo.UseShellExecute = false;
                    p5.StartInfo.RedirectStandardOutput = true;
                    p5.StartInfo.CreateNoWindow = true;
                    p5.Start();
                    startButton.Enabled = true;
                    statusLabel.Text = "OFF";
                    statusLabel.ForeColor = Color.Red;
                    startButton.Text = "START";
                    label4.Text = "Hotspot is created";
                    changeButton.Text = "UPDATE";
                    label5.Visible = false;
                    clientsLabel.Text = "";
                }
            }
        }

        private void passButton_Click(object sender, EventArgs e)
        {
            if (passButton.Text == "Show")
            {
                textBox2.UseSystemPasswordChar = false;
                passButton.Text = "Hide";
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                passButton.Text = "Show";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                status(); 
        }

    }
}
