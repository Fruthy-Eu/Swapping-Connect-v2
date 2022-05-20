using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SwappingConnectV2.Main.Classes
{
    static class Utilities
    {
        public static string ReturnContent(string path)
        {
            return new WebClient().DownloadString(Variables.BASE_ENDPOINT + path);
            HttpClient client = new();
            client.Timeout = TimeSpan.FromSeconds(5);
            var result = client.GetAsync(Variables.BASE_ENDPOINT + path).GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode)
                return result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return "false";
        }

        public static bool CheckKey(this string key)
            => JsonConvert.DeserializeObject<bool>(ReturnContent($"/api/v1/CheckKey?key={key}"));
    }
}

