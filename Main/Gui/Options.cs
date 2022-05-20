using System;
using System.Windows.Forms;
using SwappingConnectV2.Main.Classes;

namespace SwappingConnectV2.Main.GUI
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            this.ActiveControl = label1;
            
            // Load settings
            SwapperBox.SelectedItem = Statics.config.GetSwapper() switch
            {
                Swapper.Saturn => "Saturn",
                Swapper.Galaxy => "Galaxy",
                Swapper.Custom => "Custom",
                _ => throw new ArgumentOutOfRangeException()
            };

            if (Statics.config.GetPluginPath() == "Unused" || string.IsNullOrWhiteSpace(Statics.config.GetPluginPath())) return;
            bunifuMaterialTextbox1.Text = Statics.config.GetPluginPath();
            Variables.targetSwapperPath = Statics.config.GetPluginPath();

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Variables.targetSwapper = SwapperBox.SelectedText switch
            {
                "Saturn" => Swapper.Saturn,
                "Galaxy" => Swapper.Galaxy,
                "Custom" => Swapper.Custom,
                _ => Variables.targetSwapper
            };

            Variables.targetSwapperPath = bunifuMaterialTextbox1.Text + "//";

            Statics.config.SetSwapper(Variables.targetSwapper);
            Statics.config.SetPluginPath(Variables.targetSwapperPath);
            
            Close();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            Variables.targetSwapperPath = bunifuMaterialTextbox1.Text;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            // Open a file browser and save the path to the textbox and to variables.targetswapperpath
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Plugin Files (*.json)|*.json";
            openFileDialog.Title = "Select a Plugin File";
            openFileDialog.ShowDialog();
            string filePath = openFileDialog.FileName;
            if (!string.IsNullOrEmpty(filePath))
            {
                bunifuMaterialTextbox1.Text = filePath;
                Variables.targetSwapperPath = filePath;
            }
        }
    }
}
