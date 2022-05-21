using System;
using System.Diagnostics;
using System.Windows.Forms;
using SwappingConnectV2.Main.Classes;
using SwappingConnectV2.Main.GUI;

namespace SwappingConnectV2.Panels
{
    public partial class LoginControl : UserControl
    {
        private bool _once = false;
        public LoginControl()
        {
            InitializeComponent();
        }

        private void BunifuFlatButton12_Click(object sender, EventArgs e)
        {
            string key = Key.Text;

            if (key.CheckKey())
            {
                Statics.config.SetKey(key);
                Home popup = new Home();
                popup.Show();
            }
            else
            {
                MessageBox.Show("The key entered does not exist. Has it expired?", "Error");
            }
        }

        private void TwoFA_Click(object sender, EventArgs e)
        {
            if (!_once)
            {
                Key.Text = "";
                _once = true;
            }
        }

        private void LoginControl_Load(object sender, EventArgs e)
        {
            Key.Text = Statics.config.GetKey();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Process.Start(Statics.index.KeyLink);
        }
    }
}
