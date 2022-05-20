using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using SwappingConnectV2.Main.Classes;
using System.Windows.Forms;
using Newtonsoft.Json;
using SwappingConnectV2.Main.GUI;

namespace SwappingConnectV2.Panels
{
    public partial class SkinsPanel : UserControl
    {
        private static SkinsPanel _instance;      
        public static SkinsPanel Instance => _instance ?? (_instance = new SkinsPanel());
        
        private readonly List<ItemModel> _plugins = new List<ItemModel>();

        public SkinsPanel()
        {
            InitializeComponent();
            
            WebClient client = new WebClient();

            var response = client.DownloadString(Variables.ITEMS_ENDPOINT);
            _plugins = JsonConvert.DeserializeObject<List<ItemModel>>(response);
        }

        public void LoadItems()
        {
            Flow.Controls.Clear();

            foreach (var item in _plugins.FindAll(x => x.Type == Variables.currentType))
            {
                PictureBox pictureBox = new PictureBox()
                {
                    Name = item.Name,
                    ImageLocation = item.Icon,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(70, 70),
                    Cursor = Cursors.Hand
                };
                pictureBox.Click += OpenDownload;
                Flow.Controls.Add(pictureBox);
            }
        }

        private void OpenDownload(object sender, EventArgs e)
        {
            var pictureSender = (PictureBox)sender;
            Variables.targetItem = _plugins.First(x => x.Name == pictureSender.Name);
            
            new DownloadForm().Show();
        }
    }
}
