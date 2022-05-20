using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JankySwapper.Main.GUI
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            this.ActiveControl = label1;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowserDialog.SelectedPath;
                    bunifuMaterialTextbox1.Text = selectedPath;
                    JankySwapper.Properties.Settings.Default["paks"] = selectedPath;
                    JankySwapper.Properties.Settings.Default.Save();
                    timer1.Start();
                    bunifuMaterialTextbox1.Text = selectedPath;
                }
            }
        }
    }
}
