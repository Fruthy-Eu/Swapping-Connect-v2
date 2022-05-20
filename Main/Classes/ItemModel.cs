#nullable enable
namespace SwappingConnectV2.Main.Classes
{
    class ItemModel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string SwapIcon { get; set; }
        public ItemType Type { get; set; }
        public string? DownloadMessage { get; set; }
        public string DownloadURL { get; set; }
    }
}
