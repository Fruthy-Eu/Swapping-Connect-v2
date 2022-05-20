using SwappingConnectV2.Main.Classes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SwappingConnectV2.Main.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Home popup = new Home();
            popup.Show();
            Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Statics.discordRpc.SetDiscordAction("Checking key");
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
