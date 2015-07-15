using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Collections.ObjectModel;

namespace ConnectToHotspot
{
    public partial class Hotspot : Form
    {
        // status process
        Process p3 = new Process();

        // for password
        Process p4 = new Process();

        private string RunScript(string scriptText)
        {
            // create Powershell runspace

            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it

            runspace.Open();

            // create a pipeline and feed it the script text

            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);

            // add an extra command to transform the script
            // output objects into nicely formatted strings

            // remove this line to get the actual objects
            // that the script returns. For example, the script

            // "Get-Process" returns a collection
            // of System.Diagnostics.Process instances.

            pipeline.Commands.Add("Out-String");

            // execute the script

            Collection<PSObject> results = pipeline.Invoke();

            // close the runspace

            runspace.Close();

            // convert the script result into a single string

            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            return stringBuilder.ToString();
        }

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

        // updates username and password
        private void user_pass()
        {
            // updated user name
            textBox1.Text = show().Split('"')[1];

            // updated password
            p4.StartInfo.FileName = "netsh.exe";
            p4.StartInfo.Arguments = "wlan show hostednetwork setting=security";
            p4.StartInfo.UseShellExecute = false;
            p4.StartInfo.RedirectStandardOutput = true;
            p4.StartInfo.CreateNoWindow = true;
            p4.Start();
            string password_string = p4.StandardOutput.ReadToEnd();
            textBox2.Text = password_string.Split('\n')[6].Split(' ')[13].Trim();
        }

        // show process
        private string show()
        {
            p3.StartInfo.FileName = "netsh.exe";
            p3.StartInfo.Arguments = "wlan show hostednetwork";
            p3.StartInfo.UseShellExecute = false;
            p3.StartInfo.RedirectStandardOutput = true;
            p3.StartInfo.CreateNoWindow = true;
            p3.Start();
            string outputStatus = p3.StandardOutput.ReadToEnd();
            return outputStatus;
        }

        //sends show hostednetwork command
        private void status()
        {
            string outputStatus = show();
                     
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
                icsButton.Enabled = false;
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
                    icsButton.Enabled = false;
                }

                else
                {
                    startButton.Text = "STOP";
                    statusLabel.Text = "ON";
                    statusLabel.ForeColor = Color.Green;
                    label4.Text = "Hotspot is turned on";
                    icsButton.Enabled = true;
                    clientsLabel.Text = outputStatus.Split('\n')[15][29].ToString();
                    label5.Visible = true;
                }
            }
        }
   

        // MAIN PROGRAM
        public Hotspot()
        {
            InitializeComponent();
            
            // checking initial status and updating accordingly
            status();

            // Updating user name and password initailly
            user_pass();

        }

        private void Hotspot_Load(object sender, EventArgs e)
        {
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "START")
            {
                Start();
                startButton.Text = "STOP";
                statusLabel.ForeColor = Color.Green;
                label4.Text = "Hotspot is turned on";
                statusLabel.Text = "ON";
                icsButton.Enabled = true;
            }
            else
            {
                Stop();
                startButton.Text = "START";
                statusLabel.ForeColor = Color.Red;
                label4.Text = "Hotspot is turned off";
                label5.Visible = false;
                clientsLabel.Text = "";
                statusLabel.Text = "OFF";
                icsButton.Enabled = false;
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
                    icsButton.Enabled = false;
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

        private void icsButton_Click(object sender, EventArgs e)
        {
            string ics = RunScript(@"
# Create a NetSharingManager object
$m = New-Object -ComObject HNetCfg.HNetShare

# Find connection
$c = $m.EnumEveryConnection |? { $m.NetConnectionProps.Invoke($_).Name -eq '" + netComboBox.Text + @"' }

# Get sharing configuration
$config = $m.INetSharingConfigurationForINetConnection.Invoke($c)

# See if sharing is enabled
Write - Output $config.SharingEnabled

# Disable sharing
$config.EnableSharing(0)
");
            System.IO.File.WriteAllText(@"C:\Users\shanmukh\Desktop\a.txt", ics);
        }
    }
}
