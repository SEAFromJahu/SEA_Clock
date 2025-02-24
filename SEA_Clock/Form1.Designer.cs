using System.ComponentModel;

namespace SEA_Clock
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            backgroundWorker1 = new BackgroundWorker();
            textBox1 = new System.Windows.Forms.TextBox();
            buttExit = new System.Windows.Forms.Button();
            timer1 = new System.Windows.Forms.Timer(components);
            textBox2 = new System.Windows.Forms.TextBox();
            chkBox_Ping = new System.Windows.Forms.CheckBox();
            chkBox_Log = new System.Windows.Forms.CheckBox();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            textBox3 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            lblMinutos = new System.Windows.Forms.Label();
            lblHoras = new System.Windows.Forms.Label();
            tabPage2 = new System.Windows.Forms.TabPage();
            textBox4 = new System.Windows.Forms.TextBox();
            trackBar1 = new System.Windows.Forms.TrackBar();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            backgroundWorker2 = new BackgroundWorker();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += BackgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
            // 
            // textBox1
            // 
            textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox1.ForeColor = System.Drawing.Color.Cyan;
            textBox1.Location = new System.Drawing.Point(10, 23);
            textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(274, 86);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(textBox1, "Horas em binário");
            // 
            // buttExit
            // 
            buttExit.BackColor = System.Drawing.Color.Black;
            buttExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            buttExit.ForeColor = System.Drawing.Color.Cyan;
            buttExit.Location = new System.Drawing.Point(234, 301);
            buttExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttExit.Name = "buttExit";
            buttExit.Size = new System.Drawing.Size(50, 27);
            buttExit.TabIndex = 6;
            buttExit.Text = "Exit";
            toolTip1.SetToolTip(buttExit, "Encerra a aplicação");
            buttExit.UseVisualStyleBackColor = false;
            buttExit.Click += ButtExit_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;
            // 
            // textBox2
            // 
            textBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox2.ForeColor = System.Drawing.Color.Cyan;
            textBox2.Location = new System.Drawing.Point(12, 132);
            textBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(274, 86);
            textBox2.TabIndex = 1;
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(textBox2, "Minutos em binário");
            // 
            // chkBox_Ping
            // 
            chkBox_Ping.AutoSize = true;
            chkBox_Ping.BackColor = System.Drawing.Color.Black;
            chkBox_Ping.ForeColor = System.Drawing.Color.Cyan;
            chkBox_Ping.Location = new System.Drawing.Point(12, 306);
            chkBox_Ping.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkBox_Ping.Name = "chkBox_Ping";
            chkBox_Ping.Size = new System.Drawing.Size(47, 17);
            chkBox_Ping.TabIndex = 3;
            chkBox_Ping.Tag = "";
            chkBox_Ping.Text = "Ping";
            toolTip1.SetToolTip(chkBox_Ping, "Verificar conectividade via Ping");
            chkBox_Ping.UseVisualStyleBackColor = false;
            // 
            // chkBox_Log
            // 
            chkBox_Log.AutoSize = true;
            chkBox_Log.BackColor = System.Drawing.Color.Black;
            chkBox_Log.ForeColor = System.Drawing.Color.Cyan;
            chkBox_Log.Location = new System.Drawing.Point(67, 306);
            chkBox_Log.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkBox_Log.Name = "chkBox_Log";
            chkBox_Log.Size = new System.Drawing.Size(44, 17);
            chkBox_Log.TabIndex = 4;
            chkBox_Log.Text = "Log";
            toolTip1.SetToolTip(chkBox_Log, "Registra status do Ping");
            chkBox_Log.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new System.Drawing.Point(1, 1);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(307, 363);
            tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.SystemColors.Desktop;
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(chkBox_Log);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(chkBox_Ping);
            tabPage1.Controls.Add(lblMinutos);
            tabPage1.Controls.Add(lblHoras);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(buttExit);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tabPage1.ForeColor = System.Drawing.Color.Cyan;
            tabPage1.Location = new System.Drawing.Point(4, 4);
            tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage1.Size = new System.Drawing.Size(299, 335);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "UI";
            // 
            // textBox3
            // 
            textBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            textBox3.ForeColor = System.Drawing.Color.Cyan;
            textBox3.Location = new System.Drawing.Point(10, 240);
            textBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(274, 54);
            textBox3.TabIndex = 2;
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip1.SetToolTip(textBox3, "Status da conexão");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Black;
            label1.ForeColor = System.Drawing.Color.Cyan;
            label1.Location = new System.Drawing.Point(102, 222);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 13);
            label1.TabIndex = 7;
            label1.Text = "Acesso Internet";
            // 
            // lblMinutos
            // 
            lblMinutos.AutoSize = true;
            lblMinutos.BackColor = System.Drawing.Color.Black;
            lblMinutos.ForeColor = System.Drawing.Color.Cyan;
            lblMinutos.Location = new System.Drawing.Point(121, 113);
            lblMinutos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinutos.Name = "lblMinutos";
            lblMinutos.Size = new System.Drawing.Size(44, 13);
            lblMinutos.TabIndex = 7;
            lblMinutos.Text = "Minutos";
            // 
            // lblHoras
            // 
            lblHoras.AutoSize = true;
            lblHoras.BackColor = System.Drawing.Color.Black;
            lblHoras.ForeColor = System.Drawing.Color.Cyan;
            lblHoras.Location = new System.Drawing.Point(126, 5);
            lblHoras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHoras.Name = "lblHoras";
            lblHoras.Size = new System.Drawing.Size(35, 13);
            lblHoras.TabIndex = 7;
            lblHoras.Text = "Horas";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = System.Drawing.Color.Black;
            tabPage2.Controls.Add(textBox4);
            tabPage2.Controls.Add(trackBar1);
            tabPage2.ForeColor = System.Drawing.Color.Cyan;
            tabPage2.Location = new System.Drawing.Point(4, 4);
            tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage2.Size = new System.Drawing.Size(299, 335);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Setup";
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(26, 28);
            textBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(249, 23);
            textBox4.TabIndex = 10;
            textBox4.Text = "C:\\Temp\\PingLog.txt";
            // 
            // trackBar1
            // 
            trackBar1.Location = new System.Drawing.Point(7, 278);
            trackBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.RightToLeftLayout = true;
            trackBar1.Size = new System.Drawing.Size(284, 45);
            trackBar1.TabIndex = 9;
            trackBar1.Value = 75;
            trackBar1.Scroll += TrackBar1_Scroll;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Desktop;
            ClientSize = new System.Drawing.Size(307, 361);
            Controls.Add(tabControl1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximumSize = new System.Drawing.Size(323, 400);
            MinimumSize = new System.Drawing.Size(323, 400);
            Name = "Form1";
            Opacity = 0.75D;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SEA_Clock";
            TopMost = true;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);

        }
        // Add the missing event handler methods in the Form1 class

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Add your code here
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Add your code here
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttExit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox chkBox_Ping;
        private System.Windows.Forms.CheckBox chkBox_Log;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblMinutos;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

