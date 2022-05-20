namespace SwappingConnectV2.Main.Classes.Models
{
    public class ConfigModel
    {
        public Swapper TargetSwapper { get; set; } = Swapper.Saturn;
        public string TargetPluginPath { get; set; } = "Unused";
        public string Key { get; set; } = "Key here";
    }
}
