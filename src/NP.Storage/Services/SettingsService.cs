using System;
using System.IO;
using Newtonsoft.Json;
using NP.Core.Models;
using NP.Storage.Models;

namespace NP.Storage.Services
{
    public class SettingsService
    {
        private readonly string _filePath;

        public SettingsService()
        {
            //_filePath = Path.Combine(
            //    AppDomain.CurrentDomain.BaseDirectory,
            //    "Config",
            //    "config.json");

            string appData =
    Environment.GetFolderPath(
        Environment.SpecialFolder.ApplicationData);

            _filePath = Path.Combine(
                appData,
                "NP_AI_RuntimeStudio",
                "config.json");

            EnsureConfigExists();
        }

        private void EnsureConfigExists()
        {
            var dir = Path.GetDirectoryName(_filePath);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            if (!File.Exists(_filePath))
            {
                var defaultConfig = new ConfigModel
                {
                    AiProviderUrl = "",
                    AiApiKey = "",
                    AiModel = "",
                    TimeoutSeconds = 300
                };

                var json = JsonConvert.SerializeObject(defaultConfig, Formatting.Indented);

                File.WriteAllText(_filePath, json);
            }
        }

        public AiProviderSettings Load()
        {
            var json = File.ReadAllText(_filePath);
            var config = JsonConvert.DeserializeObject<ConfigModel>(json);

            return new AiProviderSettings
            {
                Url = config.AiProviderUrl,
                ApiKey = config.AiApiKey,
                Model = config.AiModel,
                TimeoutSeconds = config.TimeoutSeconds
            };
        }

        public void Save(AiProviderSettings settings)
        {
            var config = new ConfigModel
            {
                AiProviderUrl = settings.Url,
                AiApiKey = settings.ApiKey,
                AiModel = settings.Model,
                TimeoutSeconds = settings.TimeoutSeconds
            };

            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}