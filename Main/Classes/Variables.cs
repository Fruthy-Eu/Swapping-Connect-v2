using System;

namespace SwappingConnectV2.Main.Classes
{
    class Variables
    {
        public static ItemModel targetItem { get; set; }
        public static Swapper targetSwapper { get; set; } = Swapper.Saturn;
        public static string targetSwapperPath { get; set; }
        public static ItemType currentType = ItemType.Skin;

        public const string INDEX_ENDPOINT = "https://github.com/Fruthy-Ue/Swapping-Connect-v2-Api/raw/main/Index";
        //public const string BASE_ENDPOINT = "https://localhost:7004";
        public const string ITEMS_ENDPOINT = "https://raw.githubusercontent.com/Fruthy-Ue/Swapping-Connect-v2-Api/main/Items/Items";
        public const string USER_VERSION = "1.0.0";
        
        public static readonly string BasePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\SwappingConnectV2\\";
        public static readonly string ConfigPath = BasePath + "config.json";
    }
}
