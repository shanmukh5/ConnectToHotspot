using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
//using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConnectToHotspot
{
    public partial class Hotspot : Form
    {

        // start process
        Process p1 = new Process();
        // stop process
        Process p2 = new Process();
        

        // stop hotspot
        private void Stop()
        {
            p2.StartInfo.FileName = "netsh.exe";
            p2.StartInfo.Arguments = "wlan stop hostednetwork";
            p2.StartInfo.UseShellExecute = false;
            p2.StartInfo.RedirectStandardOutput = true;
            p2.StartInfo.CreateNoWindow = true;
            p2.Start();


        }

        private void clients()
        {
            Process p3 = new Process();
            string outputStatus = status(p3);

            if (startButton.Text == "STOP" && startButton.Enabled == true)
            {
                //string outputStatus = p3.StandardOutput.ReadToEnd();;;
                clientsLabel.Text = outputStatus.Split('\n')[15][29].ToString();
                label5.Visible = true;
            }
            
        }
        
        //sends show hostednetwork command
        private string status(Process p3)
        {
            p3.StartInfo.FileName = "netsh.exe";
            p3.StartInfo.Arguments = "wlan show hostednetwork";
            p3.StartInfo.UseShellExecute = false;
            p3.StartInfo.RedirectStandardOutput = true;
            p3.StartInfo.CreateNoWindow = true;
            p3.Start();
            string outputStatus = p3.StandardOutput.ReadToEnd();
            textBox1.Text = outputStatus.Split('"')[1];
            



            // Finding the state and updating

            if (outputStatus[83] == 'D')
            {
                changeButton.Text = "CREATE";
                statusLabel.Text = "NOT CREATED";
                statusLabel.ForeColor = Color.Blue;
                startButton.Enabled = false;
                label4.Text = "Create Hotspot by filling Username and Password";
            }
            else
            {
                if (outputStatus.Split('\n')[11][29] == 'N')
                {
                    startButton.Text = "START";
                    statusLabel.Text = "OFF";
                    statusLabel.ForeColor = Color.Red;
                    label4.Text = "Hotspot is turned off";
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

            return (outputStatus);
        }

        // checking for password
        private void password(Process p4)
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
        
           
        //PasswordUtility

        public Hotspot()
        {
            InitializeComponent();
            // checking initial status
            Process p3 = new Process();
            status(p3);
            
            // checking password
            Process p4 = new Process();
            password(p4);

            // for user name and password
            //string outputStatus = p3.StandardOutput.ReadToEnd();
            //string password_string = p4.StandardOutput.ReadToEnd();
            //System.IO.File.WriteAllText(@"C:\Users\shanmukh\Desktop\status1.txt", outputStatus);
            
            

            //no fo clients

            
            

        }

        private void Hotspot_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "START")
            {

                p1.StartInfo.FileName = "netsh.exe";
                p1.StartInfo.Arguments = "wlan start hostednetwork";
                p1.StartInfo.UseShellExecute = false;
                p1.StartInfo.RedirectStandardOutput = true;
                p1.StartInfo.CreateNoWindow = true;
                p1.Start();
                startButton.Text = "STOP";
                statusLabel.Text = "ON";
                statusLabel.ForeColor = Color.Green;
                label4.Text = "Hotspot is turned on";
                //await Task.Delay(4000);
                //clients();

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
                    Process p4 = new Process();
                    p4.StartInfo.FileName = "netsh.exe";
                    p4.StartInfo.Arguments = "wlan set hostednetwork mode=allow ssid=" + textBox1.Text + " key=" + textBox2.Text;
                    p4.StartInfo.UseShellExecute = false;
                    p4.StartInfo.RedirectStandardOutput = true;
                    p4.StartInfo.CreateNoWindow = true;
                    p4.Start();
                    startButton.Enabled = true;
                    statusLabel.Text = "OFF";
                    statusLabel.ForeColor = Color.Red;
                    startButton.Text = "START";
                    label4.Text = "Hotspot is created";
                    changeButton.Text = "UPDATE";

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
            if (startButton.Text == "STOP")
            {
                clients();
            }
        }
    }
}
