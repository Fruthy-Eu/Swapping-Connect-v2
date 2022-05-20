using System.IO;
using Newtonsoft.Json;
using SwappingConnectV2.Main.Classes.Models;

namespace SwappingConnectV2.Main.Classes
{
    public class Config
    {
        private readonly ConfigModel _config;
        public Config()
        {
            Directory.CreateDirectory(Variables.BasePath);
            _config = File.Exists(Variables.ConfigPath) ? JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(Variables.ConfigPath)) : new ConfigModel();
            Save();
        }
        
        public void Save()
        {
            File.WriteAllText(Variables.ConfigPath, JsonConvert.SerializeObject(_config));
        }
        
        public void SetSwapper(Swapper targetSwapper)
        {
            _config.TargetSwapper = targetSwapper;
            Save();
        }
        
        public Swapper GetSwapper()
        {
            return _config.TargetSwapper;
        }
        
        public void SetPluginPath(string pluginPath)
        {
            _config.TargetPluginPath = pluginPath;
            Save();
        }
        
        public string GetPluginPath()
        {
            return _config.TargetPluginPath;
        }

        public string GetKey()
        {
            return _config.Key;
        }

        public void SetKey(string key)
        {
            _config.Key = key;
            Save();
        }

    }
}