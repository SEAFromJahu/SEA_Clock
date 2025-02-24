using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEA_Clock
{
    public partial class Form1 : Form
    {
        private const int InitialTrackBarValue = 35;
        private const int ProcessCheckRetries = 5;
        private const int ProcessCheckDelayMilliseconds = 2000;

        private int idx = 0;
        private int urlIndx = 0;
        private string Dia;
        private FileInfo Finf = null;
        private readonly string[] url = {
                    "loopback", "www.ceptro.br", "www.cgi.br", "www.claro.com.br", "www.facebook.com",
                    "www.globo.com", "www.google.com", "www.linkedin.com", "www.nic.br", "www.terra.com.br",
                    "www.tim.com.br", "www.udemy.com", "www.uol.com.br", "www.vivo.com", "www.yahoo.com",
                    "www.youtube.com"
                };

        private readonly string[] ConvIntToBinary = {
                    "000000","000001","000010","000011","000100","000101","000110","000111","001000","001001",
                    "001010","001011","001100","001101","001110","001111","010000","010001","010010","010011",
                    "010100","010101","010110","010111","011000","011001","011010","011011","011100","011101",
                    "011110","011111","100000","100001","100010","100011","100100","100101","100110","100111",
                    "101000","101001","101010","101011","101100","101101","101110","101111","110000","110001",
                    "110010","110011","110100","110101","110110","110111","111000","111001","111010","111011"
                };

        private int urllength;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            urllength = url.Length - 1;
            trackBar1.Value = InitialTrackBarValue;
            timer1.Start();

            // Verify resource access
            //VerifyResourceAccess();
        }

        //private void VerifyResourceAccess()
        //{
        //    try
        //    {
        //        var testResource = SEA_Clock.Properties.Resources.ResourceManager.GetObject("TestResource");
        //        if (testResource == null)
        //        {
        //            throw new Exception("Resource 'TestResource' not found.");
        //        }
        //        MessageBox.Show($"Resource 'TestResource' found: {testResource}");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error accessing resources: {ex.Message}");
        //    }
        //}

        /// <summary>
        /// Handles the Tick event of the timer1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        private async void Timer1_Tick(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                await PingUrlAsync(url[urlIndx]);
                urlIndx = (urlIndx + 1) % (urllength + 1);
            }
        }

        /// <summary>
        /// Handles the Click event of the ButtExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        private void ButtExit_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Application.Exit();
        }

        /// <summary>
        /// Pings the specified URL asynchronously.
        /// </summary>
        /// <param name="url">The URL to ping.</param>
        private async Task PingUrlAsync(string url)
        {
            PingUrls objPingUrls = new()
            {
                EndWeb = " ",
                IP = " ",
                PingTime = " ",
                TxtToTextBox1 = ConvIntToBinary[DateTime.Now.Hour],
                TxtToTextBox2 = ConvIntToBinary[DateTime.Now.Minute]
            };

            if (chkBox_Ping.Checked)
            {
                try
                {
                    Dia = DateTime.Now.ToString("yyyy MM dd hh mm ss fff");
                    idx = urlIndx == 0 ? urllength : urlIndx;
                    objPingUrls.EndWeb = "     ********************************     ";
                    objPingUrls.IP = " ";
                    objPingUrls.PingTime = " ICMP - (PING) na Url: " + url[idx - 1];

                    Ping pingreq = new();
                    PingReply rep = await pingreq.SendPingAsync(url);

                    if (rep.Status == IPStatus.Success)
                    {
                        objPingUrls.EndWeb = url;
                        objPingUrls.IP = " IP: " + rep.Address.ToString();
                        objPingUrls.PingTime = "Tempo de resposta: " + rep.RoundtripTime + " ms";
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                }
            }

            if (chkBox_Log.Checked)
            {
                Finf = string.IsNullOrEmpty(textBox4.Text) ? new FileInfo(@"C:\Temp\PingLog.txt") : new FileInfo(textBox4.Text);
                try
                {
                    using StreamWriter swriter = Finf.AppendText();
                    swriter.WriteLine($"{Dia} {objPingUrls.EndWeb} {objPingUrls.IP} {objPingUrls.PingTime}");
                }
                catch (Exception ex)
                {
                    HandleLogException(ex);
                }
            }

            UpdateUI(objPingUrls);
        }

        /// <summary>
        /// Handles the log exception.
        /// </summary>
        /// <param name="ex">The exception.</param>
        private void HandleLogException(Exception ex)
        {
            // Log or handle the exception
        }

        /// <summary>
        /// Updates the UI with the ping results.
        /// </summary>
        /// <param name="objPingUrls">The ping results.</param>
        private void UpdateUI(PingUrls objPingUrls)
        {
            textBox1.Text = objPingUrls.TxtToTextBox1;
            textBox2.Text = objPingUrls.TxtToTextBox2;

            if (!string.IsNullOrEmpty(objPingUrls.EndWeb))
            {
                textBox3.Text = $"{objPingUrls.EndWeb}{Environment.NewLine}{objPingUrls.IP}{Environment.NewLine}{objPingUrls.PingTime}{Environment.NewLine}";
            }
        }

        /// <summary>
        /// Handles the Scroll event of the trackBar1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.TabIndex = 75;
            OpFunct(trackBar1.Value);
        }

        /// <summary>
        /// Sets the opacity of the form.
        /// </summary>
        /// <param name="value">The opacity value.</param>
        public void OpFunct(float value)
        {
            this.Opacity = value / 100;
            this.Refresh();
        }

    }
    /// <summary>
    /// The PingUrls class.
    /// </summary>
    class PingUrls
    {
        /// <summary>
        /// Gets or sets the end web.
        /// </summary>
        public string EndWeb { get; set; }

        /// <summary>
        /// Gets or sets the IP.
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Gets or sets the ping time.
        /// </summary>
        public string PingTime { get; set; }

        /// <summary>
        /// Gets or sets the time to live.
        /// </summary>
        public string TimeToLive { get; set; }

        /// <summary>
        /// Gets or sets the text to text box 1.
        /// </summary>
        public string TxtToTextBox1 { get; set; }

        /// <summary>
        /// Gets or sets the text to text box 2.
        /// </summary>
        public string TxtToTextBox2 { get; set; }
    }
}








//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Net.NetworkInformation;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Collections.Generic;
//using System.Text.Json;

//namespace SEA_Clock
//{
//    public class AppConfig
//    {
//        public int InitialTrackBarValue { get; set; } = 35;
//        public int ProcessCheckRetries { get; set; } = 5;
//        public int ProcessCheckDelayMilliseconds { get; set; } = 2000;
//        public List<string> Urls { get; set; } = new List<string>
//        {
//            "loopback", "www.ceptro.br", "www.cgi.br", "www.claro.com.br", "www.facebook.com",
//            "www.globo.com", "www.google.com", "www.linkedin.com", "www.nic.br", "www.terra.com.br",
//            "www.tim.com.br", "www.udemy.com", "www.uol.com.br", "www.vivo.com", "www.yahoo.com",
//            "www.youtube.com"
//        };
//        public string PingLogPath { get; set; } = @"C:\Temp\PingLog.txt";

//        public static AppConfig Load(string filePath)
//        {
//            if (!File.Exists(filePath))
//            {
//                throw new FileNotFoundException($"Configuration file not found: {filePath}");
//            }

//            string json = File.ReadAllText(filePath);
//            return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
//        }
//    }

//    public partial class Form1 : Form
//    {
//        private readonly AppConfig config;
//        private int idx = 0;
//        private int urlIndx = 0;
//        private string Dia;
//        private FileInfo Finf = null;

//        private readonly string[] ConvIntToBinary = {
//                    "000000","000001","000010","000011","000100","000101","000110","000111","001000","001001",
//                    "001010","001011","001100","001101","001110","001111","010000","010001","010010","010011",
//                    "010100","010101","010110","010111","011000","011001","011010","011011","011100","011101",
//                    "011110","011111","100000","100001","100010","100011","100100","100101","100110","100111",
//                    "101000","101001","101010","101011","101100","101101","101110","101111","110000","110001",
//                    "110010","110011","110100","110101","110110","110111","111000","111001","111010","111011"
//                };

//        private int urllength;


//        public Form1()
//        {
//            InitializeComponent();

//            try
//            {
//                // Load configuration
//                config = AppConfig.Load("SEA_Clock_Config.json");
//                urllength = config.Urls.Count - 1;
//                trackBar1.Value = config.InitialTrackBarValue;
//                timer1.Start();

//                // Verify resource access
//                VerifyResourceAccess();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading configuration: {ex.Message}");
//            }


//        }

//        private void VerifyResourceAccess()
//        {
//            try
//            {
//                var testResource = SEA_Clock.Properties.Resources.ResourceManager.GetObject("ResourceName");
//                if (testResource == null)
//                {
//                    throw new Exception("Resource 'ResourceName' not found.");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error accessing resources: {ex.Message}");
//            }
//        }

//        private async void Timer1_Tick(object sender, EventArgs e)
//        {
//            if (!backgroundWorker1.IsBusy)
//            {
//                await PingUrlAsync(config.Urls[urlIndx]);
//                urlIndx = (urlIndx + 1) % (urllength + 1);
//            }
//        }

//        private void ButtExit_Click(object sender, EventArgs e)
//        {
//            timer1.Stop();
//            Application.Exit();
//        }

//        private async Task PingUrlAsync(string url)
//        {
//            PingUrls objPingUrls = new()
//            {
//                EndWeb = " ",
//                IP = " ",
//                PingTime = " ",
//                TxtToTextBox1 = ConvIntToBinary[DateTime.Now.Hour],
//                TxtToTextBox2 = ConvIntToBinary[DateTime.Now.Minute]
//            };

//            if (chkBox_Ping.Checked)
//            {
//                try
//                {
//                    Dia = DateTime.Now.ToString("yyyy MM dd hh mm ss fff");
//                    idx = urlIndx == 0 ? urllength : urlIndx;
//                    objPingUrls.EndWeb = "     ********************************     ";
//                    objPingUrls.IP = " ";
//                    objPingUrls.PingTime = " ICMP - (PING) na Url: " + config.Urls[idx - 1];

//                    Ping pingreq = new();
//                    PingReply rep = await pingreq.SendPingAsync(url);

//                    if (rep.Status == IPStatus.Success)
//                    {
//                        objPingUrls.EndWeb = url;
//                        objPingUrls.IP = " IP: " + rep.Address.ToString();
//                        objPingUrls.PingTime = "Tempo de resposta: " + rep.RoundtripTime + " ms";
//                    }
//                }
//                catch (Exception ex)
//                {
//                    // Handle the exception
//                }
//            }

//            if (chkBox_Log.Checked)
//            {
//                Finf = string.IsNullOrEmpty(textBox4.Text) ? new FileInfo(config.PingLogPath) : new FileInfo(textBox4.Text);
//                try
//                {
//                    using StreamWriter swriter = Finf.AppendText();
//                    swriter.WriteLine($"{Dia} {objPingUrls.EndWeb} {objPingUrls.IP} {objPingUrls.PingTime}");
//                }
//                catch (Exception ex)
//                {
//                    HandleLogException(ex);
//                }
//            }

//            UpdateUI(objPingUrls);
//        }

//        private void HandleLogException(Exception ex)
//        {
//            MessageBox.Show($"Error writing to log: {ex.Message}");
//        }

//        private void UpdateUI(PingUrls objPingUrls)
//        {
//            textBox1.Text = objPingUrls.TxtToTextBox1;
//            textBox2.Text = objPingUrls.TxtToTextBox2;

//            if (!string.IsNullOrEmpty(objPingUrls.EndWeb))
//            {
//                textBox3.Text = $"{objPingUrls.EndWeb}{Environment.NewLine}{objPingUrls.IP}{Environment.NewLine}{objPingUrls.PingTime}{Environment.NewLine}";
//            }
//        }

//        private void TrackBar1_Scroll(object sender, EventArgs e)
//        {
//            trackBar1.TabIndex = 75;
//            OpFunct(trackBar1.Value);
//        }

//        public void OpFunct(float value)
//        {
//            this.Opacity = value / 100;
//            this.Refresh();
//        }
//    }

//    class PingUrls
//    {
//        public string EndWeb { get; set; }
//        public string IP { get; set; }
//        public string PingTime { get; set; }
//        public string TimeToLive { get; set; }
//        public string TxtToTextBox1 { get; set; }
//        public string TxtToTextBox2 { get; set; }
//    }
//}


















//using System;
//using System.IO;
//using System.Net.NetworkInformation;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace SEA_Clock
//{
//    public partial class Form1 : Form
//    {
//        private const int InitialTrackBarValue = 35;
//        private const int ProcessCheckRetries = 5;
//        private const int ProcessCheckDelayMilliseconds = 2000;

//        private int idx = 0;
//        private int urlIndx = 0;
//        private string Dia;
//        private FileInfo Finf = null;
//        private readonly string[] url = {
//                    "loopback", "www.ceptro.br", "www.cgi.br", "www.claro.com.br", "www.facebook.com",
//                    "www.globo.com", "www.google.com", "www.linkedin.com", "www.nic.br", "www.terra.com.br",
//                    "www.tim.com.br", "www.udemy.com", "www.uol.com.br", "www.vivo.com", "www.yahoo.com",
//                    "www.youtube.com"
//                };

//        private readonly string[] ConvIntToBinary = {
//                    "000000","000001","000010","000011","000100","000101","000110","000111","001000","001001",
//                    "001010","001011","001100","001101","001110","001111","010000","010001","010010","010011",
//                    "010100","010101","010110","010111","011000","011001","011010","011011","011100","011101",
//                    "011110","011111","100000","100001","100010","100011","100100","100101","100110","100111",
//                    "101000","101001","101010","101011","101100","101101","101110","101111","110000","110001",
//                    "110010","110011","110100","110101","110110","110111","111000","111001","111010","111011"
//                };

//        private int urllength;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="Form1"/> class.
//        /// </summary>
//        public Form1()
//        {
//            InitializeComponent();
//            urllength = url.Length - 1;
//            trackBar1.Value = InitialTrackBarValue;
//            timer1.Start();
//        }

//        /// <summary>
//        /// Handles the Tick event of the timer1 control.
//        /// </summary>
//        /// <param name="sender">The source of the event.</param>
//        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
//        private async void Timer1_Tick(object sender, EventArgs e)
//        {
//            if (!backgroundWorker1.IsBusy)
//            {
//                await PingUrlAsync(url[urlIndx]);
//                urlIndx = (urlIndx + 1) % (urllength + 1);
//            }
//        }

//        /// <summary>
//        /// Handles the Click event of the ButtExit control.
//        /// </summary>
//        /// <param name="sender">The source of the event.</param>
//        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
//        private void ButtExit_Click(object sender, EventArgs e)
//        {
//            timer1.Stop();
//            Application.Exit();
//        }

//        /// <summary>
//        /// Pings the specified URL asynchronously.
//        /// </summary>
//        /// <param name="url">The URL to ping.</param>
//        private async Task PingUrlAsync(string url)
//        {
//            PingUrls objPingUrls = new()
//            {
//                EndWeb = " ",
//                IP = " ",
//                PingTime = " ",
//                TxtToTextBox1 = ConvIntToBinary[DateTime.Now.Hour],
//                TxtToTextBox2 = ConvIntToBinary[DateTime.Now.Minute]
//            };

//            if (chkBox_Ping.Checked)
//            {
//                try
//                {
//                    Dia = DateTime.Now.ToString("yyyy MM dd hh mm ss fff");
//                    idx = urlIndx == 0 ? urllength : urlIndx;
//                    objPingUrls.EndWeb = "     ********************************     ";
//                    objPingUrls.IP = " ";
//                    objPingUrls.PingTime = " ICMP - (PING) na Url: " + url[idx - 1];

//                    Ping pingreq = new();
//                    PingReply rep = await pingreq.SendPingAsync(url);

//                    if (rep.Status == IPStatus.Success)
//                    {
//                        objPingUrls.EndWeb = url;
//                        objPingUrls.IP = " IP: " + rep.Address.ToString();
//                        objPingUrls.PingTime = "Tempo de resposta: " + rep.RoundtripTime + " ms";
//                    }
//                }
//                catch (Exception ex)
//                {
//                    // Handle the exception
//                }
//            }

//            if (chkBox_Log.Checked)
//            {
//                Finf = string.IsNullOrEmpty(textBox4.Text) ? new FileInfo(@"C:\Temp\PingLog.txt") : new FileInfo(textBox4.Text);
//                try
//                {
//                    using StreamWriter swriter = Finf.AppendText();
//                    swriter.WriteLine($"{Dia} {objPingUrls.EndWeb} {objPingUrls.IP} {objPingUrls.PingTime}");
//                }
//                catch (Exception ex)
//                {
//                    HandleLogException(ex);
//                }
//            }

//            UpdateUI(objPingUrls);
//        }

//        /// <summary>
//        /// Handles the log exception.
//        /// </summary>
//        /// <param name="ex">The exception.</param>
//        private void HandleLogException(Exception ex)
//        {
//            // Log or handle the exception
//        }

//        /// <summary>
//        /// Updates the UI with the ping results.
//        /// </summary>
//        /// <param name="objPingUrls">The ping results.</param>
//        private void UpdateUI(PingUrls objPingUrls)
//        {
//            textBox1.Text = objPingUrls.TxtToTextBox1;
//            textBox2.Text = objPingUrls.TxtToTextBox2;

//            if (!string.IsNullOrEmpty(objPingUrls.EndWeb))
//            {
//                textBox3.Text = $"{objPingUrls.EndWeb}{Environment.NewLine}{objPingUrls.IP}{Environment.NewLine}{objPingUrls.PingTime}{Environment.NewLine}";
//            }
//        }

//        /// <summary>
//        /// Handles the Scroll event of the trackBar1 control.
//        /// </summary>
//        /// <param name="sender">The source of the event.</param>
//        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
//        private void TrackBar1_Scroll(object sender, EventArgs e)
//        {
//            trackBar1.TabIndex = 75;
//            OpFunct(trackBar1.Value);
//        }

//        /// <summary>
//        /// Sets the opacity of the form.
//        /// </summary>
//        /// <param name="value">The opacity value.</param>
//        public void OpFunct(float value)
//        {
//            this.Opacity = value / 100;
//            this.Refresh();
//        }

//    }
//    /// <summary>
//    /// The PingUrls class.
//    /// </summary>
//    class PingUrls
//    {
//        /// <summary>
//        /// Gets or sets the end web.
//        /// </summary>
//        public string EndWeb { get; set; }

//        /// <summary>
//        /// Gets or sets the IP.
//        /// </summary>
//        public string IP { get; set; }

//        /// <summary>
//        /// Gets or sets the ping time.
//        /// </summary>
//        public string PingTime { get; set; }

//        /// <summary>
//        /// Gets or sets the time to live.
//        /// </summary>
//        public string TimeToLive { get; set; }

//        /// <summary>
//        /// Gets or sets the text to text box 1.
//        /// </summary>
//        public string TxtToTextBox1 { get; set; }

//        /// <summary>
//        /// Gets or sets the text to text box 2.
//        /// </summary>
//        public string TxtToTextBox2 { get; set; }
//    }
//}