using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;
using SwappingConnectV2.Main.Classes;

namespace SwappingConnectV2.Main.GUI
{
    public partial class DownloadForm : Form
    {
        public DownloadForm()
        {
            InitializeComponent();

            bunifuImageButton1.ImageLocation = Variables.targetItem.SwapIcon;
            Statics.discordRpc.SetDiscordAction(Variables.targetItem.Name);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Convert.RunWorkerAsync();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Revert.RunWorkerAsync();
        }

		private void Convert_DoWork(object sender, DoWorkEventArgs e)
		{
            CheckForIllegalCrossThreadCalls = false;

            if (Convert.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            
            richTextBox1.Text = "";

            richTextBox1.Text += "\n[LOG] Starting...";

            switch (Variables.targetSwapper)
            {
                case Swapper.Saturn:
                    richTextBox1.Text += "\n[LOG] Target swapper is Saturn.";
                    DownloadPluginToPath(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Saturn\\Plugins\\");
                    break;
                case Swapper.Galaxy:
                    richTextBox1.Text += "\n[LOG] Target swapper is Galaxy.";
                    DownloadPluginToPath(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\galaxy-swapper-v2-config\\plugins\\");
                    break;
                case Swapper.Custom:
                    richTextBox1.Text += "\n[LOG] Target swapper is Custom.";
                    DownloadPluginToPath(Variables.targetSwapperPath);
                    break;
                default:
                    richTextBox1.Text += "\n[LOG] Target swapper is not set.";
                    richTextBox1.Text += "\n[LOG] Cancelling the download.";
                    break;
            }
            
            richTextBox1.Text += "\n[LOG] Added the plugin!";
        }

        private void DownloadPluginToPath(string pluginPath)
        {
            WebClient client = new WebClient();

            var pluginContent = client.DownloadString(Variables.targetItem.DownloadURL);

            Directory.CreateDirectory(pluginPath);
            
            File.WriteAllText(pluginPath + Variables.targetItem.Name + ".json", pluginContent);
        }

        private void DeletePluginFromPath(string pluginPath)
        {
            foreach (var file in Directory.GetFiles(pluginPath))
            {
                if (file.Contains(Variables.targetItem.Name))
                    File.Delete(file);
            }
        }

		private void Revert_DoWork(object sender, DoWorkEventArgs e)
		{
            CheckForIllegalCrossThreadCalls = false;

            if (Revert.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            
            richTextBox1.Text = "";

            richTextBox1.Text += "\n[LOG] Starting...";

            switch (Variables.targetSwapper)
            {
                case Swapper.Saturn:
                    richTextBox1.Text += "\n[LOG] Target swapper is Saturn.";
                    DeletePluginFromPath(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Saturn\\Plugins\\");
                    break;
                case Swapper.Galaxy:
                    richTextBox1.Text += "\n[LOG] Target swapper is Galaxy.";
                    DeletePluginFromPath(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\galaxy-swapper-v2-config\\plugins\\");
                    break;
                case Swapper.Custom:
                    richTextBox1.Text += "\n[LOG] Target swapper is Custom.";
                    DeletePluginFromPath(Variables.targetSwapperPath);
                    break;
                default:
                    richTextBox1.Text += "\n[LOG] Target swapper is not set.";
                    richTextBox1.Text += "\n[LOG] Cancelling the deletion.";
                    break;
            }
            
            richTextBox1.Text += "\n[LOG] Removed the plugin!";
        }

        private void Download_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Variables.targetItem.DownloadMessage))
                MessageBox.Show(Variables.targetItem.DownloadMessage, "Download Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
