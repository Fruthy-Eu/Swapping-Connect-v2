using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SwappingConnectV2.Main.Classes
{
    static class Utilities
    {
        public static bool CheckKey(this string key)
            => key == Statics.index.Key;
    }
}

