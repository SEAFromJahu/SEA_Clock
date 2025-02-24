using System.Text.Json;

public partial class Form1 : Form
{
    private AppConfig config;
    private int urlIndx = 0;
    private string Dia;
    private FileInfo Finf = null;
    private int urllength;

    public Form1()
    {
        InitializeComponent();
        LoadConfig();
        urllength = config.Urls.Length - 1;
        trackBar1.Value = config.InitialTrackBarValue;
        timer1.Start();
    }

    private void LoadConfig()
    {
        try
        {
            string configContent = File.ReadAllText("config.json");
            config = JsonSerializer.Deserialize<AppConfig>(configContent);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading configuration: " + ex.Message);
            // Set default values if config fails to load
            config = new AppConfig
            {
                InitialTrackBarValue = 35,
                ProcessCheckRetries = 5,
                ProcessCheckDelayMilliseconds = 2000,
                Urls = new string[] {
                    "loopback", "www.ceptro.br", "www.cgi.br", "www.claro.com.br", "www.facebook.com",
                    "www.globo.com", "www.google.com", "www.linkedin.com", "www.nic.br", "www.terra.com.br",
                    "www.tim.com.br", "www.udemy.com", "www.uol.com.br", "www.vivo.com", "www.yahoo.com",
                    "www.youtube.com"
                },
                LogFilePath = @"C:\Temp\PingLog.txt"
            };
        }
    }
}
