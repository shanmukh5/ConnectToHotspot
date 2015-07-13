namespace ConnectToHotspot
{
    partial class Hotspot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hotspot));
            this.label4 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.passButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.clientsLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "label1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(137, 46);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(110, 99);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(81, 32);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(121, 298);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 30);
            this.changeButton.TabIndex = 9;
            this.changeButton.Text = "UPDATE";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "HOTSPOT STATUS";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 227);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(110, 263);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 8;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // passButton
            // 
            this.passButton.Location = new System.Drawing.Point(216, 263);
            this.passButton.Name = "passButton";
            this.passButton.Size = new System.Drawing.Size(45, 21);
            this.passButton.TabIndex = 10;
            this.passButton.Text = "Show";
            this.passButton.UseVisualStyleBackColor = true;
            this.passButton.Click += new System.EventHandler(this.passButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Devices Connected";
            this.label5.Visible = false;
            // 
            // clientsLabel
            // 
            this.clientsLabel.AutoSize = true;
            this.clientsLabel.Location = new System.Drawing.Point(132, 338);
            this.clientsLabel.Name = "clientsLabel";
            this.clientsLabel.Size = new System.Drawing.Size(0, 13);
            this.clientsLabel.TabIndex = 12;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Hotspot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 357);
            this.Controls.Add(this.clientsLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.passButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hotspot";
            this.Text = "Connect2Hotspot";
            this.Load += new System.EventHandler(this.Hotspot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button passButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label clientsLabel;
        private System.Windows.Forms.Timer timer1;
    }
}

