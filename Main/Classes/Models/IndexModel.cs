using Newtonsoft.Json;

namespace SwappingConnectV2.Main.Classes.Models
{
    public class IndexModel
    {
        [JsonProperty("key")] public string Key { get; set; }
        [JsonProperty("version")] public string Version { get; set; }
        [JsonProperty("downtimeMessage")] public string DowntimeMessage { get; set; }
        [JsonProperty("discordServer")] public string DiscordServer { get; set; }
        [JsonProperty("keyLink")] public string KeyLink { get; set; }
    }
}
