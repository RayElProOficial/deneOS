using Microsoft.Win32;
using System.Diagnostics;
using System.Text.Json;
using dosu;

namespace deneOS_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\DENEOS\\core\\deneOS.exe")) return;
            button1.Text = @"INSTALL►";
            button1.Click -= button1_Click!;
            button1.Click += Install_Click!;
        }

        async void Install_Click(object sender, EventArgs e)
        {
            SetupScreen setup = new SetupScreen();
            setup.Show();
            /*
            var response = MessageBox.Show(@"Install on Verbose mode?", @"deneOS Setup", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            var info = await GetUpdateInfo();
            if (info.Equals(null))
            {
                MessageBox.Show(@"Could not fetch update information.");
                return;
            }

            switch (response)
            {
                case DialogResult.Yes:
                    MessageBox.Show(@"Installing fonts...", @"deneOS Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InstallFonts();
                    MessageBox.Show(@"Installing deneOS...");
                    await UpdateScreen(true, info.download!);
                    MessageBox.Show(@"Installing languages...");
                    InstallLanguages();
                    MessageBox.Show(@"Writing Configuration...");
                    WriteConfiguration();
                    MessageBox.Show(@"Downloading System Applications...");
                    DownloadSystemApps();
                    MessageBox.Show(@"Installation completed successfully!", @"deneOS Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case DialogResult.No:
                    InstallFonts();
                    await UpdateScreen(false, info.download!);
                    InstallLanguages();
                    WriteConfiguration();
                    DownloadSystemApps();
                    MessageBox.Show(@"Installation completed successfully!", @"deneOS Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case DialogResult.Cancel:
                    MessageBox.Show(@"Installation cancelled.", @"deneOS Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }

            Process.Start(Application.ExecutablePath);
            Application.Exit();*/
        }
/*
        async Task DownloadAll()
        {
            await btnCheckUpdates_Click(false);
            InstallFonts();
            InstallLanguages();
            WriteConfiguration();
            DownloadSystemApps();

            MessageBox.Show(@"Installation completed successfully!", @"deneOS Setup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
*/
        void InstallFonts()
        {
            FontInstaller.InstallFonts();
        }
        private async Task<UpdateInfo> GetUpdateInfo()
        {
            using HttpClient client = new HttpClient();
            try
            {
                string json = await client.GetStringAsync("https://repoficialx.xyz/deneOS/api/versions.json");
                return JsonSerializer.Deserialize<UpdateInfo>(json)!;
            }
            catch
            {
                return null!;
            }
        }

        private class UpdateInfo
        {
            public string? latestVersion { get; set; }
            public string? download { get; set; }
            public string? changelog { get; set; }
        }/*
        private async Task btnCheckUpdates_Click(bool verbose)
        {
            var info = await GetUpdateInfo();
            if (info.Equals(null))
            {
                await UpdateScreen(true, info!.download!);
            }
            //return info;
        }
        */


        private string currentVersion;// = Utils.deneOSVersion.ShortVersion.GetVersion(Utils.deneOSVersion.ShortVersion.Formats.M_mx);
        
        
        async Task UpdateScreen(bool verbose, string downloadUrl)
        {
            if (!Directory.Exists(@"C:\DENEOS\core\"))
                Directory.CreateDirectory(@"C:\DENEOS\core\");

            currentVersion = File.Exists(@"C:\DENEOS\core\deneOS.exe") ? Utils.deneOSVersion.ShortVersion.GetVersion(Utils.deneOSVersion.ShortVersion.Formats.M_mx) : "0.0";
            string corePath = @"C:\DENEOS\core\";
            string exePath = Path.Combine(corePath, "deneOS.exe");
            string backupPath = Path.Combine(corePath, $"deneOS_{currentVersion}.bak");
            string tempPath = Path.Combine(corePath, "deneOS.new");

            if (verbose) MessageBox.Show(@"Closing deneOS...");

            // 1️⃣ Cerrar deneOS si está abierto
            try
            {
                var kill = Process.Start(new ProcessStartInfo
                {
                    FileName = "taskkill",
                    Arguments = "/f /im deneOS.exe",
                    UseShellExecute = true,
                    Verb = "runas",
                    CreateNoWindow = true
                });
                await kill!.WaitForExitAsync();
            }
            catch
            {
                // No estaba abierto → seguimos
            }

            // 2️⃣ Backup del binario actual
            if (File.Exists(exePath))
            {
                File.Copy(exePath, backupPath, overwrite: true);
            }

            if (verbose) MessageBox.Show(@"Downloading update...");

            // 3️⃣ Descargar nuevo binario a archivo temporal usando HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();
                    using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fs);
                    }
                }
            }

            // 4️⃣ Reemplazo
            File.Move(tempPath, exePath, overwrite: true);

            if (verbose) MessageBox.Show(@"deneOS updated successfully.");
        }


        void InstallLanguages()
        {
            string languagesPath = @"C:\DENEOS\lang\";
            if (!Directory.Exists(languagesPath))
            {
                Directory.CreateDirectory(languagesPath);
            }
            string[] languages =
            [
                "en.json",
                "es.json"
            ];

            using (HttpClient client = new HttpClient())
            {
                foreach (string language in languages)
                {
                    string languageUri = $"https://repoficialx.xyz/deneOS/api/{language}";
                    string languagePath = Path.Combine(languagesPath, language);
                    if (File.Exists(languagePath))
                    {
                        File.Delete(languagePath);
                    }
                    var data = client.GetByteArrayAsync(languageUri).GetAwaiter().GetResult();
                    File.WriteAllBytes(languagePath, data);
                    Console.WriteLine($@"Downloaded {language} to {languagePath}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process dnh = new Process();
            dnh.StartInfo.FileName = "c:\\DENEOS\\core\\deneOS.exe";
            dnh.StartInfo.Verb = "runas";
            dnh.StartInfo.UseShellExecute = true;
            dnh.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F10) return;
            System.Media.SystemSounds.Asterisk.Play();
            //System.Media.SoundPlayer sp = new();
            //sp.SoundLocation = "deneos_sound.wav";
            //sp.Play();

            if (button1.Text != @"INSTALL►")
            {
                button1.Text = @"INSTALL►";
                button1.Click -= button1_Click!;
                button1.Click += Install_Click!;
            }
            else
            {
                button1.Text = @"RUN►";
                button1.Click -= Install_Click!;
                button1.Click += button1_Click!;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {   
        }
    }
}
