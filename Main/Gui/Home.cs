using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using SwappingConnectV2.Main.Classes;
using SwappingConnectV2.Panels;

namespace SwappingConnectV2.Main.GUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            if (!Wrapper.Controls.Contains(DashPanel.Instance))
            {
                Wrapper.Controls.Add(DashPanel.Instance);
                DashPanel.Instance.Dock = DockStyle.Fill;
                DashPanel.Instance.BringToFront();
            }
            else
                DashPanel.Instance.BringToFront();


            var currentUser = Statics.discordRpc.ReturnUser(); // Get the current user

            for (int i = 0; i <= 5; i++) // If the current user doesn't exist, try to get it again (MAX 5 TIMES)
            {
                if (currentUser == null) // If the current user doesn't exist
                {
                    Task.Delay(500).Wait(); // Wait half a second
                    currentUser = Statics.discordRpc.ReturnUser(); // Get the current user
                }
            }

            if (currentUser != null)
            {
                bunifuImageButton9.ImageLocation = Statics.discordRpc.ReturnUser().GetAvatarURL(User.AvatarFormat.PNG);
            }

        }

        private void MenuSidebar_Click(object sender, EventArgs e)
        {
            if (Sidebar.Width == 270)
            {
                Sidebar.Visible = false;
                Sidebar.Width = 68;
                SidebarWrapper.Width = 90;
                LineaSidebar.Width = 52;
                AnimacionSidebar.Show(Sidebar);
            }
            else
            {
                Sidebar.Visible = false;
                Sidebar.Width = 270;
                SidebarWrapper.Width = 300;
                LineaSidebar.Width = 252;
                AnimacionSidebarBack.Show(Sidebar);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e) //Display DashPanel
        {
            Statics.discordRpc.SetDiscordLocation("Dashboard");
            if (!Wrapper.Controls.Contains(DashPanel.Instance))
            {
                Wrapper.Controls.Add(DashPanel.Instance);
                DashPanel.Instance.Dock = DockStyle.Fill;
                DashPanel.Instance.BringToFront();
            }
            else
                DashPanel.Instance.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e) //Display SkinsPanel
        {
            Statics.discordRpc.SetDiscordLocation("Skins");
            Variables.currentType = ItemType.Skin;
            if (!Wrapper.Controls.Contains(SkinsPanel.Instance))
            {
                Wrapper.Controls.Add(SkinsPanel.Instance);
                SkinsPanel.Instance.Dock = DockStyle.Fill;
                SkinsPanel.Instance.BringToFront();
            }
            else
                SkinsPanel.Instance.BringToFront();

            SkinsPanel.Instance.LoadItems();

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e) //Display BackblingsPanel
        {
            Statics.discordRpc.SetDiscordLocation("Backblings");
            Variables.currentType = ItemType.Backbling;
            if (!Wrapper.Controls.Contains(SkinsPanel.Instance))
            {
                Wrapper.Controls.Add(SkinsPanel.Instance);
                SkinsPanel.Instance.Dock = DockStyle.Fill;
                SkinsPanel.Instance.BringToFront();
            }
            else
                SkinsPanel.Instance.BringToFront();

            SkinsPanel.Instance.LoadItems();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e) //Display PickaxesPanel
        {
            Statics.discordRpc.SetDiscordLocation("Pickaxes");
            Variables.currentType = ItemType.Pickaxe;
            if (!Wrapper.Controls.Contains(SkinsPanel.Instance))
            {
                Wrapper.Controls.Add(SkinsPanel.Instance);
                SkinsPanel.Instance.Dock = DockStyle.Fill;
                SkinsPanel.Instance.BringToFront();
            }
            else
                SkinsPanel.Instance.BringToFront();

            SkinsPanel.Instance.LoadItems();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e) //Display EmotesPanel
        {
            Statics.discordRpc.SetDiscordLocation("Emotes");
            Variables.currentType = ItemType.Emote;
            if (!Wrapper.Controls.Contains(SkinsPanel.Instance))
            {
                Wrapper.Controls.Add(SkinsPanel.Instance);
                SkinsPanel.Instance.Dock = DockStyle.Fill;
                SkinsPanel.Instance.BringToFront();
            }
            else
                SkinsPanel.Instance.BringToFront();

            SkinsPanel.Instance.LoadItems();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e) //Display WrapsPanel
        {
            Statics.discordRpc.SetDiscordLocation("Special");
            Variables.currentType = ItemType.Special;
            if (!Wrapper.Controls.Contains(SkinsPanel.Instance))
            {
                Wrapper.Controls.Add(SkinsPanel.Instance);
                SkinsPanel.Instance.Dock = DockStyle.Fill;
                SkinsPanel.Instance.BringToFront();
            }
            else
                SkinsPanel.Instance.BringToFront();

            SkinsPanel.Instance.LoadItems();
        }

        private void displaySettings_Click(object sender, EventArgs e)
        {
            Form SettingsForm = new Options();
            SettingsForm.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            List<Form> forms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                if (f.Name == "Login")
                    forms.Add(f);

            foreach (Form f in forms)
                f.Hide();
        }

        private void bunifuFlatButton11_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/uShUdSE3ME");
        }

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

