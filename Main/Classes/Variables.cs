using System;

namespace SwappingConnectV2.Main.Classes
{
    class Variables
    {
        public static ItemModel targetItem { get; set; }
        public static Swapper targetSwapper { get; set; } = Swapper.Saturn;
        public static string targetSwapperPath { get; set; }
        public static ItemType currentType = ItemType.Skin;

        public const string KEY_LINK = "https://linkvertise.com";
        public const string BASE_ENDPOINT = "https://localhost:7004";
        public const string ITEMS_ENDPOINT = "https://pastebin.com/raw/xwMV6Gvu";
        public const string USER_VERSION = "1.0.0";
        
        public static readonly string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\SwappingConnectV2\\";
        public static readonly string ConfigPath = BasePath + "config.json";
    }
}
